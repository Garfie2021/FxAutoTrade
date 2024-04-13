using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using 定数;
using 共通Data;
using DB;

namespace Maintenance_Form
{
    public partial class FSwap手動登録 : Form
    {
        SqlConnection Cn;

        public FSwap手動登録(SqlConnection cn)
        {
            InitializeComponent();

            Cn = cn;
        }


        #region イベントハンドラ

        private void FSwap手動登録_Load(object sender, EventArgs e)
        {
            foreach (var 通貨ぺア取引状況 in FormData.通貨ぺア別取引状況)
            {
                cmb通貨ペア.Items.Add(通貨ぺア取引状況.Instrument);
            }
        }

        private void cmb通貨ペア_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                double 買いSwap, 売りSwap;

                DB_Maintenance.swap.Get手動登録済み最新Swap(FormData.通貨ぺア別取引状況.Find(x => x.Instrument == cmb通貨ペア.Text).通貨ペアNo,
                    out 買いSwap, out 売りSwap);

                txt最新買いSwap.Text = 買いSwap.ToString();
                txt最新売りSwap.Text = 売りSwap.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn登録_Click(object sender, EventArgs e)
        {
            try
            {
                FormData.OrderData = new OrderData();
                FormData.OrderData.now = DateTime.Now;

                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = FormData.DBConnectionString;
                    cn.Open();

                    cmn.SqlCommandInitialize(cn);
                    cmn.GetThisDay1(FormData.OrderData);

                    swap.SqlCommandInitialize(cn);
                    swap.InsertSwap手動登録_Day1(
                        FormData.通貨ぺア別取引状況.Find(x => x.Instrument == cmb通貨ペア.Text).通貨ペアNo,
                        FormData.OrderData.StartDay1,
                        double.Parse(txt買いSwap.Text),
                        double.Parse(txt売りSwap.Text));
                }

                MessageBox.Show("登録完了");
                txt買いSwap.Text = "";
                txt売りSwap.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn登録_表_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    //for (int i = 0; i < dgvSwap.RowCount; i++)
                    //{
                    //	string 通貨ペア名 = (string)dgvSwap.Rows[i].Cells[0].Value;
                    //	byte 通貨ペアNo = FormData.通貨ぺア別取引状況.Find(x => x.Instrument == 通貨ペア名).通貨ペアNo;

                    //	swap.InsertSwap手動登録_Day1(cn,
                    //		通貨ペアNo,
                    //		FormData.OrderData.StartDay1,
                    //		(double)dgvSwap.Rows[i].Cells[1].Value,
                    //		(double)dgvSwap.Rows[i].Cells[2].Value);
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn手動登録したSwapを他DBへも反映する_Click(object sender, EventArgs e)
        {
            try
            {
                swap.Insert手動登録したSwapを他DBへも反映する();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn表示_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = FormData.DBConnectionString;
                    cn.Open();

                    dgv最新Swap一覧.DataSource = DB_Maintenance.swap.Select最新Swap一覧();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        #endregion
    }
}
