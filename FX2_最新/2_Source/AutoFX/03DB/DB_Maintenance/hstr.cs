using System;
using System.Data;
using System.Data.SqlClient;
using 定数;
using 共通Data;

namespace DB_Maintenance
{
    public static class hstr
    {
        private static SqlCommand cmd;

        private static SqlCommand cmd_CntSec_通貨ペアNo_StartDate;
        private static SqlCommand cmd_CntMin1_通貨ペアNo_StartDate;
        private static SqlCommand cmd_CntMin5_通貨ペアNo_StartDate;
        private static SqlCommand cmd_CntMin15_通貨ペアNo_StartDate;
        private static SqlCommand cmd_CntHour1_通貨ペアNo_StartDate;
        private static SqlCommand cmd_CntDay1_通貨ペアNo_StartDate;
        private static SqlCommand cmd_CntWeek1_通貨ペアNo_StartDate;
        private static SqlCommand cmd_CntMonth1_通貨ペアNo_StartDate;


        public static int CntSec_通貨ペアNo_StartDate(SqlConnection cn, int 通貨ペアNo, DateTime StartDate, DateTime EndDate)
        {
            cmd_CntSec_通貨ペアNo_StartDate = new SqlCommand("hstr.spCntSec_通貨ペアNo_StartDate", cn);
            cmd_CntSec_通貨ペアNo_StartDate.CommandType = CommandType.StoredProcedure;
            cmd_CntSec_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_CntSec_通貨ペアNo_StartDate.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_CntSec_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_CntSec_通貨ペアNo_StartDate.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_CntSec_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
            cmd_CntSec_通貨ペアNo_StartDate.Parameters["EndDate"].Direction = ParameterDirection.Input;
            cmd_CntSec_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("Cnt", SqlDbType.Int));
            cmd_CntSec_通貨ペアNo_StartDate.Parameters["Cnt"].Direction = ParameterDirection.Output;

            cmd_CntSec_通貨ペアNo_StartDate.Parameters["通貨ペアNo"].Value = 通貨ペアNo;
            cmd_CntSec_通貨ペアNo_StartDate.Parameters["StartDate"].Value = StartDate;
            cmd_CntSec_通貨ペアNo_StartDate.Parameters["EndDate"].Value = EndDate;

            cmd_CntSec_通貨ペアNo_StartDate.ExecuteNonQuery();

            return (int)cmd_CntSec_通貨ペアNo_StartDate.Parameters["Cnt"].Value;
        }

        public static int CntMin1_通貨ペアNo_StartDate(SqlConnection cn, int 通貨ペアNo, DateTime StartDate, DateTime EndDate)
        {
            cmd_CntMin1_通貨ペアNo_StartDate = new SqlCommand("hstr.spCntMin1_通貨ペアNo_StartDate", cn);
            cmd_CntMin1_通貨ペアNo_StartDate.CommandType = CommandType.StoredProcedure;
            cmd_CntMin1_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_CntMin1_通貨ペアNo_StartDate.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_CntMin1_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_CntMin1_通貨ペアNo_StartDate.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_CntMin1_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
            cmd_CntMin1_通貨ペアNo_StartDate.Parameters["EndDate"].Direction = ParameterDirection.Input;
            cmd_CntMin1_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("Cnt", SqlDbType.Int));
            cmd_CntMin1_通貨ペアNo_StartDate.Parameters["Cnt"].Direction = ParameterDirection.Output;

            cmd_CntMin1_通貨ペアNo_StartDate.Parameters["通貨ペアNo"].Value = 通貨ペアNo;
            cmd_CntMin1_通貨ペアNo_StartDate.Parameters["StartDate"].Value = StartDate;
            cmd_CntMin1_通貨ペアNo_StartDate.Parameters["EndDate"].Value = EndDate;

            cmd_CntMin1_通貨ペアNo_StartDate.ExecuteNonQuery();

            return (int)cmd_CntMin1_通貨ペアNo_StartDate.Parameters["Cnt"].Value;
        }

        public static int CntMin5_通貨ペアNo_StartDate(SqlConnection cn, int 通貨ペアNo, DateTime StartDate, DateTime EndDate)
        {
            cmd_CntMin5_通貨ペアNo_StartDate = new SqlCommand("hstr.spCntMin5_通貨ペアNo_StartDate", cn);
            cmd_CntMin5_通貨ペアNo_StartDate.CommandType = CommandType.StoredProcedure;
            cmd_CntMin5_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_CntMin5_通貨ペアNo_StartDate.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_CntMin5_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_CntMin5_通貨ペアNo_StartDate.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_CntMin5_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
            cmd_CntMin5_通貨ペアNo_StartDate.Parameters["EndDate"].Direction = ParameterDirection.Input;
            cmd_CntMin5_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("Cnt", SqlDbType.Int));
            cmd_CntMin5_通貨ペアNo_StartDate.Parameters["Cnt"].Direction = ParameterDirection.Output;

            cmd_CntMin5_通貨ペアNo_StartDate.Parameters["通貨ペアNo"].Value = 通貨ペアNo;
            cmd_CntMin5_通貨ペアNo_StartDate.Parameters["StartDate"].Value = StartDate;
            cmd_CntMin5_通貨ペアNo_StartDate.Parameters["EndDate"].Value = EndDate;

            cmd_CntMin5_通貨ペアNo_StartDate.ExecuteNonQuery();

            return (int)cmd_CntMin5_通貨ペアNo_StartDate.Parameters["Cnt"].Value;
        }

        public static int CntMin15_通貨ペアNo_StartDate(SqlConnection cn, int 通貨ペアNo, DateTime StartDate, DateTime EndDate)
        {
            cmd_CntMin15_通貨ペアNo_StartDate = new SqlCommand("hstr.spCntMin15_通貨ペアNo_StartDate", cn);
            cmd_CntMin15_通貨ペアNo_StartDate.CommandType = CommandType.StoredProcedure;
            cmd_CntMin15_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_CntMin15_通貨ペアNo_StartDate.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_CntMin15_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_CntMin15_通貨ペアNo_StartDate.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_CntMin15_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
            cmd_CntMin15_通貨ペアNo_StartDate.Parameters["EndDate"].Direction = ParameterDirection.Input;
            cmd_CntMin15_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("Cnt", SqlDbType.Int));
            cmd_CntMin15_通貨ペアNo_StartDate.Parameters["Cnt"].Direction = ParameterDirection.Output;

            cmd_CntMin15_通貨ペアNo_StartDate.Parameters["通貨ペアNo"].Value = 通貨ペアNo;
            cmd_CntMin15_通貨ペアNo_StartDate.Parameters["StartDate"].Value = StartDate;
            cmd_CntMin15_通貨ペアNo_StartDate.Parameters["EndDate"].Value = EndDate;

            cmd_CntMin15_通貨ペアNo_StartDate.ExecuteNonQuery();

            return (int)cmd_CntMin15_通貨ペアNo_StartDate.Parameters["Cnt"].Value;
        }

        public static int CntHour1_通貨ペアNo_StartDate(SqlConnection cn, int 通貨ペアNo, DateTime StartDate, DateTime EndDate, ref string log)
        {
            log += $"日時：{DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss")}  通貨ペアNo：{通貨ペアNo}  StartDate：{StartDate.ToString("yyyy/MM/dd HH:mm:ss")}  EndDate：{EndDate.ToString("yyyy/MM/dd HH:mm:ss")}\r\n";

            cmd_CntHour1_通貨ペアNo_StartDate = new SqlCommand("hstr.spCntHour1_通貨ペアNo_StartDate", cn);
            cmd_CntHour1_通貨ペアNo_StartDate.CommandType = CommandType.StoredProcedure;
            cmd_CntHour1_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_CntHour1_通貨ペアNo_StartDate.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_CntHour1_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_CntHour1_通貨ペアNo_StartDate.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_CntHour1_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
            cmd_CntHour1_通貨ペアNo_StartDate.Parameters["EndDate"].Direction = ParameterDirection.Input;
            cmd_CntHour1_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("Cnt", SqlDbType.Int));
            cmd_CntHour1_通貨ペアNo_StartDate.Parameters["Cnt"].Direction = ParameterDirection.Output;

            cmd_CntHour1_通貨ペアNo_StartDate.Parameters["通貨ペアNo"].Value = 通貨ペアNo;
            cmd_CntHour1_通貨ペアNo_StartDate.Parameters["StartDate"].Value = StartDate;
            cmd_CntHour1_通貨ペアNo_StartDate.Parameters["EndDate"].Value = EndDate;

            cmd_CntHour1_通貨ペアNo_StartDate.ExecuteNonQuery();

            return (int)cmd_CntHour1_通貨ペアNo_StartDate.Parameters["Cnt"].Value;
        }

        public static int CntDay1_通貨ペアNo_StartDate(SqlConnection cn, int 通貨ペアNo, DateTime StartDate, DateTime EndDate)
        {
            cmd_CntDay1_通貨ペアNo_StartDate = new SqlCommand("hstr.spCntDay1_通貨ペアNo_StartDate", cn);
            cmd_CntDay1_通貨ペアNo_StartDate.CommandType = CommandType.StoredProcedure;
            cmd_CntDay1_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_CntDay1_通貨ペアNo_StartDate.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_CntDay1_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_CntDay1_通貨ペアNo_StartDate.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_CntDay1_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
            cmd_CntDay1_通貨ペアNo_StartDate.Parameters["EndDate"].Direction = ParameterDirection.Input;
            cmd_CntDay1_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("Cnt", SqlDbType.Int));
            cmd_CntDay1_通貨ペアNo_StartDate.Parameters["Cnt"].Direction = ParameterDirection.Output;

            cmd_CntDay1_通貨ペアNo_StartDate.Parameters["通貨ペアNo"].Value = 通貨ペアNo;
            cmd_CntDay1_通貨ペアNo_StartDate.Parameters["StartDate"].Value = StartDate;
            cmd_CntDay1_通貨ペアNo_StartDate.Parameters["EndDate"].Value = EndDate;

            cmd_CntDay1_通貨ペアNo_StartDate.ExecuteNonQuery();

            return (int)cmd_CntDay1_通貨ペアNo_StartDate.Parameters["Cnt"].Value;
        }

        public static int CntWeek1_通貨ペアNo_StartDate(SqlConnection cn, int 通貨ペアNo, DateTime StartDate, DateTime EndDate)
        {
            cmd_CntHour1_通貨ペアNo_StartDate = new SqlCommand("hstr.spCntWeek1_通貨ペアNo_StartDate", cn);
            cmd_CntHour1_通貨ペアNo_StartDate.CommandType = CommandType.StoredProcedure;
            cmd_CntHour1_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_CntHour1_通貨ペアNo_StartDate.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_CntHour1_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_CntHour1_通貨ペアNo_StartDate.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_CntHour1_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
            cmd_CntHour1_通貨ペアNo_StartDate.Parameters["EndDate"].Direction = ParameterDirection.Input;
            cmd_CntHour1_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("Cnt", SqlDbType.Int));
            cmd_CntHour1_通貨ペアNo_StartDate.Parameters["Cnt"].Direction = ParameterDirection.Output;

            cmd_CntHour1_通貨ペアNo_StartDate.Parameters["通貨ペアNo"].Value = 通貨ペアNo;
            cmd_CntHour1_通貨ペアNo_StartDate.Parameters["StartDate"].Value = StartDate;
            cmd_CntHour1_通貨ペアNo_StartDate.Parameters["EndDate"].Value = EndDate;

            cmd_CntHour1_通貨ペアNo_StartDate.ExecuteNonQuery();

            return (int)cmd_CntHour1_通貨ペアNo_StartDate.Parameters["Cnt"].Value;
        }

        public static int CntMonth1_通貨ペアNo_StartDate(SqlConnection cn, int 通貨ペアNo, DateTime StartDate, DateTime EndDate)
        {
            cmd_CntMonth1_通貨ペアNo_StartDate = new SqlCommand("hstr.spCntMonth1_通貨ペアNo_StartDate", cn);
            cmd_CntMonth1_通貨ペアNo_StartDate.CommandType = CommandType.StoredProcedure;
            cmd_CntMonth1_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_CntMonth1_通貨ペアNo_StartDate.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_CntMonth1_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
            cmd_CntMonth1_通貨ペアNo_StartDate.Parameters["StartDate"].Direction = ParameterDirection.Input;
            cmd_CntMonth1_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("EndDate", SqlDbType.DateTime));
            cmd_CntMonth1_通貨ペアNo_StartDate.Parameters["EndDate"].Direction = ParameterDirection.Input;
            cmd_CntMonth1_通貨ペアNo_StartDate.Parameters.Add(new SqlParameter("Cnt", SqlDbType.Int));
            cmd_CntMonth1_通貨ペアNo_StartDate.Parameters["Cnt"].Direction = ParameterDirection.Output;

            cmd_CntMonth1_通貨ペアNo_StartDate.Parameters["通貨ペアNo"].Value = 通貨ペアNo;
            cmd_CntMonth1_通貨ペアNo_StartDate.Parameters["StartDate"].Value = StartDate;
            cmd_CntMonth1_通貨ペアNo_StartDate.Parameters["EndDate"].Value = EndDate;

            cmd_CntMonth1_通貨ペアNo_StartDate.ExecuteNonQuery();

            return (int)cmd_CntMonth1_通貨ペアNo_StartDate.Parameters["Cnt"].Value;
        }

        public static DataTable SelectMonth1(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate)
        {
            try
            {
                cmd = new SqlCommand("hstr.spSelectMonth1", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = DB定数.CommandTimeout;

                cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
                cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
                cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

                cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
                cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
                cmd.Parameters["StartDate"].Value = StartDate;

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
                throw;
            }
        }

        public static DataTable SelectWeek1(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate)
        {
            try
            {
                cmd = new SqlCommand("hstr.spSelectWeek1", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = DB定数.CommandTimeout;

                cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
                cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
                cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

                cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
                cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
                cmd.Parameters["StartDate"].Value = StartDate;

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
                throw;
            }
        }

        public static DataTable SelectDay1(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate)
        {
            try
            {
                cmd = new SqlCommand("hstr.spSelectDay1", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = DB定数.CommandTimeout;

                cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
                cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
                cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

                cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
                cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
                cmd.Parameters["StartDate"].Value = StartDate;

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
                throw;
            }
        }

        public static DataTable SelectHour1_Min(SqlConnection cn, byte 通貨ペアNo)
        {
            try
            {
                cmd = new SqlCommand("hstr.spSelectHour1_Min", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = DB定数.CommandTimeout;

                cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
                cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
                cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

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
                throw;
            }
        }


        public static DataTable SelectHour1(SqlConnection cn, byte 通貨ペアNo, DateTime dtFrom)
        {
            try
            {
                cmd = new SqlCommand("hstr.spSelectHour1", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = DB定数.CommandTimeout;

                cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
                cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
                cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

                cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
                cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
                cmd.Parameters["StartDate"].Value = dtFrom;

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
                throw;
            }
        }

        public static DataTable SelectHour1_Hour(SqlConnection cn, byte 通貨ペアNo, byte Hour, DateTime dtFrom)
        {
            try
            {
                cmd = new SqlCommand("hstr.spSelectHour1_Hour", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = DB定数.CommandTimeout;

                cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
                cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
                cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

                cmd.Parameters.Add(new SqlParameter("From", SqlDbType.DateTime));
                cmd.Parameters["From"].Direction = ParameterDirection.Input;
                cmd.Parameters["From"].Value = dtFrom;

                cmd.Parameters.Add(new SqlParameter("Hour", SqlDbType.TinyInt));
                cmd.Parameters["Hour"].Direction = ParameterDirection.Input;
                cmd.Parameters["Hour"].Value = Hour;

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
                throw;
            }
        }

        public static DataTable SelectBonusStage(SqlConnection cn, DateTime 開始日時, DateTime 終了日時)
        {
            try
            {
                cmd = new SqlCommand("hstr.spSelectBonusStage", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = DB定数.CommandTimeout;

                cmd.Parameters.Add(new SqlParameter("from", SqlDbType.DateTime));
                cmd.Parameters["from"].Direction = ParameterDirection.Input;
                cmd.Parameters["from"].Value = 開始日時;

                cmd.Parameters.Add(new SqlParameter("to", SqlDbType.DateTime));
                cmd.Parameters["to"].Direction = ParameterDirection.Input;
                cmd.Parameters["to"].Value = 終了日時;

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
                throw;
            }
        }

        //public static void FillBy差益_SortCloseTradeTmp(SqlConnection cn, string 日付)
        //{
        //    //try
        //    //{
        //        cmd = new SqlCommand("temp.spFillBy差益_SortCloseTradeTmp", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandTimeout = DB定数.CommandTimeout;

        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                //sTradeID = (string)dr[0];
        //                //iAmount = (int)dr[1];
        //                //dRate = (double)dr[2];
        //                //sQuoteID = (string)dr[3];
        //            }
        //        }
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    //ログ.ログ書き出し(ex);
        //    //    //ログ.ログ書き出し("cn.ConnectionString : " + cn.ConnectionString);
        //    //    throw;
        //    //}
        //}
    }
}
