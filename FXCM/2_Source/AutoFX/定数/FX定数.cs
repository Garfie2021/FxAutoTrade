using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 定数
{
	public static class FX定数
	{
        public enum Company : uint
        {
            FXCMJP = 0,
            FXCMUK = 1,
            OANDA = 2,
        }

        public enum 処理区分 : byte
        {
            None = 0,
            通貨ペア全体の注文処理 = 1,
        }

        public const double シグマ閾値 = 2.5;


        public const byte 通貨ペア数 = 92;

        /// 既存のNoは変更不可 /// 
        public const byte No_AUD_CAD = 0;
        public const byte No_AUD_CHF = 1;
        public const byte No_AUD_HKD = 67;
        public const byte No_AUD_JPY = 2;
        public const byte No_AUD_NZD = 3;
        public const byte No_AUD_SGD = 68;
        public const byte No_AUD_USD = 4;
        public const byte No_CAD_CHF = 5;
        public const byte No_CAD_HKD = 69;
        public const byte No_CAD_JPY = 6;
        public const byte No_CAD_SGD = 70;
        public const byte No_CHF_HKD = 71;
        public const byte No_CHF_JPY = 7;
        public const byte No_CHF_ZAR = 72;
        public const byte No_EUR_AUD = 8;
        public const byte No_EUR_CAD = 9;
        public const byte No_EUR_CHF = 10;
        public const byte No_EUR_CZK = 44;
        public const byte No_EUR_DKK = 73;
        public const byte No_EUR_GBP = 11;
        public const byte No_EUR_HKD = 74;
        public const byte No_EUR_HUF = 75;
        public const byte No_EUR_JPY = 12;
        public const byte No_EUR_NOK = 45;
        public const byte No_EUR_NZD = 13;
        public const byte No_EUR_PLN = 76;
        public const byte No_EUR_SEK = 46;
        public const byte No_EUR_SGD = 76;
        public const byte No_EUR_TRY = 14;
        public const byte No_EUR_USD = 15;
        public const byte No_EUR_ZAR = 77;
        public const byte No_GBP_AUD = 16;
        public const byte No_GBP_CAD = 17;
        public const byte No_GBP_CHF = 18;
        public const byte No_GBP_HKD = 78;
        public const byte No_GBP_JPY = 19;
        public const byte No_GBP_NZD = 20;
        public const byte No_GBP_PLN = 79;
        public const byte No_GBP_SGD = 80;
        public const byte No_GBP_USD = 21;
        public const byte No_GBP_ZAR = 81;
        public const byte No_HKD_JPY = 22;
        public const byte No_NOK_JPY = 23;
        public const byte No_NZD_CAD = 24;
        public const byte No_NZD_CHF = 25;
        public const byte No_NZD_HKD = 82;
        public const byte No_NZD_JPY = 26;
        public const byte No_NZD_SGD = 83;
        public const byte No_NZD_USD = 27;
        public const byte No_SEK_JPY = 28;
        public const byte No_SGD_CHF = 84;
        public const byte No_SGD_HKD = 85;
        public const byte No_SGD_JPY = 29;
        public const byte No_TRY_JPY = 30;
        public const byte No_USD_CAD = 31;
        public const byte No_USD_CHF = 32;
        public const byte No_USD_CNH = 47;
        public const byte No_USD_CZK = 48;
        public const byte No_USD_DKK = 86;
        public const byte No_USD_HKD = 33;
        public const byte No_USD_HUF = 87;
        public const byte No_USD_INR = 88;
        public const byte No_USD_JPY = 34;
        public const byte No_USD_MXN = 50;
        public const byte No_USD_NOK = 49;
        public const byte No_USD_PLN = 89;
        public const byte No_USD_SAR = 90;
        public const byte No_USD_SEK = 51;
        public const byte No_USD_SGD = 35;
        public const byte No_USD_THB = 91;
        public const byte No_USD_TRY = 36;
        public const byte No_USD_ZAR = 37;
        public const byte No_ZAR_JPY = 38;
        public const byte No_XAU_USD = 39;
        public const byte No_XAG_USD = 52;
        public const byte No_AUS200 = 53;
        public const byte No_Bund = 54;
        public const byte No_Copper = 55;
        public const byte No_EUSTX50 = 56;
        public const byte No_ESP35 = 57;
        public const byte No_FRA40 = 58;
        public const byte No_GER30 = 59;
        public const byte No_HKG33 = 60;
        public const byte No_JPN225 = 61;
        public const byte No_NAS100 = 62;
        public const byte No_NGAS = 63;
        public const byte No_UK100 = 64;
        public const byte No_UKOil = 65;
        public const byte No_US30 = 41;
        public const byte No_USDOLLAR = 42;
        public const byte No_USOil = 43;
        public const byte No_SPX500 = 66;

        public const string AUD_CAD = "AUD/CAD";
        public const string AUD_CHF = "AUD/CHF";
        public const string AUD_HKD = "AUD/HKD";
        public const string AUD_JPY = "AUD/JPY";
        public const string AUD_NZD = "AUD/NZD";
        public const string AUD_SGD = "AUD/SGD";
        public const string AUD_USD = "AUD/USD";
        public const string CAD_CHF = "CAD/CHF";
        public const string CAD_HKD = "CAD/HKD";
        public const string CAD_JPY = "CAD/JPY";
        public const string CAD_SGD = "CAD/SGD";
        public const string CHF_HKD = "CHF/HKD";
        public const string CHF_JPY = "CHF/JPY";
        public const string CHF_ZAR = "CHF/ZAR";
        public const string EUR_AUD = "EUR/AUD";
        public const string EUR_CAD = "EUR/CAD";
        public const string EUR_CHF = "EUR/CHF";
        public const string EUR_CZK = "EUR/CZK";
        public const string EUR_DKK = "EUR/DKK";
        public const string EUR_GBP = "EUR/GBP";
        public const string EUR_HKD = "EUR/HKD";
        public const string EUR_HUF = "EUR/HUF";
        public const string EUR_JPY = "EUR/JPY";
        public const string EUR_NOK = "EUR/NOK";
        public const string EUR_NZD = "EUR/NZD";
        public const string EUR_PLN = "EUR/PLN";
        public const string EUR_SEK = "EUR/SEK";
        public const string EUR_SGD = "EUR/SGD";
        public const string EUR_TRY = "EUR/TRY";
        public const string EUR_USD = "EUR/USD";
        public const string EUR_ZAR = "EUR/ZAR";
        public const string GBP_AUD = "GBP/AUD";
        public const string GBP_CAD = "GBP/CAD";
        public const string GBP_CHF = "GBP/CHF";
        public const string GBP_HKD = "GBP/HKD";
        public const string GBP_JPY = "GBP/JPY";
        public const string GBP_NZD = "GBP/NZD";
        public const string GBP_PLN = "GBP/PLN";
        public const string GBP_SGD = "GBP/SGD";
        public const string GBP_USD = "GBP/USD";
        public const string GBP_ZAR = "GBP/ZAR";
        public const string HKD_JPY = "HKD/JPY";
        public const string NOK_JPY = "NOK/JPY";
        public const string NZD_CAD = "NZD/CAD";
        public const string NZD_CHF = "NZD/CHF";
        public const string NZD_HKD = "NZD/HKD";
        public const string NZD_JPY = "NZD/JPY";
        public const string NZD_SGD = "NZD/SGD";
        public const string NZD_USD = "NZD/USD";
        public const string SEK_JPY = "SEK/JPY";
        public const string SGD_CHF = "SGD/CHF";
        public const string SGD_HKD = "SGD/HKD";
        public const string SGD_JPY = "SGD/JPY";
        public const string TRY_JPY = "TRY/JPY";
        public const string USD_CAD = "USD/CAD";
        public const string USD_CHF = "USD/CHF";
        public const string USD_CNH = "USD/CNH";
        public const string USD_CZK = "USD/CZK";
        public const string USD_DKK = "USD/DKK";
        public const string USD_HKD = "USD/HKD";
        public const string USD_HUF = "USD/HUF";
        public const string USD_INR = "USD/INR";
        public const string USD_JPY = "USD/JPY";
        public const string USD_MXN = "USD/MXN";
        public const string USD_NOK = "USD/NOK";
        public const string USD_PLN = "USD/PLN";
        public const string USD_SAR = "USD/SAR";
        public const string USD_SEK = "USD/SEK";
        public const string USD_SGD = "USD/SGD";
        public const string USD_THB = "USD/THB";
        public const string USD_TRY = "USD/TRY";
        public const string USD_ZAR = "USD/ZAR";
        public const string ZAR_JPY = "ZAR/JPY";
        public const string XAU_USD = "XAU/USD";
        public const string XAG_USD = "XAG/USD";
        public const string AUS200 = "AUS200";
        public const string Bund = "Bund";
        public const string Copper = "Copper";
        public const string EUSTX50 = "EUSTX50";
        public const string ESP35 = "ESP35";
        public const string FRA40 = "FRA40";
        public const string GER30 = "GER30";
        public const string HKG33 = "HKG33";
        public const string JPN225 = "JPN225";
        public const string NAS100 = "NAS100";
        public const string NGAS = "NGAS";
        public const string UK100 = "UK100";
        public const string UKOil = "UKOil";
        public const string US30 = "US30";
        public const string USDOLLAR = "USDOLLAR";
        public const string USOil = "USOil";
        public const string SPX500 = "SPX500";

        public const string URL = "www40.fxcorporate.com";
        public const int FXOrder2Go時間補正 = 9;

        public const string trading_server_was_lost = "trading server was lost";
        public const string Market_is_closed = "Market is closed";

        public static string[] 通貨ペア;

        static FX定数()
        {
        	通貨ペア = new string[FX定数.通貨ペア数];
        	通貨ペア[FX定数.No_AUD_CAD] = FX定数.AUD_CAD;
        	通貨ペア[FX定数.No_AUD_CHF] = FX定数.AUD_CHF;
        	通貨ペア[FX定数.No_AUD_JPY] = FX定数.AUD_JPY;
        	通貨ペア[FX定数.No_AUD_NZD] = FX定数.AUD_NZD;
        	通貨ペア[FX定数.No_AUD_USD] = FX定数.AUD_USD;
        	通貨ペア[FX定数.No_CAD_CHF] = FX定数.CAD_CHF;
        	通貨ペア[FX定数.No_CAD_JPY] = FX定数.CAD_JPY;
        	通貨ペア[FX定数.No_CHF_JPY] = FX定数.CHF_JPY;
        	通貨ペア[FX定数.No_EUR_AUD] = FX定数.EUR_AUD;
        	通貨ペア[FX定数.No_EUR_CAD] = FX定数.EUR_CAD;
        	通貨ペア[FX定数.No_EUR_CHF] = FX定数.EUR_CHF;
        	通貨ペア[FX定数.No_EUR_CZK] = FX定数.EUR_CZK;
        	通貨ペア[FX定数.No_EUR_GBP] = FX定数.EUR_GBP;
        	通貨ペア[FX定数.No_EUR_JPY] = FX定数.EUR_JPY;
        	通貨ペア[FX定数.No_EUR_NOK] = FX定数.EUR_NOK;
        	通貨ペア[FX定数.No_EUR_NZD] = FX定数.EUR_NZD;
        	通貨ペア[FX定数.No_EUR_SEK] = FX定数.EUR_SEK;
        	通貨ペア[FX定数.No_EUR_TRY] = FX定数.EUR_TRY;
        	通貨ペア[FX定数.No_EUR_USD] = FX定数.EUR_USD;
        	通貨ペア[FX定数.No_GBP_AUD] = FX定数.GBP_AUD;
        	通貨ペア[FX定数.No_GBP_CAD] = FX定数.GBP_CAD;
        	通貨ペア[FX定数.No_GBP_CHF] = FX定数.GBP_CHF;
        	通貨ペア[FX定数.No_GBP_JPY] = FX定数.GBP_JPY;
        	通貨ペア[FX定数.No_GBP_NZD] = FX定数.GBP_NZD;
        	通貨ペア[FX定数.No_GBP_USD] = FX定数.GBP_USD;
        	通貨ペア[FX定数.No_HKD_JPY] = FX定数.HKD_JPY;
        	通貨ペア[FX定数.No_NOK_JPY] = FX定数.NOK_JPY;
        	通貨ペア[FX定数.No_NZD_CAD] = FX定数.NZD_CAD;
        	通貨ペア[FX定数.No_NZD_CHF] = FX定数.NZD_CHF;
        	通貨ペア[FX定数.No_NZD_JPY] = FX定数.NZD_JPY;
        	通貨ペア[FX定数.No_NZD_USD] = FX定数.NZD_USD;
        	通貨ペア[FX定数.No_SEK_JPY] = FX定数.SEK_JPY;
        	通貨ペア[FX定数.No_SGD_JPY] = FX定数.SGD_JPY;
        	通貨ペア[FX定数.No_TRY_JPY] = FX定数.TRY_JPY;
        	通貨ペア[FX定数.No_USD_CAD] = FX定数.USD_CAD;
        	通貨ペア[FX定数.No_USD_CHF] = FX定数.USD_CHF;
        	通貨ペア[FX定数.No_USD_CNH] = FX定数.USD_CNH;
        	通貨ペア[FX定数.No_USD_CZK] = FX定数.USD_CZK;
        	通貨ペア[FX定数.No_USD_HKD] = FX定数.USD_HKD;
        	通貨ペア[FX定数.No_USD_JPY] = FX定数.USD_JPY;
        	通貨ペア[FX定数.No_USD_MXN] = FX定数.USD_MXN;
            通貨ペア[FX定数.No_USD_NOK] = FX定数.USD_NOK;
            通貨ペア[FX定数.No_USD_SEK] = FX定数.USD_SEK;
            通貨ペア[FX定数.No_USD_SGD] = FX定数.USD_SGD;
        	通貨ペア[FX定数.No_USD_TRY] = FX定数.USD_TRY;
        	通貨ペア[FX定数.No_USD_ZAR] = FX定数.USD_ZAR;
        	通貨ペア[FX定数.No_ZAR_JPY] = FX定数.ZAR_JPY;
        	通貨ペア[FX定数.No_XAU_USD] = FX定数.XAU_USD;
        	通貨ペア[FX定数.No_XAG_USD] = FX定数.XAG_USD;
        	通貨ペア[FX定数.No_AUS200] = FX定数.AUS200;
        	通貨ペア[FX定数.No_Bund] = FX定数.Bund;
        	通貨ペア[FX定数.No_Copper] = FX定数.Copper;
        	通貨ペア[FX定数.No_EUSTX50] = FX定数.EUSTX50;
        	通貨ペア[FX定数.No_ESP35] = FX定数.ESP35;
        	通貨ペア[FX定数.No_FRA40] = FX定数.FRA40;
        	通貨ペア[FX定数.No_GER30] = FX定数.GER30;
        	通貨ペア[FX定数.No_HKG33] = FX定数.HKG33;
        	通貨ペア[FX定数.No_JPN225] = FX定数.JPN225;
        	通貨ペア[FX定数.No_NAS100] = FX定数.NAS100;
        	通貨ペア[FX定数.No_NGAS] = FX定数.NGAS;
        	通貨ペア[FX定数.No_UK100] = FX定数.UK100;
        	通貨ペア[FX定数.No_UKOil] = FX定数.UKOil;
        	通貨ペア[FX定数.No_US30] = FX定数.US30;
        	通貨ペア[FX定数.No_USDOLLAR] = FX定数.USDOLLAR;
        	通貨ペア[FX定数.No_USOil] = FX定数.USOil;
        	通貨ペア[FX定数.No_SPX500] = FX定数.SPX500;

        	//取引状況 = new string[通貨ペア数];
        }

        
	}
}
