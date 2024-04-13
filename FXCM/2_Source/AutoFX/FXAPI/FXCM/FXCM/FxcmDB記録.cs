using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using 定数;
using DB;

namespace FXCM
{
	public static class FxcmDB記録
	{
		public static void DB記録_Accounts(SqlConnection cn)
		{
			fxcm.InsertAccounts(cn,
				DateTime.Now,
				(string)TradeFXCM.accounts.CellValue(1, "AccountID"),
				(string)TradeFXCM.accounts.CellValue(1, "AccountName"),
				(double)TradeFXCM.accounts.CellValue(1, "Balance"),
				(double)TradeFXCM.accounts.CellValue(1, "Equity"),
				(double)TradeFXCM.accounts.CellValue(1, "DayPL"),
				(double)TradeFXCM.accounts.CellValue(1, "NontrdEqty"),
				(double)TradeFXCM.accounts.CellValue(1, "M2MEquity"),
				(double)TradeFXCM.accounts.CellValue(1, "UsedMargin"),
				(double)TradeFXCM.accounts.CellValue(1, "UsableMargin"),
				(double)TradeFXCM.accounts.CellValue(1, "GrossPL"),
				(string)TradeFXCM.accounts.CellValue(1, "Kind"),
				(string)TradeFXCM.accounts.CellValue(1, "MarginCall"),
				TradeFXCM.accounts.CellValue(1, "IsUnderMarginCall").ToString(),
				(string)TradeFXCM.accounts.CellValue(1, "Hedging"),
				(int)TradeFXCM.accounts.CellValue(1, "AmountLimit"),
				(int)TradeFXCM.accounts.CellValue(1, "BaseUnitSize"));
		}

		private static string TradesDB登録_TradeID;
		private static byte TradesDB登録_IsBuy;
		private static string TradesDB登録_OpenOrderID;
		private static uint TradesDB登録_iCnt;
		public static void DB記録_Trades(SqlConnection cn)
		{
			for (TradesDB登録_iCnt = 1; TradesDB登録_iCnt <= TradeFXCM.trades.RowCount; TradesDB登録_iCnt++)
			{
				TradesDB登録_TradeID = (string)TradeFXCM.trades.CellValue(TradesDB登録_iCnt, "TradeID");

				if ((int)fxcm.Cnt_Trades_TradeID(cn, TradesDB登録_TradeID) > 0)
					continue;

				if (TradeFXCM.trades.CellValue(TradesDB登録_iCnt, "IsBuy").ToString().CompareTo("True") == 0)
					TradesDB登録_IsBuy = 1;
				else
					TradesDB登録_IsBuy = 0;

				TradesDB登録_OpenOrderID = (string)TradeFXCM.trades.CellValue(TradesDB登録_iCnt, "OpenOrderID");

				fxcm.InsertTrade(cn,
					  TradesDB登録_TradeID
					, (string)TradeFXCM.trades.CellValue(TradesDB登録_iCnt, "AccountID")
					, (string)TradeFXCM.trades.CellValue(TradesDB登録_iCnt, "AccountName")
					, (string)TradeFXCM.trades.CellValue(TradesDB登録_iCnt, "OfferID")
					, (string)TradeFXCM.trades.CellValue(TradesDB登録_iCnt, "Instrument")
					, (int)TradeFXCM.trades.CellValue(TradesDB登録_iCnt, "Lot")
					, (double)TradeFXCM.trades.CellValue(TradesDB登録_iCnt, "AmountK")
					, (string)TradeFXCM.trades.CellValue(TradesDB登録_iCnt, "BS")
					, (double)TradeFXCM.trades.CellValue(TradesDB登録_iCnt, "Open")
					, (double)TradeFXCM.trades.CellValue(TradesDB登録_iCnt, "Close")
					, (double)TradeFXCM.trades.CellValue(TradesDB登録_iCnt, "Stop")
					, (double)TradeFXCM.trades.CellValue(TradesDB登録_iCnt, "UntTrlMove")
					, (double)TradeFXCM.trades.CellValue(TradesDB登録_iCnt, "Limit")
					, (double)TradeFXCM.trades.CellValue(TradesDB登録_iCnt, "UntTrlMoveLimit")
					, (double)TradeFXCM.trades.CellValue(TradesDB登録_iCnt, "PL")
					, (double)TradeFXCM.trades.CellValue(TradesDB登録_iCnt, "GrossPL")
					, (double)TradeFXCM.trades.CellValue(TradesDB登録_iCnt, "Com")
					, (double)TradeFXCM.trades.CellValue(TradesDB登録_iCnt, "Int")
					, ((DateTime)TradeFXCM.trades.CellValue(TradesDB登録_iCnt, "Time")).AddHours(FX定数.FXOrder2Go時間補正)
					, TradesDB登録_IsBuy
					, (string)TradeFXCM.trades.CellValue(TradesDB登録_iCnt, "Kind")
					, (string)TradeFXCM.trades.CellValue(TradesDB登録_iCnt, "QuoteID")
					, TradesDB登録_OpenOrderID
					, ""
					, (string)TradeFXCM.trades.CellValue(TradesDB登録_iCnt, "QTXT")
					, ""
					, ""
					, (string)TradeFXCM.trades.CellValue(TradesDB登録_iCnt, "TradeIDOrigin")
					);
			}
		}

		private static string DB記録_ClosedTrades_TradeID;
		private static uint DB記録_ClosedTrades_iCnt;
		public static void DB記録_ClosedTrades(SqlConnection cn)
		{
			for (DB記録_ClosedTrades_iCnt = 1; DB記録_ClosedTrades_iCnt <= TradeFXCM.closed.RowCount; DB記録_ClosedTrades_iCnt++)
			{
				DB記録_ClosedTrades_TradeID = (string)TradeFXCM.closed.CellValue(DB記録_ClosedTrades_iCnt, "TradeID");

				if (fxcm.SelectCnt_TradeID(cn, DB記録_ClosedTrades_TradeID) > 0)
					continue;

				fxcm.InsertClosedTrades(cn,
					DB記録_ClosedTrades_TradeID,
					(string)TradeFXCM.closed.CellValue(DB記録_ClosedTrades_iCnt, "AccountID"),
					(string)TradeFXCM.closed.CellValue(DB記録_ClosedTrades_iCnt, "AccountName"),
					(string)TradeFXCM.closed.CellValue(DB記録_ClosedTrades_iCnt, "OfferID"),
					(string)TradeFXCM.closed.CellValue(DB記録_ClosedTrades_iCnt, "Instrument"),
					(int)TradeFXCM.closed.CellValue(DB記録_ClosedTrades_iCnt, "Lot"),
					(double)TradeFXCM.closed.CellValue(DB記録_ClosedTrades_iCnt, "AmountK"),
					(string)TradeFXCM.closed.CellValue(DB記録_ClosedTrades_iCnt, "BS"),
					(double)TradeFXCM.closed.CellValue(DB記録_ClosedTrades_iCnt, "Open"),
					(double)TradeFXCM.closed.CellValue(DB記録_ClosedTrades_iCnt, "Close"),
					(double)TradeFXCM.closed.CellValue(DB記録_ClosedTrades_iCnt, "PL"),
					(double)TradeFXCM.closed.CellValue(DB記録_ClosedTrades_iCnt, "GrossPL"),
					(double)TradeFXCM.closed.CellValue(DB記録_ClosedTrades_iCnt, "Com"),
					(double)TradeFXCM.closed.CellValue(DB記録_ClosedTrades_iCnt, "Int"),
					((DateTime)TradeFXCM.closed.CellValue(DB記録_ClosedTrades_iCnt, "OpenTime")).AddHours(FX定数.FXOrder2Go時間補正),
					((DateTime)TradeFXCM.closed.CellValue(DB記録_ClosedTrades_iCnt, "CloseTime")).AddHours(FX定数.FXOrder2Go時間補正),
					(string)TradeFXCM.closed.CellValue(DB記録_ClosedTrades_iCnt, "Kind"),
					(string)TradeFXCM.closed.CellValue(DB記録_ClosedTrades_iCnt, "OpenOrderID"),
					"",
					(string)TradeFXCM.closed.CellValue(DB記録_ClosedTrades_iCnt, "CloseOrderID"),
					"",
					(string)TradeFXCM.closed.CellValue(DB記録_ClosedTrades_iCnt, "OQTXT"),
					(string)TradeFXCM.closed.CellValue(DB記録_ClosedTrades_iCnt, "CQTXT"),
					"",
					"");

			}
		}
	}
}
