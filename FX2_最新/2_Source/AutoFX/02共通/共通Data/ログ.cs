using System;
using System.IO;

namespace 共通Data
{
    public static class ログ
    {
        public static void 初期化()
        {
            if (Directory.Exists(FormData.ログフォルダ) == false)
            {
                Directory.CreateDirectory(FormData.ログフォルダ);
            }
        }

        public static string ログファイルPath()
        {
            return FormData.ログフォルダ + @"\" + DateTime.Now.ToString("yyyyMMdd") + "_" + FormData.口座No + ".log";
        }

        public static void ログ書き出し(Exception ex)
        {
            ログ.ログ書き出し("【Exception】" + "\r\n" + ex.Data + "\r\n" + ex.HelpLink + "\r\n" + ex.InnerException + "\r\n" + ex.Message + "\r\n" + ex.Source + "\r\n" + ex.StackTrace + "\r\n" + ex.TargetSite + "\r\n");
        }

        public static void ログ書き出し(string ログ)
        {
            File.AppendAllText(ログファイルPath(), DateTime.Now.ToString() + " " + ログ + "\r\n", FormData.Enc);
        }

    }
}
