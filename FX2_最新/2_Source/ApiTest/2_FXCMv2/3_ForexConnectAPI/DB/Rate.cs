using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DB
{
	public static class rate
	{
		public static void Update_10m(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate, DateTime EndDate)
		{
			SqlCommand cmd = new SqlCommand("rate.SP_UpdateRateHistory_10m", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = dbo.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
			cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
			cmd.Parameters["StartDate"].Value = StartDate;

			cmd.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
			cmd.Parameters["EndDate"].Direction = ParameterDirection.Input;
			cmd.Parameters["EndDate"].Value = EndDate;

			cmd.ExecuteNonQuery();
		}

		public static byte Chk直前でRate相反している(SqlConnection cn, byte 通貨ペアNo, string 売買モード)
		{
			SqlCommand cmd = new SqlCommand("dbo.SP_Chk直前でRate相反している", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = dbo.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("売買モード", SqlDbType.VarChar));
			cmd.Parameters["売買モード"].Direction = ParameterDirection.Input;
			cmd.Parameters["売買モード"].Value = 売買モード;

			cmd.Parameters.Add(new SqlParameter("判定", SqlDbType.TinyInt));
			cmd.Parameters["判定"].Direction = ParameterDirection.Output;

			cmd.ExecuteReader();

			return (byte)cmd.Parameters["判定"].Value;
		}

	}
}
