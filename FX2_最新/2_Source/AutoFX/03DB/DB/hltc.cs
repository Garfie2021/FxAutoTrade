using System;
using System.Data;
using System.Data.SqlClient;
using 定数;
using 共通Data;

namespace DB
{
    public static class hltc
    {
        private static SqlCommand cmd_Increment取引状況でデータ不足が発生した件数;
        private static SqlCommand cmd_Increment通常Order件数;

        public static void SqlCommandInitialize(SqlConnection cn)
        {
            cmd_Increment取引状況でデータ不足が発生した件数 = new SqlCommand("hltc.SP_Increment取引状況でデータ不足が発生した件数", cn);
            cmd_Increment取引状況でデータ不足が発生した件数.CommandType = CommandType.StoredProcedure;
            //cmd_Increment取引状況でデータ不足が発生した件数.CommandTimeout = DB定数.CommandTimeout;

            cmd_Increment通常Order件数 = new SqlCommand("hltc.SP_Increment通常Order件数", cn);
            cmd_Increment通常Order件数.CommandType = CommandType.StoredProcedure;
            //cmd_Increment通常Order件数.CommandTimeout = DB定数.CommandTimeout;
        }

        public static void Increment取引状況でデータ不足が発生した件数()
        {
            try
            {
                cmd_Increment取引状況でデータ不足が発生した件数.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                throw;
            }
        }

        public static void Increment通常Order件数()
        {
            try
            {
                cmd_Increment通常Order件数.ExecuteNonQuery();
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
