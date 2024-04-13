using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using FXCM;
using Common;
using DB;

/*
namespace Order
{
	public static class OrderC
	{
		private static double 注文設定_売買モード_WMA_15m_WMA前_S2 = 0;
		private static double 注文設定_売買モード_WMA_15m_WMA今_S2 = 0;
		public static bool 注文設定_売買モード_WMA_S2_15m(SqlConnection cn, byte 通貨ペアNo, DateTime now, ref DataGridView dgv注文)
		{
			Indi.GetWMA判定_15m_S2のみ(cn, 通貨ペアNo, now, out 注文設定_売買モード_WMA_15m_WMA前_S2, out 注文設定_売買モード_WMA_15m_WMA今_S2);

			dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.WMA前_15m_S2].Value = 注文設定_売買モード_WMA_15m_WMA前_S2;
			dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.WMA今_15m_S2].Value = 注文設定_売買モード_WMA_15m_WMA今_S2;

			dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.取引状況].Value = "Order対象外（売買モード_WMA_S2_15m）";
			return false;
		}

		public static bool Chk注文対象(byte 通貨ペアNo, DataGridView dgv注文)
		{
			if ((bool)dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.Chk注文].Value == false)
			{
				dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.取引状況].Value = "Order対象外（Chk注文がFalse）";
				return false;
			}

			return true;
		}


		private static Object ポジションをクローズする_sDI;
		private static string sTradeID = "";
		private static object CloseOrderID;
		public static void 全てのポジションをクローズする(SqlConnection cn)
		{
			for (uint iCnt = 1; iCnt <= Trade.trades.RowCount; iCnt++)
			{
				sTradeID = (string)Trade.trades.CellValue(iCnt, "TradeID");

				// 差益がマイナスなTrade、Top1のみクローズ
				Trade.tradeDesk.CloseTrade(sTradeID, (int)Trade.trades.CellValue(iCnt, "Lot"),
					(double)Trade.trades.CellValue(iCnt, "Close"), (string)Trade.trades.CellValue(iCnt, "QuoteID"),
					Cシステム設定.AtMarket, out CloseOrderID, out ポジションをクローズする_sDI);

				oder.UpdateOrderHistory_CloseOrderID(cn, sTradeID, (string)CloseOrderID, "余剰金を確保");
			}
		}

		private static DateTime OrderV1_StartDate;
		private static DateTime OrderV1_Start10m;
		private static byte OrderV1_通貨ペアNo;
		private static double OrderV1_買いRate;
		private static double OrderV1_売りRate;
		private static string OrderV1_QuoteID;
		private static byte OrderV1_注文判定;
		private static byte OrderV1_売買判定;
		private static string OrderV1_WMA判定_15m;
		private static double OrderV1_リミット;
		private static object OrderV1_OrderId;
		private static double OrderV1_余剰金の割合;
		public static void OrderV1(SqlConnection cn)
		{
			double WMA前_15m;
			double WMA今_15m;
			double WMA上昇角度_今;

			OrderV1_StartDate = DateTime.Now;
			OrderV1_Start10m = StartDate.Get10m(OrderV1_now);

			for (OrderV1_通貨ペアNo = 0; OrderV1_通貨ペアNo < Trade.通貨ペア.Length; OrderV1_通貨ペアNo++)
			{
				Trade.通貨ペア情報取得(OrderV1_通貨ペアNo, ref OrderV1_買いRate, ref OrderV1_売りRate, ref OrderV1_QuoteID);

				oder.注文判定OrderD(cn, OrderV1_通貨ペアNo, OrderV1_StartDate, OrderV1_買いRate, OrderV1_売りRate, ref OrderV1_注文判定, ref OrderV1_売買判定);

				if (OrderV1_注文判定 == 1)
				{
					if (Settings.chkポジション更新_成行_をスキップ == false)
					{
						Trade.ポジション更新_成行(OrderV1_売買判定, OrderV1_通貨ペアNo, OrderV1_買いRate, OrderV1_売りRate, Settings.注文単位,
							OrderV1_QuoteID, Settings.AtMarket, out OrderV1_OrderId);

						oder.InsertOrderHistory(cn, OrderV1_通貨ペアNo, OrderV1_StartDate, OrderV1_売買判定, OrderV1_買いRate, OrderV1_売りRate,
							0, "", Settings.注文単位, (string)OrderV1_OrderId, 0);
					}
				}

				if (注文設定_売買モード_WMA_S2_15m(cn, 通貨ペアNo, OrderV1_now, ref dgv注文) == false)
					continue;

				if (((string)dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.取引状況].Value).IndexOf("Order中") < 0)
					continue;

				if (OrderV1_余剰金の割合 < Trade.余剰金割合_Order限界点)
				{
					Settings.txtOrder状況 = "取引停止中（余剰金割合_Order限界点）";
					dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.取引状況].Value = "取引停止中（余剰金割合_Order限界点）";
					continue;
				}
				else
				{
					Settings.txtOrder状況 = "取引中";
				}

			}
		}
	}
}
*/
