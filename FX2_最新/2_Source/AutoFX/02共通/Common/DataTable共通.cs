using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using 定数;
using 共通Data;
using Common;


namespace Common
{
    public static class DataTable共通
    {
        public static string DataTable_ToText(DataTable dt)
        {
            string result = "";

            foreach (DataColumn clm in dt.Columns)
            {
                result += clm.ColumnName + "\t";
            }

            result += "\r\n";

            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn clm in dt.Columns)
                {
                    result += row[clm.ColumnName] + "\t";
                }

                result += "\r\n";
            }

            if (dt.Rows.Count < 1)
            {
                result += "データ無し\r\n";
            }

            return result + "\r\n";
        }
    }
}
