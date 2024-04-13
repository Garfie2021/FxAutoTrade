using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using 定数;
using 共通Data;
using DB_Maintenance;


namespace Maintenance_Form
{
    public partial class F口座登録 : Form
    {
        private SqlConnection Cn;


        public F口座登録(SqlConnection cn)
        {
            InitializeComponent();

            Cn = cn;
        }

        private void F口座登録_Load(object sender, EventArgs e)
        {
            cmbFX会社.DataSource = Enum.GetValues(typeof(Company));
            cmbFxServerContry.DataSource = Enum.GetValues(typeof(Contry));
            cmb個人法人.DataSource = Enum.GetValues(typeof(個人法人));
            cmbDemoReal.DataSource = Enum.GetValues(typeof(DemoReal));
            cmb毎朝の自動注文開始を行う.DataSource = Enum.GetValues(typeof(毎朝の自動注文開始を行う));
        }

        private void btn登録_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = FormData.DBConnectionString;
                    cn.Open();

                    cmn.Insert口座マスタ(cn,
                        txtOandaAccountId.Text,
                        txtOandaAccessToken.Text,
                        (Company)cmbFX会社.SelectedItem,
                        (Contry)cmbFxServerContry.SelectedItem,
                        (個人法人)cmb個人法人.SelectedItem,
                        (DemoReal)cmbDemoReal.SelectedItem,
                        有効無効.有効,
                        txt取引証拠金上限.Text,
                        (毎朝の自動注文開始を行う)cmb毎朝の自動注文開始を行う.SelectedItem);
                }

                MessageBox.Show("登録完了");

                txtOandaAccountId.Text = "";
                txtOandaAccessToken.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }
    }
}
