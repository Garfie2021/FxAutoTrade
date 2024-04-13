using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DB
{
	public static class fxcm
	{
		private static SqlCommand cmd;
		private static SqlDataReader Reader;

		public static int Cnt_Trades_TradeID(SqlConnection cn, string TradeID)
		{
			cmd = new SqlCommand("fxcm.spCnt_Trades_TradeID", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = dbo.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("TradeID", SqlDbType.VarChar));
			cmd.Parameters["TradeID"].Direction = ParameterDirection.Input;
			cmd.Parameters["TradeID"].Value = TradeID;

			cmd.Parameters.Add(new SqlParameter("Cnt", SqlDbType.Int));
			cmd.Parameters["Cnt"].Direction = ParameterDirection.Output;

			cmd.ExecuteNonQuery();

			return (int)cmd.Parameters["Cnt"].Value;
		}

		public static int Cnt_ClosedTrades_TradeID(SqlConnection cn, string TradeID)
		{
			cmd = new SqlCommand("fxcm.spCnt_ClosedTrades_TradeID", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = dbo.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("TradeID", SqlDbType.VarChar));
			cmd.Parameters["TradeID"].Direction = ParameterDirection.Input;
			cmd.Parameters["TradeID"].Value = TradeID;

			cmd.Parameters.Add(new SqlParameter("Cnt", SqlDbType.Int));
			cmd.Parameters["Cnt"].Direction = ParameterDirection.Output;

			cmd.ExecuteNonQuery();

			return (int)cmd.Parameters["Cnt"].Value;
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
			cmd = new SqlCommand("fxcm.spInsertTrades", cn);
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
			cmd = new SqlCommand("fxcm.spInsertClosedTrades", cn);
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

	}
}
