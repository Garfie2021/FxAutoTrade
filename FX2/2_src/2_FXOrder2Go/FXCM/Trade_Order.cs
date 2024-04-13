using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using FXCore;
using Common;
using DB;

namespace FXCM
{
	//// Static禁止。　注文対象口座を動的に作成する為のClass
	//public static class TradeOrder
	//{
	//	public static List<Trade_Order> TradeOrderList = null;

	//	public static void ログイン(string FXCM_URL)
	//	{
	//		TradeOrderList = new List<Trade_Order>();
	//		TradeOrderList.Add(new Trade_Order(FXCM_URL, "Demo", "111", "111"));	// DemoA口座
	//		//TradeOrderList.Add(new TradeOrder(FXCM_URL, "Demo", "111", "111"));	// DemoA口座
	//		//TradeOrderList.Add(new TradeOrder(FXCM_URL, "Demo", "111", "111"));	// DemoA口座
	//	}

	//	public static void ログアウト()
	//	{
	//		foreach (Trade_Order order in TradeOrderList)
	//		{
	//			order.Logout();
	//		}
	//	}
	//}

	public static class Trade_Order
	{
		public static TradeDeskAut tradeDesk = null;
		public static TableAut accounts = null;
		public static TableAut orders = null;
		public static TableAut trades = null;
		public static TableAut offers = null;
		public static TableAut closed = null;
		public static TableAut summary = null;

		public static string AccountId = "";
		public static int minAmount = 0;
		public static int AtMarket = 0;											// txtシステム設定_AtMarket.Text

		public static string[] QuoteIdList;

		public static double 余剰金割合_Order限界点 = 0;						// txt余剰金割合_Order限界点.Text

		public static void ログイン(string FXCM_URL, string connection, string strUserID, string strPassword)
		{
			FXCore.CoreAut fxCore;
			fxCore = new FXCore.CoreAut();

			tradeDesk = (FXCore.TradeDeskAut)fxCore.CreateTradeDesk("trader");
			tradeDesk.Login(strUserID, strPassword, FXCM_URL, connection);
			accounts = (FXCore.TableAut)tradeDesk.FindMainTable("accounts");
			orders = (FXCore.TableAut)tradeDesk.FindMainTable("Orders");
			trades = (FXCore.TableAut)tradeDesk.FindMainTable("Trades");
			offers = (FXCore.TableAut)tradeDesk.FindMainTable("offers");
			closed = (FXCore.TableAut)tradeDesk.FindMainTable("closed trades");
			summary = (FXCore.TableAut)tradeDesk.FindMainTable("Summary");

			AccountId = (string)accounts.CellValue(1, "AccountID");
			minAmount = (int)accounts.CellValue(1, "BaseUnitSize");

			//QuoteID登録();
		}

		public static void ログアウト()
        {
			if (tradeDesk != null)
			{
				tradeDesk.Logout();
				tradeDesk = null;
			}
		}

		private static uint GetRate_Cnt;
		public static bool GetRate(byte 通貨ペアNo, ref double 買いRate, ref double 売りRate, ref string QuoteID)
		{
			for (GetRate_Cnt = 1; GetRate_Cnt <= offers.RowCount; GetRate_Cnt++)
			{
				if (FXCMConst.通貨ペア名List[通貨ペアNo].Equals((string)offers.CellValue(GetRate_Cnt, "Instrument")) == false)
					continue;

				買いRate = (double)offers.CellValue(GetRate_Cnt, "Ask");
				売りRate = (double)offers.CellValue(GetRate_Cnt, "Bid");
				QuoteID = (string)offers.CellValue(GetRate_Cnt, "QuoteID");

				if (買いRate < 0.00001 || 売りRate < 0.00001)
				{
					// FXCMのバグでRateが0以下になり、シグマ計算結果が狂う事件があったので、それはここで回避。
					return false;
				}

				return true;
			}
		}


		//public uint QuoteID登録_iCnt;
		//public byte QuoteID登録_通貨ペアNo;
		//private void QuoteID登録()
		//{
		//	QuoteIdList = new string[FXCMConst.通貨ペア数];

		//	for (QuoteID登録_通貨ペアNo = 0; QuoteID登録_通貨ペアNo < FXCMConst.通貨ペアList.Length; QuoteID登録_通貨ペアNo++)
		//	{
		//		for (QuoteID登録_iCnt = 1; QuoteID登録_iCnt <= offers.RowCount; QuoteID登録_iCnt++)
		//		{
		//			if (FXCMConst.通貨ペアList[QuoteID登録_通貨ペアNo].Equals((string)offers.CellValue(QuoteID登録_iCnt, "Instrument")) == false)
		//				continue;

		//			QuoteIdList[QuoteID登録_通貨ペアNo] = (string)offers.CellValue(QuoteID登録_iCnt, "QuoteID");
		//		}
		//	}
		//}

		//public string GetQuoteID(uint 通貨ペアNo)
		//{
		//	return (string)offers.CellValue(通貨ペアNo, "QuoteID");
		//}

		public static void Getアカウント状態(out double 取引証拠金, out double 有効証拠金, out double 維持証拠金, out double ロスカット余剰金)
		{
			取引証拠金 = 0;
			有効証拠金 = 0;
			維持証拠金 = 0;
			ロスカット余剰金 = 0;

			取引証拠金 = (double)accounts.CellValue(1, "Balance");	//取引証拠金
			有効証拠金 = (double)accounts.CellValue(1, "Equity");	//有効証拠金
			維持証拠金 = (double)accounts.CellValue(1, "UsedMargin");	//維持証拠金
			ロスカット余剰金 = (double)accounts.CellValue(1, "UsableMargin");	//ロスカット余剰金
		}

		private static double ポジション更新_成行_dblEntryRate;
		private static object ポジション更新_成行_di;
		private static bool ポジション更新_成行_売買モード;
		public static void ポジション更新_成行(byte 売買判定, byte 通貨ペアNo, int 注文数, double 買いRate, double 売りRate, 
			string QuoteID, ref object OrderId)
		{
			if (売買判定 == 1)
			{
				ポジション更新_成行_売買モード = true;
				ポジション更新_成行_dblEntryRate = 買いRate;
			}
			else
			{
				ポジション更新_成行_売買モード = false;
				ポジション更新_成行_dblEntryRate = 売りRate;
			}

			//string 通貨ペア = FXCMConst.通貨ペアList[通貨ペアNo];
			//string QuoteId = QuoteIdList[通貨ペアNo];

			//File.AppendAllText(txtログフォルダ.Text + @"\log.log", "Start" + "\r\n", Encoding.GetEncoding("Shift_JIS"));

			//logger.execlog_write(DateTime.Now.ToString() + "\r\n" +
			//	AccountId + "\r\n" +
			//	FXCMConst.通貨ペアList[通貨ペアNo] + "\r\n" +
			//	売買モード.ToString() + "\r\n" +
			//	(注文数 * minAmount).ToString() + "\r\n" +
			//	ポジション更新_成行_dblEntryRate.ToString() + "\r\n" +
			//	QuoteID + "\r\n" +
			//	FXCMConst.AtMarket.ToString() + "\r\n");

			//成り行き
			tradeDesk.OpenTrade2(AccountId, FXCMConst.通貨ペア名List[通貨ペアNo], ポジション更新_成行_売買モード, 注文数 * minAmount,
				ポジション更新_成行_dblEntryRate, QuoteID, FXCMConst.AtMarket, tradeDesk.SL_NONE, 0, 0, 0, 
				out OrderId, out ポジション更新_成行_di);
		}

		private static string TradesDB登録_TradeID;
		private static byte TradesDB登録_IsBuy;
		private static string TradesDB登録_OpenOrderID;
		private static uint TradesDB登録_iCnt;
		public static void TradesDB登録(SqlConnection cn)
		{
			for (TradesDB登録_iCnt = 1; TradesDB登録_iCnt <= trades.RowCount; TradesDB登録_iCnt++)
			{
				TradesDB登録_TradeID = (string)trades.CellValue(TradesDB登録_iCnt, "TradeID");

				if ((int)fxcm.Cnt_Trades_TradeID(cn, TradesDB登録_TradeID) > 0)
					continue;

				if (trades.CellValue(TradesDB登録_iCnt, "IsBuy").ToString().CompareTo("True") == 0)
					TradesDB登録_IsBuy = 1;
				else
					TradesDB登録_IsBuy = 0;

				TradesDB登録_OpenOrderID = (string)trades.CellValue(TradesDB登録_iCnt, "OpenOrderID");

				fxcm.InsertTrade(cn, 
					  TradesDB登録_TradeID
					, (string)trades.CellValue(TradesDB登録_iCnt, "AccountID")
					, (string)trades.CellValue(TradesDB登録_iCnt, "AccountName")
					, (string)trades.CellValue(TradesDB登録_iCnt, "OfferID")
					, (string)trades.CellValue(TradesDB登録_iCnt, "Instrument")
					, (int)trades.CellValue(TradesDB登録_iCnt, "Lot")
					, (double)trades.CellValue(TradesDB登録_iCnt, "AmountK")
					, (string)trades.CellValue(TradesDB登録_iCnt, "BS")
					, (double)trades.CellValue(TradesDB登録_iCnt, "Open")
					, (double)trades.CellValue(TradesDB登録_iCnt, "Close")
					, (double)trades.CellValue(TradesDB登録_iCnt, "Stop")
					, (double)trades.CellValue(TradesDB登録_iCnt, "UntTrlMove")
					, (double)trades.CellValue(TradesDB登録_iCnt, "Limit")
					, (double)trades.CellValue(TradesDB登録_iCnt, "UntTrlMoveLimit")
					, (double)trades.CellValue(TradesDB登録_iCnt, "PL")
					, (double)trades.CellValue(TradesDB登録_iCnt, "GrossPL")
					, (double)trades.CellValue(TradesDB登録_iCnt, "Com")
					, (double)trades.CellValue(TradesDB登録_iCnt, "Int")
					, ((DateTime)trades.CellValue(TradesDB登録_iCnt, "Time")).AddHours(C共通.FXOrder2Go時間補正)
					, TradesDB登録_IsBuy
					, (string)trades.CellValue(TradesDB登録_iCnt, "Kind")
					, (string)trades.CellValue(TradesDB登録_iCnt, "QuoteID")
					, TradesDB登録_OpenOrderID
					, ""
					, (string)trades.CellValue(TradesDB登録_iCnt, "QTXT")
					, ""
					, ""
					, (string)trades.CellValue(TradesDB登録_iCnt, "TradeIDOrigin")
					);

				oder.UpdateOrderHistory_TradeID(cn, TradesDB登録_OpenOrderID);
			}
		}

		private static string OrderV1ポジションClose_TradeID;
		private static object OrderV1ポジションClose_OrderID;
		private static uint OrderV1ポジションClose_iCnt;
		public static void OrderV1ポジションClose(SqlConnection cn, DateTime StartDate)
		{
			//15分を基準に持続時間を計算しているので、15分以上前のポジションはCloseする。
			for (TradesDB登録_iCnt = 1; TradesDB登録_iCnt <= trades.RowCount; TradesDB登録_iCnt++)
			{
				if (StartDate.AddMinutes(-15) < ((DateTime)trades.CellValue(TradesDB登録_iCnt, "Time")).AddHours(C共通.FXOrder2Go時間補正)) continue;

				ポジションClose((string)trades.CellValue(TradesDB登録_iCnt, "TradeID"), ref OrderV1ポジションClose_OrderID);

				if (TradesDB登録_iCnt > 10) break;	// FXCMがCloseトレードを記録しておける限界的に、一度にCloseするのは最大10までにする。
			}

			// FXCM上のクローズトレードを記録

			for (OrderV1ポジションClose_iCnt = 1; OrderV1ポジションClose_iCnt <= closed.RowCount; OrderV1ポジションClose_iCnt++)
			{
				OrderV1ポジションClose_TradeID = (string)closed.CellValue(OrderV1ポジションClose_iCnt, "TradeID");

				if (fxcm.Cnt_ClosedTrades_TradeID(cn, OrderV1ポジションClose_TradeID) > 0)
					continue;

				fxcm.InsertClosedTrades(cn, 
					OrderV1ポジションClose_TradeID,
					(string)closed.CellValue(OrderV1ポジションClose_iCnt, "AccountID"),
					(string)closed.CellValue(OrderV1ポジションClose_iCnt, "AccountName"),
					(string)closed.CellValue(OrderV1ポジションClose_iCnt, "OfferID"),
					(string)closed.CellValue(OrderV1ポジションClose_iCnt, "Instrument"),
					(int)closed.CellValue(OrderV1ポジションClose_iCnt, "Lot"),
					(double)closed.CellValue(OrderV1ポジションClose_iCnt, "AmountK"),
					(string)closed.CellValue(OrderV1ポジションClose_iCnt, "BS"),
					(double)closed.CellValue(OrderV1ポジションClose_iCnt, "Open"),
					(double)closed.CellValue(OrderV1ポジションClose_iCnt, "Close"),
					(double)closed.CellValue(OrderV1ポジションClose_iCnt, "PL"),
					(double)closed.CellValue(OrderV1ポジションClose_iCnt, "GrossPL"),
					(double)closed.CellValue(OrderV1ポジションClose_iCnt, "Com"),
					(double)closed.CellValue(OrderV1ポジションClose_iCnt, "Int"),
					((DateTime)closed.CellValue(OrderV1ポジションClose_iCnt, "OpenTime")).AddHours(FXCMConst.FXOrder2Go時間補正),
					((DateTime)closed.CellValue(OrderV1ポジションClose_iCnt, "CloseTime")).AddHours(FXCMConst.FXOrder2Go時間補正),
					(string)closed.CellValue(OrderV1ポジションClose_iCnt, "Kind"),
					(string)closed.CellValue(OrderV1ポジションClose_iCnt, "OpenOrderID"),
					"",
					(string)closed.CellValue(OrderV1ポジションClose_iCnt, "CloseOrderID"),
					"",
					(string)closed.CellValue(OrderV1ポジションClose_iCnt, "OQTXT"),
					(string)closed.CellValue(OrderV1ポジションClose_iCnt, "CQTXT"),
					"",
					"");
			}
		}

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

		private static Object ポジションClose_sDI;
		private static uint ポジションClose_iCnt;
		public static void ポジションClose(string TradeID, ref object OrderID)
		{
			for (ポジションClose_iCnt = 1; ポジションClose_iCnt <= trades.RowCount; ポジションClose_iCnt++)
			{
				if (!((string)trades.CellValue(ポジションClose_iCnt, "TradeID")).Equals(TradeID)) continue;

				tradeDesk.CloseTrade(TradeID, (int)trades.CellValue(ポジションClose_iCnt, "Lot"), (double)trades.CellValue(ポジションClose_iCnt, "Close"),
					(string)trades.CellValue(ポジションClose_iCnt, "QuoteID"), AtMarket, out OrderID, out ポジションClose_sDI);

				break;
			}
		}

		//public void ポジション更新(
		//	bool bBuyShellMode,
		//	string 通貨ペア,
		//	string str取引単位,
		//	string str取引間隔,
		//	string strリミット,
		//	string str高値限界Rate,
		//	string str下値限界Rate,
		//	string strLogFolder)
		//{
		//	//string accountId = (string)accounts.CellValue(1, "AccountID");

		//	int minAmount = (int)accounts.CellValue(1, "BaseUnitSize");
		//	int Amount = minAmount * int.Parse(str取引単位);
		//	double dbl取引間隔 = double.Parse(str取引間隔);
		//	double dblリミット = double.Parse(strリミット);
		//	double dbl高値限界Rate = double.Parse(str高値限界Rate);

		//	uint iCnt = 1;
		//	for (double dblEntryRate = double.Parse(str下値限界Rate); dblEntryRate < dbl高値限界Rate; dblEntryRate += dbl取引間隔)
		//	{
		//		double EntryLimit = 0;
		//		if (bBuyShellMode == true)
		//			EntryLimit = dblEntryRate + dblリミット;
		//		else
		//			EntryLimit = dblEntryRate - dblリミット;

		//		//既に注文状況にEntoryが無いかチェック
		//		//double Limit = 0;
		//		double OpenRate = 0;
		//		double TopRangeRate = 0;
		//		double BottomRangeRate = 0;
		//		bool b既にEntory有り = false;
		//		for (iCnt = 1; iCnt <= orders.RowCount; iCnt++)
		//		{
		//			if ((string)orders.CellValue(iCnt, "Instrument") != 通貨ペア)
		//				continue;

		//			OpenRate = (double)orders.CellValue(iCnt, "Rate");
		//			//TopRangeRate = OpenRate + (dbl取引間隔 / 2);
		//			//BottomRangeRate = OpenRate - (dbl取引間隔 / 2);
		//			TopRangeRate = OpenRate + dbl取引間隔;
		//			BottomRangeRate = OpenRate - dbl取引間隔;

		//			if (BottomRangeRate < dblEntryRate && dblEntryRate < TopRangeRate)
		//			{
		//				b既にEntory有り = true;
		//				break;
		//			}
		//		}

		//		if (b既にEntory有り == true)
		//			continue;

		//		//既にポジションにEntoryが無いかチェック
		//		for (iCnt = 1; iCnt <= trades.RowCount; iCnt++)
		//		{
		//			if ((string)trades.CellValue(iCnt, "Instrument") != 通貨ペア)
		//				continue;

		//			OpenRate = (double)trades.CellValue(iCnt, "Open");
		//			//TopRangeRate = OpenRate + (dbl取引間隔 / 2);
		//			//BottomRangeRate = OpenRate - (dbl取引間隔 / 2);
		//			TopRangeRate = OpenRate + dbl取引間隔;
		//			BottomRangeRate = OpenRate - dbl取引間隔;

		//			if (BottomRangeRate < dblEntryRate && dblEntryRate < TopRangeRate)
		//			{
		//				b既にEntory有り = true;
		//				break;
		//			}
		//		}

		//		////既に逆ポジションにEntoryが無いかチェック
		//		//b既にEntory有り = Chk逆ポジション(trades, 通貨ペア, bBuyShellMode);

		//		if (b既にEntory有り == true)
		//			continue;

		//		//指値取引を登録
		//		object orderId, di;
		//		tradeDesk.CreateEntryOrder2(accountId, 通貨ペア, bBuyShellMode, Amount, dblEntryRate, tradeDesk.SL_LIMIT, 0, EntryLimit, 0, out orderId, out di);

		//		//DateTime now = DateTime.Now;
		//		//File.AppendAllText(strLogFolder + @"\" + now.ToString("yyyyMMdd") + "_sts.log", ",", Encoding.GetEncoding("Shift_JIS"));
		//	}
		//}


		//private double ChkOrder間隔内にポジションがあるか_dblEntryRate;
		//private double ChkOrder間隔内にポジションがあるか_OrderRate;
		//private double ChkOrder間隔内にポジションがあるか_TopRate;
		//private double ChkOrder間隔内にポジションがあるか_BottomRate;
		//private uint ChkOrder間隔内にポジションがあるか_Cnt;
		//public bool ChkOrder間隔内にポジションがあるか(bool 売買モード, string 通貨ペア, double 買いRate, double 売りRate, double Order間隔)
		//{
		//	if (売買モード == true)
		//	{
		//		ChkOrder間隔内にポジションがあるか_dblEntryRate = 買いRate;
		//	}
		//	else
		//	{
		//		ChkOrder間隔内にポジションがあるか_dblEntryRate = 売りRate;
		//	}

		//	//既にポジションにEntoryが無いかチェック
		//	for (ChkOrder間隔内にポジションがあるか_Cnt = 1; ChkOrder間隔内にポジションがあるか_Cnt <= trades.RowCount; ChkOrder間隔内にポジションがあるか_Cnt++)
		//	{
		//		if ((string)trades.CellValue(ChkOrder間隔内にポジションがあるか_Cnt, "Instrument") != 通貨ペア)
		//			continue;

		//		ChkOrder間隔内にポジションがあるか_OrderRate = (double)trades.CellValue(ChkOrder間隔内にポジションがあるか_Cnt, "Open");
		//		ChkOrder間隔内にポジションがあるか_TopRate = ChkOrder間隔内にポジションがあるか_OrderRate + Order間隔;
		//		ChkOrder間隔内にポジションがあるか_BottomRate = ChkOrder間隔内にポジションがあるか_OrderRate - Order間隔;

		//		if (ChkOrder間隔内にポジションがあるか_BottomRate < ChkOrder間隔内にポジションがあるか_dblEntryRate &&
		//			ChkOrder間隔内にポジションがあるか_dblEntryRate < ChkOrder間隔内にポジションがあるか_TopRate)
		//		{
		//			return true;
		//		}
		//	}

		//	return false;
		//}


		//private double リミット変更_dblEntryRate;
		//private double リミット変更_EntryLimit;
		//public void リミット変更(string TradeID, bool 売買モード, double 買いRate, double 売りRate, double リミット,
		//	out object リミット変更OrderID)
		//{
		//	if (売買モード == true)
		//	{
		//		リミット変更_dblEntryRate = 買いRate;
		//		リミット変更_EntryLimit = リミット変更_dblEntryRate + リミット;
		//	}
		//	else
		//	{
		//		リミット変更_dblEntryRate = 売りRate;
		//		リミット変更_EntryLimit = リミット変更_dblEntryRate - リミット;
		//	}

		//	tradeDesk.ChangeTradeStopLimit2(TradeID, リミット変更_EntryLimit, false, 0, out リミット変更OrderID);
		//}

		//public bool Chkポジション有り(string 通貨ペア)
		//{
		//	for (uint iCnt = 1; iCnt <= trades.RowCount; iCnt++)
		//	{
		//		if ((string)trades.CellValue(iCnt, "Instrument") != 通貨ペア)
		//			continue;

		//		return true;
		//	}

		//	return false;
		//}

		//public uint Chk逆ポジション_iCnt;
		//public bool Chk逆ポジション(string 通貨ペア, bool bBuyShellMode)
		//{
		//	for (Chk逆ポジション_iCnt = 1; Chk逆ポジション_iCnt <= trades.RowCount; Chk逆ポジション_iCnt++)
		//	{
		//		if ((string)trades.CellValue(Chk逆ポジション_iCnt, "Instrument") != 通貨ペア)
		//			continue;

		//		if ((string)trades.CellValue(Chk逆ポジション_iCnt, "BS") == "B")
		//		{
		//			//買いのポジションがあったら、売りを出さない。
		//			if (bBuyShellMode == false)
		//			{
		//				return true;
		//			}
		//		}
		//		else if ((string)trades.CellValue(Chk逆ポジション_iCnt, "BS") == "S")
		//		{
		//			//売りのポジションがあったら、買いを出さない。
		//			if (bBuyShellMode == true)
		//			{
		//				return true;
		//			}
		//		}
		//	}

		//	return false;
		//}

		//private int Getポジション数_ポジション数;
		//private uint Getポジション数_Cnt;
		//public int Getポジション数(byte 通貨ペアNo)
		//{
		//	Getポジション数_ポジション数 = 0;
		//	for (Getポジション数_Cnt = 1; Getポジション数_Cnt <= trades.RowCount; Getポジション数_Cnt++)
		//	{
		//		if ((string)trades.CellValue(Getポジション数_Cnt, "Instrument") != FXCMConst.通貨ペア[通貨ペアNo])
		//			continue;
		//		else
		//			Getポジション数_ポジション数++;
		//	}

		//	return Getポジション数_ポジション数;
		//}

		//public bool Chk直近n秒以内にCloseされたポジション有り(string 通貨ペア名, int 時間補正, DateTime n秒前)
		//{
		//	for (uint Cnt = 1; Cnt <= closed.RowCount; Cnt++)
		//	{
		//		if (((DateTime)closed.CellValue(Cnt, "CloseTime")).AddHours(時間補正) < n秒前)
		//			continue;

		//		if ((string)closed.CellValue(Cnt, "Instrument") == 通貨ペア名)
		//			return true;
		//	}

		//	return false;
		//}


		//// 注文を出す
		//public void CreateMarketOrder(string sOfferID, string sAccountID, int iAmount, double dRate, string sBuySell)
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
		//public void CreateMarketCloseOrder(string sOfferID, string sAccountID, string sTradeID, int iAmount, double dRate, string sBuySell)
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

	}
}
