using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using 定数;
using 共通Data;

namespace DB_Maintenance
{
    public static class swap
    {
        private static SqlCommand cmd;
        private static SqlCommand cmd_CntSwap手動登録_Day1_StartDate;

        public static int CntSwap手動登録_Day1_StartDate(SqlConnection cn, DateTime StartDate, DateTime EndDate)
        {
            cmd_CntSwap手動登録_Day1_StartDate = new SqlCommand("swap.spCntSwap手動登録_Day1_StartDate", cn);
            cmd_CntSwap手動登録_Day1_StartDate.CommandType = CommandType.StoredProcedure;
            cmd_CntSwap手動登録_Day1_StartDate.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_CntSwap手動登録_Day1_StartDate.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_CntSwap手動登録_Day1_StartDate.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
            cmd_CntSwap手動登録_Day1_StartDate.Parameters["EndDate"].Direction = ParameterDirection.Input;
            cmd_CntSwap手動登録_Day1_StartDate.Parameters.Add(new SqlParameter("Cnt", SqlDbType.Int));
            cmd_CntSwap手動登録_Day1_StartDate.Parameters["Cnt"].Direction = ParameterDirection.Output;

            cmd_CntSwap手動登録_Day1_StartDate.Parameters["StartDate"].Value = StartDate;
            cmd_CntSwap手動登録_Day1_StartDate.Parameters["EndDate"].Value = EndDate;

            cmd_CntSwap手動登録_Day1_StartDate.ExecuteNonQuery();

            return (int)cmd_CntSwap手動登録_Day1_StartDate.Parameters["Cnt"].Value;
        }

        public static DataTable Select最新Swap一覧()
        {
            try
            {
                cmd = new SqlCommand("swap.spSelect最新Swap一覧", FormData.cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = DB定数.CommandTimeout;

                using (var reader = cmd.ExecuteReader())
                {
                    DataTable data = new DataTable();
                    data.Load(reader);

                    reader.Close();

                    return data;
                }
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                throw;
            }
        }

        public static void Get手動登録済み最新Swap(byte 通貨ペアNo, out double 買いSwap, out double 売りSwap)
        {
            try
            {
                cmd = new SqlCommand("swap.spGet手動登録済み最新Swap", FormData.cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = DB定数.CommandTimeout;

                cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
                cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
                cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

                cmd.Parameters.Add(new SqlParameter("Swap_買い", SqlDbType.Float));
                cmd.Parameters["Swap_買い"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add(new SqlParameter("Swap_売り", SqlDbType.Float));
                cmd.Parameters["Swap_売り"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                if (cmd.Parameters["Swap_買い"].Value == DBNull.Value)
                {
                    MessageBox.Show("登録されていません");
                    買いSwap = 0;
                    売りSwap = 0;
                    return;
                }

                買いSwap = (double)cmd.Parameters["Swap_買い"].Value;
                売りSwap = (double)cmd.Parameters["Swap_売り"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ペアNo.ToString());
                throw;
            }
        }
    }
}
