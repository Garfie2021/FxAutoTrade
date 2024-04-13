using System;
using System.Windows.Forms;

namespace Maintenance_Form
{
    public partial class F結果 : Form
    {
        private string 結果;

        public F結果(string result)
        {
            InitializeComponent();

            結果 = result;
        }

        private void F結果_Load(object sender, EventArgs e)
        {
            txt結果.Text = 結果;
        }
    }
}
