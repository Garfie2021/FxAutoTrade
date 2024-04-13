using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using 定数;

namespace DB
{
	public static class hltc
	{
		private static SqlCommand cmd;

		public static void Insert処理時間(SqlConnection cn, byte 処理区分, DateTime 処理開始, DateTime 処理終了)
		{
			cmd = new SqlCommand("hltc.spInsert処理時間", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("処理区分", SqlDbType.TinyInt));
			cmd.Parameters["処理区分"].Direction = ParameterDirection.Input;
			cmd.Parameters["処理区分"].Value = 処理区分;

			cmd.Parameters.Add(new SqlParameter("処理開始", SqlDbType.DateTime));
			cmd.Parameters["処理開始"].Direction = ParameterDirection.Input;
			cmd.Parameters["処理開始"].Value = 処理開始;

			cmd.Parameters.Add(new SqlParameter("処理終了", SqlDbType.DateTime));
			cmd.Parameters["処理終了"].Direction = ParameterDirection.Input;
			cmd.Parameters["処理終了"].Value = 処理終了;

			cmd.ExecuteNonQuery();
		}

		public static void Increment取引状況でデータ不足が発生した件数(SqlConnection cn)
		{
			cmd = new SqlCommand("hltc.SP_Increment取引状況でデータ不足が発生した件数", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.ExecuteNonQuery();
		}

		public static void Increment通常Order件数(SqlConnection cn)
		{
			cmd = new SqlCommand("hltc.SP_Increment通常Order件数", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.ExecuteNonQuery();
		}

		public static void IncrementOrderタイミングCnt(SqlConnection cn)
		{
			cmd = new SqlCommand("hltc.SP_IncrementOrderタイミングCnt", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.ExecuteNonQuery();
		}
	}
}
