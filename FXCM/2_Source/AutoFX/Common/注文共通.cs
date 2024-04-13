using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using 定数;
using DB;

namespace Common
{
	public static class 注文共通
	{
        /// <returns>true：15mの一致　false：</returns>
        private static double ChkGC逆判定_Month1_買いWMAs2;
		private static double ChkGC逆判定_Month1_買いWMAs14;
		private static double ChkGC逆判定_Month1_売りWMAs2;
		private static double ChkGC逆判定_Month1_売りWMAs14;
		private static string ChkGC逆判定_Month1_売買判定;
		private static double ChkGC逆判定_Week1_買いWMAs2;
		private static double ChkGC逆判定_Week1_買いWMAs14;
		private static double ChkGC逆判定_Week1_売りWMAs2;
		private static double ChkGC逆判定_Week1_売りWMAs14;
		private static string ChkGC逆判定_Week1_売買判定;
		private static double ChkGC逆判定_Day1_買いWMAs2;
		private static double ChkGC逆判定_Day1_買いWMAs14;
		private static double ChkGC逆判定_Day1_売りWMAs2;
		private static double ChkGC逆判定_Day1_売りWMAs14;
		private static string ChkGC逆判定_Day1_売買判定;
		private static double ChkGC逆判定_Hour1_買いWMAs2;
		private static double ChkGC逆判定_Hour1_買いWMAs14;
		private static double ChkGC逆判定_Hour1_売りWMAs2;
		private static double ChkGC逆判定_Hour1_売りWMAs14;
		private static string ChkGC逆判定_Hour1_売買判定;
		private static double ChkGC逆判定_Min15_買いWMAs2;
		private static double ChkGC逆判定_Min15_買いWMAs14;
		private static double ChkGC逆判定_Min15_売りWMAs2;
		private static double ChkGC逆判定_Min15_売りWMAs14;
		private static string ChkGC逆判定_Min15_売買判定;
		private static double ChkGC逆判定_Min5_買いWMAs2;
		private static double ChkGC逆判定_Min5_買いWMAs14;
		private static double ChkGC逆判定_Min5_売りWMAs2;
		private static double ChkGC逆判定_Min5_売りWMAs14;
		private static string ChkGC逆判定_Min5_売買判定;
		private static double ChkGC逆判定_Min1_買いWMAs2;
		private static double ChkGC逆判定_Min1_買いWMAs14;
		private static double ChkGC逆判定_Min1_売りWMAs2;
		private static double ChkGC逆判定_Min1_売りWMAs14;
		private static string ChkGC逆判定_Min1_売買判定;
		public static bool ChkGC逆判定(SqlConnection cn, byte 通貨ペアNo, DateTime now, string 売買判定15m)
		{
			oder.Get売買判定_Month1(cn, 通貨ペアNo, now,
				ref ChkGC逆判定_Month1_買いWMAs2, ref ChkGC逆判定_Month1_買いWMAs14,
				ref ChkGC逆判定_Month1_売りWMAs2, ref ChkGC逆判定_Month1_売りWMAs14, ref ChkGC逆判定_Month1_売買判定);

			if (!売買判定15m.Equals(ChkGC逆判定_Month1_売買判定)) return false;	// 逆の動きをしているので危険。

			oder.Get売買判定_Week1(cn, 通貨ペアNo, now,
				ref ChkGC逆判定_Week1_買いWMAs2, ref ChkGC逆判定_Week1_買いWMAs14,
				ref ChkGC逆判定_Week1_売りWMAs2, ref ChkGC逆判定_Week1_売りWMAs14, ref ChkGC逆判定_Week1_売買判定);

			if (!売買判定15m.Equals(ChkGC逆判定_Week1_売買判定)) return false;	// 逆の動きをしているので危険。

			oder.Get売買判定_Day1(cn, 通貨ペアNo, now,
				ref ChkGC逆判定_Day1_買いWMAs2, ref ChkGC逆判定_Day1_買いWMAs14,
				ref ChkGC逆判定_Day1_売りWMAs2, ref ChkGC逆判定_Day1_売りWMAs14, ref ChkGC逆判定_Day1_売買判定);

			if (!売買判定15m.Equals(ChkGC逆判定_Day1_売買判定)) return false;	// 逆の動きをしているので危険。

			oder.Get売買判定_Hour1(cn, 通貨ペアNo, now,
				ref ChkGC逆判定_Hour1_買いWMAs2, ref ChkGC逆判定_Hour1_買いWMAs14,
				ref ChkGC逆判定_Hour1_売りWMAs2, ref ChkGC逆判定_Hour1_売りWMAs14, ref ChkGC逆判定_Hour1_売買判定);

			if (!売買判定15m.Equals(ChkGC逆判定_Hour1_売買判定)) return false;	// 逆の動きをしているので危険。

			oder.Get売買判定_Min15(cn, 通貨ペアNo, now,
				ref ChkGC逆判定_Min15_買いWMAs2, ref ChkGC逆判定_Min15_買いWMAs14,
				ref ChkGC逆判定_Min15_売りWMAs2, ref ChkGC逆判定_Min15_売りWMAs14, ref ChkGC逆判定_Min15_売買判定);

			if (!売買判定15m.Equals(ChkGC逆判定_Min15_売買判定)) return false;	// 逆の動きをしているので危険。

			oder.Get売買判定_Min5(cn, 通貨ペアNo, now,
				ref ChkGC逆判定_Min5_買いWMAs2, ref ChkGC逆判定_Min5_買いWMAs14,
				ref ChkGC逆判定_Min5_売りWMAs2, ref ChkGC逆判定_Min5_売りWMAs14, ref ChkGC逆判定_Min5_売買判定);

			if (!売買判定15m.Equals(ChkGC逆判定_Min5_売買判定)) return false;	// 逆の動きをしているので危険。

			oder.Get売買判定_Min1(cn, 通貨ペアNo, now,
				ref ChkGC逆判定_Min1_買いWMAs2, ref ChkGC逆判定_Min1_買いWMAs14,
				ref ChkGC逆判定_Min1_売りWMAs2, ref ChkGC逆判定_Min1_売りWMAs14, ref ChkGC逆判定_Min1_売買判定);

			if (!売買判定15m.Equals(ChkGC逆判定_Min1_売買判定)) return false;	// 逆の動きをしているので危険。

			return true;	// Min15と他の単位で逆の動きはなかったので危険は無い。
		}

		public static double WMA判定_Month1_買いWMAs2;
		public static double WMA判定_Month1_買いWMAs14;
		public static double WMA判定_Month1_売りWMAs2;
		public static double WMA判定_Month1_売りWMAs14;
		public static double WMA判定_Month1_買いWMAs2角度;
		public static double WMA判定_Month1_売りWMAs2角度;
		public static double WMA判定_Week1_買いWMAs2;
		public static double WMA判定_Week1_買いWMAs14;
		public static double WMA判定_Week1_売りWMAs2;
		public static double WMA判定_Week1_売りWMAs14;
		public static double WMA判定_Week1_買いWMAs2角度;
		public static double WMA判定_Week1_売りWMAs2角度;
		public static double WMA判定_Day1_買いWMAs2;
		public static double WMA判定_Day1_買いWMAs14;
		public static double WMA判定_Day1_売りWMAs2;
		public static double WMA判定_Day1_売りWMAs14;
		public static double WMA判定_Day1_買いWMAs2角度;
		public static double WMA判定_Day1_売りWMAs2角度;
		public static double WMA判定_Hour1_買いWMAs2;
		public static double WMA判定_Hour1_買いWMAs14;
		public static double WMA判定_Hour1_売りWMAs2;
		public static double WMA判定_Hour1_売りWMAs14;
		public static double WMA判定_Hour1_買いWMAs2角度;
		public static double WMA判定_Hour1_売りWMAs2角度;
		public static double WMA判定_Min15_買いWMAs2;
		public static double WMA判定_Min15_買いWMAs14;
		public static double WMA判定_Min15_売りWMAs2;
		public static double WMA判定_Min15_売りWMAs14;
		public static double WMA判定_Min15_買いWMAs2角度;
		public static double WMA判定_Min15_売りWMAs2角度;
		public static double WMA判定_Min5_買いWMAs2;
		public static double WMA判定_Min5_買いWMAs14;
		public static double WMA判定_Min5_売りWMAs2;
		public static double WMA判定_Min5_売りWMAs14;
		public static double WMA判定_Min5_買いWMAs2角度;
		public static double WMA判定_Min5_売りWMAs2角度;
		public static double WMA判定_Min1_買いWMAs2;
		public static double WMA判定_Min1_買いWMAs14;
		public static double WMA判定_Min1_売りWMAs2;
		public static double WMA判定_Min1_売りWMAs14;
		public static double WMA判定_Min1_買いWMAs2角度;
		public static double WMA判定_Min1_売りWMAs2角度;
		public static bool WMA判定(SqlConnection cn, byte 通貨ペアNo, double 買いSwap, double 売りSwap,
			DateTime StartMonth1, DateTime StartWeek1, DateTime StartDay1, DateTime StartHour1, DateTime StartMin15, DateTime StartMin5, DateTime StartMin1,
			ref string 売買判定)
		{
			oder.GetWMA_Month1(cn, 通貨ペアNo, StartMonth1,
				ref WMA判定_Month1_買いWMAs2, ref WMA判定_Month1_買いWMAs14, ref WMA判定_Month1_買いWMAs2角度,
				ref WMA判定_Month1_売りWMAs2, ref WMA判定_Month1_売りWMAs14, ref WMA判定_Month1_売りWMAs2角度);

			oder.GetWMA_Week1(cn, 通貨ペアNo, StartWeek1,
				ref WMA判定_Week1_買いWMAs2, ref WMA判定_Week1_買いWMAs14, ref WMA判定_Week1_買いWMAs2角度,
				ref WMA判定_Week1_売りWMAs2, ref WMA判定_Week1_売りWMAs14, ref WMA判定_Week1_売りWMAs2角度);

			oder.GetWMA_Day1(cn, 通貨ペアNo, StartDay1,
				ref WMA判定_Day1_買いWMAs2, ref WMA判定_Day1_買いWMAs14, ref WMA判定_Day1_買いWMAs2角度,
				ref WMA判定_Day1_売りWMAs2, ref WMA判定_Day1_売りWMAs14, ref WMA判定_Day1_売りWMAs2角度);

			oder.GetWMA_Hour1(cn, 通貨ペアNo, StartHour1,
				ref WMA判定_Hour1_買いWMAs2, ref WMA判定_Hour1_買いWMAs14, ref WMA判定_Hour1_買いWMAs2角度,
				ref WMA判定_Hour1_売りWMAs2, ref WMA判定_Hour1_売りWMAs14, ref WMA判定_Hour1_売りWMAs2角度);

			oder.GetWMA_Min15(cn, 通貨ペアNo, StartMin15,
				ref WMA判定_Min15_買いWMAs2, ref WMA判定_Min15_買いWMAs14, ref WMA判定_Min15_買いWMAs2角度,
				ref WMA判定_Min15_売りWMAs2, ref WMA判定_Min15_売りWMAs14, ref WMA判定_Min15_売りWMAs2角度);

			oder.GetWMA_Min5(cn, 通貨ペアNo, StartMin5,
				ref WMA判定_Min5_買いWMAs2, ref WMA判定_Min5_買いWMAs14, ref WMA判定_Min5_買いWMAs2角度,
				ref WMA判定_Min5_売りWMAs2, ref WMA判定_Min5_売りWMAs14, ref WMA判定_Min5_売りWMAs2角度);

			oder.GetWMA_Min1(cn, 通貨ペアNo, StartMin1,
				ref WMA判定_Min1_買いWMAs2, ref WMA判定_Min1_買いWMAs14, ref WMA判定_Min1_買いWMAs2角度,
				ref WMA判定_Min1_売りWMAs2, ref WMA判定_Min1_売りWMAs14, ref WMA判定_Min1_売りWMAs2角度);

			if (買いSwap > 売りSwap && 買いSwap > 0 &&
				WMA判定_Month1_買いWMAs2 > WMA判定_Month1_買いWMAs14 && WMA判定_Month1_買いWMAs2角度 > 0 &&
				WMA判定_Week1_買いWMAs2 > WMA判定_Week1_買いWMAs14 && WMA判定_Week1_買いWMAs2角度 > 0 &&
				WMA判定_Day1_買いWMAs2 > WMA判定_Day1_買いWMAs14 && WMA判定_Day1_買いWMAs2角度 > 0 &&
				WMA判定_Hour1_買いWMAs2 > WMA判定_Hour1_買いWMAs14 && WMA判定_Hour1_買いWMAs2角度 > 0 &&
				WMA判定_Min15_買いWMAs2 > WMA判定_Min15_買いWMAs14 && WMA判定_Min15_買いWMAs2角度 > 0 &&
				WMA判定_Min5_買いWMAs2 > WMA判定_Min5_買いWMAs14 && WMA判定_Min5_買いWMAs2角度 > 0 &&
				WMA判定_Min1_買いWMAs2 > WMA判定_Min1_買いWMAs14 && WMA判定_Min1_買いWMAs2角度 > 0)
			{
				売買判定 = "B";
				return true;
			}
			else if (買いSwap < 売りSwap && 売りSwap > 0 &&
				WMA判定_Month1_売りWMAs2 < WMA判定_Month1_売りWMAs14 && WMA判定_Month1_売りWMAs2角度 < 0 &&
				WMA判定_Week1_売りWMAs2 < WMA判定_Week1_売りWMAs14 && WMA判定_Week1_売りWMAs2角度 < 0 &&
				WMA判定_Day1_売りWMAs2 < WMA判定_Day1_売りWMAs14 && WMA判定_Day1_売りWMAs2角度 < 0 &&
				WMA判定_Hour1_売りWMAs2 < WMA判定_Hour1_売りWMAs14 && WMA判定_Hour1_売りWMAs2角度 < 0 &&
				WMA判定_Min15_売りWMAs2 < WMA判定_Min15_売りWMAs14 && WMA判定_Min15_売りWMAs2角度 < 0 &&
				WMA判定_Min5_売りWMAs2 < WMA判定_Min5_売りWMAs14 && WMA判定_Min5_売りWMAs2角度 < 0 &&
				WMA判定_Min1_売りWMAs2 < WMA判定_Min1_売りWMAs14 && WMA判定_Min1_売りWMAs2角度 < 0)
			{
				売買判定 = "S";
				return true;
			}

			return false;
		}

		public static int Get注文単位(double ロスカット余剰金, double 取引証拠金)
		{
			//int 注文単位 = (int)Math.Ceiling((double)(保有可能ポジション数 - 決算待ちポジション数) / 20); // 20を超える通貨ペアが同時に注文対象になる日なんてないだろ

			// (ロスカット余剰金 - (取引証拠金の15%)) / 25000
			int 注文単位 = (int)Math.Ceiling(((ロスカット余剰金 - (取引証拠金 * システム設定.余剰金割合_Order限界点 / 100)) / システム設定.ポジション1つ辺りの変動リスク) / システム設定.注文可能限界数);

			if (注文単位 < 1)
				return 1;
			else
				return 注文単位;
		}

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

		public static bool GetBool売買(string 買い_モード)
		{
			if (買い_モード == "S")
				return false;
			else
				return true;
		}

		public static DateTime Get当日の開始日時(DateTime dt)
		{
			DateTime Now = dt;

			if (Now.Hour < システム設定.日付はn時くぎり)
				Now = Now.AddDays(-1);

			return DateTime.Parse(Now.Year.ToString() + "/" + Now.Month.ToString() + "/" + Now.Day.ToString() + " " + システム設定.日付はn時くぎり.ToString() + ":00:00");
		}

		private static DateTime 土日を含む場合の調整_時間単位_from;
		private static DateTime 土日を含む場合の調整_時間単位_to;
		public static void 土日を含む場合の調整_時間単位(DateTime now, int iFrom, int iTo, out int iOutFrom, out int iOutTo)
		{
			土日を含む場合の調整_時間単位_from = now.AddHours(iFrom);
			土日を含む場合の調整_時間単位_to = now.AddHours(iTo);

			iOutFrom = iFrom;
			iOutTo = iTo;

			if (土日を含む場合の調整_時間単位_to.DayOfWeek == DayOfWeek.Saturday && 6 <= 土日を含む場合の調整_時間単位_to.Hour)
			{
				iOutFrom = iFrom - 48;
				iOutTo = iTo - 48;
				return;
			}
			else if (土日を含む場合の調整_時間単位_to.DayOfWeek == DayOfWeek.Sunday)
			{
				iOutFrom = iFrom - 48;
				iOutTo = iTo - 48;
				return;
			}
			else if (土日を含む場合の調整_時間単位_to.DayOfWeek == DayOfWeek.Monday && 土日を含む場合の調整_時間単位_to.Hour < 6)
			{
				iOutFrom = iFrom - 48;
				iOutTo = iTo - 48;
				return;
			}

			if (土日を含む場合の調整_時間単位_from.DayOfWeek == DayOfWeek.Saturday && 6 <= 土日を含む場合の調整_時間単位_from.Hour)
				iOutFrom = iFrom - 48;
			else if (土日を含む場合の調整_時間単位_from.DayOfWeek == DayOfWeek.Sunday)
				iOutFrom = iFrom - 48;
			else if (土日を含む場合の調整_時間単位_from.DayOfWeek == DayOfWeek.Monday && 土日を含む場合の調整_時間単位_from.Hour < 6)
				iOutFrom = iFrom - 48;

		}
	}
}
