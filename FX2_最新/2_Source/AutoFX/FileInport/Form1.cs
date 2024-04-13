using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Xml;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace FileInport
{
	public partial class Form1 : Form
	{

		#region 公開 共通メソッド

		public Form1()
		{
			InitializeComponent();
		}

		#endregion

		#region 非公開 共通メソッド

		private string Get通貨ペア名(string filepath)
		{
			string 通貨ペア = "";
			通貨ペア = filepath.Replace(txtDB取込み対象フォルダ.Text, "");
			通貨ペア = 通貨ペア.Replace("\\", "");
			通貨ペア = 通貨ペア.Replace(".tsv", "");
			通貨ペア = 通貨ペア.Replace("_", "/");

			return 通貨ペア;
		}

		private string Get通貨ペア名_Indicator(string filepath)
		{
			string 通貨ペア = "";
			通貨ペア = filepath.Replace(txtDB取込み対象フォルダ.Text, "");
			通貨ペア = 通貨ペア.Split('\\')[2];
			通貨ペア = 通貨ペア.Replace(".tsv", "");
			通貨ペア = 通貨ペア.Replace("_", "/");

			return 通貨ペア;
		}

		private void SelectedIndexChanged()
		{
			if (cmbデータ区分.Text == "Rate")
			{
				if (cmb時間区分.Text == "Monthly")
				{
					txtFXCMフォルダ.Text = @"C:\work\11_FX\3_Data\1_Rate\1_Monthly\1_Excel形式";
					txtTSVファイル保存フォルダ.Text = @"C:\work\11_FX\3_Data\1_Rate\1_Monthly\2_TSV形式";
					txtDB取込み対象フォルダ.Text = @"C:\work\11_FX\3_Data\1_Rate\1_Monthly\2_TSV形式";
					txt実行ストアド.Text = "fxcm.SP_InsertRateHistory_Monthly_fromFXCM";
				}
				else if (cmb時間区分.Text == "Weekly")
				{
					txtFXCMフォルダ.Text = @"C:\work\11_FX\3_Data\2_Weekly\1_Excel形式";
					txtTSVファイル保存フォルダ.Text = @"C:\work\11_FX\3_Data\2_Weekly\2_TSV形式";
					txtDB取込み対象フォルダ.Text = @"C:\work\11_FX\3_Data\2_Weekly\2_TSV形式";
				}
				else if (cmb時間区分.Text == "Daily")
				{
					txtFXCMフォルダ.Text = @"C:\work\11_FX\3_Data\1_Rate\3_Daily\1_Excel形式";
					txtTSVファイル保存フォルダ.Text = @"C:\work\11_FX\3_Data\1_Rate\3_Daily\2_TSV形式";
					txtDB取込み対象フォルダ.Text = @"C:\work\11_FX\3_Data\1_Rate\3_Daily\2_TSV形式";
					txt実行ストアド.Text = "fxcm.SP_InsertRateHistory_Daily_fromFXCM";
				}
				else if (cmb時間区分.Text == "Hourly")
				{
					txtFXCMフォルダ.Text = @"C:\work\11_FX\3_Data\1_Rate\4_Hourly\1_Excel形式";
					txtTSVファイル保存フォルダ.Text = @"C:\work\11_FX\3_Data\1_Rate\4_Hourly\2_TSV形式";
					txtDB取込み対象フォルダ.Text = @"C:\work\11_FX\3_Data\1_Rate\4_Hourly\2_TSV形式";
					txt実行ストアド.Text = "fxcm.SP_InsertRateHistory_Hourly_fromFXCM";
				}
				else if (cmb時間区分.Text == "30minutes")
				{
				}
				else if (cmb時間区分.Text == "15minutes")
				{
					txtFXCMフォルダ.Text = @"C:\work\11_FX\3_Data\1_Rate\6_15minutes\1_Excel形式";
					txtTSVファイル保存フォルダ.Text = @"C:\work\11_FX\3_Data\1_Rate\6_15minutes\2_TSV形式";
					txtDB取込み対象フォルダ.Text = @"C:\work\11_FX\3_Data\1_Rate\6_15minutes\2_TSV形式";
					txt実行ストアド.Text = "fxcm.SP_InsertRateHistory_15m_fromFXCM";
				}
				else if (cmb時間区分.Text == "5minutes")
				{
				}
				else if (cmb時間区分.Text == "1minutes")
				{
					txtFXCMフォルダ.Text = @"C:\work\11_FX\3_Data\1_Rate\8_1minutes\1_Excel形式";
					txtTSVファイル保存フォルダ.Text = @"C:\work\11_FX\3_Data\1_Rate\8_1minutes\2_TSV形式";
					txtDB取込み対象フォルダ.Text = @"C:\work\11_FX\3_Data\1_Rate\8_1minutes\2_TSV形式";
				}

				txtColCnt.Text = "9";
			}
			else if (cmbデータ区分.Text == "Indicator")
			{
				if (cmb時間区分.Text == "Monthly")
				{
					if (cmbIndicator.Text == "WMA")
					{
						txtFXCMフォルダ.Text = @"C:\work\11_FX\3_Data\5_Indicator\1_Monthly\1_Excel形式\WMA";
						txtTSVファイル保存フォルダ.Text = @"C:\work\11_FX\3_Data\5_Indicator\1_Monthly\2_TSV形式\WMA";
						txtDB取込み対象フォルダ.Text = @"C:\work\11_FX\3_Data\5_Indicator\1_Monthly\2_TSV形式\WMA";
						txtColCnt.Text = "10";
					}
				}
				else if (cmb時間区分.Text == "Weekly")
				{
				}
				else if (cmb時間区分.Text == "Daily")
				{
					if (cmbIndicator.Text == "ASI")
					{
						txtFXCMフォルダ.Text = @"C:\work\11_FX\3_Data\5_Indicator\3_Daily\1_Excel形式\ASI";
						txtTSVファイル保存フォルダ.Text = @"C:\work\11_FX\3_Data\5_Indicator\3_Daily\2_TSV形式\ASI";
						txtDB取込み対象フォルダ.Text = @"C:\work\11_FX\3_Data\5_Indicator\3_Daily\2_TSV形式\ASI";
						txtColCnt.Text = "10";
					}
				}
				else if (cmb時間区分.Text == "Hourly")
				{
					txtFXCMフォルダ.Text = @"C:\work\11_FX\3_Data\5_Indicator\4_Hourly\1_Excel形式";
					txtTSVファイル保存フォルダ.Text = @"C:\work\11_FX\3_Data\5_Indicator\4_Hourly\2_TSV形式";
					txtDB取込み対象フォルダ.Text = @"C:\work\11_FX\3_Data\5_Indicator\4_Hourly\2_TSV形式";
				}
				else if (cmb時間区分.Text == "30minutes")
				{
					txtFXCMフォルダ.Text = @"C:\work\11_FX\3_Data\5_Indicator\5_30minutes\1_Excel形式";
					txtTSVファイル保存フォルダ.Text = @"C:\work\11_FX\3_Data\5_Indicator\5_30minutes\2_TSV形式";
					txtDB取込み対象フォルダ.Text = @"C:\work\11_FX\3_Data\5_Indicator\5_30minutes\2_TSV形式";
				}
				else if (cmb時間区分.Text == "15minutes")
				{
					if (cmbIndicator.Text == "ADX")
					{
						txtFXCMフォルダ.Text = @"C:\work\11_FX\3_Data\5_Indicator\6_15minutes\1_Excel形式\ADX";
						txtTSVファイル保存フォルダ.Text = @"C:\work\11_FX\3_Data\5_Indicator\6_15minutes\2_TSV形式\ADX";
						txtDB取込み対象フォルダ.Text = @"C:\work\11_FX\3_Data\5_Indicator\6_15minutes\2_TSV形式\ADX";
						txtColCnt.Text = "10";
					}
					else if (cmbIndicator.Text == "DMI")
					{
						txtFXCMフォルダ.Text = @"C:\work\11_FX\3_Data\5_Indicator\6_15minutes\1_Excel形式\DMI";
						txtTSVファイル保存フォルダ.Text = @"C:\work\11_FX\3_Data\5_Indicator\6_15minutes\2_TSV形式\DMI";
						txtDB取込み対象フォルダ.Text = @"C:\work\11_FX\3_Data\5_Indicator\6_15minutes\2_TSV形式\DMI";
						txtColCnt.Text = "11";
					}

				}
				else if (cmb時間区分.Text == "5minutes")
				{
				}
				else if (cmb時間区分.Text == "1minutes")
				{
					txtFXCMフォルダ.Text = @"C:\work\11_FX\3_Data\5_Indicator\8_1minutes\1_Excel形式";
					txtTSVファイル保存フォルダ.Text = @"C:\work\11_FX\3_Data\5_Indicator\8_1minutes\2_TSV形式";
					txtDB取込み対象フォルダ.Text = @"C:\work\11_FX\3_Data\5_Indicator\8_1minutes\2_TSV形式";
				}
			}
		}
	
		#endregion

		#region 非公開 共通メソッド

		private void Form1_Load(object sender, EventArgs e)
		{
			cmbDB接続先.Text = "RealA_FX";		// DemoA_FX  RealA_FX	RealB_FX　※画面から変更してもうまくいかないので、必ずここで変更する
			cmbデータ区分.Text = "Rate";		// Rate  Indicator
			cmb時間区分.Text = "Hourly";		// Monthly Weekly Daily Hourly 30minutes 15minutes 5minutes 1minutes
			cmb通貨ペア.Text = "ALL";		// AUD_CAD AUD_NZD EUR_USD EUR_JPY USD_JPY GBP_USD NZD_JPY ALL
			cmbIndicator.Text = "WMA";		// ADX DMI WMA

			//txtFXCMフォルダ.Text = @"C:\work\11_FX\3_Data\1_Monthly\1_Excel形式";
			//txtTSVファイル保存フォルダ.Text = @"C:\work\11_FX\3_Data\1_Monthly\2_TSV形式";
			//txtDB取込み対象フォルダ.Text = @"C:\work\11_FX\3_Data\1_Monthly\2_TSV形式";
		}

		private void btnフォルダ選択_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			fbd.Description = "フォルダを指定してください。";
			//fbd.RootFolder = txtフォルダ.Text;
			fbd.SelectedPath = "1_Monthly";
			fbd.ShowNewFolderButton = false;

			if (fbd.ShowDialog(this) == DialogResult.OK)
			{
				txtFXCMフォルダ.Text = fbd.SelectedPath;
			}
		}

		private void btnTSVコンバート開始_Click(object sender, EventArgs e)
		{
			try
			{
				//string fn = @"C:\work\11_FX\3_Data\1_Monthly\1_Excel形式\AUD_CAD.xml";
				//string result = "";
				byte Col = byte.Parse(txtColCnt.Text);
				byte ColCnt = 0;

				string[] files = Directory.GetFiles(txtFXCMフォルダ.Text, "*", System.IO.SearchOption.AllDirectories);
				string[] Data = new string[files.Length];

				// FXCMデータファイル取り込み
				for (int iCnt = 0; iCnt < files.Length; iCnt++)
				{
					if (File.Exists(files[iCnt]) == false)
						continue;

					if (cmb通貨ペア.Text != "ALL")
					{
						if (files[iCnt].IndexOf(cmb通貨ペア.Text) == -1)
							continue;
					}

					//if (files[iCnt].IndexOf("DMI") > -1)
					//    Col = 11;

					XmlTextReader reader = null;
					reader = new XmlTextReader(files[iCnt]);
					while (reader.Read())
					{
						if (reader.NodeType != XmlNodeType.Element)
							continue;

						if (reader.LocalName != "Data")
							continue;

						Data[iCnt] += reader.ReadString() + "\t";
						ColCnt++;

						if (ColCnt == Col)
						{
							Data[iCnt] += "\r\n";
							ColCnt = 0;
						}
					}
					reader.Close();
				}

				// TSVファイル書き込み
				for (int iCnt = 0; iCnt < files.Length; iCnt++)
				{
					if (cmb通貨ペア.Text != "ALL")
					{
						if (files[iCnt].IndexOf(cmb通貨ペア.Text) == -1)
							continue;
					}

					files[iCnt] = files[iCnt].Replace("1_Excel形式", "2_TSV形式");
					files[iCnt] = files[iCnt].Replace(".xml", ".tsv");

					if (File.Exists(files[iCnt]))
					{
						File.Delete(files[iCnt]);
					}

					File.AppendAllText(files[iCnt], Data[iCnt], Encoding.GetEncoding("Shift_JIS"));
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
			}
		}

		private void btnDBインポート開始_Click(object sender, EventArgs e)
		{
			string[] files = Directory.GetFiles(txtDB取込み対象フォルダ.Text, "*", System.IO.SearchOption.AllDirectories);
			string[] Data = new string[files.Length];
			string 通貨ペア = "";
			byte 通貨ペアNo = 0;

			if (cmbデータ区分.Text == "Rate")
			{
				if (cmb時間区分.Text == "Monthly")
				{
					DateTime 日時;
					CDB.T_Rate_MonthlyTableAdapter.DeleteALL();

					// FXCMデータファイル取り込み
					for (int iCnt = 0; iCnt < files.Length; iCnt++)
					{
						if (File.Exists(files[iCnt]) == false)
							continue;

						if (cmb通貨ペア.Text != "ALL")
						{
							if (files[iCnt].IndexOf(cmb通貨ペア.Text) == -1)
								continue;
						}

						通貨ペア = Get通貨ペア名(files[iCnt]);
						通貨ペアNo = (byte)CDB.T_通貨ペアMstTableAdapter.ScalarNo(通貨ペア);

						StreamReader cReader = (new StreamReader(files[iCnt], Encoding.GetEncoding("Shift_JIS")));

						cReader.ReadLine();
						while (cReader.Peek() >= 0)
						{
							string[] stBuffer = cReader.ReadLine().Split('\t');

							日時 = DateTime.Parse(stBuffer[0].Split('T')[0] + " " + stBuffer[0].Split('T')[1]);
							//T_Rate_1mTableAdapter.Delete通貨ペアNo日時(通貨ペアNo, 日時);

							CDB.T_Rate_MonthlyTableAdapter.Insert(
								通貨ペアNo,
								日時,
								double.Parse(stBuffer[1]),
								double.Parse(stBuffer[2]),
								double.Parse(stBuffer[3]),
								double.Parse(stBuffer[4]),
								double.Parse(stBuffer[5]),
								double.Parse(stBuffer[6]),
								double.Parse(stBuffer[7]),
								double.Parse(stBuffer[8]));
						}

						cReader.Close();
					}
				}
				else if (cmb時間区分.Text == "Weekly")
				{

				}
				else if (cmb時間区分.Text == "Daily")
				{
					DateTime 日時;
					CDB.T_Rate_DailyTableAdapter.DeleteALL();

					// FXCMデータファイル取り込み
					for (int iCnt = 0; iCnt < files.Length; iCnt++)
					{
						if (File.Exists(files[iCnt]) == false)
							continue;

						if (cmb通貨ペア.Text != "ALL")
						{
							if (files[iCnt].IndexOf(cmb通貨ペア.Text) == -1)
								continue;
						}

						通貨ペア = Get通貨ペア名(files[iCnt]);
						通貨ペアNo = (byte)CDB.T_通貨ペアMstTableAdapter.ScalarNo(通貨ペア);

						StreamReader cReader = (new StreamReader(files[iCnt], Encoding.GetEncoding("Shift_JIS")));

						cReader.ReadLine();
						while (cReader.Peek() >= 0)
						{
							string[] stBuffer = cReader.ReadLine().Split('\t');

							日時 = DateTime.Parse(stBuffer[0].Split('T')[0] + " " + stBuffer[0].Split('T')[1]);
							//T_Rate_1mTableAdapter.Delete通貨ペアNo日時(通貨ペアNo, 日時);

							CDB.T_Rate_DailyTableAdapter.Insert(
								通貨ペアNo,
								日時,
								double.Parse(stBuffer[1]),
								double.Parse(stBuffer[2]),
								double.Parse(stBuffer[3]),
								double.Parse(stBuffer[4]),
								double.Parse(stBuffer[5]),
								double.Parse(stBuffer[6]),
								double.Parse(stBuffer[7]),
								double.Parse(stBuffer[8]));
						}

						cReader.Close();
					}
				}
				else if (cmb時間区分.Text == "Hourly")
				{
					DateTime 日時;
					CDB.T_Rate_HourlyTableAdapter.DeleteALL();

					// FXCMデータファイル取り込み
					for (int iCnt = 0; iCnt < files.Length; iCnt++)
					{
						if (File.Exists(files[iCnt]) == false)
							continue;

						if (cmb通貨ペア.Text != "ALL")
						{
							if (files[iCnt].IndexOf(cmb通貨ペア.Text) == -1)
								continue;
						}

						通貨ペア = Get通貨ペア名(files[iCnt]);
						通貨ペアNo = (byte)CDB.T_通貨ペアMstTableAdapter.ScalarNo(通貨ペア);

						StreamReader cReader = (new StreamReader(files[iCnt], Encoding.GetEncoding("Shift_JIS")));

						cReader.ReadLine();
						while (cReader.Peek() >= 0)
						{
							string[] stBuffer = cReader.ReadLine().Split('\t');

							日時 = DateTime.Parse(stBuffer[0].Split('T')[0] + " " + stBuffer[0].Split('T')[1]);
							//T_Rate_1mTableAdapter.Delete通貨ペアNo日時(通貨ペアNo, 日時);

							CDB.T_Rate_HourlyTableAdapter.Insert(
								通貨ペアNo,
								日時,
								double.Parse(stBuffer[1]),
								double.Parse(stBuffer[2]),
								double.Parse(stBuffer[3]),
								double.Parse(stBuffer[4]),
								double.Parse(stBuffer[5]),
								double.Parse(stBuffer[6]),
								double.Parse(stBuffer[7]),
								double.Parse(stBuffer[8]));
						}

						cReader.Close();
					}
				}
				else if (cmb時間区分.Text == "30minutes")
				{
				}
				else if (cmb時間区分.Text == "15minutes")
				{
					DateTime 日時;
					CDB.T_Rate_15mTableAdapter.DeleteALL();

					// FXCMデータファイル取り込み
					for (int iCnt = 0; iCnt < files.Length; iCnt++)
					{
					    if (File.Exists(files[iCnt]) == false)
					        continue;

						if (cmb通貨ペア.Text != "ALL")
						{
							if (files[iCnt].IndexOf(cmb通貨ペア.Text) == -1)
								continue;
						}

						通貨ペア = Get通貨ペア名(files[iCnt]);
						通貨ペアNo = (byte)CDB.T_通貨ペアMstTableAdapter.ScalarNo(通貨ペア);

					    StreamReader cReader = (new StreamReader(files[iCnt], Encoding.GetEncoding("Shift_JIS")));

					    cReader.ReadLine();
					    while (cReader.Peek() >= 0)
					    {
					        string[] stBuffer = cReader.ReadLine().Split('\t');

					        日時 = DateTime.Parse(stBuffer[0].Split('T')[0] + " " + stBuffer[0].Split('T')[1]);
					        //T_Rate_1mTableAdapter.Delete通貨ペアNo日時(通貨ペアNo, 日時);

							CDB.T_Rate_15mTableAdapter.Insert(
					            通貨ペアNo,
					            日時,
					            double.Parse(stBuffer[1]),
					            double.Parse(stBuffer[2]),
					            double.Parse(stBuffer[3]),
					            double.Parse(stBuffer[4]),
					            double.Parse(stBuffer[5]),
					            double.Parse(stBuffer[6]),
					            double.Parse(stBuffer[7]),
					            double.Parse(stBuffer[8]));
					    }

					    cReader.Close();
					}
				}
				else if (cmb時間区分.Text == "5minutes")
				{
				}
				else if (cmb時間区分.Text == "1minutes")
				{
					DateTime 日時;
					CDB.T_Rate_1mTableAdapter.DeleteALL();

					// FXCMデータファイル取り込み
					for (int iCnt = 0; iCnt < files.Length; iCnt++)
					{
						if (File.Exists(files[iCnt]) == false)
							continue;

						if (cmb通貨ペア.Text != "ALL")
						{
							if (files[iCnt].IndexOf(cmb通貨ペア.Text) == -1)
								continue;
						}

						通貨ペア = Get通貨ペア名(files[iCnt]);
						通貨ペアNo = (byte)CDB.T_通貨ペアMstTableAdapter.ScalarNo(通貨ペア);

						StreamReader cReader = (new StreamReader(files[iCnt], Encoding.GetEncoding("Shift_JIS")));

						cReader.ReadLine();
						while (cReader.Peek() >= 0)
						{
							string[] stBuffer = cReader.ReadLine().Split('\t');

							日時 = DateTime.Parse(stBuffer[0].Split('T')[0] + " " + stBuffer[0].Split('T')[1]);
							//T_Rate_1mTableAdapter.Delete通貨ペアNo日時(通貨ペアNo, 日時);

							CDB.T_Rate_1mTableAdapter.Insert(
								通貨ペアNo,
								日時,
								double.Parse(stBuffer[1]),
								double.Parse(stBuffer[2]),
								double.Parse(stBuffer[3]),
								double.Parse(stBuffer[4]),
								double.Parse(stBuffer[5]),
								double.Parse(stBuffer[6]),
								double.Parse(stBuffer[7]),
								double.Parse(stBuffer[8]));
						}

						cReader.Close();
					}
				}
			}
			else if (cmbデータ区分.Text == "Indicator")
			{
				if (cmb時間区分.Text == "Monthly")
				{
				}
				else if (cmb時間区分.Text == "Weekly")
				{
				}
				else if (cmb時間区分.Text == "Daily")
				{
				}
				else if (cmb時間区分.Text == "Hourly")
				{
				}
				else if (cmb時間区分.Text == "30minutes")
				{
				}
				else if (cmb時間区分.Text == "15minutes")
				{
				}
				else if (cmb時間区分.Text == "5minutes")
				{
				}
				else if (cmb時間区分.Text == "1minutes")
				{
					// FXCMデータファイル取り込み
					for (int iCnt = 0; iCnt < files.Length; iCnt++)
					{
						if (File.Exists(files[iCnt]) == false)
							continue;

						if (files[iCnt].IndexOf("DMI") > -1)
						{
							CDB.T_Indicator_1m_DMITableAdapter.DeleteALL();
						}

						通貨ペア = Get通貨ペア名_Indicator(files[iCnt]);
						通貨ペアNo = (byte)CDB.T_通貨ペアMstTableAdapter.ScalarNo(通貨ペア);

						StreamReader cReader = (new StreamReader(files[iCnt], Encoding.GetEncoding("Shift_JIS")));

						cReader.ReadLine();
						while (cReader.Peek() >= 0)
						{
							string[] stBuffer = cReader.ReadLine().Split('\t');

							// 買いにしか対応していない
							CDB.T_Indicator_1m_DMITableAdapter.Insert(
								通貨ペアNo,
								DateTime.Parse(stBuffer[0].Split('T')[0] + " " + stBuffer[0].Split('T')[1]),
								double.Parse(stBuffer[9]),
								double.Parse(stBuffer[10]),
								0, 0);
						}

						cReader.Close();
					}
				}
			}

		}

		private void cmbDB接続先_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmbDB接続先.Text == "DemoA_FX")
			{
				txtDB接続先.Text = "Data Source=1111;Initial Catalog=DemoA_FX;User ID=sa;Password=1111";
			}
			else if (cmbDB接続先.Text == "RealA_FX")
			{
				txtDB接続先.Text = "Data Source=1111;Initial Catalog=RealA_FX;User ID=sa;Password=1111";
			}
			else if (cmbDB接続先.Text == "RealB_FX")
			{
				txtDB接続先.Text = "Data Source=1111;Initial Catalog=RealB_FX;User ID=sa;Password=1111";
			}

			Properties.Settings.Default.FX_RealAConnectionString = txtDB接続先.Text;
			Properties.Settings.Default.Save();

		}

		private void cmb時間区分_SelectedIndexChanged(object sender, EventArgs e)
		{
			SelectedIndexChanged();
		}

		private void cmbデータ区分_SelectedIndexChanged(object sender, EventArgs e)
		{
			SelectedIndexChanged();
		}

		private void cmb通貨ペア_SelectedIndexChanged(object sender, EventArgs e)
		{
			SelectedIndexChanged();
		}

		private void cmbIndicator_SelectedIndexChanged(object sender, EventArgs e)
		{
			SelectedIndexChanged();
		}

		private void btn実行ストアド_Click(object sender, EventArgs e)
		{
			CDB.ExecSP(txt実行ストアド.Text);
		}


		#endregion








	}
}
