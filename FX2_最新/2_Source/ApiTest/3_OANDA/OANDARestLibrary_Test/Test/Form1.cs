using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OANDARestLibrary;

namespace Test
{
	public partial class Form1 : Form
	{
		private int _accountId { get { return Credentials.GetDefaultCredentials().DefaultAccountId; } }

		public Form1()
		{
			InitializeComponent();
		}

		private void btn通貨ペア取得_Click(object sender, EventArgs e)
		{
			var result = Rest.GetInstrumentsAsync(_accountId);
		}
	}
}
