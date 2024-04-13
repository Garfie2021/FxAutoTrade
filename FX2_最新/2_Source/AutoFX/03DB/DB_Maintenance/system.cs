using System;
using System.Data;
using System.Data.SqlClient;
using 定数;
using 共通Data;

namespace DB_Maintenance
{
    public static class system
    {
        private static SqlCommand cmd;

        public static DataTable ExecSql(SqlConnection cn, string sql)
        {
            try
            {
                cmd = new SqlCommand("system.spExecSql", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = DB定数.CommandTimeout;

                cmd.Parameters.Add(new SqlParameter("sql", SqlDbType.VarChar));
                cmd.Parameters["sql"].Direction = ParameterDirection.Input;
                cmd.Parameters["sql"].Value = sql;

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
                ログ.ログ書き出し("cn.ConnectionString : " + cn.ConnectionString);
                throw;
            }
        }

        public static DataTable Selectテーブル一覧(SqlConnection cn)
        {
            try
            {
                cmd = new SqlCommand("system.spSelectテーブル一覧", cn);
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
                ログ.ログ書き出し("cn.ConnectionString : " + cn.ConnectionString);
                throw;
            }
        }

        public static DataTable SelectDB統計(SqlConnection cn)
        {
            try
            {
                cmd = new SqlCommand("system.spSelectDB統計", cn);
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
                ログ.ログ書き出し("cn.ConnectionString : " + cn.ConnectionString);
                throw;
            }
        }

    }
}
