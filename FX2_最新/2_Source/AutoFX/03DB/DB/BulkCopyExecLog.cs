using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 定数;
using 共通Data;

namespace DB
{
    public static class BulkCopyExecLog
    {
        public static DataTable ExecLog;

        static BulkCopyExecLog()
        {
            ExecLog = new DataTable("pfmc.tExecLog");
            ExecLog.Columns.Add(new DataColumn("口座No", typeof(int)));          // 列1
            ExecLog.Columns.Add(new DataColumn("ExecDate", typeof(DateTime)));   // 列2
            ExecLog.Columns.Add(new DataColumn("処理区分", typeof(string)));     // 列3
            ExecLog.Columns.Add(new DataColumn("通貨ペアNo", typeof(byte)));     // 列4
            ExecLog.Columns.Add(new DataColumn("処理名", typeof(string)));       // 列5
            ExecLog.Columns.Add(new DataColumn("取引状況", typeof(string)));     // 列6
            ExecLog.Columns.Add(new DataColumn("Order開始日時", typeof(DateTime)));   // 列7
        }

        public static void InsertExecLog(string 処理区分, string 処理名, byte? 通貨ペアNo, string 取引状況, DateTime? Order開始日時)
        {
            ExecLog.Rows.Add(FormData.口座No, DateTime.Now, 処理区分, 通貨ペアNo, 処理名, 取引状況, Order開始日時);
        }

        public static void ExecLogFlush()
        {
            using (SqlBulkCopy bulkcopy = new SqlBulkCopy(FormData.DBConnectionString))
            {
                bulkcopy.DestinationTableName = "pfmc.tExecLog";
                //bulkcopy.BulkCopyTimeout = 600;
                bulkcopy.WriteToServer(ExecLog);
            }

            ExecLog.Clear();
        }

    }
}
