using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FXCM
{
	public static class FXCMConst
	{
		public static int FXOrder2Go時間補正 = 9;
		public static int AtMarket = 5;											// txtシステム設定_AtMarket.Text

		public const byte 通貨ペア数 = 44;
		public static string[] 通貨ペア名List;
		public static bool[] 通貨ペア無効List;	// true:FXCMが取引停止した通貨ペア　False:トレード可能　

		public static byte DGVRowNo_AUD_CAD = 0;
		public static byte DGVRowNo_AUD_CHF = 1;
		public static byte DGVRowNo_AUD_JPY = 2;
		public static byte DGVRowNo_AUD_NZD = 3;
		public static byte DGVRowNo_AUD_USD = 4;
		public static byte DGVRowNo_CAD_CHF = 5;
		public static byte DGVRowNo_CAD_JPY = 6;
		public static byte DGVRowNo_CHF_JPY = 7;
		public static byte DGVRowNo_EUR_AUD = 8;
		public static byte DGVRowNo_EUR_CAD = 9;
		public static byte DGVRowNo_EUR_CHF = 10;
		public static byte DGVRowNo_EUR_GBP = 11;
		public static byte DGVRowNo_EUR_JPY = 12;
		public static byte DGVRowNo_EUR_NZD = 13;
		public static byte DGVRowNo_EUR_TRY = 14;
		public static byte DGVRowNo_EUR_USD = 15;
		public static byte DGVRowNo_GBP_AUD = 16;
		public static byte DGVRowNo_GBP_CAD = 17;
		public static byte DGVRowNo_GBP_CHF = 18;
		public static byte DGVRowNo_GBP_JPY = 19;
		public static byte DGVRowNo_GBP_NZD = 20;
		public static byte DGVRowNo_GBP_USD = 21;
		public static byte DGVRowNo_HKD_JPY = 22;
		public static byte DGVRowNo_NOK_JPY = 23;
		public static byte DGVRowNo_NZD_CAD = 24;
		public static byte DGVRowNo_NZD_CHF = 25;
		public static byte DGVRowNo_NZD_JPY = 26;
		public static byte DGVRowNo_NZD_USD = 27;
		public static byte DGVRowNo_SEK_JPY = 28;
		public static byte DGVRowNo_SGD_JPY = 29;
		public static byte DGVRowNo_TRY_JPY = 30;
		public static byte DGVRowNo_USD_CAD = 31;
		public static byte DGVRowNo_USD_CHF = 32;
		public static byte DGVRowNo_USD_HKD = 33;
		public static byte DGVRowNo_USD_JPY = 34;
		public static byte DGVRowNo_USD_SGD = 35;
		public static byte DGVRowNo_USD_TRY = 36;
		public static byte DGVRowNo_USD_ZAR = 37;
		public static byte DGVRowNo_ZAR_JPY = 38;
		public static byte DGVRowNo_XAU_USD = 39;
		public static byte DGVRowNo_JPN225 = 40;
		public static byte DGVRowNo_US30 = 41;
		public static byte DGVRowNo_USDOLLAR = 42;
		public static byte DGVRowNo_USOil = 43;

		public static string AUD_CAD = "AUD/CAD";
		public static string AUD_CHF = "AUD/CHF";
		public static string AUD_JPY = "AUD/JPY";
		public static string AUD_NZD = "AUD/NZD";
		public static string AUD_USD = "AUD/USD";
		public static string CAD_CHF = "CAD/CHF";
		public static string CAD_JPY = "CAD/JPY";
		public static string CHF_JPY = "CHF/JPY";
		public static string EUR_AUD = "EUR/AUD";
		public static string EUR_CAD = "EUR/CAD";
		public static string EUR_CHF = "EUR/CHF";
		public static string EUR_GBP = "EUR/GBP";
		public static string EUR_JPY = "EUR/JPY";
		public static string EUR_NZD = "EUR/NZD";
		public static string EUR_TRY = "EUR/TRY";
		public static string EUR_USD = "EUR/USD";
		public static string GBP_AUD = "GBP/AUD";
		public static string GBP_CAD = "GBP/CAD";
		public static string GBP_CHF = "GBP/CHF";
		public static string GBP_JPY = "GBP/JPY";
		public static string GBP_NZD = "GBP/NZD";
		public static string GBP_USD = "GBP/USD";
		public static string HKD_JPY = "HKD/JPY";
		public static string NOK_JPY = "NOK/JPY";
		public static string NZD_CAD = "NZD/CAD";
		public static string NZD_CHF = "NZD/CHF";
		public static string NZD_JPY = "NZD/JPY";
		public static string NZD_USD = "NZD/USD";
		public static string SEK_JPY = "SEK/JPY";
		public static string SGD_JPY = "SGD/JPY";
		public static string TRY_JPY = "TRY/JPY";
		public static string USD_CAD = "USD/CAD";
		public static string USD_CHF = "USD/CHF";
		public static string USD_HKD = "USD/HKD";
		public static string USD_JPY = "USD/JPY";
		public static string USD_SGD = "USD/SGD";
		public static string USD_TRY = "USD/TRY";
		public static string USD_ZAR = "USD/ZAR";
		public static string ZAR_JPY = "ZAR/JPY";
		public static string XAU_USD = "XAU/USD";
		public static string JPN225 = "JPN225";
		public static string US30 = "US30";
		public static string USDOLLAR = "USDOLLAR";
		public static string USOil = "USOil";

		/// <summary>
		/// staticコンストラクタ
		/// </summary>
		static FXCMConst()
		{
			通貨ペア名List = new string[通貨ペア数];
			通貨ペア名List[FXCMConst.DGVRowNo_AUD_CAD] = FXCMConst.AUD_CAD;
			通貨ペア名List[FXCMConst.DGVRowNo_AUD_CHF] = FXCMConst.AUD_CHF;
			通貨ペア名List[FXCMConst.DGVRowNo_AUD_JPY] = FXCMConst.AUD_JPY;
			通貨ペア名List[FXCMConst.DGVRowNo_AUD_NZD] = FXCMConst.AUD_NZD;
			通貨ペア名List[FXCMConst.DGVRowNo_AUD_USD] = FXCMConst.AUD_USD;
			通貨ペア名List[FXCMConst.DGVRowNo_CAD_CHF] = FXCMConst.CAD_CHF;
			通貨ペア名List[FXCMConst.DGVRowNo_CAD_JPY] = FXCMConst.CAD_JPY;
			通貨ペア名List[FXCMConst.DGVRowNo_CHF_JPY] = FXCMConst.CHF_JPY;
			通貨ペア名List[FXCMConst.DGVRowNo_EUR_AUD] = FXCMConst.EUR_AUD;
			通貨ペア名List[FXCMConst.DGVRowNo_EUR_CAD] = FXCMConst.EUR_CAD;
			通貨ペア名List[FXCMConst.DGVRowNo_EUR_CHF] = FXCMConst.EUR_CHF;
			通貨ペア名List[FXCMConst.DGVRowNo_EUR_GBP] = FXCMConst.EUR_GBP;
			通貨ペア名List[FXCMConst.DGVRowNo_EUR_JPY] = FXCMConst.EUR_JPY;
			通貨ペア名List[FXCMConst.DGVRowNo_EUR_NZD] = FXCMConst.EUR_NZD;
			通貨ペア名List[FXCMConst.DGVRowNo_EUR_TRY] = FXCMConst.EUR_TRY;
			通貨ペア名List[FXCMConst.DGVRowNo_EUR_USD] = FXCMConst.EUR_USD;
			通貨ペア名List[FXCMConst.DGVRowNo_GBP_AUD] = FXCMConst.GBP_AUD;
			通貨ペア名List[FXCMConst.DGVRowNo_GBP_CAD] = FXCMConst.GBP_CAD;
			通貨ペア名List[FXCMConst.DGVRowNo_GBP_CHF] = FXCMConst.GBP_CHF;
			通貨ペア名List[FXCMConst.DGVRowNo_GBP_JPY] = FXCMConst.GBP_JPY;
			通貨ペア名List[FXCMConst.DGVRowNo_GBP_NZD] = FXCMConst.GBP_NZD;
			通貨ペア名List[FXCMConst.DGVRowNo_GBP_USD] = FXCMConst.GBP_USD;
			通貨ペア名List[FXCMConst.DGVRowNo_HKD_JPY] = FXCMConst.HKD_JPY;
			通貨ペア名List[FXCMConst.DGVRowNo_NOK_JPY] = FXCMConst.NOK_JPY;
			通貨ペア名List[FXCMConst.DGVRowNo_NZD_CAD] = FXCMConst.NZD_CAD;
			通貨ペア名List[FXCMConst.DGVRowNo_NZD_CHF] = FXCMConst.NZD_CHF;
			通貨ペア名List[FXCMConst.DGVRowNo_NZD_JPY] = FXCMConst.NZD_JPY;
			通貨ペア名List[FXCMConst.DGVRowNo_NZD_USD] = FXCMConst.NZD_USD;
			通貨ペア名List[FXCMConst.DGVRowNo_SEK_JPY] = FXCMConst.SEK_JPY;
			通貨ペア名List[FXCMConst.DGVRowNo_SGD_JPY] = FXCMConst.SGD_JPY;
			通貨ペア名List[FXCMConst.DGVRowNo_TRY_JPY] = FXCMConst.TRY_JPY;
			通貨ペア名List[FXCMConst.DGVRowNo_USD_CAD] = FXCMConst.USD_CAD;
			通貨ペア名List[FXCMConst.DGVRowNo_USD_CHF] = FXCMConst.USD_CHF;
			通貨ペア名List[FXCMConst.DGVRowNo_USD_HKD] = FXCMConst.USD_HKD;
			通貨ペア名List[FXCMConst.DGVRowNo_USD_JPY] = FXCMConst.USD_JPY;
			通貨ペア名List[FXCMConst.DGVRowNo_USD_SGD] = FXCMConst.USD_SGD;
			通貨ペア名List[FXCMConst.DGVRowNo_USD_TRY] = FXCMConst.USD_TRY;
			通貨ペア名List[FXCMConst.DGVRowNo_USD_ZAR] = FXCMConst.USD_ZAR;
			通貨ペア名List[FXCMConst.DGVRowNo_ZAR_JPY] = FXCMConst.ZAR_JPY;
			通貨ペア名List[FXCMConst.DGVRowNo_XAU_USD] = FXCMConst.XAU_USD;
			通貨ペア名List[FXCMConst.DGVRowNo_JPN225] = FXCMConst.JPN225;
			通貨ペア名List[FXCMConst.DGVRowNo_US30] = FXCMConst.US30;
			通貨ペア名List[FXCMConst.DGVRowNo_USDOLLAR] = FXCMConst.USDOLLAR;
			通貨ペア名List[FXCMConst.DGVRowNo_USOil] = FXCMConst.USOil;

			通貨ペア無効List = new bool[通貨ペア数];
			通貨ペア無効List[FXCMConst.DGVRowNo_AUD_CAD] = false;
			通貨ペア無効List[FXCMConst.DGVRowNo_AUD_CHF] = false;
			通貨ペア無効List[FXCMConst.DGVRowNo_AUD_JPY] = false;
			通貨ペア無効List[FXCMConst.DGVRowNo_AUD_NZD] = false;
			通貨ペア無効List[FXCMConst.DGVRowNo_AUD_USD] = false;
			通貨ペア無効List[FXCMConst.DGVRowNo_CAD_CHF] = false;
			通貨ペア無効List[FXCMConst.DGVRowNo_CAD_JPY] = false;
			通貨ペア無効List[FXCMConst.DGVRowNo_CHF_JPY] = false;
			通貨ペア無効List[FXCMConst.DGVRowNo_EUR_AUD] = false;
			通貨ペア無効List[FXCMConst.DGVRowNo_EUR_CAD] = false;
			通貨ペア無効List[FXCMConst.DGVRowNo_EUR_CHF] = false;
			通貨ペア無効List[FXCMConst.DGVRowNo_EUR_GBP] = false;
			通貨ペア無効List[FXCMConst.DGVRowNo_EUR_JPY] = false;
			通貨ペア無効List[FXCMConst.DGVRowNo_EUR_NZD] = false;
			通貨ペア無効List[FXCMConst.DGVRowNo_EUR_TRY] = false;
			通貨ペア無効List[FXCMConst.DGVRowNo_EUR_USD] = false;
			通貨ペア無効List[FXCMConst.DGVRowNo_GBP_AUD] = false;
			通貨ペア無効List[FXCMConst.DGVRowNo_GBP_CAD] = false;
			通貨ペア無効List[FXCMConst.DGVRowNo_GBP_CHF] = false;
			通貨ペア無効List[FXCMConst.DGVRowNo_GBP_JPY] = false;
			通貨ペア無効List[FXCMConst.DGVRowNo_GBP_NZD] = false;
			通貨ペア無効List[FXCMConst.DGVRowNo_GBP_USD] = false;
			通貨ペア無効List[FXCMConst.DGVRowNo_HKD_JPY] = true;
			通貨ペア無効List[FXCMConst.DGVRowNo_NOK_JPY] = true;
			通貨ペア無効List[FXCMConst.DGVRowNo_NZD_CAD] = false;
			通貨ペア無効List[FXCMConst.DGVRowNo_NZD_CHF] = false;
			通貨ペア無効List[FXCMConst.DGVRowNo_NZD_JPY] = false;
			通貨ペア無効List[FXCMConst.DGVRowNo_NZD_USD] = false;
			通貨ペア無効List[FXCMConst.DGVRowNo_SEK_JPY] = true;
			通貨ペア無効List[FXCMConst.DGVRowNo_SGD_JPY] = true;
			通貨ペア無効List[FXCMConst.DGVRowNo_TRY_JPY] = false;
			通貨ペア無効List[FXCMConst.DGVRowNo_USD_CAD] = false;
			通貨ペア無効List[FXCMConst.DGVRowNo_USD_CHF] = false;
			通貨ペア無効List[FXCMConst.DGVRowNo_USD_HKD] = false;
			通貨ペア無効List[FXCMConst.DGVRowNo_USD_JPY] = false;
			通貨ペア無効List[FXCMConst.DGVRowNo_USD_SGD] = true;
			通貨ペア無効List[FXCMConst.DGVRowNo_USD_TRY] = false;
			通貨ペア無効List[FXCMConst.DGVRowNo_USD_ZAR] = true;
			通貨ペア無効List[FXCMConst.DGVRowNo_ZAR_JPY] = true;
			通貨ペア無効List[FXCMConst.DGVRowNo_XAU_USD] = true;
			通貨ペア無効List[FXCMConst.DGVRowNo_JPN225] = true;
			通貨ペア無効List[FXCMConst.DGVRowNo_US30] = true;
			通貨ペア無効List[FXCMConst.DGVRowNo_USDOLLAR] = true;
			通貨ペア無効List[FXCMConst.DGVRowNo_USOil] = true;
		}

		public static bool GetTradeDesk売買モード_toBool(string 売買モード)
		{
			if (売買モード == "B")
			{
				return true;
			}
			else if (売買モード == "S")
			{
				return false;
			}

			return true;
		}

		//public static string GetURL(string connection)
		//{
		//	if (connection == "Real")
		//	{
		//		//return "fxcmj.fxcorporate.com/Hosts.jsp";
		//		return "http://www40.fxcorporate.com";
		//	}
		//	else
		//	{
		//		//return "www.fxcorporate.com";
		//		return "http://www40.fxcorporate.com";
		//	}
		//}

	}
}
