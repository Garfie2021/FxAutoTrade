using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DB
{
	public static class oder
	{
		private static SqlCommand cmd;
		private static SqlDataReader Reader;

		public static void OrderSetting初期化(SqlConnection cn)
		{
			cmd = new SqlCommand("oder.spOrderSetting初期化", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = dbo.CommandTimeout;

			cmd.ExecuteNonQuery();
		}


		// 注文判定  0:注文しない　1:注文する
		// 売買判定  1:買い　2:売り
		public static void 注文判定(SqlConnection cn, bool Rate記録以降の処理をスキップ, bool 期間別Rate計算以降の処理をスキップ,
			byte 通貨ペアNo, DateTime StartDate, double 買いRate, double 売りRate,
			out byte 注文判定, out byte 売買判定, out DateTime Close予定Date, out short 注文数, out int 手数料)
		{
			cmd = new SqlCommand("oder.spOrderD_注文", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = dbo.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("Rate記録以降の処理をスキップ", SqlDbType.Bit));
			cmd.Parameters["Rate記録以降の処理をスキップ"].Direction = ParameterDirection.Input;
			cmd.Parameters["Rate記録以降の処理をスキップ"].Value = Rate記録以降の処理をスキップ;

			cmd.Parameters.Add(new SqlParameter("期間別Rate計算以降の処理をスキップ", SqlDbType.Bit));
			cmd.Parameters["期間別Rate計算以降の処理をスキップ"].Direction = ParameterDirection.Input;
			cmd.Parameters["期間別Rate計算以降の処理をスキップ"].Value = 期間別Rate計算以降の処理をスキップ;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
			cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
			cmd.Parameters["StartDate"].Value = StartDate;

			cmd.Parameters.Add(new SqlParameter("買いRate", SqlDbType.Float));
			cmd.Parameters["買いRate"].Direction = ParameterDirection.Input;
			cmd.Parameters["買いRate"].Value = 買いRate;

			cmd.Parameters.Add(new SqlParameter("売りRate", SqlDbType.Float));
			cmd.Parameters["売りRate"].Direction = ParameterDirection.Input;
			cmd.Parameters["売りRate"].Value = 売りRate;

			cmd.Parameters.Add(new SqlParameter("注文判定", SqlDbType.TinyInt));
			cmd.Parameters["注文判定"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売買判定", SqlDbType.TinyInt));
			cmd.Parameters["売買判定"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("Close予定Date", SqlDbType.DateTime));
			cmd.Parameters["Close予定Date"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("注文数", SqlDbType.SmallInt));
			cmd.Parameters["注文数"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("手数料", SqlDbType.Int));
			cmd.Parameters["手数料"].Direction = ParameterDirection.Output;

			cmd.ExecuteNonQuery();

			注文判定 = (byte)cmd.Parameters["注文判定"].Value;
			売買判定 = (byte)cmd.Parameters["売買判定"].Value;
			Close予定Date = (DateTime)cmd.Parameters["Close予定Date"].Value;
			注文数 = (short)cmd.Parameters["注文数"].Value;
			手数料 = (int)cmd.Parameters["手数料"].Value;
		}

		public static void InsertOrderHistory(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate, byte 売買判定,
			double 買いRate, double 売りRate, int 注文数, DateTime Close予定Date, object OpenOrderID)
		{
			cmd = new SqlCommand("oder.spInsertOrderHistory", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = dbo.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("OrderDate", SqlDbType.DateTime));
			cmd.Parameters["OrderDate"].Direction = ParameterDirection.Input;
			cmd.Parameters["OrderDate"].Value = StartDate;

			cmd.Parameters.Add(new SqlParameter("売買判定", SqlDbType.VarChar));
			cmd.Parameters["売買判定"].Direction = ParameterDirection.Input;
			cmd.Parameters["売買判定"].Value = 売買判定;

			cmd.Parameters.Add(new SqlParameter("買いRate", SqlDbType.Float));
			cmd.Parameters["買いRate"].Direction = ParameterDirection.Input;
			cmd.Parameters["買いRate"].Value = 買いRate;

			cmd.Parameters.Add(new SqlParameter("売りRate", SqlDbType.Float));
			cmd.Parameters["売りRate"].Direction = ParameterDirection.Input;
			cmd.Parameters["売りRate"].Value = 売りRate;

			cmd.Parameters.Add(new SqlParameter("注文数", SqlDbType.TinyInt));
			cmd.Parameters["注文数"].Direction = ParameterDirection.Input;
			cmd.Parameters["注文数"].Value = 注文数;

			cmd.Parameters.Add(new SqlParameter("Close予定Date", SqlDbType.DateTime));
			cmd.Parameters["Close予定Date"].Direction = ParameterDirection.Input;
			cmd.Parameters["Close予定Date"].Value = Close予定Date;

			cmd.Parameters.Add(new SqlParameter("OpenOrderID", SqlDbType.VarChar));
			cmd.Parameters["OpenOrderID"].Direction = ParameterDirection.Input;
			cmd.Parameters["OpenOrderID"].Value = (string)OpenOrderID;

			cmd.ExecuteNonQuery();
		}

		public static void クローズ対象ポジション取得(SqlConnection cn, DateTime Now, ref List<string> OrderList)
		{
			cmd = new SqlCommand("oder.spOrderD_ポジションクローズ", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = dbo.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("Now", SqlDbType.DateTime));
			cmd.Parameters["Now"].Direction = ParameterDirection.Input;
			cmd.Parameters["Now"].Value = Now;

			Reader = cmd.ExecuteReader();

			while (Reader.Read())
			{
				OrderList.Add((string)Reader["TradeID"]);
			}

			Reader.Close();
		}

		public static void UpdateOrderHistory_CloseOrderID(SqlConnection cn, string TradeID, string CloseOrderID)
		{
			cmd = new SqlCommand("oder.spUpdateOrderHistory_CloseOrderID", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = dbo.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("TradeID", SqlDbType.VarChar));
			cmd.Parameters["TradeID"].Direction = ParameterDirection.Input;
			cmd.Parameters["TradeID"].Value = TradeID;

			cmd.Parameters.Add(new SqlParameter("CloseOrderID", SqlDbType.VarChar));
			cmd.Parameters["CloseOrderID"].Direction = ParameterDirection.Input;
			cmd.Parameters["CloseOrderID"].Value = CloseOrderID;
			
			//cmd.Parameters.Add(new SqlParameter("CloseOrderID", SqlDbType.VarChar));
			//cmd.Parameters["CloseOrderID"].Direction = ParameterDirection.Input;
			//cmd.Parameters["CloseOrderID"].Value = CloseOrderID;

			cmd.ExecuteNonQuery();
		}

		public static void UpdateOrderHistory_TradeID(SqlConnection cn, string OpenOrderID)
		{
			cmd = new SqlCommand("oder.spUpdateOrderHistory_TradeID", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = dbo.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("OpenOrderID", SqlDbType.VarChar));
			cmd.Parameters["OpenOrderID"].Direction = ParameterDirection.Input;
			cmd.Parameters["OpenOrderID"].Value = OpenOrderID;

			cmd.ExecuteNonQuery();
		}



		//public static int ScalarCnt(SqlConnection cn, string TradeID)
		//{
		//	SqlCommand cmd = new SqlCommand("trad.SP_ScalarCnt", cn);
		//	cmd.CommandType = CommandType.StoredProcedure;
		//	cmd.CommandTimeout = dbo.CommandTimeout;

		//	cmd.Parameters.Add(new SqlParameter("TradeID", SqlDbType.VarChar));
		//	cmd.Parameters["TradeID"].Direction = ParameterDirection.Input;
		//	cmd.Parameters["TradeID"].Value = TradeID;

		//	cmd.ExecuteNonQuery();

		//	return 1;
		//}

		//public static int RecCnt(SqlConnection cn, string TradeID)
		//{
		//	SqlCommand cmd = new SqlCommand("trad.RecCnt", cn);
		//	cmd.CommandType = CommandType.StoredProcedure;
		//	cmd.CommandTimeout = dbo.CommandTimeout;

		//	cmd.Parameters.Add(new SqlParameter("TradeID", SqlDbType.TinyInt));
		//	cmd.Parameters["TradeID"].Direction = ParameterDirection.Input;
		//	cmd.Parameters["TradeID"].Value = TradeID;

		//	cmd.ExecuteNonQuery();

		//	return 0; // Todo: DBから取得した件数を返す
		//}






		//private static string InsertTrade_TradeID;
		//private static int InsertTrade_iCnt;
		//private static int InsertTrade_iTradeCnt;
		//private static byte InsertTrade_IsBuy;
		//private static string InsertTrade_OpenOrderID;
		//public static void InsertTrade(SqlConnection cn, string TradeID, string AccountID, string AccountName, string AccountKind, 
		//	string OfferID, int Amount, string BuySell, double OpenRate, DateTime OpenTime, string OpenQuoteID, string OpenOrderID, 
		//	string OpenOrderReqID, string OpenOrderRequestTXT, double Commission, double RolloverInterest, string TradeIDOrigin, 
		//	double UsedMargin, string ValueDate, string Parties, double Close, double GrossPL, double Limit, double PL, double Stop)
		//{
		//	SqlCommand cmd = new SqlCommand("trad.InsertTrade", cn);
		//	cmd.CommandType = CommandType.StoredProcedure;
		//	cmd.CommandTimeout = dbo.CommandTimeout;

		//	cmd.Parameters.Add(new SqlParameter("TradeID", SqlDbType.VarChar));
		//	cmd.Parameters["TradeID"].Direction = ParameterDirection.Input;
		//	cmd.Parameters["TradeID"].Value = TradeID;

		//	// Todo: 全パラメータをストアドに渡す

		//	cmd.ExecuteNonQuery();

		//	oder.UpdateOrderHistory_TradeID(cn, InsertTrade_OpenOrderID);
		//}

	}
}
