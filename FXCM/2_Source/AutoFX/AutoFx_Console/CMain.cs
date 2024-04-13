using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Common;

namespace AutoFx_Console
{
	public static class CMain
	{
		private static void バグチェック()
		{
			//if (dgv注文設定.ColumnCount != Form定数.DGVClmNo注文設定_DGV列数)
			//{
			//	throw new System.Exception("dgv注文設定 の列数と、DGVClmNo注文設定_DGV列数 が不一致");
			//}
		}

		public static void Start()
		{
			try
			{
				ログ.初期化();
				システム設定.CommandLineから環境設定();

				バグチェック();

				システム設定.Trade時間内 = 注文共通.GetTrade時間内();	// システム日時更新

				//DG設定();
			}
			catch (Exception ex)
			{
				File.AppendAllText(ログ.ログフォルダPath(), ex.ToString(), システム設定.Enc);
			}
		}
	}
}
