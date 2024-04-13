//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Drawing;
//using System.Windows.Forms;
//using 定数;
//using 共通Data;
//using Common;
//using DB;

//namespace FXCMv1
//{
//    public static class FXCMv1
//    {
//        #region メンバ変数

//        private static FXCore.TradeDeskAut tradeDesk;
//        private static FXCore.TableAut accounts;
//        private static FXCore.TableAut orders;
//        private static FXCore.TableAut trades;
//        private static FXCore.TableAut offers;
//        private static FXCore.TableAut closed;
//        private static FXCore.TableAut summary;
//        private static string accountId = "";

//        #endregion


//        #region internal

//        #region login logout

//        public static void ログイン_Order開始()
//        {
//            ログ.ログ書き出し(" FXCMv1 1");

//            ログイン();
//            ログ.ログ書き出し(" FXCMv1 2");

//            QuoteID表示();
//            ログ.ログ書き出し(" FXCMv1 3");

//            アカウント状態を表示();
//            ログ.ログ書き出し(" FXCMv1 4");

//            DB記録_Account();
//            ログ.ログ書き出し(" FXCMv1 5");

//            //注文共通.先月当月利益更新(cn);
//            ログ.ログ書き出し(" FXCMv1 6");

//            Order_Ver5();
//            ログ.ログ書き出し(" FXCMv1 7");
//        }

//        private static void ログイン()
//        {
//            ログイン(FormData.DemoReal.ToString(), FormData.Username, FormData.Password);

//            FormData.ログイン表示 = "ログイン中";
//        }

//        public static void ログアウト()
//        {
//            FormData.timer_3min.Enabled = false;

//            Logout();

//            FormData.ログイン表示 = "";
//        }

//        public static void Logout()
//        {
//            if (tradeDesk != null)
//            {
//                tradeDesk.Logout();
//                tradeDesk = null;
//            }
//        }

//        #endregion


//        #region order

//        public static void Order_Ver5()
//        {
//            DB記録_ClosedTrade();

//            アカウント状態を表示();

//            保持ポジション更新();

//            注文共通.余剰金調整();
//            FormData.余剰金の割合 = 余剰金の割合計算();

//            if (double.IsNaN(FormData.余剰金の割合) == true)
//            {
//                注文共通.取引停止中("取引停止中（IsNaN(余剰金の割合)）");
//                return;
//            }

//            ClosedTrades_余剰金を確保する();

//            Order_Ver5_WMA_BS_順張り();

//            DB記録_Trade();
//        }

//        private static void Order_Ver5_WMA_BS_順張り()
//        {
//            FormData.OrderData = new OrderData();

//            FormData.OrderData.now = DateTime.Now;
//            FormData.OrderData.FXCM_Hour24前 = FormData.OrderData.now.AddHours(-24 + (FX定数.FXOrder2Go時間補正 * -1));

//            注文共通.StartTime_EndTime取得(FormData.OrderData);

//            foreach (var 通貨ぺア取引状況 in FormData.通貨ぺア別取引状況)
//            {
//                try
//                {
//                    if (通貨ぺア取引状況.FXCM固有 == null)
//                    {
//                        // FX Trading Station の CCY で対象としていないInstrumentはここを通る。
//                        continue;
//                    }

//                    if (FXCMv1.Chk注文設定_データ生成Chk(通貨ぺア取引状況) == false)
//                        continue;

//                    if (通貨ペア別Rate取得(FormData.OrderData, 通貨ぺア取引状況) == false)
//                        continue;

//                    注文共通.WMA計算(通貨ぺア取引状況);

//                    if (FormData.chk15mデータ生成以降の処理をスキップ == true)
//                        continue;

//                    if (注文共通.Chk注文設定_Chk注文(FormData.OrderData, 通貨ぺア取引状況) == false)
//                    {
//                        BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, "Chk注文", FormData.OrderData.now);
//                        return;
//                    }

//                    oder.GetWMA_Month1(FormData.OrderData, 通貨ぺア取引状況);
//                    oder.GetWMA_Week1(FormData.OrderData, 通貨ぺア取引状況);
//                    oder.GetWMA_Day1(FormData.OrderData, 通貨ぺア取引状況);
//                    oder.GetWMA_Hour1(FormData.OrderData, 通貨ぺア取引状況);
//                    oder.GetWMA_Min15(FormData.OrderData, 通貨ぺア取引状況);
//                    oder.GetWMA_Min5(FormData.OrderData, 通貨ぺア取引状況);
//                    oder.GetWMA_Min1(FormData.OrderData, 通貨ぺア取引状況);

//                    BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, "Order判定開始", FormData.OrderData.now);

//                    if (注文共通.C_注文_Order_Ver6_BS(FormData.OrderData, 通貨ぺア取引状況) == false)
//                    {
//                        注文共通.C_注文_Order_Ver6_通常(FormData.OrderData, 通貨ぺア取引状況);
//                    }
//                }
//                catch (Exception ex)
//                {
//                    List<Cエラー関連変数> Cエラー関連変数List = new List<Cエラー関連変数>();
//                    Cエラー関連変数List.Add(new Cエラー関連変数() { 変数名 = "Order_Ver5_通貨ペアNo", 値 = 通貨ぺア取引状況.通貨ペアNo.ToString() });
//                    注文共通.Exception共通(ex, Cエラー関連変数List);
//                }
//            }
//        }

//        public static bool Chk注文設定_データ生成Chk(通貨ぺア取引状況 通貨ぺア取引状況)
//        {
//            if (通貨ぺア取引状況.Chkデータ生成 == false)
//            {
//                BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, "Order対象外（データ生成ChkがFalse）", FormData.OrderData.now);
//                return false;
//            }

//            return true;
//        }

//        #endregion

//        public static void FXサーバ障害時のException(Exception ex)
//        {
//            FormData.ToolStripStsLbl = "Exceptionエラーが発生しました。 " + ex.Message;
//            注文共通.Exception共通(ex, new List<Cエラー関連変数>());

//            if (ex.Message.IndexOf("ORA-", StringComparison.Ordinal) > -1)
//            {
//                FormData.ToolStripStsLbl_BackColor = Color.Orange;
//            }
//            else
//            {
//                if ((ex.Message.IndexOf(FX定数.trading_server_was_lost, StringComparison.Ordinal) > -1 ||
//                        ex.Message.IndexOf(FX定数.Market_is_closed, StringComparison.Ordinal) > -1) &&
//                    (DateTime.Now.DayOfWeek == DayOfWeek.Saturday && DateTime.Now.Hour > 5))
//                {
//                    // FXCMがクローズしてる。
//                    ログ.ログ書き出し(" Application.Exit FXCM Close ");
//                    Application.Exit();
//                }

//                if (ex.Message.IndexOf(FX定数.trading_server_was_lost, StringComparison.Ordinal) > -1)
//                {
//                    // 平日にFXCMサーバが再起動したので復旧する。
//                    System.Threading.Thread.Sleep(60000); // 1分待ってTrading serverが復旧している事を期待。

//                    //  ここで"trading server was lost"が起きても、タイマーで再実行されるので再接続の為のループなしない。
//                    ログイン_Order開始();
//                    FormData.timer_3min.Enabled = true;
//                }
//            }
//        }

//        private static uint QuoteID表示_通貨ペアCnt;
//        //private static byte QuoteID表示_通貨ペアNo;
//        public static void QuoteID表示()
//        {
//            for (QuoteID表示_通貨ペアCnt = 1; QuoteID表示_通貨ペアCnt <= 通貨ペア数(); QuoteID表示_通貨ペアCnt++)
//            {
//                //System.Diagnostics.Debug.WriteLine(通貨ペア名(QuoteID表示_通貨ペアCnt));
//                通貨ぺア取引状況 通貨ぺア取引状況 = FormData.通貨ぺア別取引状況.Find(x => x.Instrument == 通貨ペア名(QuoteID表示_通貨ペアCnt));

//                if (通貨ぺア取引状況 == null)
//                {
//                    FormData.通貨ぺア別取引状況.Remove(通貨ぺア取引状況);
//                    continue;
//                }

//                通貨ぺア取引状況.FXCM固有 = new FXCM固有()
//                {
//                    OffersID = QuoteID表示_通貨ペアCnt,
//                    QuoteID = QuoteID取得(QuoteID表示_通貨ペアCnt)
//                };
//            }

//            //for (QuoteID表示_通貨ペアNo = 0; QuoteID表示_通貨ペアNo < FormData.通貨ぺア別取引状況.Count; QuoteID表示_通貨ペアNo++)
//            //{
//            //	//System.Diagnostics.Debug.WriteLine(QuoteID表示_通貨ペアNo);
//            //	if ((bool)FormData.通貨ぺア別取引状況[QuoteID表示_通貨ペアNo].Chkデータ生成 == false)
//            //		continue;

//            //	for (QuoteID表示_通貨ペアCnt = 1; QuoteID表示_通貨ペアCnt <= 通貨ペア数(); QuoteID表示_通貨ペアCnt++)
//            //	{
//            //		//System.Diagnostics.Debug.WriteLine(QuoteID表示_通貨ペアCnt);
//            //		FormData.通貨ぺア別取引状況.Find(x => x.通貨ペア名 == 通貨ペア名(QuoteID表示_通貨ペアCnt)).QuoteID = QuoteID取得(QuoteID表示_通貨ペアCnt);
//            //	}
//            //}
//        }

//        public static int 現在保有しているポジション数()
//        {
//            return trades.RowCount;
//        }

//        public static void 保持ポジション更新()
//        {
//            foreach (var 通貨ぺア取引状況 in FormData.通貨ぺア別取引状況)
//            {
//                if (FXCMv1.Chk注文設定_データ生成Chk(通貨ぺア取引状況) == false)
//                    continue;

//                通貨ぺア取引状況.保持ポジション = Get保持ポジション(通貨ぺア取引状況);
//            }
//        }


//        private static string 保持ポジションのリミットを初期化する_TradeID;
//        private static bool? 保持ポジションのリミットを初期化する_BS;
//        private static double 保持ポジションのリミットを初期化する_OpenRate;
//        private static double 保持ポジションのリミットを初期化する_CloseRate;
//        private static double 保持ポジションのリミットを初期化する_Rate;
//        private static uint 保持ポジションのリミットを初期化する_iCnt;
//        public static void 保持ポジションのリミット初期化(通貨ぺア取引状況 通貨ぺア取引状況)
//        {
//            for (保持ポジションのリミットを初期化する_iCnt = 1; 保持ポジションのリミットを初期化する_iCnt <= trades.RowCount; 保持ポジションのリミットを初期化する_iCnt++)
//            {
//                if ((string)trades.CellValue(保持ポジションのリミットを初期化する_iCnt, "Instrument") != 通貨ぺア取引状況.Instrument)
//                    continue;

//                保持ポジションのリミットを初期化する_TradeID = (string)trades.CellValue(保持ポジションのリミットを初期化する_iCnt, "TradeID");
//                保持ポジションのリミットを初期化する_BS = 変換.GetBool売買((string)trades.CellValue(保持ポジションのリミットを初期化する_iCnt, "BS"));
//                保持ポジションのリミットを初期化する_OpenRate = (double)trades.CellValue(保持ポジションのリミットを初期化する_iCnt, "Open");
//                保持ポジションのリミットを初期化する_CloseRate = (double)trades.CellValue(保持ポジションのリミットを初期化する_iCnt, "Close");

//                if (保持ポジションのリミットを初期化する_BS == true)
//                {
//                    if (保持ポジションのリミットを初期化する_OpenRate < 保持ポジションのリミットを初期化する_CloseRate)
//                    {
//                        保持ポジションのリミットを初期化する_Rate = 保持ポジションのリミットを初期化する_CloseRate;
//                    }
//                    else
//                    {
//                        保持ポジションのリミットを初期化する_Rate = 保持ポジションのリミットを初期化する_OpenRate;
//                    }
//                }
//                else
//                {
//                    if (保持ポジションのリミットを初期化する_OpenRate > 保持ポジションのリミットを初期化する_CloseRate)
//                    {
//                        保持ポジションのリミットを初期化する_Rate = 保持ポジションのリミットを初期化する_CloseRate;
//                    }
//                    else
//                    {
//                        保持ポジションのリミットを初期化する_Rate = 保持ポジションのリミットを初期化する_OpenRate;
//                    }
//                }

//                //リミット変更(保持ポジションのリミットを初期化する_TradeID, 保持ポジションのリミットを初期化する_BS,
//                //	通貨ぺア取引状況, out 保持ポジションのリミットを初期化する_リミット初期化OrderID);
//            }
//        }

//        private static DateTime ClosedTrades_n日前のポジションを決済する_Time;
//        private static string ClosedTrades_n日前のポジションを決済する_sTradeID;
//        private static int ClosedTrades_n日前のポジションを決済する_iAmount;
//        private static double ClosedTrades_n日前のポジションを決済する_dRate;
//        private static string ClosedTrades_n日前のポジションを決済する_sQuoteID;
//        private static object ClosedTrades_n日前のポジションを決済する_CloseOrderID;
//        private static uint ClosedTrades_n日前のポジションを決済する_iCnt;
//        public static void ClosedTrades_n日前のポジションを決済する(bool chkn日以上前のポジション決済をスキップ, int n日前)
//        {
//            if (chkn日以上前のポジション決済をスキップ == true)
//                return;

//            n日前 = n日前 * -1;

//            DateTime dt_n日前 = DateTime.Now.AddDays(n日前);

//            for (ClosedTrades_n日前のポジションを決済する_iCnt = 1; ClosedTrades_n日前のポジションを決済する_iCnt <= trades.RowCount; ClosedTrades_n日前のポジションを決済する_iCnt++)
//            {
//                ClosedTrades_n日前のポジションを決済する_Time = (DateTime)trades.CellValue(ClosedTrades_n日前のポジションを決済する_iCnt, "Time");
//                ClosedTrades_n日前のポジションを決済する_sTradeID = (string)trades.CellValue(ClosedTrades_n日前のポジションを決済する_iCnt, "TradeID");

//                if (dt_n日前 < ClosedTrades_n日前のポジションを決済する_Time)
//                {
//                    continue;
//                }

//                ClosedTrades_n日前のポジションを決済する_iAmount = (int)trades.CellValue(ClosedTrades_n日前のポジションを決済する_iCnt, "Lot");
//                ClosedTrades_n日前のポジションを決済する_dRate = (double)trades.CellValue(ClosedTrades_n日前のポジションを決済する_iCnt, "Close");
//                ClosedTrades_n日前のポジションを決済する_sQuoteID = (string)trades.CellValue(ClosedTrades_n日前のポジションを決済する_iCnt, "QuoteID");

//                ポジションをクローズする(ClosedTrades_n日前のポジションを決済する_sTradeID, ClosedTrades_n日前のポジションを決済する_iAmount,
//                    ClosedTrades_n日前のポジションを決済する_dRate, ClosedTrades_n日前のポジションを決済する_sQuoteID, FormData.システム設定_AtMarket,
//                    out ClosedTrades_n日前のポジションを決済する_CloseOrderID);

//                DB記録_ClosedTrade();
//            }
//        }

//        private static string 利益が出ているOrderは全てクローズする_TradeID;
//        private static int 利益が出ているOrderは全てクローズする_Amount;
//        private static string 利益が出ているOrderは全てクローズする_売買モード;
//        private static double 利益が出ているOrderは全てクローズする_OrderEntryRate;
//        private static double 利益が出ているOrderは全てクローズする_CloseRate;
//        private static string 利益が出ているOrderは全てクローズする_sQuoteID;
//        private static object 利益が出ているOrderは全てクローズする_CloseOrderID;
//        private static uint 利益が出ているOrderは全てクローズする_iCnt;
//        public static void 利益が出ているOrderは全てクローズする()
//        {
//            for (利益が出ているOrderは全てクローズする_iCnt = 1; 利益が出ているOrderは全てクローズする_iCnt <= trades.RowCount; 利益が出ているOrderは全てクローズする_iCnt++)
//            {
//                if ((double)trades.CellValue(利益が出ているOrderは全てクローズする_iCnt, "GrossPL") < 30)
//                    continue;

//                利益が出ているOrderは全てクローズする_売買モード = (string)trades.CellValue(利益が出ているOrderは全てクローズする_iCnt, "BS");
//                利益が出ているOrderは全てクローズする_OrderEntryRate = (double)trades.CellValue(利益が出ているOrderは全てクローズする_iCnt, "Open");
//                利益が出ているOrderは全てクローズする_CloseRate = (double)trades.CellValue(利益が出ているOrderは全てクローズする_iCnt, "Close");
//                利益が出ているOrderは全てクローズする_TradeID = (string)trades.CellValue(利益が出ているOrderは全てクローズする_iCnt, "TradeID");
//                利益が出ているOrderは全てクローズする_Amount = (int)trades.CellValue(利益が出ているOrderは全てクローズする_iCnt, "Lot");
//                利益が出ているOrderは全てクローズする_sQuoteID = (string)trades.CellValue(利益が出ているOrderは全てクローズする_iCnt, "QuoteID");

//                ポジションをクローズする(利益が出ているOrderは全てクローズする_TradeID, 利益が出ているOrderは全てクローズする_Amount,
//                    利益が出ているOrderは全てクローズする_CloseRate, 利益が出ているOrderは全てクローズする_sQuoteID, FormData.システム設定_AtMarket,
//                    out 利益が出ているOrderは全てクローズする_CloseOrderID);
//            }
//        }

//        public static void Swapに反しているいるBSポジションは全てクローズする(通貨ぺア取引状況 通貨ぺア取引状況)
//        {
//        }


//        public static void 保持ポジションのリミット初期化_BS終了時(通貨ぺア取引状況 通貨ぺア取引状況)
//        {
//            string TradeID;
//            //object リミット初期化OrderID;
//            uint iCnt;

//            for (iCnt = 1; iCnt <= trades.RowCount; iCnt++)
//            {
//                if ((string)trades.CellValue(iCnt, "Instrument") != 通貨ぺア取引状況.Instrument)
//                    continue;

//                TradeID = (string)trades.CellValue(iCnt, "TradeID");

//                //リミット変更(TradeID, 変換.GetBool売買(通貨ぺア取引状況.Swap判定), 通貨ぺア取引状況, out リミット初期化OrderID);
//            }
//        }


//        private static uint Get保持ポジション_iCnt;
//        private static string Get保持ポジション_売買モード;
//        public static string Get保持ポジション(通貨ぺア取引状況 通貨ぺア取引状況)
//        {
//            for (Get保持ポジション_iCnt = 1; Get保持ポジション_iCnt <= trades.RowCount; Get保持ポジション_iCnt++)
//            {
//                if ((string)trades.CellValue(Get保持ポジション_iCnt, "Instrument") != 通貨ぺア取引状況.Instrument)
//                    continue;

//                bool? 売買モード = 変換.GetBool売買((string)trades.CellValue(Get保持ポジション_iCnt, "BS"));

//                if (売買モード == true)
//                {
//                    Get保持ポジション_売買モード = "B";
//                }
//                else if (売買モード == false)
//                {
//                    Get保持ポジション_売買モード = "S";
//                }
//                else
//                {
//                    Get保持ポジション_売買モード = "";
//                }

//                return Get保持ポジション_売買モード;
//            }

//            return "";
//        }

//        //private static int 保持ポジション更新_ポジション数;
//        //private static uint 保持ポジション更新_Cnt;
//        public static void 保持ポジション更新(List<通貨ぺア取引状況> 通貨ぺア別取引状況)
//        {
//            //Getポジション数_ポジション数 = 0;
//            //for (Getポジション数_Cnt = 1; Getポジション数_Cnt <= trades.RowCount; Getポジション数_Cnt++)
//            //{
//            //	if ((string)trades.CellValue(Getポジション数_Cnt, "Instrument") != 通貨ぺア取引状況.Instrument)
//            //		continue;
//            //	else
//            //		Getポジション数_ポジション数++;
//            //}

//            //return Getポジション数_ポジション数;
//        }

//        private static DateTime Getポジション増加数用_now;
//        private static int Getポジション増加数用_iOutFrom;
//        private static int Getポジション増加数用_iOutTo;
//        private static DateTime Getポジション増加数用_Time;
//        private static int Getポジション増加数_ポジション数;
//        private static uint Getポジション増加数_iCnt3;
//        public static int Getポジション増加数(通貨ぺア取引状況 通貨ぺア取引状況)
//        {
//            //DateTime now = DateTime.Parse("2014/03/17 7:00:00");
//            Getポジション増加数用_now = DateTime.Now;
//            注文共通.土日を含む場合の調整_時間単位(Getポジション増加数用_now, FormData.ポジション増加数_直近n時間, 0,
//                out Getポジション増加数用_iOutFrom, out Getポジション増加数用_iOutTo);

//            Getポジション増加数用_Time = DateTime.Now;
//            Getポジション増加数用_now = Getポジション増加数用_now.AddHours(Getポジション増加数用_iOutFrom);

//            Getポジション増加数_ポジション数 = 0;
//            for (Getポジション増加数_iCnt3 = 1; Getポジション増加数_iCnt3 <= trades.RowCount; Getポジション増加数_iCnt3++)
//            {
//                if ((string)trades.CellValue(Getポジション増加数_iCnt3, "Instrument") != 通貨ぺア取引状況.Instrument)
//                    continue;

//                Getポジション増加数用_Time = (DateTime)trades.CellValue(Getポジション増加数_iCnt3, "Time");

//                if (Getポジション増加数用_now > Getポジション増加数用_Time)
//                    continue;

//                Getポジション増加数_ポジション数++;
//            }

//            return Getポジション増加数_ポジション数;
//        }

//        #endregion


//        #region privateメソッド

//        private static double 取引証拠金()
//        {
//            return ((double)accounts.CellValue(1, "Balance"));
//        }

//        private static double 有効証拠金()
//        {
//            return ((double)accounts.CellValue(1, "Equity"));
//        }

//        private static double 維持証拠金()
//        {
//            return ((double)accounts.CellValue(1, "UsedMargin"));
//        }

//        private static double ロスカット余剰金()
//        {
//            return ((double)accounts.CellValue(1, "UsableMargin"));
//        }

//        private static void ログイン(string connection, string strUsername, string strPassword)
//        {
//            FXCore.CoreAut fxCore;
//            fxCore = new FXCore.CoreAut();

//            tradeDesk = (FXCore.TradeDeskAut)fxCore.CreateTradeDesk("trader");
//            tradeDesk.Login(strUsername, strPassword, FX定数.URL, connection);
//            accounts = (FXCore.TableAut)tradeDesk.FindMainTable("accounts");
//            orders = (FXCore.TableAut)tradeDesk.FindMainTable("Orders");
//            trades = (FXCore.TableAut)tradeDesk.FindMainTable("Trades");
//            offers = (FXCore.TableAut)tradeDesk.FindMainTable("offers");
//            closed = (FXCore.TableAut)tradeDesk.FindMainTable("closed trades");
//            summary = (FXCore.TableAut)tradeDesk.FindMainTable("Summary");

//            accountId = (string)accounts.CellValue(1, "AccountID");
//            注文共通.minAmount = (int)accounts.CellValue(1, "BaseUnitSize");
//        }

//        private static void Rate取得(通貨ぺア取引状況 通貨ぺア取引状況)
//        {
//            通貨ぺア取引状況.買いRate = (double)offers.CellValue(通貨ぺア取引状況.FXCM固有.OffersID, "Ask");
//            通貨ぺア取引状況.売りRate = (double)offers.CellValue(通貨ぺア取引状況.FXCM固有.OffersID, "Bid");
//        }

//        private static void Swap取得(通貨ぺア取引状況 通貨ぺア取引状況)
//        {
//            通貨ぺア取引状況.買いSwap = (double)offers.CellValue(通貨ぺア取引状況.FXCM固有.OffersID, "IntrB");
//            通貨ぺア取引状況.売りSwap = (double)offers.CellValue(通貨ぺア取引状況.FXCM固有.OffersID, "IntrS");

//            if (通貨ぺア取引状況.買いSwap == 0 && 通貨ぺア取引状況.売りSwap == 0)
//            {
//                swap.Get売買Swapがどちらも0になる前のSwap(通貨ぺア取引状況);
//            }
//        }

//        public static void ClosedTrades_余剰金を確保する()
//        {
//            if (FormData.chk余剰金確保の自動ポジションCloseはしない == true)
//                return;

//            double 余剰金の割合 = 0;

//            DateTime Time;
//            double 差益 = 0;
//            string sTradeID = "";
//            int iAmount = 0;
//            double dRate = 0;
//            string sQuoteID = "";
//            object CloseOrderID;

//            for (uint iCnt = 1; iCnt <= FormData.決算待ちポジション数; iCnt++)
//            {
//                余剰金の割合 = FormData.TradeApi.余剰金の割合計算();

//                if (余剰金の割合 > FormData.余剰金割合の限界点)
//                    return;

//                if (FormData.chk余剰金確保の自動ポジションCloseはMSG確認する == true)
//                {
//                    if (MessageBox.Show("[ClosedTrades_余剰金を確保する]を本当に実行しますか？ \r\n実行すると、極端な損失が発生します。", "確認（超重要）",
//                        MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
//                        return;
//                }

//                temp.DeleteAll_SortCloseTradeTmp();

//                for (uint iCnt2 = 1; iCnt2 <= FormData.決算待ちポジション数; iCnt2++)
//                {
//                    Time = (DateTime)trades.CellValue(iCnt, "Time");
//                    差益 = (double)trades.CellValue(iCnt, "GrossPL");
//                    iAmount = (int)trades.CellValue(iCnt, "Lot");
//                    dRate = (double)trades.CellValue(iCnt, "Close");
//                    sTradeID = (string)trades.CellValue(iCnt, "TradeID");
//                    sQuoteID = (string)trades.CellValue(iCnt, "QuoteID");

//                    temp.InsertSortCloseTradeTmp(Time, sTradeID, 差益, iAmount, dRate, sQuoteID);
//                }

//                temp.FillBy差益_SortCloseTradeTmp(sTradeID, iAmount, dRate, sQuoteID);

//                // 差益がマイナスなTrade、Top1のみクローズ
//                FormData.TradeApi.ポジションをクローズする(sTradeID, iAmount, dRate, sQuoteID, FormData.システム設定_AtMarket, out CloseOrderID);

//                System.Threading.Thread.Sleep(1000);
//            }
//        }

//        private static void ポジション更新(bool bBuyShellMode, string 通貨ペア, string str取引単位, string str取引間隔,
//            string strリミット, string str高値限界Rate, string str下値限界Rate, string strLogFolder)
//        {
//            //string accountId = (string)accounts.CellValue(1, "AccountID");

//            int minAmount = (int)accounts.CellValue(1, "BaseUnitSize");
//            int Amount = minAmount * int.Parse(str取引単位);
//            double dbl取引間隔 = double.Parse(str取引間隔);
//            double dblリミット = double.Parse(strリミット);
//            double dbl高値限界Rate = double.Parse(str高値限界Rate);

//            uint iCnt = 1;
//            for (double dblEntryRate = double.Parse(str下値限界Rate); dblEntryRate < dbl高値限界Rate; dblEntryRate += dbl取引間隔)
//            {
//                double EntryLimit = 0;
//                if (bBuyShellMode == true)
//                    EntryLimit = dblEntryRate + dblリミット;
//                else
//                    EntryLimit = dblEntryRate - dblリミット;

//                //既に注文状況にEntoryが無いかチェック
//                //double Limit = 0;
//                double OpenRate = 0;
//                double TopRangeRate = 0;
//                double BottomRangeRate = 0;
//                bool b既にEntory有り = false;
//                for (iCnt = 1; iCnt <= orders.RowCount; iCnt++)
//                {
//                    if ((string)orders.CellValue(iCnt, "Instrument") != 通貨ペア)
//                        continue;

//                    OpenRate = (double)orders.CellValue(iCnt, "Rate");
//                    //TopRangeRate = OpenRate + (dbl取引間隔 / 2);
//                    //BottomRangeRate = OpenRate - (dbl取引間隔 / 2);
//                    TopRangeRate = OpenRate + dbl取引間隔;
//                    BottomRangeRate = OpenRate - dbl取引間隔;

//                    if (BottomRangeRate < dblEntryRate && dblEntryRate < TopRangeRate)
//                    {
//                        b既にEntory有り = true;
//                        break;
//                    }
//                }

//                if (b既にEntory有り == true)
//                    continue;

//                //既にポジションにEntoryが無いかチェック
//                for (iCnt = 1; iCnt <= trades.RowCount; iCnt++)
//                {
//                    if ((string)trades.CellValue(iCnt, "Instrument") != 通貨ペア)
//                        continue;

//                    OpenRate = (double)trades.CellValue(iCnt, "Open");
//                    //TopRangeRate = OpenRate + (dbl取引間隔 / 2);
//                    //BottomRangeRate = OpenRate - (dbl取引間隔 / 2);
//                    TopRangeRate = OpenRate + dbl取引間隔;
//                    BottomRangeRate = OpenRate - dbl取引間隔;

//                    if (BottomRangeRate < dblEntryRate && dblEntryRate < TopRangeRate)
//                    {
//                        b既にEntory有り = true;
//                        break;
//                    }
//                }

//                ////既に逆ポジションにEntoryが無いかチェック
//                //b既にEntory有り = Chk逆ポジション(trades, 通貨ペア, bBuyShellMode);

//                if (b既にEntory有り == true)
//                    continue;

//                //指値取引を登録
//                object orderId, di;
//                tradeDesk.CreateEntryOrder2(accountId, 通貨ペア, bBuyShellMode, Amount, dblEntryRate, tradeDesk.SL_LIMIT, 0, EntryLimit, 0, out orderId, out di);

//            }
//        }

//        private static string 特定通貨ペアのリミット幅を拡張する_TradeID;
//        private static double 特定通貨ペアのリミット幅を拡張する_Limit;
//        //private static object 特定通貨ペアのリミット幅を拡張する_リミット拡張OrderID;
//        private static uint 特定通貨ペアのリミット幅を拡張する_iCnt;
//        public static void 特定通貨ペアのリミット幅を拡張する(通貨ぺア取引状況 通貨ぺア取引状況)
//        {
//            特定通貨ペアのリミット幅を拡張する_TradeID = "";
//            特定通貨ペアのリミット幅を拡張する_Limit = 0;

//            for (特定通貨ペアのリミット幅を拡張する_iCnt = 1; 特定通貨ペアのリミット幅を拡張する_iCnt <= trades.RowCount; 特定通貨ペアのリミット幅を拡張する_iCnt++)
//            {
//                if ((string)trades.CellValue(特定通貨ペアのリミット幅を拡張する_iCnt, "Instrument") != 通貨ぺア取引状況.Instrument)
//                    continue;

//                特定通貨ペアのリミット幅を拡張する_TradeID = (string)trades.CellValue(特定通貨ペアのリミット幅を拡張する_iCnt, "TradeID");
//                特定通貨ペアのリミット幅を拡張する_Limit = (double)trades.CellValue(特定通貨ペアのリミット幅を拡張する_iCnt, "Limit");

//                //リミット変更(特定通貨ペアのリミット幅を拡張する_TradeID, 変換.GetBool売買(通貨ぺア取引状況.保持ポジション), 通貨ぺア取引状況,
//                //	out 特定通貨ペアのリミット幅を拡張する_リミット拡張OrderID);
//            }
//        }

//        private static Object ポジションをクローズする_sDI;
//        public static void ポジションをクローズする(string sTradeID, int iAmount, double dRate, string sQuoteID, int iAtMarket,
//            out object sOrderID)
//        {
//            tradeDesk.CloseTrade(sTradeID, iAmount, dRate, sQuoteID, iAtMarket, out sOrderID, out ポジションをクローズする_sDI);
//        }

//        public static double 余剰金の割合計算()
//        {
//            //return ((double)CTrade.accounts.CellValue(1, "UsableMargin") / (double)CTrade.accounts.CellValue(1, "Balance")) * 100;
//            return (FormData.ロスカット余剰金 / (double)accounts.CellValue(1, "Balance")) * 100;
//        }

//        public static void 注文を全て削除()
//        {
//            int 注文Entry数;

//            FXCore.TableAut accounts = (FXCore.TableAut)tradeDesk.FindMainTable("accounts");
//            //string accountId = (string)accounts.CellValue(1, "AccountID");
//            //int minAmount = (int)accounts.CellValue(1, "BaseUnitSize");

//            int iRowCount = orders.RowCount;
//            string OrderID = "";

//            while (orders.RowCount != 0)
//            {
//                OrderID = (string)orders.CellValue(1, "OrderID");
//                tradeDesk.DeleteOrder(OrderID);
//            }

//            注文Entry数 = orders.RowCount;
//        }

//        /// <summary>
//        /// オーダーRateとリミットRateの間に、既にポジションがないかチェック。
//        /// ポジションが有ったら注文しない。
//        /// </summary>
//        /// <returns>
//        /// true：ポジション有り
//        /// false：ポジション無し
//        /// </returns>
//        public static bool Chk近似Rateにポジション有り(通貨ぺア取引状況 通貨ぺア取引状況)   // 厳密な比較を必要としないので「買いRate」のみ比較に使う。
//        {
//            double ポジション追加_成行_OrderRate;

//            //既にポジションにEntoryが無いか
//            for (uint ポジション追加_成行_iCnt = 1; ポジション追加_成行_iCnt <= trades.RowCount; ポジション追加_成行_iCnt++)
//            {
//                if ((string)trades.CellValue(ポジション追加_成行_iCnt, "Instrument") != 通貨ぺア取引状況.Instrument)
//                    continue;

//                ポジション追加_成行_OrderRate = (double)trades.CellValue(ポジション追加_成行_iCnt, "Open");

//                if ((通貨ぺア取引状況.買いRate - 通貨ぺア取引状況.注文禁止Rate幅) < ポジション追加_成行_OrderRate &&
//                    ポジション追加_成行_OrderRate < (通貨ぺア取引状況.買いRate + 通貨ぺア取引状況.注文禁止Rate幅))
//                {
//                    return true; // ポジション有り
//                }
//            }

//            return false; // ポジション無し
//        }

//        //private static object ポジション追加_成行_di;
//        public static long? ポジション追加_成行(通貨ぺア取引状況 通貨ぺア取引状況)
//        {
//            if (通貨ぺア取引状況.売買 == null)
//            {
//                // ここを通ったらバグ
//                throw new Exception("「通貨ぺア取引状況.売買」がnull");
//            }

//            if (通貨ぺア取引状況.売買 == true)
//            {
//                //           if (通貨ぺア取引状況.買いリミット == null)
//                //           {
//                //               ログ.ログ書き出し(" ポジション追加_成行() 「通貨ぺア取引状況.買いリミット」がnull");
//                //               return null;
//                //           }

//                //           tradeDesk.OpenTrade2(accountId, 通貨ぺア取引状況.Instrument, (bool)通貨ぺア取引状況.売買, 注文共通.minAmount * FormData.txt注文単位,
//                //通貨ぺア取引状況.買いRate, 通貨ぺア取引状況.FXCM固有.QuoteID, FormData.txtシステム設定_AtMarket, tradeDesk.SL_LIMIT, 0,
//                //               (double)通貨ぺア取引状況.買いリミット, 0, out 通貨ぺア取引状況.OpenOrderID, out ポジション追加_成行_di);	//成り行き
//            }
//            else
//            {
//                //           if (通貨ぺア取引状況.売りリミット == null)
//                //           {
//                //               ログ.ログ書き出し(" ポジション追加_成行() 「通貨ぺア取引状況.売りリミット」がnull ");
//                //               return null;
//                //           }

//                //           tradeDesk.OpenTrade2(accountId, 通貨ぺア取引状況.Instrument, (bool)通貨ぺア取引状況.売買, 注文共通.minAmount * FormData.txt注文単位,
//                //通貨ぺア取引状況.売りRate, 通貨ぺア取引状況.FXCM固有.QuoteID, FormData.txtシステム設定_AtMarket, tradeDesk.SL_LIMIT, 0,
//                //               (double)通貨ぺア取引状況.売りリミット, 0, out 通貨ぺア取引状況.OpenOrderID, out ポジション追加_成行_di);   //成り行き

//                //           //// UPDATEでやる
//                //           //cmd.Parameters.Add(new SqlParameter("OpenOrderID", SqlDbType.VarChar));
//                //           //cmd.Parameters["OpenOrderID"].Direction = ParameterDirection.Input;
//                //           //if (通貨ぺア取引状況.OpenOrderID == null) cmd.Parameters["OpenOrderID"].Value = DBNull.Value;
//                //           //else cmd.Parameters["OpenOrderID"].Value = 通貨ぺア取引状況.OpenOrderID;

//                //           //@OpenOrderID varchar(50),
//                //           //@Oanda_TradeData_id     bigint


//                //           //OpenOrderID,
//                //           //Oanda_TradeData_id


//                //           //@OpenOrderID,
//                //           //@Oanda_TradeData_id


//            }

//            return null;
//        }

//        private static uint Chk逆ポジション_iCnt;
//        public static bool Chk逆ポジション(通貨ぺア取引状況 通貨ぺア取引状況)
//        {
//            for (Chk逆ポジション_iCnt = 1; Chk逆ポジション_iCnt <= trades.RowCount; Chk逆ポジション_iCnt++)
//            {
//                if ((string)trades.CellValue(Chk逆ポジション_iCnt, "Instrument") != 通貨ぺア取引状況.Instrument)
//                    continue;

//                if ((string)trades.CellValue(Chk逆ポジション_iCnt, "BS") == "B")
//                {
//                    //買いのポジションがあったら、売りを出さない。
//                    if (通貨ぺア取引状況.Swap判定 == "S")
//                    {
//                        return true;
//                    }
//                }
//                else if ((string)trades.CellValue(Chk逆ポジション_iCnt, "BS") == "S")
//                {
//                    //売りのポジションがあったら、買いを出さない。
//                    if (通貨ぺア取引状況.Swap判定 == "B")
//                    {
//                        return true;
//                    }
//                }
//            }

//            return false;
//        }

//        public static void DB記録_Account()
//        {
//            fxcm.InsertAccounts(
//                FormData.口座No,
//                DateTime.Now,
//                (string)FXCMv1.accounts.CellValue(1, "AccountID"),
//                (string)FXCMv1.accounts.CellValue(1, "AccountName"),
//                (double)FXCMv1.accounts.CellValue(1, "Balance"),
//                (double)FXCMv1.accounts.CellValue(1, "Equity"),
//                (double)FXCMv1.accounts.CellValue(1, "DayPL"),
//                (double)FXCMv1.accounts.CellValue(1, "NontrdEqty"),
//                (double)FXCMv1.accounts.CellValue(1, "M2MEquity"),
//                (double)FXCMv1.accounts.CellValue(1, "UsedMargin"),
//                (double)FXCMv1.accounts.CellValue(1, "UsableMargin"),
//                (double)FXCMv1.accounts.CellValue(1, "GrossPL"),
//                (string)FXCMv1.accounts.CellValue(1, "Kind"),
//                (string)FXCMv1.accounts.CellValue(1, "MarginCall"),
//                FXCMv1.accounts.CellValue(1, "IsUnderMarginCall").ToString(),
//                (string)FXCMv1.accounts.CellValue(1, "Hedging"),
//                (int)FXCMv1.accounts.CellValue(1, "AmountLimit"),
//                (int)FXCMv1.accounts.CellValue(1, "BaseUnitSize"));
//        }

//        private static string TradesDB登録_TradeID;
//        private static byte TradesDB登録_IsBuy;
//        private static string TradesDB登録_OpenOrderID;
//        private static uint TradesDB登録_iCnt;
//        private static void DB記録_Trade()
//        {
//            for (TradesDB登録_iCnt = 1; TradesDB登録_iCnt <= FXCMv1.trades.RowCount; TradesDB登録_iCnt++)
//            {
//                TradesDB登録_TradeID = (string)FXCMv1.trades.CellValue(TradesDB登録_iCnt, "TradeID");

//                if ((int)fxcm.Cnt_Trades_TradeID(FormData.口座No, TradesDB登録_TradeID) > 0)
//                    continue;

//                if (FXCMv1.trades.CellValue(TradesDB登録_iCnt, "IsBuy").ToString().CompareTo("True") == 0)
//                    TradesDB登録_IsBuy = 1;
//                else
//                    TradesDB登録_IsBuy = 0;

//                TradesDB登録_OpenOrderID = (string)FXCMv1.trades.CellValue(TradesDB登録_iCnt, "OpenOrderID");

//                fxcm.InsertTrade(
//                    FormData.口座No,
//                      TradesDB登録_TradeID
//                    , (string)FXCMv1.trades.CellValue(TradesDB登録_iCnt, "AccountID")
//                    , (string)FXCMv1.trades.CellValue(TradesDB登録_iCnt, "AccountName")
//                    , (string)FXCMv1.trades.CellValue(TradesDB登録_iCnt, "OfferID")
//                    , (string)FXCMv1.trades.CellValue(TradesDB登録_iCnt, "Instrument")
//                    , (int)FXCMv1.trades.CellValue(TradesDB登録_iCnt, "Lot")
//                    , (double)FXCMv1.trades.CellValue(TradesDB登録_iCnt, "AmountK")
//                    , (string)FXCMv1.trades.CellValue(TradesDB登録_iCnt, "BS")
//                    , (double)FXCMv1.trades.CellValue(TradesDB登録_iCnt, "Open")
//                    , (double)FXCMv1.trades.CellValue(TradesDB登録_iCnt, "Close")
//                    , (double)FXCMv1.trades.CellValue(TradesDB登録_iCnt, "Stop")
//                    , (double)FXCMv1.trades.CellValue(TradesDB登録_iCnt, "UntTrlMove")
//                    , (double)FXCMv1.trades.CellValue(TradesDB登録_iCnt, "Limit")
//                    , (double)FXCMv1.trades.CellValue(TradesDB登録_iCnt, "UntTrlMoveLimit")
//                    , (double)FXCMv1.trades.CellValue(TradesDB登録_iCnt, "PL")
//                    , (double)FXCMv1.trades.CellValue(TradesDB登録_iCnt, "GrossPL")
//                    , (double)FXCMv1.trades.CellValue(TradesDB登録_iCnt, "Com")
//                    , (double)FXCMv1.trades.CellValue(TradesDB登録_iCnt, "Int")
//                    , ((DateTime)FXCMv1.trades.CellValue(TradesDB登録_iCnt, "Time")).AddHours(FX定数.FXOrder2Go時間補正)
//                    , TradesDB登録_IsBuy
//                    , (string)FXCMv1.trades.CellValue(TradesDB登録_iCnt, "Kind")
//                    , (string)FXCMv1.trades.CellValue(TradesDB登録_iCnt, "QuoteID")
//                    , TradesDB登録_OpenOrderID
//                    , ""
//                    , (string)FXCMv1.trades.CellValue(TradesDB登録_iCnt, "QTXT")
//                    , ""
//                    , ""
//                    , (string)FXCMv1.trades.CellValue(TradesDB登録_iCnt, "TradeIDOrigin")
//                    );
//            }
//        }

//        private static string DB記録_ClosedTrades_TradeID;
//        private static uint DB記録_ClosedTrades_iCnt;
//        private static void DB記録_ClosedTrade()
//        {
//            for (DB記録_ClosedTrades_iCnt = 1; DB記録_ClosedTrades_iCnt <= FXCMv1.closed.RowCount; DB記録_ClosedTrades_iCnt++)
//            {
//                DB記録_ClosedTrades_TradeID = (string)FXCMv1.closed.CellValue(DB記録_ClosedTrades_iCnt, "TradeID");

//                if (fxcm.SelectCnt_TradeID(DB記録_ClosedTrades_TradeID) > 0)
//                    continue;

//                fxcm.InsertClosedTrades(
//                    DB記録_ClosedTrades_TradeID,
//                    (string)FXCMv1.closed.CellValue(DB記録_ClosedTrades_iCnt, "AccountID"),
//                    (string)FXCMv1.closed.CellValue(DB記録_ClosedTrades_iCnt, "AccountName"),
//                    (string)FXCMv1.closed.CellValue(DB記録_ClosedTrades_iCnt, "OfferID"),
//                    (string)FXCMv1.closed.CellValue(DB記録_ClosedTrades_iCnt, "Instrument"),
//                    (int)FXCMv1.closed.CellValue(DB記録_ClosedTrades_iCnt, "Lot"),
//                    (double)FXCMv1.closed.CellValue(DB記録_ClosedTrades_iCnt, "AmountK"),
//                    (string)FXCMv1.closed.CellValue(DB記録_ClosedTrades_iCnt, "BS"),
//                    (double)FXCMv1.closed.CellValue(DB記録_ClosedTrades_iCnt, "Open"),
//                    (double)FXCMv1.closed.CellValue(DB記録_ClosedTrades_iCnt, "Close"),
//                    (double)FXCMv1.closed.CellValue(DB記録_ClosedTrades_iCnt, "PL"),
//                    (double)FXCMv1.closed.CellValue(DB記録_ClosedTrades_iCnt, "GrossPL"),
//                    (double)FXCMv1.closed.CellValue(DB記録_ClosedTrades_iCnt, "Com"),
//                    (double)FXCMv1.closed.CellValue(DB記録_ClosedTrades_iCnt, "Int"),
//                    ((DateTime)FXCMv1.closed.CellValue(DB記録_ClosedTrades_iCnt, "OpenTime")).AddHours(FX定数.FXOrder2Go時間補正),
//                    ((DateTime)FXCMv1.closed.CellValue(DB記録_ClosedTrades_iCnt, "CloseTime")).AddHours(FX定数.FXOrder2Go時間補正),
//                    (string)FXCMv1.closed.CellValue(DB記録_ClosedTrades_iCnt, "Kind"),
//                    (string)FXCMv1.closed.CellValue(DB記録_ClosedTrades_iCnt, "OpenOrderID"),
//                    "",
//                    (string)FXCMv1.closed.CellValue(DB記録_ClosedTrades_iCnt, "CloseOrderID"),
//                    "",
//                    (string)FXCMv1.closed.CellValue(DB記録_ClosedTrades_iCnt, "OQTXT"),
//                    (string)FXCMv1.closed.CellValue(DB記録_ClosedTrades_iCnt, "CQTXT"),
//                    "",
//                    "");

//            }
//        }

//        //private static void リミット変更(string TradeID, bool? 売買モード, 通貨ぺア取引状況 通貨ぺア取引状況, out object リミット変更OrderID)
//        //{
//        //          if (売買モード == true)
//        //	{
//        //              if (通貨ぺア取引状況.買いリミット == null)
//        //              {
//        //                  // ここを通ったらバグ
//        //                  throw new Exception("「通貨ぺア取引状況.買いリミット」がnull");
//        //              }

//        //              tradeDesk.ChangeTradeStopLimit2(TradeID, (double)通貨ぺア取引状況.買いリミット, false, 0, out リミット変更OrderID);
//        //	}
//        //          else if (売買モード == false)
//        //          {
//        //              if (通貨ぺア取引状況.売りリミット == null)
//        //              {
//        //                  // ここを通ったらバグ
//        //                  throw new Exception("「通貨ぺア取引状況.売りリミット」がnull");
//        //              }

//        //              tradeDesk.ChangeTradeStopLimit2(TradeID, (double)通貨ぺア取引状況.売りリミット, false, 0, out リミット変更OrderID);
//        //	}
//        //          else
//        //          {
//        //              // ここを通ったらバグ
//        //              throw new Exception("「売買モード」がnull");
//        //          }

//        //      }


//        private static void アカウント状態を表示()
//        {
//            FormData.取引証拠金 = 取引証拠金();    //取引証拠金
//            FormData.維持証拠金 = 維持証拠金();    //維持証拠金
//            FormData.ロスカット余剰金 = ロスカット余剰金();  //ロスカット余剰金
//        }


//        private static bool 通貨ペア別Rate取得(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
//        {
//            Rate取得(通貨ぺア取引状況);

//            if (通貨ぺア取引状況.売りRate < 0.00001 || 通貨ぺア取引状況.買いRate < 0.00001)
//            {
//                // FXCMのバグでRateが0以下になり、シグマ計算結果が狂う事件があったので、それはここで回避。
//                BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, "Order対象外(Rate以上)", OrderData.now);
//                return false;
//            }

//            Swap取得(通貨ぺア取引状況);

//            rate.InsertRateHistory(OrderData, 通貨ぺア取引状況);

//            return true;
//        }

//        private static int 通貨ペア数()
//        {
//            return offers.RowCount;
//        }

//        private static string 通貨ペア名(uint 通貨ペアNo)
//        {
//            return (string)offers.CellValue(通貨ペアNo, "Instrument");
//        }

//        private static string QuoteID取得(uint QuoteID表示_iCnt)
//        {
//            return (string)offers.CellValue(QuoteID表示_iCnt, "QuoteID");
//        }

//        #endregion


//    }
//}
