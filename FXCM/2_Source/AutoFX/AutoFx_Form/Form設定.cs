using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using SystemCommon;
using 定数;
using Common;
using FXCM;

namespace AutoFx_Form
{
    public static class Form設定
    {
        public static void 注文設定DGV初期化(ref DataGridView dgv)
        {
            注文基本設定(ref dgv);
            維持証拠金を設定(ref dgv);
            注文設定_データ生成Chk_FX(ref dgv);
            注文設定_注文Chk_FX(ref dgv);

            //奇数行を黄色にする
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
        }

        private static void 注文基本設定(ref DataGridView dgv注文設定)
        {
            for (byte 通貨ペアNo = 0; 通貨ペアNo < FX定数.通貨ペア.Length; 通貨ペアNo++)
            {
                // 初期値を設定しておく事で、Valueの型も確定させ、バグ防止にもなる //
                dgv注文設定.Rows.Add();
                dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_通貨ペア].Value = FX定数.通貨ペア[通貨ペアNo];
                dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_取引状況].Value = "";
                dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = false;
                dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;
                dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_保持ポジション].Value = "";
                dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_買いSwap].Value = 0.0;
                dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_売りSwap].Value = 0.0;
                dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_Swap判定].Value = "";
                dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_WMA判定_15m].Value = "";
                dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_BS判定_前].Value = "";
                dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_BS判定_今].Value = "";
                dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_ポジション数].Value = 0;
                dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_ポジション増加数].Value = 0;
                dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_リミット].Value = 0.0;
                dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_売りRate].Value = 0.0;
                dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_買いRate].Value = 0.0;
                dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 0.0;
                dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_維持証拠金小計].Value = 0.0;
                dgv注文設定.Rows[通貨ペアNo].Cells[Form定数.DGVClmNo注文設定_QuoteID].Value = "";
            }
        }

        private static void 維持証拠金を設定(ref DataGridView dgv)
        {
            dgv.Rows[FX定数.No_AUD_CAD].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 4800;
            dgv.Rows[FX定数.No_AUD_CHF].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 4800;
            dgv.Rows[FX定数.No_AUD_JPY].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 4800;
            dgv.Rows[FX定数.No_AUD_NZD].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 4800;
            dgv.Rows[FX定数.No_CAD_JPY].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 4800;
            dgv.Rows[FX定数.No_AUD_USD].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 4800;
            dgv.Rows[FX定数.No_CAD_CHF].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 4800;
            dgv.Rows[FX定数.No_CHF_JPY].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 4800;
            dgv.Rows[FX定数.No_EUR_AUD].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 6000;
            dgv.Rows[FX定数.No_EUR_CAD].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 6000;
            dgv.Rows[FX定数.No_EUR_CHF].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 6000;
            dgv.Rows[FX定数.No_EUR_CZK].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 6000;
            dgv.Rows[FX定数.No_EUR_GBP].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 6000;
            dgv.Rows[FX定数.No_EUR_JPY].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 6000;
            dgv.Rows[FX定数.No_EUR_NOK].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 6000;
            dgv.Rows[FX定数.No_EUR_NZD].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 6000;
            dgv.Rows[FX定数.No_EUR_SEK].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 6000;
            dgv.Rows[FX定数.No_EUR_TRY].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 4800;
            dgv.Rows[FX定数.No_EUR_USD].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 6000;
            dgv.Rows[FX定数.No_GBP_AUD].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 7200;
            dgv.Rows[FX定数.No_GBP_CAD].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 7200;
            dgv.Rows[FX定数.No_GBP_CHF].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 7200;
            dgv.Rows[FX定数.No_GBP_JPY].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 7200;
            dgv.Rows[FX定数.No_GBP_NZD].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 7200;
            dgv.Rows[FX定数.No_GBP_USD].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 7200;
            dgv.Rows[FX定数.No_HKD_JPY].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 700;
            dgv.Rows[FX定数.No_NOK_JPY].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 6000;
            dgv.Rows[FX定数.No_NZD_CAD].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 4000;
            dgv.Rows[FX定数.No_NZD_CHF].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 4000;
            dgv.Rows[FX定数.No_NZD_JPY].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 4000;
            dgv.Rows[FX定数.No_NZD_USD].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 4000;
            dgv.Rows[FX定数.No_SEK_JPY].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 1200;
            dgv.Rows[FX定数.No_SGD_JPY].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 3700;
            dgv.Rows[FX定数.No_TRY_JPY].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 2600;
            dgv.Rows[FX定数.No_USD_CAD].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 4800;
            dgv.Rows[FX定数.No_USD_CHF].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 4800;
            dgv.Rows[FX定数.No_USD_CNH].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 6000;
            dgv.Rows[FX定数.No_USD_CZK].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 6000;
            dgv.Rows[FX定数.No_USD_HKD].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 4800;
            dgv.Rows[FX定数.No_USD_JPY].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 4800;
            dgv.Rows[FX定数.No_USD_MXN].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 6000;
            dgv.Rows[FX定数.No_USD_NOK].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 6000;
            dgv.Rows[FX定数.No_USD_SEK].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 6000;
            dgv.Rows[FX定数.No_USD_SGD].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 4800;
            dgv.Rows[FX定数.No_USD_TRY].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 4800;
            dgv.Rows[FX定数.No_USD_ZAR].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 4800;
            dgv.Rows[FX定数.No_ZAR_JPY].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 600;
            dgv.Rows[FX定数.No_XAU_USD].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 8500;
            dgv.Rows[FX定数.No_XAG_USD].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 6000;
            dgv.Rows[FX定数.No_AUS200].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 6000;
            dgv.Rows[FX定数.No_Bund].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 6000;
            dgv.Rows[FX定数.No_Copper].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 6000;
            dgv.Rows[FX定数.No_EUSTX50].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 6000;
            dgv.Rows[FX定数.No_ESP35].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 6000;
            dgv.Rows[FX定数.No_FRA40].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 6000;
            dgv.Rows[FX定数.No_GER30].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 6000;
            dgv.Rows[FX定数.No_HKG33].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 6000;
            dgv.Rows[FX定数.No_JPN225].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 280000;
            dgv.Rows[FX定数.No_NAS100].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 6000;
            dgv.Rows[FX定数.No_NGAS].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 6000;
            dgv.Rows[FX定数.No_UK100].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 6000;
            dgv.Rows[FX定数.No_UKOil].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 6000;
            dgv.Rows[FX定数.No_US30].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 170000;
            dgv.Rows[FX定数.No_USDOLLAR].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 48000;
            dgv.Rows[FX定数.No_USOil].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 100000;
            dgv.Rows[FX定数.No_SPX500].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 6000;
        }

        private static void 注文設定_データ生成Chk_FX(ref DataGridView dgv)
        {
            dgv.Rows[FX定数.No_AUD_CAD].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_AUD_CHF].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_AUD_JPY].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_AUD_NZD].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_AUD_USD].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_CAD_CHF].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_CAD_JPY].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_CHF_JPY].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_EUR_AUD].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_EUR_CAD].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_EUR_CHF].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_EUR_CZK].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_EUR_GBP].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_EUR_JPY].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_EUR_NOK].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_EUR_NZD].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_EUR_SEK].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_EUR_TRY].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_EUR_USD].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_GBP_AUD].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_GBP_CAD].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_GBP_CHF].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_GBP_JPY].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_GBP_NZD].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_GBP_USD].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_HKD_JPY].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = false;    // UKには無い
            dgv.Rows[FX定数.No_NOK_JPY].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = false;    // UKには無い
            dgv.Rows[FX定数.No_NZD_CAD].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_NZD_CHF].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_NZD_JPY].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_NZD_USD].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_SEK_JPY].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = false;    // UKには無い
            dgv.Rows[FX定数.No_SGD_JPY].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = false;    // UKには無い
            dgv.Rows[FX定数.No_TRY_JPY].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_USD_CAD].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_USD_CHF].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_USD_CNH].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_USD_CZK].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_USD_HKD].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_USD_JPY].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_USD_MXN].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_USD_NOK].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_USD_SEK].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_USD_SGD].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = false;    // UKには無い
            dgv.Rows[FX定数.No_USD_TRY].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_USD_ZAR].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_ZAR_JPY].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = true;
            dgv.Rows[FX定数.No_XAU_USD].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = false;    // CDFなので除外
            dgv.Rows[FX定数.No_XAG_USD].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = false;    // CDFなので除外
            dgv.Rows[FX定数.No_AUS200].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = false;    // CDFなので除外
            dgv.Rows[FX定数.No_Bund].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = false;        // CDFなので除外
            dgv.Rows[FX定数.No_Copper].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = false;    // CDFなので除外
            dgv.Rows[FX定数.No_EUSTX50].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = false;    // CDFなので除外
            dgv.Rows[FX定数.No_ESP35].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = false;        // CDFなので除外
            dgv.Rows[FX定数.No_FRA40].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = false;        // CDFなので除外
            dgv.Rows[FX定数.No_GER30].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = false;        // CDFなので除外
            dgv.Rows[FX定数.No_HKG33].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = false;        // CDFなので除外
            dgv.Rows[FX定数.No_JPN225].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = false;    // CDFなので除外
            dgv.Rows[FX定数.No_NAS100].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = false;    // CDFなので除外
            dgv.Rows[FX定数.No_NGAS].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = false;        // CDFなので除外
            dgv.Rows[FX定数.No_UK100].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = false;        // CDFなので除外
            dgv.Rows[FX定数.No_UKOil].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = false;        // CDFなので除外
            dgv.Rows[FX定数.No_US30].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = false;        // CDFなので除外
            dgv.Rows[FX定数.No_USDOLLAR].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = false;    // CDFなので除外
            dgv.Rows[FX定数.No_USOil].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = false;        // CDFなので除外
            dgv.Rows[FX定数.No_SPX500].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = false;    // CDFなので除外
        }

        private static void 注文設定_注文Chk_FX(ref DataGridView dgv)
        {
            dgv.Rows[FX定数.No_AUD_CAD].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;    //楽天FXには無い為に2016/8/1からのデータが無い
            dgv.Rows[FX定数.No_AUD_CHF].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = true;
            dgv.Rows[FX定数.No_AUD_JPY].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = true;
            dgv.Rows[FX定数.No_AUD_NZD].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = true;
            dgv.Rows[FX定数.No_AUD_USD].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = true;
            dgv.Rows[FX定数.No_CAD_CHF].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;    //楽天FXには無い為に2016/8/1からのデータが無い
            dgv.Rows[FX定数.No_CAD_JPY].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = true;
            dgv.Rows[FX定数.No_CHF_JPY].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = true;
            dgv.Rows[FX定数.No_EUR_AUD].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;    //楽天FXには無い為に2016/8/1からのデータが無い
            dgv.Rows[FX定数.No_EUR_CAD].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;    //楽天FXには無い為に2016/8/1からのデータが無い
            dgv.Rows[FX定数.No_EUR_CHF].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = true;
            dgv.Rows[FX定数.No_EUR_CZK].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;    //FXCM UKにのみ有る
            dgv.Rows[FX定数.No_EUR_GBP].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = true;
            dgv.Rows[FX定数.No_EUR_JPY].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = true;
            dgv.Rows[FX定数.No_EUR_NOK].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;    //FXCM UKにのみ有る
            dgv.Rows[FX定数.No_EUR_NZD].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;    //楽天FXには無い為に2016/8/1からのデータが無い
            dgv.Rows[FX定数.No_EUR_SEK].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;    //FXCM UKにのみ有る
            dgv.Rows[FX定数.No_EUR_TRY].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;    //楽天FXには無い為に2016/8/1からのデータが無い
            dgv.Rows[FX定数.No_EUR_USD].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = true;
            dgv.Rows[FX定数.No_GBP_AUD].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;    //楽天FXには無い為に2016/8/1からのデータが無い
            dgv.Rows[FX定数.No_GBP_CAD].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;    //楽天FXには無い為に2016/8/1からのデータが無い
            dgv.Rows[FX定数.No_GBP_CHF].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = true;
            dgv.Rows[FX定数.No_GBP_JPY].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = true;
            dgv.Rows[FX定数.No_GBP_NZD].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;    //楽天FXには無い為に2016/8/1からのデータが無い
            dgv.Rows[FX定数.No_GBP_USD].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = true;
            dgv.Rows[FX定数.No_HKD_JPY].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;    //レートの動きが危険
            dgv.Rows[FX定数.No_NOK_JPY].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;    //レートの動きが危険
            dgv.Rows[FX定数.No_NZD_CAD].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;    //楽天FXには無い為に2016/8/1からのデータが無い
            dgv.Rows[FX定数.No_NZD_CHF].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = true;
            dgv.Rows[FX定数.No_NZD_JPY].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = true;
            dgv.Rows[FX定数.No_NZD_USD].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = true;
            dgv.Rows[FX定数.No_SEK_JPY].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;    //必ずマイナスになる
            dgv.Rows[FX定数.No_SGD_JPY].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;    //システム障害が発生する
            dgv.Rows[FX定数.No_TRY_JPY].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = true;
            dgv.Rows[FX定数.No_USD_CAD].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;    //楽天FXには無い為に2016/8/1からのデータが無い
            dgv.Rows[FX定数.No_USD_CHF].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = true;
            dgv.Rows[FX定数.No_USD_CNH].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;    //FXCM UKにのみ有る
            dgv.Rows[FX定数.No_USD_CZK].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;    //FXCM UKにのみ有る
            dgv.Rows[FX定数.No_USD_HKD].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;    //楽天FXには無い為に2016/8/1からのデータが無い
            dgv.Rows[FX定数.No_USD_JPY].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = true;
            dgv.Rows[FX定数.No_USD_MXN].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;   //FXCM UKにのみ有る
            dgv.Rows[FX定数.No_USD_NOK].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;   //FXCM UKにのみ有る
            dgv.Rows[FX定数.No_USD_SEK].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;    //FXCM UKにのみ有る
            dgv.Rows[FX定数.No_USD_SGD].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;   //必ずマイナスになる
            dgv.Rows[FX定数.No_USD_TRY].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;    //楽天FXには無い為に2016/8/1からのデータが無い
            dgv.Rows[FX定数.No_USD_ZAR].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;    //必ずマイナスになる
            dgv.Rows[FX定数.No_ZAR_JPY].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;    //必ずマイナスになる
            dgv.Rows[FX定数.No_XAU_USD].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;
            dgv.Rows[FX定数.No_XAG_USD].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;
            dgv.Rows[FX定数.No_AUS200].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;
            dgv.Rows[FX定数.No_Bund].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;
            dgv.Rows[FX定数.No_Copper].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;
            dgv.Rows[FX定数.No_EUSTX50].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;
            dgv.Rows[FX定数.No_ESP35].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;
            dgv.Rows[FX定数.No_FRA40].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;
            dgv.Rows[FX定数.No_GER30].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;
            dgv.Rows[FX定数.No_HKG33].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;
            dgv.Rows[FX定数.No_JPN225].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;
            dgv.Rows[FX定数.No_NAS100].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;
            dgv.Rows[FX定数.No_NGAS].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;
            dgv.Rows[FX定数.No_UK100].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;
            dgv.Rows[FX定数.No_UKOil].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;
            dgv.Rows[FX定数.No_US30].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;
            dgv.Rows[FX定数.No_USDOLLAR].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;
            dgv.Rows[FX定数.No_USOil].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;
            dgv.Rows[FX定数.No_SPX500].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = false;
        }

    }
}
