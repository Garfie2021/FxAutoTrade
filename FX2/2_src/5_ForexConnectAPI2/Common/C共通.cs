using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
	public static class C共通
	{
		public static int DGVClmNo注文設定_通貨ペア = 0;
		public static int DGVClmNo注文設定_取引状況 = 1;
		public static int DGVClmNo注文設定_保持ポジション = 2;
		public static int DGVClmNo注文設定_売りSwap = 3;
		public static int DGVClmNo注文設定_買いSwap = 4;
		public static int DGVClmNo注文設定_Swap判定 = 5;
		public static int DGVClmNo注文設定_売りRate = 6;
		public static int DGVClmNo注文設定_買いRate = 7;
		public static int DGVClmNo注文設定_Rate終値_1つ前_月 = 8;
		public static int DGVClmNo注文設定_Rate終値_1つ前_週 = 9;
		public static int DGVClmNo注文設定_Rate終値_1つ前_日 = 10;
		public static int DGVClmNo注文設定_Rate終値_1つ前_6h = 11;
		public static int DGVClmNo注文設定_Rate終値_1つ前_1h = 12;
		public static int DGVClmNo注文設定_Rate終値_1つ前_30m = 13;
		public static int DGVClmNo注文設定_Rate終値_1つ前_15m = 14;
		public static int DGVClmNo注文設定_Rate終値_1つ前_5m = 15;
		public static int DGVClmNo注文設定_Rate終値_1つ前_1m = 16;
		public static int DGVClmNo注文設定_WMA今_Monthly = 17;
		public static int DGVClmNo注文設定_WMA_Monthly = 18;
		public static int DGVClmNo注文設定_WMA角度前_Monthly = 19;
		public static int DGVClmNo注文設定_WMA角度今_Monthly = 20;
		public static int DGVClmNo注文設定_WMA角度判定_Monthly = 21;
		public static int DGVClmNo注文設定_WMA判定_Monthly = 22;
		public static int DGVClmNo注文設定_WMA判定_Monthly_S2_GC = 23;
		public static int DGVClmNo注文設定_WMA前_Monthly_S2 = 24;
		public static int DGVClmNo注文設定_WMA今_Monthly_S2 = 25;
		public static int DGVClmNo注文設定_WMA前_Weekly_S2 = 26;
		public static int DGVClmNo注文設定_WMA今_Weekly_S2 = 27;
		public static int DGVClmNo注文設定_WMA前_Daily_S2 = 28;
		public static int DGVClmNo注文設定_WMA今_Daily_S2 = 29;
		public static int DGVClmNo注文設定_WMA前_6h_S2 = 30;
		public static int DGVClmNo注文設定_WMA今_6h_S2 = 31;
		public static int DGVClmNo注文設定_WMA前_1h_S2 = 32;
		public static int DGVClmNo注文設定_WMA今_1h_S2 = 33;
		public static int DGVClmNo注文設定_WMA前_30m_S2 = 34;
		public static int DGVClmNo注文設定_WMA今_30m_S2 = 35;
		public static int DGVClmNo注文設定_WMA前_15m_S2 = 36;
		public static int DGVClmNo注文設定_WMA今_15m_S2 = 37;
		public static int DGVClmNo注文設定_WMA前_5m_S2 = 38;
		public static int DGVClmNo注文設定_WMA今_5m_S2 = 39;
		public static int DGVClmNo注文設定_WMA前_1m_S2 = 40;
		public static int DGVClmNo注文設定_WMA今_1m_S2 = 41;
		public static int DGVClmNo注文設定_売買判定 = 42;
		public static int DGVClmNo注文設定_Rate高値_先月 = 43;
		public static int DGVClmNo注文設定_Rate安値_先月 = 44;
		public static int DGVClmNo注文設定_危険Rate判定_Monthly = 45;
		public static int DGVClmNo注文設定_Rate高値_先週 = 46;
		public static int DGVClmNo注文設定_Rate安値_先週 = 47;
		public static int DGVClmNo注文設定_危険Rate判定_Weekly = 48;
		public static int DGVClmNo注文設定_Rate高値_先日 = 49;
		public static int DGVClmNo注文設定_Rate安値_先日 = 50;
		public static int DGVClmNo注文設定_危険Rate判定_Daily = 51;
		public static int DGVClmNo注文設定_Rate高値_30m前 = 52;
		public static int DGVClmNo注文設定_Rate安値_30m前 = 53;
		public static int DGVClmNo注文設定_Rate高値_15m前 = 54;
		public static int DGVClmNo注文設定_Rate安値_15m前 = 55;
		public static int DGVClmNo注文設定_Rate高値_5m前 = 56;
		public static int DGVClmNo注文設定_Rate安値_5m前 = 57;
		public static int DGVClmNo注文設定_SMLT_シグマ閾値 = 58;
		public static int DGVClmNo注文設定_SMLT_直近1ヵ月の利益Sum = 59;
		public static int DGVClmNo注文設定_高値安値_Monthly = 60;
		public static int DGVClmNo注文設定_高値安値_Weekly = 61;
		public static int DGVClmNo注文設定_高値安値_Daily = 62;
		public static int DGVClmNo注文設定_WMA前_15m = 63;
		public static int DGVClmNo注文設定_WMA今_15m = 64;
		public static int DGVClmNo注文設定_WMA上昇角度_今_15m = 65;
		public static int DGVClmNo注文設定_WMA判定_15m = 66;
		public static int DGVClmNo注文設定_BonusStage判定_前 = 67;
		public static int DGVClmNo注文設定_BonusStage判定_今 = 68;
		public static int DGVClmNo注文設定_注文単位 = 69;
		public static int DGVClmNo注文設定_ポジション数 = 70;
		public static int DGVClmNo注文設定_ポジション増加数 = 71;
		public static int DGVClmNo注文設定_平均差損益減少数 = 72;
		public static int DGVClmNo注文設定_Order間隔最小値 = 73;
		public static int DGVClmNo注文設定_Order間隔 = 74;
		public static int DGVClmNo注文設定_リミット = 75;
		public static int DGVClmNo注文設定_当日Close = 76;
		public static int DGVClmNo注文設定_維持証拠金 = 77;
		public static int DGVClmNo注文設定_維持証拠金小計 = 78;
		public static int DGVClmNo注文設定_GrossPLワースト = 79;
		public static int DGVClmNo注文設定_GrossPL小計 = 80;
		public static int DGVClmNo注文設定_Chkデータ生成 = 81;
		public static int DGVClmNo注文設定_Chk注文 = 82;
		public static int DGVClmNo注文設定_QuoteID = 83;
		public static int DGVClmNo注文設定_DGV列数 = 84;

		public static int FXOrder2Go時間補正 = 9;

		public static string GetTrade時間内()
		{
			if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday && DateTime.Now.Hour > 6)
				return "時間外";
			else if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
				return "時間外";
			else if (DateTime.Now.DayOfWeek == DayOfWeek.Monday && DateTime.Now.Hour < 5)
				return "時間外";
			else
				return "時間内";
		}


	}
}
