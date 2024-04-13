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
		private static DateTime OrderV1_StartDate;
		private static DateTime OrderV1_Start15m;
		private static byte OrderV1_通貨ペアNo;
		private static double OrderV1_買いRate;
		private static double OrderV1_売りRate;
		private static string OrderV1_QuoteID;
		private static byte OrderV1_注文判定;
		private static string OrderV1_売買判定;
		public static void OrderV1(SqlConnection cn)
		{
			string OfferID;
			int WMAs2角度持続時間_過去;
			float WMAs2角度持続Rate_過去;
			short 注文数;
			int 手数料;

			OrderV1_StartDate = DateTime.Now;
			OrderV1_Start15m = StartDate.Get15m(OrderV1_StartDate);

			for (OrderV1_通貨ペアNo = 0; OrderV1_通貨ペアNo < FXCMConst.通貨ペア.Length; OrderV1_通貨ペアNo++)
			{
				//Trade.通貨ペア別Rate取得(OrderV1_通貨ペアNo, out OrderV1_買いRate, out OrderV1_売りRate, out OrderV1_QuoteID, out OfferID);

				oder.注文判定OrderD(cn, OrderV1_通貨ペアNo, OrderV1_StartDate, OrderV1_買いRate, OrderV1_売りRate,
					out OrderV1_注文判定, out OrderV1_売買判定, out WMAs2角度持続時間_過去, out WMAs2角度持続Rate_過去, out 注文数, out 手数料);

				if (OrderV1_注文判定 == 0) continue;

				if (Settings.chkポジション更新_成行_をスキップ == true) continue;

				double dRate;
				if (OrderV1_売買判定 == "B")
				{
					// 買い
					dRate = OrderV1_買いRate;
				}
				else
				{
					// 売り
					dRate = OrderV1_売りRate;
				}

				//Trade.CreateMarketOrder(Trade.mAccount_Order_DemoA.getRow(0).AccountID, OfferID, dRate, OrderV1_売買判定);

				//oder.InsertOrderHistory(cn, OrderV1_通貨ペアNo, OrderV1_StartDate, OrderV1_売買判定, OrderV1_買いRate, OrderV1_売りRate,
				//	0, "", Settings.注文単位, (string)OrderV1_OrderId, 0, WMAs2角度持続時間_過去, WMAs2角度持続Rate_過去, 注文数, 手数料);
			}
		}

		//public static void BonusStage終了_再処理(DateTime n分前)
		//{
		//	for (byte 通貨ペアNo = 0; 通貨ペアNo < Trade.通貨ペア.Length; 通貨ペアNo++)
		//	{

		//		if (CDB_dbo.Chk直近n分以内にボーナスステージ終了有り(通貨ペアNo, n分前) == false)
		//			continue;

		//		Trade.Orderは全てクローズする(Trade.通貨ペア[通貨ペアNo]);

		//	}
		//}

	}
}
