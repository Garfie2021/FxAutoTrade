using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCheck
{
    public static class HealthCheckログ
    {
        public static string ログフォルダ;
        public static string ログファイル補足名;

        public static void 初期化(string folder, string file)
        {
            ログフォルダ = folder;
            ログファイル補足名 = file;

            if (Directory.Exists(ログフォルダ) == false)
            {
                Directory.CreateDirectory(ログフォルダ);
            }
        }

        private static string ログファイルPath()
        {
            return ログフォルダ + @"\" + DateTime.Now.ToString("yyyyMMdd") + "_" + ログファイル補足名 + ".log";
        }


        public static void ログ書き出し(Exception ex)
        {
            ログ書き出し("【Exception】" + "\r\n" + ex.Data + "\r\n" + ex.HelpLink + "\r\n" + ex.InnerException + "\r\n" + ex.Message + "\r\n" + ex.Source + "\r\n" + ex.StackTrace + "\r\n" + ex.TargetSite + "\r\n");
        }

        public static void ログ書き出し(string ログ)
        {
            File.AppendAllText(ログファイルPath(), DateTime.Now.ToString() + " " + ログ + "\r\n", Encoding.UTF8);
        }

    }
}
