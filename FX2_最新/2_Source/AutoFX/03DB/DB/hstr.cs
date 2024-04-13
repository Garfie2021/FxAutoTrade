using System;
using System.Data;
using System.Data.SqlClient;
using 定数;
using 共通Data;

namespace DB
{
    public static class hstr
    {
        private static SqlCommand cmd_Get最新Rate;
        private static SqlCommand cmd_InsertBonusStage;

        public static void SqlCommandInitialize(SqlConnection cn)
        {
            cmd_Get最新Rate = new SqlCommand("hstr.spGet最新Rate", cn);
            cmd_Get最新Rate.CommandType = CommandType.StoredProcedure;
            cmd_Get最新Rate.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_Get最新Rate.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_Get最新Rate.Parameters.Add(new SqlParameter("買いRate", SqlDbType.Float));
            cmd_Get最新Rate.Parameters["買いRate"].Direction = ParameterDirection.Output;
            cmd_Get最新Rate.Parameters.Add(new SqlParameter("売りRate", SqlDbType.Float));
            cmd_Get最新Rate.Parameters["売りRate"].Direction = ParameterDirection.Output;

            cmd_InsertBonusStage = new SqlCommand("hstr.spInsertBonusStage", cn);
            cmd_InsertBonusStage.CommandType = CommandType.StoredProcedure;
            //cmd_InsertBonusStage.CommandTimeout = DB定数.CommandTimeout;
            cmd_InsertBonusStage.Parameters.Add(new SqlParameter("日時", SqlDbType.DateTime));
            cmd_InsertBonusStage.Parameters["日時"].Direction = ParameterDirection.Input;
            cmd_InsertBonusStage.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_InsertBonusStage.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_InsertBonusStage.Parameters.Add(new SqlParameter("買いSwap", SqlDbType.Float));
            cmd_InsertBonusStage.Parameters["買いSwap"].Direction = ParameterDirection.Input;
            cmd_InsertBonusStage.Parameters.Add(new SqlParameter("売りSwap", SqlDbType.Float));
            cmd_InsertBonusStage.Parameters["売りSwap"].Direction = ParameterDirection.Input;
            cmd_InsertBonusStage.Parameters.Add(new SqlParameter("Swap判定", SqlDbType.VarChar));
            cmd_InsertBonusStage.Parameters["Swap判定"].Direction = ParameterDirection.Input;
            cmd_InsertBonusStage.Parameters.Add(new SqlParameter("買いRate", SqlDbType.Float));
            cmd_InsertBonusStage.Parameters["買いRate"].Direction = ParameterDirection.Input;
            cmd_InsertBonusStage.Parameters.Add(new SqlParameter("買いWMAs14", SqlDbType.Float));
            cmd_InsertBonusStage.Parameters["買いWMAs14"].Direction = ParameterDirection.Input;
            cmd_InsertBonusStage.Parameters.Add(new SqlParameter("買いWMAs14上昇角度", SqlDbType.Float));
            cmd_InsertBonusStage.Parameters["買いWMAs14上昇角度"].Direction = ParameterDirection.Input;
            cmd_InsertBonusStage.Parameters.Add(new SqlParameter("買いWMAs14上昇角度シグマ", SqlDbType.Float));
            cmd_InsertBonusStage.Parameters["買いWMAs14上昇角度シグマ"].Direction = ParameterDirection.Input;
            cmd_InsertBonusStage.Parameters.Add(new SqlParameter("売りRate", SqlDbType.Float));
            cmd_InsertBonusStage.Parameters["売りRate"].Direction = ParameterDirection.Input;
            cmd_InsertBonusStage.Parameters.Add(new SqlParameter("売りWMAs14", SqlDbType.Float));
            cmd_InsertBonusStage.Parameters["売りWMAs14"].Direction = ParameterDirection.Input;
            cmd_InsertBonusStage.Parameters.Add(new SqlParameter("売りWMAs14上昇角度", SqlDbType.Float));
            cmd_InsertBonusStage.Parameters["売りWMAs14上昇角度"].Direction = ParameterDirection.Input;
            cmd_InsertBonusStage.Parameters.Add(new SqlParameter("売りWMAs14上昇角度シグマ", SqlDbType.Float));
            cmd_InsertBonusStage.Parameters["売りWMAs14上昇角度シグマ"].Direction = ParameterDirection.Input;
            cmd_InsertBonusStage.Parameters.Add(new SqlParameter("BS_WMA判定_15m", SqlDbType.VarChar));
            cmd_InsertBonusStage.Parameters["BS_WMA判定_15m"].Direction = ParameterDirection.Input;
            cmd_InsertBonusStage.Parameters.Add(new SqlParameter("保持ポジション", SqlDbType.VarChar));
            cmd_InsertBonusStage.Parameters["保持ポジション"].Direction = ParameterDirection.Input;
            cmd_InsertBonusStage.Parameters.Add(new SqlParameter("BS判定_前", SqlDbType.VarChar));
            cmd_InsertBonusStage.Parameters["BS判定_前"].Direction = ParameterDirection.Input;
            cmd_InsertBonusStage.Parameters.Add(new SqlParameter("BS判定_今", SqlDbType.VarChar));
            cmd_InsertBonusStage.Parameters["BS判定_今"].Direction = ParameterDirection.Input;
        }

        
        public static void Get最新Rate(通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_Get最新Rate.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;

                cmd_Get最新Rate.ExecuteNonQuery();

                通貨ぺア取引状況.買いRate = (double)cmd_Get最新Rate.Parameters["買いRate"].Value;
                通貨ぺア取引状況.売りRate = (double)cmd_Get最新Rate.Parameters["売りRate"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("通貨ぺア取引状況.通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                throw;
            }
        }

        public static void InsertBonusStage(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_InsertBonusStage.Parameters["日時"].Value = OrderData.now;
                cmd_InsertBonusStage.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_InsertBonusStage.Parameters["買いSwap"].Value = 通貨ぺア取引状況.買いSwap;
                cmd_InsertBonusStage.Parameters["売りSwap"].Value = 通貨ぺア取引状況.売りSwap;
                cmd_InsertBonusStage.Parameters["Swap判定"].Value = 通貨ぺア取引状況.Swap判定;
                cmd_InsertBonusStage.Parameters["買いRate"].Value = 通貨ぺア取引状況.買いRate;
                if (通貨ぺア取引状況.買いWMAs14 == null) cmd_InsertBonusStage.Parameters["買いWMAs14"].Value = DBNull.Value;
                else cmd_InsertBonusStage.Parameters["買いWMAs14"].Value = 通貨ぺア取引状況.買いWMAs14;
                if (通貨ぺア取引状況.買いWMAs14上昇角度 == null) cmd_InsertBonusStage.Parameters["買いWMAs14上昇角度"].Value = DBNull.Value;
                else cmd_InsertBonusStage.Parameters["買いWMAs14上昇角度"].Value = 通貨ぺア取引状況.買いWMAs14上昇角度;
                if (通貨ぺア取引状況.買いWMAs14上昇角度シグマ == null) cmd_InsertBonusStage.Parameters["買いWMAs14上昇角度シグマ"].Value = DBNull.Value;
                else cmd_InsertBonusStage.Parameters["買いWMAs14上昇角度シグマ"].Value = 通貨ぺア取引状況.買いWMAs14上昇角度シグマ;
                cmd_InsertBonusStage.Parameters["売りRate"].Value = 通貨ぺア取引状況.売りRate;
                if (通貨ぺア取引状況.売りWMAs14 == null) cmd_InsertBonusStage.Parameters["売りWMAs14"].Value = DBNull.Value;
                else cmd_InsertBonusStage.Parameters["売りWMAs14"].Value = 通貨ぺア取引状況.売りWMAs14;
                if (通貨ぺア取引状況.売りWMAs14上昇角度 == null) cmd_InsertBonusStage.Parameters["売りWMAs14上昇角度"].Value = DBNull.Value;
                else cmd_InsertBonusStage.Parameters["売りWMAs14上昇角度"].Value = 通貨ぺア取引状況.売りWMAs14上昇角度;
                if (通貨ぺア取引状況.売りWMAs14上昇角度シグマ == null) cmd_InsertBonusStage.Parameters["売りWMAs14上昇角度シグマ"].Value = DBNull.Value;
                else cmd_InsertBonusStage.Parameters["売りWMAs14上昇角度シグマ"].Value = 通貨ぺア取引状況.売りWMAs14上昇角度シグマ;
                cmd_InsertBonusStage.Parameters["BS_WMA判定_15m"].Value = 通貨ぺア取引状況.BS_WMA判定_15m;
                cmd_InsertBonusStage.Parameters["保持ポジション"].Value = 通貨ぺア取引状況.保持ポジション;
                cmd_InsertBonusStage.Parameters["BS判定_前"].Value = 通貨ぺア取引状況.BS判定_前;
                cmd_InsertBonusStage.Parameters["BS判定_今"].Value = 通貨ぺア取引状況.BS判定_今;

                cmd_InsertBonusStage.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("OrderData.now : " + OrderData.now);
                ログ.ログ書き出し("通貨ぺア取引状況.通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("通貨ぺア取引状況.買いRate : " + 通貨ぺア取引状況.買いRate.ToString());
                ログ.ログ書き出し("通貨ぺア取引状況.買いWMAs14 : " + 通貨ぺア取引状況.買いWMAs14.ToString());
                ログ.ログ書き出し("通貨ぺア取引状況.買いWMAs14上昇角度 : " + 通貨ぺア取引状況.買いWMAs14上昇角度);
                ログ.ログ書き出し("通貨ぺア取引状況.買いWMAs14上昇角度シグマ : " + 通貨ぺア取引状況.買いWMAs14上昇角度シグマ);
                ログ.ログ書き出し("通貨ぺア取引状況.売りRate : " + 通貨ぺア取引状況.売りRate);
                ログ.ログ書き出し("通貨ぺア取引状況.売りWMAs14 : " + 通貨ぺア取引状況.売りWMAs14);
                ログ.ログ書き出し("通貨ぺア取引状況.売りWMAs14上昇角度 : " + 通貨ぺア取引状況.売りWMAs14上昇角度);
                ログ.ログ書き出し("通貨ぺア取引状況.売りWMAs14上昇角度シグマ : " + 通貨ぺア取引状況.売りWMAs14上昇角度シグマ);
                ログ.ログ書き出し("通貨ぺア取引状況.BS_WMA判定_15m : " + 通貨ぺア取引状況.BS_WMA判定_15m);
                ログ.ログ書き出し("通貨ぺア取引状況.保持ポジション : " + 通貨ぺア取引状況.保持ポジション);
                ログ.ログ書き出し("通貨ぺア取引状況.BS判定_前 : " + 通貨ぺア取引状況.BS判定_前);
                ログ.ログ書き出し("通貨ぺア取引状況.BS判定_今 : " + 通貨ぺア取引状況.BS判定_今);

                throw;
            }
        }

    }
}
