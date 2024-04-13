using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using 定数;

namespace DB_Maintenance
{
    public static class cnt
    {
        private static SqlCommand cmd;

        public static byte 通貨ペア数(SqlConnection cn)
        {
            cmd = new SqlCommand("cnt.sp通貨ペア数", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            cmd.Parameters.Add(new SqlParameter("通貨ペア数", SqlDbType.TinyInt));
            cmd.Parameters["通貨ペア数"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            return (byte)cmd.Parameters["通貨ペア数"].Value;
        }

        #region TAB（テーブル別）

        public static void テーブル別(SqlConnection cn, ref DataGridView dgv)
        {
            cmd = new SqlCommand("cnt.spテーブル別", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            SQL実行結果をDGVに展開(cmd.ExecuteReader(), ref dgv);
        }

        #endregion


        #region TAB（通貨ペア別）

        public static void 通貨ペア別Month1(SqlConnection cn, ref DataGridView dgv)
        {
            cmd = new SqlCommand("cnt.sp通貨ペア別Month1", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            SQL実行結果をDGVに展開(cmd.ExecuteReader(), ref dgv);
        }

        public static void 通貨ペア別Week1(SqlConnection cn, ref DataGridView dgv)
        {
            cmd = new SqlCommand("cnt.sp通貨ペア別Week1", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            SQL実行結果をDGVに展開(cmd.ExecuteReader(), ref dgv);
        }

        public static void 通貨ペア別Day1(SqlConnection cn, ref DataGridView dgv)
        {
            cmd = new SqlCommand("cnt.sp通貨ペア別Day1", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            SQL実行結果をDGVに展開(cmd.ExecuteReader(), ref dgv);
        }

        public static void 通貨ペア別Hour1(SqlConnection cn, ref DataGridView dgv)
        {
            cmd = new SqlCommand("cnt.sp通貨ペア別Hour1", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            SQL実行結果をDGVに展開(cmd.ExecuteReader(), ref dgv);
        }

        public static void 通貨ペア別Min15(SqlConnection cn, ref DataGridView dgv)
        {
            cmd = new SqlCommand("cnt.sp通貨ペア別Min15", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            SQL実行結果をDGVに展開(cmd.ExecuteReader(), ref dgv);
        }

        public static void 通貨ペア別Min5(SqlConnection cn, ref DataGridView dgv)
        {
            cmd = new SqlCommand("cnt.sp通貨ペア別Min5", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            SQL実行結果をDGVに展開(cmd.ExecuteReader(), ref dgv);
        }

        public static void 通貨ペア別Min1(SqlConnection cn, ref DataGridView dgv)
        {
            cmd = new SqlCommand("cnt.sp通貨ペア別Min1", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            SQL実行結果をDGVに展開(cmd.ExecuteReader(), ref dgv);
        }

        public static void 通貨ペア別Sec(SqlConnection cn, ref DataGridView dgv)
        {
            cmd = new SqlCommand("cnt.sp通貨ペア別Sec", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            SQL実行結果をDGVに展開(cmd.ExecuteReader(), ref dgv);
        }

        #endregion


        #region TAB（日付別）

        public static void 日付別Month1(SqlConnection cn, ref DataGridView dgv)
        {
            cmd = new SqlCommand("cnt.sp日付別Month1", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            SQL実行結果をDGVに展開(cmd.ExecuteReader(), ref dgv);
        }

        public static void 日付別Week1(SqlConnection cn, ref DataGridView dgv)
        {
            cmd = new SqlCommand("cnt.sp日付別Week1", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            SQL実行結果をDGVに展開(cmd.ExecuteReader(), ref dgv);
        }

        public static void 日付別Day1(SqlConnection cn, ref DataGridView dgv)
        {
            cmd = new SqlCommand("cnt.sp日付別Day1", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            SQL実行結果をDGVに展開(cmd.ExecuteReader(), ref dgv);
        }

        public static void 日付別Hour1(SqlConnection cn, ref DataGridView dgv)
        {
            cmd = new SqlCommand("cnt.sp日付別Hout1", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            SQL実行結果をDGVに展開(cmd.ExecuteReader(), ref dgv);
        }

        public static void 日付別Min15(SqlConnection cn, ref DataGridView dgv)
        {
            cmd = new SqlCommand("cnt.sp日付別Min15", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            SQL実行結果をDGVに展開(cmd.ExecuteReader(), ref dgv);
        }

        public static void 日付別Min5(SqlConnection cn, ref DataGridView dgv)
        {
            cmd = new SqlCommand("cnt.sp日付別Min5", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            SQL実行結果をDGVに展開(cmd.ExecuteReader(), ref dgv);
        }

        public static void 日付別Min1(SqlConnection cn, ref DataGridView dgv)
        {
            cmd = new SqlCommand("cnt.sp日付別Min1", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            SQL実行結果をDGVに展開(cmd.ExecuteReader(), ref dgv);
        }

        public static void 日付別Sec(SqlConnection cn, ref DataGridView dgv)
        {
            cmd = new SqlCommand("cnt.sp日付別Sec", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            SQL実行結果をDGVに展開(cmd.ExecuteReader(), ref dgv);
        }

        #endregion

        public static void 否定形集計(SqlConnection cn, string TableName, string 通貨ペアNo,
            ref DataGridView dgv)
        {
            cmd = new SqlCommand("cnt.sp日付別通貨ペア別", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            cmd.Parameters.Add(new SqlParameter("TableName", SqlDbType.TinyInt));
            cmd.Parameters["TableName"].Direction = ParameterDirection.Input;
            cmd.Parameters["TableName"].Value = TableName;

            cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

            SQL実行結果をDGVに展開(cmd.ExecuteReader(), ref dgv);
        }


        private static void SQL実行結果をDGVに展開(SqlDataReader reader, ref DataGridView dgv)
        {
            dgv.Columns.Clear();

            // SQLの実行結果から列を再作成
            int i = 0;
            while (i < reader.FieldCount)
            {
                dgv.Columns.Add(reader.GetName(i), reader.GetName(i));
                i++;
            }

            // SQLの実行結果をグリッドに表示
            int row = 0;
            while (reader.Read())
            {
                dgv.Rows.Add();

                int clm = 0;
                while (clm < reader.FieldCount)
                {
                    dgv.Rows[row].Cells[clm].Value = reader[clm].ToString();
                    clm++;
                }

                row++;
            }

            reader.Close();
        }

    }
}
