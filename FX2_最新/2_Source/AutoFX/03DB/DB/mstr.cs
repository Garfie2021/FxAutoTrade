using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using 定数;
using 共通Data;

namespace DB
{
    public static class mstr
    {
        private static SqlCommand cmd_DB一覧取得;

        public static void SqlCommandInitialize(SqlConnection cn)
        {
            cmd_DB一覧取得 = new SqlCommand("mstr.spDB一覧取得", cn);
            cmd_DB一覧取得.CommandType = CommandType.StoredProcedure;
            //cmd_DB一覧取得.CommandTimeout = DB定数.CommandTimeout;
        }

        public static void DB一覧取得(ref List<string> DB一覧)
        {
            try
            {
                using (var reader = cmd_DB一覧取得.ExecuteReader())
                {
                    DB一覧 = new List<string>();

                    while (reader.Read())
                    {
                        DB一覧.Add((string)reader[0]);
                    }
                }
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
