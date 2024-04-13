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
using DB_Maintenance;
using Maintenance_Form.Fグラフ;


namespace Maintenance_Form
{
    public partial class F推移確認 : Form
    {
        private DataTable dtResult;

        private SqlConnection Cn;
        private int 口座;
        private string コマンドライン;


        public F推移確認(SqlConnection cn, DataTable dt, int 口座, string コマンドライン)
        {
            InitializeComponent();

            dtResult = dt;

            Cn = cn;
            this.口座 = 口座;
            this.コマンドライン = コマンドライン;
        }

        private void F推移確認_Load(object sender, EventArgs e)
        {
            txtDB接続先.Text = Cn.ConnectionString;
            txt口座.Text = this.口座.ToString();
            txtコマンドライン.Text = this.コマンドライン;

            dgv結果.DataSource = dtResult;
        }

        private void btn表示_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn折れ線グラフで表示_Click(object sender, EventArgs e)
        {
            try
            {
                var F折れ線グラフ = new F折れ線グラフ(dgv結果, dtResult);
                F折れ線グラフ.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }

        }
    }
}
