using System.Data;
using System.Data.SqlClient;
using 定数;

namespace DB_Maintenance
{
    public static class recu
    {
        private static SqlCommand cmd;

        public static void Min1再計算(SqlConnection cn)
        {
            cmd = new SqlCommand("recu.spUpdateWMA再計算ALL_Min1", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            cmd.ExecuteNonQuery();
        }

        public static void Min5再計算(SqlConnection cn)
        {
            cmd = new SqlCommand("recu.spInsertHistory再計算ALL_Min5", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("recu.spUpdateWMA再計算ALL_Min5", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            cmd.ExecuteNonQuery();
        }

        public static void Min15再計算(SqlConnection cn)
        {
            cmd = new SqlCommand("recu.spInsertHistory再計算ALL_Min15", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("recu.spUpdateWMA再計算ALL_Min15", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            cmd.ExecuteNonQuery();
        }

        public static void Hour1再計算(SqlConnection cn)
        {
            cmd = new SqlCommand("recu.spInsertHistory再計算ALL_Hour1", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("recu.spUpdateWMA再計算ALL_Hour1", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            cmd.ExecuteNonQuery();
        }

        public static void Day1再計算(SqlConnection cn)
        {
            cmd = new SqlCommand("recu.spInsertHistory再計算ALL_Day1", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("recu.spUpdateWMA再計算ALL_Day1", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            cmd.ExecuteNonQuery();
        }

        public static void Week1再計算(SqlConnection cn)
        {
            cmd = new SqlCommand("recu.spInsertHistory再計算ALL_Week1", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("recu.spUpdateWMA再計算ALL_Week1", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            cmd.ExecuteNonQuery();
        }

        public static void Month1再計算(SqlConnection cn)
        {
            cmd = new SqlCommand("recu.spInsertHistory再計算ALL_Month1", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("recu.spUpdateWMA再計算ALL_Month1", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            cmd.ExecuteNonQuery();
        }

    }
}
