//using System;
//using System.Collections.Generic;
//using System.Linq;

//using System.Data.SqlClient;
//using System.Drawing;
//using System.IO;
//using System.Windows.Forms;
//using 定数;
//using 共通Data;
//using Common;
//using DB;

//namespace FXCMv1
//{
//    public class TradeEventFXCMv1 : I_TradeEvent
//    {
//        public void Start(SqlConnection cn)
//        {
//            ログ.ログ書き出し("Start");

//            bool TradingServerDisconnect = true;
//            while (TradingServerDisconnect)
//            {
//                try
//                {
//                    ログ.ログ書き出し("TradeFXCMv1 1");

//                    FXCMv1.ログイン_Order開始(cn);

//                    注文共通.自動取引開始終了();

//                    TradingServerDisconnect = false; // Ttrading server に接続できたのでループを抜ける。

//                    ログ.ログ書き出し("TradeFXCMv1 2");
//                }
//                catch (Exception ex)
//                {
//                    ログ.ログ書き出し("TradeFXCMv1 3");

//                    Mail.SendMailAndLog("ログイン失敗(FXCMv1)", ex);

//                    ログ.ログ書き出し("TradeFXCMv1 4");

//                    if (ex.Message.IndexOf(FX定数.trading_server_was_lost, StringComparison.Ordinal) > -1)
//                    {
//                        System.Threading.Thread.Sleep(600000); // 10分待ってTrading serverが復旧している事を期待。
//                    }

//                    ログ.ログ書き出し("TradeFXCMv1 5");

//                    if (DateTime.Now.Hour > 9)
//                    {
//                        // ログインを諦めてアプリケーションを終了しておく
//                        ログ.ログ書き出し("ログインを諦めてアプリケーションを終了");
//                        Application.Exit();
//                    }
//                }
//            }

//            //timer_Rate記録_3sec.Enabled = true;
//        }

//        public void Tick_1sec(SqlConnection cn)
//        {
//            try
//            {
//                //if (FormData.txtシステム設定_Trade時間内_Text == "時間外")
//                //{
//                //    if (FormData.txtログイン表示_Text == "ログイン中")
//                //    {
//                //        FXCMv1.ログアウト();
//                //    }
//                //}
//                //else if (注文共通.取引可能時間帯())
//                //{
//                //    if (FormData.txtログイン表示_Text == "")
//                //    {
//                //        FXCMv1.ログイン_Order開始(cn);
//                //        FormData.timer_3min.Enabled = true;
//                //        注文共通.自動取引開始終了();
//                //    }
//                //}
//            }
//            catch (Exception ex)
//            {
//                注文共通.Exception共通(ex, new List<Cエラー関連変数>());
//            }
//        }

//        public void Tick_4sec(SqlConnection cn)
//        {
//            try
//            {
//                FXCMv1.Order_Ver5(cn);
//            }
//            catch (Exception ex)
//            {
//                FXCMv1.FXサーバ障害時のException(ex);
//            }
//        }

//        public void Tick_3min(SqlConnection cn)
//        {
//            try
//            {
//                FormData.TradeApi.保持ポジション更新(FormData.通貨ぺア別取引状況);

//                //C共通.Z_取引単位を調整する(txt口座種別_Text, txt出金可能額で調整したロスカット余剰金_Text, ref dgv注文設定);

//                FormData.txt決算待ちポジション数 = FXCMv1.現在保有しているポジション数();
//            }
//            catch (Exception ex)
//            {
//                注文共通.Exception共通(ex, new List<Cエラー関連変数>());
//            }
//        }

//        public void Tick_10min(SqlConnection cn)
//        {
//            try
//            {
//                if (FormData.txtシステム設定_Trade時間内 == "時間外")
//                {
//                    if (FormData.txtログイン表示 == "ログイン中")
//                    {
//                        FXCMv1.ログアウト();
//                        return;
//                    }
//                }
//                else if (注文共通.取引可能時間帯())
//                {
//                    if (FormData.txtログイン表示 == "")
//                    {
//                        FXCMv1.ログイン_Order開始(cn);
//                        FormData.timer_3min.Enabled = true;
//                        注文共通.自動取引開始終了();
//                    }
//                }

//                注文共通.BS終了_再処理(cn, DateTime.Now.AddMinutes(-25));


//                FormData.txt当日約定数 = fxcm.Cnt約定数(cn, 注文共通.Get当日の開始日時(DateTime.Now));
//                FormData.txt当日約定金額 = fxcm.GetSUM差益(cn, 注文共通.Get当日の開始日時(DateTime.Now), DateTime.Now);

//            }
//            catch (Exception ex)
//            {
//                FormData.ToolStripStsLbl = "Exceptionエラーが発生しました。 " + ex.Message;
//                FormData.ToolStripStsLbl_BackColor = Color.Red;
//                注文共通.Exception共通(ex, new List<Cエラー関連変数>());
//            }
//        }

//        public void Tick_1h(SqlConnection cn)
//        {
//            try
//            {
//                //// 最新通常のリミット値へ更新する //


//                //FXCMv1.QuoteID表示();

//                //FXCMv1.DB記録_Account(cn);

//                //注文共通.先月当月利益更新(cn);

//                //FXCMv1.ClosedTrades_n日前のポジションを決済する(cn, FormData.chkn日以上前のポジション決済をスキップ, FormData.n日以上前のポジションは決済);

//                //pfmc.InsertポジションHourly(cn);

//                //if (DateTime.Now.Hour == 5)
//                //{
//                //    // 毎朝5時 //

//                //    foreach (var 通貨ぺア取引状況 in FormData.通貨ぺア別取引状況)
//                //    {
//                //        try
//                //        {
//                //            if (FXCMv1.Chk注文設定_データ生成Chk(cn, 通貨ぺア取引状況) == false)
//                //                continue;

//                //            if (通貨ぺア取引状況.保持ポジション == "")
//                //                continue;

//                //            FXCMv1.利益が出ているOrderは全てクローズする(cn);

//                //            注文共通.リミット更新(cn, 通貨ぺア取引状況);

//                //            FXCMv1.保持ポジションのリミット初期化(cn, 通貨ぺア取引状況);
//                //        }
//                //        catch (Exception ex)
//                //        {
//                //            List<Cエラー関連変数> Cエラー関連変数List = new List<Cエラー関連変数>();
//                //            Cエラー関連変数List.Add(new Cエラー関連変数() { 変数名 = "通貨ペアNo", 値 = 通貨ぺア取引状況.通貨ペアNo.ToString() });
//                //            注文共通.Exception共通(ex, Cエラー関連変数List);
//                //        }
//                //    }
//                //}
//                //else if (DateTime.Now.Hour == 8) // 毎朝8時 //
//                //{
//                //    //if (FormData.CommandLine.IndexOf("DemoA_FX", StringComparison.Ordinal) > -1)
//                //    //{
//                //    //	chk15mデータ生成以降の処理をスキップ_Checked = false;
//                //    //	chk注文状態記録まで注文はスキップ_Checked = false;
//                //    //}
//                //    //else if (FormData.CommandLine.IndexOf("RealA_FX", StringComparison.Ordinal) > -1)
//                //    //{
//                //    //	chk15mデータ生成以降の処理をスキップ_Checked = false;
//                //    //	chk注文状態記録まで注文はスキップ_Checked = false;
//                //    //}
//                //    //else
//                //    //{
//                //    //	chk15mデータ生成以降の処理をスキップ_Checked = true;
//                //    //	chk注文状態記録まで注文はスキップ_Checked = true;
//                //    //}

//                //    if (FormData.chk毎朝の自動注文開始を行う)
//                //    {
//                //        FormData.chk15mデータ生成以降の処理をスキップ = false;
//                //        FormData.chk注文状態記録まで注文はスキップ = false;
//                //    }
//                //}

//            }
//            catch (Exception ex)
//            {
//                FXCMv1.FXサーバ障害時のException(ex);
//            }
//        }

//        public void Tick_1day(SqlConnection cn)
//        {

//        }

//        public void Closing(SqlConnection cn)
//        {
//            try
//            {
//                注文共通.自動取引開始終了();

//                FXCMv1.Logout();
//            }
//            catch (Exception ex)
//            {
//                注文共通.Exception共通(ex, new List<Cエラー関連変数>());
//                注文共通.全Timerを停止();
//            }
//        }
//    }

//    public class TradeApiFXCMv1 : I_TradeApi
//	{
//		#region public method

//		public int 現在保有しているポジション数()
//		{
//			return FXCMv1.現在保有しているポジション数();
//		}

//		public void 利益が出ているポジションは全てクローズする(SqlConnection cn)
//		{
//			FXCMv1.利益が出ているOrderは全てクローズする(cn);
//		}

//        public void Swapに反しているいるBSポジションは全てクローズする(SqlConnection cn, 通貨ぺア取引状況 通貨ぺア取引状況)
//        {
//            FXCMv1.Swapに反しているいるBSポジションは全てクローズする(cn, 通貨ぺア取引状況);
//        }

//        public void 保持ポジションのリミット初期化_BS終了時(SqlConnection cn, 通貨ぺア取引状況 通貨ぺア取引状況)
//		{
//			FXCMv1.保持ポジションのリミット初期化_BS終了時(cn, 通貨ぺア取引状況);
//		}

//        public void 保持ポジション更新(List<通貨ぺア取引状況> 通貨ぺア別取引状況)
//        {
//            FXCMv1.保持ポジション更新(通貨ぺア別取引状況);
//		}

//		public int Getポジション増加数(通貨ぺア取引状況 通貨ぺア取引状況)
//		{
//			return FXCMv1.Getポジション増加数(通貨ぺア取引状況);
//		}

//		public bool Chk逆ポジション(通貨ぺア取引状況 通貨ぺア取引状況)
//		{
//			return FXCMv1.Chk逆ポジション(通貨ぺア取引状況);
//		}

//		public void 特定通貨ペアのリミット幅を拡張する(SqlConnection cn, 通貨ぺア取引状況 通貨ぺア取引状況)
//		{
//			FXCMv1.特定通貨ペアのリミット幅を拡張する(cn, 通貨ぺア取引状況);
//		}

//		public bool Chk近似Rateにポジション有り(SqlConnection cn, 通貨ぺア取引状況 通貨ぺア取引状況)
//		{
//			return FXCMv1.Chk近似Rateにポジション有り(cn, 通貨ぺア取引状況);
//		}

//        public bool 直近のポジションClose最終日時を再確認(SqlConnection cn, string Instrument2, DateTime _3時間前)
//        {
//            return true;
//        }

//        public void リミット_ストップ取得(通貨ぺア取引状況 通貨ぺア取引状況)
//        {

//        }

//        public long? ポジション追加_成行(SqlConnection cn, 通貨ぺア取引状況 通貨ぺア取引状況)
//		{
//			return FXCMv1.ポジション追加_成行(通貨ぺア取引状況);
//		}

//        public void 注文を全て削除()
//        {
//            FXCMv1.注文を全て削除();
//        }

//        public double 余剰金の割合計算()
//		{
//			return FXCMv1.余剰金の割合計算();
//		}

//		public void ポジションをクローズする(string sTradeID, int iAmount, double dRate, string sQuoteID, int iAtMarket, out object sOrderID)
//		{
//			FXCMv1.ポジションをクローズする(sTradeID, iAmount, dRate, sQuoteID, iAtMarket, out sOrderID);
//		}

//		public void FormDataUpdate_dgv注文設定_初回のみ(ref DataGridView dgv注文設定)
//		{
//			dgv注文設定.Rows.Add(FormData.通貨ぺア別取引状況.Where(x => x.FXCM固有 != null).Count());

//			int i = 0;
//			foreach (var 通貨ぺア別取引状況 in FormData.通貨ぺア別取引状況.Where(x => x.FXCM固有 != null))
//			{
//				dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_通貨ペア].Value = 通貨ぺア別取引状況.Instrument;
//				dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 通貨ぺア別取引状況.維持証拠金;
//				dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = 通貨ぺア別取引状況.Chkデータ生成;
//				dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = 通貨ぺア別取引状況.Chk注文;
//				i++;
//			}
//		}

//		public void FormDataUpdate_dgv注文設定(ref DataGridView dgv注文設定)
//		{
//			int i = 0;
//			foreach (var 通貨ぺア別取引状況 in FormData.通貨ぺア別取引状況.Where(x => x.FXCM固有 != null))
//			{
//				dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_取引状況].Value = 通貨ぺア別取引状況.取引状況;
//				dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_保持ポジション].Value = 通貨ぺア別取引状況.保持ポジション;
//				dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_売りSwap].Value = 通貨ぺア別取引状況.売りSwap;
//				dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_買いSwap].Value = 通貨ぺア別取引状況.買いSwap;
//				dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_Swap判定].Value = 通貨ぺア別取引状況.Swap判定;
//				dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_売りRate].Value = 通貨ぺア別取引状況.売りRate;
//				dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_買いRate].Value = 通貨ぺア別取引状況.買いRate;
//                dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_BS_WMA判定_15m].Value = 通貨ぺア別取引状況.BS_WMA判定_15m;
//				dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_BS判定_前].Value = 通貨ぺア別取引状況.BS判定_前;
//				dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_BS判定_今].Value = 通貨ぺア別取引状況.BS判定_今;
//				dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_ポジション数].Value = 通貨ぺア別取引状況.Unit数;
//				dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_維持証拠金小計].Value = 通貨ぺア別取引状況.維持証拠金小計;
//				dgv注文設定.Rows[i].DefaultCellStyle.BackColor = 通貨ぺア別取引状況.DefaultCellStyle_BackColor;
//				i++;
//			}
//		}

//		#endregion
//	}
//}
