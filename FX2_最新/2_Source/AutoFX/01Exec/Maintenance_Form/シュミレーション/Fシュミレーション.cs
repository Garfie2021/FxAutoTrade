using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text;
using 定数;
using 共通Data;
using Common;
using SystemSetting;
using DB_Maintenance;
using Maintenance_Form.F手動データ登録;
using Maintenance_Form.Fデータ加工;
using Maintenance_Form.シュミレーション;


namespace Maintenance_Form
{
    public partial class Fシュミレーション : Form
    {
        private SqlConnection Cn;
        private int 口座;
        private string コマンドライン;

        public Fシュミレーション(SqlConnection cn, int 口座, string コマンドライン)
        {
            InitializeComponent();

            Cn = cn;
            this.口座 = 口座;
            this.コマンドライン = コマンドライン;
        }

        private void Fシュミレーション_Load(object sender, EventArgs e)
        {
            txtDB接続先.Text = Cn.ConnectionString;
            txt口座.Text = this.口座.ToString();
            txtコマンドライン.Text = this.コマンドライン;
        }

        private void btnOrder_Ver7_WMA反転_BS_Click(object sender, EventArgs e)
        {
            try
            {
                シュミレーションログ.初期化();

                var param = new Order_v7_Param() {
                    閾値_買いWMAs2角度 = -10.0,
                    閾値_経過時間カウント = 3,
                    cn = Cn
                };

                DB.cmn.SqlCommandInitialize(param.cn);

                param.dtHour1 = hstr.SelectHour1(param.cn, param.通貨ペアNo, DateTime.Parse("1900/01/01"));

                txtログ.Text = Order_v7.Hour1のみでWMAが反転した際に注文(param);

                MessageBox.Show("シュミレーション終了");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.Source, "エラー");
            }
        }

        private void btn週次に対して日次が反転した際に注文_Click(object sender, EventArgs e)
        {
            try
            {
                シュミレーションログ.初期化();

                var param = new Order_v7_Param()
                {
                    cn = Cn
                };

                DB.cmn.SqlCommandInitialize(param.cn);

                param.dtHour1 = hstr.SelectHour1(param.cn, param.通貨ペアNo, DateTime.Parse("1900/01/01"));

                txtログ.Text = Order_v7.週次に対して日次が反転した際に注文(param);

                MessageBox.Show("シュミレーション終了");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.Source, "エラー");
            }
        }
    }
}
