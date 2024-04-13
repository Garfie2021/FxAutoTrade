using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DB
{
	public static class cmn
	{
		public static void UpdateSettings(byte No, string 備考1, string 備考2, double 値)
		{
			using (SqlConnection cn = new SqlConnection())
			{
				cn.ConnectionString = dbo.ConnectionString();
				cn.Open();

				SqlCommand cmd = new SqlCommand("dbo.SP_UpdateSettings", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = dbo.CommandTimeout;

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
}
