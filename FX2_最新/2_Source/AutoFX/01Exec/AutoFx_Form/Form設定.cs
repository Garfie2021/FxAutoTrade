using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SystemCommon;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using 定数;
using 共通Data;
using Common;
using FXCM;

namespace AutoFx_Form
{
    public static class Form設定
    {
        public static void 注文設定DGV初期化()
        {
            注文基本設定();
            //維持証拠金を設定(ref dgv);
            注文設定_データ生成Chk_FX();
            注文設定_注文Chk_FX();
			//通貨ペア初期化()
        }

        private static void 注文基本設定()
        {
			byte q = 0;
			foreach (var Instrument in システム変数.Instruments)
			{
				FormData.DG.Add(new 通貨ぺア別取引状況()
				{
					No = q,
					通貨ペアNo = Instrument.No,
					通貨ペア名 = Instrument.instrument,
					InstrumentOanda = Instrument.instrumentOanda,
					取引状況 = "",
					保持ポジション = "",
					売りSwap = 0.0,
					買いSwap = 0.0,
					Swap判定 = "",
					売りRate = 0.0,
					買いRate = 0.0,
					WMA前_15m = "",
					WMA今_15m = "",
					WMA上昇角度_今_15m = "",
					WMA判定_15m = "",
					BS判定_前 = "",
					BS判定_今 = "",
					ポジション数 = 0,
					ポジション増加数 = 0,
					リミット = 0.0,
					維持証拠金 = 0.0,
					維持証拠金小計 = 0.0,
					Chkデータ生成 = false,
					Chk注文 = false,
					QuoteID = ""
				});

				q++;
			}
			

			for (byte i = 0; i < システム変数.Instruments.Count; i++)
            {
                // 初期値を設定しておく事で、Valueの型も確定させ、バグ防止にもなる //

				//FromData.DG.Add();
				FormData.DG[i].通貨ペア名 = FX定数.通貨ペア[i];
                FormData.DG[i].取引状況 = "";
                FormData.DG[i].Chkデータ生成 = false;
                FormData.DG[i].Chk注文 = false;
                FormData.DG[i].保持ポジション = "";
                FormData.DG[i].買いSwap = 0.0;
                FormData.DG[i].売りSwap = 0.0;
                FormData.DG[i].Swap判定 = "";
                FormData.DG[i].WMA判定_15m = "";
                FormData.DG[i].BS判定_前 = "";
                FormData.DG[i].BS判定_今 = "";
                FormData.DG[i].ポジション数 = 0;
                FormData.DG[i].ポジション増加数 = 0;
                FormData.DG[i].リミット = 0.0;
                FormData.DG[i].売りRate = 0.0;
                FormData.DG[i].買いRate = 0.0;
                FormData.DG[i].維持証拠金 = 0.0;
                FormData.DG[i].維持証拠金小計 = 0.0;
                FormData.DG[i].QuoteID = "";
            }
        }


        private static void 注文設定_データ生成Chk_FX()
        {
            FormData.DG[FX定数.No_AUD_CAD].Chkデータ生成 = true;
            FormData.DG[FX定数.No_AUD_CHF].Chkデータ生成 = true;
            FormData.DG[FX定数.No_AUD_JPY].Chkデータ生成 = true;
            FormData.DG[FX定数.No_AUD_NZD].Chkデータ生成 = true;
            FormData.DG[FX定数.No_AUD_USD].Chkデータ生成 = true;
            FormData.DG[FX定数.No_CAD_CHF].Chkデータ生成 = true;
            FormData.DG[FX定数.No_CAD_JPY].Chkデータ生成 = true;
            FormData.DG[FX定数.No_CHF_JPY].Chkデータ生成 = true;
            FormData.DG[FX定数.No_EUR_AUD].Chkデータ生成 = true;
            FormData.DG[FX定数.No_EUR_CAD].Chkデータ生成 = true;
            FormData.DG[FX定数.No_EUR_CHF].Chkデータ生成 = true;
            FormData.DG[FX定数.No_EUR_CZK].Chkデータ生成 = true;
            FormData.DG[FX定数.No_EUR_GBP].Chkデータ生成 = true;
            FormData.DG[FX定数.No_EUR_JPY].Chkデータ生成 = true;
            FormData.DG[FX定数.No_EUR_NOK].Chkデータ生成 = true;
            FormData.DG[FX定数.No_EUR_NZD].Chkデータ生成 = true;
            FormData.DG[FX定数.No_EUR_SEK].Chkデータ生成 = true;
            FormData.DG[FX定数.No_EUR_TRY].Chkデータ生成 = true;
            FormData.DG[FX定数.No_EUR_USD].Chkデータ生成 = true;
            FormData.DG[FX定数.No_GBP_AUD].Chkデータ生成 = true;
            FormData.DG[FX定数.No_GBP_CAD].Chkデータ生成 = true;
            FormData.DG[FX定数.No_GBP_CHF].Chkデータ生成 = true;
            FormData.DG[FX定数.No_GBP_JPY].Chkデータ生成 = true;
            FormData.DG[FX定数.No_GBP_NZD].Chkデータ生成 = true;
            FormData.DG[FX定数.No_GBP_USD].Chkデータ生成 = true;
            FormData.DG[FX定数.No_HKD_JPY].Chkデータ生成 = false;    // UKには無い
            FormData.DG[FX定数.No_NOK_JPY].Chkデータ生成 = false;    // UKには無い
            FormData.DG[FX定数.No_NZD_CAD].Chkデータ生成 = true;
            FormData.DG[FX定数.No_NZD_CHF].Chkデータ生成 = true;
            FormData.DG[FX定数.No_NZD_JPY].Chkデータ生成 = true;
            FormData.DG[FX定数.No_NZD_USD].Chkデータ生成 = true;
            FormData.DG[FX定数.No_SEK_JPY].Chkデータ生成 = false;    // UKには無い
            FormData.DG[FX定数.No_SGD_JPY].Chkデータ生成 = false;    // UKには無い
            FormData.DG[FX定数.No_TRY_JPY].Chkデータ生成 = true;
            FormData.DG[FX定数.No_USD_CAD].Chkデータ生成 = true;
            FormData.DG[FX定数.No_USD_CHF].Chkデータ生成 = true;
            FormData.DG[FX定数.No_USD_CNH].Chkデータ生成 = true;
            FormData.DG[FX定数.No_USD_CZK].Chkデータ生成 = true;
            FormData.DG[FX定数.No_USD_HKD].Chkデータ生成 = true;
            FormData.DG[FX定数.No_USD_JPY].Chkデータ生成 = true;
            FormData.DG[FX定数.No_USD_MXN].Chkデータ生成 = true;
            FormData.DG[FX定数.No_USD_NOK].Chkデータ生成 = true;
            FormData.DG[FX定数.No_USD_SEK].Chkデータ生成 = true;
            FormData.DG[FX定数.No_USD_SGD].Chkデータ生成 = false;    // UKには無い
            FormData.DG[FX定数.No_USD_TRY].Chkデータ生成 = true;
            FormData.DG[FX定数.No_USD_ZAR].Chkデータ生成 = true;
            FormData.DG[FX定数.No_ZAR_JPY].Chkデータ生成 = true;
            FormData.DG[FX定数.No_XAU_USD].Chkデータ生成 = false;    // CDFなので除外
            FormData.DG[FX定数.No_XAG_USD].Chkデータ生成 = false;    // CDFなので除外
            FormData.DG[FX定数.No_AUS200].Chkデータ生成 = false;    // CDFなので除外
            FormData.DG[FX定数.No_Bund].Chkデータ生成 = false;        // CDFなので除外
            FormData.DG[FX定数.No_Copper].Chkデータ生成 = false;    // CDFなので除外
            FormData.DG[FX定数.No_EUSTX50].Chkデータ生成 = false;    // CDFなので除外
            FormData.DG[FX定数.No_ESP35].Chkデータ生成 = false;        // CDFなので除外
            FormData.DG[FX定数.No_FRA40].Chkデータ生成 = false;        // CDFなので除外
            FormData.DG[FX定数.No_GER30].Chkデータ生成 = false;        // CDFなので除外
            FormData.DG[FX定数.No_HKG33].Chkデータ生成 = false;        // CDFなので除外
            FormData.DG[FX定数.No_JPN225].Chkデータ生成 = false;    // CDFなので除外
            FormData.DG[FX定数.No_NAS100].Chkデータ生成 = false;    // CDFなので除外
            FormData.DG[FX定数.No_NGAS].Chkデータ生成 = false;        // CDFなので除外
            FormData.DG[FX定数.No_UK100].Chkデータ生成 = false;        // CDFなので除外
            FormData.DG[FX定数.No_UKOil].Chkデータ生成 = false;        // CDFなので除外
            FormData.DG[FX定数.No_US30].Chkデータ生成 = false;        // CDFなので除外
            FormData.DG[FX定数.No_USDOLLAR].Chkデータ生成 = false;    // CDFなので除外
            FormData.DG[FX定数.No_USOil].Chkデータ生成 = false;        // CDFなので除外
            FormData.DG[FX定数.No_SPX500].Chkデータ生成 = false;    // CDFなので除外
        }

        private static void 注文設定_注文Chk_FX()
        {
            FormData.DG[FX定数.No_AUD_CAD].Chk注文 = false;    //楽天FXには無い為に2016/8/1からのデータが無い
            FormData.DG[FX定数.No_AUD_CHF].Chk注文 = true;
            FormData.DG[FX定数.No_AUD_JPY].Chk注文 = true;
            FormData.DG[FX定数.No_AUD_NZD].Chk注文 = true;
            FormData.DG[FX定数.No_AUD_USD].Chk注文 = true;
            FormData.DG[FX定数.No_CAD_CHF].Chk注文 = false;    //楽天FXには無い為に2016/8/1からのデータが無い
            FormData.DG[FX定数.No_CAD_JPY].Chk注文 = true;
            FormData.DG[FX定数.No_CHF_JPY].Chk注文 = true;
            FormData.DG[FX定数.No_EUR_AUD].Chk注文 = false;    //楽天FXには無い為に2016/8/1からのデータが無い
            FormData.DG[FX定数.No_EUR_CAD].Chk注文 = false;    //楽天FXには無い為に2016/8/1からのデータが無い
            FormData.DG[FX定数.No_EUR_CHF].Chk注文 = true;
            FormData.DG[FX定数.No_EUR_CZK].Chk注文 = false;    //FXCM UKにのみ有る
            FormData.DG[FX定数.No_EUR_GBP].Chk注文 = true;
            FormData.DG[FX定数.No_EUR_JPY].Chk注文 = true;
            FormData.DG[FX定数.No_EUR_NOK].Chk注文 = false;    //FXCM UKにのみ有る
            FormData.DG[FX定数.No_EUR_NZD].Chk注文 = false;    //楽天FXには無い為に2016/8/1からのデータが無い
            FormData.DG[FX定数.No_EUR_SEK].Chk注文 = false;    //FXCM UKにのみ有る
            FormData.DG[FX定数.No_EUR_TRY].Chk注文 = false;    //楽天FXには無い為に2016/8/1からのデータが無い
            FormData.DG[FX定数.No_EUR_USD].Chk注文 = true;
            FormData.DG[FX定数.No_GBP_AUD].Chk注文 = false;    //楽天FXには無い為に2016/8/1からのデータが無い
            FormData.DG[FX定数.No_GBP_CAD].Chk注文 = false;    //楽天FXには無い為に2016/8/1からのデータが無い
            FormData.DG[FX定数.No_GBP_CHF].Chk注文 = true;
            FormData.DG[FX定数.No_GBP_JPY].Chk注文 = true;
            FormData.DG[FX定数.No_GBP_NZD].Chk注文 = false;    //楽天FXには無い為に2016/8/1からのデータが無い
            FormData.DG[FX定数.No_GBP_USD].Chk注文 = true;
            FormData.DG[FX定数.No_HKD_JPY].Chk注文 = false;    //レートの動きが危険
            FormData.DG[FX定数.No_NOK_JPY].Chk注文 = false;    //レートの動きが危険
            FormData.DG[FX定数.No_NZD_CAD].Chk注文 = false;    //楽天FXには無い為に2016/8/1からのデータが無い
            FormData.DG[FX定数.No_NZD_CHF].Chk注文 = true;
            FormData.DG[FX定数.No_NZD_JPY].Chk注文 = true;
            FormData.DG[FX定数.No_NZD_USD].Chk注文 = true;
            FormData.DG[FX定数.No_SEK_JPY].Chk注文 = false;    //必ずマイナスになる
            FormData.DG[FX定数.No_SGD_JPY].Chk注文 = false;    //システム障害が発生する
            FormData.DG[FX定数.No_TRY_JPY].Chk注文 = true;
            FormData.DG[FX定数.No_USD_CAD].Chk注文 = false;    //楽天FXには無い為に2016/8/1からのデータが無い
            FormData.DG[FX定数.No_USD_CHF].Chk注文 = true;
            FormData.DG[FX定数.No_USD_CNH].Chk注文 = false;    //FXCM UKにのみ有る
            FormData.DG[FX定数.No_USD_CZK].Chk注文 = false;    //FXCM UKにのみ有る
            FormData.DG[FX定数.No_USD_HKD].Chk注文 = false;    //楽天FXには無い為に2016/8/1からのデータが無い
            FormData.DG[FX定数.No_USD_JPY].Chk注文 = true;
            FormData.DG[FX定数.No_USD_MXN].Chk注文 = false;   //FXCM UKにのみ有る
            FormData.DG[FX定数.No_USD_NOK].Chk注文 = false;   //FXCM UKにのみ有る
            FormData.DG[FX定数.No_USD_SEK].Chk注文 = false;    //FXCM UKにのみ有る
            FormData.DG[FX定数.No_USD_SGD].Chk注文 = false;   //必ずマイナスになる
            FormData.DG[FX定数.No_USD_TRY].Chk注文 = false;    //楽天FXには無い為に2016/8/1からのデータが無い
            FormData.DG[FX定数.No_USD_ZAR].Chk注文 = false;    //必ずマイナスになる
            FormData.DG[FX定数.No_ZAR_JPY].Chk注文 = false;    //必ずマイナスになる
            FormData.DG[FX定数.No_XAU_USD].Chk注文 = false;
            FormData.DG[FX定数.No_XAG_USD].Chk注文 = false;
            FormData.DG[FX定数.No_AUS200].Chk注文 = false;
            FormData.DG[FX定数.No_Bund].Chk注文 = false;
            FormData.DG[FX定数.No_Copper].Chk注文 = false;
            FormData.DG[FX定数.No_EUSTX50].Chk注文 = false;
            FormData.DG[FX定数.No_ESP35].Chk注文 = false;
            FormData.DG[FX定数.No_FRA40].Chk注文 = false;
            FormData.DG[FX定数.No_GER30].Chk注文 = false;
            FormData.DG[FX定数.No_HKG33].Chk注文 = false;
            FormData.DG[FX定数.No_JPN225].Chk注文 = false;
            FormData.DG[FX定数.No_NAS100].Chk注文 = false;
            FormData.DG[FX定数.No_NGAS].Chk注文 = false;
            FormData.DG[FX定数.No_UK100].Chk注文 = false;
            FormData.DG[FX定数.No_UKOil].Chk注文 = false;
            FormData.DG[FX定数.No_US30].Chk注文 = false;
            FormData.DG[FX定数.No_USDOLLAR].Chk注文 = false;
            FormData.DG[FX定数.No_USOil].Chk注文 = false;
            FormData.DG[FX定数.No_SPX500].Chk注文 = false;
        }

    }
}
