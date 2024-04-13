//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using System.Data.SqlClient;
//using System.Drawing;
//using System.IO;
//using System.Windows.Forms;
//using fxcore2;
//using 定数;
//using 共通Data;
//using Common;
//using DB;


//namespace FXCMv2
//{
//	public static class FXCMv2
//	{
//        #region メンバ変数

//        public static O2GSession mSession = null;
//		//public static FXCore.TradeDeskAut tradeDesk;
//		public static O2GAccountsTable mAccount = null;
//		public static O2GOrdersTable mOrders;
//		public static O2GTradesTable mTrades;
//		public static O2GOffersTable mOffers;
//		public static O2GClosedTradesTable mClosed;
//		public static O2GSummaryTable mSummary;

//		public static string accountId = "";
//		public static int minAmount = 0;
//		public static int AtMarket = 0;											// txtシステム設定_AtMarket.Text

//		public static double 余剰金割合_Order限界点 = 0;						// txt余剰金割合_Order限界点.Text

//        #endregion


//        #region internal

//        #region login logout

//        public static void ログイン_Order開始()
//        {
//            ログイン();
//            アカウント状態を表示();
//            DB記録_Account();
//            //注文共通.先月当月利益更新(cn);

//            Order_Ver5();
//        }

//        public static void ログイン()
//		{
//			try
//			{
//                string URL = "http://www40.fxcorporate.com/Hosts.jsp";

//                mSession = O2GTransport.createSession();
//                mSession.login(FormData.Username, FormData.Password, URL, FormData.DemoReal.ToString());
//                mSession.useTableManager(O2GTableManagerMode.Yes, null);

//                O2GTableManager tableMgr = mSession.getTableManager();
//                mAccount = (O2GAccountsTable)tableMgr.getTable(O2GTableType.Accounts);
//                mOrders = (O2GOrdersTable)tableMgr.getTable(O2GTableType.Orders);
//                mTrades = (O2GTradesTable)tableMgr.getTable(O2GTableType.Trades);
//                mOffers = (O2GOffersTable)tableMgr.getTable(O2GTableType.Offers);
//                mClosed = (O2GClosedTradesTable)tableMgr.getTable(O2GTableType.ClosedTrades);

//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Exception: {0}", ex.ToString());
//            }
//            finally
//            {
//                if (mSession != null)
//                {
//                    mSession.Dispose();
//                }
//            }
//        }

//        public static void ログアウト()
//        {
//            FormData.timer_3min.Enabled = false;

//            Logout();

//            FormData.ログイン表示 = "";
//        }

//        public static void Logout()
//        {
//            if (mSession != null)
//            {
//                mSession.logout();
//                mSession.Dispose();
//                mSession = null;
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
//            //FormData.txt余剰金の割合_Text = 余剰金の割合計算();

//            if (double.IsNaN(FormData.余剰金の割合) == true)
//            {
//                注文共通.取引停止中("取引停止中（IsNaN(余剰金の割合)）");
//                return;
//            }

//            ClosedTrades_余剰金を確保する();

//            Order_Ver5_WMA_BS_順張り();

//            //DB記録_Trade(cn);
//        }

//        private static void Order_Ver5_WMA_BS_順張り()
//        {
//            FormData.OrderData = new OrderData();

//            FormData.OrderData.now = DateTime.Now;
//            注文共通.StartTime_EndTime取得(FormData.OrderData);

//            FormData.OrderData.FXCM_Hour24前 = FormData.OrderData.now.AddHours(-24 + (FX定数.FXOrder2Go時間補正 * -1));

//            foreach (var 通貨ぺア取引状況 in FormData.通貨ぺア別取引状況)
//            {
//                try
//                {
//                    if (通貨ぺア取引状況.FXCM固有 == null)
//                    {
//                        // FX Trading Station の CCY で対象としていないInstrumentはここを通る。
//                        continue;
//                    }

//                    //if (FXCMv1.Chk注文設定_データ生成Chk(通貨ぺア取引状況) == false)
//                    //    continue;

//                    if (通貨ペア別Rate取得(FormData.OrderData, 通貨ぺア取引状況) == false)
//                        continue;

//                    注文共通.WMA計算(通貨ぺア取引状況);

//                    if (FormData.chk15mデータ生成以降の処理をスキップ == true)
//                        continue;

//                    if (注文共通.Chk注文設定_Chk注文(FormData.OrderData, 通貨ぺア取引状況) == false)
//                        continue;

//                    BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, "Order中(通常)", FormData.OrderData.now);

//                    oder.GetWMA_Month1(FormData.OrderData, 通貨ぺア取引状況);
//                    oder.GetWMA_Week1(FormData.OrderData, 通貨ぺア取引状況);
//                    oder.GetWMA_Day1(FormData.OrderData, 通貨ぺア取引状況);
//                    oder.GetWMA_Hour1(FormData.OrderData, 通貨ぺア取引状況);
//                    oder.GetWMA_Min15(FormData.OrderData, 通貨ぺア取引状況);
//                    oder.GetWMA_Min5(FormData.OrderData, 通貨ぺア取引状況);
//                    oder.GetWMA_Min1(FormData.OrderData, 通貨ぺア取引状況);

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

//                //Order_Ver5_注文時の状態記録_状態 = "";
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
//                    ログ.ログ書き出し("Application.Exit FXCM Close.s");
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

//        public static int 現在保有しているポジション数()
//        {
//            return 0;
//            //return trades.RowCount;
//        }

//        public static void ClosedTrades_余剰金を確保する()
//        {
//            if (FormData.chk余剰金確保の自動ポジションCloseはしない == true)
//                return;

//            double 余剰金の割合 = 0;

//            //DateTime Time;
//            //double 差益 = 0;
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
//                    //Time = (DateTime)trades.CellValue(iCnt, "Time");
//                    //差益 = (double)trades.CellValue(iCnt, "GrossPL");
//                    //iAmount = (int)trades.CellValue(iCnt, "Lot");
//                    //dRate = (double)trades.CellValue(iCnt, "Close");
//                    //sTradeID = (string)trades.CellValue(iCnt, "TradeID");
//                    //sQuoteID = (string)trades.CellValue(iCnt, "QuoteID");

//                    //temp.InsertSortCloseTradeTmp(cn, Time, sTradeID, 差益, iAmount, dRate, sQuoteID);
//                }

//                temp.FillBy差益_SortCloseTradeTmp(sTradeID, iAmount, dRate, sQuoteID);

//                // 差益がマイナスなTrade、Top1のみクローズ
//                FormData.TradeApi.ポジションをクローズする(sTradeID, iAmount, dRate, sQuoteID, FormData.システム設定_AtMarket, out CloseOrderID);

//                System.Threading.Thread.Sleep(1000);
//            }

//        }

//        public static void 保持ポジション更新()
//        {
//            foreach (var 通貨ぺア取引状況 in FormData.通貨ぺア別取引状況)
//            {
//                if (FXCMv2.Chk注文設定_データ生成Chk(通貨ぺア取引状況) == false)
//                    continue;

//                //通貨ぺア取引状況.保持ポジション = Get保持ポジション(通貨ぺア取引状況);
//            }
//        }

//        private static void アカウント状態を表示()
//        {
//            O2GAccountTableRow row = mAccount.getRow(0);

//            FormData.取引証拠金 = row.Balance;
//            FormData.維持証拠金 = row.UsedMargin;
//            FormData.ロスカット余剰金 = row.UsedMargin;
//        }


//        private static int 通貨ペア別Rate取得_Cnt = 0;
//        private static O2GOfferRow 通貨ペア別Rate取得_OfferRow = null;
//        private static bool 通貨ペア別Rate取得(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
//        {
//            string QuoteID = "";
//            string OfferID = "";

//            for (通貨ペア別Rate取得_Cnt = 0; 通貨ペア別Rate取得_Cnt < mOffers.Count; 通貨ペア別Rate取得_Cnt++)
//            {
//                通貨ペア別Rate取得_OfferRow = mOffers.getRow(通貨ペア別Rate取得_Cnt);

//                if (FX定数.通貨ペア[通貨ぺア取引状況.通貨ペアNo].Equals(通貨ペア別Rate取得_OfferRow.Instrument) == false)
//                {
//                    continue;
//                }

//                通貨ぺア取引状況.買いRate = 通貨ペア別Rate取得_OfferRow.Bid;
//                通貨ぺア取引状況.売りRate = 通貨ペア別Rate取得_OfferRow.Ask;
//                通貨ぺア取引状況.買いSwap = 通貨ペア別Rate取得_OfferRow.BuyInterest;
//                通貨ぺア取引状況.売りSwap = 通貨ペア別Rate取得_OfferRow.SellInterest;
//                OfferID = 通貨ペア別Rate取得_OfferRow.OfferID;
//                QuoteID = 通貨ペア別Rate取得_OfferRow.QuoteID;

//                return true;
//            }

//            return false;
//        }


//        // 注文を出す
//        public static void CreateMarketOrder(string sOfferID, string sAccountID, int iAmount, double dRate, string sBuySell)
//        {
//            O2GRequestFactory factory = mSession.getRequestFactory();
//            if (factory != null)
//            {
//                O2GValueMap valuemap = factory.createValueMap();
//                valuemap.setString(O2GRequestParamsEnum.Command, Constants.Commands.CreateOrder);
//                valuemap.setString(O2GRequestParamsEnum.OrderType, Constants.Orders.MarketOpen);
//                valuemap.setString(O2GRequestParamsEnum.AccountID, sAccountID);                // The identifier of the account the order should be placed for.
//                valuemap.setString(O2GRequestParamsEnum.OfferID, sOfferID);                    // The identifier of the instrument the order should be placed for.
//                valuemap.setString(O2GRequestParamsEnum.BuySell, sBuySell);                    // The order direction (use Constants.Buy for Buy, Constants.Sell for Sell)
//                valuemap.setDouble(O2GRequestParamsEnum.Rate, dRate);                          // The dRate at which the order must be filled.
//                valuemap.setInt(O2GRequestParamsEnum.Amount, iAmount);                         // The quantity of the instrument to be bought or sold.
//                valuemap.setString(O2GRequestParamsEnum.CustomID, "OpenMarketOrder");         // The custom identifier of the order.

//                O2GRequest request = factory.createOrderRequest(valuemap);
//                if (request == null)
//                    Console.WriteLine("Order's request can not be created: " + factory.getLastError());
//                else
//                    mSession.sendRequest(request);
//            }
//        }
        
//        // 注文をクローズする
//        public static void CreateMarketCloseOrder(string sOfferID, string sAccountID, string sTradeID, int iAmount, double dRate, string sBuySell)
//        {
//            O2GRequestFactory factory = mSession.getRequestFactory();
//            if (factory != null)
//            {
//                O2GValueMap valuemap = factory.createValueMap();
//                valuemap.setString(O2GRequestParamsEnum.Command, Constants.Commands.CreateOrder);
//                valuemap.setString(O2GRequestParamsEnum.OrderType, Constants.Orders.MarketClose);
//                valuemap.setString(O2GRequestParamsEnum.AccountID, sAccountID);                // The identifier of the account the order should be placed for.
//                valuemap.setString(O2GRequestParamsEnum.OfferID, sOfferID);                    // The identifier of the instrument the order should be placed for.
//                valuemap.setString(O2GRequestParamsEnum.TradeID, sTradeID);                    // The identifier of the trade to be closed.
//                valuemap.setString(O2GRequestParamsEnum.BuySell, sBuySell);                    // The order direction (Constants.Buy - for Buy, Constants.Sell - for Sell). Must be opposite to the direction of the trade.
//                valuemap.setInt(O2GRequestParamsEnum.Amount, iAmount);                         // The quantity of the instrument to be bought or sold.  Must <= to the size of the position (Lot column of the trade).
//                valuemap.setDouble(O2GRequestParamsEnum.Rate, dRate);                          // The dRate at which the order must be filled.
//                valuemap.setString(O2GRequestParamsEnum.CustomID, "CloseMarketOrder");        // The custom identifier of the order.
//                O2GRequest request = factory.createOrderRequest(valuemap);
//                if (request == null)
//                    Console.WriteLine("Order's request can not be created: " + factory.getLastError());
//                else
//                    mSession.sendRequest(request);
//            }
//        }

//		public static void Getアカウント状態(out double 取引証拠金, out double 有効証拠金, out double 維持証拠金, out double ロスカット余剰金)
//        {
//			O2GAccountTableRow row = mAccount.getRow(0);

//			取引証拠金 = row.Balance;
//			有効証拠金 = row.M2MEquity;
//			維持証拠金 = row.UsedMargin;
//			ロスカット余剰金 = row.UsedMargin;
//		}

//        public static void DB記録_Account()
//        {
//            O2GAccountTableRow row = mAccount.getRow(0);

//            fxcm.InsertAccounts(
//                FormData.口座No,
//                DateTime.Now,
//                row.AccountID,
//                row.AccountName,
//                row.Balance,
//                row.Equity,
//                row.DayPL,
//                row.NonTradeEquity,
//                row.M2MEquity,
//                row.UsedMargin,
//                row.UsableMargin,
//                row.GrossPL,
//                row.AccountKind,
//                row.MarginCallFlag,
//                "",
//                "",
//                row.AmountLimit,
//                row.BaseUnitSize);
//        }

//        //private static string DB記録_Trades_TradeID;
//        //private static int DB記録_Trades_iCnt;
//        //private static int DB記録_Trades_iTradeCnt;
//        //private static byte DB記録_Trades_IsBuy;
//        //private static string DB記録_Trades_OpenOrderID;
//		public static void DB記録_Trades()
//		{
//			//for (DB記録_Trades_iCnt = 0; DB記録_Trades_iCnt < mTrades.Count; DB記録_Trades_iCnt++)
//			//{
//			//	O2GTradeTableRow row = mTrades.getRow(DB記録_Trades_iCnt);

//			//	DB記録_Trades_TradeID = row.TradeID;
//			//	DB記録_Trades_iTradeCnt = trad.RecCnt(cn, DB記録_Trades_TradeID);

//			//	if (DB記録_Trades_iTradeCnt > 0)
//			//		continue;

//			//	trad.InsertTrade(cn, row.TradeID, row.AccountID, row.AccountName, row.AccountKind, row.OfferID, row.Amount, row.BuySell,
//			//		row.OpenRate, row.OpenTime, row.OpenQuoteID, row.OpenOrderID, row.OpenOrderReqID, row.OpenOrderRequestTXT,
//			//		row.Commission, row.RolloverInterest, row.TradeIDOrigin, row.UsedMargin, row.ValueDate, row.Parties, row.Close,
//			//		row.GrossPL, row.Limit, row.PL, row.Stop);

//			//	oder.UpdateOrderHistory_TradeID(cn, DB記録_Trades_OpenOrderID);
//			//}
//		}


//        private static string DB記録_ClosedTrades_TradeID;
//        private static int DB記録_ClosedTrades_iCnt;
//        private static void DB記録_ClosedTrade()
//        {
//            for (DB記録_ClosedTrades_iCnt = 1; DB記録_ClosedTrades_iCnt <= mClosed.Count; DB記録_ClosedTrades_iCnt++)
//            {
//                var row = mClosed.getRow(DB記録_ClosedTrades_iCnt);

//                DB記録_ClosedTrades_TradeID = row.TradeID;

//                if (fxcm.SelectCnt_TradeID(DB記録_ClosedTrades_TradeID) > 0)
//                    continue;

//                fxcm.InsertClosedTrades(
//                    DB記録_ClosedTrades_TradeID,
//                    row.AccountID,
//                    row.AccountName,
//                    row.OfferID,
//                    row.Instrument,
//                    0,  // row.Lot
//                    row.Amount,
//                    row.BuySell,
//                    row.OpenRate,
//                    row.CloseRate,
//                    row.PL,
//                    row.GrossPL,
//                    row.Commission,
//                    0, // row.Int
//                    row.OpenTime.AddHours(FX定数.FXOrder2Go時間補正),
//                    row.CloseTime.AddHours(FX定数.FXOrder2Go時間補正),
//                    row.AccountKind,
//                    row.OpenOrderID,
//                    "",
//                    row.CloseOrderID,
//                    "",
//                    "", //row.OQTXT
//                    "", //row.CQTXT
//                    "",
//                    "");

//            }
//        }


//		private static double ポジション追加_成行_dblEntryRate;
//		private static double ポジション追加_成行_EntryLimit;
//		//private static object ポジション追加_成行_di;
//		public static void ポジション追加_成行(string 売買モード, string 通貨ペア, double 買いRate, double 売りRate, int 取引単位, double リミット,
//			string quoteId, out object OrderId)
//		{
//            if (売買モード == "B")
//			{
//				ポジション追加_成行_dblEntryRate = 買いRate;
//				ポジション追加_成行_EntryLimit = ポジション追加_成行_dblEntryRate + リミット;
//			}
//            else if (売買モード == "S")
//            {
//                ポジション追加_成行_dblEntryRate = 売りRate;
//				ポジション追加_成行_EntryLimit = ポジション追加_成行_dblEntryRate - リミット;
//			}
//            else
//            {
//                // ここを通ったらバグ
//                throw new Exception("「売買モード」がnull");
//            }

//            O2GRequestFactory factory = mSession.getRequestFactory();

//			O2GValueMap valuemap = factory.createValueMap();
//			valuemap.setString(O2GRequestParamsEnum.Command, Constants.Commands.CreateOrder);
//			valuemap.setString(O2GRequestParamsEnum.OrderType, Constants.Orders.MarketOpen);
//			valuemap.setString(O2GRequestParamsEnum.AccountID, accountId);                // The identifier of the account the order should be placed for.
//			valuemap.setString(O2GRequestParamsEnum.OfferID, 通貨ペア);                    // The identifier of the instrument the order should be placed for.
//			valuemap.setString(O2GRequestParamsEnum.BuySell, 売買モード);                    // The order direction (use Constants.Buy for Buy, Constants.Sell for Sell)
//			valuemap.setDouble(O2GRequestParamsEnum.Rate, ポジション追加_成行_dblEntryRate);                          // The dRate at which the order must be filled.
//			valuemap.setInt(O2GRequestParamsEnum.Amount, minAmount);                         // The quantity of the instrument to be bought or sold.
//			valuemap.setString(O2GRequestParamsEnum.CustomID, "OpenMarketOrder");         // The custom identifier of the order.

//			//成り行き
//			O2GRequest request = factory.createOrderRequest(valuemap);

//			mSession.sendRequest(request);

//			OrderId = request.RequestID;
//		}

//        #endregion
//    }
//}
