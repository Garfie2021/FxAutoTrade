using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using 定数;
using 共通Data;
using DB_Maintenance;
using Common;
using SystemSetting;
using FXAPI共通;



namespace HealthCheck
{
    public partial class Form1 : Form
    {
        // コマンドライン例
        //
        // Auto;SwapCollect
        // manual;SwapCollect


        public Form1()
        {
            InitializeComponent();


        }

        private void ヘルスチェック開始()
        {
            var result = "";
            var チェック口座NoList = new List<int>();

            // 起動パラメータからDB名を取得する

            if (cmbDB.Text == "OANDA_DemoB")
            {
                using (SqlConnection cnOANDA_DemoB = new SqlConnection())
                {
                    チェック口座NoList.Add(1);
                    チェック口座NoList.Add(3);

                    cnOANDA_DemoB.ConnectionString = DB定数.GetConnectionString("OANDA_DemoB");
                    cnOANDA_DemoB.Open();

                    HealthCheckSt.データロスト検出_OANDA(cnOANDA_DemoB, cmbDB.Text, cmb口座.Text, チェック口座NoList, ref result);
                }
            }
            else if (cmbDB.Text == "OANDA_RealA")
            {
                using (SqlConnection cnOANDA_RealA = new SqlConnection())
                {
                    チェック口座NoList.Add(1);
                    チェック口座NoList.Add(2);
                    チェック口座NoList.Add(3);

                    cnOANDA_RealA.ConnectionString = DB定数.GetConnectionString("OANDA_RealA");
                    cnOANDA_RealA.Open();

                    HealthCheckSt.データロスト検出_OANDA(cnOANDA_RealA, cmbDB.Text, cmb口座.Text, チェック口座NoList, ref result);
                }
            }
            else if (cmbDB.Text == "OANDA_DemoB_ACV")
            {
                using (SqlConnection cnOANDA_DemoB_ACV = new SqlConnection())
                {
                    cnOANDA_DemoB_ACV.ConnectionString = DB定数.GetConnectionString("OANDA_DemoB_ACV");
                    cnOANDA_DemoB_ACV.Open();

                    HealthCheckSt.データロスト検出_ACV(cnOANDA_DemoB_ACV, cmbDB.Text, cmb口座.Text, ref result);
                }
            }
            else if (cmbDB.Text == "OANDA_RealA_ACV")
            {
                using (SqlConnection cnOANDA_RealA_ACV = new SqlConnection())
                {
                    cnOANDA_RealA_ACV.ConnectionString = DB定数.GetConnectionString("OANDA_RealA_ACV");
                    cnOANDA_RealA_ACV.Open();

                    HealthCheckSt.データロスト検出_ACV(cnOANDA_RealA_ACV, cmbDB.Text, cmb口座.Text, ref result);
                }
            }
            else if (cmbDB.Text == "SwapCollect")
            {
                using (SqlConnection cnOANDA_RealA = new SqlConnection())
                using (SqlConnection cnSwapCollect = new SqlConnection())
                {
                    cnOANDA_RealA.ConnectionString = DB定数.GetConnectionString("OANDA_RealA");
                    cnOANDA_RealA.Open();

                    cnSwapCollect.ConnectionString = DB定数.GetConnectionString("SwapCollect");
                    cnSwapCollect.Open();

                    HealthCheckSt.データロスト検出_SwapCollect(cnOANDA_RealA, cnSwapCollect, cmbDB.Text, 
                        DateTime.Parse(txtStartDate.Text), DateTime.Parse(txtEndDate.Text),
                        ref result);
                }
            }

            if (result != "")
            {
                Mail.SendMail("データロスト検出 " + cmbDB.Text + " " + cmb口座.Text, result);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //File.AppendAllText(@"C:\HealthCheck.log", DateTime.Now.ToString() + " 開始\r\n", FormData.Enc);
                //File.AppendAllText(@"C:\HealthCheck.log", DateTime.Now.ToString() + " " + Environment.GetCommandLineArgs()[1] + "\r\n", FormData.Enc);
                HealthCheckログ.ログ書き出し(Environment.GetCommandLineArgs()[1] + " : 開始");

                cmbサーバ.Items.Add("localhost");
                cmbサーバ.Items.Add("1111.5");
                cmbサーバ.Text = "1111.5";

                cmbDB.Items.Add("OANDA_DemoB");
                cmbDB.Items.Add("OANDA_DemoB_ACV");
                cmbDB.Items.Add("OANDA_RealA");
                cmbDB.Items.Add("OANDA_RealA_ACV");
                cmbDB.Items.Add("SwapCollect");

                cmb口座.Items.Add("0");
                cmb口座.Items.Add("1");
                cmb口座.Items.Add("2");
                cmb口座.Items.Add("3");
                cmb口座.Items.Add("4");
                cmb口座.Items.Add("5");
                cmb口座.Text = "1";

                foreach (var CommandLine in 定数.コマンドライン.CommandLine候補)
                {
                    cmbコマンドライン.Items.Add(CommandLine);
                }

                if (Environment.GetCommandLineArgs().Length > 1)
                {
                    var commandLine = Environment.GetCommandLineArgs()[1].Split(';');
                    cmbDB.Text = commandLine[1];
                }

                FormData.DBConnectionString = DB定数.GetConnectionString(cmbDB.Text);

                txtStartDate.Text = DateTime.Now.ToString("yyyy/MM/dd 00:00:00");
                txtEndDate.Text = DateTime.Now.ToString("yyyy/MM/dd 23:59:59");

                if (Environment.GetCommandLineArgs().Length > 1)
                {
                    if (Environment.GetCommandLineArgs()[1].IndexOf("Auto") >= 0)
                    {
                        ヘルスチェック開始();
                        HealthCheckログ.ログ書き出し(Environment.GetCommandLineArgs()[1] + " : 正常終了");
                        Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                HealthCheckログ.ログ書き出し(ex.Message);
                HealthCheckログ.ログ書き出し(ex.StackTrace);

                Mail.SendMail("データロスト検出 ", ex.Message);
                Application.Exit();
            }
        }


        private void btnヘルスチェック実行_Click(object sender, EventArgs e)
        {
            try
            {
                ヘルスチェック開始();
            }
            catch (Exception ex)
            {
                HealthCheckログ.ログ書き出し(ex.Message);
                HealthCheckログ.ログ書き出し(ex.StackTrace);
            }
        }



    }
}
