using System;
using System.Data;
using System.Data.SqlClient;
using 定数;
using 共通Data;

namespace DB
{
    public static class swap
    {
        private static SqlCommand cmd_GetSwap_手動登録Swap;
        private static SqlCommand cmd_Get売買Swapがどちらも0になる前のSwap;
        private static SqlCommand cmd_InsertSwap手動登録_Day1;
        private static SqlCommand cmd_Insert手動登録したSwapを他DBへも反映する;

        public static void SqlCommandInitialize(SqlConnection cn)
        {
            cmd_GetSwap_手動登録Swap = new SqlCommand("swap.spGetSwap_手動登録Swap", cn);
            cmd_GetSwap_手動登録Swap.CommandType = CommandType.StoredProcedure;
            //cmd_GetSwap_手動登録Swap.CommandTimeout = DB定数.CommandTimeout;
            cmd_GetSwap_手動登録Swap.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_GetSwap_手動登録Swap.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_GetSwap_手動登録Swap.Parameters.Add(new SqlParameter("Swap_買い", SqlDbType.Float));
            cmd_GetSwap_手動登録Swap.Parameters["Swap_買い"].Direction = ParameterDirection.Output;
            cmd_GetSwap_手動登録Swap.Parameters.Add(new SqlParameter("Swap_売り", SqlDbType.Float));
            cmd_GetSwap_手動登録Swap.Parameters["Swap_売り"].Direction = ParameterDirection.Output;

            cmd_Get売買Swapがどちらも0になる前のSwap = new SqlCommand("swap.spGet売買Swapがどちらも0になる前のSwap", cn);
            cmd_Get売買Swapがどちらも0になる前のSwap.CommandType = CommandType.StoredProcedure;
            //cmd_Get売買Swapがどちらも0になる前のSwap.CommandTimeout = DB定数.CommandTimeout;
            cmd_Get売買Swapがどちらも0になる前のSwap.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_Get売買Swapがどちらも0になる前のSwap.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_Get売買Swapがどちらも0になる前のSwap.Parameters.Add(new SqlParameter("Swap_買い", SqlDbType.Float));
            cmd_Get売買Swapがどちらも0になる前のSwap.Parameters["Swap_買い"].Direction = ParameterDirection.Output;
            cmd_Get売買Swapがどちらも0になる前のSwap.Parameters.Add(new SqlParameter("Swap_売り", SqlDbType.Float));
            cmd_Get売買Swapがどちらも0になる前のSwap.Parameters["Swap_売り"].Direction = ParameterDirection.Output;

            cmd_InsertSwap手動登録_Day1 = new SqlCommand("swap.spInsertSwap手動登録_Day1", cn);
            cmd_InsertSwap手動登録_Day1.CommandType = CommandType.StoredProcedure;
            //cmd_InsertSwap手動登録_Day1.CommandTimeout = DB定数.CommandTimeout;
            cmd_InsertSwap手動登録_Day1.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_InsertSwap手動登録_Day1.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_InsertSwap手動登録_Day1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_InsertSwap手動登録_Day1.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_InsertSwap手動登録_Day1.Parameters.Add(new SqlParameter("買いSwap", SqlDbType.Float));
            cmd_InsertSwap手動登録_Day1.Parameters["買いSwap"].Direction = ParameterDirection.Input;
            cmd_InsertSwap手動登録_Day1.Parameters.Add(new SqlParameter("売りSwap", SqlDbType.Float));
            cmd_InsertSwap手動登録_Day1.Parameters["売りSwap"].Direction = ParameterDirection.Input;
        }

        public static void GetSwap_手動登録Swap(通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_GetSwap_手動登録Swap.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;

                cmd_GetSwap_手動登録Swap.ExecuteNonQuery();

                通貨ぺア取引状況.買いSwap = (double)cmd_GetSwap_手動登録Swap.Parameters["Swap_買い"].Value;
                通貨ぺア取引状況.売りSwap = (double)cmd_GetSwap_手動登録Swap.Parameters["Swap_売り"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                throw;
            }
        }

        public static void Get売買Swapがどちらも0になる前のSwap(通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_Get売買Swapがどちらも0になる前のSwap.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;

                cmd_Get売買Swapがどちらも0になる前のSwap.ExecuteNonQuery();

                通貨ぺア取引状況.買いSwap = (double)cmd_Get売買Swapがどちらも0になる前のSwap.Parameters["Swap_買い"].Value;
                通貨ぺア取引状況.売りSwap = (double)cmd_Get売買Swapがどちらも0になる前のSwap.Parameters["Swap_売り"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                throw;
            }
        }

        public static void InsertSwap手動登録_Day1(byte 通貨ペアNo, DateTime StartDate, double 買いSwap, double 売りSwap)
        {
            try
            {
                cmd_InsertSwap手動登録_Day1.Parameters["通貨ペアNo"].Value = 通貨ペアNo;
                cmd_InsertSwap手動登録_Day1.Parameters["StartDate"].Value = StartDate;
                cmd_InsertSwap手動登録_Day1.Parameters["買いSwap"].Value = 買いSwap;
                cmd_InsertSwap手動登録_Day1.Parameters["売りSwap"].Value = 売りSwap;

                cmd_InsertSwap手動登録_Day1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ペアNo.ToString());
                ログ.ログ書き出し("StartDate : " + StartDate);
                ログ.ログ書き出し("買いSwap : " + 買いSwap);
                ログ.ログ書き出し("売りSwap : " + 売りSwap);
                throw;
            }
        }

        public static void Insert手動登録したSwapを他DBへも反映する()
        {
            try
            {
                cmd_Insert手動登録したSwapを他DBへも反映する = new SqlCommand("swap.spInsert手動登録したSwapを他DBへも反映する", FormData.cn);
                cmd_Insert手動登録したSwapを他DBへも反映する.CommandType = CommandType.StoredProcedure;
                cmd_Insert手動登録したSwapを他DBへも反映する.CommandTimeout = DB定数.CommandTimeout;

                cmd_Insert手動登録したSwapを他DBへも反映する.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                throw;
            }
        }

    }
}
