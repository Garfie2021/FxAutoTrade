using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;
using 定数;
using 共通Data;
using Common;
using SystemSetting;
using DB_Maintenance;
using Maintenance_Form.F手動データ登録;
using Maintenance_Form.Fデータ加工;
using Maintenance_Form.Fテストスイート;


namespace Maintenance_Form
{
    public partial class FMaintenance : Form
    {
        //private List<string> DB一覧;

        public FMaintenance()
        {
            InitializeComponent();

            FormData.timer_1hour = new Timer();
            FormData.timer_1hour.Enabled = false;
            FormData.timer_1hour.Interval = 3600000;
            FormData.timer_1hour.Tick += new EventHandler(this.timer_Tick_1hour);

            FormData.ログフォルダ = Directory.GetCurrentDirectory() + "\\log";
            ログ.初期化();
        }

        //private List<通貨ぺア取引状況> 選択したデータベースから通貨ペアListを生成()
        //{
        //	if (cmbDB.Text.IndexOf(Company.FXCM.ToString(), StringComparison.Ordinal) > -1)
        //	{
        //		return Fxcm共通.通貨ペア初期化_FXCMUK();
        //	}
        //	else if (cmbDB.Text.IndexOf(Company.OANDA.ToString(), StringComparison.Ordinal) > -1)
        //	{
        //		return Oanda共通.通貨ペア初期化_OANDA_JP();
        //	}
        //	else
        //	{
        //		return null;
        //	}
        //}


        #region イベントハンドラ

        private void FMaintenance_Load(object sender, EventArgs e)
        {
            var commandLine = Environment.GetCommandLineArgs()[1].Split(';');

            if (Environment.GetCommandLineArgs().Length > 1)
            {
                if (Environment.GetCommandLineArgs()[1].IndexOf("Auto") >= 0)
                {
                    chk自動開始.Checked = true;
                    FormData.timer_1hour.Enabled = true;
                }
            }

            // コンボボックス初期化（サーバ）
            cmbサーバ.Items.Add("localhost");
            cmbサーバ.Items.Add("1111.5");
            cmbサーバ.Text = "1111.5";


            // コンボボックス初期化（DB）
            //using (SqlConnection cn = new SqlConnection())
            //{
            //    cn.ConnectionString = DB定数.GetConnectionString("FXCM");
            //    cn.Open();
            //    mstr.DB一覧取得(cn, ref cmbDB);
            //}
            cmbDB.Items.Add("OANDA_DemoB");
            cmbDB.Items.Add("OANDA_DemoB_ACV");
            cmbDB.Items.Add("OANDA_RealA");
            cmbDB.Items.Add("OANDA_RealA_ACV");
            cmbDB.Text = commandLine[1];


            // コンボボックス初期化（口座）
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
            cmbコマンドライン.Text = "Auto;OANDA_DemoB;1;Slave";



            string arg = "OANDA";   // FXCMに対応する日が来ないのでデフォルトはOANDAにしておく

            if (Environment.GetCommandLineArgs().Length > 1)
            {
                // CommandLineを元にデフォルト選択しておく
                arg = Environment.GetCommandLineArgs()[1];
            }

        }

        private void chk自動開始_CheckedChanged(object sender, EventArgs e)
        {
            if (chk自動開始.Checked)
            {
                txtステータス.Text = "実行中";
            }
            else
            {
                txtステータス.Text = "停止中";
            }
        }

        #region メンテナンス

        private void btnSwap手動登録_Click(object sender, EventArgs e)
        {
            try
            {
                システム設定.CommandLineから環境設定();

                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = Maintenance共通.GetConnectionString(cmbサーバ.Text, cmbDB.Text);
                    cn.Open();

                    var FSwap手動登録 = new FSwap手動登録(cn);
                    FSwap手動登録.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnRate手動登録_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = Maintenance共通.GetConnectionString(cmbサーバ.Text, cmbDB.Text);
                    cn.Open();

                    var FRate手動登録 = new FRate手動登録(cn);
                    FRate手動登録.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn通貨ペア再登録_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = Maintenance共通.GetConnectionString(cmbサーバ.Text, cmbDB.Text);
                    cn.Open();

                    var FMstデータ再登録 = new FMstデータ再登録(cn);
                    FMstデータ再登録.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn口座登録_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = Maintenance共通.GetConnectionString(cmbサーバ.Text, cmbDB.Text);
                    cn.Open();

                    var F口座登録 = new F口座登録(cn);
                    F口座登録.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn環境設定_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = Maintenance共通.GetConnectionString(cmbサーバ.Text, cmbDB.Text);
                    cn.Open();

                    var F環境設定 = new F環境設定(cn);
                    F環境設定.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn全通貨ペアで注文_Click(object sender, EventArgs e)
        {
            try
            {
                FormData.CommandLine = cmbコマンドライン.Text;
                システム設定.CommandLine取得(true);
                システム設定.CommandLineから環境設定();

                var F全通貨ペアで注文 = new F全通貨ペアで注文();
                F全通貨ペアで注文.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn注文を全て削除_Click(object sender, EventArgs e)
        {
            try
            {
                FormData.CommandLine = cmbコマンドライン.Text;
                システム設定.CommandLine取得(true);
                システム設定.CommandLineから環境設定();

                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = Maintenance共通.GetConnectionString(cmbサーバ.Text, cmbDB.Text);
                    cn.Open();

                    FormData.TradeApi.注文を全て削除();
                    MessageBox.Show("注文を全て削除しました");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn全ポジションをクローズ_Click(object sender, EventArgs e)
        {
            try
            {
                FormData.CommandLine = cmbコマンドライン.Text;
                システム設定.CommandLine取得(true);
                FormData.口座No = int.Parse(cmb口座.Text);
                システム設定.CommandLineから環境設定();

                OANDAv1.OANDAv1.ログイン();

                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = Maintenance共通.GetConnectionString(cmbサーバ.Text, cmbDB.Text);
                    cn.Open();

                    FormData.TradeApi.全ポジションをクローズする();
                    MessageBox.Show("ポジションを全てクローズしました");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        #endregion


        #region テスト

        private void btnDBスクリプト_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = Maintenance共通.GetConnectionString(cmbサーバ.Text, cmbDB.Text);
                    cn.Open();

                    var FDBスクリプト = new FDBスクリプト();
                    FDBスクリプト.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnバグチェック_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDB.Text.IndexOf("_ACV") > -1)
                {
                    MessageBox.Show("初期設定が「ACV」では実行不可");
                    return;
                }

                using (SqlConnection cn_Primary = new SqlConnection())
                using (SqlConnection cn_ACV = new SqlConnection())
                {
                    cn_Primary.ConnectionString = Maintenance共通.GetConnectionString(cmbサーバ.Text, cmbDB.Text);
                    cn_Primary.Open();

                    cn_ACV.ConnectionString = Maintenance共通.GetConnectionString(cmbサーバ.Text, cmbDB.Text + "_ACV");
                    cn_ACV.Open();

                    var Fバグチェック = new Fバグチェック(cn_Primary, FormData.口座No, FormData.CommandLine,
                        cn_ACV, FormData.口座No, FormData.CommandLine + "_ACV");
                    Fバグチェック.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnテスト_Click(object sender, EventArgs e)
        {
            try
            {
                FormData.DBConnectionString = Maintenance共通.GetConnectionString(cmbサーバ.Text, cmbDB.Text);
                システム設定.DB接続();

                FormData.口座No = int.Parse(cmb口座.Text);
                FormData.CommandLine = cmbコマンドライン.Text;

                var Fテスト = new Fテスト(FormData.cn, FormData.口座No, FormData.CommandLine);
                Fテスト.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnシュミレーション_Click(object sender, EventArgs e)
        {
            try
            {
                //FormData.口座No = int.Parse(cmb口座.Text);
                //FormData.CommandLine = cmbコマンドライン.Text;

                //システム設定.CommandLineから環境設定();

                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = Maintenance共通.GetConnectionString(cmbサーバ.Text, cmbDB.Text);
                    cn.Open();

                    var Fシュミレーション = new Fシュミレーション(cn, FormData.口座No, FormData.CommandLine);
                    Fシュミレーション.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }


        #endregion


        #region 件数確認

        private void btn件数確認_Click(object sender, EventArgs e)
        {
            try
            {
                FormData.口座No = int.Parse(cmb口座.Text);
                FormData.CommandLine = cmbコマンドライン.Text;

                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = Maintenance共通.GetConnectionString(cmbサーバ.Text, cmbDB.Text);
                    cn.Open();

                    var F件数確認 = new F件数確認(cn, FormData.口座No, FormData.CommandLine);
                    F件数確認.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn注文可能通貨ペア_Click(object sender, EventArgs e)
        {
            try
            {
                FormData.口座No = int.Parse(cmb口座.Text);
                FormData.CommandLine = cmbコマンドライン.Text;

                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = Maintenance共通.GetConnectionString(cmbサーバ.Text, cmbDB.Text);
                    cn.Open();

                    var F注文可能通貨ペア = new F注文可能通貨ペア(cn, FormData.口座No, FormData.CommandLine);
                    F注文可能通貨ペア.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        // ※作りかけ
        private void btnSwapマイナスポジション_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = Maintenance共通.GetConnectionString(cmbサーバ.Text, cmbDB.Text);
                    cn.Open();

                    string resutl = "通貨ペアNo\tInstrument\t買いRate\t少数点の桁数取得\r\n";

                    FormData.OrderData = new OrderData();
                    FormData.OrderData.now = DateTime.Now;
                    注文共通.StartTime_EndTime取得(FormData.OrderData);

                    OANDAv1.OANDAv1.通貨ペアRate更新(FormData.OrderData, FormData.通貨ぺア別取引状況);

                    foreach (var 通貨ぺア取引状況 in FormData.通貨ぺア別取引状況)
                    {
                        DB.hstr.Get最新Rate(通貨ぺア取引状況);

                        DB.oder.GetWMA_Month1(FormData.OrderData, 通貨ぺア取引状況);
                        DB.oder.GetWMA_Week1(FormData.OrderData, 通貨ぺア取引状況);
                        DB.oder.GetWMA_Day1(FormData.OrderData, 通貨ぺア取引状況);
                        DB.oder.GetWMA_Hour1(FormData.OrderData, 通貨ぺア取引状況);
                        DB.oder.GetWMA_Min15(FormData.OrderData, 通貨ぺア取引状況);
                        DB.oder.GetWMA_Min5(FormData.OrderData, 通貨ぺア取引状況);
                        DB.oder.GetWMA_Min1(FormData.OrderData, 通貨ぺア取引状況);
                    }

                    OANDAv1.OANDAv1.マイナスInstrument更新(false);

                    //resutl +=
                    //    通貨ぺア取引状況.通貨ペアNo + "\t" +
                    //    通貨ぺア取引状況.Instrument + "\t" +
                    //    通貨ぺア取引状況.買いRate + "\t" +
                    //    注文共通.少数点の桁数取得(通貨ぺア取引状況.買いRate) + "\r\n";

                    var F結果 = new F結果(resutl);
                    F結果.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }

        }

        private void btnRateの少数点桁数表示_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = Maintenance共通.GetConnectionString(cmbサーバ.Text, cmbDB.Text);
                    cn.Open();

                    string resutl = "通貨ペアNo\tInstrument\t買いRate\t少数点の桁数取得\r\n";

                    FormData.OrderData = new OrderData();
                    FormData.OrderData.now = DateTime.Now;
                    注文共通.StartTime_EndTime取得(FormData.OrderData);

                    OANDAv1.OANDAv1.通貨ペアRate更新(FormData.OrderData, FormData.通貨ぺア別取引状況);

                    foreach (var 通貨ぺア取引状況 in FormData.通貨ぺア別取引状況)
                    {
                        resutl += 通貨ぺア取引状況.通貨ペアNo + "\t" + 通貨ぺア取引状況.Instrument + "\t" + 通貨ぺア取引状況.買いRate + "\t" + 注文共通.少数点の桁数取得(通貨ぺア取引状況.買いRate) + "\r\n";
                    }

                    var F結果 = new F結果(resutl);
                    F結果.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        #endregion

        #region レポート

        private void btn日次レポート_Click(object sender, EventArgs e)
        {
            try
            {
                FormData.口座No = int.Parse(cmb口座.Text);
                FormData.CommandLine = cmbコマンドライン.Text;

                システム設定.CommandLineから環境設定();

                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = Maintenance共通.GetConnectionString(cmbサーバ.Text, cmbDB.Text);
                    cn.Open();

                    var F日次レポート = new F日次レポート(FormData.cn, FormData.口座No, FormData.CommandLine);
                    F日次レポート.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn週次レポート_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = Maintenance共通.GetConnectionString(cmbサーバ.Text, cmbDB.Text);
                    cn.Open();

                    var F週次レポート = new F週次レポート(cn);
                    F週次レポート.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        #endregion

        #region レポートメール

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
            システム設定.CommandLineから環境設定();

            var DemoReal = システム設定.DemoReal判定(FormData.DBConnectionString);

            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = FormData.DBConnectionString;
                cn.Open();

                // 日次レポート DB統計

                Mail.SendMail($"日次レポート DB統計 {DemoReal} " + DateTime.Now.DayOfWeek,
                    FormData.DBConnectionString + "\r\n\r\n" +
                    DataTable共通.DataTable_ToText(system.SelectDB統計(cn)));

                if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday || DateTime.Now.DayOfWeek == DayOfWeek.Monday)
                {
                    return;
                }

                DateTime 開始日時 = DateTime.Parse(DateTime.Now.AddDays(-1).ToShortDateString() + " 06:00:00");
                DateTime 終了日時 = DateTime.Parse(DateTime.Now.ToShortDateString() + " 06:00:00");

                // 日次レポート Rate判定

                Mail.SendMail($"日次レポート Rate判定 {DemoReal} " + DateTime.Now.DayOfWeek,
                    FormData.DBConnectionString + "\r\n\r\n" +
                    "【期間】\r\n" + 開始日時.ToString("yyyy/MM/dd hh:mm:ss") + "～" + 終了日時.ToString("yyyy/MM/dd hh:mm:ss") + "\r\n" +
                    "【anls Select想定売買タイミング　Swap判定有り】\r\n" +
                    DataTable共通.DataTable_ToText(anls.Select想定売買タイミング(cn, 開始日時, 終了日時, 0)) +
                    "【hstr BonusStage】\r\n" +
                    DataTable共通.DataTable_ToText(hstr.SelectBonusStage(cn, 開始日時, 終了日時)));

                foreach (DataRow 口座 in DB_Maintenance.cmn.Select口座一覧(cn).Rows)
                {
                    int 口座No = (int)口座["口座No"];

                    // 日次レポート 注文判定

                    string 件名 = $"日次レポート 注文判定 {DemoReal} 口座No{口座No} " + DateTime.Now.DayOfWeek;

                    StringBuilder 本文 = new StringBuilder(数値定数._1MB);
                    本文.AppendLine(FormData.DBConnectionString);
                    本文.AppendLine();
                    本文.AppendLine("【期間】");
                    本文.AppendLine(開始日時.ToString("yyyy/MM/dd hh:mm:ss") + "～" + 終了日時.ToString("yyyy/MM/dd hh:mm:ss"));
                    本文.AppendLine();
                    本文.AppendLine("【oanda Account】");
                    本文.AppendLine(DataTable共通.DataTable_ToText(oanda.SelectAccount_MinMax(cn, 口座No, 開始日時, 終了日時)));
                    本文.AppendLine();
                    本文.AppendLine("【pfmc ポジションHourly】");
                    本文.AppendLine(DataTable共通.DataTable_ToText(pfmc.SelectポジションHourly(cn, 口座No, 開始日時, 終了日時)));
                    本文.AppendLine();
                    本文.AppendLine("【oder OrderHistory】");
                    本文.AppendLine(DataTable共通.DataTable_ToText(oder.SelectOrderHistory(cn, 口座No, 開始日時, 終了日時)));
                    本文.AppendLine();
                    本文.AppendLine("【oanda OrderResponse】");
                    本文.AppendLine(DataTable共通.DataTable_ToText(oanda.SelectOrderResponse(cn, 口座No, 開始日時, 終了日時)));
                    本文.AppendLine();
                    本文.AppendLine("【oanda Order_注文削除】");
                    本文.AppendLine(DataTable共通.DataTable_ToText(oanda.SelectOrder_注文削除(cn, 口座No, 開始日時, 終了日時)));
                    本文.AppendLine();
                    本文.AppendLine("【oanda Trade】");
                    本文.AppendLine(DataTable共通.DataTable_ToText(oanda.SelectTrade(cn, 口座No, 開始日時, 終了日時)));
                    本文.AppendLine();
                    本文.AppendLine("【oanda Trade_リミット変更】");
                    本文.AppendLine(DataTable共通.DataTable_ToText(oanda.SelectTrade_リミット変更(cn, 口座No, 開始日時, 終了日時)));
                    本文.AppendLine();
                    本文.AppendLine("【oanda Transaction】");
                    本文.AppendLine(DataTable共通.DataTable_ToText(oanda.SelectTransaction(cn, 口座No, 開始日時, 終了日時)));
                    本文.AppendLine();
                    本文.AppendLine("【pfmc ExecLog】");
                    本文.AppendLine(DataTable共通.DataTable_ToText(pfmc.SelectExecLog(cn, 口座No, 開始日時, 終了日時)));

                    Mail.SendMail(件名, 本文.ToString());
                }
            }
        }

        private void 月次レポート送信()
        {
            システム設定.CommandLineから環境設定();

            var DemoReal = システム設定.DemoReal判定(FormData.DBConnectionString);
            var 開始日時 = DateTime.Parse(DateTime.Now.AddMonths(-1).ToShortDateString() + " 06:00:00");
            var 終了日時 = DateTime.Parse(DateTime.Now.ToShortDateString() + " 06:00:00");

            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = FormData.DBConnectionString;
                cn.Open();

                foreach (DataRow 口座 in DB_Maintenance.cmn.Select口座一覧(cn).Rows)
                {
                    int 口座No = (int)口座["口座No"];

                    string 件名 = $"月次レポート 利益出金 {DemoReal} 口座No{口座No} ";

                    StringBuilder 本文 = new StringBuilder(数値定数._1MB);
                    本文.AppendLine(FormData.DBConnectionString);
                    本文.AppendLine();
                    本文.AppendLine("【期間】");
                    本文.AppendLine(開始日時.ToString("yyyy/MM/dd hh:mm:ss") + "～" + 終了日時.ToString("yyyy/MM/dd hh:mm:ss"));
                    本文.AppendLine();
                    本文.AppendLine("【利益】");
                    本文.AppendLine(DataTable共通.DataTable_ToText(oanda.SelectTransaction月次利益請求(cn, 口座No, 開始日時, 終了日時)));

                    Mail.SendMail(件名, 本文.ToString());
                }
            }
        }

        private void btn週次レポート送信_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region 推移確認

        private void btn利益推移_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = Maintenance共通.GetConnectionString(cmbサーバ.Text, cmbDB.Text);
                    cn.Open();

                    DateTime 開始日時 = DateTime.Parse("1900/01/01");
                    DateTime 終了日時 = DateTime.Parse("2100/01/01");

                    FormData.口座No = int.Parse(cmb口座.Text);
                    FormData.CommandLine = cmbコマンドライン.Text;

                    var F推移確認 = new F推移確認(cn, oanda.SelectAccount(cn, FormData.口座No, 開始日時, 終了日時), FormData.口座No, FormData.CommandLine);
                    F推移確認.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn注文単位推移_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = Maintenance共通.GetConnectionString(cmbサーバ.Text, cmbDB.Text);
                    cn.Open();

                    DateTime 開始日時 = DateTime.Parse("1900/01/01");
                    DateTime 終了日時 = DateTime.Parse("2100/01/01");

                    FormData.口座No = int.Parse(cmb口座.Text);
                    FormData.CommandLine = cmbコマンドライン.Text;

                    var F推移確認 = new F推移確認(cn, oder.SelectOrderHistory2_注文単位(cn, FormData.口座No, 開始日時, 終了日時), FormData.口座No, FormData.CommandLine);
                    F推移確認.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnRate推移_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn集計Day_Click(object sender, EventArgs e)
        {

        }

        private void btn集計Week_Click(object sender, EventArgs e)
        {

        }

        private void btn集計Month_Click(object sender, EventArgs e)
        {

        }

        private void btn集計Year_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region データ加工

        private void btn日毎に横並び_Hour1_Click(object sender, EventArgs e)
        {
            try
            {
                FormData.口座No = int.Parse(cmb口座.Text);
                FormData.CommandLine = cmbコマンドライン.Text;

                システム設定.CommandLineから環境設定();

                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = Maintenance共通.GetConnectionString(cmbサーバ.Text, cmbDB.Text);
                    cn.Open();

                    var F日毎に横並び = new F日毎に横並び(cn, FormData.口座No, FormData.CommandLine);
                    F日毎に横並び.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }


        #endregion

        #region Timerテスト

        private void btnTimerHour1_Click(object sender, EventArgs e)
        {
            FormData.timer_1hour.Interval = 1;
        }

        #endregion

        #region timer

        private void timer_Tick_1hour(object sender, EventArgs e)
        {
            try
            {
                if (chk自動開始.Checked == false)
                {
                    return;
                }

                if (DateTime.Now.Hour == 8)
                {
                    DB.BulkCopyExecLog.InsertExecLog(処理区分.Tick.ToString(), "1hour", null, "日次レポートメール", null);

                    日次レポート送信();


                    if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
                    {
                        DB.BulkCopyExecLog.InsertExecLog(処理区分.Tick.ToString(), "1hour", null, "週次バグチェックレポート", null);

                        using (SqlConnection cn_Primary = new SqlConnection())
                        using (SqlConnection cn_ACV = new SqlConnection())
                        {
                            cn_Primary.ConnectionString = Maintenance共通.GetConnectionString(cmbサーバ.Text, cmbDB.Text);
                            cn_Primary.Open();

                            cn_ACV.ConnectionString = Maintenance共通.GetConnectionString(cmbサーバ.Text, cmbDB.Text + "_ACV");
                            cn_ACV.Open();

                            バグチェック.DBサンプリング比較(cn_Primary, cn_ACV);
                        }
                    }

                    if (DateTime.Now.Day == 1)
                    {
                        DB.BulkCopyExecLog.InsertExecLog(処理区分.Tick.ToString(), "1hour", null, "月次レポート", null);

                        月次レポート送信();
                    }
                }
                else if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday && DateTime.Now.Hour > 8)
                {
                    DB.BulkCopyExecLog.InsertExecLog(処理区分.Tick.ToString(), "1hour", null, "週次アプリケーション終了", null);

                    ログ.ログ書き出し("Application.Exit 2");
                    Application.Exit();
                }
                else
                {
                    // DB.BulkCopyExecLog.ExecLogFlush() のみ実行するとExceptionになる。
                    return;
                }

                DB.BulkCopyExecLog.ExecLogFlush();
            }
            catch (Exception ex)
            {
                注文共通.Exception共通(ex, new List<Cエラー関連変数>());
                システム設定.DB接続();
            }
        }

        #endregion

        #endregion


    }
}
