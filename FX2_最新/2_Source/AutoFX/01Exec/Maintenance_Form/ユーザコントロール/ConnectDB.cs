using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using 定数;
using DB_Maintenance;


namespace Maintenance_Form
{
    public partial class ConnectDB : UserControl
    {
        public ConnectDB()
        {
            InitializeComponent();
        }

        public string SelectDB()
        {
            return cmbDB.Text;
        }

        private void ConnectDB_Load(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = DB定数.GetConnectionString("FXCM");
                cn.Open();

                mstr.DB一覧取得(cn, ref cmbDB);
            }
        }
    }
}
