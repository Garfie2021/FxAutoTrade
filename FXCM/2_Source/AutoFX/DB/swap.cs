using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using 定数;

namespace DB
{
	public static class swap
	{
		private static SqlCommand cmd;

		public static void Get売買Swapがどちらも0になる前のSwap(SqlConnection cn, byte 通貨ペアNo,
			out double Swap_買い, out double Swap_売り)
		{
			cmd = new SqlCommand("swap.spGet売買Swapがどちらも0になる前のSwap", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("Swap_買い", SqlDbType.Float));
			cmd.Parameters["Swap_買い"].Direction = ParameterDirection.Output;
			cmd.Parameters.Add(new SqlParameter("Swap_売り", SqlDbType.Float));
			cmd.Parameters["Swap_売り"].Direction = ParameterDirection.Output;

			cmd.ExecuteNonQuery();

			Swap_買い = (double)cmd.Parameters["Swap_買い"].Value;
			Swap_売り = (double)cmd.Parameters["Swap_売り"].Value;
		}
	}
}
