using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using 定数;
using 共通Data;
using DB;
using OANDAv1;


namespace Maintenance_Form
{
    public partial class FMstデータ再登録 : Form
    {
        private SqlConnection Cn;

        public FMstデータ再登録(SqlConnection cn)
        {
            InitializeComponent();

            Cn = cn;
        }

        private void FMstデータ再登録_Load(object sender, EventArgs e)
        {

        }

        private void btn通貨ペア再登録_Click(object sender, EventArgs e)
        {
            try
            {
                DB_Maintenance.cmn.DeleteALL通貨ペア(Cn);

                foreach (var 通貨ぺア取引状況 in FormData.通貨ぺア別取引状況)
                {
                    DB_Maintenance.cmn.Insert通貨ペア(Cn, 通貨ぺア取引状況);
                }

                MessageBox.Show("登録完了");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn通貨ペア一覧表示_Click(object sender, EventArgs e)
        {
            try
            {
                cmn.Select口座();

                List<OandaInstrument> OandaInstruments = Rest.GetInstrumentsAsync(FormData.OandaAccountId);

                string result = "";
                foreach (var oandaInstrument in OandaInstruments)
                {
                    result += oandaInstrument.instrument + "\r\n";
                }

                F結果 F結果 = new F結果(result);
                F結果.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

    }
}
