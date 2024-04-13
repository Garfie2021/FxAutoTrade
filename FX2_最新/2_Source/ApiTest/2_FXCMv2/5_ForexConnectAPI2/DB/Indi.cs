using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DB
{
	public static class Indi
	{
		public static void UpdateWMA_10m(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate)
		{
			SqlCommand cmd = new SqlCommand("indi.SP_UpdateWMA_10m", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = dbo.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
			cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
			cmd.Parameters["StartDate"].Value = StartDate;

			cmd.ExecuteNonQuery();
		}

		public static void UpdateWMA_10mS2(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate)
		{
			SqlCommand cmd = new SqlCommand("indi.SP_UpdateWMA_10mS2", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = dbo.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
			cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
			cmd.Parameters["StartDate"].Value = StartDate;

			cmd.ExecuteNonQuery();
		}

		public static void GetWMA判定_15m_S2のみ(SqlConnection cn, byte 通貨ペアNo, DateTime now, out double WMA前_S2, out double WMA今_S2)
		{
			SqlCommand cmd = new SqlCommand("indi.SP_GetWMA判定_15m_S2のみ", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = dbo.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("now", SqlDbType.DateTime));
			cmd.Parameters["now"].Direction = ParameterDirection.Input;
			cmd.Parameters["now"].Value = now;

			cmd.Parameters.Add(new SqlParameter("WMA前_S2", SqlDbType.Float));
			cmd.Parameters["WMA前_S2"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("WMA今_S2", SqlDbType.Float));
			cmd.Parameters["WMA今_S2"].Direction = ParameterDirection.Output;

			cmd.ExecuteReader();

			WMA前_S2 = (double)cmd.Parameters["WMA前_S2"].Value;
			WMA今_S2 = (double)cmd.Parameters["WMA今_S2"].Value;
		}
	}
}
