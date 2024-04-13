using System;
using System.Data;
using System.Data.SqlClient;
using 定数;
using 共通Data;

namespace DB
{
    public static class cmn
    {
        private static SqlCommand cmd_Select口座;
        private static SqlCommand cmd_Get起動初期値_通貨ペア別;
        private static SqlCommand cmd_GetThisMonth1;
        private static SqlCommand cmd_GetThisWeek1;
        private static SqlCommand cmd_GetThisDay1;
        private static SqlCommand cmd_GetThisHour1;
        private static SqlCommand cmd_GetThisMin15;
        private static SqlCommand cmd_GetThisMin5;
        private static SqlCommand cmd_GetThisMin1;
        private static SqlCommand cmd_UpdateSettings;

        public static void SqlCommandInitialize(SqlConnection cn)
        {
            cmd_Select口座 = new SqlCommand("cmn.spSelect口座", cn);
            cmd_Select口座.CommandType = CommandType.StoredProcedure;
            //cmd_Select口座.CommandTimeout = DB定数.CommandTimeout;
            cmd_Select口座.Parameters.Add(new SqlParameter("口座No", SqlDbType.TinyInt));
            cmd_Select口座.Parameters["口座No"].Direction = ParameterDirection.Input;

            cmd_Get起動初期値_通貨ペア別 = new SqlCommand("cmn.spGet起動初期値_通貨ペア別", cn);
            cmd_Get起動初期値_通貨ペア別.CommandType = CommandType.StoredProcedure;
            //cmd_Get起動初期値_通貨ペア別.CommandTimeout = DB定数.CommandTimeout;
            cmd_Get起動初期値_通貨ペア別.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_Get起動初期値_通貨ペア別.Parameters.Add(new SqlParameter("通貨ペア名_Oanda", SqlDbType.VarChar));
            cmd_Get起動初期値_通貨ペア別.Parameters.Add(new SqlParameter("買い売りRate差", SqlDbType.Float));
            cmd_Get起動初期値_通貨ペア別.Parameters.Add(new SqlParameter("差分ストップ", SqlDbType.Float));
            cmd_Get起動初期値_通貨ペア別.Parameters.Add(new SqlParameter("差分リミット通常", SqlDbType.Float));
            cmd_Get起動初期値_通貨ペア別.Parameters.Add(new SqlParameter("差分リミットBS", SqlDbType.Float));
            cmd_Get起動初期値_通貨ペア別.Parameters.Add(new SqlParameter("注文禁止Rate幅", SqlDbType.Float));
            cmd_Get起動初期値_通貨ペア別.Parameters.Add(new SqlParameter("最終注文日時", SqlDbType.DateTime));
            cmd_Get起動初期値_通貨ペア別.Parameters.Add(new SqlParameter("ポジションClose最終日時", SqlDbType.DateTime));
            cmd_Get起動初期値_通貨ペア別.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_Get起動初期値_通貨ペア別.Parameters["通貨ペア名_Oanda"].Direction = ParameterDirection.Input;
            cmd_Get起動初期値_通貨ペア別.Parameters["買い売りRate差"].Direction = ParameterDirection.Output;
            cmd_Get起動初期値_通貨ペア別.Parameters["差分ストップ"].Direction = ParameterDirection.Output;
            cmd_Get起動初期値_通貨ペア別.Parameters["差分リミット通常"].Direction = ParameterDirection.Output;
            cmd_Get起動初期値_通貨ペア別.Parameters["差分リミットBS"].Direction = ParameterDirection.Output;
            cmd_Get起動初期値_通貨ペア別.Parameters["注文禁止Rate幅"].Direction = ParameterDirection.Output;
            cmd_Get起動初期値_通貨ペア別.Parameters["最終注文日時"].Direction = ParameterDirection.Output;
            cmd_Get起動初期値_通貨ペア別.Parameters["ポジションClose最終日時"].Direction = ParameterDirection.Output;

            cmd_GetThisMonth1 = new SqlCommand("cmn.spGetThisMonth1", cn);
            cmd_GetThisMonth1.CommandType = CommandType.StoredProcedure;
            //cmd_GetThisMonth1.CommandTimeout = DB定数.CommandTimeout;
            cmd_GetThisMonth1.Parameters.Add(new SqlParameter("now", SqlDbType.DateTime));
            cmd_GetThisMonth1.Parameters.Add(new SqlParameter("back_Month1", SqlDbType.Int));
            cmd_GetThisMonth1.Parameters.Add(new SqlParameter("ThisMonth1", SqlDbType.DateTime));
            cmd_GetThisMonth1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_GetThisMonth1.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
            cmd_GetThisMonth1.Parameters["StartDate"].Direction = ParameterDirection.Output;
            cmd_GetThisMonth1.Parameters["now"].Direction = ParameterDirection.Input;
            cmd_GetThisMonth1.Parameters["back_Month1"].Direction = ParameterDirection.Input;
            cmd_GetThisMonth1.Parameters["ThisMonth1"].Direction = ParameterDirection.Output;
            cmd_GetThisMonth1.Parameters["EndDate"].Direction = ParameterDirection.Output;

            cmd_GetThisWeek1 = new SqlCommand("cmn.spGetThisWeek1", cn);
            cmd_GetThisWeek1.CommandType = CommandType.StoredProcedure;
            //cmd_GetThisWeek1.CommandTimeout = DB定数.CommandTimeout;
            cmd_GetThisWeek1.Parameters.Add(new SqlParameter("now", SqlDbType.DateTime));
            cmd_GetThisWeek1.Parameters.Add(new SqlParameter("ThisWeek1", SqlDbType.DateTime));
            cmd_GetThisWeek1.Parameters.Add(new SqlParameter("back_Week1", SqlDbType.Int));
            cmd_GetThisWeek1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_GetThisWeek1.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
            cmd_GetThisWeek1.Parameters["now"].Direction = ParameterDirection.Input;
            cmd_GetThisWeek1.Parameters["back_Week1"].Direction = ParameterDirection.Input;
            cmd_GetThisWeek1.Parameters["ThisWeek1"].Direction = ParameterDirection.Output;
            cmd_GetThisWeek1.Parameters["StartDate"].Direction = ParameterDirection.Output;
            cmd_GetThisWeek1.Parameters["EndDate"].Direction = ParameterDirection.Output;

            cmd_GetThisDay1 = new SqlCommand("cmn.spGetThisDay1", cn);
            cmd_GetThisDay1.CommandType = CommandType.StoredProcedure;
            //cmd_GetThisDay1.CommandTimeout = DB定数.CommandTimeout;
            cmd_GetThisDay1.Parameters.Add(new SqlParameter("now", SqlDbType.DateTime));
            cmd_GetThisDay1.Parameters.Add(new SqlParameter("back_Day1", SqlDbType.Int));
            cmd_GetThisDay1.Parameters.Add(new SqlParameter("ThisDay1", SqlDbType.DateTime));
            cmd_GetThisDay1.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_GetThisDay1.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
            cmd_GetThisDay1.Parameters["now"].Direction = ParameterDirection.Input;
            cmd_GetThisDay1.Parameters["back_Day1"].Direction = ParameterDirection.Input;
            cmd_GetThisDay1.Parameters["ThisDay1"].Direction = ParameterDirection.Output;
            cmd_GetThisDay1.Parameters["StartDate"].Direction = ParameterDirection.Output;
            cmd_GetThisDay1.Parameters["EndDate"].Direction = ParameterDirection.Output;

            cmd_GetThisHour1 = new SqlCommand("cmn.spGetThisHour1", cn);
            cmd_GetThisHour1.CommandType = CommandType.StoredProcedure;
            //cmd_GetThisHour1.CommandTimeout = DB定数.CommandTimeout;
            cmd_GetThisHour1.Parameters.Add(new SqlParameter("now", SqlDbType.DateTime));
            cmd_GetThisHour1.Parameters.Add(new SqlParameter("back_Hour1", SqlDbType.Int));
            cmd_GetThisHour1.Parameters.Add(new SqlParameter("StartHour1", SqlDbType.DateTime));
            cmd_GetThisHour1.Parameters.Add(new SqlParameter("EndHour1", SqlDbType.DateTime));
            cmd_GetThisHour1.Parameters["now"].Direction = ParameterDirection.Input;
            cmd_GetThisHour1.Parameters["back_Hour1"].Direction = ParameterDirection.Input;
            cmd_GetThisHour1.Parameters["StartHour1"].Direction = ParameterDirection.Output;
            cmd_GetThisHour1.Parameters["EndHour1"].Direction = ParameterDirection.Output;

            cmd_GetThisMin15 = new SqlCommand("cmn.spGetThisMin15", cn);
            cmd_GetThisMin15.CommandType = CommandType.StoredProcedure;
            //cmd_GetThisMin15.CommandTimeout = DB定数.CommandTimeout;
            cmd_GetThisMin15.Parameters.Add(new SqlParameter("now", SqlDbType.DateTime));
            cmd_GetThisMin15.Parameters.Add(new SqlParameter("back_Min15", SqlDbType.Int));
            cmd_GetThisMin15.Parameters.Add(new SqlParameter("StartMin15", SqlDbType.DateTime));
            cmd_GetThisMin15.Parameters.Add(new SqlParameter("EndMin15", SqlDbType.DateTime));
            cmd_GetThisMin15.Parameters["now"].Direction = ParameterDirection.Input;
            cmd_GetThisMin15.Parameters["back_Min15"].Direction = ParameterDirection.Input;
            cmd_GetThisMin15.Parameters["StartMin15"].Direction = ParameterDirection.Output;
            cmd_GetThisMin15.Parameters["EndMin15"].Direction = ParameterDirection.Output;

            cmd_GetThisMin5 = new SqlCommand("cmn.spGetThisMin5", cn);
            cmd_GetThisMin5.CommandType = CommandType.StoredProcedure;
            //cmd_GetThisMin5.CommandTimeout = DB定数.CommandTimeout;
            cmd_GetThisMin5.Parameters.Add(new SqlParameter("now", SqlDbType.DateTime));
            cmd_GetThisMin5.Parameters.Add(new SqlParameter("back_Min5", SqlDbType.Int));
            cmd_GetThisMin5.Parameters.Add(new SqlParameter("StartMin5", SqlDbType.DateTime));
            cmd_GetThisMin5.Parameters.Add(new SqlParameter("EndMin5", SqlDbType.DateTime));
            cmd_GetThisMin5.Parameters["now"].Direction = ParameterDirection.Input;
            cmd_GetThisMin5.Parameters["back_Min5"].Direction = ParameterDirection.Input;
            cmd_GetThisMin5.Parameters["StartMin5"].Direction = ParameterDirection.Output;
            cmd_GetThisMin5.Parameters["EndMin5"].Direction = ParameterDirection.Output;

            cmd_GetThisMin1 = new SqlCommand("cmn.spGetThisMin1", cn);
            cmd_GetThisMin1.CommandType = CommandType.StoredProcedure;
            //cmd_GetThisMin1.CommandTimeout = DB定数.CommandTimeout;
            cmd_GetThisMin1.Parameters.Add(new SqlParameter("now", SqlDbType.DateTime));
            cmd_GetThisMin1.Parameters.Add(new SqlParameter("back_Min1", SqlDbType.Int));
            cmd_GetThisMin1.Parameters.Add(new SqlParameter("StartMin1", SqlDbType.DateTime));
            cmd_GetThisMin1.Parameters.Add(new SqlParameter("EndMin1", SqlDbType.DateTime));
            cmd_GetThisMin1.Parameters["now"].Direction = ParameterDirection.Input;
            cmd_GetThisMin1.Parameters["back_Min1"].Direction = ParameterDirection.Input;
            cmd_GetThisMin1.Parameters["StartMin1"].Direction = ParameterDirection.Output;
            cmd_GetThisMin1.Parameters["EndMin1"].Direction = ParameterDirection.Output;

            cmd_UpdateSettings = new SqlCommand("cmn.spUpdateSettings", cn);
            cmd_UpdateSettings.CommandType = CommandType.StoredProcedure;
            //cmd_UpdateSettings.CommandTimeout = DB定数.CommandTimeout;
            cmd_UpdateSettings.Parameters.Add(new SqlParameter("No", SqlDbType.TinyInt));
            cmd_UpdateSettings.Parameters.Add(new SqlParameter("値", SqlDbType.Float));
            cmd_UpdateSettings.Parameters.Add(new SqlParameter("備考1", SqlDbType.VarChar));
            cmd_UpdateSettings.Parameters.Add(new SqlParameter("備考2", SqlDbType.VarChar));
            cmd_UpdateSettings.Parameters["No"].Direction = ParameterDirection.Input;
            cmd_UpdateSettings.Parameters["値"].Direction = ParameterDirection.Input;
            cmd_UpdateSettings.Parameters["備考1"].Direction = ParameterDirection.Input;
            cmd_UpdateSettings.Parameters["備考2"].Direction = ParameterDirection.Input;
        }

        public static void Select口座()
        {
            try
            {
                cmd_Select口座.Parameters["口座No"].Value = FormData.口座No;

                using (var reader = cmd_Select口座.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        FormData.OandaAccountId = (int)reader["OandaAccountId"];
                        FormData.OandaAccessToken = (string)reader["OandaAccessToken"];
                        FormData.FX会社 = (Company)Enum.ToObject(typeof(Company), (byte)reader["FX会社"]);
                        FormData.FxServerContry = (Contry)Enum.ToObject(typeof(Contry), (byte)reader["FxServerContry"]);
                        FormData.個人法人 = (個人法人)Enum.ToObject(typeof(個人法人), (byte)reader["個人法人"]);
                        FormData.DemoReal = (DemoReal)Enum.ToObject(typeof(DemoReal), (byte)reader["DemoReal"]);
                        FormData.有効無効 = (有効無効)Enum.ToObject(typeof(有効無効), (byte)reader["有効無効"]);
                        if (reader["取引証拠金上限"] == DBNull.Value) FormData.取引証拠金上限 = null;
                        else FormData.取引証拠金上限 = (int)reader["取引証拠金上限"];
                        FormData.毎朝の自動注文開始を行う = (毎朝の自動注文開始を行う)Enum.ToObject(typeof(毎朝の自動注文開始を行う), (byte)reader["毎朝の自動注文開始を行う"]);
                    }
                }
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                throw;
            }
        }

        /// <summary>
        /// 起動起動
        /// </summary>
        /// <param name="通貨ぺア取引状況"></param>
        public static void Get起動初期値_通貨ペア別(通貨ぺア取引状況 通貨ぺア取引状況)
        {
            try
            {
                cmd_Get起動初期値_通貨ペア別.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_Get起動初期値_通貨ペア別.Parameters["通貨ペア名_Oanda"].Value = 通貨ぺア取引状況.Instrument2;

                cmd_Get起動初期値_通貨ペア別.ExecuteNonQuery();

                通貨ぺア取引状況.買い売りRate差 = (double?)cmd_Get起動初期値_通貨ペア別.Parameters["買い売りRate差"].Value;
                通貨ぺア取引状況.差分ストップ = (double?)cmd_Get起動初期値_通貨ペア別.Parameters["差分ストップ"].Value;
                通貨ぺア取引状況.差分リミット通常 = (double?)cmd_Get起動初期値_通貨ペア別.Parameters["差分リミット通常"].Value;
                通貨ぺア取引状況.差分リミットBS = (double?)cmd_Get起動初期値_通貨ペア別.Parameters["差分リミットBS"].Value;
                通貨ぺア取引状況.注文禁止Rate幅 = (double?)cmd_Get起動初期値_通貨ペア別.Parameters["注文禁止Rate幅"].Value;
                通貨ぺア取引状況.注文禁止Rate幅_基準値 = 通貨ぺア取引状況.注文禁止Rate幅;
                //通貨ぺア取引状況.差分リミット = cmd_Get起動初期値_通貨ペア別.Parameters["差分リミット"].Value == DBNull.Value ? null : (double?)cmd_Get起動初期値_通貨ペア別.Parameters["差分リミット"].Value;

                if (cmd_Get起動初期値_通貨ペア別.Parameters["最終注文日時"].Value == DBNull.Value)
                {
                    通貨ぺア取引状況.最終注文日時 = DateTime.MinValue;
                }
                else
                {
                    通貨ぺア取引状況.最終注文日時 = (DateTime)cmd_Get起動初期値_通貨ペア別.Parameters["最終注文日時"].Value;
                }

                if (cmd_Get起動初期値_通貨ペア別.Parameters["ポジションClose最終日時"].Value == DBNull.Value)
                {
                    通貨ぺア取引状況.ポジションClose最終日時 = DateTime.MinValue;
                }
                else
                {
                    通貨ぺア取引状況.ポジションClose最終日時 = (DateTime)cmd_Get起動初期値_通貨ペア別.Parameters["ポジションClose最終日時"].Value;
                }
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                throw;
            }
        }

        public static void GetThisMonth1(OrderData OrderData)
        {
            try
            {
                cmd_GetThisMonth1.Parameters["now"].Value = OrderData.now;
                cmd_GetThisMonth1.Parameters["back_Month1"].Value = 0;

                cmd_GetThisMonth1.ExecuteNonQuery();

                OrderData.StartMonth1 = (DateTime)cmd_GetThisMonth1.Parameters["StartDate"].Value;
                OrderData.EndMonth1 = (DateTime)cmd_GetThisMonth1.Parameters["EndDate"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("OrderData.now " + OrderData.now.ToString());

                throw;
            }
        }

        public static void GetThisWeek1(OrderData OrderData)
        {
            try
            {
                cmd_GetThisWeek1.Parameters["now"].Value = OrderData.now;
                cmd_GetThisWeek1.Parameters["back_Week1"].Value = 0;

                cmd_GetThisWeek1.ExecuteNonQuery();

                OrderData.StartWeek1 = (DateTime)cmd_GetThisWeek1.Parameters["StartDate"].Value;
                OrderData.EndWeek1 = (DateTime)cmd_GetThisWeek1.Parameters["EndDate"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("OrderData.now " + OrderData.now.ToString());
                throw;
            }
        }

        public static void GetThisDay1(OrderData OrderData)
        {
            try
            {
                cmd_GetThisDay1.Parameters["now"].Value = OrderData.now;
                cmd_GetThisDay1.Parameters["back_Day1"].Value = 0;

                cmd_GetThisDay1.ExecuteNonQuery();

                OrderData.StartDay1 = (DateTime)cmd_GetThisDay1.Parameters["StartDate"].Value;
                OrderData.EndDay1 = (DateTime)cmd_GetThisDay1.Parameters["EndDate"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("OrderData.now " + OrderData.now.ToString());
                throw;
            }
        }

        public static void GetThisHour1(OrderData OrderData)
        {
            try
            {
                cmd_GetThisHour1.Parameters["now"].Value = OrderData.now;
                cmd_GetThisHour1.Parameters["back_Hour1"].Value = 0;

                cmd_GetThisHour1.ExecuteNonQuery();

                OrderData.StartHour1 = (DateTime)cmd_GetThisHour1.Parameters["StartHour1"].Value;
                OrderData.EndHour1 = (DateTime)cmd_GetThisHour1.Parameters["EndHour1"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("OrderData.now " + OrderData.now.ToString());
                throw;
            }
        }

        public static void GetThisMin15(OrderData OrderData)
        {
            try
            {
                cmd_GetThisMin15.Parameters["now"].Value = OrderData.now;
                cmd_GetThisMin15.Parameters["back_Min15"].Value = 0;

                cmd_GetThisMin15.ExecuteNonQuery();

                OrderData.StartMin15 = (DateTime)cmd_GetThisMin15.Parameters["StartMin15"].Value;
                OrderData.EndMin15 = (DateTime)cmd_GetThisMin15.Parameters["EndMin15"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("OrderData.now " + OrderData.now.ToString());
                throw;
            }
        }

        public static void GetThisMin5(OrderData OrderData)
        {
            try
            {
                cmd_GetThisMin5.Parameters["now"].Value = OrderData.now;
                cmd_GetThisMin5.Parameters["back_Min5"].Value = 0;

                cmd_GetThisMin5.ExecuteNonQuery();

                OrderData.StartMin5 = (DateTime)cmd_GetThisMin5.Parameters["StartMin5"].Value;
                OrderData.EndMin5 = (DateTime)cmd_GetThisMin5.Parameters["EndMin5"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("OrderData.now " + OrderData.now.ToString());
                throw;
            }
        }

        public static void GetThisMin1(OrderData OrderData)
        {
            try
            {
                cmd_GetThisMin1.Parameters["now"].Value = OrderData.now;
                cmd_GetThisMin1.Parameters["back_Min1"].Value = 0;

                cmd_GetThisMin1.ExecuteNonQuery();

                OrderData.StartMin1 = (DateTime)cmd_GetThisMin1.Parameters["StartMin1"].Value;
                OrderData.EndMin1 = (DateTime)cmd_GetThisMin1.Parameters["EndMin1"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("OrderData.now " + OrderData.now.ToString());
                throw;
            }
        }

        public static void UpdateSettings(OrderData OrderData, byte No, string 備考1, string 備考2, double 値)
        {
            try
            {
                cmd_UpdateSettings.Parameters["now"].Value = OrderData.now;
                cmd_UpdateSettings.Parameters["値"].Value = 値;
                cmd_UpdateSettings.Parameters["備考1"].Value = 備考1;
                cmd_UpdateSettings.Parameters["備考2"].Value = 備考2;

                cmd_UpdateSettings.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("OrderData.now " + OrderData.now.ToString());
                throw;
            }
        }
    }
}
