using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maintenance_Form
{
    public partial class FOANDAが扱っている通貨ペア一覧 : Form
    {
        public FOANDAが扱っている通貨ペア一覧()
        {
            InitializeComponent();
        }

        // 行数カウント
        public static int 行数カウント(string s)
        {
            return (s.Length - s.Replace("\n", "").Length) + 1;
        }

        private void OANDAが扱っている通貨ペア一覧_Load(object sender, EventArgs e)
        {
            txt通貨ペア数.Text = 行数カウント(txt通貨ペア一覧.Text).ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //リンク先に移動したことにする
            linkLabel1.LinkVisited = true;
            //ブラウザで開く
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }
    }
}
