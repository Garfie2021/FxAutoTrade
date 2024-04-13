using System;
using System.Data;
using System.Data.SqlClient;
using 定数;
using 共通Data;

namespace DB_Maintenance
{
    public static class anls
    {
        private static SqlCommand cmd;
        private static SqlCommand cmd_CntデルタRate_通貨ペアNo_StartDate;
        private static SqlCommand cmd_Cnt注文単位を割る値_通貨ペアNo_StartDate;

        public static int CntデルタRate_通貨ペアNo_登録日時(SqlConnection cn, int 通貨ペアNo, DateTime StartDate, DateTime EndDate)
        {
            cmd_CntデルタRate_通貨ペアNo_StartDate = new SqlCommand("anls.spCntデルタRate_通貨ペアNo_登録日時", cn);
            cmd_CntデルタRate_通貨ペアNo_StartDate.CommandType = CommandType.StoredProcedure;
            cmd_CntデルタRate_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_CntデルタRate_通貨ペアNo_StartDate.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_CntデルタRate_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_CntデルタRate_通貨ペアNo_StartDate.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_CntデルタRate_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
            cmd_CntデルタRate_通貨ペアNo_StartDate.Parameters["EndDate"].Direction = ParameterDirection.Input;
            cmd_CntデルタRate_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("Cnt", SqlDbType.Int));
            cmd_CntデルタRate_通貨ペアNo_StartDate.Parameters["Cnt"].Direction = ParameterDirection.Output;

            cmd_CntデルタRate_通貨ペアNo_StartDate.Parameters["通貨ペアNo"].Value = 通貨ペアNo;
            cmd_CntデルタRate_通貨ペアNo_StartDate.Parameters["StartDate"].Value = StartDate;
            cmd_CntデルタRate_通貨ペアNo_StartDate.Parameters["EndDate"].Value = EndDate;

            cmd_CntデルタRate_通貨ペアNo_StartDate.ExecuteNonQuery();

            return (int)cmd_CntデルタRate_通貨ペアNo_StartDate.Parameters["Cnt"].Value;
        }


        public static int Cnt注文単位を割る値_通貨ペアNo_登録日時(SqlConnection cn, int 通貨ペアNo, DateTime StartDate, DateTime EndDate)
        {
            cmd_Cnt注文単位を割る値_通貨ペアNo_StartDate = new SqlCommand("anls.spCnt注文単位を割る値_通貨ペアNo_登録日時", cn);
            cmd_Cnt注文単位を割る値_通貨ペアNo_StartDate.CommandType = CommandType.StoredProcedure;
            cmd_Cnt注文単位を割る値_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_Cnt注文単位を割る値_通貨ペアNo_StartDate.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_Cnt注文単位を割る値_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_Cnt注文単位を割る値_通貨ペアNo_StartDate.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_Cnt注文単位を割る値_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
            cmd_Cnt注文単位を割る値_通貨ペアNo_StartDate.Parameters["EndDate"].Direction = ParameterDirection.Input;
            cmd_Cnt注文単位を割る値_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("Cnt", SqlDbType.Int));
            cmd_Cnt注文単位を割る値_通貨ペアNo_StartDate.Parameters["Cnt"].Direction = ParameterDirection.Output;

            cmd_Cnt注文単位を割る値_通貨ペアNo_StartDate.Parameters["通貨ペアNo"].Value = 通貨ペアNo;
            cmd_Cnt注文単位を割る値_通貨ペアNo_StartDate.Parameters["StartDate"].Value = StartDate;
            cmd_Cnt注文単位を割る値_通貨ペアNo_StartDate.Parameters["EndDate"].Value = EndDate;

            cmd_Cnt注文単位を割る値_通貨ペアNo_StartDate.ExecuteNonQuery();

            return (int)cmd_Cnt注文単位を割る値_通貨ペアNo_StartDate.Parameters["Cnt"].Value;
        }

        public static string Get売買タイミング評価(SqlConnection cn, DateTime now)
        {
            try
            {
                cmd = new SqlCommand("anls.spGet売買タイミング評価", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = DB定数.CommandTimeout;

                cmd.Parameters.Add(new SqlParameter("now", SqlDbType.DateTime));
                cmd.Parameters["now"].Direction = ParameterDirection.Input;
                cmd.Parameters["now"].Value = now;

                cmd.Parameters.Add(new SqlParameter("評価", SqlDbType.VarChar, 8000));
                cmd.Parameters["評価"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                return (string)cmd.Parameters["評価"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                throw;
            }
        }

        public static DataTable Select想定売買タイミング(SqlConnection cn, DateTime 開始日時, DateTime 終了日時, double swap)
        {
            try
            {
                cmd = new SqlCommand("anls.spSelect想定売買タイミング", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = DB定数.CommandTimeout;

                cmd.Parameters.Add(new SqlParameter("from", SqlDbType.DateTime));
                cmd.Parameters["from"].Direction = ParameterDirection.Input;
                cmd.Parameters["from"].Value = 開始日時;

                cmd.Parameters.Add(new SqlParameter("to", SqlDbType.DateTime));
                cmd.Parameters["to"].Direction = ParameterDirection.Input;
                cmd.Parameters["to"].Value = 終了日時;

                cmd.Parameters.Add(new SqlParameter("swap", SqlDbType.Float));
                cmd.Parameters["swap"].Direction = ParameterDirection.Input;
                cmd.Parameters["swap"].Value = swap;

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

        public static DataTable Select想定売買タイミング_Swap判定無し(SqlConnection cn, DateTime 開始日時, DateTime 終了日時)
        {
            try
            {
                cmd = new SqlCommand("anls.spSelect想定売買タイミング_Swap判定無し", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = DB定数.CommandTimeout;

                cmd.Parameters.Add(new SqlParameter("from", SqlDbType.DateTime));
                cmd.Parameters["from"].Direction = ParameterDirection.Input;
                cmd.Parameters["from"].Value = 開始日時;

                cmd.Parameters.Add(new SqlParameter("to", SqlDbType.DateTime));
                cmd.Parameters["to"].Direction = ParameterDirection.Input;
                cmd.Parameters["to"].Value = 終了日時;

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
    }
}
