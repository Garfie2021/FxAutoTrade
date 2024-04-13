using System;
using System.Data;
using System.Data.SqlClient;
using 定数;
using 共通Data;

namespace DB
{
    public static class temp
    {
        private static SqlCommand cmd_FillBy差益_SortCloseTradeTmp;
        private static SqlCommand cmd_DeleteAll_SortCloseTradeTmp;
        private static SqlCommand cmd_InsertSortCloseTradeTmp;
        private static SqlCommand cmd_InsertSortTmp;

        public static void SqlCommandInitialize(SqlConnection cn)
        {
            cmd_FillBy差益_SortCloseTradeTmp = new SqlCommand("temp.spFillBy差益_SortCloseTradeTmp", cn);
            cmd_FillBy差益_SortCloseTradeTmp.CommandType = CommandType.StoredProcedure;
            //cmd_FillBy差益_SortCloseTradeTmp.CommandTimeout = DB定数.CommandTimeout;
            cmd_FillBy差益_SortCloseTradeTmp.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_FillBy差益_SortCloseTradeTmp.Parameters["口座No"].Direction = ParameterDirection.Input;

            cmd_DeleteAll_SortCloseTradeTmp = new SqlCommand("temp.spDeleteAll_SortCloseTradeTmp", cn);
            cmd_DeleteAll_SortCloseTradeTmp.CommandType = CommandType.StoredProcedure;
            //cmd_DeleteAll_SortCloseTradeTmp.CommandTimeout = DB定数.CommandTimeout;
            cmd_DeleteAll_SortCloseTradeTmp.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_DeleteAll_SortCloseTradeTmp.Parameters["口座No"].Direction = ParameterDirection.Input;

            cmd_InsertSortCloseTradeTmp = new SqlCommand("temp.spInsertSortCloseTradeTmp", cn);
            cmd_InsertSortCloseTradeTmp.CommandType = CommandType.StoredProcedure;
            //cmd_InsertSortCloseTradeTmp.CommandTimeout = DB定数.CommandTimeout;
            cmd_InsertSortCloseTradeTmp.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_InsertSortCloseTradeTmp.Parameters["口座No"].Direction = ParameterDirection.Input;
            cmd_InsertSortCloseTradeTmp.Parameters.Add(new SqlParameter("Time", SqlDbType.DateTime));
            cmd_InsertSortCloseTradeTmp.Parameters["Time"].Direction = ParameterDirection.Input;
            cmd_InsertSortCloseTradeTmp.Parameters.Add(new SqlParameter("sTradeID", SqlDbType.VarChar));
            cmd_InsertSortCloseTradeTmp.Parameters["sTradeID"].Direction = ParameterDirection.Input;
            cmd_InsertSortCloseTradeTmp.Parameters.Add(new SqlParameter("差益", SqlDbType.Float));
            cmd_InsertSortCloseTradeTmp.Parameters["差益"].Direction = ParameterDirection.Input;
            cmd_InsertSortCloseTradeTmp.Parameters.Add(new SqlParameter("iAmount", SqlDbType.Int));
            cmd_InsertSortCloseTradeTmp.Parameters["iAmount"].Direction = ParameterDirection.Input;
            cmd_InsertSortCloseTradeTmp.Parameters.Add(new SqlParameter("dRate", SqlDbType.Float));
            cmd_InsertSortCloseTradeTmp.Parameters["dRate"].Direction = ParameterDirection.Input;
            cmd_InsertSortCloseTradeTmp.Parameters.Add(new SqlParameter("sQuoteID", SqlDbType.VarChar));
            cmd_InsertSortCloseTradeTmp.Parameters["sQuoteID"].Direction = ParameterDirection.Input;

            cmd_InsertSortTmp = new SqlCommand("temp.spInsertSortTmp", cn);
            cmd_InsertSortTmp.CommandType = CommandType.StoredProcedure;
            //cmd_InsertSortTmp.CommandTimeout = DB定数.CommandTimeout;
            cmd_InsertSortTmp.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_InsertSortTmp.Parameters["口座No"].Direction = ParameterDirection.Input;
            cmd_InsertSortTmp.Parameters.Add(new SqlParameter("通貨ペア", SqlDbType.VarChar));
            cmd_InsertSortTmp.Parameters["通貨ペア"].Direction = ParameterDirection.Input;
            cmd_InsertSortTmp.Parameters.Add(new SqlParameter("値", SqlDbType.Float));
            cmd_InsertSortTmp.Parameters["値"].Direction = ParameterDirection.Input;
        }

        public static void FillBy差益_SortCloseTradeTmp(string sTradeID, int iAmount, double dRate, string sQuoteID)
        {
            try
            {
                cmd_FillBy差益_SortCloseTradeTmp.Parameters["口座No"].Value = FormData.口座No;

                using (var reader = cmd_FillBy差益_SortCloseTradeTmp.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sTradeID = (string)reader[0];
                        iAmount = (int)reader[1];
                        dRate = (double)reader[2];
                        sQuoteID = (string)reader[3];
                    }
                }
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                throw;
            }
        }

        public static void DeleteAll_SortCloseTradeTmp()
        {
            try
            {
                cmd_DeleteAll_SortCloseTradeTmp.Parameters["口座No"].Value = FormData.口座No;

                cmd_DeleteAll_SortCloseTradeTmp.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                throw;
            }
        }

        public static void InsertSortCloseTradeTmp(DateTime Time, string sTradeID, double 差益, int iAmount, double dRate, string sQuoteID)
        {
            try
            {
                cmd_InsertSortCloseTradeTmp.Parameters["口座No"].Value = FormData.口座No;
                cmd_InsertSortCloseTradeTmp.Parameters["Time"].Value = Time;
                cmd_InsertSortCloseTradeTmp.Parameters["sTradeID"].Value = sTradeID;
                cmd_InsertSortCloseTradeTmp.Parameters["差益"].Value = 差益;
                cmd_InsertSortCloseTradeTmp.Parameters["iAmount"].Value = iAmount;
                cmd_InsertSortCloseTradeTmp.Parameters["dRate"].Value = dRate;
                cmd_InsertSortCloseTradeTmp.Parameters["sQuoteID"].Value = sQuoteID;

                cmd_InsertSortCloseTradeTmp.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("Time : " + Time);
                ログ.ログ書き出し("sTradeID : " + sTradeID);
                ログ.ログ書き出し("差益 : " + 差益);
                ログ.ログ書き出し("iAmount : " + iAmount);
                ログ.ログ書き出し("dRate : " + dRate);
                ログ.ログ書き出し("sQuoteID : " + sQuoteID);
                throw;
            }
        }

        public static void InsertSortTmp(string 通貨ペア, double 値)
        {
            try
            {
                cmd_InsertSortTmp.Parameters["口座No"].Value = FormData.口座No;
                cmd_InsertSortTmp.Parameters["通貨ペア"].Value = 通貨ペア;
                cmd_InsertSortTmp.Parameters["値"].Value = 値;

                cmd_InsertSortTmp.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("通貨ペア " + 通貨ペア.ToString());
                ログ.ログ書き出し("値 : " + 値);
                throw;
            }
        }
    }
}
