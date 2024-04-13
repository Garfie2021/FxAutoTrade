using System;
using System.Data;
using System.Data.SqlClient;
using 定数;
using 共通Data;

namespace DB_Maintenance
{
    public static class oanda
    {
        private static SqlCommand cmd;
        private static SqlCommand cmd_GetTransactionCnt_time;
        private static SqlCommand cmd_CntAccount_口座No_日時;

        public static int CntAccount_口座No_日時(SqlConnection cn, int 口座No, DateTime StartDate, DateTime EndDate)
        {
            cmd_CntAccount_口座No_日時 = new SqlCommand("oanda.spCntAccount_口座No_日時", cn);
            cmd_CntAccount_口座No_日時.CommandType = CommandType.StoredProcedure;
            cmd_CntAccount_口座No_日時.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_CntAccount_口座No_日時.Parameters["口座No"].Direction = ParameterDirection.Input;
            cmd_CntAccount_口座No_日時.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_CntAccount_口座No_日時.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_CntAccount_口座No_日時.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
            cmd_CntAccount_口座No_日時.Parameters["EndDate"].Direction = ParameterDirection.Input;
            cmd_CntAccount_口座No_日時.Parameters.Add(new SqlParameter("Cnt", SqlDbType.Int));
            cmd_CntAccount_口座No_日時.Parameters["Cnt"].Direction = ParameterDirection.Output;

            cmd_CntAccount_口座No_日時.Parameters["口座No"].Value = 口座No;
            cmd_CntAccount_口座No_日時.Parameters["StartDate"].Value = StartDate;
            cmd_CntAccount_口座No_日時.Parameters["EndDate"].Value = EndDate;

            cmd_CntAccount_口座No_日時.ExecuteNonQuery();

            return (int)cmd_CntAccount_口座No_日時.Parameters["Cnt"].Value;
        }

        public static int GetTransactionCnt_time(SqlConnection cn, int 口座No, DateTime StartDate, DateTime EndDate)
        {
            cmd_GetTransactionCnt_time = new SqlCommand("oanda.spGetTransactionCnt_time", cn);
            cmd_GetTransactionCnt_time.CommandType = CommandType.StoredProcedure;
            cmd_GetTransactionCnt_time.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_GetTransactionCnt_time.Parameters["口座No"].Direction = ParameterDirection.Input;
            cmd_GetTransactionCnt_time.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_GetTransactionCnt_time.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_GetTransactionCnt_time.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
            cmd_GetTransactionCnt_time.Parameters["EndDate"].Direction = ParameterDirection.Input;
            cmd_GetTransactionCnt_time.Parameters.Add(new SqlParameter("Cnt", SqlDbType.Int));
            cmd_GetTransactionCnt_time.Parameters["Cnt"].Direction = ParameterDirection.Output;

            cmd_GetTransactionCnt_time.Parameters["口座No"].Value = 口座No;
            cmd_GetTransactionCnt_time.Parameters["StartDate"].Value = StartDate;
            cmd_GetTransactionCnt_time.Parameters["EndDate"].Value = EndDate;

            cmd_GetTransactionCnt_time.ExecuteNonQuery();

            return (int)cmd_GetTransactionCnt_time.Parameters["Cnt"].Value;
        }


        public static DataTable SelectTransaction月次利益請求(SqlConnection cn, int 口座No, DateTime 開始日時, DateTime 終了日時)
        {
            try
            {
                cmd = new SqlCommand("oanda.spSelectTransaction月次利益請求", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = DB定数.CommandTimeout;

                cmd.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
                cmd.Parameters["口座No"].Direction = ParameterDirection.Input;
                cmd.Parameters["口座No"].Value = 口座No;

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


        public static DataTable Rateダウンロード対象通貨ペア確認(SqlConnection cn)
        {
            cmd = new SqlCommand("oanda.spRateダウンロード対象通貨ペア確認", cn);
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

        public static string 注文可能通貨ペア確認(SqlConnection cn)
        {
            cmd = new SqlCommand("oanda.sp通貨ペア別の最新売買スワップ", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            cmd.Parameters.Add(new SqlParameter("result", SqlDbType.VarChar, 8000));
            cmd.Parameters["result"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            return (string)cmd.Parameters["result"].Value;
        }

        public static DataTable SelectOrderResponse(SqlConnection cn, int 口座No, DateTime 開始日時, DateTime 終了日時)
        {
            try
            {
                cmd = new SqlCommand("oanda.spSelectOrderResponse", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = DB定数.CommandTimeout;

                cmd.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
                cmd.Parameters["口座No"].Direction = ParameterDirection.Input;
                cmd.Parameters["口座No"].Value = 口座No;

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

        public static DataTable SelectOrder_注文削除(SqlConnection cn, int 口座No, DateTime 開始日時, DateTime 終了日時)
        {
            try
            {
                cmd = new SqlCommand("oanda.spSelectOrder_注文削除", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = DB定数.CommandTimeout;

                cmd.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
                cmd.Parameters["口座No"].Direction = ParameterDirection.Input;
                cmd.Parameters["口座No"].Value = 口座No;

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

        public static DataTable SelectTrade(SqlConnection cn, int 口座No, DateTime 開始日時, DateTime 終了日時)
        {
            try
            {
                cmd = new SqlCommand("oanda.spSelectTrade", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = DB定数.CommandTimeout;

                cmd.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
                cmd.Parameters["口座No"].Direction = ParameterDirection.Input;
                cmd.Parameters["口座No"].Value = 口座No;

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

        public static DataTable SelectTrade_リミット変更(SqlConnection cn, int 口座No, DateTime 開始日時, DateTime 終了日時)
        {
            try
            {
                cmd = new SqlCommand("oanda.spSelectTrade_リミット変更", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = DB定数.CommandTimeout;

                cmd.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
                cmd.Parameters["口座No"].Direction = ParameterDirection.Input;
                cmd.Parameters["口座No"].Value = 口座No;

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

        public static DataTable SelectTransaction(SqlConnection cn, int 口座No, DateTime 開始日時, DateTime 終了日時)
        {
            try
            {
                cmd = new SqlCommand("oanda.spSelectTransaction", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = DB定数.CommandTimeout;

                cmd.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
                cmd.Parameters["口座No"].Direction = ParameterDirection.Input;
                cmd.Parameters["口座No"].Value = 口座No;

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

        public static DataTable spSelectTransaction_interestマイナス(SqlConnection cn, int 口座No, DateTime 開始日時, DateTime 終了日時)
        {
            try
            {
                cmd = new SqlCommand("oanda.spSelectTransaction_interestマイナス", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = DB定数.CommandTimeout;

                cmd.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
                cmd.Parameters["口座No"].Direction = ParameterDirection.Input;
                cmd.Parameters["口座No"].Value = 口座No;

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

        public static DataTable SelectAccount_MinMax(SqlConnection cn, int 口座No, DateTime 開始日時, DateTime 終了日時)
        {
            try
            {
                cmd = new SqlCommand("oanda.spSelectAccount_MinMax", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = DB定数.CommandTimeout;

                cmd.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
                cmd.Parameters["口座No"].Direction = ParameterDirection.Input;
                cmd.Parameters["口座No"].Value = 口座No;

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

        public static DataTable SelectAccount(SqlConnection cn, int 口座No, DateTime 開始日時, DateTime 終了日時)
        {
            try
            {
                cmd = new SqlCommand("oanda.spSelectAccount", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = DB定数.CommandTimeout;

                cmd.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
                cmd.Parameters["口座No"].Direction = ParameterDirection.Input;
                cmd.Parameters["口座No"].Value = 口座No;

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
