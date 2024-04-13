using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DB
{
	public static class hltc
	{
		public static void Increment通常Order件数(SqlConnection cn)
		{
			SqlCommand cmd = new SqlCommand("hltc.SP_Increment通常Order件数", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = dbo.CommandTimeout;

			cmd.ExecuteNonQuery();
		}

	}
}
