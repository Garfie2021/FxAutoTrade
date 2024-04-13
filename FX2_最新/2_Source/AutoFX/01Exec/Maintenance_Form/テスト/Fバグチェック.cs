using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using 定数;
using 共通Data;
using Common;
using SystemSetting;
using DB_Maintenance;
using Maintenance_Form.F手動データ登録;
using Maintenance_Form.Fデータ加工;
using System.Text;


namespace Maintenance_Form.Fテストスイート
{
    public partial class Fバグチェック : Form
    {
        private SqlConnection Cn_Primary;
        private int 口座_Primary;
        private string コマンドライン_Primary;

        private SqlConnection Cn_ACV;
        private int 口座_ACV;
        private string コマンドライン_ACV;


        public Fバグチェック(SqlConnection cn_Primary, int 口座_Primary, string cmdline_Primary,
            SqlConnection cn_ACV, int 口座_ACV, string cmdline_ACV)
        {
            InitializeComponent();

            Cn_Primary = cn_Primary;
            口座_Primary = 口座_Primary;
            コマンドライン_Primary = cmdline_Primary;

            Cn_ACV = cn_ACV;
            口座_ACV = 口座_ACV;
            コマンドライン_ACV = cmdline_ACV;
        }

        private void Fバグチェック_Load(object sender, EventArgs e)
        {
            txtDB接続先_Primary.Text = Cn_Primary.ConnectionString;
            txt口座_Primary.Text = this.口座_Primary.ToString();
            txtコマンドライン_Primary.Text = コマンドライン_Primary;

            txtDB接続先_ACV.Text = Cn_ACV.ConnectionString;
            txt口座_ACV.Text = this.口座_ACV.ToString();
            txtコマンドライン_ACV.Text = コマンドライン_ACV;
        }

        private void btnサンプリング比較_Click(object sender, EventArgs e)
        {
            try
            {
                バグチェック.DBサンプリング比較(Cn_Primary, Cn_ACV);

                MessageBox.Show("完了");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }
    }
}
