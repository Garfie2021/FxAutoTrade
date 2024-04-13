using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using 定数;

namespace DB
{
	public static class cmn
	{
		private static SqlCommand cmd;

		public static void Getリミット_BS終了時(SqlConnection cn, byte 通貨ペアNo, out double 買いリミット, out double 売りリミット)
		{
			cmd = new SqlCommand("cmn.spGetリミット_BS終了時", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("買いリミット", SqlDbType.Float));
			cmd.Parameters["買いリミット"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りリミット", SqlDbType.Float));
			cmd.Parameters["売りリミット"].Direction = ParameterDirection.Output;

			cmd.ExecuteNonQuery();

			買いリミット = (double)cmd.Parameters["買いリミット"].Value;
			売りリミット = (double)cmd.Parameters["売りリミット"].Value;
		}

		public static void Get差分リミット(SqlConnection cn, byte 通貨ペアNo, out double 差分リミット)
		{
			cmd = new SqlCommand("cmn.spGet差分リミット", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("差分リミット", SqlDbType.Float));
			cmd.Parameters["差分リミット"].Direction = ParameterDirection.Output;

			cmd.ExecuteNonQuery();

			差分リミット = (double)cmd.Parameters["差分リミット"].Value;
		}

		public static double Get注文禁止ポジション間隔(SqlConnection cn, byte 通貨ペアNo)
		{
			cmd = new SqlCommand("cmn.spGet注文禁止ポジション間隔", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("注文禁止ポジション間隔", SqlDbType.Float));
			cmd.Parameters["注文禁止ポジション間隔"].Direction = ParameterDirection.Output;

			cmd.ExecuteNonQuery();

			return (double)cmd.Parameters["注文禁止ポジション間隔"].Value;
		}

		public static void GetThisMonth1(SqlConnection cn, DateTime now, out DateTime StartDate, out DateTime EndDate)
		{
			cmd = new SqlCommand("cmn.spGetThisMonth1", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("now", SqlDbType.DateTime));
			cmd.Parameters["now"].Direction = ParameterDirection.Input;
			cmd.Parameters["now"].Value = now;

			cmd.Parameters.Add(new SqlParameter("back_Month1", SqlDbType.Int));
			cmd.Parameters["back_Month1"].Direction = ParameterDirection.Input;
			cmd.Parameters["back_Month1"].Value = 0;

			cmd.Parameters.Add(new SqlParameter("ThisMonth1", SqlDbType.DateTime));
			cmd.Parameters["ThisMonth1"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
			cmd.Parameters["StartDate"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
			cmd.Parameters["EndDate"].Direction = ParameterDirection.Output;

			cmd.ExecuteNonQuery();

			StartDate = (DateTime)cmd.Parameters["StartDate"].Value;
			EndDate = (DateTime)cmd.Parameters["EndDate"].Value;
		}

		public static void GetThisWeek1(SqlConnection cn, DateTime now, out DateTime StartDate, out DateTime EndDate)
		{
			cmd = new SqlCommand("cmn.spGetThisWeek1", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("now", SqlDbType.DateTime));
			cmd.Parameters["now"].Direction = ParameterDirection.Input;
			cmd.Parameters["now"].Value = now;

			cmd.Parameters.Add(new SqlParameter("back_Week1", SqlDbType.Int));
			cmd.Parameters["back_Week1"].Direction = ParameterDirection.Input;
			cmd.Parameters["back_Week1"].Value = 0;

			cmd.Parameters.Add(new SqlParameter("ThisWeek1", SqlDbType.DateTime));
			cmd.Parameters["ThisWeek1"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
			cmd.Parameters["StartDate"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
			cmd.Parameters["EndDate"].Direction = ParameterDirection.Output;

			cmd.ExecuteNonQuery();

			StartDate = (DateTime)cmd.Parameters["StartDate"].Value;
			EndDate = (DateTime)cmd.Parameters["EndDate"].Value;
		}

		public static void GetThisDay1(SqlConnection cn, DateTime now, out DateTime StartDate, out DateTime EndDate)
		{
			cmd = new SqlCommand("cmn.spGetThisDay1", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("now", SqlDbType.DateTime));
			cmd.Parameters["now"].Direction = ParameterDirection.Input;
			cmd.Parameters["now"].Value = now;

			cmd.Parameters.Add(new SqlParameter("back_Day1", SqlDbType.Int));
			cmd.Parameters["back_Day1"].Direction = ParameterDirection.Input;
			cmd.Parameters["back_Day1"].Value = 0;

			cmd.Parameters.Add(new SqlParameter("ThisDay1", SqlDbType.DateTime));
			cmd.Parameters["ThisDay1"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
			cmd.Parameters["StartDate"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
			cmd.Parameters["EndDate"].Direction = ParameterDirection.Output;

			cmd.ExecuteNonQuery();

			StartDate = (DateTime)cmd.Parameters["StartDate"].Value;
			EndDate = (DateTime)cmd.Parameters["EndDate"].Value;
		}

		public static void GetThisHour1(SqlConnection cn, DateTime now, out DateTime StartDate, out DateTime EndDate)
		{
			cmd = new SqlCommand("cmn.spGetThisHour1", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("now", SqlDbType.DateTime));
			cmd.Parameters["now"].Direction = ParameterDirection.Input;
			cmd.Parameters["now"].Value = now;

			cmd.Parameters.Add(new SqlParameter("back_Hour1", SqlDbType.Int));
			cmd.Parameters["back_Hour1"].Direction = ParameterDirection.Input;
			cmd.Parameters["back_Hour1"].Value = 0;

			cmd.Parameters.Add(new SqlParameter("StartHour1", SqlDbType.DateTime));
			cmd.Parameters["StartHour1"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("EndHour1", SqlDbType.DateTime));
			cmd.Parameters["EndHour1"].Direction = ParameterDirection.Output;

			cmd.ExecuteNonQuery();

			StartDate = (DateTime)cmd.Parameters["StartHour1"].Value;
			EndDate = (DateTime)cmd.Parameters["EndHour1"].Value;
		}

		public static void GetThisMin15(SqlConnection cn, DateTime now, out DateTime StartDate, out DateTime EndDate)
		{
			cmd = new SqlCommand("cmn.spGetThisMin15", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("now", SqlDbType.DateTime));
			cmd.Parameters["now"].Direction = ParameterDirection.Input;
			cmd.Parameters["now"].Value = now;

			cmd.Parameters.Add(new SqlParameter("back_Min15", SqlDbType.Int));
			cmd.Parameters["back_Min15"].Direction = ParameterDirection.Input;
			cmd.Parameters["back_Min15"].Value = 0;

			cmd.Parameters.Add(new SqlParameter("StartMin15", SqlDbType.DateTime));
			cmd.Parameters["StartMin15"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("EndMin15", SqlDbType.DateTime));
			cmd.Parameters["EndMin15"].Direction = ParameterDirection.Output;

			cmd.ExecuteNonQuery();

			StartDate = (DateTime)cmd.Parameters["StartMin15"].Value;
			EndDate = (DateTime)cmd.Parameters["EndMin15"].Value;
		}

		public static void GetThisMin5(SqlConnection cn, DateTime now, out DateTime StartDate, out DateTime EndDate)
		{
			cmd = new SqlCommand("cmn.spGetThisMin5", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("now", SqlDbType.DateTime));
			cmd.Parameters["now"].Direction = ParameterDirection.Input;
			cmd.Parameters["now"].Value = now;

			cmd.Parameters.Add(new SqlParameter("back_Min5", SqlDbType.Int));
			cmd.Parameters["back_Min5"].Direction = ParameterDirection.Input;
			cmd.Parameters["back_Min5"].Value = 0;

			cmd.Parameters.Add(new SqlParameter("StartMin5", SqlDbType.DateTime));
			cmd.Parameters["StartMin5"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("EndMin5", SqlDbType.DateTime));
			cmd.Parameters["EndMin5"].Direction = ParameterDirection.Output;

			cmd.ExecuteNonQuery();

			StartDate = (DateTime)cmd.Parameters["StartMin5"].Value;
			EndDate = (DateTime)cmd.Parameters["EndMin5"].Value;
		}

		public static void GetThisMin1(SqlConnection cn, DateTime now, out DateTime StartDate, out DateTime EndDate)
		{
			cmd = new SqlCommand("cmn.spGetThisMin1", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("now", SqlDbType.DateTime));
			cmd.Parameters["now"].Direction = ParameterDirection.Input;
			cmd.Parameters["now"].Value = now;

			cmd.Parameters.Add(new SqlParameter("back_Min1", SqlDbType.Int));
			cmd.Parameters["back_Min1"].Direction = ParameterDirection.Input;
			cmd.Parameters["back_Min1"].Value = 0;

			cmd.Parameters.Add(new SqlParameter("StartMin1", SqlDbType.DateTime));
			cmd.Parameters["StartMin1"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("EndMin1", SqlDbType.DateTime));
			cmd.Parameters["EndMin1"].Direction = ParameterDirection.Output;

			cmd.ExecuteNonQuery();

			StartDate = (DateTime)cmd.Parameters["StartMin1"].Value;
			EndDate = (DateTime)cmd.Parameters["EndMin1"].Value;
		}

		public static void UpdateSettings(SqlConnection cn, byte No, string 備考1, string 備考2, double 値)
		{
			cmd = new SqlCommand("cmn.spUpdateSettings", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("No", SqlDbType.TinyInt));
			cmd.Parameters["No"].Direction = ParameterDirection.Input;
			cmd.Parameters["No"].Value = No;

			cmd.Parameters.Add(new SqlParameter("値", SqlDbType.Float));
			cmd.Parameters["値"].Direction = ParameterDirection.Input;
			cmd.Parameters["値"].Value = 値;

			cmd.Parameters.Add(new SqlParameter("備考1", SqlDbType.VarChar));
			cmd.Parameters["備考1"].Direction = ParameterDirection.Input;
			cmd.Parameters["備考1"].Value = 備考1;

			cmd.Parameters.Add(new SqlParameter("備考2", SqlDbType.VarChar));
			cmd.Parameters["備考2"].Direction = ParameterDirection.Input;
			cmd.Parameters["備考2"].Value = 備考2;

			cmd.ExecuteNonQuery();
		}
	}
}
