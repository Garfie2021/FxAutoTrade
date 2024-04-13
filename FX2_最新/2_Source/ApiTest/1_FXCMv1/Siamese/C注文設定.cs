using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DB;
using FXCM;
using Common;

namespace Siamese
{
	public static class C注文設定
	{
		public static void 注文設定初期化(int i基準注文単位, ref DataGridView dgv注文設定)
		{
			for (byte 通貨ペアNo = 0; 通貨ペアNo < FXCMConst.通貨ペア名List.Length; 通貨ペアNo++)
			{
				// 初期値を設定しておく事で、Valueの型も確定させ、バグ防止にもなる //
				dgv注文設定.Rows.Add();
				dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.通貨ペア].Value = FXCMConst.通貨ペア名List[通貨ペアNo];
				dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.取引状況].Value = "";
				dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.Chkデータ生成].Value = false;
				dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.Chk注文].Value = false;
				dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.保持ポジション].Value = "";
				dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.買いSwap].Value = 0;
				dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.売りSwap].Value = 0;
				dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.Swap判定].Value = "";
				dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.WMA_Monthly].Value = "";
				dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.WMA判定_Monthly].Value = "";
				dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.WMA角度前_Monthly].Value = 0;
				dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.WMA角度今_Monthly].Value = 0;
				dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.WMA角度判定_Monthly].Value = "";
				dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.危険Rate判定_Monthly].Value = "";
				dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.売買判定].Value = "";
				dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.WMA判定_15m].Value = "";
				dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.BonusStage判定_前].Value = "";
				dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.BonusStage判定_今].Value = "";
				dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.注文単位].Value = i基準注文単位;
				dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.ポジション数].Value = 0;
				dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.ポジション増加数].Value = 0;
				dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.平均差損益減少数].Value = 0;
				dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.Order間隔最小値].Value = 0.0;
				dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.Order間隔].Value = 0.0;
				dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.リミット].Value = 0;
				dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.売りRate].Value = 0;
				dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.買いRate].Value = 0;
				dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.当日Close].Value = 0;
				dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.維持証拠金].Value = 0;
				dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.維持証拠金小計].Value = 0;
				dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.GrossPL小計].Value = 0;
				dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.QuoteID].Value = "";
			}
		}

		public static void 注文設定_データ生成Chk_FX(ref DataGridView dgv)
		{
			dgv.Rows[FXCMConst.DGVRowNo_AUD_CAD].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_AUD_CHF].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_AUD_JPY].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_AUD_NZD].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_AUD_USD].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_CAD_CHF].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_CAD_JPY].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_CHF_JPY].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_EUR_AUD].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_EUR_CAD].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_EUR_CHF].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_EUR_GBP].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_EUR_JPY].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_EUR_NZD].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_EUR_TRY].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_EUR_USD].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_GBP_AUD].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_GBP_CAD].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_GBP_CHF].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_GBP_JPY].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_GBP_NZD].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_GBP_USD].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_NZD_CAD].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_NZD_CHF].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_NZD_JPY].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_NZD_USD].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_TRY_JPY].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_USD_CAD].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_USD_CHF].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_USD_HKD].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_USD_JPY].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_USD_TRY].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_USD_ZAR].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_ZAR_JPY].Cells[DGVClmNo注文.Chkデータ生成].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_XAU_USD].Cells[DGVClmNo注文.Chkデータ生成].Value = false;
			dgv.Rows[FXCMConst.DGVRowNo_JPN225].Cells[DGVClmNo注文.Chkデータ生成].Value = false;
			dgv.Rows[FXCMConst.DGVRowNo_US30].Cells[DGVClmNo注文.Chkデータ生成].Value = false;
			dgv.Rows[FXCMConst.DGVRowNo_USOil].Cells[DGVClmNo注文.Chkデータ生成].Value = false;
		}

		public static void 注文設定_注文Chk_Real_FX(ref DataGridView dgv)
		{
			dgv.Rows[FXCMConst.DGVRowNo_AUD_CAD].Cells[DGVClmNo注文.Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_AUD_CHF].Cells[DGVClmNo注文.Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_AUD_JPY].Cells[DGVClmNo注文.Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_AUD_NZD].Cells[DGVClmNo注文.Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_AUD_USD].Cells[DGVClmNo注文.Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_CAD_CHF].Cells[DGVClmNo注文.Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_CAD_JPY].Cells[DGVClmNo注文.Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_CHF_JPY].Cells[DGVClmNo注文.Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_EUR_AUD].Cells[DGVClmNo注文.Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_EUR_CAD].Cells[DGVClmNo注文.Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_EUR_CHF].Cells[DGVClmNo注文.Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_EUR_GBP].Cells[DGVClmNo注文.Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_EUR_JPY].Cells[DGVClmNo注文.Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_EUR_NZD].Cells[DGVClmNo注文.Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_EUR_TRY].Cells[DGVClmNo注文.Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_EUR_USD].Cells[DGVClmNo注文.Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_GBP_AUD].Cells[DGVClmNo注文.Chk注文].Value = true;	//レートの動きが危険
			dgv.Rows[FXCMConst.DGVRowNo_GBP_CAD].Cells[DGVClmNo注文.Chk注文].Value = true;	//レートの動きが危険
			dgv.Rows[FXCMConst.DGVRowNo_GBP_CHF].Cells[DGVClmNo注文.Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_GBP_JPY].Cells[DGVClmNo注文.Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_GBP_NZD].Cells[DGVClmNo注文.Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_GBP_USD].Cells[DGVClmNo注文.Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_NZD_CAD].Cells[DGVClmNo注文.Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_NZD_CHF].Cells[DGVClmNo注文.Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_NZD_JPY].Cells[DGVClmNo注文.Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_NZD_USD].Cells[DGVClmNo注文.Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_TRY_JPY].Cells[DGVClmNo注文.Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_USD_CAD].Cells[DGVClmNo注文.Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_USD_CHF].Cells[DGVClmNo注文.Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_USD_HKD].Cells[DGVClmNo注文.Chk注文].Value = true;	//必ずマイナスになる
			dgv.Rows[FXCMConst.DGVRowNo_USD_JPY].Cells[DGVClmNo注文.Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_USD_TRY].Cells[DGVClmNo注文.Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_USD_ZAR].Cells[DGVClmNo注文.Chk注文].Value = false;	//必ずマイナスになる
			dgv.Rows[FXCMConst.DGVRowNo_ZAR_JPY].Cells[DGVClmNo注文.Chk注文].Value = false;	//必ずマイナスになる
			dgv.Rows[FXCMConst.DGVRowNo_XAU_USD].Cells[DGVClmNo注文.Chk注文].Value = false;
			dgv.Rows[FXCMConst.DGVRowNo_JPN225].Cells[DGVClmNo注文.Chk注文].Value = false;
			dgv.Rows[FXCMConst.DGVRowNo_US30].Cells[DGVClmNo注文.Chk注文].Value = false;
			dgv.Rows[FXCMConst.DGVRowNo_USOil].Cells[DGVClmNo注文.Chk注文].Value = false;
		}

		public static void 注文設定_注文Chk_Demo_FX(ref DataGridView dgv)
		{
			dgv.Rows[FXCMConst.DGVRowNo_AUD_CAD].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_AUD_CHF].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_AUD_JPY].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_AUD_NZD].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_AUD_USD].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_CAD_CHF].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_CAD_JPY].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_CHF_JPY].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_EUR_AUD].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_EUR_CAD].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_EUR_CHF].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_EUR_GBP].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_EUR_JPY].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_EUR_NZD].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_EUR_TRY].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_EUR_USD].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_GBP_AUD].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = true;	//レートの動きが危険
			dgv.Rows[FXCMConst.DGVRowNo_GBP_CAD].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = true;	//レートの動きが危険
			dgv.Rows[FXCMConst.DGVRowNo_GBP_CHF].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_GBP_JPY].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_GBP_NZD].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_GBP_USD].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_NZD_CAD].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_NZD_CHF].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_NZD_JPY].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_NZD_USD].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_TRY_JPY].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_USD_CAD].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_USD_CHF].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_USD_HKD].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = true;	//必ずマイナスになる
			dgv.Rows[FXCMConst.DGVRowNo_USD_JPY].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_USD_TRY].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = true;
			dgv.Rows[FXCMConst.DGVRowNo_USD_ZAR].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = false;	//必ずマイナスになる
			dgv.Rows[FXCMConst.DGVRowNo_ZAR_JPY].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = false;	//必ずマイナスになる
			dgv.Rows[FXCMConst.DGVRowNo_XAU_USD].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = false;
			dgv.Rows[FXCMConst.DGVRowNo_JPN225].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = false;
			dgv.Rows[FXCMConst.DGVRowNo_US30].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = false;
			dgv.Rows[FXCMConst.DGVRowNo_USOil].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = false;
		}

		public static void 注文基本設定(int i基準注文単位, ref DataGridView dgv注文設定)
		{
			for (byte 通貨ペアNo = 0; 通貨ペアNo < FXCMConst.通貨ペア名List.Length; 通貨ペアNo++)
			{
				// 初期値を設定しておく事で、Valueの型も確定させ、バグ防止にもなる //
				dgv注文設定.Rows.Add();
				dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_通貨ペア].Value = FXCMConst.通貨ペア名List[通貨ペアNo];
				dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_取引状況].Value = "";
				dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_Chkデータ生成].Value = false;
				dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_Chk注文].Value = false;
				dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_保持ポジション].Value = "";
				dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_買いSwap].Value = 0;
				dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_売りSwap].Value = 0;
				dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_Swap判定].Value = "";
				dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_WMA_Monthly].Value = "";
				dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_WMA判定_Monthly].Value = "";
				dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_WMA角度前_Monthly].Value = 0;
				dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_WMA角度今_Monthly].Value = 0;
				dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_WMA角度判定_Monthly].Value = "";
				dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_危険Rate判定_Monthly].Value = "";
				dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_売買判定].Value = "";
				dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_WMA判定_15m].Value = "";
				dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_BonusStage判定_前].Value = "";
				dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_BonusStage判定_今].Value = "";
				dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_注文単位].Value = i基準注文単位;
				dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_ポジション数].Value = 0;
				dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_ポジション増加数].Value = 0;
				dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_平均差損益減少数].Value = 0;
				dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_Order間隔最小値].Value = 0.0;
				dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_Order間隔].Value = 0.0;
				dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_リミット].Value = 0;
				dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_売りRate].Value = 0;
				dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_買いRate].Value = 0;
				dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_当日Close].Value = 0;
				dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 0;
				dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_維持証拠金小計].Value = 0;
				dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_GrossPL小計].Value = 0;
				dgv注文設定.Rows[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_QuoteID].Value = "";
			}

			維持証拠金を設定(ref dgv注文設定);
		}

		public static void 維持証拠金を設定(ref DataGridView dgv)
		{
			dgv.Rows[FXCMConst.DGVRowNo_AUD_CAD].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 4800;
			dgv.Rows[FXCMConst.DGVRowNo_AUD_CHF].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 4800;
			dgv.Rows[FXCMConst.DGVRowNo_AUD_JPY].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 4800;
			dgv.Rows[FXCMConst.DGVRowNo_AUD_NZD].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 4800;
			dgv.Rows[FXCMConst.DGVRowNo_CAD_JPY].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 4800;
			dgv.Rows[FXCMConst.DGVRowNo_AUD_USD].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 4800;
			dgv.Rows[FXCMConst.DGVRowNo_CAD_CHF].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 4800;
			dgv.Rows[FXCMConst.DGVRowNo_CHF_JPY].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 4800;
			dgv.Rows[FXCMConst.DGVRowNo_EUR_AUD].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 6000;
			dgv.Rows[FXCMConst.DGVRowNo_EUR_CAD].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 6000;
			dgv.Rows[FXCMConst.DGVRowNo_EUR_CHF].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 6000;
			dgv.Rows[FXCMConst.DGVRowNo_EUR_GBP].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 6000;
			dgv.Rows[FXCMConst.DGVRowNo_EUR_JPY].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 6000;
			dgv.Rows[FXCMConst.DGVRowNo_EUR_NZD].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 6000;
			dgv.Rows[FXCMConst.DGVRowNo_EUR_USD].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 6000;
			dgv.Rows[FXCMConst.DGVRowNo_EUR_TRY].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 4800;
			dgv.Rows[FXCMConst.DGVRowNo_GBP_AUD].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 7200;
			dgv.Rows[FXCMConst.DGVRowNo_GBP_CAD].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 7200;
			dgv.Rows[FXCMConst.DGVRowNo_GBP_CHF].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 7200;
			dgv.Rows[FXCMConst.DGVRowNo_GBP_JPY].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 7200;
			dgv.Rows[FXCMConst.DGVRowNo_GBP_NZD].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 7200;
			dgv.Rows[FXCMConst.DGVRowNo_GBP_USD].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 7200;
			dgv.Rows[FXCMConst.DGVRowNo_NZD_CAD].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 4000;
			dgv.Rows[FXCMConst.DGVRowNo_NZD_CHF].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 4000;
			dgv.Rows[FXCMConst.DGVRowNo_NZD_JPY].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 4000;
			dgv.Rows[FXCMConst.DGVRowNo_NZD_USD].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 4000;
			dgv.Rows[FXCMConst.DGVRowNo_TRY_JPY].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 2600;
			dgv.Rows[FXCMConst.DGVRowNo_USD_CAD].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 4800;
			dgv.Rows[FXCMConst.DGVRowNo_USD_CHF].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 4800;
			dgv.Rows[FXCMConst.DGVRowNo_USD_HKD].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 4800;
			dgv.Rows[FXCMConst.DGVRowNo_USD_JPY].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 4800;
			dgv.Rows[FXCMConst.DGVRowNo_USD_TRY].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 4800;
			dgv.Rows[FXCMConst.DGVRowNo_USD_ZAR].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 4800;
			dgv.Rows[FXCMConst.DGVRowNo_ZAR_JPY].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 600;
			dgv.Rows[FXCMConst.DGVRowNo_XAU_USD].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 8500;
			dgv.Rows[FXCMConst.DGVRowNo_JPN225].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 280000;
			dgv.Rows[FXCMConst.DGVRowNo_US30].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 170000;
			dgv.Rows[FXCMConst.DGVRowNo_USOil].Cells[C共通.DGVClmNo注文設定_維持証拠金].Value = 100000;
		}

	}
}
