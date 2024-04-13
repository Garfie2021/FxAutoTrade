using System;
using System.Data;
using System.Data.SqlClient;
using 定数;
using 共通Data;

namespace DB
{
    public static class pfmc
    {
        private static SqlCommand cmd_InsertポジションMin3;
        private static SqlCommand cmd_InsertポジションHourly;
        private static SqlCommand cmd_Chk出金済み;
        private static SqlCommand cmd_Insert利益_Monthly;
        private static SqlCommand cmd_Get利益Monthly;

        public static void SqlCommandInitialize(SqlConnection cn)
        {
            cmd_InsertポジションMin3 = new SqlCommand("pfmc.spInsertポジションMin3", cn);
            cmd_InsertポジションMin3.CommandType = CommandType.StoredProcedure;
            //cmd_InsertポジションMin3.CommandTimeout = DB定数.CommandTimeout;
            cmd_InsertポジションMin3.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_InsertポジションMin3.Parameters["口座No"].Direction = ParameterDirection.Input;
            cmd_InsertポジションMin3.Parameters.Add(new SqlParameter("Order数", SqlDbType.Int));
            cmd_InsertポジションMin3.Parameters["Order数"].Direction = ParameterDirection.Input;
            cmd_InsertポジションMin3.Parameters.Add(new SqlParameter("Trade数", SqlDbType.Int));
            cmd_InsertポジションMin3.Parameters["Trade数"].Direction = ParameterDirection.Input;
            cmd_InsertポジションMin3.Parameters.Add(new SqlParameter("当日注文数", SqlDbType.Int));
            cmd_InsertポジションMin3.Parameters["当日注文数"].Direction = ParameterDirection.Input;

            cmd_InsertポジションHourly = new SqlCommand("pfmc.spInsertポジションHourly", cn);
            cmd_InsertポジションHourly.CommandType = CommandType.StoredProcedure;
            //cmd_InsertポジションHourly.CommandTimeout = DB定数.CommandTimeout;
            cmd_InsertポジションHourly.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_InsertポジションHourly.Parameters["口座No"].Direction = ParameterDirection.Input;
            cmd_InsertポジションHourly.Parameters.Add(new SqlParameter("保有可能ポジション数", SqlDbType.Int));
            cmd_InsertポジションHourly.Parameters["保有可能ポジション数"].Direction = ParameterDirection.Input;
            cmd_InsertポジションHourly.Parameters.Add(new SqlParameter("決算待ちポジション数", SqlDbType.Int));
            cmd_InsertポジションHourly.Parameters["決算待ちポジション数"].Direction = ParameterDirection.Input;
            cmd_InsertポジションHourly.Parameters.Add(new SqlParameter("当日注文数", SqlDbType.Int));
            cmd_InsertポジションHourly.Parameters["当日注文数"].Direction = ParameterDirection.Input;
            cmd_InsertポジションHourly.Parameters.Add(new SqlParameter("当日約定数", SqlDbType.Int));
            cmd_InsertポジションHourly.Parameters["当日約定数"].Direction = ParameterDirection.Input;
            cmd_InsertポジションHourly.Parameters.Add(new SqlParameter("当日約定金額", SqlDbType.Float));
            cmd_InsertポジションHourly.Parameters["当日約定金額"].Direction = ParameterDirection.Input;
            cmd_InsertポジションHourly.Parameters.Add(new SqlParameter("取引証拠金", SqlDbType.Float));
            cmd_InsertポジションHourly.Parameters["取引証拠金"].Direction = ParameterDirection.Input;
            cmd_InsertポジションHourly.Parameters.Add(new SqlParameter("有効証拠金", SqlDbType.Float));
            cmd_InsertポジションHourly.Parameters["有効証拠金"].Direction = ParameterDirection.Input;
            cmd_InsertポジションHourly.Parameters.Add(new SqlParameter("維持証拠金", SqlDbType.Float));
            cmd_InsertポジションHourly.Parameters["維持証拠金"].Direction = ParameterDirection.Input;
            cmd_InsertポジションHourly.Parameters.Add(new SqlParameter("ロスカット余剰金", SqlDbType.Float));
            cmd_InsertポジションHourly.Parameters["ロスカット余剰金"].Direction = ParameterDirection.Input;
            cmd_InsertポジションHourly.Parameters.Add(new SqlParameter("余剰金の割合", SqlDbType.Float));
            cmd_InsertポジションHourly.Parameters["余剰金の割合"].Direction = ParameterDirection.Input;

            cmd_Chk出金済み = new SqlCommand("pfmc.spChk出金済み", cn);
            cmd_Chk出金済み.CommandType = CommandType.StoredProcedure;
            //cmd_Chk出金済み.CommandTimeout = DB定数.CommandTimeout;
            cmd_Chk出金済み.Parameters.Add(new SqlParameter("now", SqlDbType.DateTime));
            cmd_Chk出金済み.Parameters["now"].Direction = ParameterDirection.Input;
            cmd_Chk出金済み.Parameters.Add(new SqlParameter("現在の取引証拠金", SqlDbType.Float));
            cmd_Chk出金済み.Parameters["現在の取引証拠金"].Direction = ParameterDirection.Input;
            cmd_Chk出金済み.Parameters.Add(new SqlParameter("先月利益", SqlDbType.Float));
            cmd_Chk出金済み.Parameters["先月利益"].Direction = ParameterDirection.Input;
            cmd_Chk出金済み.Parameters.Add(new SqlParameter("出金済フラグ", SqlDbType.TinyInt));
            cmd_Chk出金済み.Parameters["出金済フラグ"].Direction = ParameterDirection.Output;

            cmd_Insert利益_Monthly = new SqlCommand("pfmc.spInsert利益Monthly", cn);
            cmd_Insert利益_Monthly.CommandType = CommandType.StoredProcedure;
            //cmd_Insert利益_Monthly.CommandTimeout = DB定数.CommandTimeout;
            cmd_Insert利益_Monthly.Parameters.Add(new SqlParameter("年月", SqlDbType.Date));
            cmd_Insert利益_Monthly.Parameters["年月"].Direction = ParameterDirection.Input;
            cmd_Insert利益_Monthly.Parameters.Add(new SqlParameter("利益確定開始日時", SqlDbType.DateTime));
            cmd_Insert利益_Monthly.Parameters["利益確定開始日時"].Direction = ParameterDirection.Input;
            cmd_Insert利益_Monthly.Parameters.Add(new SqlParameter("出金可能Percent", SqlDbType.TinyInt));
            cmd_Insert利益_Monthly.Parameters["出金可能Percent"].Direction = ParameterDirection.Input;

            cmd_Get利益Monthly = new SqlCommand("pfmc.spGet利益Monthly", cn);
            cmd_Get利益Monthly.CommandType = CommandType.StoredProcedure;
            //cmd_Get利益Monthly.CommandTimeout = DB定数.CommandTimeout;
            cmd_Get利益Monthly.Parameters.Add(new SqlParameter("年月", SqlDbType.Date));
            cmd_Get利益Monthly.Parameters["年月"].Direction = ParameterDirection.Input;
            cmd_Get利益Monthly.Parameters.Add(new SqlParameter("利益確定開始以降の利益", SqlDbType.Int));
            cmd_Get利益Monthly.Parameters["利益確定開始以降の利益"].Direction = ParameterDirection.Output;
            cmd_Get利益Monthly.Parameters.Add(new SqlParameter("出金可能額", SqlDbType.Int));
            cmd_Get利益Monthly.Parameters["出金可能額"].Direction = ParameterDirection.Output;
        }

        public static void InsertポジションMin3(int Order数, int Trade数)
        {
            try
            {
                cmd_InsertポジションMin3.Parameters["口座No"].Value = FormData.口座No;
                cmd_InsertポジションMin3.Parameters["Order数"].Value = Order数;
                cmd_InsertポジションMin3.Parameters["Trade数"].Value = Trade数;
                cmd_InsertポジションMin3.Parameters["当日注文数"].Value = FormData.当日注文数;

                cmd_InsertポジションMin3.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("FormData.txt当日注文数_Text : " + FormData.当日注文数);
                throw;
            }
        }

        public static void InsertポジションHourly()
        {
            try
            {
                cmd_InsertポジションHourly.Parameters["口座No"].Value = FormData.口座No;
                cmd_InsertポジションHourly.Parameters["保有可能ポジション数"].Value = DBNull.Value;
                cmd_InsertポジションHourly.Parameters["決算待ちポジション数"].Value = FormData.決算待ちポジション数;
                cmd_InsertポジションHourly.Parameters["当日注文数"].Value = FormData.当日注文数;
                cmd_InsertポジションHourly.Parameters["当日約定数"].Value = FormData.当日約定数;
                cmd_InsertポジションHourly.Parameters["当日約定金額"].Value = FormData.当日約定金額;
                cmd_InsertポジションHourly.Parameters["取引証拠金"].Value = FormData.取引証拠金;
                cmd_InsertポジションHourly.Parameters["有効証拠金"].Value = DBNull.Value;
                cmd_InsertポジションHourly.Parameters["維持証拠金"].Value = FormData.維持証拠金;
                cmd_InsertポジションHourly.Parameters["ロスカット余剰金"].Value = FormData.余剰証拠金;
                cmd_InsertポジションHourly.Parameters["余剰金の割合"].Value = FormData.余剰金の割合;

                cmd_InsertポジションHourly.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("FormData.txt決算待ちポジション数_Text : " + FormData.決算待ちポジション数);
                ログ.ログ書き出し("FormData.txt当日注文数_Text : " + FormData.当日注文数);
                ログ.ログ書き出し("FormData.txt当日約定数_Text : " + FormData.当日約定数);
                ログ.ログ書き出し("FormData.txt当日約定金額_Text : " + FormData.当日約定金額);
                ログ.ログ書き出し("FormData.txt取引証拠金_Text : " + FormData.取引証拠金);
                ログ.ログ書き出し("FormData.txt維持証拠金_Text : " + FormData.維持証拠金);
                ログ.ログ書き出し("FormData.txtロスカット余剰金_Text : " + FormData.余剰証拠金);
                ログ.ログ書き出し("FormData.txt余剰金の割合_Text : " + FormData.余剰金の割合);
                throw;
            }
        }

        public static byte Chk出金済み(DateTime now, double 現在の取引証拠金, double 先月利益)
        {
            try
            {
                cmd_Chk出金済み.Parameters["now"].Value = now;
                cmd_Chk出金済み.Parameters["現在の取引証拠金"].Value = 現在の取引証拠金;
                cmd_Chk出金済み.Parameters["先月利益"].Value = 先月利益;

                cmd_Chk出金済み.ExecuteNonQuery();

                return (byte)cmd_Chk出金済み.Parameters["出金済フラグ"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("now : " + now);
                ログ.ログ書き出し("現在の取引証拠金 : " + 現在の取引証拠金);
                ログ.ログ書き出し("先月利益 : " + 先月利益);
                throw;
            }
        }

        public static void Insert利益_Monthly(DateTime now, DateTime 利益確定開始日時, byte 出金可能Percent)
        {
            try
            {
                cmd_Insert利益_Monthly.Parameters["年月"].Value = DateTime.Parse(now.Year.ToString() + "/" + now.Month.ToString() + "/1");
                cmd_Insert利益_Monthly.Parameters["利益確定開始日時"].Value = 利益確定開始日時;
                cmd_Insert利益_Monthly.Parameters["出金可能Percent"].Value = 出金可能Percent;

                cmd_Insert利益_Monthly.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("DateTime.Parse(now.Year.ToString() / now.Month.ToString() / 1 : " + DateTime.Parse(now.Year.ToString() + "/" + now.Month.ToString() + "/1"));
                ログ.ログ書き出し("利益確定開始日時 : " + 利益確定開始日時);
                ログ.ログ書き出し("出金可能Percent : " + 出金可能Percent);
                throw;
            }
        }

        public static void Get利益Monthly(DateTime 年月, out int 利益確定開始以降の利益, out int 出金可能額)
        {
            try
            {
                cmd_Get利益Monthly.Parameters["年月"].Value = DateTime.Parse(年月.Year.ToString() + "/" + 年月.Month.ToString() + "/1");

                cmd_Get利益Monthly.ExecuteNonQuery();

                利益確定開始以降の利益 = (int)cmd_Get利益Monthly.Parameters["利益確定開始以降の利益"].Value;
                出金可能額 = (int)cmd_Get利益Monthly.Parameters["出金可能額"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("DateTime.Parse(年月.Year.ToString() / 年月.Month.ToString() / 1 : " + DateTime.Parse(年月.Year.ToString() + "/" + 年月.Month.ToString() + "/1"));
                throw;
            }
        }

    }
}
