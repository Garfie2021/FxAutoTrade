using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Common
{
	public static class logger
	{
		public static void execlog_write(string message)
		{
			File.AppendAllText(Settings.ExeclogPath, message + "\r\n", Encoding.GetEncoding("Shift_JIS"));
		}

	}
}
