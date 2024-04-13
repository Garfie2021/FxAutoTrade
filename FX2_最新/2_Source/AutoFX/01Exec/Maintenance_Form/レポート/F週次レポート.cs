using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using 共通Data;
using Common;
using DB_Maintenance;


namespace Maintenance_Form
{
    public class 週ComboData
    {
        public string 表示;
        public DateTime 開始日時;
        public DateTime 終了日時;
    }


    public partial class F週次レポート : Form
    {
        private SqlConnection Cn;

        public F週次レポート(SqlConnection cn)
        {
            InitializeComponent();

            Cn = cn;
        }


        private static string レポート作成(週ComboData 週item)
        {
            string result = "";

            //DateTime 開始日時 = DateTime.Parse(日付.ToShortDateString() + " 06:00:00");
            //DateTime 終了日時 = DateTime.Parse(日付.AddDays(6).ToShortDateString() + " 06:00:00");

            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = FormData.DBConnectionString;
                cn.Open();

                result += "\r\n【期間】\r\n";
                result += 週item.開始日時.ToString("yyyy/MM/dd hh:mm:ss") + " - " + 週item.終了日時.ToString("yyyy/MM/dd hh:mm:ss") + "\r\n";

                result += "\r\n【oanda Transaction 】\r\n";
                result += DataTable共通.DataTable_ToText(oanda.spSelectTransaction_interestマイナス(cn, FormData.口座No, 週item.開始日時, 週item.終了日時));
            }

            return result;
        }


        private void F週次レポート_Load(object sender, EventArgs e)
        {
            // 年ComboBox初期化

            DateTime now = DateTime.Now;
            DateTime end = DateTime.Parse("2014/1/1 00:00:00");

            while (now > end)
            {
                cmb年.Items.Add(now.ToString("yyyy"));
                now = now.AddYears(-1);
            }


            // 週ComboBox初期化

            now = DateTime.Now;

            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
                now = now.AddDays(-6);
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
                now = now.AddDays(-5);
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
                now = now.AddDays(-4);
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Thursday)
                now = now.AddDays(-3);
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday)
                now = now.AddDays(-2);
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday)
                now = now.AddDays(-1);

            while (now > end)
            {
                var 週item = new 週ComboData()
                {
                    表示 = now.ToString("yyyy/MM/dd 6:00:00") + "(" + now.DayOfWeek.ToString() + ") - " +
                        now.AddDays(5).ToString("yyyy/MM/dd 6:00:00") + "(" + now.AddDays(5).DayOfWeek.ToString() + ")",
                    開始日時 = now,
                    終了日時 = now.AddDays(5)
                };

                cmb週.Items.Add(週item);
                now = now.AddDays(-7);
            }
        }

        private void btnレポート表示_Click(object sender, EventArgs e)
        {
            // TransactionにInterestのマイナスが記録されたかどうかも

            // 日次レポートの最後にジョブ実行回数を

            txtResult.Text = レポート作成((週ComboData)cmb週.SelectedItem);

            MessageBox.Show("完了");

        }

    }
}
