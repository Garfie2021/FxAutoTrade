using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using 定数;
using Common;
using DB;

namespace FXCM
{
	public static class Fxcm共通
	{
		public static void 保持ポジションのリミット初期化_BS終了時(SqlConnection cn, string 通貨ペア名, bool BS, double 買いリミット, double 売りリミット)
		{
			string TradeID;
			object リミット初期化OrderID;
			uint iCnt;

			for (iCnt = 1; iCnt <= TradeFXCM.trades.RowCount; iCnt++)
			{
				if ((string)TradeFXCM.trades.CellValue(iCnt, "Instrument") != 通貨ペア名)
					continue;

				TradeID = (string)TradeFXCM.trades.CellValue(iCnt, "TradeID");

				TradeFXCM.リミット変更(TradeID, BS, 買いリミット, 売りリミット, out リミット初期化OrderID);
			}
		}

		private static string 保持ポジションのリミットを初期化する_TradeID;
		private static bool 保持ポジションのリミットを初期化する_BS;
		private static double 保持ポジションのリミットを初期化する_OpenRate;
		private static double 保持ポジションのリミットを初期化する_CloseRate;
		private static double 保持ポジションのリミットを初期化する_Rate;
		private static object 保持ポジションのリミットを初期化する_リミット初期化OrderID;
		private static uint 保持ポジションのリミットを初期化する_iCnt;
		public static void 保持ポジションのリミット初期化(SqlConnection cn, string 通貨ペア名, double 買いリミット, double 売りリミット)
		{
			for (保持ポジションのリミットを初期化する_iCnt = 1; 保持ポジションのリミットを初期化する_iCnt <= TradeFXCM.trades.RowCount; 保持ポジションのリミットを初期化する_iCnt++)
			{
				if ((string)TradeFXCM.trades.CellValue(保持ポジションのリミットを初期化する_iCnt, "Instrument") != 通貨ペア名)
					continue;

				保持ポジションのリミットを初期化する_TradeID = (string)TradeFXCM.trades.CellValue(保持ポジションのリミットを初期化する_iCnt, "TradeID");
				保持ポジションのリミットを初期化する_BS = TradeFXCM.GetTradeDesk売買モード_toBool((string)TradeFXCM.trades.CellValue(保持ポジションのリミットを初期化する_iCnt, "BS"));
				保持ポジションのリミットを初期化する_OpenRate = (double)TradeFXCM.trades.CellValue(保持ポジションのリミットを初期化する_iCnt, "Open");
				保持ポジションのリミットを初期化する_CloseRate = (double)TradeFXCM.trades.CellValue(保持ポジションのリミットを初期化する_iCnt, "Close");

				if (保持ポジションのリミットを初期化する_BS == true)
				{
					if (保持ポジションのリミットを初期化する_OpenRate < 保持ポジションのリミットを初期化する_CloseRate)
					{
						保持ポジションのリミットを初期化する_Rate = 保持ポジションのリミットを初期化する_CloseRate;
					}
					else
					{
						保持ポジションのリミットを初期化する_Rate = 保持ポジションのリミットを初期化する_OpenRate;
					}
				}
				else
				{
					if (保持ポジションのリミットを初期化する_OpenRate > 保持ポジションのリミットを初期化する_CloseRate)
					{
						保持ポジションのリミットを初期化する_Rate = 保持ポジションのリミットを初期化する_CloseRate;
					}
					else
					{
						保持ポジションのリミットを初期化する_Rate = 保持ポジションのリミットを初期化する_OpenRate;
					}
				}

				TradeFXCM.リミット変更(保持ポジションのリミットを初期化する_TradeID, 保持ポジションのリミットを初期化する_BS,
					買いリミット, 売りリミット, out 保持ポジションのリミットを初期化する_リミット初期化OrderID);
			}
		}

		private static string 特定通貨ペアのリミット幅を拡張する_TradeID;
		private static double 特定通貨ペアのリミット幅を拡張する_Limit;
		private static object 特定通貨ペアのリミット幅を拡張する_リミット拡張OrderID;
		private static uint 特定通貨ペアのリミット幅を拡張する_iCnt;
		public static void 特定通貨ペアのリミット幅を拡張する(SqlConnection cn, string 通貨ペア名, bool 売買モード, double 買いRate, double 売りRate, double 買いリミット, double 売りリミット)
		{
			特定通貨ペアのリミット幅を拡張する_TradeID = "";
			特定通貨ペアのリミット幅を拡張する_Limit = 0;

			for (特定通貨ペアのリミット幅を拡張する_iCnt = 1; 特定通貨ペアのリミット幅を拡張する_iCnt <= TradeFXCM.trades.RowCount; 特定通貨ペアのリミット幅を拡張する_iCnt++)
			{
				if ((string)TradeFXCM.trades.CellValue(特定通貨ペアのリミット幅を拡張する_iCnt, "Instrument") != 通貨ペア名)
					continue;

				特定通貨ペアのリミット幅を拡張する_TradeID = (string)TradeFXCM.trades.CellValue(特定通貨ペアのリミット幅を拡張する_iCnt, "TradeID");
				特定通貨ペアのリミット幅を拡張する_Limit = (double)TradeFXCM.trades.CellValue(特定通貨ペアのリミット幅を拡張する_iCnt, "Limit");

				TradeFXCM.リミット変更(特定通貨ペアのリミット幅を拡張する_TradeID, 売買モード, 買いリミット, 売りリミット, 
					out 特定通貨ペアのリミット幅を拡張する_リミット拡張OrderID);
			}
		}


		private static DateTime ClosedTrades_n日前のポジションを決済する_Time;
		private static string ClosedTrades_n日前のポジションを決済する_sTradeID;
		private static int ClosedTrades_n日前のポジションを決済する_iAmount;
		private static double ClosedTrades_n日前のポジションを決済する_dRate;
		private static string ClosedTrades_n日前のポジションを決済する_sQuoteID;
		private static object ClosedTrades_n日前のポジションを決済する_CloseOrderID;
		private static uint ClosedTrades_n日前のポジションを決済する_iCnt;
		public static void ClosedTrades_n日前のポジションを決済する(SqlConnection cn, bool chkn日以上前のポジション決済をスキップ, int n日前)
		{
			if (chkn日以上前のポジション決済をスキップ == true)
				return;

			n日前 = n日前 * -1;

			DateTime dt_n日前 = DateTime.Now.AddDays(n日前);

			for (ClosedTrades_n日前のポジションを決済する_iCnt = 1; ClosedTrades_n日前のポジションを決済する_iCnt <= TradeFXCM.trades.RowCount; ClosedTrades_n日前のポジションを決済する_iCnt++)
			{
				ClosedTrades_n日前のポジションを決済する_Time = (DateTime)TradeFXCM.trades.CellValue(ClosedTrades_n日前のポジションを決済する_iCnt, "Time");
				ClosedTrades_n日前のポジションを決済する_sTradeID = (string)TradeFXCM.trades.CellValue(ClosedTrades_n日前のポジションを決済する_iCnt, "TradeID");

				if (dt_n日前 < ClosedTrades_n日前のポジションを決済する_Time)
				{
					continue;
				}

				ClosedTrades_n日前のポジションを決済する_iAmount = (int)TradeFXCM.trades.CellValue(ClosedTrades_n日前のポジションを決済する_iCnt, "Lot");
				ClosedTrades_n日前のポジションを決済する_dRate = (double)TradeFXCM.trades.CellValue(ClosedTrades_n日前のポジションを決済する_iCnt, "Close");
				ClosedTrades_n日前のポジションを決済する_sQuoteID = (string)TradeFXCM.trades.CellValue(ClosedTrades_n日前のポジションを決済する_iCnt, "QuoteID");

				TradeFXCM.ポジションをクローズする(ClosedTrades_n日前のポジションを決済する_sTradeID, ClosedTrades_n日前のポジションを決済する_iAmount,
					ClosedTrades_n日前のポジションを決済する_dRate, ClosedTrades_n日前のポジションを決済する_sQuoteID, システム設定.AtMarket,
					out ClosedTrades_n日前のポジションを決済する_CloseOrderID);

				FxcmDB記録.DB記録_ClosedTrades(cn);
			}
		}

		private static string 利益が出ているOrderは全てクローズする_TradeID;
		private static int 利益が出ているOrderは全てクローズする_Amount;
		private static string 利益が出ているOrderは全てクローズする_売買モード;
		private static double 利益が出ているOrderは全てクローズする_OrderEntryRate;
		private static double 利益が出ているOrderは全てクローズする_CloseRate;
		private static string 利益が出ているOrderは全てクローズする_sQuoteID;
		private static object 利益が出ているOrderは全てクローズする_CloseOrderID;
		private static uint 利益が出ているOrderは全てクローズする_iCnt;
		public static void 利益が出ているOrderは全てクローズする(SqlConnection cn, string 通貨ペア名, string Close区分)
		{
			for (利益が出ているOrderは全てクローズする_iCnt = 1; 利益が出ているOrderは全てクローズする_iCnt <= TradeFXCM.trades.RowCount; 利益が出ているOrderは全てクローズする_iCnt++)
			{
				if ((string)TradeFXCM.trades.CellValue(利益が出ているOrderは全てクローズする_iCnt, "Instrument") != 通貨ペア名)
					continue;

				if ((double)TradeFXCM.trades.CellValue(利益が出ているOrderは全てクローズする_iCnt, "GrossPL") < 30)
					continue;

				利益が出ているOrderは全てクローズする_売買モード = (string)TradeFXCM.trades.CellValue(利益が出ているOrderは全てクローズする_iCnt, "BS");
				利益が出ているOrderは全てクローズする_OrderEntryRate = (double)TradeFXCM.trades.CellValue(利益が出ているOrderは全てクローズする_iCnt, "Open");
				利益が出ているOrderは全てクローズする_CloseRate = (double)TradeFXCM.trades.CellValue(利益が出ているOrderは全てクローズする_iCnt, "Close");
				利益が出ているOrderは全てクローズする_TradeID = (string)TradeFXCM.trades.CellValue(利益が出ているOrderは全てクローズする_iCnt, "TradeID");
				利益が出ているOrderは全てクローズする_Amount = (int)TradeFXCM.trades.CellValue(利益が出ているOrderは全てクローズする_iCnt, "Lot");
				利益が出ているOrderは全てクローズする_sQuoteID = (string)TradeFXCM.trades.CellValue(利益が出ているOrderは全てクローズする_iCnt, "QuoteID");

				TradeFXCM.ポジションをクローズする(利益が出ているOrderは全てクローズする_TradeID, 利益が出ているOrderは全てクローズする_Amount, 利益が出ているOrderは全てクローズする_CloseRate, 利益が出ているOrderは全てクローズする_sQuoteID, システム設定.AtMarket, 
					out 利益が出ているOrderは全てクローズする_CloseOrderID);
			}
		}

		public static double 余剰金の割合計算(double 出金可能額で調整したロスカット余剰金)
		{
			//return ((double)CTrade.accounts.CellValue(1, "UsableMargin") / (double)CTrade.accounts.CellValue(1, "Balance")) * 100;
			return (出金可能額で調整したロスカット余剰金 / (double)TradeFXCM.accounts.CellValue(1, "Balance")) * 100;
		}

		private static DateTime Getポジション増加数用_now;
		private static int Getポジション増加数用_iOutFrom;
		private static int Getポジション増加数用_iOutTo;
		private static DateTime Getポジション増加数用_Time;
		private static int Getポジション増加数_ポジション数;
		private static uint Getポジション増加数_iCnt3;
		public static int Getポジション増加数(string 通貨ペア)
		{
			//DateTime now = DateTime.Parse("2014/03/17 7:00:00");
			Getポジション増加数用_now = DateTime.Now;
			注文共通.土日を含む場合の調整_時間単位(Getポジション増加数用_now, システム設定.ポジション増加数_直近n時間, 0,
				out Getポジション増加数用_iOutFrom, out Getポジション増加数用_iOutTo);

			Getポジション増加数用_Time = DateTime.Now;
			Getポジション増加数用_now = Getポジション増加数用_now.AddHours(Getポジション増加数用_iOutFrom);

			Getポジション増加数_ポジション数 = 0;
			for (Getポジション増加数_iCnt3 = 1; Getポジション増加数_iCnt3 <= TradeFXCM.trades.RowCount; Getポジション増加数_iCnt3++)
			{
				if ((string)TradeFXCM.trades.CellValue(Getポジション増加数_iCnt3, "Instrument") != 通貨ペア)
					continue;

				Getポジション増加数用_Time = (DateTime)TradeFXCM.trades.CellValue(Getポジション増加数_iCnt3, "Time");

				if (Getポジション増加数用_now > Getポジション増加数用_Time)
					continue;

				Getポジション増加数_ポジション数++;
			}

			return Getポジション増加数_ポジション数;
		}


	}
}
