using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Common
{
	public static class ログ
	{
		public static void 初期化()
		{
			if (Directory.Exists(システム設定.ログフォルダ) == false)
				Directory.CreateDirectory(システム設定.ログフォルダ);

			File.AppendAllText(ログフォルダPath(), "Start", システム設定.Enc);
		}

		public static string ログフォルダPath()
		{
			return システム設定.ログフォルダ + @"\" + DateTime.Now.ToString("yyyyMMdd") + ".log";
		}

	}
}
