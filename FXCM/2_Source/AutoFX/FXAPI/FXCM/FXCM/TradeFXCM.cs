using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using 定数;
using Common;
using DB;

namespace FXCM
{
	public static class TradeFXCM
	{
		public static FXCore.TradeDeskAut tradeDesk;
		public static FXCore.TableAut accounts;
		public static FXCore.TableAut orders;
		public static FXCore.TableAut trades;
		public static FXCore.TableAut offers;
		public static FXCore.TableAut closed;
		public static FXCore.TableAut summary;
		public static string accountId = "";
		public static int minAmount = 0;

        //public static string[] 取引状況;



        public static void ログイン(string connection, string strUsername, string strPassword)
		{
			FXCore.CoreAut fxCore;
			fxCore = new FXCore.CoreAut();

			tradeDesk = (FXCore.TradeDeskAut)fxCore.CreateTradeDesk("trader");
			tradeDesk.Login(strUsername, strPassword, FX定数.URL, connection);
			accounts = (FXCore.TableAut)tradeDesk.FindMainTable("accounts");
			orders = (FXCore.TableAut)tradeDesk.FindMainTable("Orders");
			trades = (FXCore.TableAut)tradeDesk.FindMainTable("Trades");
			offers = (FXCore.TableAut)tradeDesk.FindMainTable("offers");
			closed = (FXCore.TableAut)tradeDesk.FindMainTable("closed trades");
			summary = (FXCore.TableAut)tradeDesk.FindMainTable("Summary");

			accountId = (string)accounts.CellValue(1, "AccountID");
			minAmount = (int)accounts.CellValue(1, "BaseUnitSize");
		}


		public static void Logout()
		{
			if (tradeDesk != null)
			{
				tradeDesk.Logout();
				tradeDesk = null;
			}
		}


		private static Object ポジションをクローズする_sDI;
		public static void ポジションをクローズする(string sTradeID, int iAmount, double dRate, string sQuoteID, int iAtMarket,
			out object sOrderID)
		{
			tradeDesk.CloseTrade(sTradeID, iAmount, dRate, sQuoteID, iAtMarket, out sOrderID, out ポジションをクローズする_sDI);
		}

		public static void ポジション更新(
			bool bBuyShellMode,
			string 通貨ペア,
			string str取引単位,
			string str取引間隔,
			string strリミット,
			string str高値限界Rate,
			string str下値限界Rate,
			string strLogFolder)
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

		/// <summary>
		/// オーダーRateとリミットRateの間に、既にポジションがないかチェック。
		/// ポジションが有ったら注文しない。
		/// </summary>
		/// <returns>
		/// true：ポジション有り
		/// false：ポジション無し
		/// </returns>
		public static bool Chk残ポジション有無(SqlConnection cn, byte 通貨ペアNo, double 買いRate)	// 厳密な比較を必要としないので「買いRate」のみ比較に使う。
		{
			double 注文禁止ポジション間隔 = cmn.Get注文禁止ポジション間隔(cn, 通貨ペアNo);
			double ポジション更新_成行_OrderRate;

			//既にポジションにEntoryが無いか
			for (uint ポジション更新_成行_iCnt = 1; ポジション更新_成行_iCnt <= trades.RowCount; ポジション更新_成行_iCnt++)
			{
				if ((string)trades.CellValue(ポジション更新_成行_iCnt, "Instrument") != FX定数.通貨ペア[通貨ペアNo])
					continue;

				ポジション更新_成行_OrderRate = (double)trades.CellValue(ポジション更新_成行_iCnt, "Open");

				if ((買いRate - 注文禁止ポジション間隔) < ポジション更新_成行_OrderRate && ポジション更新_成行_OrderRate < (買いRate + 注文禁止ポジション間隔))
				{
					return true; // ポジション有り
				}
			}

			return false; // ポジション無し
		}


		private static object ポジション更新_成行_di;
		public static void ポジション更新_成行(bool 売買モード, string 通貨ペア, double 買いRate, double 売りRate, int 注文単位,
			double 買いリミット, double 売りリミット, string quoteId, int AtMarket, out object OrderId)
		{
			if (売買モード == true)
			{
				tradeDesk.OpenTrade2(accountId, 通貨ペア, 売買モード, minAmount * 注文単位, 買いRate, quoteId, AtMarket, tradeDesk.SL_LIMIT, 0,
					買いリミット, 0, out OrderId, out ポジション更新_成行_di);	//成り行き
			}
			else
			{
				tradeDesk.OpenTrade2(accountId, 通貨ペア, 売買モード, minAmount * 注文単位, 売りRate, quoteId, AtMarket, tradeDesk.SL_LIMIT, 0,
					売りリミット, 0, out OrderId, out ポジション更新_成行_di);	//成り行き
			}

		}

		private static double リミット変更_dblEntryRate;
		private static double リミット変更_EntryLimit;
		public static void リミット変更(string TradeID, bool 売買モード, double 買いリミット, double 売りリミット,
			out object リミット変更OrderID)
		{
			if (売買モード == true)
			{
				tradeDesk.ChangeTradeStopLimit2(TradeID, 買いリミット, false, 0, out リミット変更OrderID);
			}
			else
			{
				tradeDesk.ChangeTradeStopLimit2(TradeID, 売りリミット, false, 0, out リミット変更OrderID);
			}
		}

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

		public static bool GetTradeDesk売買モード_toBool(string 売買モード)
		{
			if (売買モード == "B")
			{
				return true;
			}
			else if (売買モード == "S")
			{
				return false;
			}

			return true;
		}

		public static string Get保持ポジション_売買モード;
		public static uint Get保持ポジション_iCnt;
		public static string Get保持ポジション(string 通貨ペア)
		{
			for (Get保持ポジション_iCnt = 1; Get保持ポジション_iCnt <= trades.RowCount; Get保持ポジション_iCnt++)
			{
				if ((string)trades.CellValue(Get保持ポジション_iCnt, "Instrument") != 通貨ペア)
					continue;

				if (GetTradeDesk売買モード_toBool((string)trades.CellValue(Get保持ポジション_iCnt, "BS")) == true)
				{
					Get保持ポジション_売買モード = "B";
				}
				else
				{
					Get保持ポジション_売買モード = "S";
				}

				return Get保持ポジション_売買モード;
			}

			return "";
		}

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

		// ポジションの増加は、1つの通貨ペア辺り、最大1日1ポジションまで
		public static bool Chk24時間以内にポジション有り(byte 通貨ペアNo, DateTime hour24前)
		{
			for (uint Cnt = 1; Cnt <= trades.RowCount; Cnt++)
			{
				if (!((string)trades.CellValue(Cnt, "Instrument")).Equals(FX定数.通貨ペア[通貨ペアNo], StringComparison.Ordinal)) continue;

				if ((DateTime)trades.CellValue(Cnt, "Time") < hour24前) continue;

				return true;
			}

			return false;
		}

		private static int Getポジション数_ポジション数;
		private static uint Getポジション数_Cnt;
		public static int Getポジション数(byte 通貨ペアNo)
		{
			Getポジション数_ポジション数 = 0;
			for (Getポジション数_Cnt = 1; Getポジション数_Cnt <= TradeFXCM.trades.RowCount; Getポジション数_Cnt++)
			{
				if ((string)TradeFXCM.trades.CellValue(Getポジション数_Cnt, "Instrument") != FX定数.通貨ペア[通貨ペアNo])
					continue;
				else
					Getポジション数_ポジション数++;
			}

			return Getポジション数_ポジション数;
		}


	}
}
