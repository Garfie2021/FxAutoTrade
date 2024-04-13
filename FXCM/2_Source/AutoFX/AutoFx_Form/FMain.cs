using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;
using SystemCommon;
using 定数;
using Common;
using DB;
using FXCM;

namespace AutoFx_Form
{
	public partial class FMain : Form
	{
		#region 公開 共通メソッド

		public FMain()
		{
			InitializeComponent();
		}

		#endregion

		#region 非公開 共通メソッド

		public void CommandLineからForm設定()
		{
			if (システム設定.CommandLine.IndexOf("RealA_FX", StringComparison.Ordinal) > -1)
			{
				chk毎朝の自動注文開始を行う.Checked = false;
			}
			else if (システム設定.CommandLine.IndexOf("RealB_FX", StringComparison.Ordinal) > -1)
			{
				chk毎朝の自動注文開始を行う.Checked = false;
			}
			else if (システム設定.CommandLine.IndexOf("RealB_2370741682_FX", StringComparison.Ordinal) > -1)
			{
				chk毎朝の自動注文開始を行う.Checked = false;
			}
			else if (システム設定.CommandLine.IndexOf("RealB_2370741683_FX", StringComparison.Ordinal) > -1)
			{
				chk毎朝の自動注文開始を行う.Checked = false;
			}
			else if (システム設定.CommandLine.IndexOf("DemoA_FX", StringComparison.Ordinal) > -1)
			{
				chk毎朝の自動注文開始を行う.Checked = true;
			}
			else if (システム設定.CommandLine.IndexOf("DemoB_FX", StringComparison.Ordinal) > -1)
			{
				chk毎朝の自動注文開始を行う.Checked = true;
			}
		}

		private void 実行モード確認()
		{
			if (システム設定.CommandLine.IndexOf("Real", StringComparison.Ordinal) > -1)
			{
				if (Properties.Settings.Default.FXConnectionString.IndexOf("Demo", StringComparison.Ordinal) > -1)
				{
					if (DialogResult.Yes != MessageBox.Show("アプリケーションのコマンドラインと、DB接続先が一致していませんが、続行しますか？"
						, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
						throw new System.Exception("アプリケーションのコマンドラインとDB接続先が不一致");
				}
			}
			else if (システム設定.CommandLine.IndexOf("Demo", StringComparison.Ordinal) > -1)
			{
				if (Properties.Settings.Default.FXConnectionString.IndexOf("Real", StringComparison.Ordinal) > -1)
				{
					if (DialogResult.Yes != MessageBox.Show("アプリケーションのコマンドラインと、DB接続先が一致していませんが、続行しますか？"
						, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
						throw new System.Exception("アプリケーションのコマンドラインとDB接続先が不一致");
				}
			}
		}

		private void DB接続先表示()
		{
			Properties.Settings.Default.FXConnectionString = システム設定.DBConnectionString;
			Properties.Settings.Default.Save();
			txtDB接続先.Text = Properties.Settings.Default.FXConnectionString;
		}

		private void Start()
		{
			try
			{
				システム設定.CommandLineから環境設定();
				CommandLineからForm設定();

				ログ.初期化();
                //Trade共通.初期化();


                バグチェック();

				DB接続先表示();
				システム設定_表示();

				システム日時更新();

				Form設定.注文設定DGV初期化(ref dgv注文設定);

				実行モード確認();


				using (SqlConnection cn = new SqlConnection())
				{
					cn.ConnectionString = Properties.Settings.Default.FXConnectionString;
					cn.Open();

					// 自動ログイン取引開始
					if (システム設定.CommandLine.IndexOf("Auto", StringComparison.Ordinal) > -1)
					{
						txtAuto.Text = "Auto";

						if (システム設定.Trade時間内 == "時間内")
						{
							bool TradingServerDisconnect = true;

							while (TradingServerDisconnect)
							{
								try
								{
									ログイン_Order開始(cn);
									自動取引開始終了();

									TradingServerDisconnect = false; // Ttrading server に接続できたのでループを抜ける。
								}
								catch (Exception ex)
								{
									if (ex.Message.IndexOf(FX定数.trading_server_was_lost, StringComparison.Ordinal) > -1)
									{
										System.Threading.Thread.Sleep(60000); // 1分待ってTrading serverが復旧している事を期待。
									}
								}
							}

							//timer_Rate記録_3sec.Enabled = true;
						}
					}
					else
					{
						txtAuto.Text = "";
					}

					txt当日注文数.Text = fxcm.Cnt当日注文数(cn, 注文共通.Get当日の開始日時(DateTime.Now)).ToString();
					txt当日約定数.Text = fxcm.Cnt約定数(cn, 注文共通.Get当日の開始日時(DateTime.Now)).ToString();
					txt当日約定金額.Text = fxcm.GetSUM差益(cn, 注文共通.Get当日の開始日時(DateTime.Now), DateTime.Now).ToString();
				}

				timer_日時曜日更新_1sec.Enabled = true;
			}
			catch (Exception ex)
			{
				Exception共通(true, ex, new List<Cエラー関連変数>());
			}
		}

		private void chk注文状態記録まで注文はスキップ_CheckedChanged(object sender, EventArgs e)
		{
			if (chk注文状態記録まで注文はスキップ.Checked == true)
			{
				ToolStripStsLbl.Text = "「注文状態記録まで注文はスキップ」：チェック有り";
				ToolStripStsLbl.BackColor = Color.Yellow;
			}
			else if (chk注文状態記録まで注文はスキップ.Checked == false)
			{
				ToolStripStsLbl.Text = "";
				ToolStripStsLbl.BackColor = Color.Gray;
			}

		}

		private void 全Timerを停止()
		{
			//全てのTimerを停止
			timer_Order_5sec.Enabled = false;
			//timer_1min.Enabled = false;
			timer_10min.Enabled = false;
			timer_1h.Enabled = false;
			timer_日時曜日更新_1sec.Enabled = false;

			txt取引モード表示.Text = "";
		}


		private void ログイン()
		{
			TradeFXCM.ログイン(システム設定.FxcmConnection, システム設定.FxcmUsername, システム設定.FxcmPassword);

			timer_DB記録_3min.Enabled = true;

			txtログイン表示.Text = "ログイン中";
		}

		private void ログアウト()
		{
			timer_DB記録_3min.Enabled = false;

			TradeFXCM.Logout();

			txtログイン表示.Text = "";
		}

		private void ログイン_ログアウト()
		{
			if (txtログイン表示.Text == "")
				ログイン();
			else
				ログアウト();

			ToolStripStsLbl.Text = "ログインしました";
		}

		private void システム日時更新()
		{
			txtシステム設定_年.Text = DateTime.Now.Year.ToString();
			txtシステム設定_月.Text = DateTime.Now.Month.ToString();
			txtシステム設定_日.Text = DateTime.Now.Day.ToString();
			txtシステム設定_時.Text = DateTime.Now.Hour.ToString();
			txtシステム設定_分.Text = DateTime.Now.Minute.ToString();
			txtシステム設定_秒.Text = DateTime.Now.Second.ToString();
			txtシステム設定_曜日.Text = DateTime.Now.DayOfWeek.ToString();

			txtシステム設定_Trade時間内.Text = システム設定.Trade時間内 = 注文共通.GetTrade時間内();
		}

		private void 自動取引を解除()
		{
			timer_Order_5sec.Enabled = false;
			//timer_1min.Enabled = false;
			timer_10min.Enabled = false;
			timer_1h.Enabled = false;
			txt取引モード表示.Text = "";
		}

		private void 自動取引を再開()
		{
			timer_Order_5sec.Enabled = true;
			//timer_1min.Enabled = true;
			timer_10min.Enabled = true;
			timer_1h.Enabled = true;
			txt取引モード表示.Text = "自動取引中";
		}

		private void 注文を全て削除する()
		{
			int 注文Entry数 = 0;
			TradeFXCM.注文を全て削除する(ref 注文Entry数);

			//txt注文Entry数.Text = 注文Entry数.ToString();
		}

		private static string 通貨ペア別Rate更新用_QuoteID = "";
		private static uint 通貨ペア別Rate更新用_Cnt = 0;
		private static bool 通貨ペア別Rate更新(SqlConnection cn, DateTime now, byte 通貨ペアNo,
			ref double 買いRate, ref double 売りRate, ref double 買いSwap, ref double 売りSwap, ref DataGridView dgv注文設定)
		{
			for (通貨ペア別Rate更新用_Cnt = 1; 通貨ペア別Rate更新用_Cnt <= TradeFXCM.offers.RowCount; 通貨ペア別Rate更新用_Cnt++)
			{
				if (FX定数.通貨ペア[通貨ペアNo] != (string)TradeFXCM.offers.CellValue(通貨ペア別Rate更新用_Cnt, "Instrument"))
					continue;

				買いRate = (double)TradeFXCM.offers.CellValue(通貨ペア別Rate更新用_Cnt, "Ask");
				売りRate = (double)TradeFXCM.offers.CellValue(通貨ペア別Rate更新用_Cnt, "Bid");

				if (売りRate < 0.00001 || 買いRate < 0.00001)
				{
					// FXCMのバグでRateが0以下になり、シグマ計算結果が狂う事件があったので、それはここで回避。
					return false;
				}

				買いSwap = (double)TradeFXCM.offers.CellValue(通貨ペア別Rate更新用_Cnt, "IntrB");
				売りSwap = (double)TradeFXCM.offers.CellValue(通貨ペア別Rate更新用_Cnt, "IntrS");

				dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_買いRate].Value = 買いRate;
				dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_売りRate].Value = 売りRate;
				dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_買いSwap].Value = 買いSwap;
				dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_売りSwap].Value = 売りSwap;

				rate.InsertRateHistory(cn, 通貨ペアNo, now, 買いRate, 売りRate, 買いSwap, 売りSwap);

				break;
			}

			return true;
		}

		public static uint QuoteID表示_iCnt;
		public static byte QuoteID表示_通貨ペアNo;
		private void QuoteID表示()
		{
			for (QuoteID表示_通貨ペアNo = 0; QuoteID表示_通貨ペアNo < FX定数.通貨ペア.Length; QuoteID表示_通貨ペアNo++)
			{
				if ((bool)dgv注文設定.Rows[QuoteID表示_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value == false)
					continue;

				for (QuoteID表示_iCnt = 1; QuoteID表示_iCnt <= TradeFXCM.offers.RowCount; QuoteID表示_iCnt++)
				{
					if (FX定数.通貨ペア[QuoteID表示_通貨ペアNo] != (string)TradeFXCM.offers.CellValue(QuoteID表示_iCnt, "Instrument"))
						continue;

					dgv注文設定.Rows[QuoteID表示_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_QuoteID].Value = 
						(string)TradeFXCM.offers.CellValue(QuoteID表示_iCnt, "QuoteID");
				}
			}
		}

		private void アカウント状態を表示()
		{
			txt取引証拠金.Text = ((double)TradeFXCM.accounts.CellValue(1, "Balance")).ToString();	//取引証拠金
			txt有効証拠金.Text = ((double)TradeFXCM.accounts.CellValue(1, "Equity")).ToString();	//有効証拠金
			txt維持証拠金.Text = ((double)TradeFXCM.accounts.CellValue(1, "UsedMargin")).ToString();	//維持証拠金
			txtロスカット余剰金.Text = ((double)TradeFXCM.accounts.CellValue(1, "UsableMargin")).ToString();	//ロスカット余剰金
		}

		private void 取引停止中(string Order状況)
		{
			txtOrder状況.Text = Order状況;
			FormCommon.維持証拠金小計_更新(ref dgv注文設定);

			txt決算待ちポジション数.Text = TradeFXCM.trades.RowCount.ToString();
			return;
		}

		public static int 余剰金調整用_出金可能調整額;
		public static double 余剰金調整用_ロスカット余剰金;
		private void 余剰金調整()
		{
			余剰金調整用_出金可能調整額 = 0;
			if (txt出金済_先月.Text == "")
			{
				// 未出金
				余剰金調整用_出金可能調整額 = int.Parse(txt出金可能額_先月.Text);
			}

			// 当月の利益を足す
			余剰金調整用_出金可能調整額 += int.Parse(txt出金可能額_当月.Text);

			余剰金調整用_ロスカット余剰金 = double.Parse(txtロスカット余剰金.Text);
			if (余剰金調整用_出金可能調整額 < 0)
			{
				// 損切りによって、出金可能額がマイナスになった場合
				txt出金可能額で調整したロスカット余剰金.Text = txtロスカット余剰金.Text;
			}
			else
			{
				txt出金可能額で調整したロスカット余剰金.Text = (余剰金調整用_ロスカット余剰金 - 余剰金調整用_出金可能調整額).ToString();
			}

		}

		private void 保持ポジション更新()
		{
			for (byte 通貨ペアNo = 0; 通貨ペアNo < FX定数.通貨ペア.Length; 通貨ペアNo++)
			{
				if (FormCommon.Chk注文設定_データ生成Chk(通貨ペアNo, ref dgv注文設定) == false)
					continue;

				dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_保持ポジション].Value = TradeFXCM.Get保持ポジション(FX定数.通貨ペア[通貨ペアNo]);
			}
		}

		private static void 前回の判定結果をクリア(byte 通貨ペアNo, ref DataGridView dgv注文設定)
		{
			dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_WMA判定_15m].Value = "";
			//dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_BS判定_前].Value = "";
			//dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_BS判定_今].Value = "";
		}

		private void Order_Ver5(SqlConnection cn)
		{
			hltc.IncrementOrderタイミングCnt(cn);

			FxcmDB記録.DB記録_ClosedTrades(cn);

			アカウント状態を表示();

			余剰金調整();
			Order_Ver5_余剰金の割合 = Fxcm共通.余剰金の割合計算(double.Parse(txt出金可能額で調整したロスカット余剰金.Text));
			txt余剰金の割合.Text = Order_Ver5_余剰金の割合.ToString();

			if (double.IsNaN(Order_Ver5_余剰金の割合) == true)
			{
				取引停止中("取引停止中（IsNaN(余剰金の割合)）");
				return;
			}

			ClosedTrades_余剰金を確保する(cn);

			Order_Ver5_WMA_BS_順張り(cn, ref dgv注文設定);

			FxcmDB記録.DB記録_Trades(cn);
		}

		//private static void 注文時の状態記録(ref string 状態)
		//{
		//	状態 += "\r\n";
		//	状態 += "【注文状態記録】" + "\r\n";
		//	状態 += DateTime.Now.ToString() + "\r\n";
		//	状態 += "Order_Ver5_now:" + Order_Ver5_now.ToString() + "\r\n";
		//	状態 += "DateTime.Now:" + DateTime.Now.ToString() + "\r\n";
		//	状態 += "Order_Ver5_now:" + Order_Ver5_now.ToString() + "\r\n";
		//	状態 += "Order_Ver5_Start1m:" + Order_Ver5_StartMin1.ToString() + "\r\n";
		//	状態 += "Order_Ver5_Start5m:" + Order_Ver5_StartMin5.ToString() + "\r\n";
		//	状態 += "Order_Ver5_Start15m:" + Order_Ver5_StartMin15.ToString() + "\r\n";
		//	状態 += "Order_Ver5_End1m:" + Order_Ver5_EndMin1.ToString() + "\r\n";
		//	状態 += "Order_Ver5_End5m:" + Order_Ver5_EndMin5.ToString() + "\r\n";
		//	状態 += "Order_Ver5_End15m:" + Order_Ver5_EndMin15.ToString() + "\r\n";
		//	状態 += "Order_Ver5_Swap判定:" + Order_Ver5_Swap判定 + "\r\n";
		//	状態 += "Order_Ver5_WMA判定_15m:" + Order_Ver5_WMA判定_15m + "\r\n";
		//	状態 += "Order_Ver5_売買判定:" + Order_Ver5_売買判定 + "\r\n";
		//	状態 += "Order_Ver5_BS判定_15m:" + Order_Ver5_BS判定_15m + "\r\n";
		//	状態 += "Order_Ver5_買売:" + Order_Ver5_買売.ToString() + "\r\n";
		//	状態 += "Order_Ver5_取引単位:" + Order_Ver5_注文単位.ToString() + "\r\n";
		//	状態 += "Order_Ver5_買いRate:" + Order_Ver5_買いRate.ToString() + "\r\n";
		//	状態 += "Order_Ver5_売りRate:" + Order_Ver5_売りRate.ToString() + "\r\n";
		//	状態 += "Order_Ver5_買いSwap:" + Order_Ver5_買いSwap.ToString() + "\r\n";
		//	状態 += "Order_Ver5_売りSwap:" + Order_Ver5_売りSwap.ToString() + "\r\n";
		//	状態 += "Order_Ver5_リミット:" + Order_Ver5_リミット.ToString() + "\r\n";
		//	状態 += "Order_Ver5_BS開始:" + Order_Ver5_BS開始.ToString() + "\r\n";
		//	状態 += "Order_Ver5_余剰金の割合:" + Order_Ver5_余剰金の割合.ToString() + "\r\n";
		//	状態 += "Order_Ver5_通貨ペアNo:" + Order_Ver5_通貨ペアNo.ToString() + "\r\n";
		//	状態 += "Order_Ver5_WMA前_15m:" + Order_Ver5_WMA前_15m.ToString() + "\r\n";
		//	状態 += "Order_Ver5_WMA上昇角度_今:" + Order_Ver5_WMA上昇角度.ToString() + "\r\n";
		//	//状態 += "ChkGC逆判定_Month1_買いWMAs2" + ChkGC逆判定_Month1_買いWMAs2.ToString() + "\r\n";
		//	//状態 += "ChkGC逆判定_Month1_買いWMAs14" + ChkGC逆判定_Month1_買いWMAs14.ToString() + "\r\n";
		//	//状態 += "ChkGC逆判定_Month1_売りWMAs2" + ChkGC逆判定_Month1_売りWMAs2.ToString() + "\r\n";
		//	//状態 += "ChkGC逆判定_Month1_売りWMAs14" + ChkGC逆判定_Month1_売りWMAs14.ToString() + "\r\n";
		//	//状態 += "ChkGC逆判定_Month1_売買判定" + ChkGC逆判定_Month1_売買判定 + "\r\n";
		//	//状態 += "ChkGC逆判定_Week1_買いWMAs2" + ChkGC逆判定_Week1_買いWMAs2.ToString() + "\r\n";
		//	//状態 += "ChkGC逆判定_Week1_買いWMAs14" + ChkGC逆判定_Week1_買いWMAs14.ToString() + "\r\n";
		//	//状態 += "ChkGC逆判定_Week1_売りWMAs2" + ChkGC逆判定_Week1_売りWMAs2.ToString() + "\r\n";
		//	//状態 += "ChkGC逆判定_Week1_売りWMAs14" + ChkGC逆判定_Week1_売りWMAs14.ToString() + "\r\n";
		//	//状態 += "ChkGC逆判定_Week1_売買判定" + ChkGC逆判定_Week1_売買判定 + "\r\n";
		//	//状態 += "ChkGC逆判定_Day1_買いWMAs2" + ChkGC逆判定_Day1_買いWMAs2.ToString() + "\r\n";
		//	//状態 += "ChkGC逆判定_Day1_買いWMAs14" + ChkGC逆判定_Day1_買いWMAs14.ToString() + "\r\n";
		//	//状態 += "ChkGC逆判定_Day1_売りWMAs2" + ChkGC逆判定_Day1_売りWMAs2.ToString() + "\r\n";
		//	//状態 += "ChkGC逆判定_Day1_売りWMAs14" + ChkGC逆判定_Day1_売りWMAs14.ToString() + "\r\n";
		//	//状態 += "ChkGC逆判定_Day1_売買判定" + ChkGC逆判定_Day1_売買判定 + "\r\n";
		//	//状態 += "ChkGC逆判定_Hour1_買いWMAs2" + ChkGC逆判定_Hour1_買いWMAs2.ToString() + "\r\n";
		//	//状態 += "ChkGC逆判定_Hour1_買いWMAs14" + ChkGC逆判定_Hour1_買いWMAs14.ToString() + "\r\n";
		//	//状態 += "ChkGC逆判定_Hour1_売りWMAs2" + ChkGC逆判定_Hour1_売りWMAs2.ToString() + "\r\n";
		//	//状態 += "ChkGC逆判定_Hour1_売りWMAs14" + ChkGC逆判定_Hour1_売りWMAs14.ToString() + "\r\n";
		//	//状態 += "ChkGC逆判定_Hour1_売買判定" + ChkGC逆判定_Hour1_売買判定 + "\r\n";
		//	//状態 += "ChkGC逆判定_Min15_買いWMAs2" + ChkGC逆判定_Min15_買いWMAs2.ToString() + "\r\n";
		//	//状態 += "ChkGC逆判定_Min15_買いWMAs14" + ChkGC逆判定_Min15_買いWMAs14.ToString() + "\r\n";
		//	//状態 += "ChkGC逆判定_Min15_売りWMAs2" + ChkGC逆判定_Min15_売りWMAs2.ToString() + "\r\n";
		//	//状態 += "ChkGC逆判定_Min15_売りWMAs14" + ChkGC逆判定_Min15_売りWMAs14.ToString() + "\r\n";
		//	//状態 += "ChkGC逆判定_Min15_売買判定" + ChkGC逆判定_Min15_売買判定 + "\r\n";
		//	//状態 += "ChkGC逆判定_Min5_買いWMAs2" + ChkGC逆判定_Min5_買いWMAs2.ToString() + "\r\n";
		//	//状態 += "ChkGC逆判定_Min5_買いWMAs14" + ChkGC逆判定_Min5_買いWMAs14.ToString() + "\r\n";
		//	//状態 += "ChkGC逆判定_Min5_売りWMAs2" + ChkGC逆判定_Min5_売りWMAs2.ToString() + "\r\n";
		//	//状態 += "ChkGC逆判定_Min5_売りWMAs14" + ChkGC逆判定_Min5_売りWMAs14.ToString() + "\r\n";
		//	//状態 += "ChkGC逆判定_Min5_売買判定" + ChkGC逆判定_Min5_売買判定 + "\r\n";
		//	//状態 += "ChkGC逆判定_Min1_買いWMAs2" + ChkGC逆判定_Min1_買いWMAs2.ToString() + "\r\n";
		//	//状態 += "ChkGC逆判定_Min1_買いWMAs14" + ChkGC逆判定_Min1_買いWMAs14.ToString() + "\r\n";
		//	//状態 += "ChkGC逆判定_Min1_売りWMAs2" + ChkGC逆判定_Min1_売りWMAs2.ToString() + "\r\n";
		//	//状態 += "ChkGC逆判定_Min1_売りWMAs14" + ChkGC逆判定_Min1_売りWMAs14.ToString() + "\r\n";
		//	//状態 += "ChkGC逆判定_Min1_売買判定" + ChkGC逆判定_Min1_売買判定 + "\r\n";
		//	状態 += "\r\n";
		//}

		private static double Chk総ポジション限界数_保有可能ポジション数;
		public bool Chk総ポジション限界数(double 取引証拠金, int 決算待ちポジション数)
		{
			// 維持証拠金が10万円では、3ポジションが限界。
			// 維持証拠金が100万円なら、30ポジションが限界。
			// 維持証拠金が1000万円なら、300ポジションが限界。
			// 維持証拠金が1億円なら、3000ポジションが限界。

			Chk総ポジション限界数_保有可能ポジション数 = 取引証拠金 / 25000;

			txt保有可能ポジション数.Text = Chk総ポジション限界数_保有可能ポジション数.ToString();

			if (決算待ちポジション数 >= Chk総ポジション限界数_保有可能ポジション数)
			{
				// 決算待ちポジション数が限界に達している。
				return true;
			}

			return false;
		}

		private static DateTime Order_Ver5_now;
		private static DateTime Order_Ver5_StartMin1;
		private static DateTime Order_Ver5_StartMin5;
		private static DateTime Order_Ver5_StartMin15;
		private static DateTime Order_Ver5_StartHour1;
		private static DateTime Order_Ver5_StartDay1;
		private static DateTime Order_Ver5_StartWeek1;
		private static DateTime Order_Ver5_StartMonth1;
		private static DateTime Order_Ver5_EndMin1;
		private static DateTime Order_Ver5_EndMin5;
		private static DateTime Order_Ver5_EndMin15;
		private static DateTime Order_Ver5_EndHour1;
		private static DateTime Order_Ver5_EndDay1;
		private static DateTime Order_Ver5_EndWeek1;
		private static DateTime Order_Ver5_EndMonth1;
		private static string Order_Ver5_Swap判定;
		private static string Order_Ver5_BS_WMA判定_15m;
		private static double Order_Ver5_買いWMAs14;
		private static double Order_Ver5_買いWMAs14上昇角度;
		private static double Order_Ver5_買いWMAs14上昇角度シグマ;
		private static double Order_Ver5_売りWMAs14;
		private static double Order_Ver5_売りWMAs14上昇角度;
		private static double Order_Ver5_売りWMAs14上昇角度シグマ;
		private static string Order_Ver5_売買判定;
		private static string Order_Ver5_BS判定_15m;
		private static bool Order_Ver5_買売;
		private static int Order_Ver5_注文単位;
		private static double Order_Ver5_買いRate;
		private static double Order_Ver5_売りRate;
		private static double Order_Ver5_買いSwap;
		private static double Order_Ver5_売りSwap;
		private static double Order_Ver5_買いリミット;
		private static double Order_Ver5_売りリミット;
		private static bool Order_Ver5_BS開始;
		private static object Order_Ver5_OrderId;
		private static double Order_Ver5_余剰金の割合;
		private static byte Order_Ver5_通貨ペアNo;
		//private static string Order_Ver5_注文時の状態記録_状態;
		private static DateTime Order_Ver5_FXCM_Hour24前;
		private void Order_Ver5_WMA_BS_順張り(SqlConnection cn, ref DataGridView dgv注文設定)
		{
			Order_Ver5_now = DateTime.Now;
			cmn.GetThisMonth1(cn, Order_Ver5_now, out Order_Ver5_StartMonth1, out Order_Ver5_EndMonth1);
			cmn.GetThisWeek1(cn, Order_Ver5_now, out Order_Ver5_StartWeek1, out Order_Ver5_EndWeek1);
			cmn.GetThisDay1(cn, Order_Ver5_now, out Order_Ver5_StartDay1, out Order_Ver5_EndDay1);
			cmn.GetThisHour1(cn, Order_Ver5_now, out Order_Ver5_StartHour1, out Order_Ver5_EndHour1);
			cmn.GetThisMin15(cn, Order_Ver5_now, out Order_Ver5_StartMin15, out Order_Ver5_EndMin15);
			cmn.GetThisMin5(cn, Order_Ver5_now, out Order_Ver5_StartMin5, out Order_Ver5_EndMin5);
			cmn.GetThisMin1(cn, Order_Ver5_now, out Order_Ver5_StartMin1, out Order_Ver5_EndMin1);

			Order_Ver5_FXCM_Hour24前 = Order_Ver5_now.AddHours(-24 + (FX定数.FXOrder2Go時間補正 * -1));
			Order_Ver5_注文単位 = int.Parse(txt注文単位.Text);

			for (Order_Ver5_通貨ペアNo = 0; Order_Ver5_通貨ペアNo < FX定数.通貨ペア.Length; Order_Ver5_通貨ペアNo++)
			{
				try
				{
					if (FormCommon.Chk注文設定_データ生成Chk(Order_Ver5_通貨ペアNo, ref dgv注文設定) == false)
						continue;

					if (通貨ペア別Rate更新(cn, Order_Ver5_now, Order_Ver5_通貨ペアNo,
						ref Order_Ver5_買いRate, ref Order_Ver5_売りRate, ref Order_Ver5_買いSwap, ref Order_Ver5_売りSwap, 
						ref dgv注文設定) == false)
						continue;

					前回の判定結果をクリア(Order_Ver5_通貨ペアNo, ref dgv注文設定);

					rate.InsertRateHistory_Min1(cn, Order_Ver5_通貨ペアNo, Order_Ver5_StartMin1, Order_Ver5_EndMin1);
					rate.InsertRateHistory_Min5(cn, Order_Ver5_通貨ペアNo, Order_Ver5_StartMin5, Order_Ver5_EndMin5);
					rate.InsertRateHistory_Min15(cn, Order_Ver5_通貨ペアNo, Order_Ver5_StartMin15, Order_Ver5_EndMin15);
					rate.InsertRateHistory_Hour1(cn, Order_Ver5_通貨ペアNo, Order_Ver5_StartHour1, Order_Ver5_EndHour1);
					rate.UpdateWMA_Min1(cn, Order_Ver5_通貨ペアNo, Order_Ver5_StartMin1, Order_Ver5_EndMin1);
					rate.UpdateWMA_Min5(cn, Order_Ver5_通貨ペアNo, Order_Ver5_StartMin5, Order_Ver5_EndMin5);
					rate.UpdateWMA_Min15(cn, Order_Ver5_通貨ペアNo, Order_Ver5_StartMin15, Order_Ver5_EndMin15);
					rate.UpdateWMA_Hour1(cn, Order_Ver5_通貨ペアNo, Order_Ver5_StartHour1, Order_Ver5_EndHour1);

					if ((Order_Ver5_now.Hour == 5 && Order_Ver5_now.Minute > 58) || (Order_Ver5_now.Hour == 6 && Order_Ver5_now.Minute < 1))
					{
						rate.InsertRateHistory_Day1(cn, Order_Ver5_通貨ペアNo, Order_Ver5_StartDay1, Order_Ver5_EndDay1);
						rate.InsertRateHistory_Week1(cn, Order_Ver5_通貨ペアNo, Order_Ver5_StartWeek1, Order_Ver5_EndWeek1);
						rate.InsertRateHistory_Month1(cn, Order_Ver5_通貨ペアNo, Order_Ver5_StartMonth1, Order_Ver5_EndMonth1);
						rate.UpdateWMA_Day1(cn, Order_Ver5_通貨ペアNo, Order_Ver5_StartDay1, Order_Ver5_EndDay1);
						rate.UpdateWMA_Week1(cn, Order_Ver5_通貨ペアNo, Order_Ver5_StartWeek1, Order_Ver5_EndWeek1);
						rate.UpdateWMA_Month1(cn, Order_Ver5_通貨ペアNo, Order_Ver5_StartMonth1, Order_Ver5_EndMonth1);
					}

					if (chk15mデータ生成以降の処理をスキップ.Checked == true)
						continue;

					if (FormCommon.Chk注文設定_Chk注文(Order_Ver5_通貨ペアNo, ref dgv注文設定) == false)
						continue;

					if (FormCommon.注文設定_Swap判定(cn, Order_Ver5_通貨ペアNo, ref Order_Ver5_Swap判定, ref dgv注文設定) == false)
						continue;

					if (FormCommon.B_逆ポジションの有る通貨ペアを算出(cn, Order_Ver5_通貨ペアNo,
						clrSwap判定が逆のポジションがある.BackColor,
						clrSwap判定が逆のポジションがありRateも保持ポジションの逆に動いてる.BackColor,
						Order_Ver5_StartMonth1, Order_Ver5_StartWeek1, Order_Ver5_StartDay1,
						ref dgv注文設定) == false)
						continue;

					dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_BS判定_前].Value
						= dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_BS判定_今].Value;

					oder.Chkボーナスステージ_15m(cn, Order_Ver5_通貨ペアNo, Order_Ver5_StartMin15,
						out Order_Ver5_買いWMAs14, ref Order_Ver5_買いWMAs14上昇角度シグマ, out Order_Ver5_売りWMAs14, ref Order_Ver5_売りWMAs14上昇角度シグマ,
						out Order_Ver5_BS_WMA判定_15m, out Order_Ver5_BS判定_15m);

					dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_WMA判定_15m].Value = Order_Ver5_BS_WMA判定_15m;
					dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_BS判定_今].Value = Order_Ver5_BS判定_15m;
					dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_取引状況].Value = "Order中(通常)";

					Order_Ver5_BS開始 = false;
					if ((string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_BS判定_前].Value == "" &&
						(string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_BS判定_今].Value == "B")
					{
						if (string.IsNullOrEmpty((string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_保持ポジション].Value) ||
							(string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_保持ポジション].Value == Order_Ver5_BS_WMA判定_15m)
						{
							// Bonus Stage 開始処理 //

							//Order_Ver5_リミット = Order_Ver5_買いRate * 0.5;	// 売買モードは関係なく「買いRate」を使う
							Order_Ver5_買いリミット = Order_Ver5_買いRate + (Order_Ver5_買いRate * システム設定.BS発生_リミット拡張幅);	// 売買モードは関係なく「買いRate」を使う
							Order_Ver5_売りリミット = Order_Ver5_売りRate - (Order_Ver5_売りRate * システム設定.BS発生_リミット拡張幅);	// 売買モードは関係なく「買いRate」を使う

							if ((string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_保持ポジション].Value != "")
							{
								Fxcm共通.特定通貨ペアのリミット幅を拡張する(cn, FX定数.通貨ペア[Order_Ver5_通貨ペアNo],
									注文共通.GetBool売買((string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_保持ポジション].Value),
									Order_Ver5_買いRate, Order_Ver5_売りRate, Order_Ver5_買いリミット, Order_Ver5_売りリミット);	// 現在Rateの50%分、リミットを拡張する。
							}

							dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_取引状況].Value = "Order中 (BS開始)";

							hstr.InsertBS(cn,
								Order_Ver5_now,
								Order_Ver5_通貨ペアNo, 
								Order_Ver5_買いRate,
								Order_Ver5_買いWMAs14,
								Order_Ver5_買いWMAs14上昇角度,
								Order_Ver5_買いWMAs14上昇角度シグマ,
								Order_Ver5_買いリミット,
								Order_Ver5_売りRate,
								Order_Ver5_売りWMAs14,
								Order_Ver5_売りWMAs14上昇角度,
								Order_Ver5_売りWMAs14上昇角度シグマ,
								Order_Ver5_売りリミット,
								注文共通.GetBool売買(Order_Ver5_BS_WMA判定_15m),
								注文共通.GetBool売買((string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_保持ポジション].Value),
								(string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_BS判定_前].Value,
								(string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_BS判定_今].Value);

							Order_Ver5_BS開始 = true;
							//BS中の通貨ペア有り = true;
						}
					}
					else if ((string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_BS判定_前].Value == "B" &&
						(string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_BS判定_今].Value == "")
					{
						// Bonus Stage 終了処理 //

						if ((string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_保持ポジション].Value != "")
						{
							Fxcm共通.利益が出ているOrderは全てクローズする(cn, FX定数.通貨ペア[Order_Ver5_通貨ペアNo], "Bonus Stage 終了 利益あり");

							double 買いリミット, 売りリミット;
							cmn.Getリミット_BS終了時(cn, Order_Ver5_通貨ペアNo, out 買いリミット, out 売りリミット);

							Fxcm共通.保持ポジションのリミット初期化_BS終了時(cn, FX定数.通貨ペア[Order_Ver5_通貨ペアNo], 注文共通.GetBool売買(Order_Ver5_Swap判定),
								買いリミット, 売りリミット);
						}

						dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_取引状況].Value = "Order対象外（BS終了）";

						hstr.InsertBS(cn,
							Order_Ver5_now,
							Order_Ver5_通貨ペアNo,
							Order_Ver5_買いRate,
							Order_Ver5_買いWMAs14,
							Order_Ver5_買いWMAs14上昇角度,
							Order_Ver5_買いWMAs14上昇角度シグマ,
							Order_Ver5_買いリミット,
							Order_Ver5_売りRate,
							Order_Ver5_売りWMAs14,
							Order_Ver5_売りWMAs14上昇角度,
							Order_Ver5_売りWMAs14上昇角度シグマ,
							Order_Ver5_売りリミット,
							注文共通.GetBool売買(Order_Ver5_BS_WMA判定_15m),
							注文共通.GetBool売買((string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_保持ポジション].Value),
							(string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_BS判定_前].Value,
							(string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_BS判定_今].Value);

						continue;
					}
					else if ((string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_BS判定_前].Value == "B" &&
						(string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_BS判定_今].Value == "B")
					{
						// Bonus Stage 継続中は何もしない //

						dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_取引状況].Value = "Order対象外（BS継続中）";
						continue;
					}

					if (FormCommon.A_取引状況エラー判定(Order_Ver5_通貨ペアNo, ref dgv注文設定) == false)
						continue;

					if ((string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_BS判定_前].Value == "B" ||
						(string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_BS判定_今].Value == "B")
					{
						if (!string.IsNullOrEmpty((string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_保持ポジション].Value))
						{
							// Todo:Swapに逆らわない方式なら、保持ポジションよりSwapに対して逆かチェックした方が良さそう。
							if ((string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_保持ポジション].Value != Order_Ver5_BS_WMA判定_15m)
							{
								dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_取引状況].Value = "Order対象外（逆BS中）";
								continue;
							}
						}
					}

					// BB判定orWMA判定で注文可かどうか
					if (Order_Ver5_BS開始 == true)
					{
						if (注文共通.ChkGC逆判定(cn, Order_Ver5_通貨ペアNo, Order_Ver5_now, Order_Ver5_BS_WMA判定_15m))
						{
							Order_Ver5_売買判定 = Order_Ver5_BS_WMA判定_15m;
						}
					}

					if (!注文共通.WMA判定(cn, Order_Ver5_通貨ペアNo, Order_Ver5_買いSwap, Order_Ver5_売りSwap,
						Order_Ver5_StartMonth1, Order_Ver5_StartWeek1, Order_Ver5_StartDay1, Order_Ver5_StartHour1, Order_Ver5_StartMin15, Order_Ver5_StartMin5, Order_Ver5_StartMin1,
						ref Order_Ver5_売買判定))
					{
						continue;
					}

					if (Order_Ver5_Swap判定 != Order_Ver5_売買判定)
					{
						dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_取引状況].Value = "Order対象外（BS Swap判定とWMA判定15mが不一致）";
						continue;
					}

					oder.Insert注文対象通貨ペアDaily(cn, Order_Ver5_StartDay1, Order_Ver5_通貨ペアNo);

					// 注文可でも保持ポジションとの関係に問題がないかどうか
					if ((string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_保持ポジション].Value != "")
					{
						if ((string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_保持ポジション].Value != Order_Ver5_売買判定)
						{
							dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_取引状況].Value = "Order対象外（BS 保持ポジとWMA判定15mが不一致）";
							continue;
						}
					}
					if (Chk総ポジション限界数(double.Parse(txt取引証拠金.Text), TradeFXCM.trades.RowCount))
					{
						dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_取引状況].Value = "Order対象外（総ポジションが限界数に達した）";
						continue;
					}						
					if (Order_Ver5_余剰金の割合 < システム設定.余剰金割合_Order限界点)
					{
						取引停止中("取引停止中（余剰金割合_Order限界点）");
						dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_取引状況].Value = "取引停止中（余剰金割合_Order限界点）";
						continue;
					}						
					if (oder.Chk直近15分以内にOrder有り(cn, Order_Ver5_通貨ペアNo, Order_Ver5_now) == true)
					{
						dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_取引状況].Value = "直近15分以内にOrder有り";
						continue;
					}
					if (TradeFXCM.Chk24時間以内にポジション有り(Order_Ver5_通貨ペアNo, Order_Ver5_FXCM_Hour24前) == true)
					{
						dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_取引状況].Value = "直近15分以内にOrder有り";
						continue;
					}

					FormCommon.Order間隔最小値_リミット_更新(cn, Order_Ver5_通貨ペアNo, Order_Ver5_売買判定, Order_Ver5_買いRate, Order_Ver5_売りRate, 
						ref Order_Ver5_買いリミット, ref Order_Ver5_売りリミット, ref dgv注文設定);

					Order_Ver5_買売 = 注文共通.GetBool売買(Order_Ver5_売買判定);

					if (TradeFXCM.Chk残ポジション有無(cn, Order_Ver5_通貨ペアNo, Order_Ver5_買いRate))
					{
						continue; // 近くのRateでポジションが既にある。
					}

					//注文時の状態記録(ref Order_Ver5_注文時の状態記録_状態);

					dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_取引状況].Value = "Order実行";

					if (!chk注文状態記録まで注文はスキップ.Checked)
					{
						TradeFXCM.ポジション更新_成行(Order_Ver5_買売, FX定数.通貨ペア[Order_Ver5_通貨ペアNo], Order_Ver5_買いRate, Order_Ver5_売りRate, Order_Ver5_注文単位,
							Order_Ver5_買いリミット, Order_Ver5_売りリミット, (string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_QuoteID].Value,
							システム設定.AtMarket, out Order_Ver5_OrderId);

						//oder.UpdateOrderHistory_OrderId(cn, Order_Ver5_通貨ペアNo, Order_Ver5_now, (string)Order_Ver5_OrderId);
					};

					oder.InsertOrderHistory2(cn,
						Order_Ver5_now,
						Order_Ver5_通貨ペアNo,
						Order_Ver5_買いSwap,
						Order_Ver5_売りSwap,
						注文共通.GetBool売買(Order_Ver5_Swap判定),
						Order_Ver5_買いRate, 
						Order_Ver5_売りRate,
						注文共通.GetBool売買(Order_Ver5_売買判定),
						注文共通.GetBool売買((string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_保持ポジション].Value),
						Order_Ver5_買いWMAs14,
						Order_Ver5_買いWMAs14上昇角度,
						Order_Ver5_買いWMAs14上昇角度シグマ,
						Order_Ver5_売りWMAs14,
						Order_Ver5_売りWMAs14上昇角度,
						Order_Ver5_売りWMAs14上昇角度シグマ,
						注文共通.GetBool売買(Order_Ver5_BS_WMA判定_15m),
						注文共通.GetBool売買(Order_Ver5_BS判定_15m),
						Order_Ver5_BS開始,
						(string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_BS判定_前].Value,
						(string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_BS判定_今].Value,
						Order_Ver5_買いリミット,
						Order_Ver5_売りリミット,
						Order_Ver5_注文単位,
						Order_Ver5_StartMonth1,
						Order_Ver5_EndMonth1,
						注文共通.WMA判定_Month1_買いWMAs2,
						注文共通.WMA判定_Month1_買いWMAs2角度,
						注文共通.WMA判定_Month1_買いWMAs14,
						注文共通.WMA判定_Month1_売りWMAs2,
						注文共通.WMA判定_Month1_売りWMAs2角度,
						注文共通.WMA判定_Month1_売りWMAs14,
						Order_Ver5_StartWeek1,
						Order_Ver5_EndWeek1,
						注文共通.WMA判定_Week1_買いWMAs2,
						注文共通.WMA判定_Week1_買いWMAs2角度,
						注文共通.WMA判定_Week1_買いWMAs14,
						注文共通.WMA判定_Week1_売りWMAs2,
						注文共通.WMA判定_Week1_売りWMAs2角度,
						注文共通.WMA判定_Week1_売りWMAs14,
						Order_Ver5_StartDay1,
						Order_Ver5_EndDay1,
						注文共通.WMA判定_Day1_買いWMAs2,
						注文共通.WMA判定_Day1_買いWMAs2角度,
						注文共通.WMA判定_Day1_買いWMAs14,
						注文共通.WMA判定_Day1_売りWMAs2,
						注文共通.WMA判定_Day1_売りWMAs2角度,
						注文共通.WMA判定_Day1_売りWMAs14,
						Order_Ver5_StartHour1,
						Order_Ver5_EndHour1,
						注文共通.WMA判定_Hour1_買いWMAs2,
						注文共通.WMA判定_Hour1_買いWMAs2角度,
						注文共通.WMA判定_Hour1_買いWMAs14,
						注文共通.WMA判定_Hour1_売りWMAs2,
						注文共通.WMA判定_Hour1_売りWMAs2角度,
						注文共通.WMA判定_Hour1_売りWMAs14,
						Order_Ver5_StartMin15,
						Order_Ver5_EndMin15,
						注文共通.WMA判定_Min15_買いWMAs2,
						注文共通.WMA判定_Min15_買いWMAs2角度,
						注文共通.WMA判定_Min15_買いWMAs14,
						注文共通.WMA判定_Min15_売りWMAs2,
						注文共通.WMA判定_Min15_売りWMAs2角度,
						注文共通.WMA判定_Min15_売りWMAs14,
						Order_Ver5_StartMin5,
						Order_Ver5_EndMin5,
						注文共通.WMA判定_Min5_買いWMAs2,
						注文共通.WMA判定_Min5_買いWMAs2角度,
						注文共通.WMA判定_Min5_買いWMAs14,
						注文共通.WMA判定_Min5_売りWMAs2,
						注文共通.WMA判定_Min5_売りWMAs2角度,
						注文共通.WMA判定_Min5_売りWMAs14,
						Order_Ver5_StartMin1,
						Order_Ver5_EndMin1,
						注文共通.WMA判定_Min1_買いWMAs2,
						注文共通.WMA判定_Min1_買いWMAs2角度,
						注文共通.WMA判定_Min1_買いWMAs14,
						注文共通.WMA判定_Min1_売りWMAs2,
						注文共通.WMA判定_Min1_売りWMAs2角度,
						注文共通.WMA判定_Min1_売りWMAs14,
						(string)Order_Ver5_OrderId);
				}
				catch (Exception ex)
				{
					List<Cエラー関連変数> Cエラー関連変数List = new List<Cエラー関連変数>();
					Cエラー関連変数List.Add(new Cエラー関連変数() { 変数名 = "Order_Ver5_通貨ペアNo", 値 = Order_Ver5_通貨ペアNo.ToString()});
					Exception共通(false, ex, Cエラー関連変数List);
				}

				//File.AppendAllText(ログ.ログフォルダPath(), Order_Ver5_注文時の状態記録_状態, システム設定.Enc);
				//Order_Ver5_注文時の状態記録_状態 = "";
			}

			txt注文単位.Text = 注文共通.Get注文単位(double.Parse(txtロスカット余剰金.Text), double.Parse(txt取引証拠金.Text)).ToString();

			hltc.Insert処理時間(cn, (byte)FX定数.処理区分.通貨ペア全体の注文処理, Order_Ver5_now, DateTime.Now);
		}

		private void 自動取引開始終了()
		{
			//if (btn自動取引開始.Text == "自動取引開始")
			//if (txt取引モード表示.Text == "自動取引中")
			if (txt取引モード表示.Text == "")
			{
				自動取引を再開();
			}
			else
			{
				自動取引を解除();
			}
		}

		private void ClosedTrades_余剰金を確保する(SqlConnection cn)
		{
			if (chk余剰金確保の自動ポジションCloseはしない.Checked == true)
				return;

			double 余剰金の割合 = 0;

			DateTime Time;
			double 差益 = 0;
			string sTradeID = "";
			int iAmount = 0;
			double dRate = 0;
			string sQuoteID = "";
			object CloseOrderID;

			for (uint iCnt = 1; iCnt <= TradeFXCM.trades.RowCount; iCnt++)
			{
				余剰金の割合 = Fxcm共通.余剰金の割合計算(double.Parse(txtロスカット余剰金.Text));

				if (余剰金の割合 > システム設定.余剰金割合の限界点)
					return;

				if (chk余剰金確保の自動ポジションCloseはMSG確認する.Checked == true)
				{ 
					if (MessageBox.Show("[ClosedTrades_余剰金を確保する]を本当に実行しますか？ \r\n実行すると、極端な損失が発生します。", "確認（超重要）", 
						MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
						return;
				}

				temp.DeleteAll_SortCloseTradeTmp(cn);

				for (uint iCnt2 = 1; iCnt2 <= TradeFXCM.trades.RowCount; iCnt2++)
				{
					Time = (DateTime)TradeFXCM.trades.CellValue(iCnt2, "Time");
					差益 = (double)TradeFXCM.trades.CellValue(iCnt2, "GrossPL");
					iAmount = (int)TradeFXCM.trades.CellValue(iCnt2, "Lot");
					dRate = (double)TradeFXCM.trades.CellValue(iCnt2, "Close");
					sTradeID = (string)TradeFXCM.trades.CellValue(iCnt2, "TradeID");
					sQuoteID = (string)TradeFXCM.trades.CellValue(iCnt2, "QuoteID");

					temp.InsertSortCloseTradeTmp(cn, Time, sTradeID, 差益, iAmount, dRate, sQuoteID);
				}

				temp.FillBy差益_SortCloseTradeTmp(cn, sTradeID, iAmount, dRate, sQuoteID);

				// 差益がマイナスなTrade、Top1のみクローズ
				TradeFXCM.ポジションをクローズする(sTradeID, iAmount, dRate, sQuoteID, システム設定.AtMarket, out CloseOrderID);

				System.Threading.Thread.Sleep(1000);
			}

		}

		private void Exception共通(bool Timerを停止, Exception ex, List<Cエラー関連変数> エラー関連変数List)
		{
			if (Timerを停止 == true)
			{
				全Timerを停止();
			}

			ToolStripStsLbl.Text = "Exceptionエラーが発生しました。 " + ex.Message;
			ToolStripStsLbl.BackColor = Color.Red;

			File.AppendAllText(ログ.ログフォルダPath(), "\r\n\r\n", システム設定.Enc);
			File.AppendAllText(ログ.ログフォルダPath(), DateTime.Now.ToString() + "\r\n", システム設定.Enc);
			File.AppendAllText(ログ.ログフォルダPath(), "Exceptionエラーが発生しました。 ", システム設定.Enc);
			File.AppendAllText(ログ.ログフォルダPath(), ex.Data + "\r\n", システム設定.Enc);
			File.AppendAllText(ログ.ログフォルダPath(), ex.HelpLink + "\r\n", システム設定.Enc);
			File.AppendAllText(ログ.ログフォルダPath(), ex.InnerException + "\r\n", システム設定.Enc);
			File.AppendAllText(ログ.ログフォルダPath(), ex.Message + "\r\n", システム設定.Enc);
			File.AppendAllText(ログ.ログフォルダPath(), ex.Source + "\r\n", システム設定.Enc);
			File.AppendAllText(ログ.ログフォルダPath(), ex.StackTrace + "\r\n", システム設定.Enc);
			File.AppendAllText(ログ.ログフォルダPath(), ex.TargetSite + "\r\n", システム設定.Enc);

			foreach (Cエラー関連変数 エラー関連変数 in エラー関連変数List)
			{
				File.AppendAllText(ログ.ログフォルダPath(), エラー関連変数.変数名 + " : " + エラー関連変数.値 + "\r\n", システム設定.Enc);
			}
		}

		private void ログイン_Order開始(SqlConnection cn)
		{
			ログイン();

			QuoteID表示();
			アカウント状態を表示();
			FxcmDB記録.DB記録_Accounts(cn);
			先月当月利益更新(cn);

			保持ポジション更新();

			Order_Ver5(cn);
		}

		private void システム設定_表示()
		{
			// 注文設定 //
			txtポジション増加数_直近n時間.Text = システム設定.ポジション増加数_直近n時間.ToString();
			txt差損益気増加数_直近n日間.Text = システム設定.差損益気増加数_直近n日間.ToString();
			txtBS発生_リミット拡張幅.Text = システム設定.BS発生_リミット拡張幅.ToString();

			// Order //
			txt余剰金割合_Order限界点.Text = システム設定.余剰金割合_Order限界点.ToString();
			txtOrder対象を減少させないOrder数.Text = システム設定.Order対象を減少させないOrder数.ToString();
			txtシステム設定_Rate幅を求めるn日間_Order間隔最小値.Text = システム設定.Rate幅を求めるn日間_Order間隔最小値.ToString();
			txtシステム設定_Rate幅を求めるn日間_リミット.Text = システム設定.Rate幅を求めるn日間_リミット.ToString();
			txt前日の高値底値とリミットの割合.Text = システム設定.前日の高値底値とリミットの割合.ToString();
			txtシステム_Order間隔増加割合.Text = システム設定.Order間隔増加割合.ToString();
			txtシステム_自動更新Rate幅はOrder間隔のn倍.Text = システム設定.自動更新Rate幅はOrder間隔のn倍.ToString();
			txtシステム設定_AtMarket.Text = システム設定.AtMarket.ToString();

			// Close Trade //
			txt余剰金割合の限界点.Text = システム設定.余剰金割合の限界点.ToString();
			txtシステム設定_CloseTrade_nヵ月前からあるポジション.Text = システム設定.CloseTrade_nヵ月前からあるポジション.ToString();
			txtシステム設定_CloseTrade_n以上であればCloseする.Text = システム設定.CloseTrade_n以上であればCloseする.ToString();

			// 出金 Monthly //
			txt出金可能にする開始日時.Text = システム設定.出金可能にする開始日時.ToString();
			txt出金可能にする取引証拠金.Text = システム設定.出金可能にする取引証拠金.ToString();
			txt出金可能にする利益Percent.Text = システム設定.出金可能にする利益Percent.ToString();

			// その他 //
			txtシステム設定_日付はn時くぎり.Text = システム設定.日付はn時くぎり.ToString();

			txt口座種別.Text = システム設定.Fxcm口座種別;
			txtConnection.Text = システム設定.FxcmConnection;
			txtUsername.Text = システム設定.FxcmUsername;
			txtPassword.Text = システム設定.FxcmPassword;

			txt余剰金割合_Order対象通貨ペアを減らす開始点.Text = システム設定.余剰金割合_Order対象通貨ペアを減らす開始点.ToString();
			txt前日の高値底値とOrder間隔最小値の割合.Text = システム設定.前日の高値底値とOrder間隔最小値の割合.ToString();
			chkn日以上前のポジション決済をスキップ.Checked = システム設定.n日以上前のポジション決済をスキップ;

			txtログイン表示.Text = "";
			txt取引モード表示.Text = "";
			ToolStripStsLbl.Text = "";

		}

		private void バグチェック()
		{
			if (dgv注文設定.ColumnCount != Form定数.DGVClmNo注文設定_DGV列数)
			{
				throw new System.Exception("dgv注文設定 の列数と、DGVClmNo注文設定_DGV列数 が不一致");
			}
		}

		#endregion

		#region イベントハンドラ

		private void Form1_Load(object sender, EventArgs e)
		{
			toolStripStatusLabel1.Text = システム設定.CommandLine;

			Start();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				自動取引開始終了();

				TradeFXCM.Logout();
			}
			catch (Exception ex)
			{
				Exception共通(true, ex, new List<Cエラー関連変数>());
			}
		}

		#endregion

		#region イベントハンドラ timer

		private void timer_Order_60sec_Tick(object sender, EventArgs e)
		{
			try
			{
				if (txtAuto.Text != "Auto")
					return;

				if (システム設定.Trade時間内 != "時間内")
					return;

				using (SqlConnection cn = new SqlConnection())
				{
					cn.ConnectionString = Properties.Settings.Default.FXConnectionString;
					cn.Open();

					Order_Ver5(cn);
				}
			}
			catch (Exception ex)
			{
				FXサーバ障害時のException(ex);
			}
		}

		private void FXサーバ障害時のException(Exception ex)
		{
			ToolStripStsLbl.Text = "Exceptionエラーが発生しました。 " + ex.Message;
			Exception共通(false, ex, new List<Cエラー関連変数>());

			if (ex.Message.IndexOf("ORA-", StringComparison.Ordinal) > -1)
			{
				ToolStripStsLbl.BackColor = Color.Orange;
			}
			else
			{
				if ((ex.Message.IndexOf(FX定数.trading_server_was_lost, StringComparison.Ordinal) > -1 ||
						ex.Message.IndexOf(FX定数.Market_is_closed, StringComparison.Ordinal) > -1) && 
					(DateTime.Now.DayOfWeek == DayOfWeek.Saturday && DateTime.Now.Hour > 5))
				{
					// FXCMがクローズしてる。
					File.AppendAllText(ログ.ログフォルダPath(), "Application.Exit FXCM Close. \r\n", システム設定.Enc);
					Application.Exit();
				}

				if (ex.Message.IndexOf(FX定数.trading_server_was_lost, StringComparison.Ordinal) > -1)
				{
					// 平日にFXCMサーバが再起動したので復旧する。
					System.Threading.Thread.Sleep(60000); // 1分待ってTrading serverが復旧している事を期待。

					using (SqlConnection cn = new SqlConnection())
					{
						cn.ConnectionString = Properties.Settings.Default.FXConnectionString;
						cn.Open();

						//  ここで"trading server was lost"が起きても、タイマーで再実行されるので再接続の為のループなしない。
						ログイン_Order開始(cn);
					}
				}
			}
		}

		private static DateTime 先月当月利益更新_年月;
		private void 先月当月利益更新(SqlConnection cn)
		{
			// 当月の利益 //

			先月当月利益更新_年月 = DateTime.Now;
			pfmc.Insert利益_Monthly(cn, 先月当月利益更新_年月, システム設定.出金可能にする開始日時, システム設定.出金可能にする利益Percent);

			int 利益確定開始以降の利益;
			int 出金可能額;

			pfmc.Get利益Monthly(cn, DateTime.Parse(先月当月利益更新_年月.Year.ToString() + "/" + 先月当月利益更新_年月.Month.ToString() + "/1 00:00:00"),
				out 利益確定開始以降の利益, out 出金可能額);

			txt当月利益.Text = 利益確定開始以降の利益.ToString();

			if (出金可能額 < 1)
			{
				txt出金可能額_当月.Text = "0";
			}
			else
			{
				txt出金可能額_当月.Text = 出金可能額.ToString();
			}


			// 先月の利益 //

			先月当月利益更新_年月 = 先月当月利益更新_年月.AddMonths(-1);

			pfmc.Insert利益_Monthly(cn, 先月当月利益更新_年月, システム設定.出金可能にする開始日時, システム設定.出金可能にする利益Percent);

			pfmc.Get利益Monthly(cn, DateTime.Parse(先月当月利益更新_年月.Year.ToString() + "/" + 先月当月利益更新_年月.Month.ToString() + "/1 00:00:00"),
				out 利益確定開始以降の利益, out 出金可能額);

			txt先月利益.Text = 利益確定開始以降の利益.ToString();

			if (出金可能額 < 1)
			{
				txt出金可能額_先月.Text = "0";
			}
			else
			{
				txt出金可能額_先月.Text = 出金可能額.ToString();
			}

			// 先月の利益は出金済み？ //
			if (pfmc.Chk出金済み(cn, DateTime.Now, (double)TradeFXCM.accounts.CellValue(1, "Balance"), int.Parse(txt先月利益.Text)) == 1)
			{
				// 出金済み
				txt出金済_先月.Text = "済";
			}
			else
			{
				// 未出金
				txt出金済_先月.Text = "";
			}

		}

		private static double timer_リミット更新_1h_Tick_買いリミット, timer_リミット更新_1h_Tick_売りリミット;
		private void timer_リミット更新_1h_Tick(object sender, EventArgs e)
		{
			// 最新通常のリミット値へ更新する //

			try
			{
				if (txtAuto.Text != "Auto")
					return;

				if (システム設定.Trade時間内 != "時間内")
				{
					File.AppendAllText(ログ.ログフォルダPath(), "Application.Exit 1", システム設定.Enc);

					if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday && DateTime.Now.Hour > 9)
					{
						File.AppendAllText(ログ.ログフォルダPath(), "Application.Exit 2", システム設定.Enc);
						Application.Exit();
					}
				}

				QuoteID表示();

				using (SqlConnection cn = new SqlConnection())
				{
					cn.ConnectionString = Properties.Settings.Default.FXConnectionString;
					cn.Open();

					FxcmDB記録.DB記録_Accounts(cn);

					先月当月利益更新(cn);

					Fxcm共通.ClosedTrades_n日前のポジションを決済する(cn, chkn日以上前のポジション決済をスキップ.Checked, システム設定.n日以上前のポジションは決済);

					保持ポジション更新();

					pfmc.InsertポジションHourly(cn, double.Parse(txt保有可能ポジション数.Text), double.Parse(txt決算待ちポジション数.Text),
						double.Parse(txt当日注文数.Text), double.Parse(txt当日約定数.Text), double.Parse(txt当日約定金額.Text),
						double.Parse(txt取引証拠金.Text), double.Parse(txt有効証拠金.Text), double.Parse(txt維持証拠金.Text),
						double.Parse(txtロスカット余剰金.Text), double.Parse(txt余剰金の割合.Text));

					if (DateTime.Now.Hour == 5)
					{
						// 毎朝5時 //

						for (byte 通貨ペアNo = 0; 通貨ペアNo < FX定数.通貨ペア.Length; 通貨ペアNo++)
						{
							try
							{
								if (FormCommon.Chk注文設定_データ生成Chk(通貨ペアNo, ref dgv注文設定) == false)
									continue;

								if ((string)dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_保持ポジション].Value == "")
									continue;

								Fxcm共通.利益が出ているOrderは全てクローズする(cn, FX定数.通貨ペア[通貨ペアNo], "毎朝5時の利益ポジションクローズ");

								FormCommon.Order間隔最小値_リミット_更新(cn, 通貨ペアNo, (string)dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_Swap判定].Value,
									(double)dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_買いRate].Value,
									(double)dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_売りRate].Value,
									ref timer_リミット更新_1h_Tick_買いリミット, ref timer_リミット更新_1h_Tick_売りリミット, ref dgv注文設定);

								Fxcm共通.保持ポジションのリミット初期化(cn, FX定数.通貨ペア[通貨ペアNo], 
									timer_リミット更新_1h_Tick_買いリミット, timer_リミット更新_1h_Tick_売りリミット);
							}
							catch (Exception ex)
							{
								List<Cエラー関連変数> Cエラー関連変数List = new List<Cエラー関連変数>();
								Cエラー関連変数List.Add(new Cエラー関連変数() { 変数名 = "通貨ペアNo", 値 = 通貨ペアNo.ToString() });
								Exception共通(false, ex, Cエラー関連変数List);
							}
						}
					}
					else if (DateTime.Now.Hour == 8) // 毎朝8時 //
					{
						//if (システム設定.CommandLine.IndexOf("DemoA_FX", StringComparison.Ordinal) > -1)
						//{
						//	chk15mデータ生成以降の処理をスキップ.Checked = false;
						//	chk注文状態記録まで注文はスキップ.Checked = false;
						//}
						//else if (システム設定.CommandLine.IndexOf("RealA_FX", StringComparison.Ordinal) > -1)
						//{
						//	chk15mデータ生成以降の処理をスキップ.Checked = false;
						//	chk注文状態記録まで注文はスキップ.Checked = false;
						//}
						//else
						//{
						//	chk15mデータ生成以降の処理をスキップ.Checked = true;
						//	chk注文状態記録まで注文はスキップ.Checked = true;
						//}

						if (chk毎朝の自動注文開始を行う.Checked)
						{
							chk15mデータ生成以降の処理をスキップ.Checked = false;
							chk注文状態記録まで注文はスキップ.Checked = false;
						}
					}
				}
			}
			catch (Exception ex)
			{
				FXサーバ障害時のException(ex);
			}
		}

		private void timer_DB記録_10min_Tick(object sender, EventArgs e)
		{
			try
			{
				if (txtAuto.Text != "Auto")
					return;

				if (システム設定.Trade時間内 != "時間内")
					return;

				FormCommon.注文設定_ポジション数_更新(ref dgv注文設定);
				FormCommon.注文設定_ポジション増加数_更新(ref dgv注文設定);
				//C共通.Z_取引単位を調整する(txt口座種別.Text, txt出金可能額で調整したロスカット余剰金.Text, ref dgv注文設定);

				using (SqlConnection cn = new SqlConnection())
				{
					cn.ConnectionString = Properties.Settings.Default.FXConnectionString;
					cn.Open();

					txt当日注文数.Text = fxcm.Cnt当日注文数(cn, 注文共通.Get当日の開始日時(DateTime.Now)).ToString();
					txt当日約定数.Text = fxcm.Cnt約定数(cn, 注文共通.Get当日の開始日時(DateTime.Now)).ToString();
					txt当日約定金額.Text = fxcm.GetSUM差益(cn, 注文共通.Get当日の開始日時(DateTime.Now), DateTime.Now).ToString();
				}
				
				txt決算待ちポジション数.Text = TradeFXCM.trades.RowCount.ToString();
			}
			catch (Exception ex)
			{
				Exception共通(true, ex, new List<Cエラー関連変数>());
			}
		}

		private void timer_日時曜日表示_Tick(object sender, EventArgs e)
		{
			try
			{
				システム日時更新();

				if (txtAuto.Text != "Auto")
					return;

				if (システム設定.Trade時間内 == "時間外")
				{
					if (txtログイン表示.Text == "ログイン中")
					{
						ログアウト();
					}
				}
				else if (システム設定.Trade時間内 == "時間内")
				{
					if (txtログイン表示.Text == "")
					{
						using (SqlConnection cn = new SqlConnection())
						{
							cn.ConnectionString = Properties.Settings.Default.FXConnectionString;
							cn.Open();

							ログイン_Order開始(cn);
							自動取引開始終了();
						}
					}
				}
			}
			catch (Exception ex)
			{
				Exception共通(true, ex, new List<Cエラー関連変数>());
			}
		}

		#endregion


		private void btnTest_Click(object sender, EventArgs e)
		{	
			try
			{
				txt注文単位.Text = 注文共通.Get注文単位(0, 0).ToString();

				txt注文単位.Text = 注文共通.Get注文単位(0, 1).ToString();

				txt注文単位.Text = 注文共通.Get注文単位(1, 0).ToString();

				txt注文単位.Text = 注文共通.Get注文単位(500000, 3500000).ToString();

				txt注文単位.Text = 注文共通.Get注文単位(1000000, 3500000).ToString();
				txt注文単位.Text = 注文共通.Get注文単位(1100000, 3500000).ToString();
				txt注文単位.Text = 注文共通.Get注文単位(1200000, 3500000).ToString();
				txt注文単位.Text = 注文共通.Get注文単位(1300000, 3500000).ToString();
				txt注文単位.Text = 注文共通.Get注文単位(1400000, 3500000).ToString();
				txt注文単位.Text = 注文共通.Get注文単位(1500000, 3500000).ToString();

				txt注文単位.Text = 注文共通.Get注文単位(2000000, 3500000).ToString();

				txt注文単位.Text = 注文共通.Get注文単位(2500000, 3500000).ToString();

				txt注文単位.Text = 注文共通.Get注文単位(200, 100).ToString();

				txt注文単位.Text = 注文共通.Get注文単位(int.Parse(txt保有可能ポジション数.Text), TradeFXCM.trades.RowCount).ToString();
			}
			catch (Exception ex)
			{
				Exception共通(true, ex, new List<Cエラー関連変数>());
			}
		}

		private void timer_10min_Tick(object sender, EventArgs e)
		{
			try
			{
				if (txtAuto.Text != "Auto")
					return;

				if (システム設定.Trade時間内 != "時間内")
					return;

				if (chk15mデータ生成以降の処理をスキップ.Checked == true)
					return;

				using (SqlConnection cn = new SqlConnection())
				{
					cn.ConnectionString = Properties.Settings.Default.FXConnectionString;
					cn.Open();

					FormCommon.BS終了_再処理(cn, DateTime.Now.AddMinutes(-25), ref dgv注文設定);
				}

			}
			catch (Exception ex)
			{
				ToolStripStsLbl.Text = "Exceptionエラーが発生しました。 " + ex.Message;
				ToolStripStsLbl.BackColor = Color.Red;
				Exception共通(false, ex, new List<Cエラー関連変数>());
			}

		}

        private void btnシステム設定DB登録_Click(object sender, EventArgs e)
        {
			using (SqlConnection cn = new SqlConnection())
			{
				cn.ConnectionString = Properties.Settings.Default.FXConnectionString;
				cn.Open();

				// No値を変更する場合、ストアド内で使用されているソースも合わせて変更しないといけない
				cmn.UpdateSettings(cn, 0, grpgrpシステム設定_注文設定_注文設定.Text, txtポジション増加数_直近n時間.Name, double.Parse(txtポジション増加数_直近n時間.Text) * -1);
				cmn.UpdateSettings(cn, 1, grpgrpシステム設定_注文設定_注文設定.Text, txt差損益気増加数_直近n日間.Name, double.Parse(txt差損益気増加数_直近n日間.Text));
				cmn.UpdateSettings(cn, 2, grpgrpシステム設定_注文設定_注文設定.Text, txtBS発生_リミット拡張幅.Name, double.Parse(txtBS発生_リミット拡張幅.Text));

				cmn.UpdateSettings(cn, 3, grpシステム設定_注文設定_Order.Text, txt余剰金割合_Order対象通貨ペアを減らす開始点.Name, double.Parse(txt余剰金割合_Order対象通貨ペアを減らす開始点.Text));
				cmn.UpdateSettings(cn, 4, grpシステム設定_注文設定_Order.Text, txt余剰金割合_Order限界点.Name, double.Parse(txt余剰金割合_Order限界点.Text));
				cmn.UpdateSettings(cn, 5, grpシステム設定_注文設定_Order.Text, txtOrder対象を減少させないOrder数.Name, double.Parse(txtOrder対象を減少させないOrder数.Text));
				cmn.UpdateSettings(cn, 6, grpシステム設定_注文設定_Order.Text, txtシステム設定_Rate幅を求めるn日間_Order間隔最小値.Name, double.Parse(txtシステム設定_Rate幅を求めるn日間_Order間隔最小値.Text));
				cmn.UpdateSettings(cn, 7, grpシステム設定_注文設定_Order.Text, txt前日の高値底値とOrder間隔最小値の割合.Name, double.Parse(txt前日の高値底値とOrder間隔最小値の割合.Text) / 100);

				cmn.UpdateSettings(cn, 8, grpシステム設定_注文設定_Order.Text, txtシステム設定_Rate幅を求めるn日間_リミット.Name, double.Parse(txtシステム設定_Rate幅を求めるn日間_リミット.Text));
				cmn.UpdateSettings(cn, 9, grpシステム設定_注文設定_Order.Text, txt前日の高値底値とリミットの割合.Name, double.Parse(txt前日の高値底値とリミットの割合.Text) / 100);
				cmn.UpdateSettings(cn, 10, grpシステム設定_注文設定_Order.Text, txtシステム_Order間隔増加割合.Name, double.Parse(txtシステム_Order間隔増加割合.Text));
				cmn.UpdateSettings(cn, 11, grpシステム設定_注文設定_Order.Text, txtシステム_自動更新Rate幅はOrder間隔のn倍.Name, double.Parse(txtシステム_自動更新Rate幅はOrder間隔のn倍.Text));
				cmn.UpdateSettings(cn, 12, grpシステム設定_注文設定_Order.Text, txtシステム設定_AtMarket.Name, double.Parse(txtシステム設定_AtMarket.Text));

				cmn.UpdateSettings(cn, 13, grpgrpシステム設定_注文設定_CloseTrade.Text, txt余剰金割合の限界点.Name, double.Parse(txt余剰金割合の限界点.Text));
				cmn.UpdateSettings(cn, 14, grpgrpシステム設定_注文設定_CloseTrade.Text, txtシステム設定_CloseTrade_nヵ月前からあるポジション.Name, (double)(int.Parse(txtシステム設定_CloseTrade_nヵ月前からあるポジション.Text) * -1));
				cmn.UpdateSettings(cn, 15, grpgrpシステム設定_注文設定_CloseTrade.Text, txtシステム設定_CloseTrade_n以上であればCloseする.Name, double.Parse(txtシステム設定_CloseTrade_n以上であればCloseする.Text));
			}
        }

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				/*
				using (SqlConnection cn = new SqlConnection())
				{
					Properties.Settings.Default.FXConnectionString = "Data Source=1111.5;Initial Catalog=DemoA_FX;User ID=sa;Password=1111";
					Properties.Settings.Default.Save();

					cn.ConnectionString = Properties.Settings.Default.FXConnectionString;
					cn.Open();

					chk15mデータ生成以降の処理をスキップ.Checked = false;
					chk注文状態記録まで注文はスキップ.Checked = false;
					ログイン();
					アカウント状態を表示();

					DateTime Order_Ver5_now = DateTime.Parse("2016-03-15 11:59:00");
					Order_Ver5_通貨ペアNo = 34;
					Order_Ver5_買いSwap = 16;
					Order_Ver5_売りSwap = -25;
					Order_Ver5_買いRate = 113.794;
					Order_Ver5_売りRate = 113.76;

					dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_買いSwap].Value = Order_Ver5_買いSwap;
					dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_売りSwap].Value = Order_Ver5_売りSwap;
					dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_買いRate].Value = Order_Ver5_買いRate;
					dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_売りRate].Value = Order_Ver5_売りRate;

					// ここまでは button1_Click(object sender, EventArgs e) 固有の初期化処理。


				 * 
				 * DateTime hour24前 = Order_Ver5_now.AddHours(-24 + (FXCMConst.FXOrder2Go時間補正 * -1));
					cmn.GetThisMonth1(cn, Order_Ver5_now, out Order_Ver5_StartMonth1, out Order_Ver5_EndMonth1);
					cmn.GetThisWeek1(cn, Order_Ver5_now, out Order_Ver5_StartWeek1, out Order_Ver5_EndWeek1);
					cmn.GetThisDay1(cn, Order_Ver5_now, out Order_Ver5_StartDay1, out Order_Ver5_EndDay1);
					cmn.GetThisHour1(cn, Order_Ver5_now, out Order_Ver5_StartHour1, out Order_Ver5_EndHour1);
					cmn.GetThisMin15(cn, Order_Ver5_now, out Order_Ver5_StartMin15, out Order_Ver5_EndMin15);
					cmn.GetThisMin5(cn, Order_Ver5_now, out Order_Ver5_StartMin5, out Order_Ver5_EndMin5);
					cmn.GetThisMin1(cn, Order_Ver5_now, out Order_Ver5_StartMin1, out Order_Ver5_EndMin1);

					if (chk15mデータ生成以降の処理をスキップ.Checked == true)
						return;

					if (C共通.Chk注文設定_Chk注文(Order_Ver5_通貨ペアNo, ref dgv注文設定) == false)
						return;

					if (C共通.注文設定_Swap判定(cn, Order_Ver5_通貨ペアNo, ref Order_Ver5_Swap判定, ref dgv注文設定) == false)
						return;

					if (C共通.B_逆ポジションの有る通貨ペアを算出(Order_Ver5_通貨ペアNo, txtシステム設定_注文設定Color_既に売買モードが逆の注文がある.BackColor, ref dgv注文設定) == false)
						return;

					dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_BS判定_前].Value
						= dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_BS判定_今].Value;

					oder.Chkボーナスステージ_15m(cn, Order_Ver5_通貨ペアNo, Order_Ver5_StartMin15, 2.5, out Order_Ver5_WMA判定_15m, out Order_Ver5_BS判定_15m,
						out Order_Ver5_WMA前_15m, out Order_Ver5_WMA今_15m, out Order_Ver5_WMA上昇角度_今);

					dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_WMA判定_15m].Value = Order_Ver5_WMA判定_15m;
					dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_BS判定_今].Value = Order_Ver5_BS判定_15m;

					if (Order_Ver5_WMA判定_15m != "")
					{
						dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_WMA前_15m].Value = Order_Ver5_WMA前_15m;
						dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_WMA今_15m].Value = Order_Ver5_WMA今_15m;
						dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_WMA上昇角度_今_15m].Value = Order_Ver5_WMA上昇角度_今;
					}

					dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_取引状況].Value = "Order中(通常)";

					Order_Ver5_BS開始 = false;
					if ((string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_BS判定_前].Value == "" &&
						(string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_BS判定_今].Value == "B")
					{
						if (string.IsNullOrEmpty((string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_保持ポジション].Value) ||
							(string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_保持ポジション].Value == Order_Ver5_WMA判定_15m)
						{
							// Bonus Stage 開始処理 //

							//Order_Ver5_リミット = Order_Ver5_買いRate * 0.5;	// 売買モードは関係なく「買いRate」を使う
							Order_Ver5_リミット = Order_Ver5_買いRate * Cシステム設定.BS発生_リミット拡張幅;	// 売買モードは関係なく「買いRate」を使う

							if ((string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_保持ポジション].Value != "")
							{
								C共通.特定通貨ペアのリミット幅を拡張する(cn, CFXCM定数.通貨ペア[Order_Ver5_通貨ペアNo],
									C共通.Get売買モード((string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_保持ポジション].Value),
									Order_Ver5_買いRate, Order_Ver5_売りRate, Order_Ver5_リミット);	// 現在Rateの50%分、リミットを拡張する。
							}

							dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_取引状況].Value = "Order中 (BS開始)";
							CDB_dbo.InsertBSHistory(cn, Order_Ver5_通貨ペアNo, Order_Ver5_シグマ閾値, Order_Ver5_now, Order_Ver5_買いRate, Order_Ver5_売りRate, Order_Ver5_WMA判定_15m, "S", "BS開始");
							Order_Ver5_BS開始 = true;
							//BS中の通貨ペア有り = true;
						}
					}
					else if ((string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_BS判定_前].Value == "B" &&
						(string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_BS判定_今].Value == "")
					{
						// Bonus Stage 終了処理 //

						if ((string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_保持ポジション].Value != "")
						{
							C共通.Order間隔最小値_リミット_更新(cn, Order_Ver5_通貨ペアNo, Order_Ver5_Swap判定,
								Cシステム設定.前日の高値底値とリミットの割合, Cシステム設定.Rate幅を求めるn日間_リミット, ref dgv注文設定);

							Order_Ver5_リミット = (double)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_リミット].Value;

							C共通.利益が出ているOrderは全てクローズする(cn, CFXCM定数.通貨ペア[Order_Ver5_通貨ペアNo], Order_Ver5_リミット, "Bonus Stage 終了 利益あり");

							C共通.保持ポジションのリミット初期化_BS終了時(cn, CFXCM定数.通貨ペア[Order_Ver5_通貨ペアNo], Order_Ver5_リミット);
						}

						dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_取引状況].Value = "Order対象外（BS終了）";
						CDB_dbo.InsertBSHistory(cn, Order_Ver5_通貨ペアNo, Order_Ver5_シグマ閾値, Order_Ver5_now, Order_Ver5_買いRate, Order_Ver5_売りRate, Order_Ver5_WMA判定_15m, "E", "BS終了");
						return;
					}
					else if ((string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_BS判定_前].Value == "B" &&
						(string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_BS判定_今].Value == "B")
					{
						// Bonus Stage 継続中は何もしない //

						dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_取引状況].Value = "Order対象外（BS継続中）";
						return;
					}

					if (C共通.A_取引状況エラー判定(Order_Ver5_通貨ペアNo, ref dgv注文設定) == false)
						return;

					if ((string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_BS判定_前].Value == "B" ||
						(string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_BS判定_今].Value == "B")
					{
						if (!string.IsNullOrEmpty((string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_保持ポジション].Value))
						{
							// Todo:Swapに逆らわない方式なら、保持ポジションよりSwapに対して逆かチェックした方が良さそう。
							if ((string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_保持ポジション].Value != Order_Ver5_WMA判定_15m)
							{
								dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_取引状況].Value = "Order対象外（逆BS中）";
								return;
							}
						}
					}

					// BB判定orWMA判定で注文可かどうか
					if (Order_Ver5_BS開始 == true)
					{
						if (ChkGC逆判定(cn, Order_Ver5_通貨ペアNo, Order_Ver5_now, Order_Ver5_WMA判定_15m, ref dgv注文設定))
						{
							Order_Ver5_売買判定 = Order_Ver5_WMA判定_15m;
						}
					}

					if (!WMA判定(cn, Order_Ver5_通貨ペアNo, Order_Ver5_買いSwap, Order_Ver5_売りSwap,
						Order_Ver5_StartMonth1, Order_Ver5_StartWeek1, Order_Ver5_StartDay1, Order_Ver5_StartHour1, Order_Ver5_StartMin15, Order_Ver5_StartMin5, Order_Ver5_StartMin1,
						ref Order_Ver5_売買判定))
					{
						return;
					}

					if (Order_Ver5_Swap判定 != Order_Ver5_売買判定)
					{
						dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_取引状況].Value = "Order対象外（BS Swap判定とWMA判定15mが不一致）";
						return;
					}

					// 注文可でも保持ポジションとの関係に問題がないかどうか
					if ((string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_保持ポジション].Value != "")
					{
						if ((string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_保持ポジション].Value != Order_Ver5_売買判定)
						{
							dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_取引状況].Value = "Order対象外（BS 保持ポジとWMA判定15mが不一致）";
							return;
						}
					}
					if (Chk総ポジション限界数(int.Parse(txt取引証拠金_現在.Text), CTrade.trades.RowCount))
					{
						dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_取引状況].Value = "Order対象外（総ポジションが限界数に達した）";
						return;
					}
					if (Order_Ver5_余剰金の割合 < Cシステム設定.余剰金割合_Order限界点)
					{
						取引停止中("取引停止中（余剰金割合_Order限界点）");
						dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_取引状況].Value = "取引停止中（余剰金割合_Order限界点）";
						return;
					}
					if (oder.Chk直近15分以内にOrder有り(cn, Order_Ver5_通貨ペアNo, Order_Ver5_now) == true)
					{
						dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_取引状況].Value = "直近15分以内にOrder有り";
						return;
					}
					if (CTrade.Chk24時間以内にポジション有り(Order_Ver5_通貨ペアNo, hour24前) == true)
					{
						dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_取引状況].Value = "直近15分以内にOrder有り";
						return;
					}

					C共通.Order間隔最小値_リミット_更新(cn, Order_Ver5_通貨ペアNo, Order_Ver5_売買判定,
						Cシステム設定.前日の高値底値とリミットの割合, Cシステム設定.Rate幅を求めるn日間_リミット, ref dgv注文設定);

					Order_Ver5_リミット = (double)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_リミット].Value;

					Order_Ver5_買売 = C共通.Get売買モード(Order_Ver5_売買判定);

					if (CTrade.Chk残ポジション有無(Order_Ver5_買売, CFXCM定数.通貨ペア[Order_Ver5_通貨ペアNo], Order_Ver5_買いRate, Order_Ver5_売りRate, Order_Ver5_リミット))
					{
						return; // 近くのRateでポジションが既にある。
					}

					Order_Ver5_注文単位 = (int)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_注文単位].Value;

					CDB_dbo.InsertOrderHistory(cn, Order_Ver5_通貨ペアNo, Order_Ver5_now, Order_Ver5_買売, Order_Ver5_買いSwap, Order_Ver5_売りSwap,
						Order_Ver5_買いRate, Order_Ver5_売りRate, Order_Ver5_リミット, Order_Ver5_注文単位, Order_Ver5_BS開始);

					注文時の状態記録();

					dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_取引状況].Value = "Order実行";

					if (chk注文状態記録まで注文はスキップ.Checked) return;

					CTrade.ポジション更新_成行(Order_Ver5_買売, CFXCM定数.通貨ペア[Order_Ver5_通貨ペアNo], Order_Ver5_買いRate, Order_Ver5_売りRate, Order_Ver5_注文単位,
						Order_Ver5_リミット, (string)dgv注文設定.Rows[Order_Ver5_通貨ペアNo].Cells[C共通.DGVClmNo注文設定_QuoteID].Value,
						Cシステム設定.AtMarket, out Order_Ver5_OrderId);

					CDB_dbo.UpdateOrderHistory_OrderId(cn, Order_Ver5_通貨ペアNo, Order_Ver5_now, (string)Order_Ver5_OrderId);
				}
				*/
			}
			catch(Exception ex)
			{
				string str = ex.Message;
			}
		}


		private void btn開始_Click(object sender, EventArgs e)
		{
			システム設定.CommandLine = txtモード.Text;
			toolStripStatusLabel1.Text = システム設定.CommandLine;

			Start();
		}


	}

}


