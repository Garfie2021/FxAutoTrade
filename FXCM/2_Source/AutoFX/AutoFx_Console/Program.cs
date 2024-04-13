using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace AutoFx_Console
{
	class Program
	{
		static void Main(string[] args)
		{
			if (Environment.GetCommandLineArgs().Length > 1)
			{
				システム設定.CommandLine = Environment.GetCommandLineArgs()[1];
			}

			CMain.Start();
		}
	}
}
