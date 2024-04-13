using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using 定数;
using Common;


namespace DB_Maintenance
{
    public static class mstr
    {
        private static SqlCommand cmd;

        public static void DB一覧取得(SqlConnection cn, ref ComboBox cmb)
        {
            cmd = new SqlCommand("mstr.spDB一覧取得", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            コンボボックス.SQL実行結果をコンボボックスに展開(cmd.ExecuteReader(), ref cmb);
        }

        public static void テーブル一覧取得(SqlConnection cn, ref ComboBox cmb)
        {
            cmd = new SqlCommand("mstr.spテーブル一覧取得", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            コンボボックス.SQL実行結果をコンボボックスに展開(cmd.ExecuteReader(), ref cmb);
        }

    }
}
