using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using SystemCommon;
using 定数;
using Common;
using FXCM;
using DB;

namespace AutoFx_Form
{
	public static class FormCommon
	{
		public static byte 注文設定_ポジション数_更新用_通貨ペアNo;
		public static void 注文設定_ポジション数_更新(ref DataGridView dgv注文設定)
		{
			for (注文設定_ポジション数_更新用_通貨ペアNo = 0; 注文設定_ポジション数_更新用_通貨ペアNo < FX定数.通貨ペア.Length; 注文設定_ポジション数_更新用_通貨ペアNo++)
			{
				if (FormCommon.Chk注文設定_データ生成Chk(注文設定_ポジション数_更新用_通貨ペアNo, ref dgv注文設定) == false)
					continue;

				dgv注文設定.Rows[注文設定_ポジション数_更新用_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_ポジション数].Value = TradeFXCM.Getポジション数(注文設定_ポジション数_更新用_通貨ペアNo);
			}
		}


		private static byte 注文設定_ポジション増加数_更新用_通貨ペアNo;
		public static void 注文設定_ポジション増加数_更新(ref DataGridView dgv注文設定)
		{
			for (注文設定_ポジション増加数_更新用_通貨ペアNo = 0; 注文設定_ポジション増加数_更新用_通貨ペアNo < FX定数.通貨ペア.Length; 注文設定_ポジション増加数_更新用_通貨ペアNo++)
			{
				if (FormCommon.Chk注文設定_データ生成Chk(注文設定_ポジション増加数_更新用_通貨ペアNo, ref dgv注文設定) == false)
					continue;

				dgv注文設定.Rows[注文設定_ポジション増加数_更新用_通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_ポジション増加数].Value
					= Fxcm共通.Getポジション増加数(FX定数.通貨ペア[注文設定_ポジション増加数_更新用_通貨ペアNo]);
			}
		}

		public static void Order間隔最小値_リミット_更新(SqlConnection cn, byte 通貨ペアNo, string 売買モード, double 買いRate, double 売りRate,
			ref double 買いリミット, ref double 売りリミット, ref DataGridView dgv注文設定)
		{
			double 差分リミット;
			cmn.Get差分リミット(cn, 通貨ペアNo, out 差分リミット);

			if (売買モード == "B")
			{
				買いリミット = 買いRate + 差分リミット;
				dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_リミット].Value = 買いリミット;
			}
			else
			{
				売りリミット = 売りRate - 差分リミット;
				dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_リミット].Value = 売りリミット;
			}
		}

		public static bool Chk注文設定_データ生成Chk(byte 通貨ペアNo, ref DataGridView dgv注文設定)
		{
			if ((bool)dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value == false)
			{
				dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_取引状況].Value = "Order対象外（データ生成ChkがFalse）";
				return false;
			}

			return true;
		}

		public static bool Chk注文設定_Chk注文(byte 通貨ペアNo, ref DataGridView dgv注文設定)
		{
			if ((bool)dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value == false)
			{
				dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_取引状況].Value = "Order対象外（Chk注文がFalse）";
				return false;
			}

			return true;
		}

		private static double 注文設定_買いSwap;
		private static double 注文設定_売りSwap;
		public static bool 注文設定_Swap判定(SqlConnection cn, byte 通貨ペアNo, ref string Swap判定, ref DataGridView dgv注文設定)
		{
			注文設定_買いSwap = (double)dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_買いSwap].Value;
			注文設定_売りSwap = (double)dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_売りSwap].Value;

			if (注文設定_買いSwap == 0 && 注文設定_売りSwap == 0)
			{
				swap.Get売買Swapがどちらも0になる前のSwap(cn, 通貨ペアNo, out 注文設定_買いSwap, out 注文設定_売りSwap);
			}

			if (注文設定_買いSwap == 0 && 注文設定_売りSwap == 0)
			{
				Swap判定 = "";
				dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_Swap判定].Value = "";
				dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_取引状況].Value = "Order対象外（Swap判定できず）";
				return false;
			}

			if (注文設定_買いSwap > 注文設定_売りSwap)
			{
				Swap判定 = "B";
				dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_Swap判定].Value = Swap判定;

				if (注文設定_買いSwap < 0)
				{
					dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_取引状況].Value = "Order対象外（Swapマイナス）買";
					return false;
				}
			}
			else
			{
				Swap判定 = "S";
				dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_Swap判定].Value = Swap判定;

				if (注文設定_売りSwap < 0)
				{
					dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_取引状況].Value = "Order対象外（Swapマイナス）売";
					return false;
				}
			}

			return true;
		}

		public static bool A_取引状況エラー判定(byte 通貨ペアNo, ref DataGridView dgv注文設定)
		{
			if ((string)dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_Swap判定].Value == "" ||
				(string)dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_Swap判定].Value == "不明")
			{
				dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_取引状況].Value = "Order対象外（Swap判定が不明）";
				return false;
			}

			if ((double)dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_買いRate].Value == 0.0 ||
				(double)dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_売りRate].Value == 0.0)
			{
				dgv注文設定.Rows[通貨ペアNo].DefaultCellStyle.BackColor = Color.SkyBlue;
				dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_取引状況].Value = "Order対象外（Rateが0）";
				return false;
			}

			return true;
		}

		private static bool B_逆ポジションの有る通貨ペアを算出_bBuyShellMode;
		private static double B_逆ポジションの有る通貨ペアを算出_Month1_買いWMAs2;
		private static double B_逆ポジションの有る通貨ペアを算出_Month1_買いWMAs14;
		private static double B_逆ポジションの有る通貨ペアを算出_Month1_売りWMAs2;
		private static double B_逆ポジションの有る通貨ペアを算出_Month1_売りWMAs14;
		private static double B_逆ポジションの有る通貨ペアを算出_Month1_買いWMAs2角度;
		private static double B_逆ポジションの有る通貨ペアを算出_Month1_売りWMAs2角度;
		private static double B_逆ポジションの有る通貨ペアを算出_Week1_買いWMAs2;
		private static double B_逆ポジションの有る通貨ペアを算出_Week1_買いWMAs14;
		private static double B_逆ポジションの有る通貨ペアを算出_Week1_売りWMAs2;
		private static double B_逆ポジションの有る通貨ペアを算出_Week1_売りWMAs14;
		private static double B_逆ポジションの有る通貨ペアを算出_Week1_買いWMAs2角度;
		private static double B_逆ポジションの有る通貨ペアを算出_Week1_売りWMAs2角度;
		private static double B_逆ポジションの有る通貨ペアを算出_Day1_買いWMAs2;
		private static double B_逆ポジションの有る通貨ペアを算出_Day1_買いWMAs14;
		private static double B_逆ポジションの有る通貨ペアを算出_Day1_売りWMAs2;
		private static double B_逆ポジションの有る通貨ペアを算出_Day1_売りWMAs14;
		private static double B_逆ポジションの有る通貨ペアを算出_Day1_買いWMAs2角度;
		private static double B_逆ポジションの有る通貨ペアを算出_Day1_売りWMAs2角度;
		public static bool B_逆ポジションの有る通貨ペアを算出(SqlConnection cn, byte 通貨ペアNo, Color BackColorLv1, Color BackColorLv2,
			DateTime StartMonth1, DateTime StartWeek1, DateTime StartDay1, 
			ref DataGridView dgv注文設定)
		{
			B_逆ポジションの有る通貨ペアを算出_bBuyShellMode = 注文共通.GetBool売買((string)dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_Swap判定].Value);

			if (TradeFXCM.Chk逆ポジション(FX定数.通貨ペア[通貨ペアNo], B_逆ポジションの有る通貨ペアを算出_bBuyShellMode) == false)
				return true;

			oder.GetWMA_Month1(cn, 通貨ペアNo, StartMonth1,
				ref B_逆ポジションの有る通貨ペアを算出_Month1_買いWMAs2, ref B_逆ポジションの有る通貨ペアを算出_Month1_買いWMAs14, ref B_逆ポジションの有る通貨ペアを算出_Month1_買いWMAs2角度,
				ref B_逆ポジションの有る通貨ペアを算出_Month1_売りWMAs2, ref B_逆ポジションの有る通貨ペアを算出_Month1_売りWMAs14, ref B_逆ポジションの有る通貨ペアを算出_Month1_売りWMAs2角度);

			oder.GetWMA_Week1(cn, 通貨ペアNo, StartWeek1,
				ref B_逆ポジションの有る通貨ペアを算出_Week1_買いWMAs2, ref B_逆ポジションの有る通貨ペアを算出_Week1_買いWMAs14, ref B_逆ポジションの有る通貨ペアを算出_Week1_買いWMAs2角度,
				ref B_逆ポジションの有る通貨ペアを算出_Week1_売りWMAs2, ref B_逆ポジションの有る通貨ペアを算出_Week1_売りWMAs14, ref B_逆ポジションの有る通貨ペアを算出_Week1_売りWMAs2角度);

			oder.GetWMA_Day1(cn, 通貨ペアNo, StartDay1,
				ref B_逆ポジションの有る通貨ペアを算出_Day1_買いWMAs2, ref B_逆ポジションの有る通貨ペアを算出_Day1_買いWMAs14, ref B_逆ポジションの有る通貨ペアを算出_Day1_買いWMAs2角度,
				ref B_逆ポジションの有る通貨ペアを算出_Day1_売りWMAs2, ref B_逆ポジションの有る通貨ペアを算出_Day1_売りWMAs14, ref B_逆ポジションの有る通貨ペアを算出_Day1_売りWMAs2角度);

			if (B_逆ポジションの有る通貨ペアを算出_bBuyShellMode == true)
			{
				dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_取引状況].Value = "Order対象外(Swapに対して逆ポジション有り)買";

				if (B_逆ポジションの有る通貨ペアを算出_Month1_売りWMAs2 < B_逆ポジションの有る通貨ペアを算出_Month1_売りWMAs14 && B_逆ポジションの有る通貨ペアを算出_Month1_売りWMAs2角度 < 0 &&
					B_逆ポジションの有る通貨ペアを算出_Week1_売りWMAs2 < B_逆ポジションの有る通貨ペアを算出_Week1_売りWMAs14 && B_逆ポジションの有る通貨ペアを算出_Week1_売りWMAs2角度 < 0 &&
					B_逆ポジションの有る通貨ペアを算出_Day1_売りWMAs2 < B_逆ポジションの有る通貨ペアを算出_Day1_売りWMAs14 && B_逆ポジションの有る通貨ペアを算出_Day1_売りWMAs2角度 < 0)
				{
					// 保持ポジションが買で、Swap判定が売、RateのGC判定が売
					dgv注文設定.Rows[通貨ペアNo].DefaultCellStyle.BackColor = BackColorLv2;
				}
				else
				{
					// 保持ポジションが買で、Swap判定が売、RateのGC判定が買
					dgv注文設定.Rows[通貨ペアNo].DefaultCellStyle.BackColor = BackColorLv1;
				}
			}
			else
			{
				dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_取引状況].Value = "Order対象外(Swapに対して逆ポジション有り)売";

				if (B_逆ポジションの有る通貨ペアを算出_Month1_買いWMAs2 > B_逆ポジションの有る通貨ペアを算出_Month1_買いWMAs14 && B_逆ポジションの有る通貨ペアを算出_Month1_買いWMAs2角度 > 0 &&
					B_逆ポジションの有る通貨ペアを算出_Week1_買いWMAs2 > B_逆ポジションの有る通貨ペアを算出_Week1_買いWMAs14 && B_逆ポジションの有る通貨ペアを算出_Week1_買いWMAs2角度 > 0 &&
					B_逆ポジションの有る通貨ペアを算出_Day1_買いWMAs2 > B_逆ポジションの有る通貨ペアを算出_Day1_買いWMAs14 && B_逆ポジションの有る通貨ペアを算出_Day1_買いWMAs2角度 > 0)
				{
					// 保持ポジションが売で、Swap判定が買、RateのGC判定が買
					dgv注文設定.Rows[通貨ペアNo].DefaultCellStyle.BackColor = BackColorLv2;
				}
				else
				{
					// 保持ポジションが売で、Swap判定が買、RateのGC判定が売
					dgv注文設定.Rows[通貨ペアNo].DefaultCellStyle.BackColor = BackColorLv1;
				}
			}

			return false;
		}

		public static void 維持証拠金小計_更新(ref DataGridView dgv注文設定)
		{
			for (int 通貨ペアNo = 0; 通貨ペアNo < dgv注文設定.RowCount; 通貨ペアNo++)
			{
				dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_維持証拠金小計].Value =
					(int)dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_ポジション数].Value *
					(int)dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value;
			}
		}

		public static void BS終了_再処理(SqlConnection cn, DateTime n分前, ref DataGridView dgv注文設定)
		{
			for (byte 通貨ペアNo = 0; 通貨ペアNo < FX定数.通貨ペア.Length; 通貨ペアNo++)
			{
				if ((string)dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_保持ポジション].Value == "")
					continue;

				if ((string)dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_BS判定_前].Value == "B" ||
					(string)dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_BS判定_今].Value == "B")
					continue;

				if (oder.Chk直近n分以内にボーナスステージ終了有り(cn, 通貨ペアNo, n分前) == false)
					continue;

				Fxcm共通.利益が出ているOrderは全てクローズする(cn, FX定数.通貨ペア[通貨ペアNo], "Bonus Stage 終了 利益あり");

				double 買いリミット, 売りリミット;
				cmn.Getリミット_BS終了時(cn, 通貨ペアNo, out 買いリミット, out 売りリミット);

				Fxcm共通.保持ポジションのリミット初期化_BS終了時(cn, FX定数.通貨ペア[通貨ペアNo],
					注文共通.GetBool売買((string)dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_Swap判定].Value),
					買いリミット, 売りリミット);
			}
		}

	}
}