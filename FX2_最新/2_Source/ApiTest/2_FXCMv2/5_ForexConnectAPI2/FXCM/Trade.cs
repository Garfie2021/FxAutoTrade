using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using fxcore2;
using Common;
using DB;

namespace FXCM
{
    public static class Trade
    {
		// Rate取得用口座
		public static O2GSession mSession_Rate;
		//public static FXCore.TradeDeskAut tradeDesk;
		public static O2GOffersTable mOffers_Rate;

		// 注文用 ※当面はDemoのみ、徐々にReal口座を増やしていく
		public static O2GSession mSession_Order_DemoA;
		//public static FXCore.TradeDeskAut tradeDesk;
		public static O2GAccountsTable mAccount_Order_DemoA;
		public static O2GOrdersTable mOrders_Order_DemoA;
		public static O2GTradesTable mTrades_Order_DemoA;
		public static O2GOffersTable mOffers_Order_DemoA;
		public static O2GClosedTradesTable mClosed_Order_DemoA;
		public static O2GSummaryTable mSummary_Order_DemoA;

        public static string accountId = "";
        public static int mAmount = 1;

		public static double 余剰金割合_Order限界点 = 0;						// txt余剰金割合_Order限界点.Text

		public static void Login()
		{
			try
			{

				string Connection;
				string Login;
				string Password;

				string URL = "http://www40.fxcorporate.com/Hosts.jsp";

				Connection = "Real";

				Login = "1111";
				Password = "1111";
				mSession_Rate = O2GTransport.createSession();
				mSession_Rate.login(Login, Password, URL, Connection);
				mSession_Rate.useTableManager(O2GTableManagerMode.Yes, null);
				O2GTableManager tableMgr = mSession_Rate.getTableManager();
				mOffers_Rate = (O2GOffersTable)tableMgr.getTable(O2GTableType.Offers);

				Connection = "Demo";

				Login = "1111";
				Password = "1111";
				mSession_Order_DemoA = O2GTransport.createSession();
				mSession_Order_DemoA.login(Login, Password, URL, Connection);
				mSession_Order_DemoA.useTableManager(O2GTableManagerMode.Yes, null);
				tableMgr = mSession_Order_DemoA.getTableManager();
				mAccount_Order_DemoA = (O2GAccountsTable)tableMgr.getTable(O2GTableType.Accounts);
				mOrders_Order_DemoA = (O2GOrdersTable)tableMgr.getTable(O2GTableType.Orders);
				mTrades_Order_DemoA = (O2GTradesTable)tableMgr.getTable(O2GTableType.Trades);
				mClosed_Order_DemoA = (O2GClosedTradesTable)tableMgr.getTable(O2GTableType.ClosedTrades);
				mSummary_Order_DemoA = (O2GSummaryTable)tableMgr.getTable(O2GTableType.Summary);

			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception: {0}", ex.ToString());
			}
			finally
			{
				if (mSession_Rate != null)
				{
					mSession_Rate.Dispose();
				}

				if (mSession_Order_DemoA != null)
				{
					mSession_Order_DemoA.Dispose();
				}
			}
		}

        public static void Logout()
        {
			if (mSession_Rate != null)
			{
				mSession_Rate.logout();
				mSession_Rate = null;
			}

			if (mSession_Order_DemoA != null)
			{
				mSession_Order_DemoA.logout();
				mSession_Order_DemoA = null;
			}
		}

		/*
		private static int 通貨ペア別Rate取得_Cnt = 0;
		private static O2GOfferRow 通貨ペア別Rate取得_OfferRow = null;
		public static void 通貨ペア別Rate取得(byte 通貨ペアNo, out double 買いRate, out double 売りRate, out string QuoteID, out string OfferID)
		{
			買いRate = 0;
			売りRate = 0;
			QuoteID = "";
			OfferID = "";

			for (通貨ペア別Rate取得_Cnt = 0; 通貨ペア別Rate取得_Cnt < mOffers_Rate.Count; 通貨ペア別Rate取得_Cnt++)
			{
				通貨ペア別Rate取得_OfferRow = mOffers_Rate.getRow(通貨ペア別Rate取得_Cnt);

				if (FXCMConst.通貨ペア[通貨ペアNo].Equals(通貨ペア別Rate取得_OfferRow.Instrument) == false)
				{
					continue;
				}

				買いRate = 通貨ペア別Rate取得_OfferRow.Ask;
				売りRate = 通貨ペア別Rate取得_OfferRow.Bid;
				OfferID = 通貨ペア別Rate取得_OfferRow.OfferID;
				QuoteID = 通貨ペア別Rate取得_OfferRow.QuoteID;

				return;
			}
		}


		// 注文を出す
		public static void CreateMarketOrder(string sAccountID, string sOfferID, double dRate, string sBuySell)
		{
			O2GRequestFactory factory = mSession_Order_DemoA.getRequestFactory();

			O2GValueMap valuemap = factory.createValueMap();
			valuemap.setString(O2GRequestParamsEnum.Command, Constants.Commands.CreateOrder);
			valuemap.setString(O2GRequestParamsEnum.OrderType, Constants.Orders.MarketOpen);
			valuemap.setString(O2GRequestParamsEnum.AccountID, sAccountID);                // The identifier of the account the order should be placed for.
			valuemap.setString(O2GRequestParamsEnum.OfferID, sOfferID);                    // The identifier of the instrument the order should be placed for.
			valuemap.setString(O2GRequestParamsEnum.BuySell, sBuySell);                    // The order direction (use Constants.Buy for Buy, Constants.Sell for Sell)
			valuemap.setDouble(O2GRequestParamsEnum.Rate, dRate);                          // The dRate at which the order must be filled.
			valuemap.setInt(O2GRequestParamsEnum.Amount, mAmount);                         // The quantity of the instrument to be bought or sold.
			valuemap.setString(O2GRequestParamsEnum.CustomID, "OpenMarketOrder");         // The custom identifier of the order.

			O2GRequest request = factory.createOrderRequest(valuemap);

			if (request == null)
			{
				throw new Exception(factory.getLastError());
			}
			else
			{
				mSession_Order_DemoA.sendRequest(request);
			}
		}


		// 注文をクローズする
		public static void ポジションをクローズする(string sOfferID, string sAccountID, string sTradeID, int iAmount, double dRate, string sBuySell)
		{
			O2GRequestFactory factory = mSession_Order_DemoA.getRequestFactory();
			if (factory != null)
			{
				O2GValueMap valuemap = factory.createValueMap();
				valuemap.setString(O2GRequestParamsEnum.Command, Constants.Commands.CreateOrder);
				valuemap.setString(O2GRequestParamsEnum.OrderType, Constants.Orders.MarketClose);
				valuemap.setString(O2GRequestParamsEnum.AccountID, sAccountID);                // The identifier of the account the order should be placed for.
				valuemap.setString(O2GRequestParamsEnum.OfferID, sOfferID);                    // The identifier of the instrument the order should be placed for.
				valuemap.setString(O2GRequestParamsEnum.TradeID, sTradeID);                    // The identifier of the trade to be closed.
				valuemap.setString(O2GRequestParamsEnum.BuySell, sBuySell);                    // The order direction (Constants.Buy - for Buy, Constants.Sell - for Sell). Must be opposite to the direction of the trade.
				valuemap.setInt(O2GRequestParamsEnum.Amount, iAmount);                         // The quantity of the instrument to be bought or sold.  Must <= to the size of the position (Lot column of the trade).
				valuemap.setDouble(O2GRequestParamsEnum.Rate, dRate);                          // The dRate at which the order must be filled.
				valuemap.setString(O2GRequestParamsEnum.CustomID, "CloseMarketOrder");        // The custom identifier of the order.
				O2GRequest request = factory.createOrderRequest(valuemap);

				if (request == null)
				{
					throw new Exception(factory.getLastError());
				}
				else
				{
					mSession_Order_DemoA.sendRequest(request);
				}
			}
		}

		public static void Getアカウント状態(out double 取引証拠金, out double 有効証拠金, out double 維持証拠金, out double ロスカット余剰金)
		{
			O2GAccountTableRow row = Trade.mAccount_Order_DemoA.getRow(0);

			取引証拠金 = row.Balance;
			有効証拠金 = row.M2MEquity;
			維持証拠金 = row.UsedMargin;
			ロスカット余剰金 = row.UsedMargin;
		}
		 * 
		*/


		/*
		private static string DB記録_Trades_TradeID;
		private static int DB記録_Trades_iCnt;
		private static int DB記録_Trades_iTradeCnt;
		private static byte DB記録_Trades_IsBuy;
		private static string DB記録_Trades_OpenOrderID;
		public static void DB記録_Trades(SqlConnection cn)
		{
			for (DB記録_Trades_iCnt = 0; DB記録_Trades_iCnt < Trade.mTrades_Order_DemoA.Count; DB記録_Trades_iCnt++)
			{
				O2GTradeTableRow row = Trade.mTrades_Order_DemoA.getRow(DB記録_Trades_iCnt);

				DB記録_Trades_TradeID = row.TradeID;
				DB記録_Trades_iTradeCnt = oder.RecCnt(cn, DB記録_Trades_TradeID);

				if (DB記録_Trades_iTradeCnt > 0)
					continue;

				oder.InsertTrade(cn, row.TradeID, row.AccountID, row.AccountName, row.AccountKind, row.OfferID, row.Amount, row.BuySell,
					row.OpenRate, row.OpenTime, row.OpenQuoteID, row.OpenOrderID, row.OpenOrderReqID, row.OpenOrderRequestTXT,
					row.Commission, row.RolloverInterest, row.TradeIDOrigin, row.UsedMargin, row.ValueDate, row.Parties, row.Close,
					row.GrossPL, row.Limit, row.PL, row.Stop);

				oder.UpdateOrderHistory_TradeID(cn, DB記録_Trades_OpenOrderID);
			}
		}
		*/

		/*
		private static int DB記録_ClosedTrades_iCnt;
		public static void DB記録_ClosedTrades(SqlConnection cn)
		{
			for (DB記録_ClosedTrades_iCnt = 0; DB記録_ClosedTrades_iCnt < Trade.mClosed_Order_DemoA.Count; DB記録_ClosedTrades_iCnt++)
			{
				O2GClosedTradeTableRow row = Trade.mClosed_Order_DemoA.getRow(DB記録_ClosedTrades_iCnt);

				int iCnt = oder.RecCnt(cn, row.TradeID);
				if (iCnt > 0)
				{
					// 既に登録済み
					continue;
				}

				oder.InsertTrade(cn, row.TradeID, row.AccountID, row.AccountName, row.AccountKind, row.OfferID, row.Amount, row.BuySell,
					row.OpenRate, row.OpenTime, row.OpenQuoteID, row.OpenOrderID, row.OpenOrderReqID, row.OpenOrderRequestTXT,
					row.Commission, row.RolloverInterest, row.TradeIDOrigin, row.ValueDate, row.GrossPL);

				oder.UpdateOrderHistory_TradeID(cn, DB記録_ClosedTrades_OpenOrderID);
			}
		}
		*/

		/*
		public static void ポジション更新( bool bBuyShellMode, string 通貨ペア, string str取引単位, string str取引間隔, string strリミット,
			string str高値限界Rate, string str下値限界Rate, string strLogFolder)
		{
			//string accountId = (string)accounts.CellValue(1, "AccountID");

			int minAmount = (int)accounts.CellValue(1, "BaseUnitSize");
			int Amount = minAmount * int.Parse(str取引単位);
			double dbl取引間隔 = double.Parse(str取引間隔);
			double dblリミット = double.Parse(strリミット);
			double dbl高値限界Rate = double.Parse(str高値限界Rate);

			uint iCnt = 1;
			for (double dblEntryRate = double.Parse(str下値限界Rate); dblEntryRate < dbl高値限界Rate; dblEntryRate += dbl取引間隔)
			{
				double EntryLimit = 0;
				if (bBuyShellMode == true)
					EntryLimit = dblEntryRate + dblリミット;
				else
					EntryLimit = dblEntryRate - dblリミット;

				//既に注文状況にEntoryが無いかチェック
				//double Limit = 0;
				double OpenRate = 0;
				double TopRangeRate = 0;
				double BottomRangeRate = 0;
				bool b既にEntory有り = false;
				for (iCnt = 1; iCnt <= orders.RowCount; iCnt++)
				{
					if ((string)orders.CellValue(iCnt, "Instrument") != 通貨ペア)
						continue;

					OpenRate = (double)orders.CellValue(iCnt, "Rate");
					//TopRangeRate = OpenRate + (dbl取引間隔 / 2);
					//BottomRangeRate = OpenRate - (dbl取引間隔 / 2);
					TopRangeRate = OpenRate + dbl取引間隔;
					BottomRangeRate = OpenRate - dbl取引間隔;

					if (BottomRangeRate < dblEntryRate && dblEntryRate < TopRangeRate)
					{
						b既にEntory有り = true;
						break;
					}
				}

				if (b既にEntory有り == true)
					continue;

				//既にポジションにEntoryが無いかチェック
				for (iCnt = 1; iCnt <= trades.RowCount; iCnt++)
				{
					if ((string)trades.CellValue(iCnt, "Instrument") != 通貨ペア)
						continue;

					OpenRate = (double)trades.CellValue(iCnt, "Open");
					//TopRangeRate = OpenRate + (dbl取引間隔 / 2);
					//BottomRangeRate = OpenRate - (dbl取引間隔 / 2);
					TopRangeRate = OpenRate + dbl取引間隔;
					BottomRangeRate = OpenRate - dbl取引間隔;

					if (BottomRangeRate < dblEntryRate && dblEntryRate < TopRangeRate)
					{
						b既にEntory有り = true;
						break;
					}
				}

				////既に逆ポジションにEntoryが無いかチェック
				//b既にEntory有り = Chk逆ポジション(trades, 通貨ペア, bBuyShellMode);

				if (b既にEntory有り == true)
					continue;

				//指値取引を登録
				object orderId, di;
				tradeDesk.CreateEntryOrder2(accountId, 通貨ペア, bBuyShellMode, Amount, dblEntryRate, tradeDesk.SL_LIMIT, 0, EntryLimit, 0, out orderId, out di);

				//DateTime now = DateTime.Now;
				//File.AppendAllText(strLogFolder + @"\" + now.ToString("yyyyMMdd") + "_sts.log", ",", Encoding.GetEncoding("Shift_JIS"));
			}
		}
		private static double ポジション更新_成行_dblEntryRate;
		private static double ポジション更新_成行_EntryLimit;
		private static object ポジション更新_成行_di;
		*/

		/*
		private static double ChkOrder間隔内にポジションがあるか_dblEntryRate;
		private static double ChkOrder間隔内にポジションがあるか_OrderRate;
		private static double ChkOrder間隔内にポジションがあるか_TopRate;
		private static double ChkOrder間隔内にポジションがあるか_BottomRate;
		private static uint ChkOrder間隔内にポジションがあるか_Cnt;
		public static bool ChkOrder間隔内にポジションがあるか(bool 売買モード, string 通貨ペア, double 買いRate, double 売りRate, double Order間隔)
		{
			if (売買モード == true)
			{
				ChkOrder間隔内にポジションがあるか_dblEntryRate = 買いRate;
			}
			else
			{
				ChkOrder間隔内にポジションがあるか_dblEntryRate = 売りRate;
			}

			//既にポジションにEntoryが無いかチェック
			for (ChkOrder間隔内にポジションがあるか_Cnt = 1; ChkOrder間隔内にポジションがあるか_Cnt <= trades.RowCount; ChkOrder間隔内にポジションがあるか_Cnt++)
			{
				if ((string)trades.CellValue(ChkOrder間隔内にポジションがあるか_Cnt, "Instrument") != 通貨ペア)
					continue;

				ChkOrder間隔内にポジションがあるか_OrderRate = (double)trades.CellValue(ChkOrder間隔内にポジションがあるか_Cnt, "Open");
				ChkOrder間隔内にポジションがあるか_TopRate = ChkOrder間隔内にポジションがあるか_OrderRate + Order間隔;
				ChkOrder間隔内にポジションがあるか_BottomRate = ChkOrder間隔内にポジションがあるか_OrderRate - Order間隔;

				if (ChkOrder間隔内にポジションがあるか_BottomRate < ChkOrder間隔内にポジションがあるか_dblEntryRate &&
					ChkOrder間隔内にポジションがあるか_dblEntryRate < ChkOrder間隔内にポジションがあるか_TopRate)
				{
					return true;
				}
			}

			return false;
		}
		*/

		/*
		private static double リミット変更_dblEntryRate;
		private static double リミット変更_EntryLimit;
		public static void リミット変更(string TradeID, bool 売買モード, double 買いRate, double 売りRate, double リミット,
			out object リミット変更OrderID)
		{
			if (売買モード == true)
			{
				リミット変更_dblEntryRate = 買いRate;
				リミット変更_EntryLimit = リミット変更_dblEntryRate + リミット;
			}
			else
			{
				リミット変更_dblEntryRate = 売りRate;
				リミット変更_EntryLimit = リミット変更_dblEntryRate - リミット;
			}

			tradeDesk.ChangeTradeStopLimit2(TradeID, リミット変更_EntryLimit, false, 0, out リミット変更OrderID);
		}
		*/

		/*
		public static void 注文を全て削除する(ref int 注文Entry数)
		{
			FXCore.TableAut accounts = (FXCore.TableAut)tradeDesk.FindMainTable("accounts");
			//string accountId = (string)accounts.CellValue(1, "AccountID");
			//int minAmount = (int)accounts.CellValue(1, "BaseUnitSize");

			int iRowCount = orders.RowCount;
			string OrderID = "";

			while (orders.RowCount != 0)
			{
				OrderID = (string)orders.CellValue(1, "OrderID");
				tradeDesk.DeleteOrder(OrderID);
			}

			//DateTime now = DateTime.Now;
			//File.AppendAllText(strLogFolder + @"\" + now.ToString("yyyyMMdd") + "_sts.log", ",", Encoding.GetEncoding("Shift_JIS"));

			注文Entry数 = orders.RowCount;
		}
		*/

		/*
		public static bool Chkポジション有り(string 通貨ペア)
		{
			for (uint iCnt = 1; iCnt <= trades.RowCount; iCnt++)
			{
				if ((string)trades.CellValue(iCnt, "Instrument") != 通貨ペア)
					continue;

				return true;
			}

			return false;
		}
		*/

		/*
		public static uint Chk逆ポジション_iCnt;
		public static bool Chk逆ポジション(string 通貨ペア, bool bBuyShellMode)
		{
			for (Chk逆ポジション_iCnt = 1; Chk逆ポジション_iCnt <= trades.RowCount; Chk逆ポジション_iCnt++)
			{
				if ((string)trades.CellValue(Chk逆ポジション_iCnt, "Instrument") != 通貨ペア)
					continue;

				if ((string)trades.CellValue(Chk逆ポジション_iCnt, "BS") == "B")
				{
					//買いのポジションがあったら、売りを出さない。
					if (bBuyShellMode == false)
					{
						return true;
					}
				}
				else if ((string)trades.CellValue(Chk逆ポジション_iCnt, "BS") == "S")
				{
					//売りのポジションがあったら、買いを出さない。
					if (bBuyShellMode == true)
					{
						return true;
					}
				}
			}

			return false;
		}
		 */

		/*
		public static void 通貨ペア別に注文を削除する(string 通貨ペア, ref int 注文Entry数)
		{
			FXCore.TableAut accounts = (FXCore.TableAut)tradeDesk.FindMainTable("accounts");
			//string accountId = (string)accounts.CellValue(1, "AccountID");
			//int minAmount = (int)accounts.CellValue(1, "BaseUnitSize");

			int iRowCount = orders.RowCount;
			string OrderID = "";
			string Instrument = "";

			while (orders.RowCount != 0)
			{
				Instrument = (string)orders.CellValue(1, "Instrument");

				if (通貨ペア != Instrument)
					continue;

				OrderID = (string)orders.CellValue(1, "OrderID");
				tradeDesk.DeleteOrder(OrderID);
			}

			//DateTime now = DateTime.Now;
			//File.AppendAllText(strLogFolder + @"\" + now.ToString("yyyyMMdd") + "_sts.log", ",", Encoding.GetEncoding("Shift_JIS"));

			注文Entry数 = orders.RowCount;
		}
		 */

		/*
		private static int Getポジション数_ポジション数;
		private static uint Getポジション数_Cnt;
		public static int Getポジション数(byte 通貨ペアNo)
		{
			Getポジション数_ポジション数 = 0;
			for (Getポジション数_Cnt = 1; Getポジション数_Cnt <= Trade.trades.RowCount; Getポジション数_Cnt++)
			{
				if ((string)Trade.trades.CellValue(Getポジション数_Cnt, "Instrument") != FXCMConst.通貨ペア[通貨ペアNo])
					continue;
				else
					Getポジション数_ポジション数++;
			}

			return Getポジション数_ポジション数;
		}

		public static bool Chk直近n秒以内にCloseされたポジション有り(string 通貨ペア名, int 時間補正, DateTime n秒前)
		{
			for (uint Cnt = 1; Cnt <= closed.RowCount; Cnt++)
			{
				if (((DateTime)closed.CellValue(Cnt, "CloseTime")).AddHours(時間補正) < n秒前)
					continue;

				if ((string)closed.CellValue(Cnt, "Instrument") == 通貨ペア名)
					return true;
			}

			return false;
		}
		 */

		////private static double 通貨ペア別Rate更新用_買いRate = 0;
		////private static double 通貨ペア別Rate更新用_売りRate = 0;
		////private static double 通貨ペア別Rate更新用_買いSwap = 0;
		////private static double 通貨ペア別Rate更新用_売りSwap = 0;
		////private static string 通貨ペア別Rate更新用_QuoteID = "";
		////private static uint 通貨ペア別Rate更新用_Cnt = 0;
		////public static void 通貨ペア別Rate取得(byte 通貨ペアNo, out double RateB, out double RateS)
		////{
		////	RateB = 0;
		////	RateS = 0;

		////	for (通貨ペア別Rate更新用_Cnt = 0; 通貨ペア別Rate更新用_Cnt < mOffers.Count; 通貨ペア別Rate更新用_Cnt++)
		////	{
		////		O2GOfferTableRow row = mOffers.getRow(通貨ペア別Rate更新用_Cnt);

		////		if (通貨ペア[通貨ペアNo] != row.Instrument)
		////		{
		////			continue;
		////		}

		////		RateB = row.Ask;
		////		RateS = row.Bid;
		////		return;
		////	}
		////}

		//// 注文を出す
		//public static void CreateMarketOrder(string sOfferID, string sAccountID, int iAmount, double dRate, string sBuySell)
		//{
		//	O2GRequestFactory factory = mSession.getRequestFactory();
		//	if (factory != null)
		//	{
		//		O2GValueMap valuemap = factory.createValueMap();
		//		valuemap.setString(O2GRequestParamsEnum.Command, Constants.Commands.CreateOrder);
		//		valuemap.setString(O2GRequestParamsEnum.OrderType, Constants.Orders.MarketOpen);
		//		valuemap.setString(O2GRequestParamsEnum.AccountID, sAccountID);                // The identifier of the account the order should be placed for.
		//		valuemap.setString(O2GRequestParamsEnum.OfferID, sOfferID);                    // The identifier of the instrument the order should be placed for.
		//		valuemap.setString(O2GRequestParamsEnum.BuySell, sBuySell);                    // The order direction (use Constants.Buy for Buy, Constants.Sell for Sell)
		//		valuemap.setDouble(O2GRequestParamsEnum.Rate, dRate);                          // The dRate at which the order must be filled.
		//		valuemap.setInt(O2GRequestParamsEnum.Amount, iAmount);                         // The quantity of the instrument to be bought or sold.
		//		valuemap.setString(O2GRequestParamsEnum.CustomID, "OpenMarketOrder");         // The custom identifier of the order.

		//		O2GRequest request = factory.createOrderRequest(valuemap);
		//		if (request == null)
		//			Console.WriteLine("Order's request can not be created: " + factory.getLastError());
		//		else
		//			mSession.sendRequest(request);
		//	}
		//}
        
		//// 注文をクローズする
		//public static void CreateMarketCloseOrder(string sOfferID, string sAccountID, string sTradeID, int iAmount, double dRate, string sBuySell)
		//{
		//	O2GRequestFactory factory = mSession.getRequestFactory();
		//	if (factory != null)
		//	{
		//		O2GValueMap valuemap = factory.createValueMap();
		//		valuemap.setString(O2GRequestParamsEnum.Command, Constants.Commands.CreateOrder);
		//		valuemap.setString(O2GRequestParamsEnum.OrderType, Constants.Orders.MarketClose);
		//		valuemap.setString(O2GRequestParamsEnum.AccountID, sAccountID);                // The identifier of the account the order should be placed for.
		//		valuemap.setString(O2GRequestParamsEnum.OfferID, sOfferID);                    // The identifier of the instrument the order should be placed for.
		//		valuemap.setString(O2GRequestParamsEnum.TradeID, sTradeID);                    // The identifier of the trade to be closed.
		//		valuemap.setString(O2GRequestParamsEnum.BuySell, sBuySell);                    // The order direction (Constants.Buy - for Buy, Constants.Sell - for Sell). Must be opposite to the direction of the trade.
		//		valuemap.setInt(O2GRequestParamsEnum.Amount, iAmount);                         // The quantity of the instrument to be bought or sold.  Must <= to the size of the position (Lot column of the trade).
		//		valuemap.setDouble(O2GRequestParamsEnum.Rate, dRate);                          // The dRate at which the order must be filled.
		//		valuemap.setString(O2GRequestParamsEnum.CustomID, "CloseMarketOrder");        // The custom identifier of the order.
		//		O2GRequest request = factory.createOrderRequest(valuemap);
		//		if (request == null)
		//			Console.WriteLine("Order's request can not be created: " + factory.getLastError());
		//		else
		//			mSession.sendRequest(request);
		//	}
		//}



	}
}
