using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using SystemCommon;

namespace HealthCheck
{
	class Program
	{

		private static void Main(string[] args)
		{
			try
			{
				string body = "";
				string 状況_Title_DemoA;
				string 状況_Title_RealA;
				string 状況_Title_RealB;
				string 状況_DemoA;
				string 状況_RealA;
				string 状況_RealB;

				状況_Title_DemoA = "\r\n【DemoA_FX】\r\n";
				CDB_dbo.DemoA_FX();
				CDB_hltc.Getレコードの状況(-1, out 状況_DemoA);

				状況_Title_RealA = "\r\n【RealA_FX】\r\n";
				CDB_dbo.RealA_FX();
				CDB_hltc.Getレコードの状況(-1, out 状況_RealA);

				状況_Title_RealB = "\r\n【RealB_FX】\r\n";
				CDB_dbo.RealB_FX();
				CDB_hltc.Getレコードの状況(-1, out 状況_RealB);

				body += 状況_Title_DemoA + 状況_DemoA + 状況_Title_RealA + 状況_RealA + 状況_Title_RealB + 状況_RealB;

				状況_Title_DemoA = "\r\n【DemoA_Kabu】\r\n";
				CDB_dbo.DemoA_Kabu();
				CDB_hltc.Getレコードの状況(-1, out 状況_DemoA);

				状況_Title_RealA = "\r\n【RealA_Kabu】\r\n";
				CDB_dbo.RealA_Kabu();
				CDB_hltc.Getレコードの状況(-1, out 状況_RealA);

				状況_Title_RealB = "\r\n【RealB_Kabu】\r\n";
				CDB_dbo.RealB_Kabu();
				CDB_hltc.Getレコードの状況(-1, out 状況_RealB);

				body += 状況_Title_DemoA + 状況_DemoA + 状況_Title_RealA + 状況_RealA + 状況_Title_RealB + 状況_RealB;

				状況_Title_DemoA = "\r\n【DemoA_XAU】\r\n";
				CDB_dbo.DemoA_XAU();
				CDB_hltc.Getレコードの状況(-1, out 状況_DemoA);

				状況_Title_RealA = "\r\n【RealA_XAU】\r\n";
				CDB_dbo.RealA_XAU();
				CDB_hltc.Getレコードの状況(-1, out 状況_RealA);

				状況_Title_RealB = "\r\n【RealB_XAU】\r\n";
				CDB_dbo.RealB_XAU();
				CDB_hltc.Getレコードの状況(-1, out 状況_RealB);

				body += 状況_Title_DemoA + 状況_DemoA + 状況_Title_RealA + 状況_RealA + 状況_Title_RealB + 状況_RealB;

				C04システム共通.SendGMail("1111.err@111.com", "1111.err@111.com", "AutoFX レコード件数", body);

			}
			catch (Exception ex)
			{
				Exception共通(ex, C共通.txtログフォルダ);
			}
		}

		private static void Exception共通(Exception ex, string txtログフォルダ)
		{
			string ログファイル名 = DateTime.Now.ToString("yyyyMMdd") + ".log";

			File.AppendAllText(txtログフォルダ + @"\" + ログファイル名, "\r\n\r\n");
			File.AppendAllText(txtログフォルダ + @"\" + ログファイル名, DateTime.Now.ToString() + "\r\n", Encoding.GetEncoding("Shift_JIS"));
			File.AppendAllText(txtログフォルダ + @"\" + ログファイル名, ex.Data + "\r\n", Encoding.GetEncoding("Shift_JIS"));
			File.AppendAllText(txtログフォルダ + @"\" + ログファイル名, ex.HelpLink + "\r\n", Encoding.GetEncoding("Shift_JIS"));
			File.AppendAllText(txtログフォルダ + @"\" + ログファイル名, ex.InnerException + "\r\n", Encoding.GetEncoding("Shift_JIS"));
			File.AppendAllText(txtログフォルダ + @"\" + ログファイル名, ex.Message + "\r\n", Encoding.GetEncoding("Shift_JIS"));
			File.AppendAllText(txtログフォルダ + @"\" + ログファイル名, ex.Source + "\r\n", Encoding.GetEncoding("Shift_JIS"));
			File.AppendAllText(txtログフォルダ + @"\" + ログファイル名, ex.StackTrace + "\r\n", Encoding.GetEncoding("Shift_JIS"));
			File.AppendAllText(txtログフォルダ + @"\" + ログファイル名, ex.TargetSite + "\r\n", Encoding.GetEncoding("Shift_JIS"));
		}



}


}
