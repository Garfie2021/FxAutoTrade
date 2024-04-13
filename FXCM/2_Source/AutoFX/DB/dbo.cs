using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using 定数;

namespace DB
{
	public static class dbo
	{
		public static string GetConnectionStr(string DB名)
		{
#if RELEASE
			return "Data Source=localhost;Initial Catalog=" + DB名 + ";Integrated Security=True";
#else
			return "Data Source=1111.5;Initial Catalog=" + DB名 + ";User ID=sa;Password=1111";
#endif
		}

	}
}
	