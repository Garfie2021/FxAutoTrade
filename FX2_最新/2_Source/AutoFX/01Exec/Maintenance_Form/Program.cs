﻿using System;
using System.Windows.Forms;
using SystemSetting;


namespace Maintenance_Form
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

            システム設定.CommandLine取得(true);

            Application.Run(new FMaintenance());
        }
    }

}
