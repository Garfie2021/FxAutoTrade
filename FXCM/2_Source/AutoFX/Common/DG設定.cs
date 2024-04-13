using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 定数;

namespace Common
{
	public static class DG設定
	{
		public static List<DG> DGList = new List<DG>();

		static DG設定()
		{
			注文基本設定();
			維持証拠金を設定();
			注文設定_データ生成Chk_FX();
			注文設定_注文Chk_FX();
		}

		private static void 注文基本設定()
		{
			for (byte 通貨ペアNo = 0; 通貨ペアNo < FX定数.通貨ペア.Length; 通貨ペアNo++)
			{
				// 初期値を設定しておく事で、Valueの型も確定させ、バグ防止にもなる //
				DGList.Add(new DG()
				{
					通貨ペアNo = 通貨ペアNo,
					通貨ペア名 = FX定数.通貨ペア[通貨ペアNo],
					取引状況 = "",
					Chkデータ生成 = false,
					Chk注文 = false,
					保持ポジション = "",
					買いSwap = 0,
					売りSwap = 0,
					Swap判定 = "",
					WMA判定_15m = "",
					BS判定_前 = "",
					BS判定_今 = "",
					ポジション数 = 0,
					ポジション増加数 = 0,
					リミット = 0,
					売りRate = 0,
					買いRate = 0,
					維持証拠金 = 0,
					維持証拠金小計 = 0,
					QuoteID = ""
				});
			}
		}

		private static void 維持証拠金を設定()
		{
			DGList.Find(x => x.通貨ペアNo == FX定数.No_AUD_CAD).維持証拠金 = 4800;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_AUD_CHF).維持証拠金 = 4800;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_AUD_JPY).維持証拠金 = 4800;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_AUD_NZD).維持証拠金 = 4800;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_CAD_JPY).維持証拠金 = 4800;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_AUD_USD).維持証拠金 = 4800;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_CAD_CHF).維持証拠金 = 4800;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_CHF_JPY).維持証拠金 = 4800;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_EUR_AUD).維持証拠金 = 6000;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_EUR_CAD).維持証拠金 = 6000;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_EUR_CHF).維持証拠金 = 6000;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_EUR_GBP).維持証拠金 = 6000;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_EUR_JPY).維持証拠金 = 6000;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_EUR_NZD).維持証拠金 = 6000;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_EUR_USD).維持証拠金 = 6000;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_EUR_TRY).維持証拠金 = 4800;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_GBP_AUD).維持証拠金 = 7200;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_GBP_CAD).維持証拠金 = 7200;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_GBP_CHF).維持証拠金 = 7200;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_GBP_JPY).維持証拠金 = 7200;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_GBP_NZD).維持証拠金 = 7200;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_GBP_USD).維持証拠金 = 7200;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_HKD_JPY).維持証拠金 = 700;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_NOK_JPY).維持証拠金 = 6000;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_NZD_CAD).維持証拠金 = 4000;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_NZD_CHF).維持証拠金 = 4000;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_NZD_JPY).維持証拠金 = 4000;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_NZD_USD).維持証拠金 = 4000;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_SEK_JPY).維持証拠金 = 1200;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_SGD_JPY).維持証拠金 = 3700;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_TRY_JPY).維持証拠金 = 2600;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_USD_CAD).維持証拠金 = 4800;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_USD_CHF).維持証拠金 = 4800;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_USD_HKD).維持証拠金 = 4800;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_USD_JPY).維持証拠金 = 4800;
            DGList.Find(x => x.通貨ペアNo == FX定数.No_USD_MXN).維持証拠金 = 4800;
            DGList.Find(x => x.通貨ペアNo == FX定数.No_USD_NOK).維持証拠金 = 4800;
            DGList.Find(x => x.通貨ペアNo == FX定数.No_USD_SEK).維持証拠金 = 4800;
            DGList.Find(x => x.通貨ペアNo == FX定数.No_USD_SGD).維持証拠金 = 4800;
            DGList.Find(x => x.通貨ペアNo == FX定数.No_USD_TRY).維持証拠金 = 4800;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_USD_ZAR).維持証拠金 = 4800;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_ZAR_JPY).維持証拠金 = 600;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_XAU_USD).維持証拠金 = 8500;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_JPN225).維持証拠金 = 280000;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_US30).維持証拠金 = 170000;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_USDOLLAR).維持証拠金 = 48000;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_USOil).維持証拠金 = 100000;
		}

		private static void 注文設定_データ生成Chk_FX()
		{
			DGList.Find(x => x.通貨ペアNo == FX定数.No_AUD_CAD).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_AUD_CHF).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_AUD_JPY).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_AUD_NZD).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_CAD_JPY).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_AUD_USD).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_CAD_CHF).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_CHF_JPY).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_EUR_AUD).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_EUR_CAD).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_EUR_CHF).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_EUR_GBP).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_EUR_JPY).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_EUR_NZD).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_EUR_USD).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_EUR_TRY).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_GBP_AUD).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_GBP_CAD).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_GBP_CHF).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_GBP_JPY).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_GBP_NZD).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_GBP_USD).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_HKD_JPY).Chkデータ生成 = false;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_NOK_JPY).Chkデータ生成 = false;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_NZD_CAD).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_NZD_CHF).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_NZD_JPY).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_NZD_USD).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_SEK_JPY).Chkデータ生成 = false;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_SGD_JPY).Chkデータ生成 = false;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_TRY_JPY).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_USD_CAD).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_USD_CHF).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_USD_HKD).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_USD_JPY).Chkデータ生成 = true;
            DGList.Find(x => x.通貨ペアNo == FX定数.No_USD_MXN).Chkデータ生成 = true;
            DGList.Find(x => x.通貨ペアNo == FX定数.No_USD_NOK).Chkデータ生成 = true;
            DGList.Find(x => x.通貨ペアNo == FX定数.No_USD_SEK).Chkデータ生成 = false;
            DGList.Find(x => x.通貨ペアNo == FX定数.No_USD_SGD).Chkデータ生成 = false;
            DGList.Find(x => x.通貨ペアNo == FX定数.No_USD_TRY).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_USD_ZAR).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_ZAR_JPY).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_XAU_USD).Chkデータ生成 = false;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_JPN225).Chkデータ生成 = false;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_US30).Chkデータ生成 = false;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_USDOLLAR).Chkデータ生成 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_USOil).Chkデータ生成 = false;
		}

		private static void 注文設定_注文Chk_FX()
		{
			DGList.Find(x => x.通貨ペアNo == FX定数.No_AUD_CAD).Chk注文 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_AUD_CHF).Chk注文 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_AUD_JPY).Chk注文 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_AUD_NZD).Chk注文 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_CAD_JPY).Chk注文 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_AUD_USD).Chk注文 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_CAD_CHF).Chk注文 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_CHF_JPY).Chk注文 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_EUR_AUD).Chk注文 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_EUR_CAD).Chk注文 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_EUR_CHF).Chk注文 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_EUR_GBP).Chk注文 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_EUR_JPY).Chk注文 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_EUR_NZD).Chk注文 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_EUR_USD).Chk注文 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_EUR_TRY).Chk注文 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_GBP_AUD).Chk注文 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_GBP_CAD).Chk注文 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_GBP_CHF).Chk注文 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_GBP_JPY).Chk注文 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_GBP_NZD).Chk注文 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_GBP_USD).Chk注文 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_HKD_JPY).Chk注文 = false;	//必ずマイナスになる
			DGList.Find(x => x.通貨ペアNo == FX定数.No_NOK_JPY).Chk注文 = false;	//システム障害が発生する
			DGList.Find(x => x.通貨ペアNo == FX定数.No_NZD_CAD).Chk注文 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_NZD_CHF).Chk注文 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_NZD_JPY).Chk注文 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_NZD_USD).Chk注文 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_SEK_JPY).Chk注文 = false;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_SGD_JPY).Chk注文 = false;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_TRY_JPY).Chk注文 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_USD_CAD).Chk注文 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_USD_CHF).Chk注文 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_USD_HKD).Chk注文 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_USD_JPY).Chk注文 = true;
            DGList.Find(x => x.通貨ペアNo == FX定数.No_USD_MXN).Chk注文 = true;
            DGList.Find(x => x.通貨ペアNo == FX定数.No_USD_NOK).Chk注文 = true;
            DGList.Find(x => x.通貨ペアNo == FX定数.No_USD_SEK).Chk注文 = false;
            DGList.Find(x => x.通貨ペアNo == FX定数.No_USD_SGD).Chk注文 = false;
            DGList.Find(x => x.通貨ペアNo == FX定数.No_USD_TRY).Chk注文 = true;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_USD_ZAR).Chk注文 = false;	//必ずマイナスになる
			DGList.Find(x => x.通貨ペアNo == FX定数.No_ZAR_JPY).Chk注文 = false;	//必ずマイナスになる
			DGList.Find(x => x.通貨ペアNo == FX定数.No_XAU_USD).Chk注文 = false;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_JPN225).Chk注文 = false;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_US30).Chk注文 = false;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_USDOLLAR).Chk注文 = false;
			DGList.Find(x => x.通貨ペアNo == FX定数.No_USOil).Chk注文 = false;
		}

	}
}
