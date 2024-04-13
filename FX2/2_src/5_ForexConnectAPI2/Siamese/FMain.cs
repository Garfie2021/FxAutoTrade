using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Data.SqlClient;
using Common;
using FXCM;
using DB;
using Order;


namespace Siamese
{
	public partial class FMain : Form
	{

		private static string BatFilePath = "";


		public FMain()
		{
			InitializeComponent();
		}

		/*
		public static void Orderは全てクローズする(string 通貨ペア名)
		{
			string TradeID;
			int Amount;
			string 売買モード;
			double OrderEntryRate;
			double CloseRate;
			string sQuoteID;
			object CloseOrderID;
			uint iCnt;

			for (iCnt = 1; iCnt <= Trade.trades.RowCount; iCnt++)
			{
				if ((double)Trade.trades.CellValue(iCnt, "GrossPL") < 0)
					continue;

				if ((string)Trade.trades.CellValue(iCnt, "Instrument") != 通貨ペア名)
					continue;

				売買モード = (string)Trade.trades.CellValue(iCnt, "BS");
				OrderEntryRate = (double)Trade.trades.CellValue(iCnt, "Open");
				CloseRate = (double)Trade.trades.CellValue(iCnt, "Close");
				TradeID = (string)Trade.trades.CellValue(iCnt, "TradeID");
				Amount = (int)Trade.trades.CellValue(iCnt, "Lot");
				sQuoteID = (string)Trade.trades.CellValue(iCnt, "QuoteID");

				Trade.ポジションをクローズする(TradeID, Amount, CloseRate, sQuoteID, Cシステム設定.AtMarket, out CloseOrderID);

				oder.UpdateOrderHistory_CloseOrderID(TradeID, (string)CloseOrderID);
			}
		}
		*/



		#region 非公開 共通メソッド

		private void chkポジション更新_成行_をスキップ_CheckedChanged()
		{
			if (chkポジション更新_成行_をスキップ.Checked == true)
			{
				ToolStripStsLbl.Text = "「Trade.ポジション更新_成行」をスキップ：チェック有り";
				ToolStripStsLbl.BackColor = Color.Yellow;
			}
			else if (chkポジション更新_成行_をスキップ.Checked == false)
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
			timer_1h.Enabled = false;
			timer_日時曜日更新_1sec.Enabled = false;

			txt取引モード表示.Text = "";
		}

		private void ログイン()
		{
			Trade.Login();

			txtログイン表示.Text = "ログイン中";
		}

		private void ログアウト()
		{
			Trade.Logout();

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

			txtシステム設定_Trade時間内.Text = C共通.GetTrade時間内();
		}

		private void 自動取引を解除()
		{
			timer_Order_5sec.Enabled = false;
			//timer_1min.Enabled = false;
			timer_1h.Enabled = false;
			txt取引モード表示.Text = "";
		}

		private void 自動取引を再開()
		{
			timer_Order_5sec.Enabled = true;
			//timer_1min.Enabled = true;
			timer_1h.Enabled = true;
			txt取引モード表示.Text = "自動取引中";
		}

		//private void アカウント状態を表示()
		//{
		//	txt取引証拠金_現在.Text = ((double)Trade.accounts.CellValue(1, "Balance")).ToString("F0");	//取引証拠金
		//	txt有効証拠金.Text = ((double)Trade.accounts.CellValue(1, "Equity")).ToString("F0");	//有効証拠金
		//	txt維持証拠金.Text = ((double)Trade.accounts.CellValue(1, "UsedMargin")).ToString("F0");	//維持証拠金
		//	txtロスカット余剰金.Text = ((double)Trade.accounts.CellValue(1, "UsableMargin")).ToString("F0");	//ロスカット余剰金
		//}

		private void 取引停止中(string Order状況)
		{
			txtOrder状況.Text = Order状況;

			//txt決算待ちポジション数.Text = Trade.trades.RowCount.ToString();
			return;
		}



		private void 前回の判定結果をクリア(byte 通貨ペアNo)
		{
			dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_売買判定].Value = "";
			dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_Rate高値_先月].Value = "";
			dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_Rate安値_先月].Value = "";
			dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_危険Rate判定_Monthly].Value = "";
			dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_Rate高値_先週].Value = "";
			dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_Rate安値_先週].Value = "";
			dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_危険Rate判定_Weekly].Value = "";
			dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_Rate高値_先日].Value = "";
			dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_Rate安値_先日].Value = "";
			dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_危険Rate判定_Daily].Value = "";
			dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_Rate高値_30m前].Value = "";
			dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_Rate安値_30m前].Value = "";
			dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_Rate高値_15m前].Value = "";
			dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_Rate安値_15m前].Value = "";
			dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_Rate高値_5m前].Value = "";
			dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_Rate安値_5m前].Value = "";
			dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_高値安値_Monthly].Value = "";
			dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_高値安値_Weekly].Value = "";
			dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_高値安値_Daily].Value = "";
			dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_WMA判定_15m].Value = "";
			//dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_BonusStage判定_前].Value = "";
			//dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_BonusStage判定_今].Value = "";
		}


		private void 自動取引開始()
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




		private void Exception共通(bool Timerを停止, Exception ex, string txtログフォルダ)
		{
			if (Timerを停止 == true)
			{
				全Timerを停止();
			}

			ToolStripStsLbl.Text = "Exceptionエラーが発生しました。 " + ex.Message;
			ToolStripStsLbl.BackColor = Color.Red;

			string ログファイル名 = DateTime.Now.ToString("yyyyMMdd") + ".log";

			File.AppendAllText(txtログフォルダ + @"\" + ログファイル名, "\r\n\r\n");
			File.AppendAllText(txtログフォルダ + @"\" + ログファイル名, DateTime.Now.ToString() + "\r\n", Encoding.GetEncoding("Shift_JIS"));
			File.AppendAllText(txtログフォルダ + @"\" + ログファイル名, ex.Data + "\r\n", Encoding.GetEncoding("Shift_JIS"));
			File.AppendAllText(txtログフォルダ + @"\" + ログファイル名, ex.HelpLink + "\r\n", Encoding.GetEncoding("Shift_JIS"));
			File.AppendAllText(txtログフォルダ + @"\" + ログファイル名, ex.InnerException + "\r\n", Encoding.GetEncoding("Shift_JIS"));
			File.AppendAllText(txtログフォルダ + @"\" + ログファイル名, ex.Message + "\r\n", Encoding.GetEncoding("Shift_JIS"));
			File.AppendAllText(txtログフォルダ + @"\" + ログファイル名, ex.Source + "\r\n", Encoding.GetEncoding("Shift_JIS"));
			File.AppendAllText(txtログフォルダ + @"\" + ログファイル名, ex.StackTrace + "\r\n", Encoding.GetEncoding("Shift_JIS"));
			File.AppendAllText(txtログフォルダ + @"\" + ログファイル名, ex.TargetSite + "\r\n", Encoding.GetEncoding("Shift_JIS"));

		}

		private void ログイン_Order開始()
		{
			ログイン();

			//アカウント状態を表示();

			using (SqlConnection cn = new SqlConnection())
			{
				cn.ConnectionString = dbo.ConnectionString();
				cn.Open();

				OrderD.OrderV1(cn);
			}

			自動取引開始();
		}

		private void システム設定_読込み()
		{
			// 注文設定 //
			Cシステム設定.ポジション増加数_直近n時間 = int.Parse(txtポジション増加数_直近n時間.Text) * -1;
			Cシステム設定.差損益気増加数_直近n日間 = int.Parse(txt差損益気増加数_直近n日間.Text);
			Cシステム設定.BonusStage発生_リミット拡張幅 = double.Parse(txtBonusStage発生_リミット拡張幅.Text);

			// Order //
			Cシステム設定.余剰金割合_Order対象通貨ペアを減らす開始点 = double.Parse(txt余剰金割合_Order対象通貨ペアを減らす開始点.Text);
			Cシステム設定.余剰金割合_Order限界点 = double.Parse(txt余剰金割合_Order限界点.Text);
			Cシステム設定.Order対象を減少させないOrder数 = int.Parse(txtOrder対象を減少させないOrder数.Text);
			Cシステム設定.Rate幅を求めるn日間_Order間隔最小値 = byte.Parse(txtシステム設定_Rate幅を求めるn日間_Order間隔最小値.Text);
			Cシステム設定.前日の高値底値とOrder間隔最小値の割合 = double.Parse(txt前日の高値底値とOrder間隔最小値の割合.Text);
			Cシステム設定.Rate幅を求めるn日間_リミット = byte.Parse(txtシステム設定_Rate幅を求めるn日間_リミット.Text);
			Cシステム設定.前日の高値底値とリミットの割合 = double.Parse(txt前日の高値底値とリミットの割合.Text);
			Cシステム設定.Order間隔増加割合 = double.Parse(txtシステム_Order間隔増加割合.Text);
			Cシステム設定.自動更新Rate幅はOrder間隔のn倍 = double.Parse(txtシステム_自動更新Rate幅はOrder間隔のn倍.Text);
			Cシステム設定.AtMarket = int.Parse(txtシステム設定_AtMarket.Text);

			// Close Trade //
			Cシステム設定.余剰金割合の限界点 = double.Parse(txt余剰金割合の限界点.Text);
			Cシステム設定.CloseTrade_nヵ月前からあるポジション = int.Parse(txtシステム設定_CloseTrade_nヵ月前からあるポジション.Text) * -1;
			Cシステム設定.CloseTrade_n以上であればCloseする = int.Parse(txtシステム設定_CloseTrade_n以上であればCloseする.Text);

			// 出金 Monthly //
			Cシステム設定.出金可能にする開始日時 = DateTime.Parse(txt出金可能にする開始日時.Text);
			Cシステム設定.出金可能にする取引証拠金 = int.Parse(txt出金可能にする取引証拠金.Text);
			Cシステム設定.出金可能にする利益Percent = byte.Parse(txt出金可能にする利益Percent.Text);

			// その他 //
			Cシステム設定.日付はn時くぎり = int.Parse(txtシステム設定_日付はn時くぎり.Text);
			Cシステム設定.ログフォルダ = txtログフォルダ.Text;

		}

		#endregion

		#region イベントハンドラ Form

		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				string cmds = "";
				toolStripStatusLabel1.Text = "";
				if (Environment.GetCommandLineArgs().Length > 1)
				{
					cmds = Environment.GetCommandLineArgs()[1];
					toolStripStatusLabel1.Text = cmds;
				}

				txtDB接続先.Text = dbo.ConnectionString();

				システム設定_読込み();

				this.Text = "AutoFX  " + Directory.GetCurrentDirectory() + @"\AutoFx_Form.exe  " + File.GetLastWriteTime(Cシステム設定.ExeFilePath).ToString();

				if (Directory.Exists(txtログフォルダ.Text) == false)
					Directory.CreateDirectory(txtログフォルダ.Text);

				File.AppendAllText(txtログフォルダ.Text + @"\log.log", "Start" + "\r\n", Encoding.GetEncoding("Shift_JIS"));


				if (toolStripStatusLabel1.Text.IndexOf("Close") > -1)
				{
					//クローズメッセージを送信する
					System.Diagnostics.Process[] ps = System.Diagnostics.Process.GetProcessesByName("AutoFx_Form");
					foreach (System.Diagnostics.Process p in ps)
					{
						p.CloseMainWindow();
					}
				}

				システム日時更新();

				txtログイン表示.Text = "";
				txt取引モード表示.Text = "";
				ToolStripStsLbl.Text = "";

				//奇数行を黄色にする
				dgv注文設定.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;

				C注文設定.注文基本設定(int.Parse(txt基準注文単位.Text), ref dgv注文設定);
				C注文設定.注文設定_データ生成Chk_FX(ref dgv注文設定);
				C注文設定.注文設定_注文Chk_Real_FX(ref dgv注文設定);

				// 自動ログイン取引開始
				if (toolStripStatusLabel1.Text.IndexOf("Auto") > -1)
				{
					txtAuto.Text = "Auto";

					if (txtシステム設定_Trade時間内.Text == "時間内")
					{
						ログイン_Order開始();

						//timer_Rate記録_3sec.Enabled = true;
					}
				}
				else
				{
					txtAuto.Text = "";
				}

				timer_日時曜日更新_1sec.Enabled = true;

				chkポジション更新_成行_をスキップ_CheckedChanged();


			}
			catch (Exception ex)
			{
				Exception共通(true, ex, txtログフォルダ.Text);
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				自動取引開始();

				//Trade.Logout();
			}
			catch (Exception ex)
			{
				Exception共通(true, ex, txtログフォルダ.Text);
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

				if (txtシステム設定_Trade時間内.Text != "時間内")
					return;

				using (SqlConnection cn = new SqlConnection())
				{
					cn.ConnectionString = dbo.ConnectionString();
					cn.Open();

					//OrderD.BonusStage終了_再処理(DateTime.Now.AddMinutes(-25), ref dgv注文設定);

					//Trade.DB記録_ClosedTrades(cn);

					OrderD.OrderV1(cn);

					//Trade.DB記録_Trades(cn);
				}

				//txt決算待ちポジション数.Text = Trade.trades.RowCount.ToString();

			}
			catch (Exception ex)
			{
				ToolStripStsLbl.Text = "Exceptionエラーが発生しました。 " + ex.Message;

				if (ToolStripStsLbl.Text.IndexOf("ORA-") > -1)
				{
					ToolStripStsLbl.BackColor = Color.Orange;
				}
				else
				{
					ToolStripStsLbl.BackColor = Color.Red;
				}

				Exception共通(false, ex, txtログフォルダ.Text);
			}
		}



		private void timer_リミット更新_1h_Tick(object sender, EventArgs e)
		{
			// 最新通常のリミット値へ更新する //

			try
			{
				if (txtAuto.Text != "Auto")
					return;

				if (txtシステム設定_Trade時間内.Text != "時間内")
					return;

				if (DateTime.Now.Hour == 8)
                {
                    // 毎朝8時 //
                    chkRate記録以降の処理をスキップ.Checked = false;
                    chkポジション更新_成行_をスキップ.Checked = false;
                }
			}
			catch (Exception ex)
			{
				ToolStripStsLbl.Text = "Exceptionエラーが発生しました。 " + ex.Message;
				ToolStripStsLbl.BackColor = Color.Red;
				Exception共通(false, ex, txtログフォルダ.Text);
			}
		}


		private void timer_日時曜日表示_Tick(object sender, EventArgs e)
		{
			try
			{
				システム日時更新();

				if (txtAuto.Text != "Auto")
					return;

				if (txtシステム設定_Trade時間内.Text == "時間外")
				{
					if (txtログイン表示.Text == "ログイン中")
					{
						ログアウト();
					}
				}
				else if (txtシステム設定_Trade時間内.Text == "時間内")
				{
					if (txtログイン表示.Text == "")
					{
						ログイン_Order開始();
					}
				}
			}
			catch (Exception ex)
			{
				Exception共通(true, ex, txtログフォルダ.Text);
			}
		}


		#endregion



		private void btnTest_Click(object sender, EventArgs e)
		{	
			try
			{

	
			}
			catch (Exception ex)
			{
				Exception共通(true, ex, txtログフォルダ.Text);
			}
		}

		private void chkポジション更新_成行_をスキップ_CheckedChanged(object sender, EventArgs e)
		{
			chkポジション更新_成行_をスキップ_CheckedChanged();
		}


        private void btnシステム設定DB登録_Click(object sender, EventArgs e)
        {
            // No値を変更する場合、ストアド内で使用されているソースも合わせて変更しないといけない
            cmn.UpdateSettings(0, grpgrpシステム設定_注文設定_注文設定.Text, txtポジション増加数_直近n時間.Name, double.Parse(txtポジション増加数_直近n時間.Text) * -1);
            cmn.UpdateSettings(1, grpgrpシステム設定_注文設定_注文設定.Text, txt差損益気増加数_直近n日間.Name, double.Parse(txt差損益気増加数_直近n日間.Text));
            cmn.UpdateSettings(2, grpgrpシステム設定_注文設定_注文設定.Text, txtBonusStage発生_リミット拡張幅.Name, double.Parse(txtBonusStage発生_リミット拡張幅.Text));

            cmn.UpdateSettings(3, grpシステム設定_注文設定_Order.Text, txt余剰金割合_Order対象通貨ペアを減らす開始点.Name, double.Parse(txt余剰金割合_Order対象通貨ペアを減らす開始点.Text));
            cmn.UpdateSettings(4, grpシステム設定_注文設定_Order.Text, txt余剰金割合_Order限界点.Name, double.Parse(txt余剰金割合_Order限界点.Text));
            cmn.UpdateSettings(5, grpシステム設定_注文設定_Order.Text, txtOrder対象を減少させないOrder数.Name, double.Parse(txtOrder対象を減少させないOrder数.Text));
            cmn.UpdateSettings(6, grpシステム設定_注文設定_Order.Text, txtシステム設定_Rate幅を求めるn日間_Order間隔最小値.Name, double.Parse(txtシステム設定_Rate幅を求めるn日間_Order間隔最小値.Text));
            cmn.UpdateSettings(7, grpシステム設定_注文設定_Order.Text, txt前日の高値底値とOrder間隔最小値の割合.Name, double.Parse(txt前日の高値底値とOrder間隔最小値の割合.Text) / 100);
            
            cmn.UpdateSettings(8, grpシステム設定_注文設定_Order.Text, txtシステム設定_Rate幅を求めるn日間_リミット.Name, double.Parse(txtシステム設定_Rate幅を求めるn日間_リミット.Text));
            cmn.UpdateSettings(9, grpシステム設定_注文設定_Order.Text, txt前日の高値底値とリミットの割合.Name, double.Parse(txt前日の高値底値とリミットの割合.Text) / 100);
            cmn.UpdateSettings(10, grpシステム設定_注文設定_Order.Text, txtシステム_Order間隔増加割合.Name, double.Parse(txtシステム_Order間隔増加割合.Text));
            cmn.UpdateSettings(11, grpシステム設定_注文設定_Order.Text, txtシステム_自動更新Rate幅はOrder間隔のn倍.Name, double.Parse(txtシステム_自動更新Rate幅はOrder間隔のn倍.Text));
            cmn.UpdateSettings(12, grpシステム設定_注文設定_Order.Text, txtシステム設定_AtMarket.Name, double.Parse(txtシステム設定_AtMarket.Text));

            cmn.UpdateSettings(13, grpgrpシステム設定_注文設定_CloseTrade.Text, txt余剰金割合の限界点.Name, double.Parse(txt余剰金割合の限界点.Text));
            cmn.UpdateSettings(14, grpgrpシステム設定_注文設定_CloseTrade.Text, txtシステム設定_CloseTrade_nヵ月前からあるポジション.Name, (double)(int.Parse(txtシステム設定_CloseTrade_nヵ月前からあるポジション.Text) * -1));
            cmn.UpdateSettings(15, grpgrpシステム設定_注文設定_CloseTrade.Text, txtシステム設定_CloseTrade_n以上であればCloseする.Name, double.Parse(txtシステム設定_CloseTrade_n以上であればCloseする.Text));

        }


	}

}


