using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FXCM;

namespace Siamese
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
			Environment.SetEnvironmentVariable("Path", Environment.GetEnvironmentVariable("Path") + @";C:\Program Files\Candleworks\ForexConnectAPIx64\bin");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

			Application.Run(new FMain());
        }
    }
}
