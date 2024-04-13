using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using FXCM;
using Common;
using DB;

namespace Order
{
	public static class OrderB
	{
		/*
		private static DateTime OrderV1_StartDate;
		private static DateTime OrderV1_Start15m;
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
			OrderV1_Start15m = StartDate.Get15m(OrderV1_StartDate);

			for (OrderV1_通貨ペアNo = 0; OrderV1_通貨ペアNo < Trade.通貨ペア.Length; OrderV1_通貨ペアNo++)
			{
				Trade.通貨ペア情報取得(OrderV1_通貨ペアNo, ref OrderV1_買いRate, ref OrderV1_売りRate, ref OrderV1_QuoteID);

				oder.注文判定v1(cn, OrderV1_通貨ペアNo, OrderV1_StartDate, OrderV1_買いRate, OrderV1_売りRate, ref OrderV1_注文判定, ref OrderV1_売買判定);

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
		 */
	}
}
