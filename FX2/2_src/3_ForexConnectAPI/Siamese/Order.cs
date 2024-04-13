using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;
using DB;
using FXCM;
using Common;

namespace Siamese
{
	public static class Order
	{
		public static bool E_Chk直前でRate相反している(SqlConnection cn, byte 通貨ペアNo, ref DataGridView dgv注文)
		{
			if (rate.Chk直前でRate相反している(cn, 通貨ペアNo, (string)dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.売買判定].Value) == 0)
			{
				dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.取引状況].Value = "Order対象外(直前でRate相反)";
				return false;
			}

			return true;
		}

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

		private static void 前回の判定結果をクリア(byte 通貨ペアNo, DataGridView dgv注文)
		{
			dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.売買判定].Value = "";
			dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.Rate高値_先月].Value = "";
			dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.Rate安値_先月].Value = "";
			dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.危険Rate判定_Monthly].Value = "";
			dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.Rate高値_先週].Value = "";
			dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.Rate安値_先週].Value = "";
			dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.危険Rate判定_Weekly].Value = "";
			dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.Rate高値_先日].Value = "";
			dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.Rate安値_先日].Value = "";
			dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.危険Rate判定_Daily].Value = "";
			dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.Rate高値_30m前].Value = "";
			dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.Rate安値_30m前].Value = "";
			dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.Rate高値_15m前].Value = "";
			dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.Rate安値_15m前].Value = "";
			dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.Rate高値_5m前].Value = "";
			dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.Rate安値_5m前].Value = "";
			dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.高値安値_Monthly].Value = "";
			dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.高値安値_Weekly].Value = "";
			dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.高値安値_Daily].Value = "";
			dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.WMA判定_15m].Value = "";
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

		private static DateTime OrderV1_now;
		private static DateTime OrderV1_Start10m;
		private static string OrderV1_売買判定;
		private static string OrderV1_WMA判定_15m;
		private static int OrderV1_取引単位;
		private static double OrderV1_買いRate;
		private static double OrderV1_売りRate;
		private static double OrderV1_リミット;
		private static object OrderV1_OrderId;
		private static double OrderV1_余剰金の割合;
		public static void OrderV1(SqlConnection cn, DataGridView dgv注文, CheckBox chkRate記録以降の処理をスキップ, 
			CheckBox chkポジション更新_成行_をスキップ, TextBox txtOrder状況)
		{

			byte 通貨ペアNo;
			double シグマ閾値 = 2.5;
			double WMA前_15m;
			double WMA今_15m;
			double WMA上昇角度_今;

			OrderV1_now = DateTime.Now;
			OrderV1_Start10m = StartDate.Get10m(OrderV1_now);

			for (通貨ペアNo = 0; 通貨ペアNo < Trade.通貨ペア.Length; 通貨ペアNo++)
			{
				Trade.通貨ペア別Rate取得(通貨ペアNo, out OrderV1_買いRate, out OrderV1_売りRate);

				前回の判定結果をクリア(通貨ペアNo, dgv注文);

				rate.Update_10m(cn, 通貨ペアNo, OrderV1_Start10m, OrderV1_Start10m.AddMinutes(10));
				Indi.UpdateWMA_10m(cn, 通貨ペアNo, OrderV1_Start10m);
				Indi.UpdateWMA_10mS2(cn, 通貨ペアNo, OrderV1_Start10m);

				if (chkRate記録以降の処理をスキップ.Checked == true)
					continue;

				if (Chk注文対象(通貨ペアNo, dgv注文) == false)
					continue;

				OrderV1_買いRate = (double)dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.買いRate].Value;
				OrderV1_売りRate = (double)dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.売りRate].Value;

				if (double.IsNaN(OrderV1_余剰金の割合) == true)
				{
					txtOrder状況.Text = "取引停止中（IsNaN(余剰金の割合)）";
					dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.取引状況].Value = "取引停止中（IsNaN(余剰金の割合)）";
					continue;
				}

				if ((double)dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.買いRate].Value == 0 ||
					(double)dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.売りRate].Value == 0)
				{
					dgv注文.Rows[通貨ペアNo].DefaultCellStyle.BackColor = Color.SkyBlue;
					dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.取引状況].Value = "Order対象外（Rateが0）";
					continue;
				}

				OrderV1_取引単位 = (int)dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.注文単位].Value;

				if (OrderV1_取引単位 < 1)
				{
					dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.取引状況].Value = "Order対象外（取引単位が1未満）";
					continue;
				}

				if ((string)dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.BonusStage判定_前].Value == "B" ||
					(string)dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.BonusStage判定_今].Value == "B")
				{
					if ((string)dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.保持ポジション].Value != OrderV1_WMA判定_15m)
					{
						dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.取引状況].Value = "Order対象外（逆BonusStage中）";
						continue;
					}
				}

				OrderV1_売買判定 = (string)dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.売買判定].Value;

				if (Order.E_Chk直前でRate相反している(cn, 通貨ペアNo, ref dgv注文) == false)
					continue;

				if (Order.注文設定_売買モード_WMA_S2_15m(cn, 通貨ペアNo, OrderV1_now, ref dgv注文) == false)
					continue;

				if (((string)dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.取引状況].Value).IndexOf("Order中") < 0)
					continue;

				if (OrderV1_余剰金の割合 < Trade.余剰金割合_Order限界点)
				{
					txtOrder状況.Text = "取引停止中（余剰金割合_Order限界点）";
					dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.取引状況].Value = "取引停止中（余剰金割合_Order限界点）";
					continue;
				}
				else
				{
					txtOrder状況.Text = "取引中";
				}

				if (chkポジション更新_成行_をスキップ.Checked == false)
				{
					OrderV1_リミット = (double)dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.リミット].Value;

					Trade.ポジション更新_成行((string)dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.売買判定].Value,
						Trade.通貨ペア[通貨ペアNo], OrderV1_買いRate, OrderV1_売りRate, OrderV1_取引単位,
						OrderV1_リミット, (string)dgv注文.Rows[通貨ペアNo].Cells[DGVClmNo注文.QuoteID].Value,
						out OrderV1_OrderId);

					oder.InsertHistory(cn, 通貨ペアNo, OrderV1_now, OrderV1_売買判定, 0, OrderV1_買いRate, OrderV1_売りRate, "", "",
						OrderV1_取引単位, (string)OrderV1_OrderId, 0);

					hltc.Increment通常Order件数(cn);
				}
			}
		}
	}
}
