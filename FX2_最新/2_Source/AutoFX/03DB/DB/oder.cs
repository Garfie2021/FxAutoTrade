using System;
using System.Data;
using System.Data.SqlClient;
using 定数;
using 共通Data;
//using Common;

namespace DB
{
    public static class oder
    {
        //public static string LogPath;

        private static SqlCommand cmd_Cnt当日注文数;
        private static SqlCommand cmd_Chkデータ不足判定;
        private static SqlCommand cmd_Chkボーナスステージ_15m;
        private static SqlCommand cmd_Chk当日にOrder有り;
        private static SqlCommand cmd_Get売買判定_Month1;
        private static SqlCommand cmd_Get売買判定_Week1;
        private static SqlCommand cmd_Get売買判定_Day1;
        private static SqlCommand cmd_Get売買判定_Hour1;
        private static SqlCommand cmd_Get売買判定_Min15;
        private static SqlCommand cmd_Get売買判定_Min5;
        private static SqlCommand cmd_Get売買判定_Min1;
        private static SqlCommand cmd_GetWMA_Month1;
        private static SqlCommand cmd_GetWMA_Week1;
        private static SqlCommand cmd_GetWMA_Day1;
        private static SqlCommand cmd_GetWMA_Hour1;
        private static SqlCommand cmd_GetWMA_Min15;
        private static SqlCommand cmd_GetWMA_Min5;
        private static SqlCommand cmd_GetWMA_Min1;
        private static SqlCommand cmd_Chk直近n分以内にボーナスステージ終了有り;
        private static SqlCommand cmd_UpdateOrderHistory_OrderId;
        private static SqlCommand cmd_UpdateOrderHistory_OANDA_Trade_ID;
        private static SqlCommand cmd_Insertリミット変更History;
        private static SqlCommand cmd_InsertOrderHistory2;
        private static SqlCommand cmd_InsertCloseHistory;
        
        public static void SqlCommandInitialize(SqlConnection cn)
        {
            cmd_Cnt当日注文数 = new SqlCommand("oder.spCnt当日注文数", cn);
            cmd_Cnt当日注文数.CommandType = CommandType.StoredProcedure;
            //cmd_Cnt当日注文数.CommandTimeout = DB定数.CommandTimeout;
            cmd_Cnt当日注文数.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_Cnt当日注文数.Parameters["口座No"].Direction = ParameterDirection.Input;
            cmd_Cnt当日注文数.Parameters.Add(new SqlParameter("from", SqlDbType.DateTime));
            cmd_Cnt当日注文数.Parameters["from"].Direction = ParameterDirection.Input;
            cmd_Cnt当日注文数.Parameters.Add(new SqlParameter("Cnt", SqlDbType.Int));
            cmd_Cnt当日注文数.Parameters["Cnt"].Direction = ParameterDirection.Output;

            cmd_Chkデータ不足判定 = new SqlCommand("oder.spChkデータ不足判定", cn);
            cmd_Chkデータ不足判定.CommandType = CommandType.StoredProcedure;
            //cmd_Chkデータ不足判定.CommandTimeout = DB定数.CommandTimeout;
            cmd_Chkデータ不足判定.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_Chkデータ不足判定.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_Chkデータ不足判定.Parameters.Add(new SqlParameter("DiffWeek_Min15", SqlDbType.Int));
            cmd_Chkデータ不足判定.Parameters["DiffWeek_Min15"].Direction = ParameterDirection.Output;
            cmd_Chkデータ不足判定.Parameters.Add(new SqlParameter("DiffWeek_Week1", SqlDbType.Int));
            cmd_Chkデータ不足判定.Parameters["DiffWeek_Week1"].Direction = ParameterDirection.Output;
            cmd_Chkデータ不足判定.Parameters.Add(new SqlParameter("DiffMonth_Month1", SqlDbType.Int));
            cmd_Chkデータ不足判定.Parameters["DiffMonth_Month1"].Direction = ParameterDirection.Output;

            cmd_Chkボーナスステージ_15m = new SqlCommand("oder.spChkボーナスステージ15m", cn);
            cmd_Chkボーナスステージ_15m.CommandType = CommandType.StoredProcedure;
            //cmd_Chkボーナスステージ_15m.CommandTimeout = DB定数.CommandTimeout;
            cmd_Chkボーナスステージ_15m.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_Chkボーナスステージ_15m.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_Chkボーナスステージ_15m.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_Chkボーナスステージ_15m.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_Chkボーナスステージ_15m.Parameters.Add(new SqlParameter("シグマ閾値", SqlDbType.Float));
            cmd_Chkボーナスステージ_15m.Parameters["シグマ閾値"].Direction = ParameterDirection.Input;
            cmd_Chkボーナスステージ_15m.Parameters.Add(new SqlParameter("買いWMAs14", SqlDbType.Float));
            cmd_Chkボーナスステージ_15m.Parameters["買いWMAs14"].Direction = ParameterDirection.Output;
            cmd_Chkボーナスステージ_15m.Parameters.Add(new SqlParameter("買いWMAs14上昇角度シグマ", SqlDbType.Float));
            cmd_Chkボーナスステージ_15m.Parameters["買いWMAs14上昇角度シグマ"].Direction = ParameterDirection.Output;
            cmd_Chkボーナスステージ_15m.Parameters.Add(new SqlParameter("売りWMAs14", SqlDbType.Float));
            cmd_Chkボーナスステージ_15m.Parameters["売りWMAs14"].Direction = ParameterDirection.Output;
            cmd_Chkボーナスステージ_15m.Parameters.Add(new SqlParameter("売りWMAs14上昇角度シグマ", SqlDbType.Float));
            cmd_Chkボーナスステージ_15m.Parameters["売りWMAs14上昇角度シグマ"].Direction = ParameterDirection.Output;
            cmd_Chkボーナスステージ_15m.Parameters.Add(new SqlParameter("WMA判定", SqlDbType.VarChar, 1));
            cmd_Chkボーナスステージ_15m.Parameters["WMA判定"].Direction = ParameterDirection.Output;
            cmd_Chkボーナスステージ_15m.Parameters.Add(new SqlParameter("BS判定", SqlDbType.VarChar, 1));
            cmd_Chkボーナスステージ_15m.Parameters["BS判定"].Direction = ParameterDirection.Output;

            cmd_Chk当日にOrder有り = new SqlCommand("oder.spChkNearestOrder", cn);
            cmd_Chk当日にOrder有り.CommandType = CommandType.StoredProcedure;
            //cmd_Chk当日にOrder有り.CommandTimeout = DB定数.CommandTimeout;
            cmd_Chk当日にOrder有り.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_Chk当日にOrder有り.Parameters["口座No"].Direction = ParameterDirection.Input;
            cmd_Chk当日にOrder有り.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_Chk当日にOrder有り.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_Chk当日にOrder有り.Parameters.Add(new SqlParameter("NearestTime", SqlDbType.DateTime));
            cmd_Chk当日にOrder有り.Parameters["NearestTime"].Direction = ParameterDirection.Input;
            cmd_Chk当日にOrder有り.Parameters.Add(new SqlParameter("Order数", SqlDbType.Int));
            cmd_Chk当日にOrder有り.Parameters["Order数"].Direction = ParameterDirection.Output;

            cmd_Get売買判定_Month1 = new SqlCommand("oder.spGet売買判定2_Month1", cn);
            cmd_Get売買判定_Month1.CommandType = CommandType.StoredProcedure;
            //cmd_Get売買判定_Month1.CommandTimeout = DB定数.CommandTimeout;
            cmd_Get売買判定_Month1.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_Get売買判定_Month1.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_Get売買判定_Month1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_Get売買判定_Month1.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_Get売買判定_Month1.Parameters.Add(new SqlParameter("買いWMAs2", SqlDbType.Float));
            cmd_Get売買判定_Month1.Parameters["買いWMAs2"].Direction = ParameterDirection.Output;
            cmd_Get売買判定_Month1.Parameters.Add(new SqlParameter("買いWMAs14", SqlDbType.Float));
            cmd_Get売買判定_Month1.Parameters["買いWMAs14"].Direction = ParameterDirection.Output;
            cmd_Get売買判定_Month1.Parameters.Add(new SqlParameter("売りWMAs2", SqlDbType.Float));
            cmd_Get売買判定_Month1.Parameters["売りWMAs2"].Direction = ParameterDirection.Output;
            cmd_Get売買判定_Month1.Parameters.Add(new SqlParameter("売りWMAs14", SqlDbType.Float));
            cmd_Get売買判定_Month1.Parameters["売りWMAs14"].Direction = ParameterDirection.Output;
            cmd_Get売買判定_Month1.Parameters.Add(new SqlParameter("売買判定", SqlDbType.VarChar, 1));
            cmd_Get売買判定_Month1.Parameters["売買判定"].Direction = ParameterDirection.Output;

            cmd_Get売買判定_Week1 = new SqlCommand("oder.spGet売買判定2_Week1", cn);
            cmd_Get売買判定_Week1.CommandType = CommandType.StoredProcedure;
            //cmd_Get売買判定_Week1.CommandTimeout = DB定数.CommandTimeout;
            cmd_Get売買判定_Week1.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_Get売買判定_Week1.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_Get売買判定_Week1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.TinyInt));
            cmd_Get売買判定_Week1.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_Get売買判定_Week1.Parameters.Add(new SqlParameter("買いWMAs2", SqlDbType.Float));
            cmd_Get売買判定_Week1.Parameters["買いWMAs2"].Direction = ParameterDirection.Output;
            cmd_Get売買判定_Week1.Parameters.Add(new SqlParameter("買いWMAs14", SqlDbType.Float));
            cmd_Get売買判定_Week1.Parameters["買いWMAs14"].Direction = ParameterDirection.Output;
            cmd_Get売買判定_Week1.Parameters.Add(new SqlParameter("売りWMAs2", SqlDbType.Float));
            cmd_Get売買判定_Week1.Parameters["売りWMAs2"].Direction = ParameterDirection.Output;
            cmd_Get売買判定_Week1.Parameters.Add(new SqlParameter("売りWMAs14", SqlDbType.Float));
            cmd_Get売買判定_Week1.Parameters["売りWMAs14"].Direction = ParameterDirection.Output;
            cmd_Get売買判定_Week1.Parameters.Add(new SqlParameter("売買判定", SqlDbType.VarChar, 1));
            cmd_Get売買判定_Week1.Parameters["売買判定"].Direction = ParameterDirection.Output;

            cmd_Get売買判定_Day1 = new SqlCommand("oder.spGet売買判定2_Day1", cn);
            cmd_Get売買判定_Day1.CommandType = CommandType.StoredProcedure;
            //cmd_Get売買判定_Day1.CommandTimeout = DB定数.CommandTimeout;
            cmd_Get売買判定_Day1.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_Get売買判定_Day1.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_Get売買判定_Day1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.TinyInt));
            cmd_Get売買判定_Day1.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_Get売買判定_Day1.Parameters.Add(new SqlParameter("買いWMAs2", SqlDbType.Float));
            cmd_Get売買判定_Day1.Parameters["買いWMAs2"].Direction = ParameterDirection.Output;
            cmd_Get売買判定_Day1.Parameters.Add(new SqlParameter("買いWMAs14", SqlDbType.Float));
            cmd_Get売買判定_Day1.Parameters["買いWMAs14"].Direction = ParameterDirection.Output;
            cmd_Get売買判定_Day1.Parameters.Add(new SqlParameter("売りWMAs2", SqlDbType.Float));
            cmd_Get売買判定_Day1.Parameters["売りWMAs2"].Direction = ParameterDirection.Output;
            cmd_Get売買判定_Day1.Parameters.Add(new SqlParameter("売りWMAs14", SqlDbType.Float));
            cmd_Get売買判定_Day1.Parameters["売りWMAs14"].Direction = ParameterDirection.Output;
            cmd_Get売買判定_Day1.Parameters.Add(new SqlParameter("売買判定", SqlDbType.VarChar, 1));
            cmd_Get売買判定_Day1.Parameters["売買判定"].Direction = ParameterDirection.Output;

            cmd_Get売買判定_Hour1 = new SqlCommand("oder.spGet売買判定2_Hour1", cn);
            cmd_Get売買判定_Hour1.CommandType = CommandType.StoredProcedure;
            //cmd_Get売買判定_Hour1.CommandTimeout = DB定数.CommandTimeout;
            cmd_Get売買判定_Hour1.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_Get売買判定_Hour1.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_Get売買判定_Hour1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.TinyInt));
            cmd_Get売買判定_Hour1.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_Get売買判定_Hour1.Parameters.Add(new SqlParameter("買いWMAs2", SqlDbType.Float));
            cmd_Get売買判定_Hour1.Parameters["買いWMAs2"].Direction = ParameterDirection.Output;
            cmd_Get売買判定_Hour1.Parameters.Add(new SqlParameter("買いWMAs14", SqlDbType.Float));
            cmd_Get売買判定_Hour1.Parameters["買いWMAs14"].Direction = ParameterDirection.Output;
            cmd_Get売買判定_Hour1.Parameters.Add(new SqlParameter("売りWMAs2", SqlDbType.Float));
            cmd_Get売買判定_Hour1.Parameters["売りWMAs2"].Direction = ParameterDirection.Output;
            cmd_Get売買判定_Hour1.Parameters.Add(new SqlParameter("売りWMAs14", SqlDbType.Float));
            cmd_Get売買判定_Hour1.Parameters["売りWMAs14"].Direction = ParameterDirection.Output;
            cmd_Get売買判定_Hour1.Parameters.Add(new SqlParameter("売買判定", SqlDbType.VarChar, 1));
            cmd_Get売買判定_Hour1.Parameters["売買判定"].Direction = ParameterDirection.Output;

            cmd_Get売買判定_Min15 = new SqlCommand("oder.spGet売買判定2_Min15", cn);
            cmd_Get売買判定_Min15.CommandType = CommandType.StoredProcedure;
            //cmd_Get売買判定_Min15.CommandTimeout = DB定数.CommandTimeout;
            cmd_Get売買判定_Min15.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_Get売買判定_Min15.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_Get売買判定_Min15.Parameters.Add(new SqlParameter("StartDate", SqlDbType.TinyInt));
            cmd_Get売買判定_Min15.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_Get売買判定_Min15.Parameters.Add(new SqlParameter("買いWMAs2", SqlDbType.Float));
            cmd_Get売買判定_Min15.Parameters["買いWMAs2"].Direction = ParameterDirection.Output;
            cmd_Get売買判定_Min15.Parameters.Add(new SqlParameter("買いWMAs14", SqlDbType.Float));
            cmd_Get売買判定_Min15.Parameters["買いWMAs14"].Direction = ParameterDirection.Output;
            cmd_Get売買判定_Min15.Parameters.Add(new SqlParameter("売りWMAs2", SqlDbType.Float));
            cmd_Get売買判定_Min15.Parameters["売りWMAs2"].Direction = ParameterDirection.Output;
            cmd_Get売買判定_Min15.Parameters.Add(new SqlParameter("売りWMAs14", SqlDbType.Float));
            cmd_Get売買判定_Min15.Parameters["売りWMAs14"].Direction = ParameterDirection.Output;
            cmd_Get売買判定_Min15.Parameters.Add(new SqlParameter("売買判定", SqlDbType.VarChar, 1));
            cmd_Get売買判定_Min15.Parameters["売買判定"].Direction = ParameterDirection.Output;

            cmd_Get売買判定_Min5 = new SqlCommand("oder.spGet売買判定2_Min5", cn);
            cmd_Get売買判定_Min5.CommandType = CommandType.StoredProcedure;
            //cmd_Get売買判定_Min5.CommandTimeout = DB定数.CommandTimeout;
            cmd_Get売買判定_Min5.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_Get売買判定_Min5.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_Get売買判定_Min5.Parameters.Add(new SqlParameter("StartDate", SqlDbType.TinyInt));
            cmd_Get売買判定_Min5.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_Get売買判定_Min5.Parameters.Add(new SqlParameter("買いWMAs2", SqlDbType.Float));
            cmd_Get売買判定_Min5.Parameters["買いWMAs2"].Direction = ParameterDirection.Output;
            cmd_Get売買判定_Min5.Parameters.Add(new SqlParameter("買いWMAs14", SqlDbType.Float));
            cmd_Get売買判定_Min5.Parameters["買いWMAs14"].Direction = ParameterDirection.Output;
            cmd_Get売買判定_Min5.Parameters.Add(new SqlParameter("売りWMAs2", SqlDbType.Float));
            cmd_Get売買判定_Min5.Parameters["売りWMAs2"].Direction = ParameterDirection.Output;
            cmd_Get売買判定_Min5.Parameters.Add(new SqlParameter("売りWMAs14", SqlDbType.Float));
            cmd_Get売買判定_Min5.Parameters["売りWMAs14"].Direction = ParameterDirection.Output;
            cmd_Get売買判定_Min5.Parameters.Add(new SqlParameter("売買判定", SqlDbType.VarChar, 1));
            cmd_Get売買判定_Min5.Parameters["売買判定"].Direction = ParameterDirection.Output;

            cmd_Get売買判定_Min1 = new SqlCommand("oder.spGet売買判定2_Min1", cn);
            cmd_Get売買判定_Min1.CommandType = CommandType.StoredProcedure;
            //cmd_Get売買判定_Min1.CommandTimeout = DB定数.CommandTimeout;
            cmd_Get売買判定_Min1.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_Get売買判定_Min1.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_Get売買判定_Min1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.TinyInt));
            cmd_Get売買判定_Min1.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_Get売買判定_Min1.Parameters.Add(new SqlParameter("買いWMAs2", SqlDbType.Float));
            cmd_Get売買判定_Min1.Parameters["買いWMAs2"].Direction = ParameterDirection.Output;
            cmd_Get売買判定_Min1.Parameters.Add(new SqlParameter("買いWMAs14", SqlDbType.Float));
            cmd_Get売買判定_Min1.Parameters["買いWMAs14"].Direction = ParameterDirection.Output;
            cmd_Get売買判定_Min1.Parameters.Add(new SqlParameter("売りWMAs2", SqlDbType.Float));
            cmd_Get売買判定_Min1.Parameters["売りWMAs2"].Direction = ParameterDirection.Output;
            cmd_Get売買判定_Min1.Parameters.Add(new SqlParameter("売りWMAs14", SqlDbType.Float));
            cmd_Get売買判定_Min1.Parameters["売りWMAs14"].Direction = ParameterDirection.Output;
            cmd_Get売買判定_Min1.Parameters.Add(new SqlParameter("売買判定", SqlDbType.VarChar, 1));
            cmd_Get売買判定_Min1.Parameters["売買判定"].Direction = ParameterDirection.Output;

            cmd_GetWMA_Month1 = new SqlCommand("oder.spGetWMA_Month1", cn);
            cmd_GetWMA_Month1.CommandType = CommandType.StoredProcedure;
            //cmd_GetWMA_Month1.CommandTimeout = DB定数.CommandTimeout;
            cmd_GetWMA_Month1.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_GetWMA_Month1.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_GetWMA_Month1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_GetWMA_Month1.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_GetWMA_Month1.Parameters.Add(new SqlParameter("買いWMAs2", SqlDbType.Float));
            cmd_GetWMA_Month1.Parameters["買いWMAs2"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Month1.Parameters.Add(new SqlParameter("買いWMAs2角度", SqlDbType.Float));
            cmd_GetWMA_Month1.Parameters["買いWMAs2角度"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Month1.Parameters.Add(new SqlParameter("買いWMAs14", SqlDbType.Float));
            cmd_GetWMA_Month1.Parameters["買いWMAs14"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Month1.Parameters.Add(new SqlParameter("売りWMAs2", SqlDbType.Float));
            cmd_GetWMA_Month1.Parameters["売りWMAs2"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Month1.Parameters.Add(new SqlParameter("売りWMAs2角度", SqlDbType.Float));
            cmd_GetWMA_Month1.Parameters["売りWMAs2角度"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Month1.Parameters.Add(new SqlParameter("売りWMAs14", SqlDbType.Float));
            cmd_GetWMA_Month1.Parameters["売りWMAs14"].Direction = ParameterDirection.Output;

            cmd_GetWMA_Week1 = new SqlCommand("oder.spGetWMA_Week1", cn);
            cmd_GetWMA_Week1.CommandType = CommandType.StoredProcedure;
            //cmd_GetWMA_Week1.CommandTimeout = DB定数.CommandTimeout;
            cmd_GetWMA_Week1.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_GetWMA_Week1.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_GetWMA_Week1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_GetWMA_Week1.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_GetWMA_Week1.Parameters.Add(new SqlParameter("買いWMAs2", SqlDbType.Float));
            cmd_GetWMA_Week1.Parameters["買いWMAs2"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Week1.Parameters.Add(new SqlParameter("買いWMAs2角度", SqlDbType.Float));
            cmd_GetWMA_Week1.Parameters["買いWMAs2角度"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Week1.Parameters.Add(new SqlParameter("買いWMAs14", SqlDbType.Float));
            cmd_GetWMA_Week1.Parameters["買いWMAs14"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Week1.Parameters.Add(new SqlParameter("売りWMAs2", SqlDbType.Float));
            cmd_GetWMA_Week1.Parameters["売りWMAs2"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Week1.Parameters.Add(new SqlParameter("売りWMAs2角度", SqlDbType.Float));
            cmd_GetWMA_Week1.Parameters["売りWMAs2角度"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Week1.Parameters.Add(new SqlParameter("売りWMAs14", SqlDbType.Float));
            cmd_GetWMA_Week1.Parameters["売りWMAs14"].Direction = ParameterDirection.Output;

            cmd_GetWMA_Day1 = new SqlCommand("oder.spGetWMA_Day1", cn);
            cmd_GetWMA_Day1.CommandType = CommandType.StoredProcedure;
            //cmd_GetWMA_Day1.CommandTimeout = DB定数.CommandTimeout;
            cmd_GetWMA_Day1.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_GetWMA_Day1.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_GetWMA_Day1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_GetWMA_Day1.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_GetWMA_Day1.Parameters.Add(new SqlParameter("買いWMAs2", SqlDbType.Float));
            cmd_GetWMA_Day1.Parameters["買いWMAs2"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Day1.Parameters.Add(new SqlParameter("買いWMAs2角度", SqlDbType.Float));
            cmd_GetWMA_Day1.Parameters["買いWMAs2角度"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Day1.Parameters.Add(new SqlParameter("買いWMAs14", SqlDbType.Float));
            cmd_GetWMA_Day1.Parameters["買いWMAs14"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Day1.Parameters.Add(new SqlParameter("売りWMAs2", SqlDbType.Float));
            cmd_GetWMA_Day1.Parameters["売りWMAs2"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Day1.Parameters.Add(new SqlParameter("売りWMAs2角度", SqlDbType.Float));
            cmd_GetWMA_Day1.Parameters["売りWMAs2角度"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Day1.Parameters.Add(new SqlParameter("売りWMAs14", SqlDbType.Float));
            cmd_GetWMA_Day1.Parameters["売りWMAs14"].Direction = ParameterDirection.Output;

            cmd_GetWMA_Hour1 = new SqlCommand("oder.spGetWMA_Hour1", cn);
            cmd_GetWMA_Hour1.CommandType = CommandType.StoredProcedure;
            //cmd_GetWMA_Hour1.CommandTimeout = DB定数.CommandTimeout;
            cmd_GetWMA_Hour1.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_GetWMA_Hour1.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_GetWMA_Hour1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_GetWMA_Hour1.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_GetWMA_Hour1.Parameters.Add(new SqlParameter("買いWMAs2", SqlDbType.Float));
            cmd_GetWMA_Hour1.Parameters["買いWMAs2"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Hour1.Parameters.Add(new SqlParameter("買いWMAs2角度", SqlDbType.Float));
            cmd_GetWMA_Hour1.Parameters["買いWMAs2角度"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Hour1.Parameters.Add(new SqlParameter("買いWMAs14", SqlDbType.Float));
            cmd_GetWMA_Hour1.Parameters["買いWMAs14"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Hour1.Parameters.Add(new SqlParameter("売りWMAs2", SqlDbType.Float));
            cmd_GetWMA_Hour1.Parameters["売りWMAs2"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Hour1.Parameters.Add(new SqlParameter("売りWMAs2角度", SqlDbType.Float));
            cmd_GetWMA_Hour1.Parameters["売りWMAs2角度"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Hour1.Parameters.Add(new SqlParameter("売りWMAs14", SqlDbType.Float));
            cmd_GetWMA_Hour1.Parameters["売りWMAs14"].Direction = ParameterDirection.Output;

            cmd_GetWMA_Min15 = new SqlCommand("oder.spGetWMA_Min15", cn);
            cmd_GetWMA_Min15.CommandType = CommandType.StoredProcedure;
            //cmd_GetWMA_Min15.CommandTimeout = DB定数.CommandTimeout;
            cmd_GetWMA_Min15.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_GetWMA_Min15.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_GetWMA_Min15.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_GetWMA_Min15.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_GetWMA_Min15.Parameters.Add(new SqlParameter("買いWMAs2", SqlDbType.Float));
            cmd_GetWMA_Min15.Parameters["買いWMAs2"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Min15.Parameters.Add(new SqlParameter("買いWMAs2角度", SqlDbType.Float));
            cmd_GetWMA_Min15.Parameters["買いWMAs2角度"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Min15.Parameters.Add(new SqlParameter("買いWMAs14", SqlDbType.Float));
            cmd_GetWMA_Min15.Parameters["買いWMAs14"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Min15.Parameters.Add(new SqlParameter("売りWMAs2", SqlDbType.Float));
            cmd_GetWMA_Min15.Parameters["売りWMAs2"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Min15.Parameters.Add(new SqlParameter("売りWMAs2角度", SqlDbType.Float));
            cmd_GetWMA_Min15.Parameters["売りWMAs2角度"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Min15.Parameters.Add(new SqlParameter("売りWMAs14", SqlDbType.Float));
            cmd_GetWMA_Min15.Parameters["売りWMAs14"].Direction = ParameterDirection.Output;

            cmd_GetWMA_Min5 = new SqlCommand("oder.spGetWMA_Min5", cn);
            cmd_GetWMA_Min5.CommandType = CommandType.StoredProcedure;
            //cmd_GetWMA_Min5.CommandTimeout = DB定数.CommandTimeout;
            cmd_GetWMA_Min5.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_GetWMA_Min5.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_GetWMA_Min5.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_GetWMA_Min5.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_GetWMA_Min5.Parameters.Add(new SqlParameter("買いWMAs2", SqlDbType.Float));
            cmd_GetWMA_Min5.Parameters["買いWMAs2"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Min5.Parameters.Add(new SqlParameter("買いWMAs2角度", SqlDbType.Float));
            cmd_GetWMA_Min5.Parameters["買いWMAs2角度"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Min5.Parameters.Add(new SqlParameter("買いWMAs14", SqlDbType.Float));
            cmd_GetWMA_Min5.Parameters["買いWMAs14"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Min5.Parameters.Add(new SqlParameter("売りWMAs2", SqlDbType.Float));
            cmd_GetWMA_Min5.Parameters["売りWMAs2"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Min5.Parameters.Add(new SqlParameter("売りWMAs2角度", SqlDbType.Float));
            cmd_GetWMA_Min5.Parameters["売りWMAs2角度"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Min5.Parameters.Add(new SqlParameter("売りWMAs14", SqlDbType.Float));
            cmd_GetWMA_Min5.Parameters["売りWMAs14"].Direction = ParameterDirection.Output;

            cmd_GetWMA_Min1 = new SqlCommand("oder.spGetWMA_Min1", cn);
            cmd_GetWMA_Min1.CommandType = CommandType.StoredProcedure;
            //cmd_GetWMA_Min1.CommandTimeout = DB定数.CommandTimeout;
            cmd_GetWMA_Min1.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_GetWMA_Min1.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_GetWMA_Min1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_GetWMA_Min1.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_GetWMA_Min1.Parameters.Add(new SqlParameter("買いWMAs2", SqlDbType.Float));
            cmd_GetWMA_Min1.Parameters["買いWMAs2"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Min1.Parameters.Add(new SqlParameter("買いWMAs2角度", SqlDbType.Float));
            cmd_GetWMA_Min1.Parameters["買いWMAs2角度"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Min1.Parameters.Add(new SqlParameter("買いWMAs14", SqlDbType.Float));
            cmd_GetWMA_Min1.Parameters["買いWMAs14"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Min1.Parameters.Add(new SqlParameter("売りWMAs2", SqlDbType.Float));
            cmd_GetWMA_Min1.Parameters["売りWMAs2"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Min1.Parameters.Add(new SqlParameter("売りWMAs2角度", SqlDbType.Float));
            cmd_GetWMA_Min1.Parameters["売りWMAs2角度"].Direction = ParameterDirection.Output;
            cmd_GetWMA_Min1.Parameters.Add(new SqlParameter("売りWMAs14", SqlDbType.Float));
            cmd_GetWMA_Min1.Parameters["売りWMAs14"].Direction = ParameterDirection.Output;

            cmd_Chk直近n分以内にボーナスステージ終了有り = new SqlCommand("oder.spChk直近n分以内にボーナスステージ終了有り", cn);
            cmd_Chk直近n分以内にボーナスステージ終了有り.CommandType = CommandType.StoredProcedure;
            //cmd_Chk直近n分以内にボーナスステージ終了有り.CommandTimeout = DB定数.CommandTimeout;
            cmd_Chk直近n分以内にボーナスステージ終了有り.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_Chk直近n分以内にボーナスステージ終了有り.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_Chk直近n分以内にボーナスステージ終了有り.Parameters.Add(new SqlParameter("n分前", SqlDbType.DateTime));
            cmd_Chk直近n分以内にボーナスステージ終了有り.Parameters["n分前"].Direction = ParameterDirection.Input;
            cmd_Chk直近n分以内にボーナスステージ終了有り.Parameters.Add(new SqlParameter("判定", SqlDbType.TinyInt));
            cmd_Chk直近n分以内にボーナスステージ終了有り.Parameters["判定"].Direction = ParameterDirection.Output;

            cmd_UpdateOrderHistory_OrderId = new SqlCommand("oder.spUpdateOrderHistory_OrderId", cn);
            cmd_UpdateOrderHistory_OrderId.CommandType = CommandType.StoredProcedure;
            //cmd_UpdateOrderHistory_OrderId.CommandTimeout = DB定数.CommandTimeout;
            cmd_UpdateOrderHistory_OrderId.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_UpdateOrderHistory_OrderId.Parameters["口座No"].Direction = ParameterDirection.Input;
            cmd_UpdateOrderHistory_OrderId.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_UpdateOrderHistory_OrderId.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_UpdateOrderHistory_OrderId.Parameters.Add(new SqlParameter("日時", SqlDbType.DateTime));
            cmd_UpdateOrderHistory_OrderId.Parameters["日時"].Direction = ParameterDirection.Input;
            cmd_UpdateOrderHistory_OrderId.Parameters.Add(new SqlParameter("OpenOrderID", SqlDbType.VarChar));
            cmd_UpdateOrderHistory_OrderId.Parameters["OpenOrderID"].Direction = ParameterDirection.Input;

            cmd_UpdateOrderHistory_OANDA_Trade_ID = new SqlCommand("oder.spUpdateOrderHistory_OANDA_Trade_ID", cn);
            cmd_UpdateOrderHistory_OANDA_Trade_ID.CommandType = CommandType.StoredProcedure;
            //cmd_UpdateOrderHistory_OANDA_Trade_ID.CommandTimeout = DB定数.CommandTimeout;
            cmd_UpdateOrderHistory_OANDA_Trade_ID.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_UpdateOrderHistory_OANDA_Trade_ID.Parameters["口座No"].Direction = ParameterDirection.Input;
            cmd_UpdateOrderHistory_OANDA_Trade_ID.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_UpdateOrderHistory_OANDA_Trade_ID.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_UpdateOrderHistory_OANDA_Trade_ID.Parameters.Add(new SqlParameter("日時", SqlDbType.DateTime));
            cmd_UpdateOrderHistory_OANDA_Trade_ID.Parameters["日時"].Direction = ParameterDirection.Input;
            cmd_UpdateOrderHistory_OANDA_Trade_ID.Parameters.Add(new SqlParameter("Oanda_TradeData_id", SqlDbType.BigInt));
            cmd_UpdateOrderHistory_OANDA_Trade_ID.Parameters["Oanda_TradeData_id"].Direction = ParameterDirection.Input;

            cmd_Insertリミット変更History = new SqlCommand("oder.spInsertリミット変更History", cn);
            cmd_Insertリミット変更History.CommandType = CommandType.StoredProcedure;
            //cmd_Insertリミット変更History.CommandTimeout = DB定数.CommandTimeout;
            cmd_Insertリミット変更History.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_Insertリミット変更History.Parameters["口座No"].Direction = ParameterDirection.Input;
            cmd_Insertリミット変更History.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_Insertリミット変更History.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_Insertリミット変更History.Parameters.Add(new SqlParameter("OANDA_Trade_Side", SqlDbType.VarChar));
            cmd_Insertリミット変更History.Parameters["OANDA_Trade_Side"].Direction = ParameterDirection.Input;
            cmd_Insertリミット変更History.Parameters.Add(new SqlParameter("OANDA_Trade_ID", SqlDbType.BigInt));
            cmd_Insertリミット変更History.Parameters["OANDA_Trade_ID"].Direction = ParameterDirection.Input;
            cmd_Insertリミット変更History.Parameters.Add(new SqlParameter("OANDA_Trade_Price", SqlDbType.Float));
            cmd_Insertリミット変更History.Parameters["OANDA_Trade_Price"].Direction = ParameterDirection.Input;
            cmd_Insertリミット変更History.Parameters.Add(new SqlParameter("OANDA_Trade_TakeProfit", SqlDbType.Float));
            cmd_Insertリミット変更History.Parameters["OANDA_Trade_TakeProfit"].Direction = ParameterDirection.Input;
            cmd_Insertリミット変更History.Parameters.Add(new SqlParameter("リミット", SqlDbType.VarChar));
            cmd_Insertリミット変更History.Parameters["リミット"].Direction = ParameterDirection.Input;
            cmd_Insertリミット変更History.Parameters.Add(new SqlParameter("差分リミット通常", SqlDbType.Float));
            cmd_Insertリミット変更History.Parameters["差分リミット通常"].Direction = ParameterDirection.Input;
            cmd_Insertリミット変更History.Parameters.Add(new SqlParameter("差分リミットBS", SqlDbType.Float));
            cmd_Insertリミット変更History.Parameters["差分リミットBS"].Direction = ParameterDirection.Input;
            cmd_Insertリミット変更History.Parameters.Add(new SqlParameter("買いSwap", SqlDbType.Float));
            cmd_Insertリミット変更History.Parameters["買いSwap"].Direction = ParameterDirection.Input;
            cmd_Insertリミット変更History.Parameters.Add(new SqlParameter("売りSwap", SqlDbType.Float));
            cmd_Insertリミット変更History.Parameters["売りSwap"].Direction = ParameterDirection.Input;
            cmd_Insertリミット変更History.Parameters.Add(new SqlParameter("Swap判定", SqlDbType.VarChar));
            cmd_Insertリミット変更History.Parameters["Swap判定"].Direction = ParameterDirection.Input;
            cmd_Insertリミット変更History.Parameters.Add(new SqlParameter("買いRate", SqlDbType.Float));
            cmd_Insertリミット変更History.Parameters["買いRate"].Direction = ParameterDirection.Input;
            cmd_Insertリミット変更History.Parameters.Add(new SqlParameter("売りRate", SqlDbType.Float));
            cmd_Insertリミット変更History.Parameters["売りRate"].Direction = ParameterDirection.Input;
            cmd_Insertリミット変更History.Parameters.Add(new SqlParameter("売買判定", SqlDbType.VarChar));
            cmd_Insertリミット変更History.Parameters["売買判定"].Direction = ParameterDirection.Input;
            cmd_Insertリミット変更History.Parameters.Add(new SqlParameter("売買", SqlDbType.Bit));
            cmd_Insertリミット変更History.Parameters["売買"].Direction = ParameterDirection.Input;
            cmd_Insertリミット変更History.Parameters.Add(new SqlParameter("保持ポジション", SqlDbType.VarChar));
            cmd_Insertリミット変更History.Parameters["保持ポジション"].Direction = ParameterDirection.Input;
            cmd_Insertリミット変更History.Parameters.Add(new SqlParameter("BS_WMA判定_15m", SqlDbType.VarChar));
            cmd_Insertリミット変更History.Parameters["BS_WMA判定_15m"].Direction = ParameterDirection.Input;
            cmd_Insertリミット変更History.Parameters.Add(new SqlParameter("BS判定_15m", SqlDbType.VarChar));
            cmd_Insertリミット変更History.Parameters["BS判定_15m"].Direction = ParameterDirection.Input;
            cmd_Insertリミット変更History.Parameters.Add(new SqlParameter("BS開始", SqlDbType.Bit));
            cmd_Insertリミット変更History.Parameters["BS開始"].Direction = ParameterDirection.Input;
            cmd_Insertリミット変更History.Parameters.Add(new SqlParameter("BS判定_前", SqlDbType.VarChar));
            cmd_Insertリミット変更History.Parameters["BS判定_前"].Direction = ParameterDirection.Input;
            cmd_Insertリミット変更History.Parameters.Add(new SqlParameter("BS判定_今", SqlDbType.VarChar));
            cmd_Insertリミット変更History.Parameters["BS判定_今"].Direction = ParameterDirection.Input;

            cmd_InsertOrderHistory2 = new SqlCommand("oder.spInsertOrderHistory2", cn);
            cmd_InsertOrderHistory2.CommandType = CommandType.StoredProcedure;
            //cmd_InsertOrderHistory2.CommandTimeout = DB定数.CommandTimeout;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_InsertOrderHistory2.Parameters["口座No"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_InsertOrderHistory2.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("日時", SqlDbType.DateTime));
            cmd_InsertOrderHistory2.Parameters["日時"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("買いSwap", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["買いSwap"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("売りSwap", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["売りSwap"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Swap判定", SqlDbType.VarChar));
            cmd_InsertOrderHistory2.Parameters["Swap判定"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("買いRate", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["買いRate"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("売りRate", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["売りRate"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("売買判定", SqlDbType.VarChar));
            cmd_InsertOrderHistory2.Parameters["売買判定"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("売買", SqlDbType.Bit));
            cmd_InsertOrderHistory2.Parameters["売買"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("保持ポジション", SqlDbType.VarChar));
            cmd_InsertOrderHistory2.Parameters["保持ポジション"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("BS_Min15_買いWMAs14", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["BS_Min15_買いWMAs14"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("BS_Min15_買いWMAs14角度", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["BS_Min15_買いWMAs14角度"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("BS_Min15_買いWMAs14角度シグマ", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["BS_Min15_買いWMAs14角度シグマ"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("BS_Min15_売りWMAs14", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["BS_Min15_売りWMAs14"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("BS_Min15_売りWMAs14角度", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["BS_Min15_売りWMAs14角度"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("BS_Min15_売りWMAs14角度シグマ", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["BS_Min15_売りWMAs14角度シグマ"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("BS_WMA判定_15m", SqlDbType.VarChar));
            cmd_InsertOrderHistory2.Parameters["BS_WMA判定_15m"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("BS判定_15m", SqlDbType.VarChar));
            cmd_InsertOrderHistory2.Parameters["BS判定_15m"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("BS開始", SqlDbType.Bit));
            cmd_InsertOrderHistory2.Parameters["BS開始"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("BS判定_前", SqlDbType.VarChar));
            cmd_InsertOrderHistory2.Parameters["BS判定_前"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("ポジション追加_成行_ストップ", SqlDbType.VarChar));
            cmd_InsertOrderHistory2.Parameters["ポジション追加_成行_ストップ"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("ポジション追加_成行_リミット", SqlDbType.VarChar));
            cmd_InsertOrderHistory2.Parameters["ポジション追加_成行_リミット"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("ポジション追加時のリミット", SqlDbType.VarChar));
            cmd_InsertOrderHistory2.Parameters["ポジション追加時のリミット"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("BS判定_今", SqlDbType.VarChar));
            cmd_InsertOrderHistory2.Parameters["BS判定_今"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("差分リミット通常", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["差分リミット通常"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("差分リミットBS", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["差分リミットBS"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("注文単位", SqlDbType.Int));
            cmd_InsertOrderHistory2.Parameters["注文単位"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("注文単位を割る値", SqlDbType.Int));
            cmd_InsertOrderHistory2.Parameters["注文単位を割る値"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("ロスカット余剰金", SqlDbType.Int));
            cmd_InsertOrderHistory2.Parameters["ロスカット余剰金"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("ロスカット余剰金調整値", SqlDbType.Int));
            cmd_InsertOrderHistory2.Parameters["ロスカット余剰金調整値"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("証拠金倍率", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["証拠金倍率"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Month1_Start", SqlDbType.DateTime));
            cmd_InsertOrderHistory2.Parameters["Month1_Start"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Month1_End", SqlDbType.DateTime));
            cmd_InsertOrderHistory2.Parameters["Month1_End"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Month1_買いWMAs2", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Month1_買いWMAs2"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Month1_買いWMAs2角度", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Month1_買いWMAs2角度"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Month1_買いWMAs14", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Month1_買いWMAs14"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Month1_売りWMAs2", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Month1_売りWMAs2"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Month1_売りWMAs2角度", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Month1_売りWMAs2角度"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Month1_売りWMAs14", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Month1_売りWMAs14"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Week1_Start", SqlDbType.DateTime));
            cmd_InsertOrderHistory2.Parameters["Week1_Start"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Week1_End", SqlDbType.DateTime));
            cmd_InsertOrderHistory2.Parameters["Week1_End"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Week1_買いWMAs2", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Week1_買いWMAs2"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Week1_買いWMAs2角度", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Week1_買いWMAs2角度"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Week1_買いWMAs14", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Week1_買いWMAs14"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Week1_売りWMAs2", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Week1_売りWMAs2"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Week1_売りWMAs2角度", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Week1_売りWMAs2角度"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Week1_売りWMAs14", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Week1_売りWMAs14"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Day1_Start", SqlDbType.DateTime));
            cmd_InsertOrderHistory2.Parameters["Day1_Start"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Day1_End", SqlDbType.DateTime));
            cmd_InsertOrderHistory2.Parameters["Day1_End"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Day1_買いWMAs2", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Day1_買いWMAs2"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Day1_買いWMAs2角度", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Day1_買いWMAs2角度"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Day1_買いWMAs14", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Day1_買いWMAs14"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Day1_売りWMAs2", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Day1_売りWMAs2"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Day1_売りWMAs2角度", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Day1_売りWMAs2角度"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Day1_売りWMAs14", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Day1_売りWMAs14"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Hour1_Start", SqlDbType.DateTime));
            cmd_InsertOrderHistory2.Parameters["Hour1_Start"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Hour1_End", SqlDbType.DateTime));
            cmd_InsertOrderHistory2.Parameters["Hour1_End"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Hour1_買いWMAs2", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Hour1_買いWMAs2"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Hour1_買いWMAs2角度", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Hour1_買いWMAs2角度"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Hour1_買いWMAs14", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Hour1_買いWMAs14"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Hour1_売りWMAs2", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Hour1_売りWMAs2"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Hour1_売りWMAs2角度", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Hour1_売りWMAs2角度"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Hour1_売りWMAs14", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Hour1_売りWMAs14"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Min15_Start", SqlDbType.DateTime));
            cmd_InsertOrderHistory2.Parameters["Min15_Start"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Min15_End", SqlDbType.DateTime));
            cmd_InsertOrderHistory2.Parameters["Min15_End"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Min15_買いWMAs2", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Min15_買いWMAs2"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Min15_買いWMAs2角度", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Min15_買いWMAs2角度"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Min15_買いWMAs14", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Min15_買いWMAs14"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Min15_売りWMAs2", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Min15_売りWMAs2"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Min15_売りWMAs2角度", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Min15_売りWMAs2角度"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Min15_売りWMAs14", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Min15_売りWMAs14"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Min5_Start", SqlDbType.DateTime));
            cmd_InsertOrderHistory2.Parameters["Min5_Start"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Min5_End", SqlDbType.DateTime));
            cmd_InsertOrderHistory2.Parameters["Min5_End"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Min5_買いWMAs2", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Min5_買いWMAs2"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Min5_買いWMAs2角度", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Min5_買いWMAs2角度"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Min5_買いWMAs14", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Min5_買いWMAs14"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Min5_売りWMAs2", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Min5_売りWMAs2"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Min5_売りWMAs2角度", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Min5_売りWMAs2角度"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Min5_売りWMAs14", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Min5_売りWMAs14"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Min1_Start", SqlDbType.DateTime));
            cmd_InsertOrderHistory2.Parameters["Min1_Start"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Min1_End", SqlDbType.DateTime));
            cmd_InsertOrderHistory2.Parameters["Min1_End"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Min1_買いWMAs2", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Min1_買いWMAs2"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Min1_買いWMAs2角度", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Min1_買いWMAs2角度"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Min1_買いWMAs14", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Min1_買いWMAs14"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Min1_売りWMAs2", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Min1_売りWMAs2"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Min1_売りWMAs2角度", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Min1_売りWMAs2角度"].Direction = ParameterDirection.Input;
            cmd_InsertOrderHistory2.Parameters.Add(new SqlParameter("Min1_売りWMAs14", SqlDbType.Float));
            cmd_InsertOrderHistory2.Parameters["Min1_売りWMAs14"].Direction = ParameterDirection.Input;


            cmd_InsertCloseHistory = new SqlCommand("oder.spInsertCloseHistory", cn);
            cmd_InsertCloseHistory.CommandType = CommandType.StoredProcedure;
            //cmd_InsertCloseHistory.CommandTimeout = DB定数.CommandTimeout;
            cmd_InsertCloseHistory.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_InsertCloseHistory.Parameters["口座No"].Direction = ParameterDirection.Input;
            cmd_InsertCloseHistory.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_InsertCloseHistory.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_InsertCloseHistory.Parameters.Add(new SqlParameter("日時", SqlDbType.DateTime));
            cmd_InsertCloseHistory.Parameters["日時"].Direction = ParameterDirection.Input;
            cmd_InsertCloseHistory.Parameters.Add(new SqlParameter("クローズ種別", SqlDbType.VarChar));
            cmd_InsertCloseHistory.Parameters["クローズ種別"].Direction = ParameterDirection.Input;
            cmd_InsertCloseHistory.Parameters.Add(new SqlParameter("OrderData_StartDay1", SqlDbType.DateTime));
            cmd_InsertCloseHistory.Parameters["OrderData_StartDay1"].Direction = ParameterDirection.Input;
            cmd_InsertCloseHistory.Parameters.Add(new SqlParameter("OrderData_EndDay1", SqlDbType.DateTime));
            cmd_InsertCloseHistory.Parameters["OrderData_EndDay1"].Direction = ParameterDirection.Input;
            cmd_InsertCloseHistory.Parameters.Add(new SqlParameter("買いSwap", SqlDbType.Float));
            cmd_InsertCloseHistory.Parameters["買いSwap"].Direction = ParameterDirection.Input;
            cmd_InsertCloseHistory.Parameters.Add(new SqlParameter("売りSwap", SqlDbType.Float));
            cmd_InsertCloseHistory.Parameters["売りSwap"].Direction = ParameterDirection.Input;
            cmd_InsertCloseHistory.Parameters.Add(new SqlParameter("Swap判定", SqlDbType.VarChar));
            cmd_InsertCloseHistory.Parameters["Swap判定"].Direction = ParameterDirection.Input;
            cmd_InsertCloseHistory.Parameters.Add(new SqlParameter("買いRate", SqlDbType.Float));
            cmd_InsertCloseHistory.Parameters["買いRate"].Direction = ParameterDirection.Input;
            cmd_InsertCloseHistory.Parameters.Add(new SqlParameter("売りRate", SqlDbType.Float));
            cmd_InsertCloseHistory.Parameters["売りRate"].Direction = ParameterDirection.Input;
            cmd_InsertCloseHistory.Parameters.Add(new SqlParameter("売買判定", SqlDbType.VarChar));
            cmd_InsertCloseHistory.Parameters["売買判定"].Direction = ParameterDirection.Input;
            cmd_InsertCloseHistory.Parameters.Add(new SqlParameter("売買", SqlDbType.Bit));
            cmd_InsertCloseHistory.Parameters["売買"].Direction = ParameterDirection.Input;
            cmd_InsertCloseHistory.Parameters.Add(new SqlParameter("保持ポジション", SqlDbType.VarChar));
            cmd_InsertCloseHistory.Parameters["保持ポジション"].Direction = ParameterDirection.Input;
            cmd_InsertCloseHistory.Parameters.Add(new SqlParameter("BS_WMA判定_15m", SqlDbType.VarChar));
            cmd_InsertCloseHistory.Parameters["BS_WMA判定_15m"].Direction = ParameterDirection.Input;
            cmd_InsertCloseHistory.Parameters.Add(new SqlParameter("BS判定_15m", SqlDbType.VarChar));
            cmd_InsertCloseHistory.Parameters["BS判定_15m"].Direction = ParameterDirection.Input;
            cmd_InsertCloseHistory.Parameters.Add(new SqlParameter("BS開始", SqlDbType.Bit));
            cmd_InsertCloseHistory.Parameters["BS開始"].Direction = ParameterDirection.Input;
            cmd_InsertCloseHistory.Parameters.Add(new SqlParameter("BS判定_前", SqlDbType.VarChar));
            cmd_InsertCloseHistory.Parameters["BS判定_前"].Direction = ParameterDirection.Input;
            cmd_InsertCloseHistory.Parameters.Add(new SqlParameter("BS判定_今", SqlDbType.VarChar));
            cmd_InsertCloseHistory.Parameters["BS判定_今"].Direction = ParameterDirection.Input;
            cmd_InsertCloseHistory.Parameters.Add(new SqlParameter("差分リミット通常", SqlDbType.Float));
            cmd_InsertCloseHistory.Parameters["差分リミット通常"].Direction = ParameterDirection.Input;
            cmd_InsertCloseHistory.Parameters.Add(new SqlParameter("差分リミットBS", SqlDbType.Float));
            cmd_InsertCloseHistory.Parameters["差分リミットBS"].Direction = ParameterDirection.Input;
            cmd_InsertCloseHistory.Parameters.Add(new SqlParameter("ロスカット余剰金", SqlDbType.Int));
            cmd_InsertCloseHistory.Parameters["ロスカット余剰金"].Direction = ParameterDirection.Input;
            cmd_InsertCloseHistory.Parameters.Add(new SqlParameter("Oanda_TradeData_id", SqlDbType.BigInt));
            cmd_InsertCloseHistory.Parameters.Add(new SqlParameter("Oanda_TradeData_side", SqlDbType.VarChar));
            cmd_InsertCloseHistory.Parameters.Add(new SqlParameter("Oanda_TradeData_instrument", SqlDbType.VarChar));
            cmd_InsertCloseHistory.Parameters.Add(new SqlParameter("Oanda_TradeData_time", SqlDbType.DateTime));
            cmd_InsertCloseHistory.Parameters.Add(new SqlParameter("Oanda_TradeData_price", SqlDbType.Float));
            cmd_InsertCloseHistory.Parameters.Add(new SqlParameter("Oanda_TradeData_units", SqlDbType.Int));
            cmd_InsertCloseHistory.Parameters.Add(new SqlParameter("Oanda_TradeData_takeProfit", SqlDbType.Float));
            cmd_InsertCloseHistory.Parameters.Add(new SqlParameter("Oanda_TradeData_stopLoss", SqlDbType.Float));
            cmd_InsertCloseHistory.Parameters.Add(new SqlParameter("Oanda_TradeData_trailingStop", SqlDbType.Int));
            cmd_InsertCloseHistory.Parameters.Add(new SqlParameter("Oanda_TradeData_trailingAmount", SqlDbType.Float));
            cmd_InsertCloseHistory.Parameters["Oanda_TradeData_id"].Direction = ParameterDirection.Input;
            cmd_InsertCloseHistory.Parameters["Oanda_TradeData_side"].Direction = ParameterDirection.Input;
            cmd_InsertCloseHistory.Parameters["Oanda_TradeData_instrument"].Direction = ParameterDirection.Input;
            cmd_InsertCloseHistory.Parameters["Oanda_TradeData_time"].Direction = ParameterDirection.Input;
            cmd_InsertCloseHistory.Parameters["Oanda_TradeData_price"].Direction = ParameterDirection.Input;
            cmd_InsertCloseHistory.Parameters["Oanda_TradeData_units"].Direction = ParameterDirection.Input;
            cmd_InsertCloseHistory.Parameters["Oanda_TradeData_takeProfit"].Direction = ParameterDirection.Input;
            cmd_InsertCloseHistory.Parameters["Oanda_TradeData_stopLoss"].Direction = ParameterDirection.Input;
            cmd_InsertCloseHistory.Parameters["Oanda_TradeData_trailingStop"].Direction = ParameterDirection.Input;
            cmd_InsertCloseHistory.Parameters["Oanda_TradeData_trailingAmount"].Direction = ParameterDirection.Input;

        }

        public static int Cnt当日注文数(DateTime from)
        {
            try
            {
                cmd_Cnt当日注文数.Parameters["口座No"].Value = FormData.口座No;
                cmd_Cnt当日注文数.Parameters["from"].Value = from;

                cmd_Cnt当日注文数.ExecuteNonQuery();

                return (int)cmd_Cnt当日注文数.Parameters["Cnt"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("from : " + from.ToString());
                throw;
            }
        }

        public static void Chkデータ不足判定(通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_Chkデータ不足判定.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;

                cmd_Chkデータ不足判定.ExecuteNonQuery();

                if ((int)cmd_Chkデータ不足判定.Parameters["DiffWeek_Min15"].Value < 10)
                {
                    // データ不足
                    通貨ぺア取引状況.データ不足_Min15 = true;
                }
                else
                {
                    通貨ぺア取引状況.データ不足_Min15 = false;
                }

                if ((int)cmd_Chkデータ不足判定.Parameters["DiffWeek_Week1"].Value < 15)
                {
                    // データ不足
                    通貨ぺア取引状況.データ不足_Week1 = true;
                }
                else
                {
                    通貨ぺア取引状況.データ不足_Week1 = false;
                }

                if ((int)cmd_Chkデータ不足判定.Parameters["DiffMonth_Month1"].Value < 15)
                {
                    // データ不足
                    通貨ぺア取引状況.データ不足_Month1 = true;
                }
                else
                {
                    通貨ぺア取引状況.データ不足_Month1 = false;
                }

            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                throw;
            }
        }

        public static void Chkボーナスステージ_15m(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_Chkボーナスステージ_15m.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_Chkボーナスステージ_15m.Parameters["StartDate"].Value = OrderData.StartMin15;
                cmd_Chkボーナスステージ_15m.Parameters["シグマ閾値"].Value = FX定数.シグマ閾値;

                cmd_Chkボーナスステージ_15m.ExecuteNonQuery();

                通貨ぺア取引状況.買いWMAs14 = cmd_Chkボーナスステージ_15m.Parameters["買いWMAs14"].Value == DBNull.Value ? 0 : (double)cmd_Chkボーナスステージ_15m.Parameters["買いWMAs14"].Value;
                通貨ぺア取引状況.売りWMAs14 = cmd_Chkボーナスステージ_15m.Parameters["売りWMAs14"].Value == DBNull.Value ? 0 : (double)cmd_Chkボーナスステージ_15m.Parameters["売りWMAs14"].Value;

                通貨ぺア取引状況.BS_WMA判定_15m = (string)cmd_Chkボーナスステージ_15m.Parameters["WMA判定"].Value;

                通貨ぺア取引状況.買いWMAs14上昇角度シグマ = cmd_Chkボーナスステージ_15m.Parameters["買いWMAs14上昇角度シグマ"].Value == DBNull.Value ? 0 : (double)cmd_Chkボーナスステージ_15m.Parameters["買いWMAs14上昇角度シグマ"].Value;
                通貨ぺア取引状況.売りWMAs14上昇角度シグマ = cmd_Chkボーナスステージ_15m.Parameters["売りWMAs14上昇角度シグマ"].Value == DBNull.Value ? 0 : (double)cmd_Chkボーナスステージ_15m.Parameters["売りWMAs14上昇角度シグマ"].Value;

                通貨ぺア取引状況.BS判定_15m = (string)cmd_Chkボーナスステージ_15m.Parameters["BS判定"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("StartMin15 " + OrderData.StartMin15.ToString());
                ログ.ログ書き出し("FX定数.シグマ閾値 : " + FX定数.シグマ閾値);
                ログ.ログ書き出し("買いWMAs14 " + cmd_Chkボーナスステージ_15m.Parameters["買いWMAs14"].Value.ToString());
                ログ.ログ書き出し("売りWMAs14 " + cmd_Chkボーナスステージ_15m.Parameters["売りWMAs14"].Value.ToString());
                ログ.ログ書き出し("WMA判定 " + cmd_Chkボーナスステージ_15m.Parameters["WMA判定"].Value.ToString());
                ログ.ログ書き出し("買いWMAs14上昇角度シグマ " + cmd_Chkボーナスステージ_15m.Parameters["買いWMAs14上昇角度シグマ"].Value.ToString());
                ログ.ログ書き出し("売りWMAs14上昇角度シグマ " + cmd_Chkボーナスステージ_15m.Parameters["売りWMAs14上昇角度シグマ"].Value.ToString());
                ログ.ログ書き出し("BS判定 " + cmd_Chkボーナスステージ_15m.Parameters["BS判定"].Value.ToString());
                throw;
            }
        }

        public static bool Chk当日にOrder有り(byte 通貨ペアNo, DateTime StartDay1)
        {
            try
            {
                cmd_Chk当日にOrder有り.Parameters["口座No"].Value = FormData.口座No;
                cmd_Chk当日にOrder有り.Parameters["通貨ペアNo"].Value = 通貨ペアNo;
                cmd_Chk当日にOrder有り.Parameters["NearestTime"].Value = StartDay1;

                cmd_Chk当日にOrder有り.ExecuteNonQuery();

                if ((int)cmd_Chk当日にOrder有り.Parameters["Order数"].Value > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ペアNo.ToString());
                ログ.ログ書き出し("Now.AddHours(-24) : " + StartDay1);
                throw;
            }
        }

        public static void Get売買判定_Month1(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_Get売買判定_Month1.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_Get売買判定_Month1.Parameters["StartDate"].Value = OrderData.now;

                cmd_Get売買判定_Month1.ExecuteNonQuery();

                通貨ぺア取引状況.ChkGC逆判定_Month1_買いWMAs2 = (double)cmd_Get売買判定_Month1.Parameters["買いWMAs2"].Value;
                通貨ぺア取引状況.ChkGC逆判定_Month1_買いWMAs14 = (double)cmd_Get売買判定_Month1.Parameters["買いWMAs14"].Value;
                通貨ぺア取引状況.ChkGC逆判定_Month1_売りWMAs2 = (double)cmd_Get売買判定_Month1.Parameters["売りWMAs2"].Value;
                通貨ぺア取引状況.ChkGC逆判定_Month1_売りWMAs14 = (double)cmd_Get売買判定_Month1.Parameters["売りWMAs14"].Value;
                通貨ぺア取引状況.ChkGC逆判定_Month1_売買判定 = (string)cmd_Get売買判定_Month1.Parameters["売買判定"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("OrderData.now : " + OrderData.now);
                throw;
            }
        }

        public static void Get売買判定_Week1(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_Get売買判定_Week1.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_Get売買判定_Week1.Parameters["StartDate"].Value = OrderData.now;

                cmd_Get売買判定_Week1.ExecuteNonQuery();

                通貨ぺア取引状況.ChkGC逆判定_Week1_買いWMAs2 = (double)cmd_Get売買判定_Week1.Parameters["買いWMAs2"].Value;
                通貨ぺア取引状況.ChkGC逆判定_Week1_買いWMAs14 = (double)cmd_Get売買判定_Week1.Parameters["買いWMAs14"].Value;
                通貨ぺア取引状況.ChkGC逆判定_Week1_売りWMAs2 = (double)cmd_Get売買判定_Week1.Parameters["売りWMAs2"].Value;
                通貨ぺア取引状況.ChkGC逆判定_Week1_売りWMAs14 = (double)cmd_Get売買判定_Week1.Parameters["売りWMAs14"].Value;
                通貨ぺア取引状況.ChkGC逆判定_Week1_売買判定 = (string)cmd_Get売買判定_Week1.Parameters["売買判定"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("OrderData.now : " + OrderData.now);
                throw;
            }
        }

        public static void Get売買判定_Day1(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_Get売買判定_Day1.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_Get売買判定_Day1.Parameters["StartDate"].Value = OrderData.now;

                cmd_Get売買判定_Day1.ExecuteNonQuery();

                通貨ぺア取引状況.ChkGC逆判定_Day1_買いWMAs2 = (double)cmd_Get売買判定_Day1.Parameters["買いWMAs2"].Value;
                通貨ぺア取引状況.ChkGC逆判定_Day1_買いWMAs14 = (double)cmd_Get売買判定_Day1.Parameters["買いWMAs14"].Value;
                通貨ぺア取引状況.ChkGC逆判定_Day1_売りWMAs2 = (double)cmd_Get売買判定_Day1.Parameters["売りWMAs2"].Value;
                通貨ぺア取引状況.ChkGC逆判定_Day1_売りWMAs14 = (double)cmd_Get売買判定_Day1.Parameters["売りWMAs14"].Value;
                通貨ぺア取引状況.ChkGC逆判定_Day1_売買判定 = (string)cmd_Get売買判定_Day1.Parameters["売買判定"].Value;

            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("OrderData.now " + OrderData.now.ToString());
                throw;
            }
        }

        public static void Get売買判定_Hour1(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_Get売買判定_Hour1.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_Get売買判定_Hour1.Parameters["StartDate"].Value = OrderData.now;

                cmd_Get売買判定_Hour1.ExecuteNonQuery();

                通貨ぺア取引状況.ChkGC逆判定_Hour1_買いWMAs2 = (double)cmd_Get売買判定_Hour1.Parameters["買いWMAs2"].Value;
                通貨ぺア取引状況.ChkGC逆判定_Hour1_買いWMAs14 = (double)cmd_Get売買判定_Hour1.Parameters["買いWMAs14"].Value;
                通貨ぺア取引状況.ChkGC逆判定_Hour1_売りWMAs2 = (double)cmd_Get売買判定_Hour1.Parameters["売りWMAs2"].Value;
                通貨ぺア取引状況.ChkGC逆判定_Hour1_売りWMAs14 = (double)cmd_Get売買判定_Hour1.Parameters["売りWMAs14"].Value;
                通貨ぺア取引状況.ChkGC逆判定_Hour1_売買判定 = (string)cmd_Get売買判定_Hour1.Parameters["売買判定"].Value;

            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("OrderData.now " + OrderData.now.ToString());
                throw;
            }
        }

        public static void Get売買判定_Min15(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_Get売買判定_Min15.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_Get売買判定_Min15.Parameters["StartDate"].Value = OrderData.now;

                cmd_Get売買判定_Min15.ExecuteNonQuery();

                通貨ぺア取引状況.ChkGC逆判定_Min15_買いWMAs2 = (double)cmd_Get売買判定_Min15.Parameters["買いWMAs2"].Value;
                通貨ぺア取引状況.ChkGC逆判定_Min15_買いWMAs14 = (double)cmd_Get売買判定_Min15.Parameters["買いWMAs14"].Value;
                通貨ぺア取引状況.ChkGC逆判定_Min15_売りWMAs2 = (double)cmd_Get売買判定_Min15.Parameters["売りWMAs2"].Value;
                通貨ぺア取引状況.ChkGC逆判定_Min15_売りWMAs14 = (double)cmd_Get売買判定_Min15.Parameters["売りWMAs14"].Value;
                通貨ぺア取引状況.ChkGC逆判定_Min15_売買判定 = (string)cmd_Get売買判定_Min15.Parameters["売買判定"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("OrderData.now " + OrderData.now.ToString());
                throw;
            }
        }

        public static void Get売買判定_Min5(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_Get売買判定_Min5.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_Get売買判定_Min5.Parameters["StartDate"].Value = OrderData.now;

                cmd_Get売買判定_Min5.ExecuteNonQuery();

                通貨ぺア取引状況.ChkGC逆判定_Min5_買いWMAs2 = (double)cmd_Get売買判定_Min5.Parameters["買いWMAs2"].Value;
                通貨ぺア取引状況.ChkGC逆判定_Min5_買いWMAs14 = (double)cmd_Get売買判定_Min5.Parameters["買いWMAs14"].Value;
                通貨ぺア取引状況.ChkGC逆判定_Min5_売りWMAs2 = (double)cmd_Get売買判定_Min5.Parameters["売りWMAs2"].Value;
                通貨ぺア取引状況.ChkGC逆判定_Min5_売りWMAs14 = (double)cmd_Get売買判定_Min5.Parameters["売りWMAs14"].Value;
                通貨ぺア取引状況.ChkGC逆判定_Min5_売買判定 = (string)cmd_Get売買判定_Min5.Parameters["売買判定"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("OrderData.now " + OrderData.now.ToString());
                throw;
            }
        }

        public static void Get売買判定_Min1(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_Get売買判定_Min1.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_Get売買判定_Min1.Parameters["StartDate"].Value = OrderData.now;

                cmd_Get売買判定_Min1.ExecuteNonQuery();

                通貨ぺア取引状況.ChkGC逆判定_Min1_買いWMAs2 = (double)cmd_Get売買判定_Min1.Parameters["買いWMAs2"].Value;
                通貨ぺア取引状況.ChkGC逆判定_Min1_買いWMAs14 = (double)cmd_Get売買判定_Min1.Parameters["買いWMAs14"].Value;
                通貨ぺア取引状況.ChkGC逆判定_Min1_売りWMAs2 = (double)cmd_Get売買判定_Min1.Parameters["売りWMAs2"].Value;
                通貨ぺア取引状況.ChkGC逆判定_Min1_売りWMAs14 = (double)cmd_Get売買判定_Min1.Parameters["売りWMAs14"].Value;
                通貨ぺア取引状況.ChkGC逆判定_Min1_売買判定 = (string)cmd_Get売買判定_Min1.Parameters["売買判定"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("OrderData.now " + OrderData.now.ToString());
                throw;
            }
        }

        public static void GetWMA_Month1(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_GetWMA_Month1.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_GetWMA_Month1.Parameters["StartDate"].Value = OrderData.StartMonth1;

                cmd_GetWMA_Month1.ExecuteNonQuery();

                通貨ぺア取引状況.WMA判定_Month1_買いWMAs2 = cmd_GetWMA_Month1.Parameters["買いWMAs2"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Month1.Parameters["買いWMAs2"].Value;
                通貨ぺア取引状況.WMA判定_Month1_買いWMAs2角度 = cmd_GetWMA_Month1.Parameters["買いWMAs2角度"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Month1.Parameters["買いWMAs2角度"].Value;
                通貨ぺア取引状況.WMA判定_Month1_買いWMAs14 = cmd_GetWMA_Month1.Parameters["買いWMAs14"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Month1.Parameters["買いWMAs14"].Value;
                通貨ぺア取引状況.WMA判定_Month1_売りWMAs2 = cmd_GetWMA_Month1.Parameters["売りWMAs2"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Month1.Parameters["売りWMAs2"].Value;
                通貨ぺア取引状況.WMA判定_Month1_売りWMAs2角度 = cmd_GetWMA_Month1.Parameters["売りWMAs2角度"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Month1.Parameters["売りWMAs2角度"].Value;
                通貨ぺア取引状況.WMA判定_Month1_売りWMAs14 = cmd_GetWMA_Month1.Parameters["売りWMAs14"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Month1.Parameters["売りWMAs14"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("\r\n 通貨ペアNo " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("\r\n StartMonth1 " + OrderData.StartMonth1.ToString());
                ログ.ログ書き出し("\r\n 買いWMAs2 " + cmd_GetWMA_Month1.Parameters["買いWMAs2"].Value.ToString());
                ログ.ログ書き出し("\r\n 買いWMAs2角度 " + cmd_GetWMA_Month1.Parameters["買いWMAs2角度"].Value.ToString());
                ログ.ログ書き出し("\r\n 買いWMAs14 " + cmd_GetWMA_Month1.Parameters["買いWMAs14"].Value.ToString());
                ログ.ログ書き出し("\r\n 売りWMAs2 " + cmd_GetWMA_Month1.Parameters["売りWMAs2"].Value.ToString());
                ログ.ログ書き出し("\r\n 売りWMAs2角度 " + cmd_GetWMA_Month1.Parameters["売りWMAs2角度"].Value.ToString());
                ログ.ログ書き出し("\r\n 売りWMAs14 " + cmd_GetWMA_Month1.Parameters["売りWMAs14"].Value.ToString());

                throw;
            }
        }

        public static void GetWMA_Week1(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_GetWMA_Week1.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_GetWMA_Week1.Parameters["StartDate"].Value = OrderData.StartWeek1;

                cmd_GetWMA_Week1.ExecuteNonQuery();

                通貨ぺア取引状況.WMA判定_Week1_買いWMAs2 = cmd_GetWMA_Week1.Parameters["買いWMAs2"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Week1.Parameters["買いWMAs2"].Value;
                通貨ぺア取引状況.WMA判定_Week1_買いWMAs2角度 = cmd_GetWMA_Week1.Parameters["買いWMAs2角度"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Week1.Parameters["買いWMAs2角度"].Value;
                通貨ぺア取引状況.WMA判定_Week1_買いWMAs14 = cmd_GetWMA_Week1.Parameters["買いWMAs14"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Week1.Parameters["買いWMAs14"].Value;
                通貨ぺア取引状況.WMA判定_Week1_売りWMAs2 = cmd_GetWMA_Week1.Parameters["売りWMAs2"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Week1.Parameters["売りWMAs2"].Value;
                通貨ぺア取引状況.WMA判定_Week1_売りWMAs2角度 = cmd_GetWMA_Week1.Parameters["売りWMAs2角度"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Week1.Parameters["売りWMAs2角度"].Value;
                通貨ぺア取引状況.WMA判定_Week1_売りWMAs14 = cmd_GetWMA_Week1.Parameters["売りWMAs14"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Week1.Parameters["売りWMAs14"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("\r\n 通貨ペアNo " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("\r\n StartWeek1 " + OrderData.StartWeek1.ToString());
                ログ.ログ書き出し("\r\n 買いWMAs2 " + cmd_GetWMA_Week1.Parameters["買いWMAs2"].Value.ToString());
                ログ.ログ書き出し("\r\n 買いWMAs2角度 " + cmd_GetWMA_Week1.Parameters["買いWMAs2角度"].Value.ToString());
                ログ.ログ書き出し("\r\n 買いWMAs14 " + cmd_GetWMA_Week1.Parameters["買いWMAs14"].Value.ToString());
                ログ.ログ書き出し("\r\n 売りWMAs2 " + cmd_GetWMA_Week1.Parameters["売りWMAs2"].Value.ToString());
                ログ.ログ書き出し("\r\n 売りWMAs2角度 " + cmd_GetWMA_Week1.Parameters["売りWMAs2角度"].Value.ToString());
                ログ.ログ書き出し("\r\n 売りWMAs14 " + cmd_GetWMA_Week1.Parameters["売りWMAs14"].Value.ToString());

                throw;
            }
        }

        public static void GetWMA_Day1(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_GetWMA_Day1.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_GetWMA_Day1.Parameters["StartDate"].Value = OrderData.StartDay1;

                cmd_GetWMA_Day1.ExecuteNonQuery();

                通貨ぺア取引状況.WMA判定_Day1_買いWMAs2 = cmd_GetWMA_Day1.Parameters["買いWMAs2"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Day1.Parameters["買いWMAs2"].Value;
                通貨ぺア取引状況.WMA判定_Day1_買いWMAs2角度 = cmd_GetWMA_Day1.Parameters["買いWMAs2角度"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Day1.Parameters["買いWMAs2角度"].Value;
                通貨ぺア取引状況.WMA判定_Day1_買いWMAs14 = cmd_GetWMA_Day1.Parameters["買いWMAs14"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Day1.Parameters["買いWMAs14"].Value;
                通貨ぺア取引状況.WMA判定_Day1_売りWMAs2 = cmd_GetWMA_Day1.Parameters["売りWMAs2"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Day1.Parameters["売りWMAs2"].Value;
                通貨ぺア取引状況.WMA判定_Day1_売りWMAs2角度 = cmd_GetWMA_Day1.Parameters["売りWMAs2角度"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Day1.Parameters["売りWMAs2角度"].Value;
                通貨ぺア取引状況.WMA判定_Day1_売りWMAs14 = cmd_GetWMA_Day1.Parameters["売りWMAs14"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Day1.Parameters["売りWMAs14"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("\r\n 通貨ペアNo " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("\r\n StartDay1 " + OrderData.StartDay1.ToString());
                ログ.ログ書き出し("\r\n 買いWMAs2 " + cmd_GetWMA_Day1.Parameters["買いWMAs2"].Value.ToString());
                ログ.ログ書き出し("\r\n 買いWMAs2角度 " + cmd_GetWMA_Day1.Parameters["買いWMAs2角度"].Value.ToString());
                ログ.ログ書き出し("\r\n 買いWMAs14 " + cmd_GetWMA_Day1.Parameters["買いWMAs14"].Value.ToString());
                ログ.ログ書き出し("\r\n 売りWMAs2 " + cmd_GetWMA_Day1.Parameters["売りWMAs2"].Value.ToString());
                ログ.ログ書き出し("\r\n 売りWMAs2角度 " + cmd_GetWMA_Day1.Parameters["売りWMAs2角度"].Value.ToString());
                ログ.ログ書き出し("\r\n 売りWMAs14 " + cmd_GetWMA_Day1.Parameters["売りWMAs14"].Value.ToString());

                throw;
            }
        }

        public static void GetWMA_Hour1(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_GetWMA_Hour1.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_GetWMA_Hour1.Parameters["StartDate"].Value = OrderData.StartHour1;

                cmd_GetWMA_Hour1.ExecuteNonQuery();

                通貨ぺア取引状況.WMA判定_Hour1_買いWMAs2 = cmd_GetWMA_Hour1.Parameters["買いWMAs2"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Hour1.Parameters["買いWMAs2"].Value;
                通貨ぺア取引状況.WMA判定_Hour1_買いWMAs2角度 = cmd_GetWMA_Hour1.Parameters["買いWMAs2角度"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Hour1.Parameters["買いWMAs2角度"].Value;
                通貨ぺア取引状況.WMA判定_Hour1_買いWMAs14 = cmd_GetWMA_Hour1.Parameters["買いWMAs14"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Hour1.Parameters["買いWMAs14"].Value;
                通貨ぺア取引状況.WMA判定_Hour1_売りWMAs2 = cmd_GetWMA_Hour1.Parameters["売りWMAs2"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Hour1.Parameters["売りWMAs2"].Value;
                通貨ぺア取引状況.WMA判定_Hour1_売りWMAs2角度 = cmd_GetWMA_Hour1.Parameters["売りWMAs2角度"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Hour1.Parameters["売りWMAs2角度"].Value;
                通貨ぺア取引状況.WMA判定_Hour1_売りWMAs14 = cmd_GetWMA_Hour1.Parameters["売りWMAs14"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Hour1.Parameters["売りWMAs14"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("\r\n 通貨ペアNo " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("\r\n StartDay1 " + OrderData.StartHour1.ToString());
                ログ.ログ書き出し("\r\n 買いWMAs2 " + cmd_GetWMA_Hour1.Parameters["買いWMAs2"].Value.ToString());
                ログ.ログ書き出し("\r\n 買いWMAs2角度 " + cmd_GetWMA_Hour1.Parameters["買いWMAs2角度"].Value.ToString());
                ログ.ログ書き出し("\r\n 買いWMAs14 " + cmd_GetWMA_Hour1.Parameters["買いWMAs14"].Value.ToString());
                ログ.ログ書き出し("\r\n 売りWMAs2 " + cmd_GetWMA_Hour1.Parameters["売りWMAs2"].Value.ToString());
                ログ.ログ書き出し("\r\n 売りWMAs2角度 " + cmd_GetWMA_Hour1.Parameters["売りWMAs2角度"].Value.ToString());
                ログ.ログ書き出し("\r\n 売りWMAs14 " + cmd_GetWMA_Hour1.Parameters["売りWMAs14"].Value.ToString());
                throw;
            }
        }

        public static void GetWMA_Min15(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_GetWMA_Min15.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_GetWMA_Min15.Parameters["StartDate"].Value = OrderData.StartMin15;

                cmd_GetWMA_Min15.ExecuteNonQuery();

                通貨ぺア取引状況.WMA判定_Min15_買いWMAs2 = cmd_GetWMA_Min15.Parameters["買いWMAs2"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Min15.Parameters["買いWMAs2"].Value;
                通貨ぺア取引状況.WMA判定_Min15_買いWMAs2角度 = cmd_GetWMA_Min15.Parameters["買いWMAs2角度"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Min15.Parameters["買いWMAs2角度"].Value;
                通貨ぺア取引状況.WMA判定_Min15_買いWMAs14 = cmd_GetWMA_Min15.Parameters["買いWMAs14"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Min15.Parameters["買いWMAs14"].Value;
                通貨ぺア取引状況.WMA判定_Min15_売りWMAs2 = cmd_GetWMA_Min15.Parameters["売りWMAs2"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Min15.Parameters["売りWMAs2"].Value;
                通貨ぺア取引状況.WMA判定_Min15_売りWMAs2角度 = cmd_GetWMA_Min15.Parameters["売りWMAs2角度"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Min15.Parameters["売りWMAs2角度"].Value;
                通貨ぺア取引状況.WMA判定_Min15_売りWMAs14 = cmd_GetWMA_Min15.Parameters["売りWMAs14"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Min15.Parameters["売りWMAs14"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("\r\n 通貨ペアNo " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("\r\n StartMin15 " + OrderData.StartMin15.ToString());
                ログ.ログ書き出し("\r\n 買いWMAs2 " + cmd_GetWMA_Min15.Parameters["買いWMAs2"].Value.ToString());
                ログ.ログ書き出し("\r\n 買いWMAs2角度 " + cmd_GetWMA_Min15.Parameters["買いWMAs2角度"].Value.ToString());
                ログ.ログ書き出し("\r\n 買いWMAs14 " + cmd_GetWMA_Min15.Parameters["買いWMAs14"].Value.ToString());
                ログ.ログ書き出し("\r\n 売りWMAs2 " + cmd_GetWMA_Min15.Parameters["売りWMAs2"].Value.ToString());
                ログ.ログ書き出し("\r\n 売りWMAs2角度 " + cmd_GetWMA_Min15.Parameters["売りWMAs2角度"].Value.ToString());
                ログ.ログ書き出し("\r\n 売りWMAs14 " + cmd_GetWMA_Min15.Parameters["売りWMAs14"].Value.ToString());
                throw;
            }

        }

        public static void GetWMA_Min5(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_GetWMA_Min5.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_GetWMA_Min5.Parameters["StartDate"].Value = OrderData.StartMin5;

                cmd_GetWMA_Min5.ExecuteNonQuery();

                通貨ぺア取引状況.WMA判定_Min5_買いWMAs2 = cmd_GetWMA_Min5.Parameters["買いWMAs2"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Min5.Parameters["買いWMAs2"].Value;
                通貨ぺア取引状況.WMA判定_Min5_買いWMAs2角度 = cmd_GetWMA_Min5.Parameters["買いWMAs2角度"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Min5.Parameters["買いWMAs2角度"].Value;
                通貨ぺア取引状況.WMA判定_Min5_買いWMAs14 = cmd_GetWMA_Min5.Parameters["買いWMAs14"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Min5.Parameters["買いWMAs14"].Value;
                通貨ぺア取引状況.WMA判定_Min5_売りWMAs2 = cmd_GetWMA_Min5.Parameters["売りWMAs2"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Min5.Parameters["売りWMAs2"].Value;
                通貨ぺア取引状況.WMA判定_Min5_売りWMAs2角度 = cmd_GetWMA_Min5.Parameters["売りWMAs2角度"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Min5.Parameters["売りWMAs2角度"].Value;
                通貨ぺア取引状況.WMA判定_Min5_売りWMAs14 = cmd_GetWMA_Min5.Parameters["売りWMAs14"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Min5.Parameters["売りWMAs14"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("\r\n 通貨ペアNo " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("\r\n StartMin5 " + OrderData.StartMin5.ToString());
                ログ.ログ書き出し("\r\n 買いWMAs2 " + cmd_GetWMA_Min5.Parameters["買いWMAs2"].Value.ToString());
                ログ.ログ書き出し("\r\n 買いWMAs2角度 " + cmd_GetWMA_Min5.Parameters["買いWMAs2角度"].Value.ToString());
                ログ.ログ書き出し("\r\n 買いWMAs14 " + cmd_GetWMA_Min5.Parameters["買いWMAs14"].Value.ToString());
                ログ.ログ書き出し("\r\n 売りWMAs2 " + cmd_GetWMA_Min5.Parameters["売りWMAs2"].Value.ToString());
                ログ.ログ書き出し("\r\n 売りWMAs2角度 " + cmd_GetWMA_Min5.Parameters["売りWMAs2角度"].Value.ToString());
                ログ.ログ書き出し("\r\n 売りWMAs14 " + cmd_GetWMA_Min5.Parameters["売りWMAs14"].Value.ToString());
                throw;
            }
        }

        public static void GetWMA_Min1(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_GetWMA_Min1.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_GetWMA_Min1.Parameters["StartDate"].Value = OrderData.StartMin1;

                cmd_GetWMA_Min1.ExecuteNonQuery();

                通貨ぺア取引状況.WMA判定_Min1_買いWMAs2 = cmd_GetWMA_Min1.Parameters["買いWMAs2"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Min1.Parameters["買いWMAs2"].Value;
                通貨ぺア取引状況.WMA判定_Min1_買いWMAs2角度 = cmd_GetWMA_Min1.Parameters["買いWMAs2角度"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Min1.Parameters["買いWMAs2角度"].Value;
                通貨ぺア取引状況.WMA判定_Min1_買いWMAs14 = cmd_GetWMA_Min1.Parameters["買いWMAs14"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Min1.Parameters["買いWMAs14"].Value;
                通貨ぺア取引状況.WMA判定_Min1_売りWMAs2 = cmd_GetWMA_Min1.Parameters["売りWMAs2"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Min1.Parameters["売りWMAs2"].Value;
                通貨ぺア取引状況.WMA判定_Min1_売りWMAs2角度 = cmd_GetWMA_Min1.Parameters["売りWMAs2角度"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Min1.Parameters["売りWMAs2角度"].Value;
                通貨ぺア取引状況.WMA判定_Min1_売りWMAs14 = cmd_GetWMA_Min1.Parameters["売りWMAs14"].Value == DBNull.Value ? 0 : (double)cmd_GetWMA_Min1.Parameters["売りWMAs14"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("\r\n 通貨ペアNo " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("\r\n StartMin5 " + OrderData.StartMin1.ToString());
                ログ.ログ書き出し("\r\n 買いWMAs2 " + cmd_GetWMA_Min1.Parameters["買いWMAs2"].Value.ToString());
                ログ.ログ書き出し("\r\n 買いWMAs2角度 " + cmd_GetWMA_Min1.Parameters["買いWMAs2角度"].Value.ToString());
                ログ.ログ書き出し("\r\n 買いWMAs14 " + cmd_GetWMA_Min1.Parameters["買いWMAs14"].Value.ToString());
                ログ.ログ書き出し("\r\n 売りWMAs2 " + cmd_GetWMA_Min1.Parameters["売りWMAs2"].Value.ToString());
                ログ.ログ書き出し("\r\n 売りWMAs2角度 " + cmd_GetWMA_Min1.Parameters["売りWMAs2角度"].Value.ToString());
                ログ.ログ書き出し("\r\n 売りWMAs14 " + cmd_GetWMA_Min1.Parameters["売りWMAs14"].Value.ToString());

                throw;
            }
        }

        public static bool Chk直近n分以内にボーナスステージ終了有り(通貨ぺア取引状況 通貨ぺア取引状況, DateTime n分前)
        {
            try
            {
                cmd_Chk直近n分以内にボーナスステージ終了有り.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_Chk直近n分以内にボーナスステージ終了有り.Parameters["n分前"].Value = n分前;

                cmd_Chk直近n分以内にボーナスステージ終了有り.ExecuteNonQuery();

                if (byte.Parse(cmd_Chk直近n分以内にボーナスステージ終了有り.Parameters["判定"].Value.ToString()) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("n分前 : " + n分前);
                throw;
            }
        }

        public static void UpdateOrderHistory_OrderId(byte 通貨ペアNo, DateTime 日時, string OpenOrderID)
        {
            try
            {
                if (OpenOrderID == "")
                    return;

                cmd_UpdateOrderHistory_OrderId.Parameters["口座No"].Value = FormData.口座No;
                cmd_UpdateOrderHistory_OrderId.Parameters["通貨ペアNo"].Value = 通貨ペアNo;
                cmd_UpdateOrderHistory_OrderId.Parameters["日時"].Value = 日時;
                cmd_UpdateOrderHistory_OrderId.Parameters["OpenOrderID"].Value = OpenOrderID;

                cmd_UpdateOrderHistory_OrderId.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ペアNo.ToString());
                ログ.ログ書き出し("日時 : " + 日時);
                ログ.ログ書き出し("OpenOrderID : " + OpenOrderID);
                throw;
            }
        }

        public static void UpdateOrderHistory_OANDA_Trade_ID(byte 通貨ペアNo, OrderData OrderData, long? Oanda_TradeData_id)
        {
            try
            {
                cmd_UpdateOrderHistory_OANDA_Trade_ID.Parameters["口座No"].Value = FormData.口座No;
                cmd_UpdateOrderHistory_OANDA_Trade_ID.Parameters["通貨ペアNo"].Value = 通貨ペアNo;
                cmd_UpdateOrderHistory_OANDA_Trade_ID.Parameters["日時"].Value = OrderData.now;
                cmd_UpdateOrderHistory_OANDA_Trade_ID.Parameters["Oanda_TradeData_id"].Value = (long)Oanda_TradeData_id;

                cmd_UpdateOrderHistory_OANDA_Trade_ID.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ペアNo.ToString());
                ログ.ログ書き出し("日時 : " + OrderData.now);
                ログ.ログ書き出し("Oanda_TradeData_id : " + Oanda_TradeData_id);
                throw;
            }
        }

        public static void Insertリミット変更History(TradeData TradeData, string リミット, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_Insertリミット変更History.Parameters["口座No"].Value = FormData.口座No;
                cmd_Insertリミット変更History.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_Insertリミット変更History.Parameters["OANDA_Trade_Side"].Value = TradeData.side;
                cmd_Insertリミット変更History.Parameters["OANDA_Trade_ID"].Value = TradeData.id;
                cmd_Insertリミット変更History.Parameters["OANDA_Trade_Price"].Value = TradeData.price;
                cmd_Insertリミット変更History.Parameters["OANDA_Trade_TakeProfit"].Value = TradeData.takeProfit;
                cmd_Insertリミット変更History.Parameters["リミット"].Value = リミット;
                if (通貨ぺア取引状況.差分リミット通常 == null) cmd_Insertリミット変更History.Parameters["差分リミット通常"].Value = DBNull.Value;
                else cmd_Insertリミット変更History.Parameters["差分リミット通常"].Value = 通貨ぺア取引状況.差分リミット通常;
                if (通貨ぺア取引状況.差分リミットBS == null) cmd_Insertリミット変更History.Parameters["差分リミットBS"].Value = DBNull.Value;
                else cmd_Insertリミット変更History.Parameters["差分リミットBS"].Value = 通貨ぺア取引状況.差分リミットBS;
                cmd_Insertリミット変更History.Parameters["買いSwap"].Value = 通貨ぺア取引状況.買いSwap;
                cmd_Insertリミット変更History.Parameters["売りSwap"].Value = 通貨ぺア取引状況.売りSwap;
                cmd_Insertリミット変更History.Parameters["Swap判定"].Value = 通貨ぺア取引状況.Swap判定;
                cmd_Insertリミット変更History.Parameters["買いRate"].Value = 通貨ぺア取引状況.買いRate;
                cmd_Insertリミット変更History.Parameters["売りRate"].Value = 通貨ぺア取引状況.売りRate;
                cmd_Insertリミット変更History.Parameters["売買判定"].Value = 通貨ぺア取引状況.売買判定;
                if (通貨ぺア取引状況.売買 == null) cmd_Insertリミット変更History.Parameters["売買"].Value = DBNull.Value;
                else cmd_Insertリミット変更History.Parameters["売買"].Value = 通貨ぺア取引状況.売買;
                cmd_Insertリミット変更History.Parameters["保持ポジション"].Value = 通貨ぺア取引状況.保持ポジション;
                cmd_Insertリミット変更History.Parameters["BS_WMA判定_15m"].Value = 通貨ぺア取引状況.BS_WMA判定_15m;
                cmd_Insertリミット変更History.Parameters["BS判定_15m"].Value = 通貨ぺア取引状況.BS判定_15m;
                if (通貨ぺア取引状況.BS開始 == null) cmd_Insertリミット変更History.Parameters["BS開始"].Value = DBNull.Value;
                else cmd_Insertリミット変更History.Parameters["BS開始"].Value = 通貨ぺア取引状況.BS開始;
                cmd_Insertリミット変更History.Parameters["BS判定_前"].Value = 通貨ぺア取引状況.BS判定_前;
                cmd_Insertリミット変更History.Parameters["BS判定_今"].Value = 通貨ぺア取引状況.BS判定_今;

                cmd_Insertリミット変更History.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し(" : " + 通貨ぺア取引状況.通貨ペアNo);
                ログ.ログ書き出し(" : " + TradeData.side);
                ログ.ログ書き出し(" : " + TradeData.id);
                ログ.ログ書き出し(" : " + TradeData.price);
                ログ.ログ書き出し(" : " + TradeData.takeProfit);
                ログ.ログ書き出し(" : " + リミット);
                ログ.ログ書き出し(" : " + 通貨ぺア取引状況.差分リミット通常);
                ログ.ログ書き出し(" : " + 通貨ぺア取引状況.差分リミットBS);
                ログ.ログ書き出し(" : " + 通貨ぺア取引状況.買いSwap);
                ログ.ログ書き出し(" : " + 通貨ぺア取引状況.売りSwap);
                ログ.ログ書き出し(" : " + 通貨ぺア取引状況.Swap判定);
                ログ.ログ書き出し(" : " + 通貨ぺア取引状況.買いRate);
                ログ.ログ書き出し(" : " + 通貨ぺア取引状況.売りRate);
                ログ.ログ書き出し(" : " + 通貨ぺア取引状況.売買判定);
                ログ.ログ書き出し(" : " + 通貨ぺア取引状況.売買);
                ログ.ログ書き出し(" : " + 通貨ぺア取引状況.保持ポジション);
                ログ.ログ書き出し(" : " + 通貨ぺア取引状況.BS_WMA判定_15m);
                ログ.ログ書き出し(" : " + 通貨ぺア取引状況.BS判定_15m);
                ログ.ログ書き出し(" : " + 通貨ぺア取引状況.BS開始);
                ログ.ログ書き出し(" : " + 通貨ぺア取引状況.BS判定_前);
                ログ.ログ書き出し(" : " + 通貨ぺア取引状況.BS判定_今);
                throw;
            }
        }

        public static void InsertOrderHistory2(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_InsertOrderHistory2.Parameters["口座No"].Value = FormData.口座No;
                cmd_InsertOrderHistory2.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_InsertOrderHistory2.Parameters["日時"].Value = OrderData.now;
                cmd_InsertOrderHistory2.Parameters["買いSwap"].Value = 通貨ぺア取引状況.買いSwap;
                cmd_InsertOrderHistory2.Parameters["売りSwap"].Value = 通貨ぺア取引状況.売りSwap;
                cmd_InsertOrderHistory2.Parameters["Swap判定"].Value = 通貨ぺア取引状況.Swap判定;
                cmd_InsertOrderHistory2.Parameters["買いRate"].Value = 通貨ぺア取引状況.買いRate;
                cmd_InsertOrderHistory2.Parameters["売りRate"].Value = 通貨ぺア取引状況.売りRate;
                cmd_InsertOrderHistory2.Parameters["売買判定"].Value = 通貨ぺア取引状況.売買判定;
                if (通貨ぺア取引状況.売買 == null) cmd_InsertOrderHistory2.Parameters["売買"].Value = DBNull.Value;
                else cmd_InsertOrderHistory2.Parameters["売買"].Value = 通貨ぺア取引状況.売買;
                cmd_InsertOrderHistory2.Parameters["保持ポジション"].Value = 通貨ぺア取引状況.保持ポジション;
                if (通貨ぺア取引状況.買いWMAs14 == null) cmd_InsertOrderHistory2.Parameters["BS_Min15_買いWMAs14"].Value = DBNull.Value;
                else cmd_InsertOrderHistory2.Parameters["BS_Min15_買いWMAs14"].Value = 通貨ぺア取引状況.買いWMAs14;
                if (通貨ぺア取引状況.買いWMAs14上昇角度 == null) cmd_InsertOrderHistory2.Parameters["BS_Min15_買いWMAs14角度"].Value = DBNull.Value;
                else cmd_InsertOrderHistory2.Parameters["BS_Min15_買いWMAs14角度"].Value = 通貨ぺア取引状況.買いWMAs14上昇角度;
                if (通貨ぺア取引状況.買いWMAs14上昇角度シグマ == null) cmd_InsertOrderHistory2.Parameters["BS_Min15_買いWMAs14角度シグマ"].Value = DBNull.Value;
                else cmd_InsertOrderHistory2.Parameters["BS_Min15_買いWMAs14角度シグマ"].Value = 通貨ぺア取引状況.買いWMAs14上昇角度シグマ;
                if (通貨ぺア取引状況.売りWMAs14 == null) cmd_InsertOrderHistory2.Parameters["BS_Min15_売りWMAs14"].Value = DBNull.Value;
                else cmd_InsertOrderHistory2.Parameters["BS_Min15_売りWMAs14"].Value = 通貨ぺア取引状況.売りWMAs14;
                if (通貨ぺア取引状況.売りWMAs14上昇角度 == null) cmd_InsertOrderHistory2.Parameters["BS_Min15_売りWMAs14角度"].Value = DBNull.Value;
                else cmd_InsertOrderHistory2.Parameters["BS_Min15_売りWMAs14角度"].Value = 通貨ぺア取引状況.売りWMAs14上昇角度;
                if (通貨ぺア取引状況.売りWMAs14上昇角度シグマ == null) cmd_InsertOrderHistory2.Parameters["BS_Min15_売りWMAs14角度シグマ"].Value = DBNull.Value;
                else cmd_InsertOrderHistory2.Parameters["BS_Min15_売りWMAs14角度シグマ"].Value = 通貨ぺア取引状況.売りWMAs14上昇角度シグマ;
                if (通貨ぺア取引状況.BS_WMA判定_15m == null) cmd_InsertOrderHistory2.Parameters["BS_WMA判定_15m"].Value = DBNull.Value;
                else cmd_InsertOrderHistory2.Parameters["BS_WMA判定_15m"].Value = 通貨ぺア取引状況.BS_WMA判定_15m;
                if (通貨ぺア取引状況.BS判定_15m == null) cmd_InsertOrderHistory2.Parameters["BS判定_15m"].Value = DBNull.Value;
                else cmd_InsertOrderHistory2.Parameters["BS判定_15m"].Value = 通貨ぺア取引状況.BS判定_15m;
                if (通貨ぺア取引状況.BS開始 == null) cmd_InsertOrderHistory2.Parameters["BS開始"].Value = DBNull.Value;
                else cmd_InsertOrderHistory2.Parameters["BS開始"].Value = 通貨ぺア取引状況.BS開始;
                if (通貨ぺア取引状況.BS判定_前 == null) cmd_InsertOrderHistory2.Parameters["BS判定_前"].Value = DBNull.Value;
                else cmd_InsertOrderHistory2.Parameters["BS判定_前"].Value = 通貨ぺア取引状況.BS判定_前;
                if (通貨ぺア取引状況.ポジション追加_成行_ストップ == null) cmd_InsertOrderHistory2.Parameters["ポジション追加_成行_ストップ"].Value = DBNull.Value;
                else cmd_InsertOrderHistory2.Parameters["ポジション追加_成行_ストップ"].Value = 通貨ぺア取引状況.ポジション追加_成行_ストップ;
                if (通貨ぺア取引状況.ポジション追加_成行_リミット == null) cmd_InsertOrderHistory2.Parameters["ポジション追加_成行_リミット"].Value = DBNull.Value;
                else cmd_InsertOrderHistory2.Parameters["ポジション追加_成行_リミット"].Value = 通貨ぺア取引状況.ポジション追加_成行_リミット;
                if (通貨ぺア取引状況.ポジション追加時のリミット == null) cmd_InsertOrderHistory2.Parameters["ポジション追加時のリミット"].Value = DBNull.Value;
                else cmd_InsertOrderHistory2.Parameters["ポジション追加時のリミット"].Value = 通貨ぺア取引状況.ポジション追加時のリミット;
                if (通貨ぺア取引状況.BS判定_今 == null) cmd_InsertOrderHistory2.Parameters["BS判定_今"].Value = DBNull.Value;
                else cmd_InsertOrderHistory2.Parameters["BS判定_今"].Value = 通貨ぺア取引状況.BS判定_今;
                if (通貨ぺア取引状況.差分リミット通常 == null) cmd_InsertOrderHistory2.Parameters["差分リミット通常"].Value = DBNull.Value;
                else cmd_InsertOrderHistory2.Parameters["差分リミット通常"].Value = 通貨ぺア取引状況.差分リミット通常;
                if (通貨ぺア取引状況.差分リミットBS == null) cmd_InsertOrderHistory2.Parameters["差分リミットBS"].Value = DBNull.Value;
                else cmd_InsertOrderHistory2.Parameters["差分リミットBS"].Value = 通貨ぺア取引状況.差分リミットBS;
                cmd_InsertOrderHistory2.Parameters["注文単位"].Value = 通貨ぺア取引状況.注文単位;
                cmd_InsertOrderHistory2.Parameters["注文単位を割る値"].Value = 通貨ぺア取引状況.注文単位を割る値;
                cmd_InsertOrderHistory2.Parameters["ロスカット余剰金"].Value = FormData.余剰証拠金;
                cmd_InsertOrderHistory2.Parameters["ロスカット余剰金調整値"].Value = FormData.ロスカット余剰金調整値;
                cmd_InsertOrderHistory2.Parameters["証拠金倍率"].Value = 通貨ぺア取引状況.証拠金倍率;                
                cmd_InsertOrderHistory2.Parameters["Month1_Start"].Value = OrderData.StartMonth1;
                cmd_InsertOrderHistory2.Parameters["Month1_End"].Value = OrderData.EndMonth1;
                cmd_InsertOrderHistory2.Parameters["Month1_買いWMAs2"].Value = 通貨ぺア取引状況.WMA判定_Month1_買いWMAs2;
                cmd_InsertOrderHistory2.Parameters["Month1_買いWMAs2角度"].Value = 通貨ぺア取引状況.WMA判定_Month1_買いWMAs2角度;
                cmd_InsertOrderHistory2.Parameters["Month1_買いWMAs14"].Value = 通貨ぺア取引状況.WMA判定_Month1_買いWMAs14;
                cmd_InsertOrderHistory2.Parameters["Month1_売りWMAs2"].Value = 通貨ぺア取引状況.WMA判定_Month1_売りWMAs2;
                cmd_InsertOrderHistory2.Parameters["Month1_売りWMAs2角度"].Value = 通貨ぺア取引状況.WMA判定_Month1_売りWMAs2角度;
                cmd_InsertOrderHistory2.Parameters["Month1_売りWMAs14"].Value = 通貨ぺア取引状況.WMA判定_Month1_売りWMAs14;
                cmd_InsertOrderHistory2.Parameters["Week1_Start"].Value = OrderData.StartWeek1;
                cmd_InsertOrderHistory2.Parameters["Week1_End"].Value = OrderData.EndWeek1;
                cmd_InsertOrderHistory2.Parameters["Week1_買いWMAs2"].Value = 通貨ぺア取引状況.WMA判定_Week1_買いWMAs2;
                cmd_InsertOrderHistory2.Parameters["Week1_買いWMAs2角度"].Value = 通貨ぺア取引状況.WMA判定_Week1_買いWMAs2角度;
                cmd_InsertOrderHistory2.Parameters["Week1_買いWMAs14"].Value = 通貨ぺア取引状況.WMA判定_Week1_買いWMAs14;
                cmd_InsertOrderHistory2.Parameters["Week1_売りWMAs2"].Value = 通貨ぺア取引状況.WMA判定_Week1_売りWMAs2;
                cmd_InsertOrderHistory2.Parameters["Week1_売りWMAs2角度"].Value = 通貨ぺア取引状況.WMA判定_Week1_売りWMAs2角度;
                cmd_InsertOrderHistory2.Parameters["Week1_売りWMAs14"].Value = 通貨ぺア取引状況.WMA判定_Week1_売りWMAs14;
                cmd_InsertOrderHistory2.Parameters["Day1_Start"].Value = OrderData.StartDay1;
                cmd_InsertOrderHistory2.Parameters["Day1_End"].Value = OrderData.EndDay1;
                cmd_InsertOrderHistory2.Parameters["Day1_買いWMAs2"].Value = 通貨ぺア取引状況.WMA判定_Day1_買いWMAs2;
                cmd_InsertOrderHistory2.Parameters["Day1_買いWMAs2角度"].Value = 通貨ぺア取引状況.WMA判定_Day1_買いWMAs2角度;
                cmd_InsertOrderHistory2.Parameters["Day1_買いWMAs14"].Value = 通貨ぺア取引状況.WMA判定_Day1_買いWMAs14;
                cmd_InsertOrderHistory2.Parameters["Day1_売りWMAs2"].Value = 通貨ぺア取引状況.WMA判定_Day1_売りWMAs2;
                cmd_InsertOrderHistory2.Parameters["Day1_売りWMAs2角度"].Value = 通貨ぺア取引状況.WMA判定_Day1_売りWMAs2角度;
                cmd_InsertOrderHistory2.Parameters["Day1_売りWMAs14"].Value = 通貨ぺア取引状況.WMA判定_Day1_売りWMAs14;
                cmd_InsertOrderHistory2.Parameters["Hour1_Start"].Value = OrderData.StartHour1;
                cmd_InsertOrderHistory2.Parameters["Hour1_End"].Value = OrderData.EndHour1;
                cmd_InsertOrderHistory2.Parameters["Hour1_買いWMAs2"].Value = 通貨ぺア取引状況.WMA判定_Hour1_買いWMAs2;
                cmd_InsertOrderHistory2.Parameters["Hour1_買いWMAs2角度"].Value = 通貨ぺア取引状況.WMA判定_Hour1_買いWMAs2角度;
                cmd_InsertOrderHistory2.Parameters["Hour1_買いWMAs14"].Value = 通貨ぺア取引状況.WMA判定_Hour1_買いWMAs14;
                cmd_InsertOrderHistory2.Parameters["Hour1_売りWMAs2"].Value = 通貨ぺア取引状況.WMA判定_Hour1_売りWMAs2;
                cmd_InsertOrderHistory2.Parameters["Hour1_売りWMAs2角度"].Value = 通貨ぺア取引状況.WMA判定_Hour1_売りWMAs2角度;
                cmd_InsertOrderHistory2.Parameters["Hour1_売りWMAs14"].Value = 通貨ぺア取引状況.WMA判定_Hour1_売りWMAs14;
                cmd_InsertOrderHistory2.Parameters["Min15_Start"].Value = OrderData.StartMin15;
                cmd_InsertOrderHistory2.Parameters["Min15_End"].Value = OrderData.EndMin15;
                cmd_InsertOrderHistory2.Parameters["Min15_買いWMAs2"].Value = 通貨ぺア取引状況.WMA判定_Min15_買いWMAs2;
                cmd_InsertOrderHistory2.Parameters["Min15_買いWMAs2角度"].Value = 通貨ぺア取引状況.WMA判定_Min15_買いWMAs2角度;
                cmd_InsertOrderHistory2.Parameters["Min15_買いWMAs14"].Value = 通貨ぺア取引状況.WMA判定_Min15_買いWMAs14;
                cmd_InsertOrderHistory2.Parameters["Min15_売りWMAs2"].Value = 通貨ぺア取引状況.WMA判定_Min15_売りWMAs2;
                cmd_InsertOrderHistory2.Parameters["Min15_売りWMAs2角度"].Value = 通貨ぺア取引状況.WMA判定_Min15_売りWMAs2角度;
                cmd_InsertOrderHistory2.Parameters["Min15_売りWMAs14"].Value = 通貨ぺア取引状況.WMA判定_Min15_売りWMAs14;
                cmd_InsertOrderHistory2.Parameters["Min5_Start"].Value = OrderData.StartMin5;
                cmd_InsertOrderHistory2.Parameters["Min5_End"].Value = OrderData.EndMin5;
                cmd_InsertOrderHistory2.Parameters["Min5_買いWMAs2"].Value = 通貨ぺア取引状況.WMA判定_Min5_買いWMAs2;
                cmd_InsertOrderHistory2.Parameters["Min5_買いWMAs2角度"].Value = 通貨ぺア取引状況.WMA判定_Min5_買いWMAs2角度;
                cmd_InsertOrderHistory2.Parameters["Min5_買いWMAs14"].Value = 通貨ぺア取引状況.WMA判定_Min5_買いWMAs14;
                cmd_InsertOrderHistory2.Parameters["Min5_売りWMAs2"].Value = 通貨ぺア取引状況.WMA判定_Min5_売りWMAs2;
                cmd_InsertOrderHistory2.Parameters["Min5_売りWMAs2角度"].Value = 通貨ぺア取引状況.WMA判定_Min5_売りWMAs2角度;
                cmd_InsertOrderHistory2.Parameters["Min5_売りWMAs14"].Value = 通貨ぺア取引状況.WMA判定_Min5_売りWMAs14;
                cmd_InsertOrderHistory2.Parameters["Min1_Start"].Value = OrderData.StartMin1;
                cmd_InsertOrderHistory2.Parameters["Min1_End"].Value = OrderData.EndMin1;
                cmd_InsertOrderHistory2.Parameters["Min1_買いWMAs2"].Value = 通貨ぺア取引状況.WMA判定_Min1_買いWMAs2;
                cmd_InsertOrderHistory2.Parameters["Min1_買いWMAs2角度"].Value = 通貨ぺア取引状況.WMA判定_Min1_買いWMAs2角度;
                cmd_InsertOrderHistory2.Parameters["Min1_買いWMAs14"].Value = 通貨ぺア取引状況.WMA判定_Min1_買いWMAs14;
                cmd_InsertOrderHistory2.Parameters["Min1_売りWMAs2"].Value = 通貨ぺア取引状況.WMA判定_Min1_売りWMAs2;
                cmd_InsertOrderHistory2.Parameters["Min1_売りWMAs2角度"].Value = 通貨ぺア取引状況.WMA判定_Min1_売りWMAs2角度;
                cmd_InsertOrderHistory2.Parameters["Min1_売りWMAs14"].Value = 通貨ぺア取引状況.WMA判定_Min1_売りWMAs14;

                cmd_InsertOrderHistory2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("OrderData.now : " + OrderData.now);
                ログ.ログ書き出し("通貨ぺア取引状況.買いSwap : " + 通貨ぺア取引状況.買いSwap);
                ログ.ログ書き出し("通貨ぺア取引状況.買いWMAs14 : " + 通貨ぺア取引状況.買いWMAs14.ToString());
                ログ.ログ書き出し("通貨ぺア取引状況.売りSwap : " + 通貨ぺア取引状況.売りSwap);
                ログ.ログ書き出し("通貨ぺア取引状況.Swap判定 : " + 通貨ぺア取引状況.Swap判定);
                ログ.ログ書き出し("通貨ぺア取引状況.買いRate : " + 通貨ぺア取引状況.買いRate);
                ログ.ログ書き出し("通貨ぺア取引状況.売りRate : " + 通貨ぺア取引状況.売りRate);
                ログ.ログ書き出し("通貨ぺア取引状況.売買判定 : " + 通貨ぺア取引状況.売買判定);
                ログ.ログ書き出し("通貨ぺア取引状況.売買 : " + 通貨ぺア取引状況.売買);
                ログ.ログ書き出し("通貨ぺア取引状況.保持ポジション : " + 通貨ぺア取引状況.保持ポジション);
                ログ.ログ書き出し("通貨ぺア取引状況.買いWMAs14 : " + 通貨ぺア取引状況.買いWMAs14);
                ログ.ログ書き出し("通貨ぺア取引状況.買いWMAs14上昇角度 : " + 通貨ぺア取引状況.買いWMAs14上昇角度);
                ログ.ログ書き出し("通貨ぺア取引状況.買いWMAs14上昇角度シグマ : " + 通貨ぺア取引状況.買いWMAs14上昇角度シグマ);
                ログ.ログ書き出し("通貨ぺア取引状況.売りWMAs14 : " + 通貨ぺア取引状況.売りWMAs14);
                ログ.ログ書き出し("通貨ぺア取引状況.売りWMAs14上昇角度 : " + 通貨ぺア取引状況.売りWMAs14上昇角度);
                ログ.ログ書き出し("通貨ぺア取引状況.売りWMAs14上昇角度シグマ : " + 通貨ぺア取引状況.売りWMAs14上昇角度シグマ);
                ログ.ログ書き出し("通貨ぺア取引状況.BS_WMA判定_15m : " + 通貨ぺア取引状況.BS_WMA判定_15m);
                ログ.ログ書き出し("通貨ぺア取引状況.BS判定_15m : " + 通貨ぺア取引状況.BS判定_15m);
                ログ.ログ書き出し("通貨ぺア取引状況.BS開始 : " + 通貨ぺア取引状況.BS開始);
                ログ.ログ書き出し("通貨ぺア取引状況.BS判定_前 : " + 通貨ぺア取引状況.BS判定_前);
                ログ.ログ書き出し("通貨ぺア取引状況.BS判定_今 : " + 通貨ぺア取引状況.BS判定_今);
                ログ.ログ書き出し("通貨ぺア取引状況.注文単位 : " + 通貨ぺア取引状況.注文単位); ログ.ログ書き出し("OrderData.StartMonth1 : " + OrderData.StartMonth1);
                ログ.ログ書き出し("OrderData.EndMonth1 : " + OrderData.EndMonth1);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Month1_買いWMAs2 : " + 通貨ぺア取引状況.WMA判定_Month1_買いWMAs2);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Month1_買いWMAs2角度 : " + 通貨ぺア取引状況.WMA判定_Month1_買いWMAs2角度);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Month1_買いWMAs14 : " + 通貨ぺア取引状況.WMA判定_Month1_買いWMAs14);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Month1_売りWMAs2 : " + 通貨ぺア取引状況.WMA判定_Month1_売りWMAs2);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Month1_売りWMAs2角度 : " + 通貨ぺア取引状況.WMA判定_Month1_売りWMAs2角度);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Month1_売りWMAs14 : " + 通貨ぺア取引状況.WMA判定_Month1_売りWMAs14);
                ログ.ログ書き出し("OrderData.StartWeek1 : " + OrderData.StartWeek1);
                ログ.ログ書き出し("OrderData.EndWeek1 : " + OrderData.EndWeek1);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Week1_買いWMAs2 : " + 通貨ぺア取引状況.WMA判定_Week1_買いWMAs2);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Week1_買いWMAs2角度 : " + 通貨ぺア取引状況.WMA判定_Week1_買いWMAs2角度);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Week1_買いWMAs14 : " + 通貨ぺア取引状況.WMA判定_Week1_買いWMAs14);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Week1_売りWMAs2 : " + 通貨ぺア取引状況.WMA判定_Week1_売りWMAs2);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Week1_売りWMAs2角度 : " + 通貨ぺア取引状況.WMA判定_Week1_売りWMAs2角度);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Week1_売りWMAs14 : " + 通貨ぺア取引状況.WMA判定_Week1_売りWMAs14);
                ログ.ログ書き出し("OrderData.StartDay1 : " + OrderData.StartDay1);
                ログ.ログ書き出し("OrderData.EndDay1 : " + OrderData.EndDay1);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Day1_買いWMAs2 : " + 通貨ぺア取引状況.WMA判定_Day1_買いWMAs2);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Day1_買いWMAs2角度 : " + 通貨ぺア取引状況.WMA判定_Day1_買いWMAs2角度);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Day1_買いWMAs14 : " + 通貨ぺア取引状況.WMA判定_Day1_買いWMAs14);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Day1_売りWMAs2 : " + 通貨ぺア取引状況.WMA判定_Day1_売りWMAs2);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Day1_売りWMAs2角度 : " + 通貨ぺア取引状況.WMA判定_Day1_売りWMAs2角度);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Day1_売りWMAs14 : " + 通貨ぺア取引状況.WMA判定_Day1_売りWMAs14);
                ログ.ログ書き出し("OrderData.StartHour1 : " + OrderData.StartHour1);
                ログ.ログ書き出し("OrderData.EndHour1 : " + OrderData.EndHour1);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Hour1_買いWMAs2 : " + 通貨ぺア取引状況.WMA判定_Hour1_買いWMAs2);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Hour1_買いWMAs2角度 : " + 通貨ぺア取引状況.WMA判定_Hour1_買いWMAs2角度);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Hour1_買いWMAs14 : " + 通貨ぺア取引状況.WMA判定_Hour1_買いWMAs14);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Hour1_売りWMAs2 : " + 通貨ぺア取引状況.WMA判定_Hour1_売りWMAs2);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Hour1_売りWMAs2角度 : " + 通貨ぺア取引状況.WMA判定_Hour1_売りWMAs2角度);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Hour1_売りWMAs14 : " + 通貨ぺア取引状況.WMA判定_Hour1_売りWMAs14);
                ログ.ログ書き出し("OrderData.StartMin15 : " + OrderData.StartMin15);
                ログ.ログ書き出し("OrderData.EndMin15 : " + OrderData.EndMin15);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Min15_買いWMAs2 : " + 通貨ぺア取引状況.WMA判定_Min15_買いWMAs2);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Min15_買いWMAs2角度 : " + 通貨ぺア取引状況.WMA判定_Min15_買いWMAs2角度);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Min15_買いWMAs14 : " + 通貨ぺア取引状況.WMA判定_Min15_買いWMAs14);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Min15_売りWMAs2 : " + 通貨ぺア取引状況.WMA判定_Min15_売りWMAs2);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Min15_売りWMAs2角度 : " + 通貨ぺア取引状況.WMA判定_Min15_売りWMAs2角度);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Min15_売りWMAs14 : " + 通貨ぺア取引状況.WMA判定_Min15_売りWMAs14);
                ログ.ログ書き出し("OrderData.StartMin5 : " + OrderData.StartMin5);
                ログ.ログ書き出し("OrderData.EndMin5 : " + OrderData.EndMin5);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Min5_買いWMAs2 : " + 通貨ぺア取引状況.WMA判定_Min5_買いWMAs2);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Min5_買いWMAs2角度 : " + 通貨ぺア取引状況.WMA判定_Min5_買いWMAs2角度);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Min5_買いWMAs14 : " + 通貨ぺア取引状況.WMA判定_Min5_買いWMAs14);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Min5_売りWMAs2 : " + 通貨ぺア取引状況.WMA判定_Min5_売りWMAs2);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Min5_売りWMAs2角度 : " + 通貨ぺア取引状況.WMA判定_Min5_売りWMAs2角度);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Min5_売りWMAs14 : " + 通貨ぺア取引状況.WMA判定_Min5_売りWMAs14);
                ログ.ログ書き出し("OrderData.StartMin1 : " + OrderData.StartMin1);
                ログ.ログ書き出し("OrderData.EndMin1 : " + OrderData.EndMin1);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Min1_買いWMAs2 : " + 通貨ぺア取引状況.WMA判定_Min1_買いWMAs2);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Min1_買いWMAs2角度 : " + 通貨ぺア取引状況.WMA判定_Min1_買いWMAs2角度);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Min1_買いWMAs14 : " + 通貨ぺア取引状況.WMA判定_Min1_買いWMAs14);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Min1_売りWMAs2 : " + 通貨ぺア取引状況.WMA判定_Min1_売りWMAs2);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Min1_売りWMAs2角度 : " + 通貨ぺア取引状況.WMA判定_Min1_売りWMAs2角度);
                ログ.ログ書き出し("通貨ぺア取引状況.WMA判定_Min1_売りWMAs14 : " + 通貨ぺア取引状況.WMA判定_Min1_売りWMAs14);
                ログ.ログ書き出し("通貨ぺア取引状況.OpenOrderID : " + (通貨ぺア取引状況.OpenOrderID == null ? "" : (string)通貨ぺア取引状況.OpenOrderID));
                throw;
            }
        }

        public static void InsertCloseHistory(byte クローズ種別, OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況, TradeData tradeData)
        {
            try
            {
                cmd_InsertCloseHistory.Parameters["口座No"].Value = FormData.口座No;
                cmd_InsertCloseHistory.Parameters["クローズ種別"].Value = クローズ種別;
                cmd_InsertCloseHistory.Parameters["ロスカット余剰金"].Value = FormData.余剰証拠金;

                if (OrderData == null)
                {
                    cmd_InsertCloseHistory.Parameters["日時"].Value = DateTime.Now;
                    cmd_InsertCloseHistory.Parameters["OrderData_StartDay1"].Value = DBNull.Value;
                    cmd_InsertCloseHistory.Parameters["OrderData_EndDay1"].Value = DBNull.Value;
                }
                else
                {
                    cmd_InsertCloseHistory.Parameters["日時"].Value = OrderData.now;
                    cmd_InsertCloseHistory.Parameters["OrderData_StartDay1"].Value = OrderData.StartDay1;
                    cmd_InsertCloseHistory.Parameters["OrderData_EndDay1"].Value = OrderData.EndDay1;
                }

                if (通貨ぺア取引状況 == null)
                {
                    cmd_InsertCloseHistory.Parameters["通貨ペアNo"].Value = DBNull.Value;
                    cmd_InsertCloseHistory.Parameters["買いSwap"].Value = DBNull.Value;
                    cmd_InsertCloseHistory.Parameters["売りSwap"].Value = DBNull.Value;
                    cmd_InsertCloseHistory.Parameters["Swap判定"].Value = DBNull.Value;
                    cmd_InsertCloseHistory.Parameters["買いRate"].Value = DBNull.Value;
                    cmd_InsertCloseHistory.Parameters["売りRate"].Value = DBNull.Value;
                    cmd_InsertCloseHistory.Parameters["売買判定"].Value = DBNull.Value;
                    cmd_InsertCloseHistory.Parameters["売買"].Value = DBNull.Value;
                    cmd_InsertCloseHistory.Parameters["保持ポジション"].Value = DBNull.Value;
                    cmd_InsertCloseHistory.Parameters["BS_WMA判定_15m"].Value = DBNull.Value;
                    cmd_InsertCloseHistory.Parameters["BS判定_15m"].Value = DBNull.Value;
                    cmd_InsertCloseHistory.Parameters["BS開始"].Value = DBNull.Value;
                    cmd_InsertCloseHistory.Parameters["BS判定_前"].Value = DBNull.Value;
                    cmd_InsertCloseHistory.Parameters["BS判定_今"].Value = DBNull.Value;
                    cmd_InsertCloseHistory.Parameters["差分リミット通常"].Value = DBNull.Value;
                    cmd_InsertCloseHistory.Parameters["差分リミットBS"].Value = DBNull.Value;
                }
                else
                {
                    cmd_InsertCloseHistory.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                    cmd_InsertCloseHistory.Parameters["買いSwap"].Value = 通貨ぺア取引状況.買いSwap;
                    cmd_InsertCloseHistory.Parameters["売りSwap"].Value = 通貨ぺア取引状況.売りSwap;
                    cmd_InsertCloseHistory.Parameters["Swap判定"].Value = 通貨ぺア取引状況.Swap判定;
                    cmd_InsertCloseHistory.Parameters["買いRate"].Value = 通貨ぺア取引状況.買いRate;
                    cmd_InsertCloseHistory.Parameters["売りRate"].Value = 通貨ぺア取引状況.売りRate;
                    cmd_InsertCloseHistory.Parameters["売買判定"].Value = 通貨ぺア取引状況.売買判定;
                    if (通貨ぺア取引状況.売買 == null) cmd_InsertCloseHistory.Parameters["売買"].Value = DBNull.Value;
                    else cmd_InsertCloseHistory.Parameters["売買"].Value = 通貨ぺア取引状況.売買;
                    cmd_InsertCloseHistory.Parameters["保持ポジション"].Value = 通貨ぺア取引状況.保持ポジション;
                    if (通貨ぺア取引状況.BS_WMA判定_15m == null) cmd_InsertCloseHistory.Parameters["BS_WMA判定_15m"].Value = DBNull.Value;
                    else cmd_InsertCloseHistory.Parameters["BS_WMA判定_15m"].Value = 通貨ぺア取引状況.BS_WMA判定_15m;
                    if (通貨ぺア取引状況.BS判定_15m == null) cmd_InsertCloseHistory.Parameters["BS判定_15m"].Value = DBNull.Value;
                    else cmd_InsertCloseHistory.Parameters["BS判定_15m"].Value = 通貨ぺア取引状況.BS判定_15m;
                    if (通貨ぺア取引状況.BS開始 == null) cmd_InsertCloseHistory.Parameters["BS開始"].Value = DBNull.Value;
                    else cmd_InsertCloseHistory.Parameters["BS開始"].Value = 通貨ぺア取引状況.BS開始;
                    if (通貨ぺア取引状況.BS判定_前 == null) cmd_InsertCloseHistory.Parameters["BS判定_前"].Value = DBNull.Value;
                    else cmd_InsertCloseHistory.Parameters["BS判定_前"].Value = 通貨ぺア取引状況.BS判定_前;
                    if (通貨ぺア取引状況.BS判定_今 == null) cmd_InsertCloseHistory.Parameters["BS判定_今"].Value = DBNull.Value;
                    else cmd_InsertCloseHistory.Parameters["BS判定_今"].Value = 通貨ぺア取引状況.BS判定_今;
                    if (通貨ぺア取引状況.差分リミット通常 == null) cmd_InsertCloseHistory.Parameters["差分リミット通常"].Value = DBNull.Value;
                    else cmd_InsertCloseHistory.Parameters["差分リミット通常"].Value = 通貨ぺア取引状況.差分リミット通常;
                    if (通貨ぺア取引状況.差分リミットBS == null) cmd_InsertCloseHistory.Parameters["差分リミットBS"].Value = DBNull.Value;
                    else cmd_InsertCloseHistory.Parameters["差分リミットBS"].Value = 通貨ぺア取引状況.差分リミットBS;
                }

                if (tradeData == null)
                {
                    cmd_InsertCloseHistory.Parameters["Oanda_TradeData_id"].Value = DBNull.Value;
                    cmd_InsertCloseHistory.Parameters["Oanda_TradeData_side"].Value = DBNull.Value;
                    cmd_InsertCloseHistory.Parameters["Oanda_TradeData_instrument"].Value = DBNull.Value;
                    cmd_InsertCloseHistory.Parameters["Oanda_TradeData_time"].Value = DBNull.Value;
                    cmd_InsertCloseHistory.Parameters["Oanda_TradeData_price"].Value = DBNull.Value;
                    cmd_InsertCloseHistory.Parameters["Oanda_TradeData_units"].Value = DBNull.Value;
                    cmd_InsertCloseHistory.Parameters["Oanda_TradeData_takeProfit"].Value = DBNull.Value;
                    cmd_InsertCloseHistory.Parameters["Oanda_TradeData_stopLoss"].Value = DBNull.Value;
                    cmd_InsertCloseHistory.Parameters["Oanda_TradeData_trailingStop"].Value = DBNull.Value;
                    cmd_InsertCloseHistory.Parameters["Oanda_TradeData_trailingAmount"].Value = DBNull.Value;
                }
                else
                {
                    cmd_InsertCloseHistory.Parameters["Oanda_TradeData_id"].Value = tradeData.id;
                    cmd_InsertCloseHistory.Parameters["Oanda_TradeData_side"].Value = tradeData.side;
                    cmd_InsertCloseHistory.Parameters["Oanda_TradeData_instrument"].Value = tradeData.instrument;
                    cmd_InsertCloseHistory.Parameters["Oanda_TradeData_time"].Value = tradeData.time;
                    cmd_InsertCloseHistory.Parameters["Oanda_TradeData_price"].Value = tradeData.price;
                    cmd_InsertCloseHistory.Parameters["Oanda_TradeData_units"].Value = tradeData.units;
                    cmd_InsertCloseHistory.Parameters["Oanda_TradeData_takeProfit"].Value = tradeData.takeProfit;
                    cmd_InsertCloseHistory.Parameters["Oanda_TradeData_stopLoss"].Value = tradeData.stopLoss;
                    cmd_InsertCloseHistory.Parameters["Oanda_TradeData_trailingStop"].Value = tradeData.trailingStop;
                    cmd_InsertCloseHistory.Parameters["Oanda_TradeData_trailingAmount"].Value = tradeData.trailingAmount;
                }

                cmd_InsertCloseHistory.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("クローズ種別 : " + クローズ種別);
                ログ.ログ書き出し("ロスカット余剰金 : " + FormData.余剰証拠金);

                if (OrderData != null)
                {
                    ログ.ログ書き出し("日時 : " + OrderData.now);
                    ログ.ログ書き出し("OrderData_StartDay1 : " + OrderData.StartDay1);
                    ログ.ログ書き出し("OrderData_EndDay1 : " + OrderData.EndDay1);
                }

                if (通貨ぺア取引状況 != null)
                {
                    ログ.ログ書き出し("通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo);
                    ログ.ログ書き出し("買いSwap : " + 通貨ぺア取引状況.買いSwap);
                    ログ.ログ書き出し("売りSwap : " + 通貨ぺア取引状況.売りSwap);
                    ログ.ログ書き出し("Swap判定 : " + 通貨ぺア取引状況.Swap判定);
                    ログ.ログ書き出し("買いRate : " + 通貨ぺア取引状況.買いRate);
                    ログ.ログ書き出し("売りRate : " + 通貨ぺア取引状況.売りRate);
                    ログ.ログ書き出し("売買判定 : " + 通貨ぺア取引状況.売買判定);
                    if (通貨ぺア取引状況.売買 == null) ログ.ログ書き出し("売買 : null");
                    else ログ.ログ書き出し("売買 : " + 通貨ぺア取引状況.売買);
                    ログ.ログ書き出し("保持ポジション : " + 通貨ぺア取引状況.保持ポジション);
                    if (通貨ぺア取引状況.BS_WMA判定_15m == null) ログ.ログ書き出し("BS_WMA判定_15m : null");
                    else ログ.ログ書き出し("BS_WMA判定_15m : " + 通貨ぺア取引状況.BS_WMA判定_15m);
                    if (通貨ぺア取引状況.BS判定_15m == null) ログ.ログ書き出し("BS判定_15m : null");
                    else ログ.ログ書き出し("BS判定_15m : " + 通貨ぺア取引状況.BS判定_15m);
                    if (通貨ぺア取引状況.BS開始 == null) ログ.ログ書き出し("BS開始 : null");
                    else ログ.ログ書き出し("BS開始 : " + 通貨ぺア取引状況.BS開始);
                    if (通貨ぺア取引状況.BS判定_前 == null) ログ.ログ書き出し("BS判定_前 : null");
                    else ログ.ログ書き出し("BS判定_前 : " + 通貨ぺア取引状況.BS判定_前);
                    if (通貨ぺア取引状況.BS判定_今 == null) ログ.ログ書き出し("BS判定_今 : null");
                    else ログ.ログ書き出し("BS判定_今 : " + 通貨ぺア取引状況.BS判定_今);
                    if (通貨ぺア取引状況.差分リミット通常 == null) ログ.ログ書き出し("差分リミット通常 : null");
                    else ログ.ログ書き出し("差分リミット通常 : " + 通貨ぺア取引状況.差分リミット通常);
                    if (通貨ぺア取引状況.差分リミットBS == null) ログ.ログ書き出し("差分リミットBS : null");
                    else ログ.ログ書き出し("差分リミットBS : " + 通貨ぺア取引状況.差分リミットBS);
                }

                if (tradeData != null)
                {
                    ログ.ログ書き出し("Oanda_TradeData_id : " + tradeData.id);
                    ログ.ログ書き出し("Oanda_TradeData_side : " + tradeData.side);
                    ログ.ログ書き出し("Oanda_TradeData_instrument : " + tradeData.instrument);
                    ログ.ログ書き出し("Oanda_TradeData_time : " + tradeData.time);
                    ログ.ログ書き出し("Oanda_TradeData_price : " + tradeData.price);
                    ログ.ログ書き出し("Oanda_TradeData_units : " + tradeData.units);
                    ログ.ログ書き出し("Oanda_TradeData_takeProfit : " + tradeData.takeProfit);
                    ログ.ログ書き出し("Oanda_TradeData_stopLoss : " + tradeData.stopLoss);
                    ログ.ログ書き出し("Oanda_TradeData_trailingStop : " + tradeData.trailingStop);
                    ログ.ログ書き出し("Oanda_TradeData_trailingAmount : " + tradeData.trailingAmount);
                }

                throw;
            }
        }

    }
}
