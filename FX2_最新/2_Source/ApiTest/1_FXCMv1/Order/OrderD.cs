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
	public static class OrderD
	{
		//private static DateTime OrderV1注文_Start15m;
		private static byte OrderV1注文_通貨ペアNo;
		private static double OrderV1注文_買いRate;
		private static double OrderV1注文_売りRate;
		private static string OrderV1注文_QuoteID;
		private static byte OrderV1注文_注文判定;
		private static byte OrderV1注文_売買判定;
		private static object OrderV1注文_OpenOrderID;
		private static DateTime OrderV1注文_Close予定Date;
		private static short OrderV1注文_注文数;
		private static int OrderV1注文_手数料;
		public static void OrderV1注文(SqlConnection cn, bool Rate記録以降の処理をスキップ, bool 期間別Rate計算以降の処理をスキップ,
			bool ポジション更新_成行_をスキップ, DateTime Now)
		{
			//OrderV1注文_Start15m = Start.Get15m(Now);

			for (OrderV1注文_通貨ペアNo = 0; OrderV1注文_通貨ペアNo < FXCMConst.通貨ペア名List.Length; OrderV1注文_通貨ペアNo++)
			{
				if (FXCMConst.通貨ペア無効List[OrderV1注文_通貨ペアNo])
				{
					continue;	// FXCMで無効になった通貨ペアは飛ばす。
				}

				if (Trade_Order.GetRate(OrderV1注文_通貨ペアNo, ref OrderV1注文_買いRate, ref OrderV1注文_売りRate, ref OrderV1注文_QuoteID) == false)
				{
					continue;	// Rateに異常が見つかった通貨ペアは飛ばす。
				}

				oder.注文判定(cn, Rate記録以降の処理をスキップ, 期間別Rate計算以降の処理をスキップ,
					OrderV1注文_通貨ペアNo, Now, OrderV1注文_買いRate, OrderV1注文_売りRate,
					out OrderV1注文_注文判定, out OrderV1注文_売買判定, out OrderV1注文_Close予定Date, out OrderV1注文_注文数, out OrderV1注文_手数料);

				if (Rate記録以降の処理をスキップ == true) continue;
				if (期間別Rate計算以降の処理をスキップ == true) continue;
				if (ポジション更新_成行_をスキップ == true) continue;

				if (OrderV1注文_注文判定 == 0) continue;

				Trade_Order.ポジション更新_成行(OrderV1注文_売買判定, OrderV1注文_通貨ペアNo, OrderV1注文_注文数,
					OrderV1注文_買いRate, OrderV1注文_売りRate, OrderV1注文_QuoteID, ref OrderV1注文_OpenOrderID);

				oder.InsertOrderHistory(cn, OrderV1注文_通貨ペアNo, Now, OrderV1注文_売買判定, 
					OrderV1注文_買いRate, OrderV1注文_売りRate, OrderV1注文_注文数, OrderV1注文_Close予定Date, OrderV1注文_OpenOrderID);
			}

			Trade_Order.TradesDB登録(cn);
		}

		//private static List<string> OrderV1ポジションクローズ_OrderList;
		//private static object OrderV1ポジションクローズ_OrderID;
		//public static void OrderV1ポジションクローズ(SqlConnection cn, DateTime StartDate)
		//{
		//	OrderV1ポジションクローズ_OrderList = new List<string>();

		//	// 通貨ペアを問わず、orderの口座で、注文してから15分以上経過しているポジションの一覧を抽出し、纏めてクローズする。
		//	oder.クローズ対象ポジション取得(cn, StartDate, ref OrderV1ポジションクローズ_OrderList);

		//	foreach (string TradeID in OrderV1ポジションクローズ_OrderList)
		//	{
		//		Trade_Order.ポジションをクローズ(TradeID, ref OrderV1ポジションクローズ_OrderID);

		//		if (OrderV1ポジションクローズ_OrderID == null) continue;

		//		oder.UpdateOrderHistory_CloseOrderID(cn, TradeID, (string)OrderV1ポジションクローズ_OrderID);
		//	}

		//	Trade_Order.ClosedTradesDB登録(cn, StartDate);
		//}

	}
}
