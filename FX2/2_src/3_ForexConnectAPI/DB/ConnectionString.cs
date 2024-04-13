using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
	public static class ConnectionString
	{
		public static string DemoA_FX()
		{
			#if RELEASE
			return "Data Source=localhost;Initial Catalog=DemoA_FX;Integrated Security=True";
			#else
			return "Data Source=1111;Initial Catalog=DemoA_FX;User ID=sa;Password=1111";
			#endif
		}

		public static string DemoB_FX()
		{
			#if RELEASE
			return "Data Source=localhost;Initial Catalog=DemoB_FX;Integrated Security=True";
			#else
			return "Data Source=1111;Initial Catalog=DemoB_FX;User ID=sa;Password=1111";
			#endif
		}
	}
}
