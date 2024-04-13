using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DB
{
	public static class rate
	{
		public static int ScalarCnt(SqlConnection cn, string TradeID)
		{
			SqlCommand cmd = new SqlCommand("rate.SP_ScalarCnt", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = dbo.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("TradeID", SqlDbType.VarChar));
			cmd.Parameters["TradeID"].Direction = ParameterDirection.Input;
			cmd.Parameters["TradeID"].Value = TradeID;

			cmd.ExecuteNonQuery();

			return 1;
		}

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

		public static void InsertRateHistory(SqlConnection cn, byte 通貨ペアNo, DateTime 日時, double Rate_買い, double Rate_売り, double Swap_買い, double Swap_売り)
		{
			SqlCommand cmd = new SqlCommand("dbo.SP_InsertRateHistory", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = dbo.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("日時", SqlDbType.DateTime));
			cmd.Parameters["日時"].Direction = ParameterDirection.Input;
			cmd.Parameters["日時"].Value = 日時;

			cmd.Parameters.Add(new SqlParameter("Rate_買い", SqlDbType.Float));
			cmd.Parameters["Rate_買い"].Direction = ParameterDirection.Input;
			cmd.Parameters["Rate_買い"].Value = Rate_買い;

			cmd.Parameters.Add(new SqlParameter("Rate_売り", SqlDbType.Float));
			cmd.Parameters["Rate_売り"].Direction = ParameterDirection.Input;
			cmd.Parameters["Rate_売り"].Value = Rate_売り;

			cmd.Parameters.Add(new SqlParameter("Swap_買い", SqlDbType.Float));
			cmd.Parameters["Swap_買い"].Direction = ParameterDirection.Input;
			cmd.Parameters["Swap_買い"].Value = Swap_買い;

			cmd.Parameters.Add(new SqlParameter("Swap_売り", SqlDbType.Float));
			cmd.Parameters["Swap_売り"].Direction = ParameterDirection.Input;
			cmd.Parameters["Swap_売り"].Value = Swap_売り;

			cmd.ExecuteNonQuery();
		}

	}
}
