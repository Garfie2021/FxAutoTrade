using System.Windows.Forms;

namespace Maintenance_Form
{
    public partial class Utxt環境情報 : UserControl
    {
        public Utxt環境情報()
        {
            InitializeComponent();
        }

        public string ConnectionString
        {
            set { txtDB接続先.Text = value; }
        }

        public string 口座
        {
            set { txt口座.Text = value; }
        }

        public string コマンドライン
        {
            set { txtコマンドライン.Text = value; }
        }

        //private void UtxtDB接続先_Load(object sender, EventArgs e)
        //{
        //    txtDB接続先.Text = FormData.DBConnectionString;
        //}
    }
}
