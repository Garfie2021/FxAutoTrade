using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using 定数;

namespace DB
{
	public static class pfmc
	{
		private static SqlCommand cmd;

		public static void InsertポジションHourly(SqlConnection cn,
			double 保有可能ポジション数, double 決算待ちポジション数,
			double 当日注文数, double 当日約定数, double 当日約定金額,
			double 取引証拠金, double 有効証拠金, double 維持証拠金, double ロスカット余剰金, double 余剰金の割合)
		{
			cmd = new SqlCommand("pfmc.spInsertポジションHourly", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("保有可能ポジション数", SqlDbType.Float));
			cmd.Parameters["保有可能ポジション数"].Direction = ParameterDirection.Input;
			cmd.Parameters["保有可能ポジション数"].Value = 保有可能ポジション数;

			cmd.Parameters.Add(new SqlParameter("決算待ちポジション数", SqlDbType.Float));
			cmd.Parameters["決算待ちポジション数"].Direction = ParameterDirection.Input;
			cmd.Parameters["決算待ちポジション数"].Value = 決算待ちポジション数;

			cmd.Parameters.Add(new SqlParameter("当日注文数", SqlDbType.Float));
			cmd.Parameters["当日注文数"].Direction = ParameterDirection.Input;
			cmd.Parameters["当日注文数"].Value = 当日注文数;

			cmd.Parameters.Add(new SqlParameter("当日約定数", SqlDbType.Float));
			cmd.Parameters["当日約定数"].Direction = ParameterDirection.Input;
			cmd.Parameters["当日約定数"].Value = 当日約定数;

			cmd.Parameters.Add(new SqlParameter("当日約定金額", SqlDbType.Float));
			cmd.Parameters["当日約定金額"].Direction = ParameterDirection.Input;
			cmd.Parameters["当日約定金額"].Value = 当日約定金額;

			cmd.Parameters.Add(new SqlParameter("取引証拠金", SqlDbType.Float));
			cmd.Parameters["取引証拠金"].Direction = ParameterDirection.Input;
			cmd.Parameters["取引証拠金"].Value = 取引証拠金;

			cmd.Parameters.Add(new SqlParameter("有効証拠金", SqlDbType.Float));
			cmd.Parameters["有効証拠金"].Direction = ParameterDirection.Input;
			cmd.Parameters["有効証拠金"].Value = 有効証拠金;

			cmd.Parameters.Add(new SqlParameter("維持証拠金", SqlDbType.Float));
			cmd.Parameters["維持証拠金"].Direction = ParameterDirection.Input;
			cmd.Parameters["維持証拠金"].Value = 維持証拠金;

			cmd.Parameters.Add(new SqlParameter("ロスカット余剰金", SqlDbType.Float));
			cmd.Parameters["ロスカット余剰金"].Direction = ParameterDirection.Input;
			cmd.Parameters["ロスカット余剰金"].Value = ロスカット余剰金;

			cmd.Parameters.Add(new SqlParameter("余剰金の割合", SqlDbType.Float));
			cmd.Parameters["余剰金の割合"].Direction = ParameterDirection.Input;
			cmd.Parameters["余剰金の割合"].Value = 余剰金の割合;

			cmd.ExecuteNonQuery();
		}

		public static byte Chk出金済み(SqlConnection cn, DateTime now, double 現在の取引証拠金, int 先月利益)
		{
			cmd = new SqlCommand("pfmc.spChk出金済み", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("now", SqlDbType.DateTime));
			cmd.Parameters["now"].Direction = ParameterDirection.Input;
			cmd.Parameters["now"].Value = now;

			cmd.Parameters.Add(new SqlParameter("現在の取引証拠金", SqlDbType.Float));
			cmd.Parameters["現在の取引証拠金"].Direction = ParameterDirection.Input;
			cmd.Parameters["現在の取引証拠金"].Value = 現在の取引証拠金;

			cmd.Parameters.Add(new SqlParameter("先月利益", SqlDbType.Int));
			cmd.Parameters["先月利益"].Direction = ParameterDirection.Input;
			cmd.Parameters["先月利益"].Value = 先月利益;

			cmd.Parameters.Add(new SqlParameter("出金済フラグ", SqlDbType.TinyInt));
			cmd.Parameters["出金済フラグ"].Direction = ParameterDirection.Output;

			cmd.ExecuteNonQuery();

			return (byte)cmd.Parameters["出金済フラグ"].Value;
		}

		public static void Insert利益_Monthly(SqlConnection cn, DateTime now, DateTime 利益確定開始日時, byte 出金可能Percent)
		{
			cmd = new SqlCommand("pfmc.spInsert利益Monthly", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("年月", SqlDbType.Date));
			cmd.Parameters["年月"].Direction = ParameterDirection.Input;
			cmd.Parameters["年月"].Value = DateTime.Parse(now.Year.ToString() + "/" + now.Month.ToString() + "/1");

			cmd.Parameters.Add(new SqlParameter("利益確定開始日時", SqlDbType.DateTime));
			cmd.Parameters["利益確定開始日時"].Direction = ParameterDirection.Input;
			cmd.Parameters["利益確定開始日時"].Value = 利益確定開始日時;

			cmd.Parameters.Add(new SqlParameter("出金可能Percent", SqlDbType.TinyInt));
			cmd.Parameters["出金可能Percent"].Direction = ParameterDirection.Input;
			cmd.Parameters["出金可能Percent"].Value = 出金可能Percent;

			cmd.ExecuteNonQuery();
		}

		public static void Get利益Monthly(SqlConnection cn, DateTime 年月, out int 利益確定開始以降の利益, out int 出金可能額)
		{
			cmd = new SqlCommand("pfmc.spGet利益Monthly", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("年月", SqlDbType.Date));
			cmd.Parameters["年月"].Direction = ParameterDirection.Input;
			cmd.Parameters["年月"].Value = DateTime.Parse(年月.Year.ToString() + "/" + 年月.Month.ToString() + "/1");

			cmd.Parameters.Add(new SqlParameter("利益確定開始以降の利益", SqlDbType.Int));
			cmd.Parameters["利益確定開始以降の利益"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("出金可能額", SqlDbType.Int));
			cmd.Parameters["出金可能額"].Direction = ParameterDirection.Output;

			cmd.ExecuteNonQuery();

			利益確定開始以降の利益 = (int)cmd.Parameters["利益確定開始以降の利益"].Value;
			出金可能額 = (int)cmd.Parameters["出金可能額"].Value;
		}

	}
}
