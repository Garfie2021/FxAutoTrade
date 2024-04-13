using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DB
{
	public static class trad
	{
		public static int RecCnt(SqlConnection cn, string TradeID)
		{
			SqlCommand cmd = new SqlCommand("trad.RecCnt", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = dbo.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("TradeID", SqlDbType.TinyInt));
			cmd.Parameters["TradeID"].Direction = ParameterDirection.Input;
			cmd.Parameters["TradeID"].Value = TradeID;

			cmd.ExecuteNonQuery();

			return 0; // Todo: DBから取得した件数を返す
		}
	
		private static string DB記録_Trades_TradeID;
		private static int DB記録_Trades_iCnt;
		private static int DB記録_Trades_iTradeCnt;
		private static byte DB記録_Trades_IsBuy;
		private static string DB記録_Trades_OpenOrderID;
		public static void InsertTrade(SqlConnection cn, string TradeID, string AccountID, string AccountName, string AccountKind, 
			string OfferID, int Amount, string BuySell, double OpenRate, DateTime OpenTime, string OpenQuoteID, string OpenOrderID, 
			string OpenOrderReqID, string OpenOrderRequestTXT, double Commission, double RolloverInterest, string TradeIDOrigin, 
			double UsedMargin, string ValueDate, string Parties, double Close, double GrossPL, double Limit, double PL, double Stop)
		{
			SqlCommand cmd = new SqlCommand("trad.InsertTrade", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = dbo.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("TradeID", SqlDbType.VarChar));
			cmd.Parameters["TradeID"].Direction = ParameterDirection.Input;
			cmd.Parameters["TradeID"].Value = TradeID;

			// Todo: 全パラメータをストアドに渡す

			cmd.ExecuteNonQuery();

			oder.UpdateOrderHistory_TradeID(cn, DB記録_Trades_OpenOrderID);
		}
	}
}
