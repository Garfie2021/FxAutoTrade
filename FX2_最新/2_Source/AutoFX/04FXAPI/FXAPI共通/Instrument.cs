using System.Collections.Generic;
using 定数;
using 共通Data;

namespace FXAPI共通
{
    public static class Instrument初期化
    {
        //FormData.CommandLine
        public static List<通貨ぺア取引状況> 通貨ペア初期化()
        {
            if (FormData.FX会社 == Company.FXCM)
            {
                if (FormData.FxServerContry == Contry.JP)
                {
                    return 通貨ペア初期化_FXCMJP();
                }
                else if (FormData.FxServerContry == Contry.UK)
                {
                    return 通貨ペア初期化_FXCMUK();
                }
            }
            else if (FormData.FX会社 == Company.OANDA)
            {
                if (FormData.FxServerContry == Contry.US)
                {
                    var 通貨ぺア取引状況 = 通貨ペア初期化_OANDA_US();

                    Instrument2更新(ref 通貨ぺア取引状況);

                    return 通貨ぺア取引状況;
                }
            }

            return null;
        }

        public static List<通貨ぺア取引状況> 通貨ペア初期化_OANDA_US()
        {
            var 通貨ぺア取引状況 = new List<通貨ぺア取引状況>();

            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_AUD_CAD, Instrument = "AUD/CAD", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 2.57 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_AUD_CHF, Instrument = "AUD/CHF", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 2.00 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_AUD_HKD, Instrument = "AUD/HKD", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 2.00 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_AUD_JPY, Instrument = "AUD/JPY", Rateの少数点桁数 = 3, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 2.57 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_AUD_NZD, Instrument = "AUD/NZD", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 2.57 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_AUD_SGD, Instrument = "AUD/SGD", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 2.00 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_AUD_USD, Instrument = "AUD/USD", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 2.57 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_CAD_CHF, Instrument = "CAD/CHF", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 2.00 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_CAD_HKD, Instrument = "CAD/HKD", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 2.00 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_CAD_JPY, Instrument = "CAD/JPY", Rateの少数点桁数 = 3, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 2.57 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_CAD_SGD, Instrument = "CAD/SGD", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 2.00 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_CHF_HKD, Instrument = "CHF/HKD", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.50 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_CHF_JPY, Instrument = "CHF/JPY", Rateの少数点桁数 = 3, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.50 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_CHF_ZAR, Instrument = "CHF/ZAR", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.50 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_AUD, Instrument = "EUR/AUD", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.64 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_CAD, Instrument = "EUR/CAD", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.64 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_CHF, Instrument = "EUR/CHF", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.38 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_CZK, Instrument = "EUR/CZK", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.38 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_DKK, Instrument = "EUR/DKK", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.71 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_GBP, Instrument = "EUR/GBP", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.38 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_HKD, Instrument = "EUR/HKD", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.38 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_HUF, Instrument = "EUR/HUF", Rateの少数点桁数 = 3, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.38 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_JPY, Instrument = "EUR/JPY", Rateの少数点桁数 = 3, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.64 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_NOK, Instrument = "EUR/NOK", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.64 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_NZD, Instrument = "EUR/NZD", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.64 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_PLN, Instrument = "EUR/PLN", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.38 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_SEK, Instrument = "EUR/SEK", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.64 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_SGD, Instrument = "EUR/SGD", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.38 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_TRY, Instrument = "EUR/TRY", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.38 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_USD, Instrument = "EUR/USD", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.64 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_ZAR, Instrument = "EUR/ZAR", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.38 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_GBP_AUD, Instrument = "GBP/AUD", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.20 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_GBP_CAD, Instrument = "GBP/CAD", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.20 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_GBP_CHF, Instrument = "GBP/CHF", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.20 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_GBP_HKD, Instrument = "GBP/HKD", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.20 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_GBP_JPY, Instrument = "GBP/JPY", Rateの少数点桁数 = 3, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.20 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_GBP_NZD, Instrument = "GBP/NZD", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.20 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_GBP_PLN, Instrument = "GBP/PLN", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.20 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_GBP_SGD, Instrument = "GBP/SGD", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.20 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_GBP_USD, Instrument = "GBP/USD", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.20 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_GBP_ZAR, Instrument = "GBP/ZAR", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.20 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_HKD_JPY, Instrument = "HKD/JPY", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 9.00 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_NZD_CAD, Instrument = "NZD/CAD", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 3.00 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_NZD_CHF, Instrument = "NZD/CHF", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 2.25 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_NZD_HKD, Instrument = "NZD/HKD", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 2.25 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_NZD_JPY, Instrument = "NZD/JPY", Rateの少数点桁数 = 3, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 3.00 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_NZD_SGD, Instrument = "NZD/SGD", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 2.25 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_NZD_USD, Instrument = "NZD/USD", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 3.00 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_SGD_CHF, Instrument = "SGD/CHF", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 2.25 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_SGD_HKD, Instrument = "SGD/HKD", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 2.25 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_SGD_JPY, Instrument = "SGD/JPY", Rateの少数点桁数 = 3, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 2.25 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_TRY_JPY, Instrument = "TRY/JPY", Rateの少数点桁数 = 3, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 6.00 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_CAD, Instrument = "USD/CAD", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 2.00 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_CHF, Instrument = "USD/CHF", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.64 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_CNH, Instrument = "USD/CNH", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.64 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_CZK, Instrument = "USD/CZK", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.64 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_DKK, Instrument = "USD/DKK", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 2.00 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_HKD, Instrument = "USD/HKD", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.64 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_HUF, Instrument = "USD/HUF", Rateの少数点桁数 = 3, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.64 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_INR, Instrument = "USD/INR", Rateの少数点桁数 = 3, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.64 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_JPY, Instrument = "USD/JPY", Rateの少数点桁数 = 3, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 2.00 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_MXN, Instrument = "USD/MXN", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.00 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_NOK, Instrument = "USD/NOK", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 2.00 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_PLN, Instrument = "USD/PLN", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.64 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_SAR, Instrument = "USD/SAR", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.64 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_SEK, Instrument = "USD/SEK", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 2.00 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_SGD, Instrument = "USD/SGD", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.64 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_THB, Instrument = "USD/THB", Rateの少数点桁数 = 3, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.64 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_TRY, Instrument = "USD/TRY", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.64 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_ZAR, Instrument = "USD/ZAR", Rateの少数点桁数 = 5, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 1.64 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_ZAR_JPY, Instrument = "ZAR/JPY", Rateの少数点桁数 = 3, Chkデータ生成 = true, Chk注文 = true, 証拠金倍率 = 20.00 });

            return 通貨ぺア取引状況;
        }


        private static List<通貨ぺア取引状況> 通貨ペア初期化_FXCMJP()
        {
            var 通貨ぺア取引状況 = new List<通貨ぺア取引状況>();

            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_AUD_CAD, Instrument = "AUD/CAD", Chkデータ生成 = true, Chk注文 = false, 維持証拠金 = 4800 });    // 楽天FXには無い為に2016/8/1からのデータが無い	
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_AUD_CHF, Instrument = "AUD/CHF", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_AUD_JPY, Instrument = "AUD/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_AUD_NZD, Instrument = "AUD/NZD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_AUD_USD, Instrument = "AUD/USD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_CAD_CHF, Instrument = "CAD/CHF", Chkデータ生成 = true, Chk注文 = false, 維持証拠金 = 4800 });    // 楽天FXには無い為に2016/8/1からのデータが無い	
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_CAD_JPY, Instrument = "CAD/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_CHF_JPY, Instrument = "CHF/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_AUD, Instrument = "EUR/AUD", Chkデータ生成 = true, Chk注文 = false, 維持証拠金 = 6000 });    // 楽天FXには無い為に2016/8/1からのデータが無い	
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_CAD, Instrument = "EUR/CAD", Chkデータ生成 = true, Chk注文 = false, 維持証拠金 = 6000 });    // 楽天FXには無い為に2016/8/1からのデータが無い	
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_CHF, Instrument = "EUR/CHF", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_GBP, Instrument = "EUR/GBP", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_JPY, Instrument = "EUR/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_NZD, Instrument = "EUR/NZD", Chkデータ生成 = true, Chk注文 = false, 維持証拠金 = 6000 });    // 楽天FXには無い為に2016/8/1からのデータが無い	
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_TRY, Instrument = "EUR/TRY", Chkデータ生成 = true, Chk注文 = false, 維持証拠金 = 4800 });    // 楽天FXには無い為に2016/8/1からのデータが無い	
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_USD, Instrument = "EUR/USD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_GBP_AUD, Instrument = "GBP/AUD", Chkデータ生成 = true, Chk注文 = false, 維持証拠金 = 7200 });    // 楽天FXには無い為に2016/8/1からのデータが無い	
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_GBP_CAD, Instrument = "GBP/CAD", Chkデータ生成 = true, Chk注文 = false, 維持証拠金 = 7200 });    // 楽天FXには無い為に2016/8/1からのデータが無い	
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_GBP_CHF, Instrument = "GBP/CHF", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 7200 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_GBP_JPY, Instrument = "GBP/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 7200 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_GBP_NZD, Instrument = "GBP/NZD", Chkデータ生成 = true, Chk注文 = false, 維持証拠金 = 7200 });    // 楽天FXには無い為に2016/8/1からのデータが無い	
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_GBP_USD, Instrument = "GBP/USD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 7200 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_HKD_JPY, Instrument = "HKD/JPY", Chkデータ生成 = false, Chk注文 = false, 維持証拠金 = 700 });    // UKには無い	//レートの動きが危険	
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_NOK_JPY, Instrument = "NOK/JPY", Chkデータ生成 = false, Chk注文 = false, 維持証拠金 = 6000 });   // UKには無い	//レートの動きが危険	
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_NZD_CAD, Instrument = "NZD/CAD", Chkデータ生成 = true, Chk注文 = false, 維持証拠金 = 4000 });    // 楽天FXには無い為に2016/8/1からのデータが無い	
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_NZD_CHF, Instrument = "NZD/CHF", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4000 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_NZD_JPY, Instrument = "NZD/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4000 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_NZD_USD, Instrument = "NZD/USD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4000 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_SEK_JPY, Instrument = "SEK/JPY", Chkデータ生成 = false, Chk注文 = false, 維持証拠金 = 1200 });   // UKには無い	//必ずマイナスになる	
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_SGD_JPY, Instrument = "SGD/JPY", Chkデータ生成 = false, Chk注文 = false, 維持証拠金 = 3700 });   // UKには無い	//システム障害が発生する	
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_TRY_JPY, Instrument = "TRY/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 2600 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_CAD, Instrument = "USD/CAD", Chkデータ生成 = true, Chk注文 = false, 維持証拠金 = 4800 });    // 楽天FXには無い為に2016/8/1からのデータが無い	
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_CHF, Instrument = "USD/CHF", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_HKD, Instrument = "USD/HKD", Chkデータ生成 = true, Chk注文 = false, 維持証拠金 = 4800 });    // 楽天FXには無い為に2016/8/1からのデータが無い	
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_JPY, Instrument = "USD/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_SGD, Instrument = "USD/SGD", Chkデータ生成 = false, Chk注文 = false, 維持証拠金 = 4800 });   // UKには無い	//必ずマイナスになる	
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_TRY, Instrument = "USD/TRY", Chkデータ生成 = true, Chk注文 = false, 維持証拠金 = 4800 });    // 楽天FXには無い為に2016/8/1からのデータが無い	
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_ZAR, Instrument = "USD/ZAR", Chkデータ生成 = true, Chk注文 = false, 維持証拠金 = 4800 });    // 必ずマイナスになる	
            通貨ぺア取引状況.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_ZAR_JPY, Instrument = "ZAR/JPY", Chkデータ生成 = true, Chk注文 = false, 維持証拠金 = 600 });     // 必ずマイナスになる	

            return 通貨ぺア取引状況;
        }

        private static List<通貨ぺア取引状況> 通貨ペア初期化_FXCMUK()
        {
            var 通貨ペア配列 = new List<通貨ぺア取引状況>();

            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_AUD_CAD, Instrument = "AUD/CAD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_AUD_CHF, Instrument = "AUD/CHF", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_AUD_HKD, Instrument = "AUD/HKD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_AUD_JPY, Instrument = "AUD/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_AUD_NZD, Instrument = "AUD/NZD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_AUD_SGD, Instrument = "AUD/SGD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_AUD_USD, Instrument = "AUD/USD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_CAD_CHF, Instrument = "CAD/CHF", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_CAD_HKD, Instrument = "CAD/HKD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_CAD_JPY, Instrument = "CAD/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_CAD_SGD, Instrument = "CAD/SGD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_CHF_HKD, Instrument = "CHF/HKD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_CHF_JPY, Instrument = "CHF/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_CHF_ZAR, Instrument = "CHF/ZAR", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_AUD, Instrument = "EUR/AUD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_CAD, Instrument = "EUR/CAD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_CHF, Instrument = "EUR/CHF", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_CZK, Instrument = "EUR/CZK", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_DKK, Instrument = "EUR/DKK", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_GBP, Instrument = "EUR/GBP", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_HKD, Instrument = "EUR/HKD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_HUF, Instrument = "EUR/HUF", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_JPY, Instrument = "EUR/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_NOK, Instrument = "EUR/NOK", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_NZD, Instrument = "EUR/NZD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_PLN, Instrument = "EUR/PLN", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_SEK, Instrument = "EUR/SEK", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_SGD, Instrument = "EUR/SGD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_TRY, Instrument = "EUR/TRY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_USD, Instrument = "EUR/USD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_EUR_ZAR, Instrument = "EUR/ZAR", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_GBP_AUD, Instrument = "GBP/AUD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 7200 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_GBP_CAD, Instrument = "GBP/CAD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 7200 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_GBP_CHF, Instrument = "GBP/CHF", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 7200 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_GBP_HKD, Instrument = "GBP/HKD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 7200 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_GBP_JPY, Instrument = "GBP/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 7200 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_GBP_NZD, Instrument = "GBP/NZD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 7200 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_GBP_PLN, Instrument = "GBP/PLN", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 7200 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_GBP_SGD, Instrument = "GBP/SGD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 7200 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_GBP_USD, Instrument = "GBP/USD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 7200 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_GBP_ZAR, Instrument = "GBP/ZAR", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 7200 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_NZD_CAD, Instrument = "NZD/CAD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4000 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_NZD_CHF, Instrument = "NZD/CHF", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4000 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_NZD_HKD, Instrument = "NZD/HKD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4000 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_NZD_JPY, Instrument = "NZD/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4000 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_NZD_SGD, Instrument = "NZD/SGD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4000 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_NZD_USD, Instrument = "NZD/USD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4000 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_SGD_CHF, Instrument = "SGD/CHF", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4000 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_SGD_HKD, Instrument = "SGD/HKD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4000 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_TRY_JPY, Instrument = "TRY/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 2600 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_CAD, Instrument = "USD/CAD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_CHF, Instrument = "USD/CHF", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_CNH, Instrument = "USD/CNH", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_CZK, Instrument = "USD/CZK", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_DKK, Instrument = "USD/DKK", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_HKD, Instrument = "USD/HKD", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_HUF, Instrument = "USD/HUF", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_INR, Instrument = "USD/INR", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_JPY, Instrument = "USD/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_MXN, Instrument = "USD/MXN", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_NOK, Instrument = "USD/NOK", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_PLN, Instrument = "USD/PLN", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_SAR, Instrument = "USD/SAR", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_SEK, Instrument = "USD/SEK", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_THB, Instrument = "USD/THB", Chkデータ生成 = true, Chk注文 = false, 維持証拠金 = 6000 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_TRY, Instrument = "USD/TRY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_USD_ZAR, Instrument = "USD/ZAR", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 4800 });
            通貨ペア配列.Add(new 通貨ぺア取引状況() { 通貨ペアNo = FX定数.No_ZAR_JPY, Instrument = "ZAR/JPY", Chkデータ生成 = true, Chk注文 = true, 維持証拠金 = 600 });

            return 通貨ペア配列;
        }

        private static void Instrument2更新(ref List<通貨ぺア取引状況> 通貨ぺア取引状況List)
        {
            foreach (var 通貨ぺア取引状況 in 通貨ぺア取引状況List)
            {
                通貨ぺア取引状況.Instrument2 = 通貨ぺア取引状況.Instrument.Replace('/', '_');
            }
        }

    }
}
