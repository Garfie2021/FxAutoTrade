using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Common;

namespace AutoFx_Form
{
	static class Program
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			if (Environment.GetCommandLineArgs().Length > 1)
			{
				システム設定.CommandLine = Environment.GetCommandLineArgs()[1];
			}

			Application.Run(new FMain());

		}
	}
}
