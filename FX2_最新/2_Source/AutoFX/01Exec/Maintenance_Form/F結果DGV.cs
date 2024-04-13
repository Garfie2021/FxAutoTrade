using System;
using System.Windows.Forms;

namespace Maintenance_Form
{
    public partial class F結果DGV : Form
    {
        private string Result;

        public F結果DGV(string result)
        {
            InitializeComponent();

            Result = result;
        }

        private void 行列追加()
        {
            for (int i = 1; i < 100; i++)
            {
                DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
                textColumn.DataPropertyName = "Column" + i;
                textColumn.Name = "Column" + i;
                textColumn.HeaderText = "Column" + i;

                dgv結果.Columns.Add(textColumn);
            }

            for (int i = 1; i < 10000; i++)
            {
                dgv結果.Rows.Add();
            }
        }

        private void F結果DGV_Load(object sender, EventArgs e)
        {
            行列追加();

            int iRow = 0;
            foreach (var row in Result.Split(new string[] { "\r\n" }, StringSplitOptions.None))
            {
                int iCol = 0;
                foreach (var col in row.Split('\t'))
                {
                    dgv結果.Rows[iRow].Cells[iCol].Value = col;
                    iCol++;
                }

                iRow++;
            }
        }
    }
}
