using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DB
{
	public static class hltc
	{
		private static SqlCommand cmd;
		private static SqlDataReader Reader;

		public static void Increment通常Order件数(SqlConnection cn)
		{
			cmd = new SqlCommand("hltc.SP_Increment通常Order件数", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = dbo.CommandTimeout;

			cmd.ExecuteNonQuery();
		}

	}
}
