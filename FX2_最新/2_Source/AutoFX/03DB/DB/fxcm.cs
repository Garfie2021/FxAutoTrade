using System;
using System.Data;
using System.Data.SqlClient;
using 定数;
using 共通Data;

namespace DB
{
    public static class fxcm
    {
        private static SqlCommand cmd_Cnt約定数;
        private static SqlCommand cmd_Cnt_Trades_TradeID;
        private static SqlCommand cmd_SelectCnt_TradeID;
        private static SqlCommand cmd_InsertTrade;
        private static SqlCommand cmd_InsertClosedTrades;
        private static SqlCommand cmd_InsertAccounts;
        private static SqlCommand cmd_GetSUM差益;

        public static void SqlCommandInitialize(SqlConnection cn)
        {
            cmd_Cnt約定数 = new SqlCommand("fxcm.spCnt約定数", cn);
            cmd_Cnt約定数.CommandType = CommandType.StoredProcedure;
            //cmd_Cnt約定数.CommandTimeout = DB定数.CommandTimeout;
            cmd_Cnt約定数.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_Cnt約定数.Parameters["口座No"].Direction = ParameterDirection.Input;
            cmd_Cnt約定数.Parameters.Add(new SqlParameter("from", SqlDbType.VarChar));
            cmd_Cnt約定数.Parameters["from"].Direction = ParameterDirection.Input;
            cmd_Cnt約定数.Parameters.Add(new SqlParameter("Cnt", SqlDbType.Int));
            cmd_Cnt約定数.Parameters["Cnt"].Direction = ParameterDirection.Output;

            cmd_Cnt_Trades_TradeID = new SqlCommand("fxcm.spCnt_Trades_TradeID", cn);
            cmd_Cnt_Trades_TradeID.CommandType = CommandType.StoredProcedure;
            //cmd_Cnt_Trades_TradeID.CommandTimeout = DB定数.CommandTimeout;
            cmd_Cnt_Trades_TradeID.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_Cnt_Trades_TradeID.Parameters["口座No"].Direction = ParameterDirection.Input;
            cmd_Cnt_Trades_TradeID.Parameters.Add(new SqlParameter("TradeID", SqlDbType.VarChar));
            cmd_Cnt_Trades_TradeID.Parameters["TradeID"].Direction = ParameterDirection.Input;
            cmd_Cnt_Trades_TradeID.Parameters.Add(new SqlParameter("Cnt", SqlDbType.Int));
            cmd_Cnt_Trades_TradeID.Parameters["Cnt"].Direction = ParameterDirection.Output;

            cmd_SelectCnt_TradeID = new SqlCommand("fxcm.spCnt_ClosedTrades_TradeID", cn);
            cmd_SelectCnt_TradeID.CommandType = CommandType.StoredProcedure;
            //cmd_SelectCnt_TradeID.CommandTimeout = DB定数.CommandTimeout;
            cmd_SelectCnt_TradeID.Parameters.Add(new SqlParameter("TradeID", SqlDbType.VarChar));
            cmd_SelectCnt_TradeID.Parameters["TradeID"].Direction = ParameterDirection.Input;
            cmd_SelectCnt_TradeID.Parameters.Add(new SqlParameter("Cnt", SqlDbType.Int));
            cmd_SelectCnt_TradeID.Parameters["Cnt"].Direction = ParameterDirection.Output;

            cmd_InsertTrade = new SqlCommand("fxcm.spInsertTrades", cn);
            cmd_InsertTrade.CommandType = CommandType.StoredProcedure;
            //cmd_InsertTrade.CommandTimeout = DB定数.CommandTimeout;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_InsertTrade.Parameters["口座No"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("TradeID", SqlDbType.VarChar));
            cmd_InsertTrade.Parameters["TradeID"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("AccountID", SqlDbType.VarChar));
            cmd_InsertTrade.Parameters["AccountID"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("AccountName", SqlDbType.VarChar));
            cmd_InsertTrade.Parameters["AccountName"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("OfferID", SqlDbType.VarChar));
            cmd_InsertTrade.Parameters["OfferID"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("Instrument", SqlDbType.VarChar));
            cmd_InsertTrade.Parameters["Instrument"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("Lot", SqlDbType.Int));
            cmd_InsertTrade.Parameters["Lot"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("AmountK", SqlDbType.Float));
            cmd_InsertTrade.Parameters["AmountK"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("BS", SqlDbType.VarChar));
            cmd_InsertTrade.Parameters["BS"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("Open", SqlDbType.Float));
            cmd_InsertTrade.Parameters["Open"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("Close", SqlDbType.Float));
            cmd_InsertTrade.Parameters["Close"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("Stop", SqlDbType.Float));
            cmd_InsertTrade.Parameters["Stop"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("UntTrlMove", SqlDbType.Float));
            cmd_InsertTrade.Parameters["UntTrlMove"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("Limit", SqlDbType.Float));
            cmd_InsertTrade.Parameters["Limit"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("UntTrlMoveLimit", SqlDbType.Float));
            cmd_InsertTrade.Parameters["UntTrlMoveLimit"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("PL", SqlDbType.Float));
            cmd_InsertTrade.Parameters["PL"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("GrossPL", SqlDbType.Float));
            cmd_InsertTrade.Parameters["GrossPL"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("Com", SqlDbType.Float));
            cmd_InsertTrade.Parameters["Com"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("Int", SqlDbType.Float));
            cmd_InsertTrade.Parameters["Int"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("Time", SqlDbType.DateTime));
            cmd_InsertTrade.Parameters["Time"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("IsBuy", SqlDbType.TinyInt));
            cmd_InsertTrade.Parameters["IsBuy"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("Kind", SqlDbType.VarChar));
            cmd_InsertTrade.Parameters["Kind"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("QuoteID", SqlDbType.VarChar));
            cmd_InsertTrade.Parameters["QuoteID"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("OpenOrderID", SqlDbType.VarChar));
            cmd_InsertTrade.Parameters["OpenOrderID"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("OpenOrderReqID", SqlDbType.VarChar));
            cmd_InsertTrade.Parameters["OpenOrderReqID"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("QTXT", SqlDbType.VarChar));
            cmd_InsertTrade.Parameters["QTXT"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("StopOrderID", SqlDbType.VarChar));
            cmd_InsertTrade.Parameters["StopOrderID"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("LimitOrderID", SqlDbType.VarChar));
            cmd_InsertTrade.Parameters["LimitOrderID"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("TradeIDOrigin", SqlDbType.VarChar));
            cmd_InsertTrade.Parameters["TradeIDOrigin"].Direction = ParameterDirection.Input;

            cmd_InsertClosedTrades = new SqlCommand("fxcm.spInsertClosedTrades", cn);
            cmd_InsertClosedTrades.CommandType = CommandType.StoredProcedure;
            //cmd_InsertClosedTrades.CommandTimeout = DB定数.CommandTimeout;
            cmd_InsertClosedTrades.Parameters.Add(new SqlParameter("TradeID", SqlDbType.VarChar));
            cmd_InsertClosedTrades.Parameters["TradeID"].Direction = ParameterDirection.Input;
            cmd_InsertClosedTrades.Parameters.Add(new SqlParameter("AccountID", SqlDbType.VarChar));
            cmd_InsertClosedTrades.Parameters["AccountID"].Direction = ParameterDirection.Input;
            cmd_InsertClosedTrades.Parameters.Add(new SqlParameter("AccountName", SqlDbType.VarChar));
            cmd_InsertClosedTrades.Parameters["AccountName"].Direction = ParameterDirection.Input;
            cmd_InsertClosedTrades.Parameters.Add(new SqlParameter("OfferID", SqlDbType.VarChar));
            cmd_InsertClosedTrades.Parameters["OfferID"].Direction = ParameterDirection.Input;
            cmd_InsertClosedTrades.Parameters.Add(new SqlParameter("Instrument", SqlDbType.VarChar));
            cmd_InsertClosedTrades.Parameters["Instrument"].Direction = ParameterDirection.Input;
            cmd_InsertClosedTrades.Parameters.Add(new SqlParameter("Lot", SqlDbType.Int));
            cmd_InsertClosedTrades.Parameters["Lot"].Direction = ParameterDirection.Input;
            cmd_InsertClosedTrades.Parameters.Add(new SqlParameter("AmountK", SqlDbType.Float));
            cmd_InsertClosedTrades.Parameters["AmountK"].Direction = ParameterDirection.Input;
            cmd_InsertClosedTrades.Parameters.Add(new SqlParameter("BS", SqlDbType.VarChar));
            cmd_InsertClosedTrades.Parameters["BS"].Direction = ParameterDirection.Input;
            cmd_InsertClosedTrades.Parameters.Add(new SqlParameter("Open", SqlDbType.Float));
            cmd_InsertClosedTrades.Parameters["Open"].Direction = ParameterDirection.Input;
            cmd_InsertClosedTrades.Parameters.Add(new SqlParameter("Close", SqlDbType.Float));
            cmd_InsertClosedTrades.Parameters["Close"].Direction = ParameterDirection.Input;
            cmd_InsertClosedTrades.Parameters.Add(new SqlParameter("PL", SqlDbType.Float));
            cmd_InsertClosedTrades.Parameters["PL"].Direction = ParameterDirection.Input;
            cmd_InsertClosedTrades.Parameters.Add(new SqlParameter("GrossPL", SqlDbType.Float));
            cmd_InsertClosedTrades.Parameters["GrossPL"].Direction = ParameterDirection.Input;
            cmd_InsertClosedTrades.Parameters.Add(new SqlParameter("Com", SqlDbType.Float));
            cmd_InsertClosedTrades.Parameters["Com"].Direction = ParameterDirection.Input;
            cmd_InsertClosedTrades.Parameters.Add(new SqlParameter("Int", SqlDbType.Float));
            cmd_InsertClosedTrades.Parameters["Int"].Direction = ParameterDirection.Input;
            cmd_InsertClosedTrades.Parameters.Add(new SqlParameter("OpenTime", SqlDbType.DateTime));
            cmd_InsertClosedTrades.Parameters["OpenTime"].Direction = ParameterDirection.Input;
            cmd_InsertClosedTrades.Parameters.Add(new SqlParameter("CloseTime", SqlDbType.DateTime));
            cmd_InsertClosedTrades.Parameters["CloseTime"].Direction = ParameterDirection.Input;
            cmd_InsertClosedTrades.Parameters.Add(new SqlParameter("Kind", SqlDbType.VarChar));
            cmd_InsertClosedTrades.Parameters["Kind"].Direction = ParameterDirection.Input;
            cmd_InsertClosedTrades.Parameters.Add(new SqlParameter("OpenOrderID", SqlDbType.VarChar));
            cmd_InsertClosedTrades.Parameters["OpenOrderID"].Direction = ParameterDirection.Input;
            cmd_InsertClosedTrades.Parameters.Add(new SqlParameter("OpenOrderReqID", SqlDbType.VarChar));
            cmd_InsertClosedTrades.Parameters["OpenOrderReqID"].Direction = ParameterDirection.Input;
            cmd_InsertClosedTrades.Parameters.Add(new SqlParameter("CloseOrderID", SqlDbType.VarChar));
            cmd_InsertClosedTrades.Parameters["CloseOrderID"].Direction = ParameterDirection.Input;
            cmd_InsertClosedTrades.Parameters.Add(new SqlParameter("CloseOrderReqID", SqlDbType.VarChar));
            cmd_InsertClosedTrades.Parameters["CloseOrderReqID"].Direction = ParameterDirection.Input;
            cmd_InsertClosedTrades.Parameters.Add(new SqlParameter("OQTXT", SqlDbType.VarChar));
            cmd_InsertClosedTrades.Parameters["OQTXT"].Direction = ParameterDirection.Input;
            cmd_InsertClosedTrades.Parameters.Add(new SqlParameter("CQTXT", SqlDbType.VarChar));
            cmd_InsertClosedTrades.Parameters["CQTXT"].Direction = ParameterDirection.Input;
            cmd_InsertClosedTrades.Parameters.Add(new SqlParameter("TradeIDOrigin", SqlDbType.VarChar));
            cmd_InsertClosedTrades.Parameters["TradeIDOrigin"].Direction = ParameterDirection.Input;
            cmd_InsertClosedTrades.Parameters.Add(new SqlParameter("TradeIDRemain", SqlDbType.VarChar));
            cmd_InsertClosedTrades.Parameters["TradeIDRemain"].Direction = ParameterDirection.Input;

            cmd_InsertAccounts = new SqlCommand("fxcm.spInsertAccounts", cn);
            cmd_InsertAccounts.CommandType = CommandType.StoredProcedure;
            //cmd_InsertAccounts.CommandTimeout = DB定数.CommandTimeout;
            cmd_InsertAccounts.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_InsertAccounts.Parameters["口座No"].Direction = ParameterDirection.Input;
            cmd_InsertAccounts.Parameters.Add(new SqlParameter("日時", SqlDbType.DateTime));
            cmd_InsertAccounts.Parameters["日時"].Direction = ParameterDirection.Input;
            cmd_InsertAccounts.Parameters.Add(new SqlParameter("AccountID", SqlDbType.VarChar));
            cmd_InsertAccounts.Parameters["AccountID"].Direction = ParameterDirection.Input;
            cmd_InsertAccounts.Parameters.Add(new SqlParameter("AccountName", SqlDbType.VarChar));
            cmd_InsertAccounts.Parameters["AccountName"].Direction = ParameterDirection.Input;
            cmd_InsertAccounts.Parameters.Add(new SqlParameter("Balance", SqlDbType.Float));
            cmd_InsertAccounts.Parameters["Balance"].Direction = ParameterDirection.Input;
            cmd_InsertAccounts.Parameters.Add(new SqlParameter("Equity", SqlDbType.Float));
            cmd_InsertAccounts.Parameters["Equity"].Direction = ParameterDirection.Input;
            cmd_InsertAccounts.Parameters.Add(new SqlParameter("DayPL", SqlDbType.Float));
            cmd_InsertAccounts.Parameters["DayPL"].Direction = ParameterDirection.Input;
            cmd_InsertAccounts.Parameters.Add(new SqlParameter("NontrdEqty", SqlDbType.Float));
            cmd_InsertAccounts.Parameters["NontrdEqty"].Direction = ParameterDirection.Input;
            cmd_InsertAccounts.Parameters.Add(new SqlParameter("M2MEquity", SqlDbType.Float));
            cmd_InsertAccounts.Parameters["M2MEquity"].Direction = ParameterDirection.Input;
            cmd_InsertAccounts.Parameters.Add(new SqlParameter("UsedMargin", SqlDbType.Float));
            cmd_InsertAccounts.Parameters["UsedMargin"].Direction = ParameterDirection.Input;
            cmd_InsertAccounts.Parameters.Add(new SqlParameter("UsableMargin", SqlDbType.Float));
            cmd_InsertAccounts.Parameters["UsableMargin"].Direction = ParameterDirection.Input;
            cmd_InsertAccounts.Parameters.Add(new SqlParameter("GrossPL", SqlDbType.Float));
            cmd_InsertAccounts.Parameters["GrossPL"].Direction = ParameterDirection.Input;
            cmd_InsertAccounts.Parameters.Add(new SqlParameter("Kind", SqlDbType.VarChar));
            cmd_InsertAccounts.Parameters["Kind"].Direction = ParameterDirection.Input;
            cmd_InsertAccounts.Parameters.Add(new SqlParameter("MarginCall", SqlDbType.VarChar));
            cmd_InsertAccounts.Parameters["MarginCall"].Direction = ParameterDirection.Input;
            cmd_InsertAccounts.Parameters.Add(new SqlParameter("IsUnderMarginCall", SqlDbType.VarChar));
            cmd_InsertAccounts.Parameters["IsUnderMarginCall"].Direction = ParameterDirection.Input;
            cmd_InsertAccounts.Parameters.Add(new SqlParameter("Hedging", SqlDbType.VarChar));
            cmd_InsertAccounts.Parameters["Hedging"].Direction = ParameterDirection.Input;
            cmd_InsertAccounts.Parameters.Add(new SqlParameter("AmountLimit", SqlDbType.Int));
            cmd_InsertAccounts.Parameters["AmountLimit"].Direction = ParameterDirection.Input;
            cmd_InsertAccounts.Parameters.Add(new SqlParameter("BaseUnitSize", SqlDbType.Int));
            cmd_InsertAccounts.Parameters["BaseUnitSize"].Direction = ParameterDirection.Input;

            cmd_GetSUM差益 = new SqlCommand("fxcm.spGetSUM差益", cn);
            cmd_GetSUM差益.CommandType = CommandType.StoredProcedure;
            //cmd_GetSUM差益.CommandTimeout = DB定数.CommandTimeout;
            cmd_GetSUM差益.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_GetSUM差益.Parameters["口座No"].Direction = ParameterDirection.Input;
            cmd_GetSUM差益.Parameters.Add(new SqlParameter("FromDate", SqlDbType.DateTime));
            cmd_GetSUM差益.Parameters["FromDate"].Direction = ParameterDirection.Input;
            cmd_GetSUM差益.Parameters.Add(new SqlParameter("ToDate", SqlDbType.DateTime));
            cmd_GetSUM差益.Parameters["ToDate"].Direction = ParameterDirection.Input;
            cmd_GetSUM差益.Parameters.Add(new SqlParameter("利益", SqlDbType.Int));
            cmd_GetSUM差益.Parameters["利益"].Direction = ParameterDirection.Output;

        }

        public static int Cnt約定数(DateTime from)
        {
            try
            {
                cmd_Cnt約定数.Parameters["口座No"].Value = FormData.口座No;
                cmd_Cnt約定数.Parameters["from"].Value = from;

                cmd_Cnt約定数.ExecuteNonQuery();

                return (int)cmd_Cnt約定数.Parameters["Cnt"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("from : " + from.ToString());
                throw;
            }
        }

        public static int Cnt_Trades_TradeID(int 口座No, string TradeID)
        {
            try
            {
                cmd_Cnt_Trades_TradeID.Parameters["口座No"].Value = 口座No;
                cmd_Cnt_Trades_TradeID.Parameters["TradeID"].Value = TradeID;

                cmd_Cnt_Trades_TradeID.ExecuteNonQuery();

                return (int)cmd_Cnt_Trades_TradeID.Parameters["Cnt"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("TradeID : " + TradeID);
                throw;
            }
        }

        public static int SelectCnt_TradeID(string TradeID)
        {
            try
            {
                cmd_SelectCnt_TradeID.Parameters["TradeID"].Value = TradeID;

                cmd_SelectCnt_TradeID.ExecuteNonQuery();

                return (int)cmd_SelectCnt_TradeID.Parameters["Cnt"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("TradeID : " + TradeID);
                throw;
            }
        }

        public static void InsertTrade(int 口座No,
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
            try
            {
                cmd_InsertTrade.Parameters["口座No"].Value = 口座No;
                cmd_InsertTrade.Parameters["TradeID"].Value = TradeID;
                cmd_InsertTrade.Parameters["AccountID"].Value = AccountID;
                cmd_InsertTrade.Parameters["AccountName"].Value = AccountName;
                cmd_InsertTrade.Parameters["OfferID"].Value = OfferID;
                cmd_InsertTrade.Parameters["Instrument"].Value = Instrument;
                cmd_InsertTrade.Parameters["Lot"].Value = Lot;
                cmd_InsertTrade.Parameters["AmountK"].Value = AmountK;
                cmd_InsertTrade.Parameters["BS"].Value = BS;
                cmd_InsertTrade.Parameters["Open"].Value = Open;
                cmd_InsertTrade.Parameters["Stop"].Value = Stop;
                cmd_InsertTrade.Parameters["Close"].Value = Close;
                cmd_InsertTrade.Parameters["UntTrlMove"].Value = UntTrlMove;
                cmd_InsertTrade.Parameters["Limit"].Value = Limit;
                cmd_InsertTrade.Parameters["UntTrlMoveLimit"].Value = UntTrlMoveLimit;
                cmd_InsertTrade.Parameters["PL"].Value = PL;
                cmd_InsertTrade.Parameters["GrossPL"].Value = GrossPL;
                cmd_InsertTrade.Parameters["Com"].Value = Com;
                cmd_InsertTrade.Parameters["Int"].Value = Int;
                cmd_InsertTrade.Parameters["Time"].Value = Time;
                cmd_InsertTrade.Parameters["IsBuy"].Value = IsBuy;
                cmd_InsertTrade.Parameters["Kind"].Value = Kind;
                cmd_InsertTrade.Parameters["QuoteID"].Value = QuoteID;
                cmd_InsertTrade.Parameters["OpenOrderID"].Value = OpenOrderID;
                cmd_InsertTrade.Parameters["OpenOrderReqID"].Value = OpenOrderReqID;
                cmd_InsertTrade.Parameters["QTXT"].Value = QTXT;
                cmd_InsertTrade.Parameters["StopOrderID"].Value = StopOrderID;
                cmd_InsertTrade.Parameters["LimitOrderID"].Value = LimitOrderID;
                cmd_InsertTrade.Parameters["TradeIDOrigin"].Value = TradeIDOrigin;

                cmd_InsertTrade.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("TradeID : " + TradeID);
                ログ.ログ書き出し("	 AccountID;	 : " + AccountID);
                ログ.ログ書き出し("	 AccountName;	 : " + AccountName);
                ログ.ログ書き出し("	 AmountK;	 : " + AmountK);
                ログ.ログ書き出し("	 BS;	 : " + BS);
                ログ.ログ書き出し("	 Close;	 : " + Close);
                ログ.ログ書き出し("	 Com;	 : " + Com);
                ログ.ログ書き出し("	 GrossPL;	 : " + GrossPL);
                ログ.ログ書き出し("	 Instrument;	 : " + Instrument);
                ログ.ログ書き出し("	 Int;	 : " + Int);
                ログ.ログ書き出し("	 IsBuy;	 : " + IsBuy);
                ログ.ログ書き出し("	 Kind;	 : " + Kind);
                ログ.ログ書き出し("	 Limit;	 : " + Limit);
                ログ.ログ書き出し("	 LimitOrderID;	 : " + LimitOrderID);
                ログ.ログ書き出し("	 Lot;	 : " + Lot);
                ログ.ログ書き出し("	 OfferID;	 : " + OfferID);
                ログ.ログ書き出し("	 Open;	 : " + Open);
                ログ.ログ書き出し("	 OpenOrderID;	 : " + OpenOrderID);
                ログ.ログ書き出し("	 OpenOrderReqID;	 : " + OpenOrderReqID);
                ログ.ログ書き出し("	 PL;	 : " + PL);
                ログ.ログ書き出し("	 QTXT;	 : " + QTXT);
                ログ.ログ書き出し("	 QuoteID;	 : " + QuoteID);
                ログ.ログ書き出し("	 Stop;	 : " + Stop);
                ログ.ログ書き出し("	 StopOrderID;	 : " + StopOrderID);
                ログ.ログ書き出し("	 Time;	 : " + Time);
                ログ.ログ書き出し("	 TradeIDOrigin;	 : " + TradeIDOrigin);
                ログ.ログ書き出し("	 UntTrlMove;	 : " + UntTrlMove);
                throw;
            }
        }

        public static void InsertClosedTrades(string TradeID,
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
            try
            {
                cmd_InsertClosedTrades.Parameters["TradeID"].Value = TradeID;
                cmd_InsertClosedTrades.Parameters["AccountID"].Value = AccountID;
                cmd_InsertClosedTrades.Parameters["AccountName"].Value = AccountName;
                cmd_InsertClosedTrades.Parameters["OfferID"].Value = OfferID;
                cmd_InsertClosedTrades.Parameters["Instrument"].Value = Instrument;
                cmd_InsertClosedTrades.Parameters["Lot"].Value = Lot;
                cmd_InsertClosedTrades.Parameters["AmountK"].Value = AmountK;
                cmd_InsertClosedTrades.Parameters["BS"].Value = BS;
                cmd_InsertClosedTrades.Parameters["Open"].Value = Open;
                cmd_InsertClosedTrades.Parameters["Close"].Value = Close;
                cmd_InsertClosedTrades.Parameters["PL"].Value = PL;
                cmd_InsertClosedTrades.Parameters["GrossPL"].Value = GrossPL;
                cmd_InsertClosedTrades.Parameters["Com"].Value = Com;
                cmd_InsertClosedTrades.Parameters["Int"].Value = Int;
                cmd_InsertClosedTrades.Parameters["OpenTime"].Value = OpenTime;
                cmd_InsertClosedTrades.Parameters["CloseTime"].Value = CloseTime;
                cmd_InsertClosedTrades.Parameters["Kind"].Value = Kind;
                cmd_InsertClosedTrades.Parameters["OpenOrderID"].Value = OpenOrderID;
                cmd_InsertClosedTrades.Parameters["OpenOrderReqID"].Value = OpenOrderReqID;
                cmd_InsertClosedTrades.Parameters["CloseOrderID"].Value = CloseOrderID;
                cmd_InsertClosedTrades.Parameters["CloseOrderReqID"].Value = CloseOrderReqID;
                cmd_InsertClosedTrades.Parameters["OQTXT"].Value = OQTXT;
                cmd_InsertClosedTrades.Parameters["CQTXT"].Value = CQTXT;
                cmd_InsertClosedTrades.Parameters["TradeIDOrigin"].Value = TradeIDOrigin;
                cmd_InsertClosedTrades.Parameters["TradeIDRemain"].Value = TradeIDRemain;

                cmd_InsertClosedTrades.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("TradeID : " + TradeID);
                ログ.ログ書き出し("AccountID : " + AccountID);
                ログ.ログ書き出し("AccountName : " + AccountName);
                ログ.ログ書き出し("AmountK : " + AmountK);
                ログ.ログ書き出し("BS : " + BS);
                ログ.ログ書き出し("Close : " + Close);
                ログ.ログ書き出し("CloseOrderID : " + CloseOrderID);
                ログ.ログ書き出し("CloseOrderReqID : " + CloseOrderReqID);
                ログ.ログ書き出し("CloseTime : " + CloseTime);
                ログ.ログ書き出し("Com : " + Com);
                ログ.ログ書き出し("CQTXT : " + CQTXT);
                ログ.ログ書き出し("GrossPL : " + GrossPL);
                ログ.ログ書き出し("Instrument : " + Instrument);
                ログ.ログ書き出し("Int : " + Int);
                ログ.ログ書き出し("Kind : " + Kind);
                ログ.ログ書き出し("Lot : " + Lot);
                ログ.ログ書き出し("OfferID : " + OfferID);
                ログ.ログ書き出し("Open : " + Open);
                ログ.ログ書き出し("OpenOrderID : " + OpenOrderID);
                ログ.ログ書き出し("OpenOrderReqID : " + OpenOrderReqID);
                ログ.ログ書き出し("OpenTime : " + OpenTime);
                ログ.ログ書き出し("OQTXT : " + OQTXT);
                ログ.ログ書き出し("PL : " + PL);
                ログ.ログ書き出し("TradeIDOrigin : " + TradeIDOrigin);
                ログ.ログ書き出し("TradeIDRemain : " + TradeIDRemain);
                throw;
            }
        }

        public static void InsertAccounts(
            int 口座No,
            DateTime 日時,
            string AccountID,
            string AccountName,
            double Balance,
            double Equity,
            double DayPL,
            double NontrdEqty,
            double M2MEquity,
            double UsedMargin,
            double UsableMargin,
            double GrossPL,
            string Kind,
            string MarginCall,
            string IsUnderMarginCall,
            string Hedging,
            int AmountLimit,
            int BaseUnitSize)
        {
            try
            {

                cmd_InsertAccounts.Parameters["口座No"].Value = 口座No;
                cmd_InsertAccounts.Parameters["日時"].Value = 日時;
                cmd_InsertAccounts.Parameters["AccountID"].Value = AccountID;
                cmd_InsertAccounts.Parameters["AccountName"].Value = AccountName;
                cmd_InsertAccounts.Parameters["Balance"].Value = Balance;
                cmd_InsertAccounts.Parameters["Equity"].Value = Equity;
                cmd_InsertAccounts.Parameters["DayPL"].Value = DayPL;
                cmd_InsertAccounts.Parameters["NontrdEqty"].Value = NontrdEqty;
                cmd_InsertAccounts.Parameters["M2MEquity"].Value = M2MEquity;
                cmd_InsertAccounts.Parameters["UsedMargin"].Value = UsedMargin;
                cmd_InsertAccounts.Parameters["UsableMargin"].Value = UsableMargin;
                cmd_InsertAccounts.Parameters["GrossPL"].Value = GrossPL;
                cmd_InsertAccounts.Parameters["Kind"].Value = Kind;
                cmd_InsertAccounts.Parameters["MarginCall"].Value = MarginCall;
                cmd_InsertAccounts.Parameters["IsUnderMarginCall"].Value = IsUnderMarginCall;
                cmd_InsertAccounts.Parameters["Hedging"].Value = Hedging;
                cmd_InsertAccounts.Parameters["AmountLimit"].Value = AmountLimit;
                cmd_InsertAccounts.Parameters["BaseUnitSize"].Value = BaseUnitSize;

                cmd_InsertAccounts.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("日時 : " + 日時);
                ログ.ログ書き出し("AccountID : " + AccountID);
                ログ.ログ書き出し("AccountName : " + AccountName);
                ログ.ログ書き出し("Balance : " + Balance);
                ログ.ログ書き出し("Equity : " + Equity);
                ログ.ログ書き出し("DayPL : " + DayPL);
                ログ.ログ書き出し("NontrdEqty : " + NontrdEqty);
                ログ.ログ書き出し("M2MEquity : " + M2MEquity);
                ログ.ログ書き出し("UsedMargin : " + UsedMargin);
                ログ.ログ書き出し("UsableMargin : " + UsableMargin);
                ログ.ログ書き出し("GrossPL : " + GrossPL);
                ログ.ログ書き出し("Kind : " + Kind);
                ログ.ログ書き出し("MarginCall : " + MarginCall);
                ログ.ログ書き出し("IsUnderMarginCall : " + IsUnderMarginCall);
                ログ.ログ書き出し("Hedging : " + Hedging);
                ログ.ログ書き出し("AmountLimit : " + AmountLimit);
                ログ.ログ書き出し("BaseUnitSize : " + BaseUnitSize);
                throw;
            }
        }

        public static int GetSUM差益(DateTime FromDate, DateTime ToDate)
        {
            try
            {
                cmd_GetSUM差益.Parameters["口座No"].Value = FormData.口座No;
                cmd_GetSUM差益.Parameters["FromDate"].Value = FromDate;
                cmd_GetSUM差益.Parameters["ToDate"].Value = ToDate;

                cmd_GetSUM差益.ExecuteNonQuery();

                if (DBNull.Value == cmd_GetSUM差益.Parameters["利益"].Value)
                {
                    return 0;
                }
                else
                {
                    return (int)cmd_GetSUM差益.Parameters["利益"].Value;
                }
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("FromDate : " + FromDate);
                ログ.ログ書き出し("ToDate : " + ToDate);
                throw;
            }
        }
    }
}
