using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DB
{
	public static class dbo
	{
		public static int CommandTimeout = 600000000;	// 10分

		public static string ConnectionString()
		{
#if RELEASE
			return "Data Source=localhost;Initial Catalog=FX2_Demo;Integrated Security=True";
#else
			return "Data Source=1111.5;Initial Catalog=FX2_Demo;User ID=sa;Password=1111";
#endif
		}
	}
}
