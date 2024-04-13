using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 定数;
using Common;

namespace FXCM
{
    public static class 通貨ペア初期化
    {
        public static List<Instrument> FXCMJP()
        {
            var 通貨ペア配列 = new List<Instrument>();

            通貨ペア配列.Add(new Instrument() { No = FX定数.No_AUD_CAD, instrument = "AUD/CAD", Chkデータ生成 = true, Chk注文 = false, 維持証拠金 = 4800 });    // 楽天FXには無い為に2016/8/1からのデータが無い	
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_AUD_CHF, instrument = "AUD/CHF", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_AUD_JPY, instrument = "AUD/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_AUD_NZD, instrument = "AUD/NZD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_AUD_USD, instrument = "AUD/USD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_CAD_CHF, instrument = "CAD/CHF", Chkデータ生成 = true, Chk注文 = false, 維持証拠金 = 4800 });    // 楽天FXには無い為に2016/8/1からのデータが無い	
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_CAD_JPY, instrument = "CAD/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_CHF_JPY, instrument = "CHF/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_EUR_AUD, instrument = "EUR/AUD", Chkデータ生成 = true, Chk注文 = false, 維持証拠金 = 6000 });    // 楽天FXには無い為に2016/8/1からのデータが無い	
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_EUR_CAD, instrument = "EUR/CAD", Chkデータ生成 = true, Chk注文 = false, 維持証拠金 = 6000 });    // 楽天FXには無い為に2016/8/1からのデータが無い	
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_EUR_CHF, instrument = "EUR/CHF", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_EUR_GBP, instrument = "EUR/GBP", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_EUR_JPY, instrument = "EUR/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_EUR_NZD, instrument = "EUR/NZD", Chkデータ生成 = true, Chk注文 = false, 維持証拠金 = 6000 });    // 楽天FXには無い為に2016/8/1からのデータが無い	
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_EUR_TRY, instrument = "EUR/TRY", Chkデータ生成 = true, Chk注文 = false, 維持証拠金 = 4800 });    // 楽天FXには無い為に2016/8/1からのデータが無い	
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_EUR_USD, instrument = "EUR/USD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_GBP_AUD, instrument = "GBP/AUD", Chkデータ生成 = true, Chk注文 = false, 維持証拠金 = 7200 });    // 楽天FXには無い為に2016/8/1からのデータが無い	
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_GBP_CAD, instrument = "GBP/CAD", Chkデータ生成 = true, Chk注文 = false, 維持証拠金 = 7200 });    // 楽天FXには無い為に2016/8/1からのデータが無い	
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_GBP_CHF, instrument = "GBP/CHF", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 7200 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_GBP_JPY, instrument = "GBP/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 7200 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_GBP_NZD, instrument = "GBP/NZD", Chkデータ生成 = true, Chk注文 = false, 維持証拠金 = 7200 });    // 楽天FXには無い為に2016/8/1からのデータが無い	
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_GBP_USD, instrument = "GBP/USD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 7200 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_HKD_JPY, instrument = "HKD/JPY", Chkデータ生成 = false, Chk注文 = false, 維持証拠金 = 700 });    // UKには無い	//レートの動きが危険	
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_NOK_JPY, instrument = "NOK/JPY", Chkデータ生成 = false, Chk注文 = false, 維持証拠金 = 6000 });   // UKには無い	//レートの動きが危険	
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_NZD_CAD, instrument = "NZD/CAD", Chkデータ生成 = true, Chk注文 = false, 維持証拠金 = 4000 });    // 楽天FXには無い為に2016/8/1からのデータが無い	
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_NZD_CHF, instrument = "NZD/CHF", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_NZD_JPY, instrument = "NZD/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_NZD_USD, instrument = "NZD/USD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_SEK_JPY, instrument = "SEK/JPY", Chkデータ生成 = false, Chk注文 = false, 維持証拠金 = 1200 });   // UKには無い	//必ずマイナスになる	
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_SGD_JPY, instrument = "SGD/JPY", Chkデータ生成 = false, Chk注文 = false, 維持証拠金 = 3700 });   // UKには無い	//システム障害が発生する	
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_TRY_JPY, instrument = "TRY/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 2600 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_USD_CAD, instrument = "USD/CAD", Chkデータ生成 = true, Chk注文 = false, 維持証拠金 = 4800 });    // 楽天FXには無い為に2016/8/1からのデータが無い	
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_USD_CHF, instrument = "USD/CHF", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_USD_HKD, instrument = "USD/HKD", Chkデータ生成 = true, Chk注文 = false, 維持証拠金 = 4800 });    // 楽天FXには無い為に2016/8/1からのデータが無い	
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_USD_JPY, instrument = "USD/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_USD_SGD, instrument = "USD/SGD", Chkデータ生成 = false, Chk注文 = false, 維持証拠金 = 4800 });   // UKには無い	//必ずマイナスになる	
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_USD_TRY, instrument = "USD/TRY", Chkデータ生成 = true, Chk注文 = false, 維持証拠金 = 4800 });    // 楽天FXには無い為に2016/8/1からのデータが無い	
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_USD_ZAR, instrument = "USD/ZAR", Chkデータ生成 = true, Chk注文 = false, 維持証拠金 = 4800 });    // 必ずマイナスになる	
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_ZAR_JPY, instrument = "ZAR/JPY", Chkデータ生成 = true, Chk注文 = false, 維持証拠金 = 600 });     // 必ずマイナスになる	
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_XAU_USD, instrument = "XAU/USD", Chkデータ生成 = false, Chk注文 = false, 維持証拠金 = 8500 });   // CDFなので除外		
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_JPN225, instrument = "JPN225", Chkデータ生成 = false, Chk注文 = false, 維持証拠金 = 280000 });   // CDFなので除外		
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_USDOLLAR, instrument = "USDOLLAR", Chkデータ生成 = false, Chk注文 = false, 維持証拠金 = 48000 }); //	CDFなので除外		
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_USOil, instrument = "USOil", Chkデータ生成 = false, Chk注文 = false, 維持証拠金 = 100000 });      //	CDFなので除外		

            return 通貨ペア配列;
        }

        public static List<Instrument> FXCMUK()
        {
            var 通貨ペア配列 = new List<Instrument>();

            通貨ペア配列.Add(new Instrument() { No = FX定数.No_AUD_CAD, instrument = "AUD/CAD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_AUD_CHF, instrument = "AUD/CHF", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_AUD_JPY, instrument = "AUD/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_AUD_NZD, instrument = "AUD/NZD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_AUD_USD, instrument = "AUD/USD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_CAD_CHF, instrument = "CAD/CHF", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_CAD_JPY, instrument = "CAD/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_CHF_JPY, instrument = "CHF/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_EUR_AUD, instrument = "EUR/AUD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_EUR_CAD, instrument = "EUR/CAD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_EUR_CHF, instrument = "EUR/CHF", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_EUR_CZK, instrument = "EUR/CZK", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_EUR_GBP, instrument = "EUR/GBP", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_EUR_JPY, instrument = "EUR/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_EUR_NOK, instrument = "EUR/NOK", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_EUR_NZD, instrument = "EUR/NZD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_EUR_SEK, instrument = "EUR/SEK", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_EUR_TRY, instrument = "EUR/TRY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_EUR_USD, instrument = "EUR/USD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_GBP_AUD, instrument = "GBP/AUD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 7200 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_GBP_CAD, instrument = "GBP/CAD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 7200 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_GBP_CHF, instrument = "GBP/CHF", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 7200 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_GBP_JPY, instrument = "GBP/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 7200 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_GBP_NZD, instrument = "GBP/NZD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 7200 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_GBP_USD, instrument = "GBP/USD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 7200 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_NZD_CAD, instrument = "NZD/CAD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_NZD_CHF, instrument = "NZD/CHF", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_NZD_JPY, instrument = "NZD/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_NZD_USD, instrument = "NZD/USD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_TRY_JPY, instrument = "TRY/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 2600 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_USD_CAD, instrument = "USD/CAD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_USD_CHF, instrument = "USD/CHF", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_USD_CNH, instrument = "USD/CNH", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_USD_CZK, instrument = "USD/CZK", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_USD_HKD, instrument = "USD/HKD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_USD_JPY, instrument = "USD/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_USD_MXN, instrument = "USD/MXN", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_USD_NOK, instrument = "USD/NOK", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_USD_SEK, instrument = "USD/SEK", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_USD_TRY, instrument = "USD/TRY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_USD_ZAR, instrument = "USD/ZAR", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_ZAR_JPY, instrument = "ZAR/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 600 });

            return 通貨ペア配列;
        }

        public static List<Instrument> OANDA()
        {
            var 通貨ペア配列 = new List<Instrument>();

            通貨ペア配列.Add(new Instrument() { No = FX定数.No_AUD_CAD, instrument = "AUD/CAD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_AUD_CHF, instrument = "AUD/CHF", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_AUD_JPY, instrument = "AUD/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_AUD_NZD, instrument = "AUD/NZD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_AUD_USD, instrument = "AUD/USD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_CAD_CHF, instrument = "CAD/CHF", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_CAD_JPY, instrument = "CAD/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_CHF_JPY, instrument = "CHF/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_EUR_AUD, instrument = "EUR/AUD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_EUR_CAD, instrument = "EUR/CAD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_EUR_CHF, instrument = "EUR/CHF", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_EUR_CZK, instrument = "EUR/CZK", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_EUR_GBP, instrument = "EUR/GBP", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_EUR_JPY, instrument = "EUR/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_EUR_NOK, instrument = "EUR/NOK", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_EUR_NZD, instrument = "EUR/NZD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_EUR_SEK, instrument = "EUR/SEK", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_EUR_TRY, instrument = "EUR/TRY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_EUR_USD, instrument = "EUR/USD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_GBP_AUD, instrument = "GBP/AUD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 7200 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_GBP_CAD, instrument = "GBP/CAD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 7200 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_GBP_CHF, instrument = "GBP/CHF", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 7200 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_GBP_JPY, instrument = "GBP/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 7200 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_GBP_NZD, instrument = "GBP/NZD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 7200 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_GBP_USD, instrument = "GBP/USD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 7200 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_GBP_USD, instrument = "HKD/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 7200 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_NZD_CAD, instrument = "NZD/CAD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_NZD_CHF, instrument = "NZD/CHF", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_NZD_JPY, instrument = "NZD/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_NZD_USD, instrument = "NZD/USD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_NZD_USD, instrument = "SGD/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_TRY_JPY, instrument = "TRY/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 2600 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_USD_CAD, instrument = "USD/CAD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_USD_CHF, instrument = "USD/CHF", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_USD_CNH, instrument = "USD/CNH", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_USD_CZK, instrument = "USD/CZK", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_USD_HKD, instrument = "USD/HKD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_USD_JPY, instrument = "USD/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_USD_MXN, instrument = "USD/MXN", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_USD_NOK, instrument = "USD/NOK", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_USD_SEK, instrument = "USD/SEK", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_USD_SEK, instrument = "USD/SGD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_USD_TRY, instrument = "USD/TRY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_USD_ZAR, instrument = "USD/ZAR", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new Instrument() { No = FX定数.No_ZAR_JPY, instrument = "ZAR/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 600 });

            return 通貨ペア配列;
        }

    }
}


