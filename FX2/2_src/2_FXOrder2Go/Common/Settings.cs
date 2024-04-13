using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Common
{
	public static class Settings
	{
		public static double シグマ閾値;
		public static bool chkRate記録以降の処理をスキップ;
		public static bool chkポジション更新_成行_をスキップ;
		public static int AtMarket = 0;											// txtシステム設定_AtMarket.Text
		public static byte 注文単位 = 1;

		public static string logFolder = Directory.GetCurrentDirectory() + @"\log";				// (カレントフォルダ)\log\
		public static string ExeclogPath = Directory.GetCurrentDirectory() + @"\log\exec.log";	// (カレントフォルダ)\log\exec.log
		//public static string ErrlogPath = Directory.GetCurrentDirectory() + @"\log\error.log";	// (カレントフォルダ)\log\exec.log

		static Settings()
		{
			tSettingsテーブル読込み();
		}

		public static void tSettingsテーブル読込み()
		{
			シグマ閾値 = 2.5;
			chkRate記録以降の処理をスキップ = false;
			chkポジション更新_成行_をスキップ = false;
			AtMarket = 0;
		}
	}
}
