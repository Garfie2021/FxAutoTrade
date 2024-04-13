using System;
using System.Data;
using System.Data.SqlClient;
using 定数;
using 共通Data;

namespace DB_Maintenance
{
    public static class oder
    {
        private static SqlCommand cmd;

        public static DataTable SelectOrderHistory(SqlConnection cn, int 口座No, DateTime 開始日時, DateTime 終了日時)
        {
            try
            {
                cmd = new SqlCommand("oder.spSelectOrderHistory2", cn);
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

        public static DataTable SelectOrderHistory2_注文単位(SqlConnection cn, int 口座No, DateTime 開始日時, DateTime 終了日時)
        {
            try
            {
                cmd = new SqlCommand("oder.spSelectOrderHistory2_注文単位", cn);
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
