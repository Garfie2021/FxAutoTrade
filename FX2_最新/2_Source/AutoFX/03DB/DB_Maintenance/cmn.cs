using System;
using System.Data;
using System.Data.SqlClient;
using 定数;
using 共通Data;

namespace DB_Maintenance
{
    public static class cmn
    {
        private static SqlCommand cmd;

        public static DataTable Select口座一覧(SqlConnection cn)
        {
            try
            {
                cmd = new SqlCommand("cmn.spSelect口座一覧", cn);
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

        public static void DeleteALL通貨ペア(SqlConnection cn)
        {
            cmd = new SqlCommand("cmn.spDeleteALL通貨ペア", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            cmd.ExecuteNonQuery();
        }

        public static void Insert通貨ペア(SqlConnection cn, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            cmd = new SqlCommand("cmn.spInsert通貨ペアMst", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;

            cmd.Parameters.Add(new SqlParameter("通貨ペア名", SqlDbType.VarChar));
            cmd.Parameters["通貨ペア名"].Direction = ParameterDirection.Input;
            cmd.Parameters["通貨ペア名"].Value = 通貨ぺア取引状況.Instrument;

            cmd.ExecuteNonQuery();
        }

        public static void Insert口座マスタ(SqlConnection cn, string OandaAccountId, string OandaAccessToken,
            Company FX会社, Contry FxServerContry, 個人法人 個人法人, DemoReal DemoReal, 有効無効 有効無効, string 取引証拠金上限,
            毎朝の自動注文開始を行う 毎朝の自動注文開始を行う)
        {
            cmd = new SqlCommand("cmn.spInsert口座マスタ", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = DB定数.CommandTimeout;

            cmd.Parameters.Add(new SqlParameter("OandaAccountId", SqlDbType.Int));
            cmd.Parameters["OandaAccountId"].Direction = ParameterDirection.Input;
            cmd.Parameters["OandaAccountId"].Value = OandaAccountId;

            cmd.Parameters.Add(new SqlParameter("OandaAccessToken", SqlDbType.VarChar));
            cmd.Parameters["OandaAccessToken"].Direction = ParameterDirection.Input;
            cmd.Parameters["OandaAccessToken"].Value = OandaAccessToken;

            cmd.Parameters.Add(new SqlParameter("FX会社", SqlDbType.TinyInt));
            cmd.Parameters["FX会社"].Direction = ParameterDirection.Input;
            cmd.Parameters["FX会社"].Value = FX会社;

            cmd.Parameters.Add(new SqlParameter("FxServerContry", SqlDbType.TinyInt));
            cmd.Parameters["FxServerContry"].Direction = ParameterDirection.Input;
            cmd.Parameters["FxServerContry"].Value = FxServerContry;

            cmd.Parameters.Add(new SqlParameter("個人法人", SqlDbType.TinyInt));
            cmd.Parameters["個人法人"].Direction = ParameterDirection.Input;
            cmd.Parameters["個人法人"].Value = 個人法人;

            cmd.Parameters.Add(new SqlParameter("DemoReal", SqlDbType.TinyInt));
            cmd.Parameters["DemoReal"].Direction = ParameterDirection.Input;
            cmd.Parameters["DemoReal"].Value = DemoReal;

            cmd.Parameters.Add(new SqlParameter("有効無効", SqlDbType.TinyInt));
            cmd.Parameters["有効無効"].Direction = ParameterDirection.Input;
            cmd.Parameters["有効無効"].Value = 有効無効;

            cmd.Parameters.Add(new SqlParameter("取引証拠金上限", SqlDbType.Int));
            cmd.Parameters["取引証拠金上限"].Direction = ParameterDirection.Input;
            if (string.IsNullOrEmpty(取引証拠金上限)) cmd.Parameters["取引証拠金上限"].Value = DBNull.Value;
            else cmd.Parameters["取引証拠金上限"].Value = int.Parse(取引証拠金上限);

            cmd.Parameters.Add(new SqlParameter("毎朝の自動注文開始を行う", SqlDbType.TinyInt));
            cmd.Parameters["毎朝の自動注文開始を行う"].Direction = ParameterDirection.Input;
            cmd.Parameters["毎朝の自動注文開始を行う"].Value = 毎朝の自動注文開始を行う;

            cmd.ExecuteNonQuery();
        }


    }
}
