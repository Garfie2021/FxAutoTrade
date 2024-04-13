using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maintenance_Form.F手動データ登録
{
    public partial class F環境設定 : Form
    {
        private SqlConnection Cn;


        public F環境設定(SqlConnection cn)
        {
            InitializeComponent();

            Cn = cn;
        }

        private void F環境設定_Load(object sender, EventArgs e)
        {
            //dgv環境設定一覧.
        }

        private void btn更新_Click(object sender, EventArgs e)
        {

        }

    }
}
