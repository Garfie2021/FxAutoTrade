using System.Data;
using System.Data.SqlClient;
using 定数;

namespace DB_FXCM
{
    public static class exp
    {
        private static SqlCommand cmd_ExeportRateHistory_fromFXCM;

        public static void SqlCommandInitialize(SqlConnection cn)
        {
            cmd_ExeportRateHistory_fromFXCM = new SqlCommand("exp.spExeportRateHistory_fromFXCM", cn);
            cmd_ExeportRateHistory_fromFXCM.CommandType = CommandType.StoredProcedure;
            //cmd_ExeportRateHistory_fromFXCM.CommandTimeout = DB定数.CommandTimeout;
            cmd_ExeportRateHistory_fromFXCM.Parameters.Add(new SqlParameter("ExportDbName", SqlDbType.VarChar));
            cmd_ExeportRateHistory_fromFXCM.Parameters["ExportDbName"].Direction = ParameterDirection.Input;
            cmd_ExeportRateHistory_fromFXCM.Parameters.Add(new SqlParameter("TargetTblName", SqlDbType.VarChar));
            cmd_ExeportRateHistory_fromFXCM.Parameters["TargetTblName"].Direction = ParameterDirection.Input;

        }

        public static void ExeportRateHistory_fromFXCM(string ExportDbName, string TargetTblName)
        {
            cmd_ExeportRateHistory_fromFXCM.Parameters["ExportDbName"].Value = ExportDbName;
            cmd_ExeportRateHistory_fromFXCM.Parameters["TargetTblName"].Value = TargetTblName;

            cmd_ExeportRateHistory_fromFXCM.ExecuteNonQuery();
        }

    }
}
