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
		// 注文判定  0:注文しない　1:注文する
		// 売買判定  1:買い　2:売り
		public static void 注文判定OrderD(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate, double 買いRate, double 売りRate,
			out byte 注文判定, out string 売買判定, out int WMAs2角度持続時間_過去, out float WMAs2角度持続Rate_過去, out short 注文数, out int 手数料)
		{
			SqlCommand cmd = new SqlCommand("oder.spOrderD", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = dbo.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
			cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
			cmd.Parameters["StartDate"].Value = StartDate;

			cmd.Parameters.Add(new SqlParameter("買いRate", SqlDbType.DateTime));
			cmd.Parameters["買いRate"].Direction = ParameterDirection.Input;
			cmd.Parameters["買いRate"].Value = 買いRate;

			cmd.Parameters.Add(new SqlParameter("売りRate", SqlDbType.DateTime));
			cmd.Parameters["売りRate"].Direction = ParameterDirection.Input;
			cmd.Parameters["売りRate"].Value = 売りRate;

			cmd.Parameters.Add(new SqlParameter("注文判定", SqlDbType.TinyInt));
			cmd.Parameters["注文判定"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売買判定", SqlDbType.TinyInt));
			cmd.Parameters["売買判定"].Direction = ParameterDirection.Output;

			cmd.ExecuteReader();

			注文判定 = (byte)cmd.Parameters["注文判定"].Value;
			売買判定 = (string)cmd.Parameters["売買判定"].Value;
			WMAs2角度持続時間_過去 = (int)cmd.Parameters["WMAs2角度持続時間_過去"].Value;
			WMAs2角度持続Rate_過去 = (float)cmd.Parameters["WMAs2角度持続Rate_過去"].Value;
			注文数 = (short)cmd.Parameters["注文数"].Value;
			手数料 = (int)cmd.Parameters["手数料"].Value;
		}

		public static void InsertOrderHistory(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate, byte 売買判定,
			double 買いRate, double 売りRate, byte Close済み, string Close区分, int 注文単位, string OpenOrderID, byte Order区分)
		{
			SqlCommand cmd = new SqlCommand("oder.spInsertOrderHistory", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = dbo.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
			cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
			cmd.Parameters["StartDate"].Value = StartDate;

			cmd.Parameters.Add(new SqlParameter("売買判定", SqlDbType.VarChar));
			cmd.Parameters["売買判定"].Direction = ParameterDirection.Input;
			cmd.Parameters["売買判定"].Value = 売買判定;

			cmd.Parameters.Add(new SqlParameter("買いRate", SqlDbType.Float));
			cmd.Parameters["買いRate"].Direction = ParameterDirection.Input;
			cmd.Parameters["買いRate"].Value = 買いRate;

			cmd.Parameters.Add(new SqlParameter("売りRate", SqlDbType.Float));
			cmd.Parameters["売りRate"].Direction = ParameterDirection.Input;
			cmd.Parameters["売りRate"].Value = 売りRate;

			cmd.Parameters.Add(new SqlParameter("Close済み", SqlDbType.TinyInt));
			cmd.Parameters["Close済み"].Direction = ParameterDirection.Input;
			cmd.Parameters["Close済み"].Value = Close済み;

			cmd.Parameters.Add(new SqlParameter("Close区分", SqlDbType.VarChar));
			cmd.Parameters["Close区分"].Direction = ParameterDirection.Input;
			cmd.Parameters["Close区分"].Value = Close区分;

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

		public static void UpdateOrderHistory_CloseOrderID(SqlConnection cn, string TradeID, string CloseOrderID)
		{
			SqlCommand cmd = new SqlCommand("dbo.SP_UpdateOrderHistory_CloseOrderID", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = dbo.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("TradeID", SqlDbType.VarChar));
			cmd.Parameters["TradeID"].Direction = ParameterDirection.Input;
			cmd.Parameters["TradeID"].Value = TradeID;

			cmd.Parameters.Add(new SqlParameter("CloseOrderID", SqlDbType.VarChar));
			cmd.Parameters["CloseOrderID"].Direction = ParameterDirection.Input;
			cmd.Parameters["CloseOrderID"].Value = CloseOrderID;

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


		public static void InsertClosedTrades(SqlConnection cn,
			string TradeID,
			string AccountID,
			string AccountName,
			string OfferID,
			string Instrument,
			int Lot,
			double AmountK,
			string BS,
			double Open,
			double Close,
			double PL,
			double GrossPL,
			double Com,
			double Int,
			DateTime OpenTime,
			DateTime CloseTime,
			string Kind,
			string OpenOrderID,
			string OpenOrderReqID,
			string CloseOrderID,
			string CloseOrderReqID,
			string OQTXT,
			string CQTXT,
			string TradeIDOrigin,
			string TradeIDRemain
		)
		{
			SqlCommand cmd = new SqlCommand("dbo.SP_InsertClosedTrades", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = dbo.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("TradeID", SqlDbType.VarChar));
			cmd.Parameters["TradeID"].Direction = ParameterDirection.Input;
			cmd.Parameters["TradeID"].Value = TradeID;

			cmd.Parameters.Add(new SqlParameter("AccountID", SqlDbType.VarChar));
			cmd.Parameters["AccountID"].Direction = ParameterDirection.Input;
			cmd.Parameters["AccountID"].Value = AccountID;

			cmd.Parameters.Add(new SqlParameter("AccountName", SqlDbType.VarChar));
			cmd.Parameters["AccountName"].Direction = ParameterDirection.Input;
			cmd.Parameters["AccountName"].Value = AccountName;

			cmd.Parameters.Add(new SqlParameter("OfferID", SqlDbType.VarChar));
			cmd.Parameters["OfferID"].Direction = ParameterDirection.Input;
			cmd.Parameters["OfferID"].Value = OfferID;

			cmd.Parameters.Add(new SqlParameter("Instrument", SqlDbType.VarChar));
			cmd.Parameters["Instrument"].Direction = ParameterDirection.Input;
			cmd.Parameters["Instrument"].Value = Instrument;

			cmd.Parameters.Add(new SqlParameter("Lot", SqlDbType.Int));
			cmd.Parameters["Lot"].Direction = ParameterDirection.Input;
			cmd.Parameters["Lot"].Value = Lot;

			cmd.Parameters.Add(new SqlParameter("AmountK", SqlDbType.Float));
			cmd.Parameters["AmountK"].Direction = ParameterDirection.Input;
			cmd.Parameters["AmountK"].Value = AmountK;

			cmd.Parameters.Add(new SqlParameter("BS", SqlDbType.VarChar));
			cmd.Parameters["BS"].Direction = ParameterDirection.Input;
			cmd.Parameters["BS"].Value = BS;

			cmd.Parameters.Add(new SqlParameter("Open", SqlDbType.Float));
			cmd.Parameters["Open"].Direction = ParameterDirection.Input;
			cmd.Parameters["Open"].Value = Open;

			cmd.Parameters.Add(new SqlParameter("Close", SqlDbType.Float));
			cmd.Parameters["Close"].Direction = ParameterDirection.Input;
			cmd.Parameters["Close"].Value = Close;

			cmd.Parameters.Add(new SqlParameter("PL", SqlDbType.Float));
			cmd.Parameters["PL"].Direction = ParameterDirection.Input;
			cmd.Parameters["PL"].Value = PL;

			cmd.Parameters.Add(new SqlParameter("GrossPL", SqlDbType.Float));
			cmd.Parameters["GrossPL"].Direction = ParameterDirection.Input;
			cmd.Parameters["GrossPL"].Value = GrossPL;

			cmd.Parameters.Add(new SqlParameter("Com", SqlDbType.Float));
			cmd.Parameters["Com"].Direction = ParameterDirection.Input;
			cmd.Parameters["Com"].Value = Com;

			cmd.Parameters.Add(new SqlParameter("Int", SqlDbType.Float));
			cmd.Parameters["Int"].Direction = ParameterDirection.Input;
			cmd.Parameters["Int"].Value = Int;

			cmd.Parameters.Add(new SqlParameter("OpenTime", SqlDbType.DateTime));
			cmd.Parameters["OpenTime"].Direction = ParameterDirection.Input;
			cmd.Parameters["OpenTime"].Value = OpenTime;

			cmd.Parameters.Add(new SqlParameter("CloseTime", SqlDbType.DateTime));
			cmd.Parameters["CloseTime"].Direction = ParameterDirection.Input;
			cmd.Parameters["CloseTime"].Value = CloseTime;

			cmd.Parameters.Add(new SqlParameter("Kind", SqlDbType.VarChar));
			cmd.Parameters["Kind"].Direction = ParameterDirection.Input;
			cmd.Parameters["Kind"].Value = Kind;

			cmd.Parameters.Add(new SqlParameter("OpenOrderID", SqlDbType.VarChar));
			cmd.Parameters["OpenOrderID"].Direction = ParameterDirection.Input;
			cmd.Parameters["OpenOrderID"].Value = OpenOrderID;

			cmd.Parameters.Add(new SqlParameter("OpenOrderReqID", SqlDbType.VarChar));
			cmd.Parameters["OpenOrderReqID"].Direction = ParameterDirection.Input;
			cmd.Parameters["OpenOrderReqID"].Value = OpenOrderReqID;

			cmd.Parameters.Add(new SqlParameter("CloseOrderID", SqlDbType.VarChar));
			cmd.Parameters["CloseOrderID"].Direction = ParameterDirection.Input;
			cmd.Parameters["CloseOrderID"].Value = CloseOrderID;

			cmd.Parameters.Add(new SqlParameter("CloseOrderReqID", SqlDbType.VarChar));
			cmd.Parameters["CloseOrderReqID"].Direction = ParameterDirection.Input;
			cmd.Parameters["CloseOrderReqID"].Value = CloseOrderReqID;

			cmd.Parameters.Add(new SqlParameter("OQTXT", SqlDbType.VarChar));
			cmd.Parameters["OQTXT"].Direction = ParameterDirection.Input;
			cmd.Parameters["OQTXT"].Value = OQTXT;

			cmd.Parameters.Add(new SqlParameter("CQTXT", SqlDbType.VarChar));
			cmd.Parameters["CQTXT"].Direction = ParameterDirection.Input;
			cmd.Parameters["CQTXT"].Value = CQTXT;

			cmd.Parameters.Add(new SqlParameter("TradeIDOrigin", SqlDbType.VarChar));
			cmd.Parameters["TradeIDOrigin"].Direction = ParameterDirection.Input;
			cmd.Parameters["TradeIDOrigin"].Value = TradeIDOrigin;

			cmd.Parameters.Add(new SqlParameter("TradeIDRemain", SqlDbType.VarChar));
			cmd.Parameters["TradeIDRemain"].Direction = ParameterDirection.Input;
			cmd.Parameters["TradeIDRemain"].Value = TradeIDRemain;

			cmd.ExecuteNonQuery();
		}

		public static int SelectCnt_TradeID(SqlConnection cn, string TradeID)
		{
			SqlCommand cmd = new SqlCommand("dbo.SP_SelectCnt_TradeID", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = dbo.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("TradeID", SqlDbType.VarChar));
			cmd.Parameters["TradeID"].Direction = ParameterDirection.Input;
			cmd.Parameters["TradeID"].Value = TradeID;

			cmd.Parameters.Add(new SqlParameter("Cnt", SqlDbType.Int));
			cmd.Parameters["Cnt"].Direction = ParameterDirection.Output;

			cmd.ExecuteReader();

			return (int)cmd.Parameters["Cnt"].Value;
		}

		public static int ScalarCnt(SqlConnection cn, string TradeID)
		{
			SqlCommand cmd = new SqlCommand("trad.SP_ScalarCnt", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = dbo.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("TradeID", SqlDbType.VarChar));
			cmd.Parameters["TradeID"].Direction = ParameterDirection.Input;
			cmd.Parameters["TradeID"].Value = TradeID;

			cmd.ExecuteNonQuery();

			return 1;
		}

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

		public static void InsertTrade(SqlConnection cn,
			 string TradeID
			, string AccountID
			, string AccountName
			, string OfferID
			, string Instrument
			, int Lot
			, double AmountK
			, string BS
			, double Open
			, double Close
			, double Stop
			, double UntTrlMove
			, double Limit
			, double UntTrlMoveLimit
			, double PL
			, double GrossPL
			, double Com
			, double Int
			, DateTime Time
			, byte IsBuy
			, string Kind
			, string QuoteID
			, string OpenOrderID
			, string OpenOrderReqID
			, string QTXT
			, string StopOrderID
			, string LimitOrderID
			, string TradeIDOrigin
		)
		{
			SqlCommand cmd = new SqlCommand("dbo.SP_InsertTrades", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = dbo.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("TradeID", SqlDbType.VarChar));
			cmd.Parameters["TradeID"].Direction = ParameterDirection.Input;
			cmd.Parameters["TradeID"].Value = TradeID;

			cmd.Parameters.Add(new SqlParameter("AccountID", SqlDbType.VarChar));
			cmd.Parameters["AccountID"].Direction = ParameterDirection.Input;
			cmd.Parameters["AccountID"].Value = AccountID;

			cmd.Parameters.Add(new SqlParameter("AccountName", SqlDbType.VarChar));
			cmd.Parameters["AccountName"].Direction = ParameterDirection.Input;
			cmd.Parameters["AccountName"].Value = AccountName;

			cmd.Parameters.Add(new SqlParameter("OfferID", SqlDbType.VarChar));
			cmd.Parameters["OfferID"].Direction = ParameterDirection.Input;
			cmd.Parameters["OfferID"].Value = OfferID;

			cmd.Parameters.Add(new SqlParameter("Instrument", SqlDbType.VarChar));
			cmd.Parameters["Instrument"].Direction = ParameterDirection.Input;
			cmd.Parameters["Instrument"].Value = Instrument;

			cmd.Parameters.Add(new SqlParameter("Lot", SqlDbType.Int));
			cmd.Parameters["Lot"].Direction = ParameterDirection.Input;
			cmd.Parameters["Lot"].Value = Lot;

			cmd.Parameters.Add(new SqlParameter("AmountK", SqlDbType.Float));
			cmd.Parameters["AmountK"].Direction = ParameterDirection.Input;
			cmd.Parameters["AmountK"].Value = AmountK;

			cmd.Parameters.Add(new SqlParameter("BS", SqlDbType.VarChar));
			cmd.Parameters["BS"].Direction = ParameterDirection.Input;
			cmd.Parameters["BS"].Value = BS;

			cmd.Parameters.Add(new SqlParameter("Open", SqlDbType.Float));
			cmd.Parameters["Open"].Direction = ParameterDirection.Input;
			cmd.Parameters["Open"].Value = Open;

			cmd.Parameters.Add(new SqlParameter("Close", SqlDbType.Float));
			cmd.Parameters["Close"].Direction = ParameterDirection.Input;
			cmd.Parameters["Close"].Value = Close;

			cmd.Parameters.Add(new SqlParameter("Stop", SqlDbType.Float));
			cmd.Parameters["Stop"].Direction = ParameterDirection.Input;
			cmd.Parameters["Stop"].Value = Stop;

			cmd.Parameters.Add(new SqlParameter("UntTrlMove", SqlDbType.Float));
			cmd.Parameters["UntTrlMove"].Direction = ParameterDirection.Input;
			cmd.Parameters["UntTrlMove"].Value = UntTrlMove;

			cmd.Parameters.Add(new SqlParameter("Limit", SqlDbType.Float));
			cmd.Parameters["Limit"].Direction = ParameterDirection.Input;
			cmd.Parameters["Limit"].Value = Limit;

			cmd.Parameters.Add(new SqlParameter("UntTrlMoveLimit", SqlDbType.Float));
			cmd.Parameters["UntTrlMoveLimit"].Direction = ParameterDirection.Input;
			cmd.Parameters["UntTrlMoveLimit"].Value = UntTrlMoveLimit;

			cmd.Parameters.Add(new SqlParameter("PL", SqlDbType.Float));
			cmd.Parameters["PL"].Direction = ParameterDirection.Input;
			cmd.Parameters["PL"].Value = PL;

			cmd.Parameters.Add(new SqlParameter("GrossPL", SqlDbType.Float));
			cmd.Parameters["GrossPL"].Direction = ParameterDirection.Input;
			cmd.Parameters["GrossPL"].Value = GrossPL;

			cmd.Parameters.Add(new SqlParameter("Com", SqlDbType.Float));
			cmd.Parameters["Com"].Direction = ParameterDirection.Input;
			cmd.Parameters["Com"].Value = Com;

			cmd.Parameters.Add(new SqlParameter("Int", SqlDbType.Float));
			cmd.Parameters["Int"].Direction = ParameterDirection.Input;
			cmd.Parameters["Int"].Value = Int;

			cmd.Parameters.Add(new SqlParameter("Time", SqlDbType.DateTime));
			cmd.Parameters["Time"].Direction = ParameterDirection.Input;
			cmd.Parameters["Time"].Value = Time;

			cmd.Parameters.Add(new SqlParameter("IsBuy", SqlDbType.TinyInt));
			cmd.Parameters["IsBuy"].Direction = ParameterDirection.Input;
			cmd.Parameters["IsBuy"].Value = IsBuy;

			cmd.Parameters.Add(new SqlParameter("Kind", SqlDbType.VarChar));
			cmd.Parameters["Kind"].Direction = ParameterDirection.Input;
			cmd.Parameters["Kind"].Value = Kind;

			cmd.Parameters.Add(new SqlParameter("QuoteID", SqlDbType.VarChar));
			cmd.Parameters["QuoteID"].Direction = ParameterDirection.Input;
			cmd.Parameters["QuoteID"].Value = QuoteID;

			cmd.Parameters.Add(new SqlParameter("OpenOrderID", SqlDbType.VarChar));
			cmd.Parameters["OpenOrderID"].Direction = ParameterDirection.Input;
			cmd.Parameters["OpenOrderID"].Value = OpenOrderID;

			cmd.Parameters.Add(new SqlParameter("OpenOrderReqID", SqlDbType.VarChar));
			cmd.Parameters["OpenOrderReqID"].Direction = ParameterDirection.Input;
			cmd.Parameters["OpenOrderReqID"].Value = OpenOrderReqID;

			cmd.Parameters.Add(new SqlParameter("QTXT", SqlDbType.VarChar));
			cmd.Parameters["QTXT"].Direction = ParameterDirection.Input;
			cmd.Parameters["QTXT"].Value = QTXT;

			cmd.Parameters.Add(new SqlParameter("StopOrderID", SqlDbType.VarChar));
			cmd.Parameters["StopOrderID"].Direction = ParameterDirection.Input;
			cmd.Parameters["StopOrderID"].Value = StopOrderID;

			cmd.Parameters.Add(new SqlParameter("LimitOrderID", SqlDbType.VarChar));
			cmd.Parameters["LimitOrderID"].Direction = ParameterDirection.Input;
			cmd.Parameters["LimitOrderID"].Value = LimitOrderID;

			cmd.Parameters.Add(new SqlParameter("TradeIDOrigin", SqlDbType.VarChar));
			cmd.Parameters["TradeIDOrigin"].Direction = ParameterDirection.Input;
			cmd.Parameters["TradeIDOrigin"].Value = TradeIDOrigin;

			cmd.ExecuteNonQuery();
		}





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
