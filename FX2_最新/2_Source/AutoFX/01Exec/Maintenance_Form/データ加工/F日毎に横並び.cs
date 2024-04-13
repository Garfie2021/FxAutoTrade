using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;
using 共通Data;
using Common;
using DB_Maintenance;

namespace Maintenance_Form.Fデータ加工
{
    public partial class F日毎に横並び : Form
    {
        private SqlConnection Cn;
        private int 口座;
        private string コマンドライン;

        public F日毎に横並び(SqlConnection cn, int 口座, string コマンドライン)
        {
            InitializeComponent();

            Cn = cn;
            this.口座 = 口座;
            this.コマンドライン = コマンドライン;
        }

        private string データ加工(byte hour, DateTime dtFrom)
        {
            var sb = new StringBuilder(1024 * 1024);
            var dt = hstr.SelectHour1_Hour(Cn, 34, hour, dtFrom);

            sb.Append(hour + "\t");

            foreach (DataRow row in dt.Rows)
            {
                sb.Append(row["買いRate_始値"] + "\t");
            }

            return sb.ToString();
        }

        #region イベントハンドラ

        private void F日毎に横並び_Load(object sender, EventArgs e)
        {
            txtDB接続先.Text = Cn.ConnectionString;
            txt口座.Text = this.口座.ToString();
            txtコマンドライン.Text = this.コマンドライン;
        }

        private void btn表示_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = hstr.SelectHour1_Min(Cn, 34);
                var startDate = (DateTime)dt.Rows[0]["StartDate"];

                while (startDate.Hour != 5)
                {
                    startDate = startDate.AddHours(1);
                }

                var sb = new StringBuilder(1024 * 1024 * 10);

                for (byte i = 6 ; i < 24 ; i++)
                {
                    sb.AppendLine(データ加工(i, startDate));
                }

                for (byte i = 0; i < 7; i++)
                {
                    sb.AppendLine(データ加工(i, startDate.AddHours(18)));
                }

                F結果 F結果 = new F結果(sb.ToString());
                F結果.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        #endregion
    }
}
