using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using 定数;
using 共通Data;

namespace DB
{
    public static class BulkCopyRateSec
    {
        private static DataTable RateSec;

        static BulkCopyRateSec()
        {
            RateSec = new DataTable("hstr.tSec");
            RateSec.Columns.Add(new DataColumn("通貨ペアNo", typeof(byte)));   // 列1
            RateSec.Columns.Add(new DataColumn("StartDate", typeof(DateTime)));   // 列2
            RateSec.Columns.Add(new DataColumn("買いSwap", typeof(double)));     // 列3
            RateSec.Columns.Add(new DataColumn("買いRate", typeof(double)));     // 列5
            RateSec.Columns.Add(new DataColumn("売りSwap", typeof(double)));     // 列4
            RateSec.Columns.Add(new DataColumn("売りRate", typeof(double)));     // 列6
        }

        public static void RateSecInitialize()
        {
            RateSec.Clear();
        }

        public static void InsertRateSec(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            RateSec.Rows.Add(通貨ぺア取引状況.通貨ペアNo, OrderData.now, 通貨ぺア取引状況.買いSwap, 通貨ぺア取引状況.買いRate, 通貨ぺア取引状況.売りSwap, 通貨ぺア取引状況.売りRate);
        }

        public static void RateSecFlush()
        {
            using (SqlBulkCopy bulkcopy = new SqlBulkCopy(FormData.DBConnectionString))
            {
                bulkcopy.DestinationTableName = "hstr.tSec";
                //bulkcopy.BulkCopyTimeout = 600;
                bulkcopy.WriteToServer(RateSec);
            }
        }



    }
}
