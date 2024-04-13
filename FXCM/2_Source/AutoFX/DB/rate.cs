using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using 定数;

namespace DB
{
	public static class rate
	{
		private static SqlCommand cmd;

		public static void InsertRateHistory(SqlConnection cn, byte 通貨ペアNo, DateTime 日時, 
			double Rate_買い, double Rate_売り, double Swap_買い, double Swap_売り)
		{
			cmd = new SqlCommand("rate.spInsertHistory_Sec", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
			cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
			cmd.Parameters["StartDate"].Value = 日時;

			cmd.Parameters.Add(new SqlParameter("買いRate", SqlDbType.Float));
			cmd.Parameters["買いRate"].Direction = ParameterDirection.Input;
			cmd.Parameters["買いRate"].Value = Rate_買い;

			cmd.Parameters.Add(new SqlParameter("売りRate", SqlDbType.Float));
			cmd.Parameters["売りRate"].Direction = ParameterDirection.Input;
			cmd.Parameters["売りRate"].Value = Rate_売り;

			cmd.Parameters.Add(new SqlParameter("買いSwap", SqlDbType.Float));
			cmd.Parameters["買いSwap"].Direction = ParameterDirection.Input;
			cmd.Parameters["買いSwap"].Value = Swap_買い;

			cmd.Parameters.Add(new SqlParameter("売りSwap", SqlDbType.Float));
			cmd.Parameters["売りSwap"].Direction = ParameterDirection.Input;
			cmd.Parameters["売りSwap"].Value = Swap_売り;

			cmd.ExecuteNonQuery();
		}

		public static void InsertRateHistory_Min1(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate, DateTime EndDate)
		{
			cmd = new SqlCommand("rate.spInsertHistory_Min1", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

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

		public static void InsertRateHistory_Min5(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate, DateTime EndDate)
		{
			cmd = new SqlCommand("rate.spInsertHistory_Min5", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

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

		public static void InsertRateHistory_Min15(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate, DateTime EndDate)
		{
			cmd = new SqlCommand("rate.spInsertHistory_Min15", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

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

		public static void InsertRateHistory_Hour1(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate, DateTime EndDate)
		{
			cmd = new SqlCommand("rate.spInsertHistory_Hour1", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

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

		public static void InsertRateHistory_Day1(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate, DateTime EndDate)
		{
			cmd = new SqlCommand("rate.spInsertHistory_Day1", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

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

		public static void InsertRateHistory_Week1(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate, DateTime EndDate)
		{
			cmd = new SqlCommand("rate.spInsertHistory_Week1", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

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

		public static void InsertRateHistory_Month1(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate, DateTime EndDate)
		{
			cmd = new SqlCommand("rate.spInsertHistory_Month1", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

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

		public static void UpdateWMA_Min1(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate, DateTime EndDate)
		{
			cmd = new SqlCommand("rate.spUpdateWMA_Min1", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
			cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
			cmd.Parameters["StartDate"].Value = StartDate;

			cmd.ExecuteNonQuery();
		}

		public static void UpdateWMA_Min5(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate, DateTime EndDate)
		{
			cmd = new SqlCommand("rate.spUpdateWMA_Min5", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
			cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
			cmd.Parameters["StartDate"].Value = StartDate;

			cmd.ExecuteNonQuery();
		}

		public static void UpdateWMA_Min15(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate, DateTime EndDate)
		{
			cmd = new SqlCommand("rate.spUpdateWMA_Min15", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
			cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
			cmd.Parameters["StartDate"].Value = StartDate;

			cmd.ExecuteNonQuery();
		}

		public static void UpdateWMA_Hour1(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate, DateTime EndDate)
		{
			cmd = new SqlCommand("rate.spUpdateWMA_Hour1", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
			cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
			cmd.Parameters["StartDate"].Value = StartDate;

			cmd.ExecuteNonQuery();
		}

		public static void UpdateWMA_Day1(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate, DateTime EndDate)
		{
			cmd = new SqlCommand("rate.spUpdateWMA_Day1", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
			cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
			cmd.Parameters["StartDate"].Value = StartDate;

			cmd.ExecuteNonQuery();
		}

		public static void UpdateWMA_Week1(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate, DateTime EndDate)
		{
			cmd = new SqlCommand("rate.spUpdateWMA_Week1", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
			cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
			cmd.Parameters["StartDate"].Value = StartDate;

			cmd.ExecuteNonQuery();
		}

		public static void UpdateWMA_Month1(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate, DateTime EndDate)
		{
			cmd = new SqlCommand("rate.spUpdateWMA_Month1", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
			cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
			cmd.Parameters["StartDate"].Value = StartDate;

			cmd.ExecuteNonQuery();
		}

	}
}
