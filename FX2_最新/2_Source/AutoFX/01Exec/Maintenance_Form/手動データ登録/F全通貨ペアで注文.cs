using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 定数;
using 共通Data;
using Common;
using DB;
using SystemSetting;
using OANDAv1;


namespace Maintenance_Form.F手動データ登録
{
    public partial class F全通貨ペアで注文 : Form
    {
        public F全通貨ペアで注文()
        {
            InitializeComponent();
        }

        private void F全通貨ペアで注文_Load(object sender, EventArgs e)
        {
            //txt接続先.Text = 
            //    "DB接続先： " + FormData.cn.ConnectionString + "\r\n" +
            //    "口座： " + FormData.口座No + "\r\n" +
            //    "コマンドライン： " + FormData.CommandLine + "\r\n" +
            //    "OandaEnvironment： " + FormData.OandaEnvironment + "\r\n" +
            //    "OandaAccessToken： " + FormData.OandaAccessToken + "\r\n" +
            //    "OandaAccountId： " + FormData.OandaAccountId;
            txt接続先.Text = "DB接続先： " + FormData.cn.ConnectionString + "\r\n";
        }

        // 
        private void 注文(string 売買モード, byte 通貨ペアNo_開始, byte 通貨ペアNo_終了)
        {
            OANDAv1.OANDAv1.ログイン();
            OANDAv1.OANDAv1.OoandaInstrument取得();

            foreach (var 通貨ぺア取引状況 in FormData.通貨ぺア別取引状況)
            {
                if (通貨ぺア取引状況.通貨ペアNo < 通貨ペアNo_開始 || 通貨ペアNo_終了 < 通貨ぺア取引状況.通貨ペアNo) continue;

                var ポジション追加_成行_request = new Dictionary<string, string>
                {
                    {"instrument", 通貨ぺア取引状況.OandaInstrument.instrument},
                    {"units", txt1通貨ペアの注文数.Text},
                    {"side", 売買モード},
                    {"type", "market"},
                    {"expiry", DateTime.Now.AddMinutes(3).ToString( "yyyy-MM-dd'T'HH:mm:ss'Z'")}
                };

                Rest.PostOrderAsync(FormData.OandaAccountId, ポジション追加_成行_request);
            }
        }

        private void btn注文実行_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var 通貨ぺア取引状況 in FormData.通貨ぺア別取引状況)
                {
                    cmn.Get起動初期値_通貨ペア別(通貨ぺア取引状況);
                }

                FormData.OandaAccessToken = txtAccessToken.Text;


                FormData.OandaAccountId = int.Parse(txtOandaAccountId買いポジション用口座A.Text);
                注文("buy", 0, 49);

                FormData.OandaAccountId = int.Parse(txtOandaAccountId買いポジション用口座B.Text);
                注文("buy", 50, 99);


                FormData.OandaAccountId = int.Parse(txtOandaAccountId売りポジション用口座A.Text);
                注文("sell", 0, 49);

                FormData.OandaAccountId = int.Parse(txtOandaAccountId売りポジション用口座B.Text);
                注文("sell", 50, 99);

                MessageBox.Show("完了");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
