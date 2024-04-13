using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using 定数;

namespace DB
{
	public static class hstr
	{
		private static SqlCommand cmd;

		public static void InsertBS(SqlConnection cn,
			DateTime 日時,
			byte 通貨ペアNo,
			double 買いRate,
			double 買いWMAs14,
			double 買いWMAs14上昇角度,
			double 買いWMAs14上昇角度シグマ,
			double 買いリミット,
			double 売りRate,
			double 売りWMAs14,
			double 売りWMAs14上昇角度,
			double 売りWMAs14上昇角度シグマ,
			double 売りリミット,
			bool WMA判定_15m,
			bool 保持ポジション,
			string BS判定_前,
			string BS判定_今)
		{
			cmd = new SqlCommand("hstr.spInsertBonusStage", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("日時", SqlDbType.DateTime));
			cmd.Parameters["日時"].Direction = ParameterDirection.Input;
			cmd.Parameters["日時"].Value = 日時;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("買いRate", SqlDbType.Float));
			cmd.Parameters["買いRate"].Direction = ParameterDirection.Input;
			cmd.Parameters["買いRate"].Value = 買いRate;

			cmd.Parameters.Add(new SqlParameter("買いWMAs14", SqlDbType.Float));
			cmd.Parameters["買いWMAs14"].Direction = ParameterDirection.Input;
			cmd.Parameters["買いWMAs14"].Value = 買いWMAs14;

			cmd.Parameters.Add(new SqlParameter("買いWMAs14上昇角度", SqlDbType.Float));
			cmd.Parameters["買いWMAs14上昇角度"].Direction = ParameterDirection.Input;
			cmd.Parameters["買いWMAs14上昇角度"].Value = 買いWMAs14上昇角度;

			cmd.Parameters.Add(new SqlParameter("買いWMAs14上昇角度シグマ", SqlDbType.Float));
			cmd.Parameters["買いWMAs14上昇角度シグマ"].Direction = ParameterDirection.Input;
			cmd.Parameters["買いWMAs14上昇角度シグマ"].Value = 買いWMAs14上昇角度シグマ;

			cmd.Parameters.Add(new SqlParameter("買いリミット", SqlDbType.Float));
			cmd.Parameters["買いリミット"].Direction = ParameterDirection.Input;
			cmd.Parameters["買いリミット"].Value = 買いWMAs14上昇角度シグマ;

			cmd.Parameters.Add(new SqlParameter("売りRate", SqlDbType.Float));
			cmd.Parameters["売りRate"].Direction = ParameterDirection.Input;
			cmd.Parameters["売りRate"].Value = 売りRate;

			cmd.Parameters.Add(new SqlParameter("売りWMAs14", SqlDbType.Float));
			cmd.Parameters["売りWMAs14"].Direction = ParameterDirection.Input;
			cmd.Parameters["売りWMAs14"].Value = 売りWMAs14;

			cmd.Parameters.Add(new SqlParameter("売りWMAs14上昇角度", SqlDbType.Float));
			cmd.Parameters["売りWMAs14上昇角度"].Direction = ParameterDirection.Input;
			cmd.Parameters["売りWMAs14上昇角度"].Value = 売りWMAs14上昇角度;

			cmd.Parameters.Add(new SqlParameter("売りWMAs14上昇角度シグマ", SqlDbType.Float));
			cmd.Parameters["売りWMAs14上昇角度シグマ"].Direction = ParameterDirection.Input;
			cmd.Parameters["売りWMAs14上昇角度シグマ"].Value = 売りWMAs14上昇角度シグマ;

			cmd.Parameters.Add(new SqlParameter("売りリミット", SqlDbType.Float));
			cmd.Parameters["売りリミット"].Direction = ParameterDirection.Input;
			cmd.Parameters["売りリミット"].Value = 売りリミット;

			cmd.Parameters.Add(new SqlParameter("BS_WMA判定_15m", SqlDbType.Bit));
			cmd.Parameters["BS_WMA判定_15m"].Direction = ParameterDirection.Input;
			cmd.Parameters["BS_WMA判定_15m"].Value = WMA判定_15m;

			cmd.Parameters.Add(new SqlParameter("保持ポジション", SqlDbType.Bit));
			cmd.Parameters["保持ポジション"].Direction = ParameterDirection.Input;
			cmd.Parameters["保持ポジション"].Value = 保持ポジション;

			cmd.Parameters.Add(new SqlParameter("BS判定_前", SqlDbType.VarChar));
			cmd.Parameters["BS判定_前"].Direction = ParameterDirection.Input;
			cmd.Parameters["BS判定_前"].Value = BS判定_前;

			cmd.Parameters.Add(new SqlParameter("BS判定_今", SqlDbType.VarChar));
			cmd.Parameters["BS判定_今"].Direction = ParameterDirection.Input;
			cmd.Parameters["BS判定_今"].Value = BS判定_今;

			cmd.ExecuteNonQuery();
		}

	}
}
