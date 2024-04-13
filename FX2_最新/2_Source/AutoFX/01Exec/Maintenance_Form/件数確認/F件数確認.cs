using System;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using 定数;
using 共通Data;
using DB_Maintenance;


namespace Maintenance_Form
{
    public partial class F件数確認 : Form
    {
        private SqlConnection Cn;
        private int 口座;
        private string コマンドライン;


        public F件数確認(SqlConnection cn, int 口座, string コマンドライン)
        {
            InitializeComponent();

            this.dgvテーブル別.RowPostPaint += new DataGridViewRowPostPaintEventHandler((new イベントハンドラ()).dgv_RowPostPaint);
            this.dgv通貨ペア別Month1.RowPostPaint += new DataGridViewRowPostPaintEventHandler((new イベントハンドラ()).dgv_RowPostPaint);
            this.dgv通貨ペア別Week1.RowPostPaint += new DataGridViewRowPostPaintEventHandler((new イベントハンドラ()).dgv_RowPostPaint);
            this.dgv通貨ペア別Day1.RowPostPaint += new DataGridViewRowPostPaintEventHandler((new イベントハンドラ()).dgv_RowPostPaint);
            this.dgv通貨ペア別Hour1.RowPostPaint += new DataGridViewRowPostPaintEventHandler((new イベントハンドラ()).dgv_RowPostPaint);
            this.dgv通貨ペア別Min15.RowPostPaint += new DataGridViewRowPostPaintEventHandler((new イベントハンドラ()).dgv_RowPostPaint);
            this.dgv通貨ペア別Min5.RowPostPaint += new DataGridViewRowPostPaintEventHandler((new イベントハンドラ()).dgv_RowPostPaint);
            this.dgv通貨ペア別Min1.RowPostPaint += new DataGridViewRowPostPaintEventHandler((new イベントハンドラ()).dgv_RowPostPaint);
            this.dgv通貨ペア別Sec.RowPostPaint += new DataGridViewRowPostPaintEventHandler((new イベントハンドラ()).dgv_RowPostPaint);
            this.dgv日付別Month1.RowPostPaint += new DataGridViewRowPostPaintEventHandler((new イベントハンドラ()).dgv_RowPostPaint);
            this.dgv日付別Week1.RowPostPaint += new DataGridViewRowPostPaintEventHandler((new イベントハンドラ()).dgv_RowPostPaint);
            this.dgv日付別Day1.RowPostPaint += new DataGridViewRowPostPaintEventHandler((new イベントハンドラ()).dgv_RowPostPaint);
            this.dgv日付別Hour1.RowPostPaint += new DataGridViewRowPostPaintEventHandler((new イベントハンドラ()).dgv_RowPostPaint);
            this.dgv日付別Min15.RowPostPaint += new DataGridViewRowPostPaintEventHandler((new イベントハンドラ()).dgv_RowPostPaint);
            this.dgv日付別Min5.RowPostPaint += new DataGridViewRowPostPaintEventHandler((new イベントハンドラ()).dgv_RowPostPaint);
            this.dgv日付別Min1.RowPostPaint += new DataGridViewRowPostPaintEventHandler((new イベントハンドラ()).dgv_RowPostPaint);
            this.dgv日付別Sec.RowPostPaint += new DataGridViewRowPostPaintEventHandler((new イベントハンドラ()).dgv_RowPostPaint);

            Cn = cn;
            this.口座 = 口座;
            this.コマンドライン = コマンドライン;
        }


        #region イベントハンドラ

        private void F件数確認_Load(object sender, EventArgs e)
        {
            txtDB接続先.Text = Cn.ConnectionString;
            txt口座.Text = this.口座.ToString();
            txtコマンドライン.Text = this.コマンドライン;

            //using (SqlConnection cn = new SqlConnection())
            //{
            //	cn.ConnectionString = FormData.DBConnectionString;
            //	cn.Open();

            //	cnt.テーブル別(cn, ref dgvテーブル別);
            //	cnt.テーブル別通貨ペア別(cn, ref dgvテーブル別通貨ペア別);

            //	//string str通貨ペアNo = cmb通貨ペア.Text;
            //	//cnt.日付別通貨ペア別(cn, "hstr.Month1", str通貨ペアNo, ref dgvMonth1_通貨ペア別);
            //	//cnt.日付別通貨ペア別(cn, "hstr.Week1", str通貨ペアNo, ref dgvWeek1_通貨ペア別);
            //	//cnt.日付別通貨ペア別(cn, "hstr.Day1", str通貨ペアNo, ref dgvDay1_通貨ペア別);
            //	//cnt.日付別通貨ペア別(cn, "hstr.Hour1", str通貨ペアNo, ref dgvHour1_通貨ペア別);
            //	//cnt.日付別通貨ペア別(cn, "hstr.Min15", str通貨ペアNo, ref dgvMin15_通貨ペア別);
            //	//cnt.日付別通貨ペア別(cn, "hstr.Min5", str通貨ペアNo, ref dgvMin5_通貨ペア別);
            //	//cnt.日付別通貨ペア別(cn, "hstr.Min1", str通貨ペアNo, ref dgvMin1_通貨ペア別);
            //	//cnt.日付別通貨ペア別(cn, "hstr.Sec", str通貨ペアNo, ref dgvSec_通貨ペア別);
            //}
        }


        #region TAB（テーブル別）

        private void btn再表示_テーブル別_Click(object sender, EventArgs e)
        {
            try
            {
                cnt.テーブル別(Cn, ref dgvテーブル別);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        #endregion


        #region TAB（通貨ペア別）

        private void btn再表示_Month1通貨ペア別_Click(object sender, EventArgs e)
        {
            try
            {
                cnt.通貨ペア別Month1(Cn, ref dgv通貨ペア別Month1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn再表示_Week1通貨ペア別_Click(object sender, EventArgs e)
        {
            try
            {
                cnt.通貨ペア別Week1(Cn, ref dgv通貨ペア別Week1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn再表示_Day1通貨ペア別_Click(object sender, EventArgs e)
        {
            try
            {
                cnt.通貨ペア別Day1(Cn, ref dgv通貨ペア別Day1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn再表示_Hour1通貨ペア別_Click(object sender, EventArgs e)
        {
            try
            {
                cnt.通貨ペア別Hour1(Cn, ref dgv通貨ペア別Hour1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn再表示_Min15通貨ペア別_Click(object sender, EventArgs e)
        {
            try
            {
                cnt.通貨ペア別Min15(Cn, ref dgv通貨ペア別Min15);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn再表示_Min5通貨ペア別_Click(object sender, EventArgs e)
        {
            try
            {
                cnt.通貨ペア別Min5(Cn, ref dgv通貨ペア別Min5);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn再表示_Min1通貨ペア別_Click(object sender, EventArgs e)
        {
            try
            {
                cnt.通貨ペア別Min1(Cn, ref dgv通貨ペア別Min1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn再表示_Sec通貨ペア別_Click(object sender, EventArgs e)
        {
            try
            {
                cnt.通貨ペア別Sec(Cn, ref dgv通貨ペア別Sec);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        #endregion


        #region TAB（日付別）

        private void btn再表示_Month1日付別_Click(object sender, EventArgs e)
        {
            try
            {
                txt想定件数_Month1日付別.Text = FormData.通貨ぺア別取引状況.Count().ToString();

                cnt.日付別Month1(Cn, ref dgv日付別Month1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn再表示_Week1日付別_Click(object sender, EventArgs e)
        {
            try
            {
                txt想定件数_Week1日付別.Text = FormData.通貨ぺア別取引状況.Count().ToString();

                cnt.日付別Week1(Cn, ref dgv日付別Week1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn再表示_Day1日付別_Click(object sender, EventArgs e)
        {
            try
            {
                txt想定件数_Day1日付別.Text = FormData.通貨ぺア別取引状況.Count().ToString();

                cnt.日付別Day1(Cn, ref dgv日付別Day1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn再表示_Hour1日付別_Click(object sender, EventArgs e)
        {
            try
            {
                txt想定件数_Hour1日付別.Text = FormData.通貨ぺア別取引状況.Count().ToString();

                cnt.日付別Hour1(Cn, ref dgv日付別Hour1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn再表示_Min15日付別_Click(object sender, EventArgs e)
        {
            try
            {
                txt想定件数_Min15日付別.Text = FormData.通貨ぺア別取引状況.Count().ToString();

                cnt.日付別Min15(Cn, ref dgv日付別Min15);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn再表示_Min5日付別_Click(object sender, EventArgs e)
        {
            try
            {
                txt想定件数_Min5日付別.Text = FormData.通貨ぺア別取引状況.Count().ToString();

                cnt.日付別Min5(Cn, ref dgv日付別Min5);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn再表示_Min1日付別_Click(object sender, EventArgs e)
        {
            try
            {
                txt想定件数_Min1日付別.Text = FormData.通貨ぺア別取引状況.Count().ToString();

                cnt.日付別Min1(Cn, ref dgv日付別Min1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn再表示_Sec日付別_Click(object sender, EventArgs e)
        {
            try
            {
                txt想定件数_Sec日付別.Text = FormData.通貨ぺア別取引状況.Count().ToString();

                cnt.日付別Sec(Cn, ref dgv日付別Sec);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        #endregion

        #endregion

    }
}
