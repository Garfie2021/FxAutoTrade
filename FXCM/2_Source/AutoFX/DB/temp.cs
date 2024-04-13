using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using 定数;

namespace DB
{
	public static class temp
	{
		private static SqlCommand cmd;

		public static void FillBy差益_SortCloseTradeTmp(SqlConnection cn,
			string sTradeID, int iAmount, double dRate, string sQuoteID)
		{
			cmd = new SqlCommand("temp.spFillBy差益_SortCloseTradeTmp", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			SqlDataReader dr = cmd.ExecuteReader();
			dr.Read();

			sTradeID = (string)dr[0];
			iAmount = (int)dr[1];
			dRate = (double)dr[2];
			sQuoteID = (string)dr[3];

			dr.Close(); 
		}

		public static void DeleteAll_SortCloseTradeTmp(SqlConnection cn)
		{
			cmd = new SqlCommand("temp.spDeleteAll_SortCloseTradeTmp", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.ExecuteNonQuery();
		}

		public static void InsertSortCloseTradeTmp(SqlConnection cn,
			DateTime Time, string sTradeID, double 差益, int iAmount, double dRate, string sQuoteID)
		{
			cmd = new SqlCommand("temp.spInsertSortCloseTradeTmp", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("Time", SqlDbType.DateTime));
			cmd.Parameters["Time"].Direction = ParameterDirection.Input;
			cmd.Parameters["Time"].Value = Time;

			cmd.Parameters.Add(new SqlParameter("sTradeID", SqlDbType.VarChar));
			cmd.Parameters["sTradeID"].Direction = ParameterDirection.Input;
			cmd.Parameters["sTradeID"].Value = sTradeID;

			cmd.Parameters.Add(new SqlParameter("差益", SqlDbType.Float));
			cmd.Parameters["差益"].Direction = ParameterDirection.Input;
			cmd.Parameters["差益"].Value = 差益;

			cmd.Parameters.Add(new SqlParameter("iAmount", SqlDbType.Int));
			cmd.Parameters["iAmount"].Direction = ParameterDirection.Input;
			cmd.Parameters["iAmount"].Value = iAmount;

			cmd.Parameters.Add(new SqlParameter("dRate", SqlDbType.Float));
			cmd.Parameters["dRate"].Direction = ParameterDirection.Input;
			cmd.Parameters["dRate"].Value = dRate;

			cmd.Parameters.Add(new SqlParameter("sQuoteID", SqlDbType.VarChar));
			cmd.Parameters["sQuoteID"].Direction = ParameterDirection.Input;
			cmd.Parameters["sQuoteID"].Value = sQuoteID;

			cmd.ExecuteNonQuery();
		}

		public static void InsertSortTmp(SqlConnection cn, string 通貨ペア, double 値)
		{
			cmd = new SqlCommand("temp.spInsertSortTmp", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペア", SqlDbType.VarChar));
			cmd.Parameters["通貨ペア"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペア"].Value = 通貨ペア;

			cmd.Parameters.Add(new SqlParameter("値", SqlDbType.Float));
			cmd.Parameters["値"].Direction = ParameterDirection.Input;
			cmd.Parameters["値"].Value = 値;

			cmd.ExecuteNonQuery();
		}
	}
}
