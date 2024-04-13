using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace HealthCheck
{
	public static class CDB_hltc
	{
		public static void Getレコードの状況(int back_Day, out string 状況)
		{
			using (SqlConnection cn = new SqlConnection())
			{
				cn.ConnectionString = Properties.Settings.Default.FXConnectionString;
				cn.Open();

				SqlCommand cmd = new SqlCommand("hltc.SP_Getレコードの状況", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = CDB_dbo.CommandTimeout;

				cmd.Parameters.Add(new SqlParameter("back_Day", SqlDbType.Int));
				cmd.Parameters["back_Day"].Direction = ParameterDirection.Input;
				cmd.Parameters["back_Day"].Value = back_Day;

				cmd.Parameters.Add(new SqlParameter("状況", SqlDbType.VarChar, 5000));
				cmd.Parameters["状況"].Direction = ParameterDirection.Output;

				cmd.ExecuteReader();

				状況 = (string)cmd.Parameters["状況"].Value;
			}
		}

	}
}
