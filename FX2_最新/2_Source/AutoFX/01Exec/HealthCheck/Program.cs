using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCheck
{
    static class Program
    {
        public static bool Auto = false;
        public static string DB = "";

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            string commandLine =  Environment.GetCommandLineArgs()[1];
            if (commandLine.IndexOf("Auto") > -1)
            {
                Auto = true;
            }

            DB = commandLine.Split(';')[1];

#if DEBUG
            HealthCheckログ.初期化(Directory.GetCurrentDirectory() + "\\log", DB);
#else
            HealthCheckログ.初期化(@"C:\AutoFX\HealthCheck\log", DB);
#endif


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());



        }
    }
}
