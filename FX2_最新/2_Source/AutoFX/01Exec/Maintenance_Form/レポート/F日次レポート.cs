using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;
using 共通Data;
using Common;
using DB_Maintenance;

namespace Maintenance_Form
{
    public partial class F日次レポート : Form
    {
        private SqlConnection Cn;
        private int 口座;
        private string コマンドライン;


        public F日次レポート(SqlConnection cn, int 口座, string コマンドライン)
        {
            InitializeComponent();

            Cn = cn;
            this.口座 = 口座;
            this.コマンドライン = コマンドライン;
        }

        #region privateメソッド

        private string レポート作成(DateTime 日付)
        {
            txtDB接続先.Text = Cn.ConnectionString;
            txt口座.Text = this.口座.ToString();
            txtコマンドライン.Text = this.コマンドライン;

            string result = "";

            DateTime 開始日時 = DateTime.Parse(日付.ToShortDateString() + " 06:00:00");
            DateTime 終了日時 = DateTime.Parse(日付.AddDays(1).ToShortDateString() + " 06:00:00");

            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = FormData.DBConnectionString;
                cn.Open();

                result += "\r\n【DB統計】\r\n";
                result += DataTable共通.DataTable_ToText(system.SelectDB統計(cn));

                result += "\r\n【期間】\r\n";
                result += 開始日時.ToString("yyyy/MM/dd hh:mm:ss") + "～" + 終了日時.ToString("yyyy/MM/dd hh:mm:ss") + "\r\n";

                //result += "\r\n【SWAPがプラスの通貨】\r\n";
                //result += anls.Get売買タイミング評価(cn, 開始日時) + "\r\n";

                result += "\r\n【anls Select想定売買タイミング　Swap判定有り】\r\n";
                result += DataTable共通.DataTable_ToText(anls.Select想定売買タイミング(cn, 開始日時, 終了日時, 0));

                if (chkSelect想定売買タイミングSwap判定無しを表示する.Checked)
                {
                    result += "\r\n【anls Select想定売買タイミング　Swap判定無し】\r\n";
                    result += DataTable共通.DataTable_ToText(anls.Select想定売買タイミング_Swap判定無し(cn, 開始日時, 終了日時));
                }

                result += "\r\n【hstr BonusStage】\r\n";
                result += DataTable共通.DataTable_ToText(hstr.SelectBonusStage(cn, 開始日時, 終了日時));

                foreach (DataRow 口座 in DB_Maintenance.cmn.Select口座一覧(cn).Rows)
                {
                    int 口座No = (int)口座["口座No"];

                    result += $"\r\n【口座No：{口座No}】\r\n";

                    result += "\r\n【oanda Account】\r\n";
                    result += DataTable共通.DataTable_ToText(oanda.SelectAccount_MinMax(cn, 口座No, 開始日時, 終了日時));

                    result += "\r\n【pfmc ポジションHourly】\r\n";
                    result += DataTable共通.DataTable_ToText(pfmc.SelectポジションHourly(cn, 口座No, 開始日時, 終了日時));

                    result += "\r\n【oder OrderHistory】\r\n";
                    result += DataTable共通.DataTable_ToText(oder.SelectOrderHistory(cn, 口座No, 開始日時, 終了日時));

                    result += "\r\n【oanda OrderResponse】\r\n";
                    result += DataTable共通.DataTable_ToText(oanda.SelectOrderResponse(cn, 口座No, 開始日時, 終了日時));

                    result += "\r\n【oanda Order_注文削除】\r\n";
                    result += DataTable共通.DataTable_ToText(oanda.SelectOrder_注文削除(cn, 口座No, 開始日時, 終了日時));

                    result += "\r\n【oanda Trade】\r\n";
                    result += DataTable共通.DataTable_ToText(oanda.SelectTrade(cn, 口座No, 開始日時, 終了日時));

                    result += "\r\n【oanda Trade_リミット変更】\r\n";
                    result += DataTable共通.DataTable_ToText(oanda.SelectTrade_リミット変更(cn, 口座No, 開始日時, 終了日時));

                    result += "\r\n【oanda Transaction】\r\n";
                    result += DataTable共通.DataTable_ToText(oanda.SelectTransaction(cn, 口座No, 開始日時, 終了日時));

                    result += "\r\n【pfmc ExecLog】\r\n";
                    result += DataTable共通.DataTable_ToText(pfmc.SelectExecLog(cn, 口座No, 開始日時, 終了日時));

                    result += "\r\n【hstr BonusStage】\r\n";
                    result += DataTable共通.DataTable_ToText(hstr.SelectBonusStage(cn, 開始日時, 終了日時));

                    result += "\r\n【anls Select想定売買タイミング　Swap判定有り】\r\n";
                    result += DataTable共通.DataTable_ToText(anls.Select想定売買タイミング(cn, 開始日時, 終了日時, 0));
                }

            }

            return result;
        }

        private string レポート表示_通貨ペア別(DateTime 日付, ComboData 通貨ペア)
        {
            string result = "";

            DateTime 開始日時 = DateTime.Parse(日付.ToShortDateString() + " 06:00:00");
            DateTime 終了日時 = DateTime.Parse(日付.AddDays(1).ToShortDateString() + " 06:00:00");

            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = FormData.DBConnectionString;
                cn.Open();

                result += "\r\n【期間】\t" + 開始日時.ToString("yyyy/MM/dd hh:mm:ss") + "～" + 終了日時.ToString("yyyy/MM/dd hh:mm:ss") + "\r\n";
                result += "\r\n【通貨ペア】\t" + 通貨ペア.Instrument + "(" + 通貨ペア.通貨ペアNo + ")\r\n";

                //result += "\r\n【SWAPがプラスの通貨】\r\n";
                //result += anls.Get売買タイミング評価(cn, 開始日時) + "\r\n";

                result += "\r\n【anls Select想定売買タイミング　Swap判定有り】\r\n";
                result += DataTable共通.DataTable_ToText(anls.Select想定売買タイミング(cn, 開始日時, 終了日時, 0));

                if (chkSelect想定売買タイミングSwap判定無しを表示する.Checked)
                {
                    result += "\r\n【anls Select想定売買タイミング　Swap判定無し】\r\n";
                    result += DataTable共通.DataTable_ToText(anls.Select想定売買タイミング_Swap判定無し(cn, 開始日時, 終了日時));
                }

                result += "\r\n【hstr BonusStage】\r\n";
                result += DataTable共通.DataTable_ToText(hstr.SelectBonusStage(cn, 開始日時, 終了日時));

                result += "\r\n【oder OrderHistory】\r\n";
                result += DataTable共通.DataTable_ToText(oder.SelectOrderHistory(cn, FormData.口座No, 開始日時, 終了日時));

                result += "\r\n【oanda OrderResponse】\r\n";
                result += DataTable共通.DataTable_ToText(oanda.SelectOrderResponse(cn, FormData.口座No, 開始日時, 終了日時));

                result += "\r\n【oanda Order_注文削除】\r\n";
                result += DataTable共通.DataTable_ToText(oanda.SelectOrder_注文削除(cn, FormData.口座No, 開始日時, 終了日時));

                result += "\r\n【oanda Trade】\r\n";
                result += DataTable共通.DataTable_ToText(oanda.SelectTrade(cn, FormData.口座No, 開始日時, 終了日時));

                result += "\r\n【oanda Trade_リミット変更】\r\n";
                result += DataTable共通.DataTable_ToText(oanda.SelectTrade_リミット変更(cn, FormData.口座No, 開始日時, 終了日時));

                result += "\r\n【oanda Transaction】\r\n";
                result += DataTable共通.DataTable_ToText(oanda.SelectTransaction(cn, FormData.口座No, 開始日時, 終了日時));

                result += "\r\n【oanda Account】\r\n";
                result += DataTable共通.DataTable_ToText(oanda.SelectAccount_MinMax(cn, FormData.口座No, 開始日時, 終了日時));

                result += "\r\n【pfmc ポジションHourly】\r\n";
                result += DataTable共通.DataTable_ToText(pfmc.SelectポジションHourly(cn, FormData.口座No, 開始日時, 終了日時));

                result += "\r\n【pfmc ExecLog】\r\n";
                result += DataTable共通.DataTable_ToText(pfmc.SelectExecLog(cn, FormData.口座No, 開始日時, 終了日時));

            }

            return result;
        }

        private void 日付調整()
        {
            dtp日付.Value = DateTime.Now.AddDays(-1);

            if (dtp日付.Value.ToString("dddd") == "日曜日")
            {
                dtp日付.Value = dtp日付.Value.AddDays(-2);
            }
            else if (dtp日付.Value.ToString("dddd") == "土曜日")
            {
                dtp日付.Value = dtp日付.Value.AddDays(-1);
            }
        }

        private class ComboData
        {
            public byte 通貨ペアNo;
            public string Instrument;

            public override string ToString()
            {
                return Instrument;
            }
        }

        private void cmb通貨ペア_Item追加()
        {
            foreach (var aa in FormData.通貨ぺア別取引状況)
            {
                cmb通貨ペア.Items.Add(new ComboData()
                {
                    通貨ペアNo = aa.通貨ペアNo,
                    Instrument = aa.Instrument
                });
            }
        }

        #endregion


        #region イベントハンドラ

        private void F日次レポート_Load(object sender, EventArgs e)
        {
            txtDB接続先.Text = Cn.ConnectionString;
            txt口座.Text = this.口座.ToString();
            txtコマンドライン.Text = this.コマンドライン;

            // テスト向け初期化
            OANDAv1.OANDAv1.ログイン();
            OANDAv1.OANDAv1.OoandaInstrument取得();

            日付調整();
            cmb通貨ペア_Item追加();
        }


        private void btnレポート表示_Click(object sender, EventArgs e)
        {
            try
            {
                F結果 F結果 = new F結果(レポート作成(dtp日付.Value));
                F結果.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnレポートメール送信_Click(object sender, EventArgs e)
        {
            Mail.SendMail("日次レポート", レポート作成(dtp日付.Value));
        }

        private void btnレポート表示_DGV_Click(object sender, EventArgs e)
        {
            try
            {
                var F結果DGV = new F結果DGV(レポート作成(dtp日付.Value));
                F結果DGV.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnレポートファイル保存_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(Directory.GetCurrentDirectory() + @"\Report_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".tsv", レポート作成(dtp日付.Value), Encoding.GetEncoding("UTF-8"));

                MessageBox.Show("完了");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnレポート表示_通貨ペア別_DGV_Click(object sender, EventArgs e)
        {
            try
            {
                var F結果DGV = new F結果DGV(レポート表示_通貨ペア別(dtp日付.Value, (ComboData)cmb通貨ペア.SelectedItem));
                F結果DGV.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        #endregion

    }
}
