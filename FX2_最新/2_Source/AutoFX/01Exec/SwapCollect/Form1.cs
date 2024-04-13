using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using 定数;
using 共通Data;
using Common;
using SystemSetting;
using FXAPI共通;
using OANDAv1;
using DB_Maintenance;


namespace SwapCollect
{
    public partial class Form1 : Form
    {
        //public DateTime OandaTransaction最終日時_買い口座A;
        //public DateTime OandaTransaction最終日時_買い口座B;
        //public DateTime OandaTransaction最終日時_売り口座A;
        //public DateTime OandaTransaction最終日時_売り口座B;


        public Form1()
        {
            InitializeComponent();

            FormData.timer_20min = new Timer();
            FormData.timer_20min.Enabled = false;
            FormData.timer_20min.Interval = 1200000;
            FormData.timer_20min.Tick += new EventHandler(this.timer_Tick_20min);
        }

        private static void Transaction収集(int 口座No, int OandaAccountId, ref int Cnt)
        {
            //FormData.OandaAccountId = OandaAccountId;
            CredentialsSt.SetCredentials(FormData.OandaEnvironment, FormData.OandaAccessToken, OandaAccountId);

            List<OandaTransaction> result;
            FormData.OandaTransactionLastId = Rest.GetTransactionListAsync(OandaAccountId, FormData.OandaTransactionLastId, out result);

            foreach (var transaction in result)
            {
                if (DB.oanda.GetTransactionCnt(口座No, transaction) > 0) continue;

                DB.oanda.InsertTransaction(口座No, transaction);
                Cnt++;
            }
        }


        #region イベントハンドラ Form

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (Environment.GetCommandLineArgs().Length > 1)
                {
                    if (Environment.GetCommandLineArgs()[1].IndexOf("Auto") >= 0)
                    {
                        chk自動開始.Checked = true;
                        FormData.timer_20min.Enabled = true;
                    }
                }

                FormData.OandaEnvironment = EEnvironment.Practice;
                FormData.FX会社 = Company.OANDA;
                FormData.FxServerContry = Contry.US;
                FormData.通貨ぺア別取引状況 = Instrument初期化.通貨ペア初期化();

                txtDB接続先.Text = DB定数.GetConnectionString("SwapCollect");
                FormData.DBConnectionString = txtDB接続先.Text;
                システム設定.DB接続();

                FormData.OandaAccessToken = txtAccessToken.Text;

                DB.BulkCopyExecLog.InsertExecLog(処理区分.Start.ToString(), "", null, null, null);
                DB.BulkCopyExecLog.ExecLogFlush();
            }
            catch (Exception ex)
            {
                注文共通.Exception共通(ex, new List<Cエラー関連変数>());
                注文共通.全Timerを停止();
            }
        }

        private void chk自動開始_CheckedChanged(object sender, EventArgs e)
        {
            if (chk自動開始.Checked)
            {
                txtステータス.Text = "収集中";
            }
            else
            {
                txtステータス.Text = "停止中";
            }
        }

        private void btn手動実行_Click(object sender, EventArgs e)
        {
            try
            {
                // 複数の処理を並行に実行
                // デバッグをし易くし、サーバ負荷を平準化する為に、1つづつ実行する。
                //Task.WhenAll(Transaction収集Async(int.Parse(txt買いポジション用口座No.Text), int.Parse(txtOandaAccountId買いポジション用口座.Text)),
                //    Transaction収集Async(int.Parse(txt売りポジション用口座No.Text), int.Parse(txtOandaAccountId売りポジション用口座.Text))).Wait();
                int InsertCount = 0;
                Transaction収集(int.Parse(txt買いポジション用口座ANo.Text), int.Parse(txtOandaAccountId買いポジション用口座A.Text), ref InsertCount);
                Transaction収集(int.Parse(txt買いポジション用口座BNo.Text), int.Parse(txtOandaAccountId買いポジション用口座B.Text), ref InsertCount);
                Transaction収集(int.Parse(txt売りポジション用口座ANo.Text), int.Parse(txtOandaAccountId売りポジション用口座A.Text), ref InsertCount);
                Transaction収集(int.Parse(txt売りポジション用口座BNo.Text), int.Parse(txtOandaAccountId売りポジション用口座B.Text), ref InsertCount);

                MessageBox.Show($"完了\r\n件数：{InsertCount}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                システム設定.DB接続();
            }
        }

        private void btn手動実行_spInsertSwap手動登録_Day1_toDemo_Click(object sender, EventArgs e)
        {
            try
            {
                DB_SwapCollect.swap.InsertSwap手動登録_Day1_toDemo();

                MessageBox.Show("完了");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                システム設定.DB接続();
            }
        }

        private void btn手動実行_spInsertSwap手動登録_Day1_toReal_Click(object sender, EventArgs e)
        {
            try
            {
                DB_SwapCollect.swap.InsertSwap手動登録_Day1_toReal();

                MessageBox.Show("完了");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                システム設定.DB接続();
            }
        }

        private void btnTimer手動実行_Click(object sender, EventArgs e)
        {
            try
            {
                本実行();

                MessageBox.Show("完了");
            }
            catch (Exception ex)
            {
                注文共通.Exception共通(ex, new List<Cエラー関連変数>());
                システム設定.DB接続();
            }
        }

        private void btn日次レポート送信_Click(object sender, EventArgs e)
        {
            try
            {
                日次レポート送信();

                MessageBox.Show("完了");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void 日次レポート送信()
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = FormData.DBConnectionString;
                cn.Open();

                Mail.SendMail("日次レポート DB統計 SwapCollect " + DateTime.Now.DayOfWeek,
                    FormData.DBConnectionString + "\r\n\r\n" +
                    DataTable共通.DataTable_ToText(system.SelectDB統計(cn)));
            }


            var files = Directory.EnumerateFiles(txtデータフォルダ.Text, "*", SearchOption.AllDirectories);

            var ファイルサイズ = "";
            foreach (string filepath in files)
            {
                var fi = new FileInfo(filepath);

                ファイルサイズ += filepath + ": " + (fi.Length / 1024) + "KB\r\n";
            }

            var ドライブ空容量 = "";
            var drive = new DriveInfo("C");
            ドライブ空容量 += $"ドライブ全体のバイト数:{drive.TotalSize / 1024 / 1024 / 1024}GB\r\n";
            ドライブ空容量 += $"呼び出し側が利用できるバイト数:{drive.AvailableFreeSpace / 1024 / 1024 / 1024}GB\r\n";
            ドライブ空容量 += $"ドライブ全体の空きバイト数:{drive.TotalFreeSpace / 1024 / 1024 / 1024}GB\r\n";

            Mail.SendMail("日次レポート サーバの状態 " + DateTime.Now.DayOfWeek,
                "【Cドライブ空容量】\r\n" + ドライブ空容量 + "\r\n" +
                "【ファイルサイズ】\r\n" + ファイルサイズ) ;

        }

        private void エラーチェック()
        {

        }

        #endregion


        #region イベントハンドラ timer

        private void timer_Tick_20min(object sender, EventArgs e)
        {
            try
            {
                if (chk自動開始.Checked == false) return;

                if (DateTime.Now.Hour == 6 || DateTime.Now.Hour == 7)
                {
                    本実行();
                }
                else if (DateTime.Now.Hour == 8)
                {
                    日次レポート送信();
                }
                else if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday && DateTime.Now.Hour > 9)
                {
                    ログ.ログ書き出し("Application.Exit 2");
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                注文共通.Exception共通(ex, new List<Cエラー関連変数>());
                システム設定.DB接続();
            }
        }

        #endregion

        private void 本実行()
        {
            DB.BulkCopyExecLog.InsertExecLog(処理区分.Tick.ToString(), "20min", null, null, null);

            int InsertCount = 0;
            Transaction収集(int.Parse(txt買いポジション用口座ANo.Text), int.Parse(txtOandaAccountId買いポジション用口座A.Text), ref InsertCount);
            Transaction収集(int.Parse(txt買いポジション用口座BNo.Text), int.Parse(txtOandaAccountId買いポジション用口座B.Text), ref InsertCount);
            Transaction収集(int.Parse(txt売りポジション用口座ANo.Text), int.Parse(txtOandaAccountId売りポジション用口座A.Text), ref InsertCount);
            Transaction収集(int.Parse(txt売りポジション用口座BNo.Text), int.Parse(txtOandaAccountId売りポジション用口座B.Text), ref InsertCount);

            DB.BulkCopyExecLog.InsertExecLog(処理区分.Swap記録.ToString(), null, null, $"Insert Transaction ({InsertCount}件)", null);

            if (InsertCount > 0)
            {
                DB_SwapCollect.swap.InsertSwap手動登録_Day1_toDemo();
                DB_SwapCollect.swap.InsertSwap手動登録_Day1_toReal();
            }

            DB.BulkCopyExecLog.ExecLogFlush();
        }



        //private static async Task Transaction収集Async_買い(int 口座No, int OandaAccountId)
        //{
        //    //FormData.OandaAccountId = OandaAccountId;
        //    CredentialsSt.SetCredentials(FormData.OandaEnvironment, FormData.OandaAccessToken, OandaAccountId);

        //    var result = await Rest.GetFullTransactionHistoryAsync(OandaAccountId);

        //    foreach (var transaction in result)
        //    {
        //        var 日時 = DateTime.Parse(transaction.time);

        //        oanda.InsertTransaction(口座No, transaction);
        //    }
        //}

        //private async void Transaction収集Async_売り(int 口座No, int OandaAccountId)
        //{
        //    //FormData.OandaAccountId = OandaAccountId;
        //    CredentialsSt.SetCredentials(FormData.OandaEnvironment, FormData.OandaAccessToken, OandaAccountId);

        //    var result = await Rest.GetFullTransactionHistoryAsync(OandaAccountId);

        //    var 今回最も新しかったもの = DateTime.MinValue;
        //    foreach (var transaction in result)
        //    {
        //        var 日時 = DateTime.Parse(transaction.time);

        //        if (日時 < OandaTransaction最終日時_売り口座) continue;

        //        oanda.InsertTransaction(口座No, transaction);

        //        if (今回最も新しかったもの < 日時)
        //        {
        //            今回最も新しかったもの = 日時;
        //        }
        //    }

        //    OandaTransaction最終日時_売り口座 = 今回最も新しかったもの;
        //}


    }
}
