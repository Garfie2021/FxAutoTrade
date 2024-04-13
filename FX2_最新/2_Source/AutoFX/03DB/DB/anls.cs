using System;
using System.Data;
using System.Data.SqlClient;
using 定数;
using 共通Data;

namespace DB
{
    public static class anls
    {
        private static SqlCommand cmd_Get注文単位を割る値;

        public static void SqlCommandInitialize(SqlConnection cn)
        {
            cmd_Get注文単位を割る値 = new SqlCommand("anls.spGet注文単位を割る値", cn);
            cmd_Get注文単位を割る値.CommandType = CommandType.StoredProcedure;
            //cmd_Get注文単位を割る値.CommandTimeout = DB定数.CommandTimeout;
            cmd_Get注文単位を割る値.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_Get注文単位を割る値.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_Get注文単位を割る値.Parameters.Add(new SqlParameter("売買", SqlDbType.Bit));
            cmd_Get注文単位を割る値.Parameters["売買"].Direction = ParameterDirection.Input;
            cmd_Get注文単位を割る値.Parameters.Add(new SqlParameter("Rate", SqlDbType.Float));
            cmd_Get注文単位を割る値.Parameters["Rate"].Direction = ParameterDirection.Input;
            cmd_Get注文単位を割る値.Parameters.Add(new SqlParameter("注文単位を割る値", SqlDbType.Int));
            cmd_Get注文単位を割る値.Parameters["注文単位を割る値"].Direction = ParameterDirection.Output;
        }

        public static void Get注文単位を割る値(通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_Get注文単位を割る値.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_Get注文単位を割る値.Parameters["売買"].Value = 通貨ぺア取引状況.売買;

                if (通貨ぺア取引状況.売買 == true)
                {
                    cmd_Get注文単位を割る値.Parameters["Rate"].Value = 通貨ぺア取引状況.買いRate;
                }
                else
                {
                    cmd_Get注文単位を割る値.Parameters["Rate"].Value = 通貨ぺア取引状況.売りRate;
                }

                cmd_Get注文単位を割る値.ExecuteNonQuery();

                通貨ぺア取引状況.注文単位を割る値 = (int)cmd_Get注文単位を割る値.Parameters["注文単位を割る値"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("通貨ぺア取引状況.通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo);
                ログ.ログ書き出し("通貨ぺア取引状況.売買 : " + 通貨ぺア取引状況.売買);
                ログ.ログ書き出し("通貨ぺア取引状況.買いRate : " + 通貨ぺア取引状況.買いRate);
                ログ.ログ書き出し("通貨ぺア取引状況.売りRate : " + 通貨ぺア取引状況.売りRate);
                ログ.ログ書き出し("cmd.Parameters[\"注文単位を割る値\"].Value : " + cmd_Get注文単位を割る値.Parameters["注文単位を割る値"].Value);
                ログ.ログ書き出し("通貨ぺア取引状況.注文単位を割る値 : " + 通貨ぺア取引状況.注文単位を割る値);
                throw;
            }
        }

    }
}
