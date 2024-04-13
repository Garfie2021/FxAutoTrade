using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fxcore2;
using DB;
using System.Data.SqlClient;

namespace FXCM
{
    public static class Trade
    {
        public static O2GSession mSession = null;
		//public static FXCore.TradeDeskAut tradeDesk;
		public static O2GAccountsTable mAccount = null;
		public static O2GOrdersTable mOrders;
		public static O2GTradesTable  mTrades;
		public static O2GOffersTable mOffers;
		public static O2GClosedTradesTable mClosed;
		public static O2GSummaryTable mSummary;
        
        public static string[] 通貨ペア;
        public static string accountId = "";
        public static int minAmount = 0;
		public static int AtMarket = 0;											// txtシステム設定_AtMarket.Text

		public static double 余剰金割合_Order限界点 = 0;						// txt余剰金割合_Order限界点.Text

		/// <summary>
		/// staticコンストラクタ
		/// </summary>
		static Trade()
        {
            通貨ペア = new string[Const.通貨ペア数];
            通貨ペア[Const.DGVRowNo_AUD_CAD] = Const.AUD_CAD;
            通貨ペア[Const.DGVRowNo_AUD_CHF] = Const.AUD_CHF;
            通貨ペア[Const.DGVRowNo_AUD_JPY] = Const.AUD_JPY;
            通貨ペア[Const.DGVRowNo_AUD_NZD] = Const.AUD_NZD;
            通貨ペア[Const.DGVRowNo_AUD_USD] = Const.AUD_USD;
            通貨ペア[Const.DGVRowNo_CAD_CHF] = Const.CAD_CHF;
            通貨ペア[Const.DGVRowNo_CAD_JPY] = Const.CAD_JPY;
            通貨ペア[Const.DGVRowNo_CHF_JPY] = Const.CHF_JPY;
            通貨ペア[Const.DGVRowNo_EUR_AUD] = Const.EUR_AUD;
            通貨ペア[Const.DGVRowNo_EUR_CAD] = Const.EUR_CAD;
            通貨ペア[Const.DGVRowNo_EUR_CHF] = Const.EUR_CHF;
            通貨ペア[Const.DGVRowNo_EUR_GBP] = Const.EUR_GBP;
            通貨ペア[Const.DGVRowNo_EUR_JPY] = Const.EUR_JPY;
            通貨ペア[Const.DGVRowNo_EUR_NZD] = Const.EUR_NZD;
            通貨ペア[Const.DGVRowNo_EUR_TRY] = Const.EUR_TRY;
            通貨ペア[Const.DGVRowNo_EUR_USD] = Const.EUR_USD;
            通貨ペア[Const.DGVRowNo_GBP_AUD] = Const.GBP_AUD;
            通貨ペア[Const.DGVRowNo_GBP_CAD] = Const.GBP_CAD;
            通貨ペア[Const.DGVRowNo_GBP_CHF] = Const.GBP_CHF;
            通貨ペア[Const.DGVRowNo_GBP_JPY] = Const.GBP_JPY;
            通貨ペア[Const.DGVRowNo_GBP_NZD] = Const.GBP_NZD;
            通貨ペア[Const.DGVRowNo_GBP_USD] = Const.GBP_USD;
            通貨ペア[Const.DGVRowNo_NZD_CAD] = Const.NZD_CAD;
            通貨ペア[Const.DGVRowNo_NZD_CHF] = Const.NZD_CHF;
            通貨ペア[Const.DGVRowNo_NZD_JPY] = Const.NZD_JPY;
            通貨ペア[Const.DGVRowNo_NZD_USD] = Const.NZD_USD;
            通貨ペア[Const.DGVRowNo_TRY_JPY] = Const.TRY_JPY;
            通貨ペア[Const.DGVRowNo_USD_CAD] = Const.USD_CAD;
            通貨ペア[Const.DGVRowNo_USD_CHF] = Const.USD_CHF;
            通貨ペア[Const.DGVRowNo_USD_HKD] = Const.USD_HKD;
            通貨ペア[Const.DGVRowNo_USD_JPY] = Const.USD_JPY;
            通貨ペア[Const.DGVRowNo_USD_TRY] = Const.USD_TRY;
            通貨ペア[Const.DGVRowNo_USD_ZAR] = Const.USD_ZAR;
            通貨ペア[Const.DGVRowNo_ZAR_JPY] = Const.ZAR_JPY;
            通貨ペア[Const.DGVRowNo_XAU_USD] = Const.XAU_USD;
            通貨ペア[Const.DGVRowNo_JPN225] = Const.JPN225;
            通貨ペア[Const.DGVRowNo_US30] = Const.US30;
            通貨ペア[Const.DGVRowNo_USOil] = Const.USOil;
        }

		public static void ログイン(string connection, string strUsername, string strPassword)
		{

        }

        public static void Logout()
        {
            if (mSession != null)
            {
                mSession.Dispose();
                mSession = null;
            }
        }

		private static double 通貨ペア別Rate更新用_買いRate = 0;
		private static double 通貨ペア別Rate更新用_売りRate = 0;
		private static double 通貨ペア別Rate更新用_買いSwap = 0;
		private static double 通貨ペア別Rate更新用_売りSwap = 0;
		private static string 通貨ペア別Rate更新用_QuoteID = "";
		private static int 通貨ペア別Rate更新用_Cnt = 0;
		public static void 通貨ペア別Rate取得(byte 通貨ペアNo, out double RateB, out double RateS)
		{
			RateB = 0;
			RateS = 0;

			for (通貨ペア別Rate更新用_Cnt = 0; 通貨ペア別Rate更新用_Cnt < mOffers.Count; 通貨ペア別Rate更新用_Cnt++)
			{
				O2GOfferTableRow row = mOffers.getRow(通貨ペア別Rate更新用_Cnt);

				if (通貨ペア[通貨ペアNo] != row.Instrument)
				{
					continue;
				}

				RateB = row.Ask;
				RateS = row.Bid;

				return;
			}

		}

        // 注文を出す
        public static void CreateMarketOrder(string sOfferID, string sAccountID, int iAmount, double dRate, string sBuySell)
        {
            O2GRequestFactory factory = mSession.getRequestFactory();
            if (factory != null)
            {
                O2GValueMap valuemap = factory.createValueMap();
                valuemap.setString(O2GRequestParamsEnum.Command, Constants.Commands.CreateOrder);
                valuemap.setString(O2GRequestParamsEnum.OrderType, Constants.Orders.MarketOpen);
                valuemap.setString(O2GRequestParamsEnum.AccountID, sAccountID);                // The identifier of the account the order should be placed for.
                valuemap.setString(O2GRequestParamsEnum.OfferID, sOfferID);                    // The identifier of the instrument the order should be placed for.
                valuemap.setString(O2GRequestParamsEnum.BuySell, sBuySell);                    // The order direction (use Constants.Buy for Buy, Constants.Sell for Sell)
                valuemap.setDouble(O2GRequestParamsEnum.Rate, dRate);                          // The dRate at which the order must be filled.
                valuemap.setInt(O2GRequestParamsEnum.Amount, iAmount);                         // The quantity of the instrument to be bought or sold.
                valuemap.setString(O2GRequestParamsEnum.CustomID, "OpenMarketOrder");         // The custom identifier of the order.

                O2GRequest request = factory.createOrderRequest(valuemap);
                if (request == null)
                    Console.WriteLine("Order's request can not be created: " + factory.getLastError());
                else
                    mSession.sendRequest(request);
            }
        }
        
        // 注文をクローズする
        public static void CreateMarketCloseOrder(string sOfferID, string sAccountID, string sTradeID, int iAmount, double dRate, string sBuySell)
        {
            O2GRequestFactory factory = mSession.getRequestFactory();
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
                    Console.WriteLine("Order's request can not be created: " + factory.getLastError());
                else
                    mSession.sendRequest(request);
            }
        }

		public static void Getアカウント状態(out double 取引証拠金, out double 有効証拠金, out double 維持証拠金, out double ロスカット余剰金)
        {
			O2GAccountTableRow row = Trade.mAccount.getRow(0);

			取引証拠金 = row.Balance;
			有効証拠金 = row.M2MEquity;
			維持証拠金 = row.UsedMargin;
			ロスカット余剰金 = row.UsedMargin;
		}

		private static string DB記録_Trades_TradeID;
		private static int DB記録_Trades_iCnt;
		private static int DB記録_Trades_iTradeCnt;
		private static byte DB記録_Trades_IsBuy;
		private static string DB記録_Trades_OpenOrderID;
		public static void DB記録_Trades(SqlConnection cn)
		{
			for (DB記録_Trades_iCnt = 0; DB記録_Trades_iCnt < Trade.mTrades.Count; DB記録_Trades_iCnt++)
			{
				O2GTradeTableRow row = Trade.mTrades.getRow(DB記録_Trades_iCnt);

				DB記録_Trades_TradeID = row.TradeID;
				DB記録_Trades_iTradeCnt = trad.RecCnt(cn, DB記録_Trades_TradeID);

				if (DB記録_Trades_iTradeCnt > 0)
					continue;

				trad.InsertTrade(cn, row.TradeID, row.AccountID, row.AccountName, row.AccountKind, row.OfferID, row.Amount, row.BuySell,
					row.OpenRate, row.OpenTime, row.OpenQuoteID, row.OpenOrderID, row.OpenOrderReqID, row.OpenOrderRequestTXT,
					row.Commission, row.RolloverInterest, row.TradeIDOrigin, row.UsedMargin, row.ValueDate, row.Parties, row.Close,
					row.GrossPL, row.Limit, row.PL, row.Stop);

				oder.UpdateOrderHistory_TradeID(cn, DB記録_Trades_OpenOrderID);
			}
		}

		private static double ポジション更新_成行_dblEntryRate;
		private static double ポジション更新_成行_EntryLimit;
		private static object ポジション更新_成行_di;
		public static void ポジション更新_成行(string 売買モード, string 通貨ペア, double 買いRate, double 売りRate, int 取引単位, double リミット,
			string quoteId, out object OrderId)
		{
			if (売買モード == "B")
			{
				ポジション更新_成行_dblEntryRate = 買いRate;
				ポジション更新_成行_EntryLimit = ポジション更新_成行_dblEntryRate + リミット;
			}
			else
			{
				ポジション更新_成行_dblEntryRate = 売りRate;
				ポジション更新_成行_EntryLimit = ポジション更新_成行_dblEntryRate - リミット;
			}

			O2GRequestFactory factory = mSession.getRequestFactory();

			O2GValueMap valuemap = factory.createValueMap();
			valuemap.setString(O2GRequestParamsEnum.Command, Constants.Commands.CreateOrder);
			valuemap.setString(O2GRequestParamsEnum.OrderType, Constants.Orders.MarketOpen);
			valuemap.setString(O2GRequestParamsEnum.AccountID, accountId);                // The identifier of the account the order should be placed for.
			valuemap.setString(O2GRequestParamsEnum.OfferID, 通貨ペア);                    // The identifier of the instrument the order should be placed for.
			valuemap.setString(O2GRequestParamsEnum.BuySell, 売買モード);                    // The order direction (use Constants.Buy for Buy, Constants.Sell for Sell)
			valuemap.setDouble(O2GRequestParamsEnum.Rate, ポジション更新_成行_dblEntryRate);                          // The dRate at which the order must be filled.
			valuemap.setInt(O2GRequestParamsEnum.Amount, minAmount);                         // The quantity of the instrument to be bought or sold.
			valuemap.setString(O2GRequestParamsEnum.CustomID, "OpenMarketOrder");         // The custom identifier of the order.

			//成り行き
			O2GRequest request = factory.createOrderRequest(valuemap);

			mSession.sendRequest(request);

			OrderId = request.RequestID;
		}
	}
}
