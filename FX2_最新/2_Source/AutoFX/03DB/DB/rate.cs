using System;
using System.Data;
using System.Data.SqlClient;
using 定数;
using 共通Data;

namespace DB
{
    public static class rate
    {
        private static SqlCommand cmd_InsertRateHistory_Min1;
        private static SqlCommand cmd_InsertRateHistory_Min5;
        private static SqlCommand cmd_InsertRateHistory_Min15;
        private static SqlCommand cmd_InsertRateHistory_Hour1;
        private static SqlCommand cmd_InsertRateHistory_Day1;
        private static SqlCommand cmd_InsertRateHistory_Week1;
        private static SqlCommand cmd_InsertRateHistory_Month1;
        private static SqlCommand cmd_InsertRateHistoryAll_Min1;
        private static SqlCommand cmd_InsertRateHistoryAll_Min5;
        private static SqlCommand cmd_InsertRateHistoryAll_Min15;
        private static SqlCommand cmd_InsertRateHistoryAll_Hour1;
        private static SqlCommand cmd_InsertRateHistoryAll_Day1;
        private static SqlCommand cmd_InsertRateHistoryAll_Week1;
        private static SqlCommand cmd_InsertRateHistoryAll_Month1;
        private static SqlCommand cmd_UpdateWMA_Min1;
        private static SqlCommand cmd_UpdateWMA_Min5;
        private static SqlCommand cmd_UpdateWMA_Min15;
        private static SqlCommand cmd_UpdateWMA_Hour1;
        private static SqlCommand cmd_UpdateWMA_Day1;
        private static SqlCommand cmd_UpdateWMA_Week1;
        private static SqlCommand cmd_UpdateWMA_Month1;
        private static SqlCommand cmd_UpdateWmaAll_Min1;
        private static SqlCommand cmd_UpdateWmaAll_Min5;
        private static SqlCommand cmd_UpdateWmaAll_Min15;
        private static SqlCommand cmd_UpdateWmaAll_Hour1;
        private static SqlCommand cmd_UpdateWmaAll_Day1;
        private static SqlCommand cmd_UpdateWmaAll_Week1;
        private static SqlCommand cmd_UpdateWmaAll_Month1;

        public static void SqlCommandInitialize(SqlConnection cn)
        {
            cmd_InsertRateHistory_Min1 = new SqlCommand("rate.spInsertHistory_Min1", cn);
            cmd_InsertRateHistory_Min1.CommandType = CommandType.StoredProcedure;
            //cmd_InsertRateHistory_Min1.CommandTimeout = DB定数.CommandTimeout;
            cmd_InsertRateHistory_Min1.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_InsertRateHistory_Min1.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_InsertRateHistory_Min1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_InsertRateHistory_Min1.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_InsertRateHistory_Min1.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
            cmd_InsertRateHistory_Min1.Parameters["EndDate"].Direction = ParameterDirection.Input;

            cmd_InsertRateHistory_Min5 = new SqlCommand("rate.spInsertHistory_Min5", cn);
            cmd_InsertRateHistory_Min5.CommandType = CommandType.StoredProcedure;
            //cmd_InsertRateHistory_Min5.CommandTimeout = DB定数.CommandTimeout;
            cmd_InsertRateHistory_Min5.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_InsertRateHistory_Min5.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_InsertRateHistory_Min5.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_InsertRateHistory_Min5.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_InsertRateHistory_Min5.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
            cmd_InsertRateHistory_Min5.Parameters["EndDate"].Direction = ParameterDirection.Input;

            cmd_InsertRateHistory_Min15 = new SqlCommand("rate.spInsertHistory_Min15", cn);
            cmd_InsertRateHistory_Min15.CommandType = CommandType.StoredProcedure;
            //cmd_InsertRateHistory_Min15.CommandTimeout = DB定数.CommandTimeout;
            cmd_InsertRateHistory_Min15.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_InsertRateHistory_Min15.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_InsertRateHistory_Min15.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_InsertRateHistory_Min15.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_InsertRateHistory_Min15.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
            cmd_InsertRateHistory_Min15.Parameters["EndDate"].Direction = ParameterDirection.Input;

            cmd_InsertRateHistory_Hour1 = new SqlCommand("rate.spInsertHistory_Hour1", cn);
            cmd_InsertRateHistory_Hour1.CommandType = CommandType.StoredProcedure;
            //cmd_InsertRateHistory_Hour1.CommandTimeout = DB定数.CommandTimeout;
            cmd_InsertRateHistory_Hour1.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_InsertRateHistory_Hour1.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_InsertRateHistory_Hour1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_InsertRateHistory_Hour1.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_InsertRateHistory_Hour1.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
            cmd_InsertRateHistory_Hour1.Parameters["EndDate"].Direction = ParameterDirection.Input;

            cmd_InsertRateHistory_Day1 = new SqlCommand("rate.spInsertHistory_Day1", cn);
            cmd_InsertRateHistory_Day1.CommandType = CommandType.StoredProcedure;
            //cmd_InsertRateHistory_Day1.CommandTimeout = DB定数.CommandTimeout;
            cmd_InsertRateHistory_Day1.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_InsertRateHistory_Day1.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_InsertRateHistory_Day1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_InsertRateHistory_Day1.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_InsertRateHistory_Day1.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
            cmd_InsertRateHistory_Day1.Parameters["EndDate"].Direction = ParameterDirection.Input;

            cmd_InsertRateHistory_Week1 = new SqlCommand("rate.spInsertHistory_Week1", cn);
            cmd_InsertRateHistory_Week1.CommandType = CommandType.StoredProcedure;
            //cmd_InsertRateHistory_Week1.CommandTimeout = DB定数.CommandTimeout;
            cmd_InsertRateHistory_Week1.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_InsertRateHistory_Week1.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_InsertRateHistory_Week1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_InsertRateHistory_Week1.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_InsertRateHistory_Week1.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
            cmd_InsertRateHistory_Week1.Parameters["EndDate"].Direction = ParameterDirection.Input;

            cmd_InsertRateHistory_Month1 = new SqlCommand("rate.spInsertHistory_Month1", cn);
            cmd_InsertRateHistory_Month1.CommandType = CommandType.StoredProcedure;
            //cmd_InsertRateHistory_Month1.CommandTimeout = DB定数.CommandTimeout;
            cmd_InsertRateHistory_Month1.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_InsertRateHistory_Month1.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_InsertRateHistory_Month1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_InsertRateHistory_Month1.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_InsertRateHistory_Month1.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
            cmd_InsertRateHistory_Month1.Parameters["EndDate"].Direction = ParameterDirection.Input;

            cmd_InsertRateHistoryAll_Min1 = new SqlCommand("rate.spInsertHistoryAll_Min1", cn);
            cmd_InsertRateHistoryAll_Min1.CommandType = CommandType.StoredProcedure;
            //cmd_InsertRateHistoryAll_Min1.CommandTimeout = DB定数.CommandTimeout;
            cmd_InsertRateHistoryAll_Min1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_InsertRateHistoryAll_Min1.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_InsertRateHistoryAll_Min1.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
            cmd_InsertRateHistoryAll_Min1.Parameters["EndDate"].Direction = ParameterDirection.Input;

            cmd_InsertRateHistoryAll_Min5 = new SqlCommand("rate.spInsertHistoryAll_Min5", cn);
            cmd_InsertRateHistoryAll_Min5.CommandType = CommandType.StoredProcedure;
            //cmd_InsertRateHistoryAll_Min5.CommandTimeout = DB定数.CommandTimeout;
            cmd_InsertRateHistoryAll_Min5.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_InsertRateHistoryAll_Min5.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_InsertRateHistoryAll_Min5.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
            cmd_InsertRateHistoryAll_Min5.Parameters["EndDate"].Direction = ParameterDirection.Input;

            cmd_InsertRateHistoryAll_Min15 = new SqlCommand("rate.spInsertHistoryAll_Min15", cn);
            cmd_InsertRateHistoryAll_Min15.CommandType = CommandType.StoredProcedure;
            //cmd_InsertRateHistoryAll_Min15.CommandTimeout = DB定数.CommandTimeout;
            cmd_InsertRateHistoryAll_Min15.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_InsertRateHistoryAll_Min15.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_InsertRateHistoryAll_Min15.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
            cmd_InsertRateHistoryAll_Min15.Parameters["EndDate"].Direction = ParameterDirection.Input;

            cmd_InsertRateHistoryAll_Hour1 = new SqlCommand("rate.spInsertHistoryAll_Hour1", cn);
            cmd_InsertRateHistoryAll_Hour1.CommandType = CommandType.StoredProcedure;
            //cmd_InsertRateHistoryAll_Hour1.CommandTimeout = DB定数.CommandTimeout;
            cmd_InsertRateHistoryAll_Hour1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_InsertRateHistoryAll_Hour1.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_InsertRateHistoryAll_Hour1.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
            cmd_InsertRateHistoryAll_Hour1.Parameters["EndDate"].Direction = ParameterDirection.Input;

            cmd_InsertRateHistoryAll_Day1 = new SqlCommand("rate.spInsertHistoryAll_Day1", cn);
            cmd_InsertRateHistoryAll_Day1.CommandType = CommandType.StoredProcedure;
            //cmd_InsertRateHistoryAll_Day1.CommandTimeout = DB定数.CommandTimeout;
            cmd_InsertRateHistoryAll_Day1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_InsertRateHistoryAll_Day1.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_InsertRateHistoryAll_Day1.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
            cmd_InsertRateHistoryAll_Day1.Parameters["EndDate"].Direction = ParameterDirection.Input;

            cmd_InsertRateHistoryAll_Week1 = new SqlCommand("rate.spInsertHistoryAll_Week1", cn);
            cmd_InsertRateHistoryAll_Week1.CommandType = CommandType.StoredProcedure;
            //cmd_InsertRateHistoryAll_Week1.CommandTimeout = DB定数.CommandTimeout;
            cmd_InsertRateHistoryAll_Week1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_InsertRateHistoryAll_Week1.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_InsertRateHistoryAll_Week1.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
            cmd_InsertRateHistoryAll_Week1.Parameters["EndDate"].Direction = ParameterDirection.Input;

            cmd_InsertRateHistoryAll_Month1 = new SqlCommand("rate.spInsertHistoryAll_Month1", cn);
            cmd_InsertRateHistoryAll_Month1.CommandType = CommandType.StoredProcedure;
            //cmd_InsertRateHistoryAll_Month1.CommandTimeout = DB定数.CommandTimeout;
            cmd_InsertRateHistoryAll_Month1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_InsertRateHistoryAll_Month1.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_InsertRateHistoryAll_Month1.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
            cmd_InsertRateHistoryAll_Month1.Parameters["EndDate"].Direction = ParameterDirection.Input;

            cmd_UpdateWMA_Min1 = new SqlCommand("rate.spUpdateWMA_Min1", cn);
            cmd_UpdateWMA_Min1.CommandType = CommandType.StoredProcedure;
            //cmd_UpdateWMA_Min1.CommandTimeout = DB定数.CommandTimeout;
            cmd_UpdateWMA_Min1.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_UpdateWMA_Min1.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_UpdateWMA_Min1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_UpdateWMA_Min1.Parameters["StartDate"].Direction = ParameterDirection.Input;

            cmd_UpdateWMA_Min5 = new SqlCommand("rate.spUpdateWMA_Min5", cn);
            cmd_UpdateWMA_Min5.CommandType = CommandType.StoredProcedure;
            //cmd_UpdateWMA_Min5.CommandTimeout = DB定数.CommandTimeout;
            cmd_UpdateWMA_Min5.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_UpdateWMA_Min5.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_UpdateWMA_Min5.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_UpdateWMA_Min5.Parameters["StartDate"].Direction = ParameterDirection.Input;

            cmd_UpdateWMA_Min15 = new SqlCommand("rate.spUpdateWMA_Min15", cn);
            cmd_UpdateWMA_Min15.CommandType = CommandType.StoredProcedure;
            //cmd_UpdateWMA_Min15.CommandTimeout = DB定数.CommandTimeout;
            cmd_UpdateWMA_Min15.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_UpdateWMA_Min15.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_UpdateWMA_Min15.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_UpdateWMA_Min15.Parameters["StartDate"].Direction = ParameterDirection.Input;

            cmd_UpdateWMA_Hour1 = new SqlCommand("rate.spUpdateWMA_Hour1", cn);
            cmd_UpdateWMA_Hour1.CommandType = CommandType.StoredProcedure;
            //cmd_UpdateWMA_Hour1.CommandTimeout = DB定数.CommandTimeout;
            cmd_UpdateWMA_Hour1.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_UpdateWMA_Hour1.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_UpdateWMA_Hour1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_UpdateWMA_Hour1.Parameters["StartDate"].Direction = ParameterDirection.Input;

            cmd_UpdateWMA_Day1 = new SqlCommand("rate.spUpdateWMA_Day1", cn);
            cmd_UpdateWMA_Day1.CommandType = CommandType.StoredProcedure;
            //cmd_UpdateWMA_Day1.CommandTimeout = DB定数.CommandTimeout;
            cmd_UpdateWMA_Day1.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_UpdateWMA_Day1.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_UpdateWMA_Day1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_UpdateWMA_Day1.Parameters["StartDate"].Direction = ParameterDirection.Input;

            cmd_UpdateWMA_Week1 = new SqlCommand("rate.spUpdateWMA_Week1", cn);
            cmd_UpdateWMA_Week1.CommandType = CommandType.StoredProcedure;
            //cmd_UpdateWMA_Week1.CommandTimeout = DB定数.CommandTimeout;
            cmd_UpdateWMA_Week1.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_UpdateWMA_Week1.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_UpdateWMA_Week1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_UpdateWMA_Week1.Parameters["StartDate"].Direction = ParameterDirection.Input;

            cmd_UpdateWMA_Month1 = new SqlCommand("rate.spUpdateWMA_Month1", cn);
            cmd_UpdateWMA_Month1.CommandType = CommandType.StoredProcedure;
            //cmd_UpdateWMA_Month1.CommandTimeout = DB定数.CommandTimeout;
            cmd_UpdateWMA_Month1.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_UpdateWMA_Month1.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_UpdateWMA_Month1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_UpdateWMA_Month1.Parameters["StartDate"].Direction = ParameterDirection.Input;

            cmd_UpdateWmaAll_Min1 = new SqlCommand("rate.spUpdateWmaAll_Min1", cn);
            cmd_UpdateWmaAll_Min1.CommandType = CommandType.StoredProcedure;
            //cmd_UpdateWmaAll_Min1.CommandTimeout = DB定数.CommandTimeout;
            cmd_UpdateWmaAll_Min1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_UpdateWmaAll_Min1.Parameters["StartDate"].Direction = ParameterDirection.Input;

            cmd_UpdateWmaAll_Min5 = new SqlCommand("rate.spUpdateWmaAll_Min5", cn);
            cmd_UpdateWmaAll_Min5.CommandType = CommandType.StoredProcedure;
            //cmd_UpdateWmaAll_Min5.CommandTimeout = DB定数.CommandTimeout;
            cmd_UpdateWmaAll_Min5.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_UpdateWmaAll_Min5.Parameters["StartDate"].Direction = ParameterDirection.Input;

            cmd_UpdateWmaAll_Min15 = new SqlCommand("rate.spUpdateWmaAll_Min15", cn);
            cmd_UpdateWmaAll_Min15.CommandType = CommandType.StoredProcedure;
            //cmd_UpdateWmaAll_Min15.CommandTimeout = DB定数.CommandTimeout;
            cmd_UpdateWmaAll_Min15.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_UpdateWmaAll_Min15.Parameters["StartDate"].Direction = ParameterDirection.Input;

            cmd_UpdateWmaAll_Hour1 = new SqlCommand("rate.spUpdateWmaAll_Hour1", cn);
            cmd_UpdateWmaAll_Hour1.CommandType = CommandType.StoredProcedure;
            //cmd_UpdateWmaAll_Hour1.CommandTimeout = DB定数.CommandTimeout;
            cmd_UpdateWmaAll_Hour1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_UpdateWmaAll_Hour1.Parameters["StartDate"].Direction = ParameterDirection.Input;

            cmd_UpdateWmaAll_Day1 = new SqlCommand("rate.spUpdateWmaAll_Day1", cn);
            cmd_UpdateWmaAll_Day1.CommandType = CommandType.StoredProcedure;
            //cmd_UpdateWmaAll_Day1.CommandTimeout = DB定数.CommandTimeout;
            cmd_UpdateWmaAll_Day1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_UpdateWmaAll_Day1.Parameters["StartDate"].Direction = ParameterDirection.Input;

            cmd_UpdateWmaAll_Week1 = new SqlCommand("rate.spUpdateWmaAll_Week1", cn);
            cmd_UpdateWmaAll_Week1.CommandType = CommandType.StoredProcedure;
            //cmd_UpdateWmaAll_Week1.CommandTimeout = DB定数.CommandTimeout;
            cmd_UpdateWmaAll_Week1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_UpdateWmaAll_Week1.Parameters["StartDate"].Direction = ParameterDirection.Input;

            cmd_UpdateWmaAll_Month1 = new SqlCommand("rate.spUpdateWmaAll_Month1", cn);
            cmd_UpdateWmaAll_Month1.CommandType = CommandType.StoredProcedure;
            //cmd_UpdateWmaAll_Month1.CommandTimeout = DB定数.CommandTimeout;
            cmd_UpdateWmaAll_Month1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_UpdateWmaAll_Month1.Parameters["StartDate"].Direction = ParameterDirection.Input;

        }

        public static void InsertRateHistory_Min1(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_InsertRateHistory_Min1.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_InsertRateHistory_Min1.Parameters["StartDate"].Value = OrderData.StartMin1;
                cmd_InsertRateHistory_Min1.Parameters["EndDate"].Value = OrderData.EndMin1;

                cmd_InsertRateHistory_Min1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("OrderData.StartMin1 : " + OrderData.StartMin1);
                ログ.ログ書き出し("OrderData.EndMin1 : " + OrderData.EndMin1);
                throw;
            }
        }

        public static void InsertRateHistory_Min5(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_InsertRateHistory_Min5.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_InsertRateHistory_Min5.Parameters["StartDate"].Value = OrderData.StartMin5;
                cmd_InsertRateHistory_Min5.Parameters["EndDate"].Value = OrderData.EndMin5;

                cmd_InsertRateHistory_Min5.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("OrderData.StartMin5 : " + OrderData.StartMin5);
                ログ.ログ書き出し("OrderData.EndMin5 : " + OrderData.EndMin5);
                throw;
            }
        }

        public static void InsertRateHistory_Min15(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_InsertRateHistory_Min15.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_InsertRateHistory_Min15.Parameters["StartDate"].Value = OrderData.StartMin15;
                cmd_InsertRateHistory_Min15.Parameters["EndDate"].Value = OrderData.EndMin15;

                cmd_InsertRateHistory_Min15.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("OrderData.StartMin15 : " + OrderData.StartMin15);
                ログ.ログ書き出し("OrderData.EndMin15 : " + OrderData.EndMin15);
                throw;
            }
        }

        public static void InsertRateHistory_Hour1(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_InsertRateHistory_Hour1.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_InsertRateHistory_Hour1.Parameters["StartDate"].Value = OrderData.StartHour1;
                cmd_InsertRateHistory_Hour1.Parameters["EndDate"].Value = OrderData.EndHour1;

                cmd_InsertRateHistory_Hour1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("StartDate " + OrderData.StartHour1.ToString());
                ログ.ログ書き出し("EndDate " + OrderData.EndHour1.ToString());

                throw;
            }
        }

        public static void InsertRateHistory_Day1(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_InsertRateHistory_Day1.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_InsertRateHistory_Day1.Parameters["StartDate"].Value = OrderData.StartDay1;
                cmd_InsertRateHistory_Day1.Parameters["EndDate"].Value = OrderData.EndDay1;

                cmd_InsertRateHistory_Day1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("OrderData.StartDay1 : " + OrderData.StartDay1);
                ログ.ログ書き出し("OrderData.EndDay1 : " + OrderData.EndDay1);
                throw;
            }
        }

        public static void InsertRateHistory_Week1(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_InsertRateHistory_Week1.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_InsertRateHistory_Week1.Parameters["StartDate"].Value = OrderData.StartWeek1;
                cmd_InsertRateHistory_Week1.Parameters["EndDate"].Value = OrderData.EndWeek1;

                cmd_InsertRateHistory_Week1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("OrderData.StartWeek1 : " + OrderData.StartWeek1);
                ログ.ログ書き出し("OrderData.EndWeek1 : " + OrderData.EndWeek1);
                throw;
            }
        }

        public static void InsertRateHistory_Month1(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_InsertRateHistory_Month1.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_InsertRateHistory_Month1.Parameters["StartDate"].Value = OrderData.StartMonth1;
                cmd_InsertRateHistory_Month1.Parameters["EndDate"].Value = OrderData.EndMonth1;

                cmd_InsertRateHistory_Month1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("OrderData.StartMonth1 : " + OrderData.StartMonth1);
                ログ.ログ書き出し("OrderData.EndMonth1 : " + OrderData.EndMonth1);
                throw;
            }
        }

        public static void InsertRateHistoryAll_Min1(OrderData OrderData)
        {
            try
            {
                cmd_InsertRateHistoryAll_Min1.Parameters["StartDate"].Value = OrderData.StartMin1;
                cmd_InsertRateHistoryAll_Min1.Parameters["EndDate"].Value = OrderData.EndMin1;

                cmd_InsertRateHistoryAll_Min1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("OrderData.StartMin1 : " + OrderData.StartMin1);
                ログ.ログ書き出し("OrderData.EndMin1 : " + OrderData.EndMin1);
                throw;
            }
        }

        public static void InsertRateHistoryAll_Min5(OrderData OrderData)
        {
            try
            {
                cmd_InsertRateHistoryAll_Min5.Parameters["StartDate"].Value = OrderData.StartMin5;
                cmd_InsertRateHistoryAll_Min5.Parameters["EndDate"].Value = OrderData.EndMin5;

                cmd_InsertRateHistoryAll_Min5.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("OrderData.StartMin5 : " + OrderData.StartMin5);
                ログ.ログ書き出し("OrderData.EndMin5 : " + OrderData.EndMin5);
                throw;
            }
        }

        public static void InsertRateHistoryAll_Min15(OrderData OrderData)
        {
            try
            {
                cmd_InsertRateHistoryAll_Min15.Parameters["StartDate"].Value = OrderData.StartMin15;
                cmd_InsertRateHistoryAll_Min15.Parameters["EndDate"].Value = OrderData.EndMin15;

                cmd_InsertRateHistoryAll_Min15.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("OrderData.StartMin15 : " + OrderData.StartMin15);
                ログ.ログ書き出し("OrderData.EndMin15 : " + OrderData.EndMin15);
                throw;
            }
        }

        public static void InsertRateHistoryAll_Hour1(OrderData OrderData)
        {
            try
            {
                cmd_InsertRateHistoryAll_Hour1.Parameters["StartDate"].Value = OrderData.StartHour1;
                cmd_InsertRateHistoryAll_Hour1.Parameters["EndDate"].Value = OrderData.EndHour1;

                cmd_InsertRateHistoryAll_Hour1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("OrderData.StartHour1 : " + OrderData.StartHour1);
                ログ.ログ書き出し("OrderData.EndHour1 : " + OrderData.EndHour1);
                throw;
            }
        }

        public static void InsertRateHistoryAll_Day1(OrderData OrderData)
        {
            try
            {
                cmd_InsertRateHistoryAll_Day1.Parameters["StartDate"].Value = OrderData.StartDay1;
                cmd_InsertRateHistoryAll_Day1.Parameters["EndDate"].Value = OrderData.EndDay1;

                cmd_InsertRateHistoryAll_Day1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("OrderData.StartDay1 : " + OrderData.StartDay1);
                ログ.ログ書き出し("OrderData.EndDay1 : " + OrderData.EndDay1);
                throw;
            }
        }

        public static void InsertRateHistoryAll_Week1(OrderData OrderData)
        {
            try
            {
                cmd_InsertRateHistoryAll_Week1.Parameters["StartDate"].Value = OrderData.StartWeek1;
                cmd_InsertRateHistoryAll_Week1.Parameters["EndDate"].Value = OrderData.EndWeek1;

                cmd_InsertRateHistoryAll_Week1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("OrderData.StartWeek1 : " + OrderData.StartWeek1);
                ログ.ログ書き出し("OrderData.EndWeek1 : " + OrderData.EndWeek1);
                throw;
            }
        }

        public static void InsertRateHistoryAll_Month1(OrderData OrderData)
        {
            try
            {
                cmd_InsertRateHistoryAll_Month1.Parameters["StartDate"].Value = OrderData.StartMonth1;
                cmd_InsertRateHistoryAll_Month1.Parameters["EndDate"].Value = OrderData.EndMonth1;

                cmd_InsertRateHistoryAll_Month1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("OrderData.StartMonth1 : " + OrderData.StartMonth1);
                ログ.ログ書き出し("OrderData.EndMonth1 : " + OrderData.EndMonth1);
                throw;
            }
        }

        public static void UpdateWMA_Min1(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_UpdateWMA_Min1.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_UpdateWMA_Min1.Parameters["StartDate"].Value = OrderData.StartMin1;

                cmd_UpdateWMA_Min1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("OrderData.StartMin1 : " + OrderData.StartMin1);
                throw;
            }
        }


        public static void UpdateWMA_Min5(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_UpdateWMA_Min5.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_UpdateWMA_Min5.Parameters["StartDate"].Value = OrderData.StartMin5;

                cmd_UpdateWMA_Min5.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("OrderData.StartMin5 : " + OrderData.StartMin5);
                throw;
            }
        }

        public static void UpdateWMA_Min15(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_UpdateWMA_Min15.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_UpdateWMA_Min15.Parameters["StartDate"].Value = OrderData.StartMin15;

                cmd_UpdateWMA_Min15.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("OrderData.StartMin15 : " + OrderData.StartMin15);
                throw;
            }
        }

        public static void UpdateWMA_Hour1(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_UpdateWMA_Hour1.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_UpdateWMA_Hour1.Parameters["StartDate"].Value = OrderData.StartHour1;

                cmd_UpdateWMA_Hour1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("OrderData.StartHour1 : " + OrderData.StartHour1);
                throw;
            }
        }

        public static void UpdateWMA_Day1(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_UpdateWMA_Day1.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_UpdateWMA_Day1.Parameters["StartDate"].Value = OrderData.StartDay1;

                cmd_UpdateWMA_Day1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("OrderData.StartDay1 : " + OrderData.StartDay1);
                throw;
            }
        }

        public static void UpdateWMA_Week1(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_UpdateWMA_Week1.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_UpdateWMA_Week1.Parameters["StartDate"].Value = OrderData.StartWeek1;

                cmd_UpdateWMA_Week1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("OrderData.StartWeek1 : " + OrderData.StartWeek1);
                throw;
            }
        }

        public static void UpdateWMA_Month1(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_UpdateWMA_Month1.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_UpdateWMA_Month1.Parameters["StartDate"].Value = OrderData.StartMonth1;

                cmd_UpdateWMA_Month1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("OrderData.StartMonth1 : " + OrderData.StartMonth1);
                throw;
            }
        }

        public static void UpdateWmaAll_Min1(OrderData OrderData)
        {
            try
            {
                cmd_UpdateWmaAll_Min1.Parameters["StartDate"].Value = OrderData.StartMin1;

                cmd_UpdateWmaAll_Min1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("OrderData.StartMin1 : " + OrderData.StartMin1);
                throw;
            }
        }

        public static void UpdateWmaAll_Min5(OrderData OrderData)
        {
            try
            {
                cmd_UpdateWmaAll_Min5.Parameters["StartDate"].Value = OrderData.StartMin5;

                cmd_UpdateWmaAll_Min5.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("OrderData.StartMin5 : " + OrderData.StartMin5);
                throw;
            }
        }

        public static void UpdateWmaAll_Min15(OrderData OrderData)
        {
            try
            {
                cmd_UpdateWmaAll_Min15.Parameters["StartDate"].Value = OrderData.StartMin15;

                cmd_UpdateWmaAll_Min15.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("OrderData.StartMin15 : " + OrderData.StartMin15);
                throw;
            }
        }

        public static void UpdateWmaAll_Hour1(OrderData OrderData)
        {
            try
            {
                cmd_UpdateWmaAll_Hour1.Parameters["StartDate"].Value = OrderData.StartHour1;

                cmd_UpdateWmaAll_Hour1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("OrderData.StartHour1 : " + OrderData.StartHour1);
                throw;
            }
        }

        public static void UpdateWmaAll_Day1(OrderData OrderData)
        {
            try
            {
                cmd_UpdateWmaAll_Day1.Parameters["StartDate"].Value = OrderData.StartDay1;

                cmd_UpdateWmaAll_Day1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("OrderData.StartDay1 : " + OrderData.StartDay1);
                throw;
            }
        }

        public static void UpdateWmaAll_Week1(OrderData OrderData)
        {
            try
            {
                cmd_UpdateWmaAll_Week1.Parameters["StartDate"].Value = OrderData.StartWeek1;

                cmd_UpdateWmaAll_Week1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("OrderData.StartWeek1 : " + OrderData.StartWeek1);
                throw;
            }
        }

        public static void UpdateWmaAll_Month1(OrderData OrderData)
        {
            try
            {
                cmd_UpdateWmaAll_Month1.Parameters["StartDate"].Value = OrderData.StartMonth1;

                cmd_UpdateWmaAll_Month1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("OrderData.StartMonth1 : " + OrderData.StartMonth1);
                throw;
            }
        }
    }
}
