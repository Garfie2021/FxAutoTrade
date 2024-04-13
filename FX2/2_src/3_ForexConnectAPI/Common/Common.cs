using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	public static class Validate
	{
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
