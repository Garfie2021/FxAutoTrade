using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	public static class StartDate
	{
		public static DateTime Get1m(DateTime now)
		{
			return DateTime.Parse(now.Year + "/" + now.Month + "/" + now.Day + " " + now.Hour + ":" + now.Minute + ":00");
		}

		private static byte GetStartDate_5m_Minuts;
		public static DateTime Get5m(DateTime now)
		{
			if (now.Minute < 5)
			{
				GetStartDate_5m_Minuts = 0;
			}
			else if (now.Minute < 10)
			{
				GetStartDate_5m_Minuts = 5;
			}
			else if (now.Minute < 15)
			{
				GetStartDate_5m_Minuts = 10;
			}
			else if (now.Minute < 20)
			{
				GetStartDate_5m_Minuts = 15;
			}
			else if (now.Minute < 25)
			{
				GetStartDate_5m_Minuts = 20;
			}
			else if (now.Minute < 30)
			{
				GetStartDate_5m_Minuts = 25;
			}
			else if (now.Minute < 35)
			{
				GetStartDate_5m_Minuts = 30;
			}
			else if (now.Minute < 40)
			{
				GetStartDate_5m_Minuts = 35;
			}
			else if (now.Minute < 45)
			{
				GetStartDate_5m_Minuts = 40;
			}
			else if (now.Minute < 50)
			{
				GetStartDate_5m_Minuts = 45;
			}
			else if (now.Minute <= 55)
			{
				GetStartDate_5m_Minuts = 50;
			}
			else
			{
				GetStartDate_5m_Minuts = 55;
			}

			return DateTime.Parse(now.Year + "/" + now.Month + "/" + now.Day + " " + now.Hour + ":" + GetStartDate_5m_Minuts.ToString() + ":00");
		}

		private static byte GetStartDate_10m_Minuts;
		public static DateTime Get10m(DateTime now)
		{
			if (now.Minute < 10)
			{
				GetStartDate_10m_Minuts = 0;
			}
			else if (now.Minute < 20)
			{
				GetStartDate_10m_Minuts = 10;
			}
			else if (now.Minute < 30)
			{
				GetStartDate_10m_Minuts = 20;
			}
			else if (now.Minute < 40)
			{
				GetStartDate_10m_Minuts = 30;
			}
			else if (now.Minute < 50)
			{
				GetStartDate_10m_Minuts = 40;
			}
			else
			{
				GetStartDate_10m_Minuts = 50;
			}

			return DateTime.Parse(now.Year + "/" + now.Month + "/" + now.Day + " " + now.Hour + ":" + GetStartDate_15m_Minuts.ToString() + ":00");
		}

		private static byte GetStartDate_15m_Minuts;
		public static DateTime Get15m(DateTime now)
		{
			if (now.Minute < 15)
			{
				GetStartDate_15m_Minuts = 0;
			}
			else if (now.Minute < 30)
			{
				GetStartDate_15m_Minuts = 15;
			}
			else if (now.Minute < 45)
			{
				GetStartDate_15m_Minuts = 30;
			}
			else
			{
				GetStartDate_15m_Minuts = 45;
			}

			return DateTime.Parse(now.Year + "/" + now.Month + "/" + now.Day + " " + now.Hour + ":" + GetStartDate_15m_Minuts.ToString() + ":00");
		}

		private static byte GetStartDate_30m_Minuts;
		public static DateTime Get30m(DateTime now)
		{
			if (now.Minute < 30)
			{
				GetStartDate_30m_Minuts = 0;
			}
			else
			{
				GetStartDate_30m_Minuts = 30;
			}

			return DateTime.Parse(now.Year + "/" + now.Month + "/" + now.Day + " " + now.Hour + ":" + GetStartDate_30m_Minuts.ToString() + ":00");
		}
	}
}
