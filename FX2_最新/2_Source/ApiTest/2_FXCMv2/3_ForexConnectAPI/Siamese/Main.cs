using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DB;
using FXCM;
using Common;

namespace Siamese
{
    public partial class Main : Form
    {
		#region publicメソッド

		private string FXConnectionString;

		#endregion

		
		#region publicメソッド

		public Main()
        {
            InitializeComponent();
        }

        #endregion


        #region privateメソッド
		
		private void ログアウト()
        {
            Trade.Logout();

            txtログイン表示.Text = "";
        }

        private void Exception共通(bool Timerを停止, Exception ex, string txtログフォルダ)
        {
            if (Timerを停止 == true)
            {
                全Timerを停止();
            }

            ToolStripStsLbl.Text = "Exceptionエラーが発生しました。 " + ex.Message;
            ToolStripStsLbl.BackColor = Color.Red;

            string ログファイル名 = DateTime.Now.ToString("yyyyMMdd") + ".log";

            File.AppendAllText(txtログフォルダ + @"\" + ログファイル名, "\r\n\r\n");
            File.AppendAllText(txtログフォルダ + @"\" + ログファイル名, DateTime.Now.ToString() + "\r\n", Encoding.GetEncoding("Shift_JIS"));
            File.AppendAllText(txtログフォルダ + @"\" + ログファイル名, ex.Data + "\r\n", Encoding.GetEncoding("Shift_JIS"));
            File.AppendAllText(txtログフォルダ + @"\" + ログファイル名, ex.HelpLink + "\r\n", Encoding.GetEncoding("Shift_JIS"));
            File.AppendAllText(txtログフォルダ + @"\" + ログファイル名, ex.InnerException + "\r\n", Encoding.GetEncoding("Shift_JIS"));
            File.AppendAllText(txtログフォルダ + @"\" + ログファイル名, ex.Message + "\r\n", Encoding.GetEncoding("Shift_JIS"));
            File.AppendAllText(txtログフォルダ + @"\" + ログファイル名, ex.Source + "\r\n", Encoding.GetEncoding("Shift_JIS"));
            File.AppendAllText(txtログフォルダ + @"\" + ログファイル名, ex.StackTrace + "\r\n", Encoding.GetEncoding("Shift_JIS"));
            File.AppendAllText(txtログフォルダ + @"\" + ログファイル名, ex.TargetSite + "\r\n", Encoding.GetEncoding("Shift_JIS"));

        }

        private void 全Timerを停止()
        {
            timer_Order.Enabled = false;
            timer_日時曜日更新.Enabled = false;

            txt取引モード表示.Text = "";
        }

        private void システム日時更新()
        {
            txtシステム設定_年.Text = DateTime.Now.Year.ToString();
            txtシステム設定_月.Text = DateTime.Now.Month.ToString();
            txtシステム設定_日.Text = DateTime.Now.Day.ToString();
            txtシステム設定_時.Text = DateTime.Now.Hour.ToString();
            txtシステム設定_分.Text = DateTime.Now.Minute.ToString();
            txtシステム設定_秒.Text = DateTime.Now.Second.ToString();
            txtシステム設定_曜日.Text = DateTime.Now.DayOfWeek.ToString();

			txtシステム設定_Trade時間内.Text = Common.Validate.GetTrade時間内();
        }

		private static double OrderV1_余剰金の割合;
		private void アカウント状態を表示()
        {
			double 取引証拠金, 有効証拠金, 維持証拠金, ロスカット余剰金;
			Trade.Getアカウント状態(out 取引証拠金, out 有効証拠金, out 維持証拠金, out ロスカット余剰金);

			txt取引証拠金_現在.Text = 取引証拠金.ToString("F0");      //取引証拠金
			txt有効証拠金.Text = 有効証拠金.ToString("F0");	        //有効証拠金
			txt維持証拠金.Text = 維持証拠金.ToString("F0");	        //維持証拠金
			txtロスカット余剰金.Text = ロスカット余剰金.ToString("F0");	//ロスカット余剰金

			//OrderV1_余剰金の割合 = (int.Parse(txt出金可能額で調整したロスカット余剰金.Text) / Trade.mAccount.getRow(0).Balance) * 100;
			//txt余剰金の割合.Text = OrderV1_余剰金の割合.ToString("F0");
		}

        private void 自動取引開始()
        {
            if (txt取引モード表示.Text == "")
            {
                timer_Order.Enabled = true;
                txt取引モード表示.Text = "自動取引中";
            }
            else
            {
                timer_Order.Enabled = false;
                txt取引モード表示.Text = "";
            }
        }

        private void ログイン()
        {
            Trade.ログイン(txtConnection.Text, txtUsername.Text, txtPassword.Text);

            txtログイン表示.Text = "ログイン中";
        }

        private void ログイン_Order開始()
        {
            ログイン();

            アカウント状態を表示();

            自動取引開始();
        }



		public static bool E_Chk直前でRate相反している(SqlConnection cn, byte 通貨ペアNo, ref DataGridView dgv注文設定)
		{
			if (rate.Chk直前でRate相反している(cn, 通貨ペアNo, (string)dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.売買判定].Value) == 0)
			{
				dgv注文設定.Rows[通貨ペアNo].Cells[DGVClmNo注文.取引状況].Value = "Order対象外(直前でRate相反)";
				return false;
			}

			return true;
		}

		private void DemoA_FX()
		{
			txtConnection.Text = "Demo";
			txtUsername.Text = "1111";
			txtPassword.Text = "1111";

			txtログフォルダ.Text = @"C:\AutoFX\DemoA_FX\log";

			txt基準注文単位.Text = "5";

			chkn日以上前のポジション決済をスキップ.Checked = true;

			FXConnectionString = ConnectionString.DemoA_FX();
		}

		private void DemoB_FX()
		{
			txtConnection.Text = "Demo";
			txtUsername.Text = "1111";
			txtPassword.Text = "1111";

			txtログフォルダ.Text = @"C:\AutoFX\DemoB_FX\log";

			txt基準注文単位.Text = "5";

			chkn日以上前のポジション決済をスキップ.Checked = true;

			FXConnectionString = ConnectionString.DemoB_FX();
		}


		#endregion


		#region イベントハンドラ Form

		private void FMain_Load(object sender, EventArgs e)
        {
            try
            {
                if (Environment.GetCommandLineArgs().Length > 1)
                {
                    toolStripStatusLabel1.Text = Environment.GetCommandLineArgs()[1];
                }

				if (toolStripStatusLabel1.Text.IndexOf("DemoA_FX") > -1)
				{
					DemoA_FX();
				}
				else if (toolStripStatusLabel1.Text.IndexOf("DemoB_FX") > -1)
				{
					DemoB_FX();
				}

			}
			catch (Exception ex)
			{
				Exception共通(true, ex, txtログフォルダ.Text);
			}
        }

        private void btn損失開始_Click(object sender, EventArgs e)
        {
            FXCM_Test.Login();
        }

        #endregion


		#region イベントハンドラ timer

		// 1秒置おきに、日時、曜日、取引時間内外かを更新
		private void timer_日時曜日更新_1sec_Tick(object sender, EventArgs e)
        {
            try
            {
                システム日時更新();

                if (txtAuto.Text != "Auto")
                    return;

                if (txtシステム設定_Trade時間内.Text == "時間外")
                {
                    if (txtログイン表示.Text == "ログイン中")
                    {
                        ログアウト();
                    }
                }
                else if (txtシステム設定_Trade時間内.Text == "時間内")
                {
                    if (txtログイン表示.Text == "")
                    {
                        ログイン_Order開始();
                    }
                }
            }
            catch (Exception ex)
            {
                Exception共通(true, ex, txtログフォルダ.Text);
            }
		}

		// 10分おきに、ポジションクローズして新しい注文を出す
		private void timer_10min_Tick(object sender, EventArgs e)
		{
			try
			{
				if (txtAuto.Text != "Auto")
					return;

				if (txtシステム設定_Trade時間内.Text != "時間内")
					return;

				using (SqlConnection cn = new SqlConnection())
				{
					cn.ConnectionString = FXConnectionString;
					cn.Open();

					Order.OrderV1(cn, dgv注文, chkRate記録以降の処理をスキップ, chkポジション更新_成行_をスキップ, txtOrder状況);

					Trade.DB記録_Trades(cn);
				}
			}
			catch (Exception ex)
			{
				ToolStripStsLbl.Text = "Exceptionエラーが発生しました。 " + ex.Message;

				if (ToolStripStsLbl.Text.IndexOf("ORA-") > -1)
				{
					ToolStripStsLbl.BackColor = Color.Orange;
				}
				else
				{
					ToolStripStsLbl.BackColor = Color.Red;
				}

				Exception共通(false, ex, txtログフォルダ.Text);
			}

		}

		#endregion

	}
}
