using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using 定数;
using DB_Maintenance;


namespace Maintenance_Form
{
    public partial class F注文可能通貨ペア : Form
    {
        private SqlConnection Cn;
        private int 口座;
        private string コマンドライン;


        public F注文可能通貨ペア(SqlConnection cn, int 口座, string コマンドライン)
        {
            InitializeComponent();

            Cn = cn;
            this.口座 = 口座;
            this.コマンドライン = コマンドライン;
        }

        private void F注文可能通貨ペア_Load(object sender, EventArgs e)
        {
            txtDB接続先.Text = Cn.ConnectionString;
            txt口座.Text = this.口座.ToString();
            txtコマンドライン.Text = this.コマンドライン;
        }

        private void btn通貨ペア抽出_Click(object sender, EventArgs e)
        {
            try
            {
                var F結果 = new F結果(oanda.注文可能通貨ペア確認(Cn).Replace("\\r\\n", "\r\n").Replace("\\t", "\t"));
                F結果.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn通貨ペア別の最新売買スワップ_Click(object sender, EventArgs e)
        {
            try
            {
                //var F結果 = new F結果(oanda.注文可能通貨ペア確認(Cn));
                var F結果 = new F結果(oanda.注文可能通貨ペア確認(Cn).Replace("\\r\\n", "\r\n").Replace("\\t", "\t"));
                F結果.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnOANDAが扱っている通貨ペア一覧_Click(object sender, EventArgs e)
        {
            try
            {
                //var F結果 = new F結果(oanda.注文可能通貨ペア確認(Cn));
                var form = new FOANDAが扱っている通貨ペア一覧();
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
            
        }
    }
}
