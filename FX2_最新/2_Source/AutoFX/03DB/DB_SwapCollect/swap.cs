using System;
using System.Data;
using System.Data.SqlClient;
using 定数;
using 共通Data;


namespace DB_SwapCollect
{
    public static class swap
    {
        private static SqlCommand cmd;

        public static void InsertSwap手動登録_Day1_toDemo()
        {
            try
            {
                cmd = new SqlCommand("swap.spInsertSwap手動登録_Day1_toDemo", FormData.cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = DB定数.CommandTimeout;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                throw;
            }
        }

        public static void InsertSwap手動登録_Day1_toReal()
        {
            try
            {
                cmd = new SqlCommand("swap.spInsertSwap手動登録_Day1_toReal", FormData.cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = DB定数.CommandTimeout;

                cmd.ExecuteNonQuery();
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
