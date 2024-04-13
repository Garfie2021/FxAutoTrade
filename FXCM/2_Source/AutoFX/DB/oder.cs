using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using 定数;

namespace DB
{
	public static class oder
	{
		public static string LogPath;

		private static SqlCommand cmd;

		public static void Insert注文対象通貨ペアDaily(SqlConnection cn, DateTime StartDate, byte 通貨ペアNo)
		{
			cmd = new SqlCommand("oder.spInsert注文対象通貨ペアDaily", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
			cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
			cmd.Parameters["StartDate"].Value = StartDate;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.ExecuteNonQuery();
		}

		public static void Chkボーナスステージ_15m(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate,
			out double 買いWMAs14, ref double 買いWMAs14上昇角度シグマ, out double 売りWMAs14, ref double 売りWMAs14上昇角度シグマ,
			out string WMA判定, out string BS判定)
		{
            買いWMAs14 = 0;
            買いWMAs14上昇角度シグマ = 0;
            売りWMAs14 = 0;
            売りWMAs14上昇角度シグマ = 0;
            WMA判定 = "";
            BS判定 = "";

            try
            {
			    cmd = new SqlCommand("oder.spChkボーナスステージ15m", cn);
			    cmd.CommandType = CommandType.StoredProcedure;
			    cmd.CommandTimeout = DB定数.CommandTimeout;

			    cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			    cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			    cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			    cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
			    cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
			    cmd.Parameters["StartDate"].Value = StartDate;

			    cmd.Parameters.Add(new SqlParameter("シグマ閾値", SqlDbType.Float));
			    cmd.Parameters["シグマ閾値"].Direction = ParameterDirection.Input;
			    cmd.Parameters["シグマ閾値"].Value = FX定数.シグマ閾値;

			    cmd.Parameters.Add(new SqlParameter("買いWMAs14", SqlDbType.Float));
			    cmd.Parameters["買いWMAs14"].Direction = ParameterDirection.Output;

			    cmd.Parameters.Add(new SqlParameter("買いWMAs14上昇角度シグマ", SqlDbType.Float));
			    cmd.Parameters["買いWMAs14上昇角度シグマ"].Direction = ParameterDirection.Output;

			    cmd.Parameters.Add(new SqlParameter("売りWMAs14", SqlDbType.Float));
			    cmd.Parameters["売りWMAs14"].Direction = ParameterDirection.Output;

			    cmd.Parameters.Add(new SqlParameter("売りWMAs14上昇角度シグマ", SqlDbType.Float));
			    cmd.Parameters["売りWMAs14上昇角度シグマ"].Direction = ParameterDirection.Output;

			    cmd.Parameters.Add(new SqlParameter("WMA判定", SqlDbType.VarChar, 1));
			    cmd.Parameters["WMA判定"].Direction = ParameterDirection.Output;

			    cmd.Parameters.Add(new SqlParameter("BS判定", SqlDbType.VarChar, 1));
			    cmd.Parameters["BS判定"].Direction = ParameterDirection.Output;

			    cmd.ExecuteNonQuery();

			    File.AppendAllText(LogPath + @"\" + DateTime.Now.ToString("yyyyMMdd") + ".log", "\r\n買いWMAs14 " + cmd.Parameters["買いWMAs14"].Value.ToString(), Encoding.GetEncoding("Shift_JIS"));
			    File.AppendAllText(LogPath + @"\" + DateTime.Now.ToString("yyyyMMdd") + ".log", "\r\n売りWMAs14 " + cmd.Parameters["売りWMAs14"].Value.ToString(), Encoding.GetEncoding("Shift_JIS"));
			    File.AppendAllText(LogPath + @"\" + DateTime.Now.ToString("yyyyMMdd") + ".log", "\r\nWMA判定 " + cmd.Parameters["WMA判定"].Value.ToString(), Encoding.GetEncoding("Shift_JIS"));
			    File.AppendAllText(LogPath + @"\" + DateTime.Now.ToString("yyyyMMdd") + ".log", "\r\n買いWMAs14上昇角度シグマ " + cmd.Parameters["買いWMAs14上昇角度シグマ"].Value.ToString(), Encoding.GetEncoding("Shift_JIS"));
			    File.AppendAllText(LogPath + @"\" + DateTime.Now.ToString("yyyyMMdd") + ".log", "\r\n売りWMAs14上昇角度シグマ " + cmd.Parameters["売りWMAs14上昇角度シグマ"].Value.ToString(), Encoding.GetEncoding("Shift_JIS"));
			    File.AppendAllText(LogPath + @"\" + DateTime.Now.ToString("yyyyMMdd") + ".log", "\r\nBS判定 " + cmd.Parameters["BS判定"].Value.ToString(), Encoding.GetEncoding("Shift_JIS"));

                買いWMAs14 = cmd.Parameters["買いWMAs14"].Value == DBNull.Value ? 0 : (double)cmd.Parameters["買いWMAs14"].Value;
                売りWMAs14 = cmd.Parameters["売りWMAs14"].Value == DBNull.Value ? 0 : (double)cmd.Parameters["売りWMAs14"].Value;

			    WMA判定 = (string)cmd.Parameters["WMA判定"].Value;

			    if (WMA判定 == "B")
			    {
                    買いWMAs14上昇角度シグマ = cmd.Parameters["買いWMAs14上昇角度シグマ"].Value == DBNull.Value ? 0 : (double)cmd.Parameters["買いWMAs14上昇角度シグマ"].Value;
                }
			    else
			    {
                    売りWMAs14上昇角度シグマ = cmd.Parameters["売りWMAs14上昇角度シグマ"].Value == DBNull.Value ? 0 : (double)cmd.Parameters["売りWMAs14上昇角度シグマ"].Value;
                }

			    BS判定 = (string)cmd.Parameters["BS判定"].Value;
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
		}

		public static bool Chk直近15分以内にOrder有り(SqlConnection cn,  byte 通貨ペアNo, DateTime Now)
		{
			cmd = new SqlCommand("oder.spChkNearestOrder", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("NearestTime", SqlDbType.DateTime));
			cmd.Parameters["NearestTime"].Direction = ParameterDirection.Input;
			cmd.Parameters["NearestTime"].Value = Now.AddMinutes(-15);

			cmd.Parameters.Add(new SqlParameter("Order数", SqlDbType.TinyInt));
			cmd.Parameters["Order数"].Direction = ParameterDirection.Output;

			cmd.ExecuteNonQuery();

			if ((byte)cmd.Parameters["Order数"].Value > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static void Get売買判定_Month1(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate,
			ref double 買いWMAs2, ref double 買いWMAs14, ref double 売りWMAs2, ref double 売りWMAs14, ref string 売買判定)
		{
			cmd = new SqlCommand("oder.spGet売買判定2_Month1", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
			cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
			cmd.Parameters["StartDate"].Value = StartDate;

			cmd.Parameters.Add(new SqlParameter("買いWMAs2", SqlDbType.Float));
			cmd.Parameters["買いWMAs2"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("買いWMAs14", SqlDbType.Float));
			cmd.Parameters["買いWMAs14"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs2", SqlDbType.Float));
			cmd.Parameters["売りWMAs2"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs14", SqlDbType.Float));
			cmd.Parameters["売りWMAs14"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売買判定", SqlDbType.VarChar, 1));
			cmd.Parameters["売買判定"].Direction = ParameterDirection.Output;

			cmd.ExecuteNonQuery();

			買いWMAs2 = (double)cmd.Parameters["買いWMAs2"].Value;
			買いWMAs14 = (double)cmd.Parameters["買いWMAs14"].Value;
			売りWMAs2 = (double)cmd.Parameters["売りWMAs2"].Value;
			売りWMAs14 = (double)cmd.Parameters["売りWMAs14"].Value;
			売買判定 = (string)cmd.Parameters["売買判定"].Value;
		}

		public static void Get売買判定_Week1(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate,
			ref double 買いWMAs2, ref double 買いWMAs14, ref double 売りWMAs2, ref double 売りWMAs14, ref string 売買判定)
		{
			cmd = new SqlCommand("oder.spGet売買判定2_Week1", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.TinyInt));
			cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
			cmd.Parameters["StartDate"].Value = StartDate;

			cmd.Parameters.Add(new SqlParameter("買いWMAs2", SqlDbType.Float));
			cmd.Parameters["買いWMAs2"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("買いWMAs14", SqlDbType.Float));
			cmd.Parameters["買いWMAs14"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs2", SqlDbType.Float));
			cmd.Parameters["売りWMAs2"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs14", SqlDbType.Float));
			cmd.Parameters["売りWMAs14"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売買判定", SqlDbType.VarChar, 1));
			cmd.Parameters["売買判定"].Direction = ParameterDirection.Output;

			cmd.ExecuteNonQuery();

			買いWMAs2 = (double)cmd.Parameters["買いWMAs2"].Value;
			買いWMAs14 = (double)cmd.Parameters["買いWMAs14"].Value;
			売りWMAs2 = (double)cmd.Parameters["売りWMAs2"].Value;
			売りWMAs14 = (double)cmd.Parameters["売りWMAs14"].Value;
			売買判定 = (string)cmd.Parameters["売買判定"].Value;
		}

		public static void Get売買判定_Day1(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate,
			ref double 買いWMAs2, ref double 買いWMAs14, ref double 売りWMAs2, ref double 売りWMAs14, ref string 売買判定)
		{
			cmd = new SqlCommand("oder.spGet売買判定2_Day1", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.TinyInt));
			cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
			cmd.Parameters["StartDate"].Value = StartDate;

			cmd.Parameters.Add(new SqlParameter("買いWMAs2", SqlDbType.Float));
			cmd.Parameters["買いWMAs2"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("買いWMAs14", SqlDbType.Float));
			cmd.Parameters["買いWMAs14"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs2", SqlDbType.Float));
			cmd.Parameters["売りWMAs2"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs14", SqlDbType.Float));
			cmd.Parameters["売りWMAs14"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売買判定", SqlDbType.VarChar, 1));
			cmd.Parameters["売買判定"].Direction = ParameterDirection.Output;

			cmd.ExecuteNonQuery();

			買いWMAs2 = (double)cmd.Parameters["買いWMAs2"].Value;
			買いWMAs14 = (double)cmd.Parameters["買いWMAs14"].Value;
			売りWMAs2 = (double)cmd.Parameters["売りWMAs2"].Value;
			売りWMAs14 = (double)cmd.Parameters["売りWMAs14"].Value;
			売買判定 = (string)cmd.Parameters["売買判定"].Value;
		}

		public static void Get売買判定_Hour1(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate,
			ref double 買いWMAs2, ref double 買いWMAs14, ref double 売りWMAs2, ref double 売りWMAs14, ref string 売買判定)
		{
			cmd = new SqlCommand("oder.spGet売買判定2_Hour1", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.TinyInt));
			cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
			cmd.Parameters["StartDate"].Value = StartDate;

			cmd.Parameters.Add(new SqlParameter("買いWMAs2", SqlDbType.Float));
			cmd.Parameters["買いWMAs2"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("買いWMAs14", SqlDbType.Float));
			cmd.Parameters["買いWMAs14"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs2", SqlDbType.Float));
			cmd.Parameters["売りWMAs2"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs14", SqlDbType.Float));
			cmd.Parameters["売りWMAs14"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売買判定", SqlDbType.VarChar, 1));
			cmd.Parameters["売買判定"].Direction = ParameterDirection.Output;

			cmd.ExecuteNonQuery();

			買いWMAs2 = (double)cmd.Parameters["買いWMAs2"].Value;
			買いWMAs14 = (double)cmd.Parameters["買いWMAs14"].Value;
			売りWMAs2 = (double)cmd.Parameters["売りWMAs2"].Value;
			売りWMAs14 = (double)cmd.Parameters["売りWMAs14"].Value;
			売買判定 = (string)cmd.Parameters["売買判定"].Value;
		}

		public static void Get売買判定_Min15(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate,
			ref double 買いWMAs2, ref double 買いWMAs14, ref double 売りWMAs2, ref double 売りWMAs14, ref string 売買判定)
		{
			cmd = new SqlCommand("oder.spGet売買判定2_Min15", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.TinyInt));
			cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
			cmd.Parameters["StartDate"].Value = StartDate;

			cmd.Parameters.Add(new SqlParameter("買いWMAs2", SqlDbType.Float));
			cmd.Parameters["買いWMAs2"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("買いWMAs14", SqlDbType.Float));
			cmd.Parameters["買いWMAs14"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs2", SqlDbType.Float));
			cmd.Parameters["売りWMAs2"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs14", SqlDbType.Float));
			cmd.Parameters["売りWMAs14"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売買判定", SqlDbType.VarChar, 1));
			cmd.Parameters["売買判定"].Direction = ParameterDirection.Output;

			cmd.ExecuteNonQuery();

			買いWMAs2 = (double)cmd.Parameters["買いWMAs2"].Value;
			買いWMAs14 = (double)cmd.Parameters["買いWMAs14"].Value;
			売りWMAs2 = (double)cmd.Parameters["売りWMAs2"].Value;
			売りWMAs14 = (double)cmd.Parameters["売りWMAs14"].Value;
			売買判定 = (string)cmd.Parameters["売買判定"].Value;
		}

		public static void Get売買判定_Min5(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate,
			ref double 買いWMAs2, ref double 買いWMAs14, ref double 売りWMAs2, ref double 売りWMAs14, ref string 売買判定)
		{
			cmd = new SqlCommand("oder.spGet売買判定2_Min5", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.TinyInt));
			cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
			cmd.Parameters["StartDate"].Value = StartDate;

			cmd.Parameters.Add(new SqlParameter("買いWMAs2", SqlDbType.Float));
			cmd.Parameters["買いWMAs2"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("買いWMAs14", SqlDbType.Float));
			cmd.Parameters["買いWMAs14"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs2", SqlDbType.Float));
			cmd.Parameters["売りWMAs2"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs14", SqlDbType.Float));
			cmd.Parameters["売りWMAs14"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売買判定", SqlDbType.VarChar, 1));
			cmd.Parameters["売買判定"].Direction = ParameterDirection.Output;

			cmd.ExecuteNonQuery();

			買いWMAs2 = (double)cmd.Parameters["買いWMAs2"].Value;
			買いWMAs14 = (double)cmd.Parameters["買いWMAs14"].Value;
			売りWMAs2 = (double)cmd.Parameters["売りWMAs2"].Value;
			売りWMAs14 = (double)cmd.Parameters["売りWMAs14"].Value;
			売買判定 = (string)cmd.Parameters["売買判定"].Value;
		}

		public static void Get売買判定_Min1(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate,
			ref double 買いWMAs2, ref double 買いWMAs14, ref double 売りWMAs2, ref double 売りWMAs14, ref string 売買判定)
		{
			cmd = new SqlCommand("oder.spGet売買判定2_Min1", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.TinyInt));
			cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
			cmd.Parameters["StartDate"].Value = StartDate;

			cmd.Parameters.Add(new SqlParameter("買いWMAs2", SqlDbType.Float));
			cmd.Parameters["買いWMAs2"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("買いWMAs14", SqlDbType.Float));
			cmd.Parameters["買いWMAs14"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs2", SqlDbType.Float));
			cmd.Parameters["売りWMAs2"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs14", SqlDbType.Float));
			cmd.Parameters["売りWMAs14"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売買判定", SqlDbType.VarChar, 1));
			cmd.Parameters["売買判定"].Direction = ParameterDirection.Output;

			cmd.ExecuteNonQuery();

			買いWMAs2 = (double)cmd.Parameters["買いWMAs2"].Value;
			買いWMAs14 = (double)cmd.Parameters["買いWMAs14"].Value;
			売りWMAs2 = (double)cmd.Parameters["売りWMAs2"].Value;
			売りWMAs14 = (double)cmd.Parameters["売りWMAs14"].Value;
			売買判定 = (string)cmd.Parameters["売買判定"].Value;
		}

		public static void GetWMA_Month1(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate,
			ref double 買いWMAs2, ref double 買いWMAs14, ref double 買いWMAs2角度, 
			ref double 売りWMAs2, ref double 売りWMAs14, ref double 売りWMAs2角度)
		{
			cmd = new SqlCommand("oder.spGetWMA_Month1", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
			cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
			cmd.Parameters["StartDate"].Value = StartDate;

			cmd.Parameters.Add(new SqlParameter("買いWMAs2", SqlDbType.Float));
			cmd.Parameters["買いWMAs2"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("買いWMAs2角度", SqlDbType.Float));
			cmd.Parameters["買いWMAs2角度"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("買いWMAs14", SqlDbType.Float));
			cmd.Parameters["買いWMAs14"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs2", SqlDbType.Float));
			cmd.Parameters["売りWMAs2"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs2角度", SqlDbType.Float));
			cmd.Parameters["売りWMAs2角度"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs14", SqlDbType.Float));
			cmd.Parameters["売りWMAs14"].Direction = ParameterDirection.Output;

			cmd.ExecuteNonQuery();

			買いWMAs2 = (double)cmd.Parameters["買いWMAs2"].Value;
			買いWMAs2角度 = (double)cmd.Parameters["買いWMAs2角度"].Value;
			買いWMAs14 = (double)cmd.Parameters["買いWMAs14"].Value;
			売りWMAs2 = (double)cmd.Parameters["売りWMAs2"].Value;
			売りWMAs2角度 = (double)cmd.Parameters["売りWMAs2角度"].Value;
			売りWMAs14 = (double)cmd.Parameters["売りWMAs14"].Value;
		}

		public static void GetWMA_Week1(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate,
			ref double 買いWMAs2, ref double 買いWMAs14, ref double 買いWMAs2角度, 
			ref double 売りWMAs2, ref double 売りWMAs14, ref double 売りWMAs2角度)
		{
			cmd = new SqlCommand("oder.spGetWMA_Week1", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
			cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
			cmd.Parameters["StartDate"].Value = StartDate;

			cmd.Parameters.Add(new SqlParameter("買いWMAs2", SqlDbType.Float));
			cmd.Parameters["買いWMAs2"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("買いWMAs2角度", SqlDbType.Float));
			cmd.Parameters["買いWMAs2角度"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("買いWMAs14", SqlDbType.Float));
			cmd.Parameters["買いWMAs14"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs2", SqlDbType.Float));
			cmd.Parameters["売りWMAs2"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs2角度", SqlDbType.Float));
			cmd.Parameters["売りWMAs2角度"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs14", SqlDbType.Float));
			cmd.Parameters["売りWMAs14"].Direction = ParameterDirection.Output;

			cmd.ExecuteNonQuery();

			買いWMAs2 = (double)cmd.Parameters["買いWMAs2"].Value;
			買いWMAs2角度 = (double)cmd.Parameters["買いWMAs2角度"].Value;
			買いWMAs14 = (double)cmd.Parameters["買いWMAs14"].Value;
			売りWMAs2 = (double)cmd.Parameters["売りWMAs2"].Value;
			売りWMAs2角度 = (double)cmd.Parameters["売りWMAs2角度"].Value;
			売りWMAs14 = (double)cmd.Parameters["売りWMAs14"].Value;
		}

		public static void GetWMA_Day1(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate,
			ref double 買いWMAs2, ref double 買いWMAs14, ref double 買いWMAs2角度, 
			ref double 売りWMAs2, ref double 売りWMAs14, ref double 売りWMAs2角度)
		{
			cmd = new SqlCommand("oder.spGetWMA_Day1", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
			cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
			cmd.Parameters["StartDate"].Value = StartDate;

			cmd.Parameters.Add(new SqlParameter("買いWMAs2", SqlDbType.Float));
			cmd.Parameters["買いWMAs2"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("買いWMAs2角度", SqlDbType.Float));
			cmd.Parameters["買いWMAs2角度"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("買いWMAs14", SqlDbType.Float));
			cmd.Parameters["買いWMAs14"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs2", SqlDbType.Float));
			cmd.Parameters["売りWMAs2"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs2角度", SqlDbType.Float));
			cmd.Parameters["売りWMAs2角度"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs14", SqlDbType.Float));
			cmd.Parameters["売りWMAs14"].Direction = ParameterDirection.Output;

			cmd.ExecuteNonQuery();

			買いWMAs2 = (double)cmd.Parameters["買いWMAs2"].Value;
			買いWMAs2角度 = (double)cmd.Parameters["買いWMAs2角度"].Value;
			買いWMAs14 = (double)cmd.Parameters["買いWMAs14"].Value;
			売りWMAs2 = (double)cmd.Parameters["売りWMAs2"].Value;
			売りWMAs2角度 = (double)cmd.Parameters["売りWMAs2角度"].Value;
			売りWMAs14 = (double)cmd.Parameters["売りWMAs14"].Value;
		}

		public static void GetWMA_Hour1(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate,
			ref double 買いWMAs2, ref double 買いWMAs14, ref double 買いWMAs2角度, 
			ref double 売りWMAs2, ref double 売りWMAs14, ref double 売りWMAs2角度)
		{
			cmd = new SqlCommand("oder.spGetWMA_Hour1", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
			cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
			cmd.Parameters["StartDate"].Value = StartDate;

			cmd.Parameters.Add(new SqlParameter("買いWMAs2", SqlDbType.Float));
			cmd.Parameters["買いWMAs2"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("買いWMAs2角度", SqlDbType.Float));
			cmd.Parameters["買いWMAs2角度"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("買いWMAs14", SqlDbType.Float));
			cmd.Parameters["買いWMAs14"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs2", SqlDbType.Float));
			cmd.Parameters["売りWMAs2"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs2角度", SqlDbType.Float));
			cmd.Parameters["売りWMAs2角度"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs14", SqlDbType.Float));
			cmd.Parameters["売りWMAs14"].Direction = ParameterDirection.Output;

			cmd.ExecuteNonQuery();

			買いWMAs2 = (double)cmd.Parameters["買いWMAs2"].Value;
			買いWMAs2角度 = (double)cmd.Parameters["買いWMAs2角度"].Value;
			買いWMAs14 = (double)cmd.Parameters["買いWMAs14"].Value;
			売りWMAs2 = (double)cmd.Parameters["売りWMAs2"].Value;
			売りWMAs2角度 = (double)cmd.Parameters["売りWMAs2角度"].Value;
			売りWMAs14 = (double)cmd.Parameters["売りWMAs14"].Value;
		}

		public static void GetWMA_Min15(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate,
			ref double 買いWMAs2, ref double 買いWMAs14, ref double 買いWMAs2角度, 
			ref double 売りWMAs2, ref double 売りWMAs14, ref double 売りWMAs2角度)
		{
			cmd = new SqlCommand("oder.spGetWMA_Min15", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
			cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
			cmd.Parameters["StartDate"].Value = StartDate;

			cmd.Parameters.Add(new SqlParameter("買いWMAs2", SqlDbType.Float));
			cmd.Parameters["買いWMAs2"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("買いWMAs2角度", SqlDbType.Float));
			cmd.Parameters["買いWMAs2角度"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("買いWMAs14", SqlDbType.Float));
			cmd.Parameters["買いWMAs14"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs2", SqlDbType.Float));
			cmd.Parameters["売りWMAs2"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs2角度", SqlDbType.Float));
			cmd.Parameters["売りWMAs2角度"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs14", SqlDbType.Float));
			cmd.Parameters["売りWMAs14"].Direction = ParameterDirection.Output;

			cmd.ExecuteNonQuery();

			買いWMAs2 = (double)cmd.Parameters["買いWMAs2"].Value;
			買いWMAs2角度 = (double)cmd.Parameters["買いWMAs2角度"].Value;
			買いWMAs14 = (double)cmd.Parameters["買いWMAs14"].Value;
			売りWMAs2 = (double)cmd.Parameters["売りWMAs2"].Value;
			売りWMAs2角度 = (double)cmd.Parameters["売りWMAs2角度"].Value;
			売りWMAs14 = (double)cmd.Parameters["売りWMAs14"].Value;
		}

		public static void GetWMA_Min5(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate,
			ref double 買いWMAs2, ref double 買いWMAs14, ref double 買いWMAs2角度, 
			ref double 売りWMAs2, ref double 売りWMAs14, ref double 売りWMAs2角度)
		{
			cmd = new SqlCommand("oder.spGetWMA_Min5", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
			cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
			cmd.Parameters["StartDate"].Value = StartDate;

			cmd.Parameters.Add(new SqlParameter("買いWMAs2", SqlDbType.Float));
			cmd.Parameters["買いWMAs2"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("買いWMAs2角度", SqlDbType.Float));
			cmd.Parameters["買いWMAs2角度"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("買いWMAs14", SqlDbType.Float));
			cmd.Parameters["買いWMAs14"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs2", SqlDbType.Float));
			cmd.Parameters["売りWMAs2"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs2角度", SqlDbType.Float));
			cmd.Parameters["売りWMAs2角度"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs14", SqlDbType.Float));
			cmd.Parameters["売りWMAs14"].Direction = ParameterDirection.Output;

			cmd.ExecuteNonQuery();

			買いWMAs2 = (double)cmd.Parameters["買いWMAs2"].Value;
			買いWMAs2角度 = (double)cmd.Parameters["買いWMAs2角度"].Value;
			買いWMAs14 = (double)cmd.Parameters["買いWMAs14"].Value;
			売りWMAs2 = (double)cmd.Parameters["売りWMAs2"].Value;
			売りWMAs2角度 = (double)cmd.Parameters["売りWMAs2角度"].Value;
			売りWMAs14 = (double)cmd.Parameters["売りWMAs14"].Value;
		}

		public static void GetWMA_Min1(SqlConnection cn, byte 通貨ペアNo, DateTime StartDate,
			ref double 買いWMAs2, ref double 買いWMAs14, ref double 買いWMAs2角度, 
			ref double 売りWMAs2, ref double 売りWMAs14, ref double 売りWMAs2角度)
		{
			cmd = new SqlCommand("oder.spGetWMA_Min1", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("StartDate", SqlDbType.DateTime));
			cmd.Parameters["StartDate"].Direction = ParameterDirection.Input;
			cmd.Parameters["StartDate"].Value = StartDate;

			cmd.Parameters.Add(new SqlParameter("買いWMAs2", SqlDbType.Float));
			cmd.Parameters["買いWMAs2"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("買いWMAs2角度", SqlDbType.Float));
			cmd.Parameters["買いWMAs2角度"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("買いWMAs14", SqlDbType.Float));
			cmd.Parameters["買いWMAs14"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs2", SqlDbType.Float));
			cmd.Parameters["売りWMAs2"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs2角度", SqlDbType.Float));
			cmd.Parameters["売りWMAs2角度"].Direction = ParameterDirection.Output;

			cmd.Parameters.Add(new SqlParameter("売りWMAs14", SqlDbType.Float));
			cmd.Parameters["売りWMAs14"].Direction = ParameterDirection.Output;

			cmd.ExecuteNonQuery();

			買いWMAs2 = (double)cmd.Parameters["買いWMAs2"].Value;
			買いWMAs2角度 = (double)cmd.Parameters["買いWMAs2角度"].Value;
			買いWMAs14 = (double)cmd.Parameters["買いWMAs14"].Value;
			売りWMAs2 = (double)cmd.Parameters["売りWMAs2"].Value;
			売りWMAs2角度 = (double)cmd.Parameters["売りWMAs2角度"].Value;
			売りWMAs14 = (double)cmd.Parameters["売りWMAs14"].Value;
		}

		public static bool Chk直近n分以内にボーナスステージ終了有り(SqlConnection cn, byte 通貨ペアNo, DateTime n分前)
		{
			cmd = new SqlCommand("oder.spChk直近n分以内にボーナスステージ終了有り", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("n分前", SqlDbType.DateTime));
			cmd.Parameters["n分前"].Direction = ParameterDirection.Input;
			cmd.Parameters["n分前"].Value = n分前;

			cmd.Parameters.Add(new SqlParameter("判定", SqlDbType.TinyInt));
			cmd.Parameters["判定"].Direction = ParameterDirection.Output;

			cmd.ExecuteNonQuery();

			if (byte.Parse(cmd.Parameters["判定"].Value.ToString()) == 1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static void UpdateOrderHistory_OrderId(SqlConnection cn, byte 通貨ペアNo, DateTime 日時, string OpenOrderID)
		{
			if (OpenOrderID == "")
				return;

			cmd = new SqlCommand("oder.spUpdateOrderHistory_OrderId", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("日時", SqlDbType.DateTime));
			cmd.Parameters["日時"].Direction = ParameterDirection.Input;
			cmd.Parameters["日時"].Value = 日時;

			cmd.Parameters.Add(new SqlParameter("OpenOrderID", SqlDbType.VarChar));
			cmd.Parameters["OpenOrderID"].Direction = ParameterDirection.Input;
			cmd.Parameters["OpenOrderID"].Value = OpenOrderID;

			cmd.ExecuteNonQuery();
		}

		public static void InsertOrderHistory(SqlConnection cn, byte 通貨ペアNo, DateTime 日時, bool 売買判定, double 買いSwap, double 売りSwap,
			double 買いRate, double 売りRate, double リミット, int 注文単位, bool BS開始)
		{
			cmd = new SqlCommand("oder.spInsertOrderHistory", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("日時", SqlDbType.DateTime));
			cmd.Parameters["日時"].Direction = ParameterDirection.Input;
			cmd.Parameters["日時"].Value = 日時;

			cmd.Parameters.Add(new SqlParameter("売買判定", SqlDbType.Bit));
			cmd.Parameters["売買判定"].Direction = ParameterDirection.Input;
			cmd.Parameters["売買判定"].Value = 売買判定;

			cmd.Parameters.Add(new SqlParameter("買いSwap", SqlDbType.Float));
			cmd.Parameters["買いSwap"].Direction = ParameterDirection.Input;
			cmd.Parameters["買いSwap"].Value = 買いSwap;

			cmd.Parameters.Add(new SqlParameter("売りSwap", SqlDbType.Float));
			cmd.Parameters["売りSwap"].Direction = ParameterDirection.Input;
			cmd.Parameters["売りSwap"].Value = 売りSwap;

			cmd.Parameters.Add(new SqlParameter("買いRate", SqlDbType.Float));
			cmd.Parameters["買いRate"].Direction = ParameterDirection.Input;
			cmd.Parameters["買いRate"].Value = 買いRate;

			cmd.Parameters.Add(new SqlParameter("売りRate", SqlDbType.Float));
			cmd.Parameters["売りRate"].Direction = ParameterDirection.Input;
			cmd.Parameters["売りRate"].Value = 売りRate;

			cmd.Parameters.Add(new SqlParameter("リミット", SqlDbType.Float));
			cmd.Parameters["リミット"].Direction = ParameterDirection.Input;
			cmd.Parameters["リミット"].Value = リミット;

			cmd.Parameters.Add(new SqlParameter("注文単位", SqlDbType.Int));
			cmd.Parameters["注文単位"].Direction = ParameterDirection.Input;
			cmd.Parameters["注文単位"].Value = 注文単位;

			cmd.Parameters.Add(new SqlParameter("BB開始", SqlDbType.Bit));
			cmd.Parameters["BB開始"].Direction = ParameterDirection.Input;
			cmd.Parameters["BB開始"].Value = BS開始;

			cmd.ExecuteNonQuery();
		}

		public static void InsertOrderHistory2(SqlConnection cn,
			DateTime 日時,
			byte 通貨ペアNo,
			double 買いSwap,
			double 売りSwap,
			bool Swap判定,
			double 買いRate,
			double 売りRate,
			bool 売買判定,
			bool 保持ポジション,
			double BS_Min15_買いWMAs14,
			double BS_Min15_買いWMAs14角度,
			double BS_Min15_買いWMAs14角度シグマ,
			double BS_Min15_売りWMAs14,
			double BS_Min15_売りWMAs14角度,
			double BS_Min15_売りWMAs14角度シグマ,
			bool BS_WMA判定_15m,
			bool BS判定_15m,
			bool BS開始,
			string BS判定_前,
			string BS判定_今,
			double 買いリミット,
			double 売りリミット,
			int 注文単位,
			DateTime Month1_Start,
			DateTime Month1_End,
			double Month1_買いWMAs2,
			double Month1_買いWMAs2角度,
			double Month1_買いWMAs14,
			double Month1_売りWMAs2,
			double Month1_売りWMAs2角度,
			double Month1_売りWMAs14,
			DateTime Week1_Start,
			DateTime Week1_End,
			double Week1_買いWMAs2,
			double Week1_買いWMAs2角度,
			double Week1_買いWMAs14,
			double Week1_売りWMAs2,
			double Week1_売りWMAs2角度,
			double Week1_売りWMAs14,
			DateTime Day1_Start,
			DateTime Day1_End,
			double Day1_買いWMAs2,
			double Day1_買いWMAs2角度,
			double Day1_買いWMAs14,
			double Day1_売りWMAs2,
			double Day1_売りWMAs2角度,
			double Day1_売りWMAs14,
			DateTime Hour1_Start,
			DateTime Hour1_End,
			double Hour1_買いWMAs2,
			double Hour1_買いWMAs2角度,
			double Hour1_買いWMAs14,
			double Hour1_売りWMAs2,
			double Hour1_売りWMAs2角度,
			double Hour1_売りWMAs14,
			DateTime Min15_Start,
			DateTime Min15_End,
			double Min15_買いWMAs2,
			double Min15_買いWMAs2角度,
			double Min15_買いWMAs14,
			double Min15_売りWMAs2,
			double Min15_売りWMAs2角度,
			double Min15_売りWMAs14,
			DateTime Min5_Start,
			DateTime Min5_End,
			double Min5_買いWMAs2,
			double Min5_買いWMAs2角度,
			double Min5_買いWMAs14,
			double Min5_売りWMAs2,
			double Min5_売りWMAs2角度,
			double Min5_売りWMAs14,
			DateTime Min1_Start,
			DateTime Min1_End,
			double Min1_買いWMAs2,
			double Min1_買いWMAs2角度,
			double Min1_買いWMAs14,
			double Min1_売りWMAs2,
			double Min1_売りWMAs2角度,
			double Min1_売りWMAs14,
			string OrderId)
		{
			cmd = new SqlCommand("oder.spInsertOrderHistory2", cn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandTimeout = DB定数.CommandTimeout;

			cmd.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
			cmd.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
			cmd.Parameters["通貨ペアNo"].Value = 通貨ペアNo;

			cmd.Parameters.Add(new SqlParameter("日時", SqlDbType.DateTime));
			cmd.Parameters["日時"].Direction = ParameterDirection.Input;
			cmd.Parameters["日時"].Value = 日時;

			cmd.Parameters.Add(new SqlParameter("買いSwap", SqlDbType.Float));
			cmd.Parameters["買いSwap"].Direction = ParameterDirection.Input;
			cmd.Parameters["買いSwap"].Value = 買いSwap;

			cmd.Parameters.Add(new SqlParameter("売りSwap", SqlDbType.Float));
			cmd.Parameters["売りSwap"].Direction = ParameterDirection.Input;
			cmd.Parameters["売りSwap"].Value = 売りSwap;

			cmd.Parameters.Add(new SqlParameter("Swap判定", SqlDbType.Bit));
			cmd.Parameters["Swap判定"].Direction = ParameterDirection.Input;
			cmd.Parameters["Swap判定"].Value = Swap判定;

			cmd.Parameters.Add(new SqlParameter("買いRate", SqlDbType.Float));
			cmd.Parameters["買いRate"].Direction = ParameterDirection.Input;
			cmd.Parameters["買いRate"].Value = 買いRate;

			cmd.Parameters.Add(new SqlParameter("売りRate", SqlDbType.Float));
			cmd.Parameters["売りRate"].Direction = ParameterDirection.Input;
			cmd.Parameters["売りRate"].Value = 売りRate;

			cmd.Parameters.Add(new SqlParameter("売買判定", SqlDbType.VarChar));
			cmd.Parameters["売買判定"].Direction = ParameterDirection.Input;
			cmd.Parameters["売買判定"].Value = 売買判定;

			cmd.Parameters.Add(new SqlParameter("保持ポジション", SqlDbType.Bit));
			cmd.Parameters["保持ポジション"].Direction = ParameterDirection.Input;
			cmd.Parameters["保持ポジション"].Value = 保持ポジション;

			cmd.Parameters.Add(new SqlParameter("BS_Min15_買いWMAs14", SqlDbType.Float));
			cmd.Parameters["BS_Min15_買いWMAs14"].Direction = ParameterDirection.Input;
			cmd.Parameters["BS_Min15_買いWMAs14"].Value = BS_Min15_買いWMAs14;

			cmd.Parameters.Add(new SqlParameter("BS_Min15_買いWMAs14角度", SqlDbType.Float));
			cmd.Parameters["BS_Min15_買いWMAs14角度"].Direction = ParameterDirection.Input;
			cmd.Parameters["BS_Min15_買いWMAs14角度"].Value = BS_Min15_買いWMAs14角度;

			cmd.Parameters.Add(new SqlParameter("BS_Min15_買いWMAs14角度シグマ", SqlDbType.Float));
			cmd.Parameters["BS_Min15_買いWMAs14角度シグマ"].Direction = ParameterDirection.Input;
			cmd.Parameters["BS_Min15_買いWMAs14角度シグマ"].Value = BS_Min15_買いWMAs14角度シグマ;

			cmd.Parameters.Add(new SqlParameter("BS_Min15_売りWMAs14", SqlDbType.Float));
			cmd.Parameters["BS_Min15_売りWMAs14"].Direction = ParameterDirection.Input;
			cmd.Parameters["BS_Min15_売りWMAs14"].Value = BS_Min15_売りWMAs14;

			cmd.Parameters.Add(new SqlParameter("BS_Min15_売りWMAs14角度", SqlDbType.Float));
			cmd.Parameters["BS_Min15_売りWMAs14角度"].Direction = ParameterDirection.Input;
			cmd.Parameters["BS_Min15_売りWMAs14角度"].Value = BS_Min15_売りWMAs14角度;

			cmd.Parameters.Add(new SqlParameter("BS_Min15_売りWMAs14角度シグマ", SqlDbType.Float));
			cmd.Parameters["BS_Min15_売りWMAs14角度シグマ"].Direction = ParameterDirection.Input;
			cmd.Parameters["BS_Min15_売りWMAs14角度シグマ"].Value = BS_Min15_売りWMAs14角度シグマ;

			cmd.Parameters.Add(new SqlParameter("BS_WMA判定_15m", SqlDbType.VarChar));
			cmd.Parameters["BS_WMA判定_15m"].Direction = ParameterDirection.Input;
			cmd.Parameters["BS_WMA判定_15m"].Value = BS_WMA判定_15m;

			cmd.Parameters.Add(new SqlParameter("BS判定_15m", SqlDbType.VarChar));
			cmd.Parameters["BS判定_15m"].Direction = ParameterDirection.Input;
			cmd.Parameters["BS判定_15m"].Value = BS判定_15m;

			cmd.Parameters.Add(new SqlParameter("BB開始", SqlDbType.Bit));
			cmd.Parameters["BB開始"].Direction = ParameterDirection.Input;
			cmd.Parameters["BB開始"].Value = BS開始;

			cmd.Parameters.Add(new SqlParameter("BS判定_前", SqlDbType.VarChar));
			cmd.Parameters["BS判定_前"].Direction = ParameterDirection.Input;
			cmd.Parameters["BS判定_前"].Value = BS判定_前;

			cmd.Parameters.Add(new SqlParameter("BS判定_今", SqlDbType.VarChar));
			cmd.Parameters["BS判定_今"].Direction = ParameterDirection.Input;
			cmd.Parameters["BS判定_今"].Value = BS判定_今;

			cmd.Parameters.Add(new SqlParameter("買いリミット", SqlDbType.Float));
			cmd.Parameters["買いリミット"].Direction = ParameterDirection.Input;
			cmd.Parameters["買いリミット"].Value = 買いリミット;

			cmd.Parameters.Add(new SqlParameter("売りリミット", SqlDbType.Float));
			cmd.Parameters["売りリミット"].Direction = ParameterDirection.Input;
			cmd.Parameters["売りリミット"].Value = 売りリミット;

			cmd.Parameters.Add(new SqlParameter("注文単位", SqlDbType.Int));
			cmd.Parameters["注文単位"].Direction = ParameterDirection.Input;
			cmd.Parameters["注文単位"].Value = 注文単位;

			cmd.Parameters.Add(new SqlParameter("Month1_Start", SqlDbType.DateTime));
			cmd.Parameters["Month1_Start"].Direction = ParameterDirection.Input;
			cmd.Parameters["Month1_Start"].Value = Month1_Start;

			cmd.Parameters.Add(new SqlParameter("Month1_End", SqlDbType.DateTime));
			cmd.Parameters["Month1_End"].Direction = ParameterDirection.Input;
			cmd.Parameters["Month1_End"].Value = Month1_Start;

			cmd.Parameters.Add(new SqlParameter("Month1_買いWMAs2", SqlDbType.Float));
			cmd.Parameters["Month1_買いWMAs2"].Direction = ParameterDirection.Input;
			cmd.Parameters["Month1_買いWMAs2"].Value = Month1_買いWMAs2;

			cmd.Parameters.Add(new SqlParameter("Month1_買いWMAs2角度", SqlDbType.Float));
			cmd.Parameters["Month1_買いWMAs2角度"].Direction = ParameterDirection.Input;
			cmd.Parameters["Month1_買いWMAs2角度"].Value = Month1_買いWMAs2角度;

			cmd.Parameters.Add(new SqlParameter("Month1_買いWMAs14", SqlDbType.Float));
			cmd.Parameters["Month1_買いWMAs14"].Direction = ParameterDirection.Input;
			cmd.Parameters["Month1_買いWMAs14"].Value = Month1_買いWMAs14;

			cmd.Parameters.Add(new SqlParameter("Month1_売りWMAs2", SqlDbType.Float));
			cmd.Parameters["Month1_売りWMAs2"].Direction = ParameterDirection.Input;
			cmd.Parameters["Month1_売りWMAs2"].Value = Month1_売りWMAs2;

			cmd.Parameters.Add(new SqlParameter("Month1_売りWMAs2角度", SqlDbType.Float));
			cmd.Parameters["Month1_売りWMAs2角度"].Direction = ParameterDirection.Input;
			cmd.Parameters["Month1_売りWMAs2角度"].Value = Month1_売りWMAs2角度;

			cmd.Parameters.Add(new SqlParameter("Month1_売りWMAs14", SqlDbType.Float));
			cmd.Parameters["Month1_売りWMAs14"].Direction = ParameterDirection.Input;
			cmd.Parameters["Month1_売りWMAs14"].Value = Month1_売りWMAs14;

			cmd.Parameters.Add(new SqlParameter("Week1_Start", SqlDbType.DateTime));
			cmd.Parameters["Week1_Start"].Direction = ParameterDirection.Input;
			cmd.Parameters["Week1_Start"].Value = Month1_Start;

			cmd.Parameters.Add(new SqlParameter("Week1_End", SqlDbType.DateTime));
			cmd.Parameters["Week1_End"].Direction = ParameterDirection.Input;
			cmd.Parameters["Week1_End"].Value = Month1_Start;

			cmd.Parameters.Add(new SqlParameter("Week1_買いWMAs2", SqlDbType.Float));
			cmd.Parameters["Week1_買いWMAs2"].Direction = ParameterDirection.Input;
			cmd.Parameters["Week1_買いWMAs2"].Value = Week1_買いWMAs2;

			cmd.Parameters.Add(new SqlParameter("Week1_買いWMAs2角度", SqlDbType.Float));
			cmd.Parameters["Week1_買いWMAs2角度"].Direction = ParameterDirection.Input;
			cmd.Parameters["Week1_買いWMAs2角度"].Value = Week1_買いWMAs2角度;

			cmd.Parameters.Add(new SqlParameter("Week1_買いWMAs14", SqlDbType.Float));
			cmd.Parameters["Week1_買いWMAs14"].Direction = ParameterDirection.Input;
			cmd.Parameters["Week1_買いWMAs14"].Value = Week1_買いWMAs14;

			cmd.Parameters.Add(new SqlParameter("Week1_売りWMAs2", SqlDbType.Float));
			cmd.Parameters["Week1_売りWMAs2"].Direction = ParameterDirection.Input;
			cmd.Parameters["Week1_売りWMAs2"].Value = Week1_売りWMAs2;

			cmd.Parameters.Add(new SqlParameter("Week1_売りWMAs2角度", SqlDbType.Float));
			cmd.Parameters["Week1_売りWMAs2角度"].Direction = ParameterDirection.Input;
			cmd.Parameters["Week1_売りWMAs2角度"].Value = Week1_売りWMAs2角度;

			cmd.Parameters.Add(new SqlParameter("Week1_売りWMAs14", SqlDbType.Float));
			cmd.Parameters["Week1_売りWMAs14"].Direction = ParameterDirection.Input;
			cmd.Parameters["Week1_売りWMAs14"].Value = Week1_売りWMAs14;

			cmd.Parameters.Add(new SqlParameter("Day1_Start", SqlDbType.DateTime));
			cmd.Parameters["Day1_Start"].Direction = ParameterDirection.Input;
			cmd.Parameters["Day1_Start"].Value = Month1_Start;

			cmd.Parameters.Add(new SqlParameter("Day1_End", SqlDbType.DateTime));
			cmd.Parameters["Day1_End"].Direction = ParameterDirection.Input;
			cmd.Parameters["Day1_End"].Value = Month1_Start;

			cmd.Parameters.Add(new SqlParameter("Day1_買いWMAs2", SqlDbType.Float));
			cmd.Parameters["Day1_買いWMAs2"].Direction = ParameterDirection.Input;
			cmd.Parameters["Day1_買いWMAs2"].Value = Day1_買いWMAs2;

			cmd.Parameters.Add(new SqlParameter("Day1_買いWMAs2角度", SqlDbType.Float));
			cmd.Parameters["Day1_買いWMAs2角度"].Direction = ParameterDirection.Input;
			cmd.Parameters["Day1_買いWMAs2角度"].Value = Day1_買いWMAs2角度;

			cmd.Parameters.Add(new SqlParameter("Day1_買いWMAs14", SqlDbType.Float));
			cmd.Parameters["Day1_買いWMAs14"].Direction = ParameterDirection.Input;
			cmd.Parameters["Day1_買いWMAs14"].Value = Day1_買いWMAs14;

			cmd.Parameters.Add(new SqlParameter("Day1_売りWMAs2", SqlDbType.Float));
			cmd.Parameters["Day1_売りWMAs2"].Direction = ParameterDirection.Input;
			cmd.Parameters["Day1_売りWMAs2"].Value = Day1_売りWMAs2;

			cmd.Parameters.Add(new SqlParameter("Day1_売りWMAs2角度", SqlDbType.Float));
			cmd.Parameters["Day1_売りWMAs2角度"].Direction = ParameterDirection.Input;
			cmd.Parameters["Day1_売りWMAs2角度"].Value = Day1_売りWMAs2角度;

			cmd.Parameters.Add(new SqlParameter("Day1_売りWMAs14", SqlDbType.Float));
			cmd.Parameters["Day1_売りWMAs14"].Direction = ParameterDirection.Input;
			cmd.Parameters["Day1_売りWMAs14"].Value = Day1_売りWMAs14;

			cmd.Parameters.Add(new SqlParameter("Hour1_Start", SqlDbType.DateTime));
			cmd.Parameters["Hour1_Start"].Direction = ParameterDirection.Input;
			cmd.Parameters["Hour1_Start"].Value = Month1_Start;

			cmd.Parameters.Add(new SqlParameter("Hour1_End", SqlDbType.DateTime));
			cmd.Parameters["Hour1_End"].Direction = ParameterDirection.Input;
			cmd.Parameters["Hour1_End"].Value = Month1_Start;

			cmd.Parameters.Add(new SqlParameter("Hour1_買いWMAs2", SqlDbType.Float));
			cmd.Parameters["Hour1_買いWMAs2"].Direction = ParameterDirection.Input;
			cmd.Parameters["Hour1_買いWMAs2"].Value = Hour1_買いWMAs2;

			cmd.Parameters.Add(new SqlParameter("Hour1_買いWMAs2角度", SqlDbType.Float));
			cmd.Parameters["Hour1_買いWMAs2角度"].Direction = ParameterDirection.Input;
			cmd.Parameters["Hour1_買いWMAs2角度"].Value = Hour1_買いWMAs2角度;

			cmd.Parameters.Add(new SqlParameter("Hour1_買いWMAs14", SqlDbType.Float));
			cmd.Parameters["Hour1_買いWMAs14"].Direction = ParameterDirection.Input;
			cmd.Parameters["Hour1_買いWMAs14"].Value = Hour1_買いWMAs14;

			cmd.Parameters.Add(new SqlParameter("Hour1_売りWMAs2", SqlDbType.Float));
			cmd.Parameters["Hour1_売りWMAs2"].Direction = ParameterDirection.Input;
			cmd.Parameters["Hour1_売りWMAs2"].Value = Hour1_売りWMAs2;

			cmd.Parameters.Add(new SqlParameter("Hour1_売りWMAs2角度", SqlDbType.Float));
			cmd.Parameters["Hour1_売りWMAs2角度"].Direction = ParameterDirection.Input;
			cmd.Parameters["Hour1_売りWMAs2角度"].Value = Hour1_売りWMAs2角度;

			cmd.Parameters.Add(new SqlParameter("Hour1_売りWMAs14", SqlDbType.Float));
			cmd.Parameters["Hour1_売りWMAs14"].Direction = ParameterDirection.Input;
			cmd.Parameters["Hour1_売りWMAs14"].Value = Hour1_売りWMAs14;

			cmd.Parameters.Add(new SqlParameter("Min15_Start", SqlDbType.DateTime));
			cmd.Parameters["Min15_Start"].Direction = ParameterDirection.Input;
			cmd.Parameters["Min15_Start"].Value = Month1_Start;

			cmd.Parameters.Add(new SqlParameter("Min15_End", SqlDbType.DateTime));
			cmd.Parameters["Min15_End"].Direction = ParameterDirection.Input;
			cmd.Parameters["Min15_End"].Value = Month1_Start;

			cmd.Parameters.Add(new SqlParameter("Min15_買いWMAs2", SqlDbType.Float));
			cmd.Parameters["Min15_買いWMAs2"].Direction = ParameterDirection.Input;
			cmd.Parameters["Min15_買いWMAs2"].Value = Min15_買いWMAs2;

			cmd.Parameters.Add(new SqlParameter("Min15_買いWMAs2角度", SqlDbType.Float));
			cmd.Parameters["Min15_買いWMAs2角度"].Direction = ParameterDirection.Input;
			cmd.Parameters["Min15_買いWMAs2角度"].Value = Min15_買いWMAs2角度;

			cmd.Parameters.Add(new SqlParameter("Min15_買いWMAs14", SqlDbType.Float));
			cmd.Parameters["Min15_買いWMAs14"].Direction = ParameterDirection.Input;
			cmd.Parameters["Min15_買いWMAs14"].Value = Min15_買いWMAs14;

			cmd.Parameters.Add(new SqlParameter("Min15_売りWMAs2", SqlDbType.Float));
			cmd.Parameters["Min15_売りWMAs2"].Direction = ParameterDirection.Input;
			cmd.Parameters["Min15_売りWMAs2"].Value = Min15_売りWMAs2;

			cmd.Parameters.Add(new SqlParameter("Min15_売りWMAs2角度", SqlDbType.Float));
			cmd.Parameters["Min15_売りWMAs2角度"].Direction = ParameterDirection.Input;
			cmd.Parameters["Min15_売りWMAs2角度"].Value = Min15_売りWMAs2角度;

			cmd.Parameters.Add(new SqlParameter("Min15_売りWMAs14", SqlDbType.Float));
			cmd.Parameters["Min15_売りWMAs14"].Direction = ParameterDirection.Input;
			cmd.Parameters["Min15_売りWMAs14"].Value = Min15_売りWMAs14;

			cmd.Parameters.Add(new SqlParameter("Min5_Start", SqlDbType.DateTime));
			cmd.Parameters["Min5_Start"].Direction = ParameterDirection.Input;
			cmd.Parameters["Min5_Start"].Value = Month1_Start;

			cmd.Parameters.Add(new SqlParameter("Min5_End", SqlDbType.DateTime));
			cmd.Parameters["Min5_End"].Direction = ParameterDirection.Input;
			cmd.Parameters["Min5_End"].Value = Month1_Start;

			cmd.Parameters.Add(new SqlParameter("Min5_買いWMAs2", SqlDbType.Float));
			cmd.Parameters["Min5_買いWMAs2"].Direction = ParameterDirection.Input;
			cmd.Parameters["Min5_買いWMAs2"].Value = Min5_買いWMAs2;

			cmd.Parameters.Add(new SqlParameter("Min5_買いWMAs2角度", SqlDbType.Float));
			cmd.Parameters["Min5_買いWMAs2角度"].Direction = ParameterDirection.Input;
			cmd.Parameters["Min5_買いWMAs2角度"].Value = Min5_買いWMAs2角度;

			cmd.Parameters.Add(new SqlParameter("Min5_買いWMAs14", SqlDbType.Float));
			cmd.Parameters["Min5_買いWMAs14"].Direction = ParameterDirection.Input;
			cmd.Parameters["Min5_買いWMAs14"].Value = Min5_買いWMAs14;

			cmd.Parameters.Add(new SqlParameter("Min5_売りWMAs2", SqlDbType.Float));
			cmd.Parameters["Min5_売りWMAs2"].Direction = ParameterDirection.Input;
			cmd.Parameters["Min5_売りWMAs2"].Value = Min5_売りWMAs2;

			cmd.Parameters.Add(new SqlParameter("Min5_売りWMAs2角度", SqlDbType.Float));
			cmd.Parameters["Min5_売りWMAs2角度"].Direction = ParameterDirection.Input;
			cmd.Parameters["Min5_売りWMAs2角度"].Value = Min5_売りWMAs2角度;

			cmd.Parameters.Add(new SqlParameter("Min5_売りWMAs14", SqlDbType.Float));
			cmd.Parameters["Min5_売りWMAs14"].Direction = ParameterDirection.Input;
			cmd.Parameters["Min5_売りWMAs14"].Value = Min5_売りWMAs14;

			cmd.Parameters.Add(new SqlParameter("Min1_Start", SqlDbType.DateTime));
			cmd.Parameters["Min1_Start"].Direction = ParameterDirection.Input;
			cmd.Parameters["Min1_Start"].Value = Month1_Start;

			cmd.Parameters.Add(new SqlParameter("Min1_End", SqlDbType.DateTime));
				cmd.Parameters["Min1_End"].Direction = ParameterDirection.Input;
			cmd.Parameters["Min1_End"].Value = Month1_Start;

			cmd.Parameters.Add(new SqlParameter("Min1_買いWMAs2", SqlDbType.Float));
			cmd.Parameters["Min1_買いWMAs2"].Direction = ParameterDirection.Input;
			cmd.Parameters["Min1_買いWMAs2"].Value = Min1_買いWMAs2;

			cmd.Parameters.Add(new SqlParameter("Min1_買いWMAs2角度", SqlDbType.Float));
			cmd.Parameters["Min1_買いWMAs2角度"].Direction = ParameterDirection.Input;
			cmd.Parameters["Min1_買いWMAs2角度"].Value = Min1_買いWMAs2角度;

			cmd.Parameters.Add(new SqlParameter("Min1_買いWMAs14", SqlDbType.Float));
			cmd.Parameters["Min1_買いWMAs14"].Direction = ParameterDirection.Input;
			cmd.Parameters["Min1_買いWMAs14"].Value = Min1_買いWMAs14;

			cmd.Parameters.Add(new SqlParameter("Min1_売りWMAs2", SqlDbType.Float));
			cmd.Parameters["Min1_売りWMAs2"].Direction = ParameterDirection.Input;
			cmd.Parameters["Min1_売りWMAs2"].Value = Min1_売りWMAs2;

			cmd.Parameters.Add(new SqlParameter("Min1_売りWMAs2角度", SqlDbType.Float));
			cmd.Parameters["Min1_売りWMAs2角度"].Direction = ParameterDirection.Input;
			cmd.Parameters["Min1_売りWMAs2角度"].Value = Min1_売りWMAs2角度;

			cmd.Parameters.Add(new SqlParameter("Min1_売りWMAs14", SqlDbType.Float));
			cmd.Parameters["Min1_売りWMAs14"].Direction = ParameterDirection.Input;
			cmd.Parameters["Min1_売りWMAs14"].Value = Min1_売りWMAs14;

			cmd.Parameters.Add(new SqlParameter("OrderId", SqlDbType.Float));
			cmd.Parameters["OrderId"].Direction = ParameterDirection.Input;
			cmd.Parameters["OrderId"].Value = OrderId;

			cmd.ExecuteNonQuery();
		}
	}
}
