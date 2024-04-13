using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DB
{
	public static class oder
	{
		public static void InsertHistory(SqlConnection cn, byte 通貨ペアNo, DateTime 日時, string 売買モード, byte Close済み, double Rate_買い, double Rate_売り, string Close区分,
			string BonusStage, int 注文単位, string OpenOrderID, byte Order区分)
		{
			if (OpenOrderID == "")
				return;

			SqlCommand cmd = new SqlCommand("dbo.SP_InsertOrderHistory", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = dbo.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("日時", SqlDbType.DateTime));
			cmd.Parameters["日時"].Direction = ParameterDirection.Input;
			cmd.Parameters["日時"].Value = 日時;

			cmd.Parameters.Add(new SqlParameter("売買モード", SqlDbType.VarChar));
			cmd.Parameters["売買モード"].Direction = ParameterDirection.Input;
			cmd.Parameters["売買モード"].Value = 売買モード;

			cmd.Parameters.Add(new SqlParameter("Close済み", SqlDbType.TinyInt));
			cmd.Parameters["Close済み"].Direction = ParameterDirection.Input;
			cmd.Parameters["Close済み"].Value = Close済み;

			cmd.Parameters.Add(new SqlParameter("Rate_買い", SqlDbType.Float));
			cmd.Parameters["Rate_買い"].Direction = ParameterDirection.Input;
			cmd.Parameters["Rate_買い"].Value = Rate_買い;

			cmd.Parameters.Add(new SqlParameter("Rate_売り", SqlDbType.Float));
			cmd.Parameters["Rate_売り"].Direction = ParameterDirection.Input;
			cmd.Parameters["Rate_売り"].Value = Rate_売り;

			cmd.Parameters.Add(new SqlParameter("Close区分", SqlDbType.VarChar));
			cmd.Parameters["Close区分"].Direction = ParameterDirection.Input;
			cmd.Parameters["Close区分"].Value = Close区分;

			cmd.Parameters.Add(new SqlParameter("BonusStage", SqlDbType.VarChar));
			cmd.Parameters["BonusStage"].Direction = ParameterDirection.Input;
			cmd.Parameters["BonusStage"].Value = BonusStage;

			cmd.Parameters.Add(new SqlParameter("注文単位", SqlDbType.TinyInt));
			cmd.Parameters["注文単位"].Direction = ParameterDirection.Input;
			cmd.Parameters["注文単位"].Value = 注文単位;

			cmd.Parameters.Add(new SqlParameter("OpenOrderID", SqlDbType.VarChar));
			cmd.Parameters["OpenOrderID"].Direction = ParameterDirection.Input;
			cmd.Parameters["OpenOrderID"].Value = OpenOrderID;

			cmd.Parameters.Add(new SqlParameter("Order区分", SqlDbType.TinyInt));
			cmd.Parameters["Order区分"].Direction = ParameterDirection.Input;
			cmd.Parameters["Order区分"].Value = Order区分;

			cmd.ExecuteNonQuery();
		}

		public static void UpdateOrderHistory_TradeID(SqlConnection cn, string OpenOrderID)
		{
			SqlCommand cmd = new SqlCommand("dbo.SP_UpdateOrderHistory_TradeID", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = dbo.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("OpenOrderID", SqlDbType.VarChar));
			cmd.Parameters["OpenOrderID"].Direction = ParameterDirection.Input;
			cmd.Parameters["OpenOrderID"].Value = OpenOrderID;

			cmd.ExecuteNonQuery();
		}
	}
}
