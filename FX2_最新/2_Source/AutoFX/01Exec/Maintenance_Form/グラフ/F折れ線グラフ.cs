using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace Maintenance_Form.Fグラフ
{
    public partial class F折れ線グラフ : Form
    {
        private DataGridView Dgv;
        private DataTable dtResult;


        public F折れ線グラフ(DataGridView dgv, DataTable dt)
        {
            InitializeComponent();

            Dgv = dgv;
            dtResult = dt;
        }

        private void F折れ線グラフ_Load(object sender, EventArgs e)
        {
            // 初期化
            chart折れ線グラフ.Series.Clear();

            // Chartコントロールにデータソースを設定
            chart折れ線グラフ.DataSource = dtResult;

            // Chartコントロールにタイトルを設定
            //chart折れ線グラフ.Titles.Add("アクセス数とユニークユーザー数");

            // グラフの種類,系列,軸の設定
            for (int i = 1; i < dtResult.Columns.Count; i++)
            {
                // 列名の取得
                string columnName = dtResult.Columns[i].ColumnName;

                // 系列の設定
                chart折れ線グラフ.Series.Add(columnName);

                // グラフの種類
                chart折れ線グラフ.Series[columnName].ChartType = SeriesChartType.Column;

                // X軸
                chart折れ線グラフ.Series[columnName].XValueMember = dtResult.Columns[0].ColumnName.ToString();
                chart折れ線グラフ.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                chart折れ線グラフ.ChartAreas[0].AxisX.MinorGrid.Enabled = false;

                // Y軸
                chart折れ線グラフ.Series[columnName].YValueMembers = columnName;

                chart折れ線グラフ.Series[columnName].ChartType = SeriesChartType.Line;

            }

            // X軸タイトル
            chart折れ線グラフ.ChartAreas[0].AxisX.Title = "日時";

            chart折れ線グラフ.DataBind();


            //chart折れ線グラフ.DataSource = dtResult;

            ////chart折れ線グラフ.Series[0].Points.AddXY(
            ////    Convert.ToDateTime(dtResult.Columns[0]));

            //chart折れ線グラフ.DataBind();
        }
    }
}
