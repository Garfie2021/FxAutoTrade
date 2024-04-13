using System.Data;
using System.Data.SqlClient;
using 定数;

namespace DB_FXCM
{
    public static class rate
    {
        private static SqlCommand cmd_取り込み済みデータを全て削除;
        private static SqlCommand cmd_時間調整実行;

        public static void SqlCommandInitialize(SqlConnection cn)
        {
            cmd_取り込み済みデータを全て削除 = new SqlCommand("rate.sp取り込み済みデータを全て削除", cn);
            cmd_取り込み済みデータを全て削除.CommandType = CommandType.StoredProcedure;
            //cmd_取り込み済みデータを全て削除.CommandTimeout = DB定数.CommandTimeout;

            cmd_時間調整実行 = new SqlCommand("rate.sp時間調整実行", cn);
            cmd_時間調整実行.CommandType = CommandType.StoredProcedure;
            //cmd_時間調整実行.CommandTimeout = DB定数.CommandTimeout;
        }

        public static void 取り込み済みデータを全て削除()
        {
            cmd_取り込み済みデータを全て削除.ExecuteNonQuery();
        }

        public static void 時間調整実行()
        {
            cmd_時間調整実行.ExecuteNonQuery();
        }

    }
}
