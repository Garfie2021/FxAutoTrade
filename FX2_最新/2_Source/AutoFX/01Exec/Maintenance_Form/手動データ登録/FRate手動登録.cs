using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using 定数;
using 共通Data;
using DB_Maintenance;
using DB_FXCM;


namespace Maintenance_Form
{
    public partial class FRate手動登録 : Form
    {
        SqlConnection Cn;

        public FRate手動登録(SqlConnection cn)
        {
            InitializeComponent();

            Cn = cn;
        }

        // Retrieve the value of a cell, given a file name, sheet name, 
        // and address name.
        public static string GetCellValue(string fileName, string sheetName, string addressName)
        {
            string value = null;

            // Open the spreadsheet document for read-only access.
            using (SpreadsheetDocument document = SpreadsheetDocument.Open(fileName, false))
            {
                // Retrieve a reference to the workbook part.
                WorkbookPart wbPart = document.WorkbookPart;

                // Find the sheet with the supplied name, and then use that 
                // Sheet object to retrieve a reference to the first worksheet.
                Sheet theSheet = wbPart.Workbook.Descendants<Sheet>().Where(s => s.Name == sheetName).FirstOrDefault();

                // Throw an exception if there is no sheet.
                if (theSheet == null)
                {
                    throw new ArgumentException("sheetName");
                }

                // Retrieve a reference to the worksheet part.
                WorksheetPart wsPart = (WorksheetPart)(wbPart.GetPartById(theSheet.Id));

                // Use its Worksheet property to get a reference to the cell 
                // whose address matches the address you supplied.
                Cell theCell = wsPart.Worksheet.Descendants<Cell>().Where(c => c.CellReference == addressName).FirstOrDefault();

                // If the cell does not exist, return an empty string.
                if (theCell != null)
                {
                    value = theCell.InnerText;

                    // If the cell represents an integer number, you are done. 
                    // For dates, this code returns the serialized value that 
                    // represents the date. The code handles strings and 
                    // Booleans individually. For shared strings, the code 
                    // looks up the corresponding value in the shared string 
                    // table. For Booleans, the code converts the value into 
                    // the words TRUE or FALSE.
                    if (theCell.DataType != null)
                    {
                        switch (theCell.DataType.Value)
                        {
                            case CellValues.SharedString:

                                // For shared strings, look up the value in the
                                // shared strings table.
                                var stringTable =
                                    wbPart.GetPartsOfType<SharedStringTablePart>()
                                    .FirstOrDefault();

                                // If the shared string table is missing, something 
                                // is wrong. Return the index that is in
                                // the cell. Otherwise, look up the correct text in 
                                // the table.
                                if (stringTable != null)
                                {
                                    value =
                                        stringTable.SharedStringTable
                                        .ElementAt(int.Parse(value)).InnerText;
                                }
                                break;

                            case CellValues.Boolean:
                                switch (value)
                                {
                                    case "0":
                                        value = "FALSE";
                                        break;
                                    default:
                                        value = "TRUE";
                                        break;
                                }
                                break;
                        }
                    }
                }
            }
            return value;
        }

        private void FXCMデータベースへインポート(string 単位, string フォルダ)
        {
            foreach (var ファイルPath in Directory.GetFiles(フォルダ))
            {
                var ファイル = new FileInfo(ファイルPath);

                DataTable dt = new DataTable("rate." + 単位);
                dt.Columns.Add(new DataColumn("通貨ペアNo", typeof(byte)));			// 列1
                dt.Columns.Add(new DataColumn("StartDate", typeof(DateTime)));		// 列2
                dt.Columns.Add(new DataColumn("Rate_始値_買い", typeof(double)));	// 列3
                dt.Columns.Add(new DataColumn("Rate_高値_買い", typeof(double)));	// 列4
                dt.Columns.Add(new DataColumn("Rate_安値_買い", typeof(double)));	// 列5
                dt.Columns.Add(new DataColumn("Rate_終値_買い", typeof(double)));	// 列6
                dt.Columns.Add(new DataColumn("Rate_始値_売り", typeof(double)));	// 列7
                dt.Columns.Add(new DataColumn("Rate_高値_売り", typeof(double)));	// 列8
                dt.Columns.Add(new DataColumn("Rate_安値_売り", typeof(double)));	// 列9
                dt.Columns.Add(new DataColumn("Rate_終値_売り", typeof(double)));	// 列10

                byte 通貨ペアNo = FormData.通貨ぺア別取引状況.Find(x => x.Instrument2 == ファイル.Name.Split('.')[0]).通貨ペアNo;

                bool _1行目 = true;
                using (StreamReader sr = new StreamReader(ファイル.FullName, Encoding.GetEncoding("shift_jis")))
                {
                    while (sr.Peek() >= 0)
                    {
                        var str = sr.ReadLine().Split('\t');

                        if (_1行目)
                        {
                            _1行目 = false;
                            continue;
                        }

                        dt.Rows.Add(通貨ペアNo, DateTime.Parse(str[0]), double.Parse(str[1]), double.Parse(str[2]), double.Parse(str[3]), double.Parse(str[4]), double.Parse(str[5]), double.Parse(str[6]), double.Parse(str[7]), double.Parse(str[8]));

                    }
                }

                using (SqlBulkCopy bulkcopy = new SqlBulkCopy(DB定数.GetConnectionString("FXCM")))
                {
                    bulkcopy.BulkCopyTimeout = 600;
                    bulkcopy.DestinationTableName = "rate." + 単位;
                    bulkcopy.WriteToServer(dt);
                }
            }
        }



        #region イベントハンドラ

        private void FRate手動登録_Load(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = DB定数.GetConnectionString("FXCM");
                cn.Open();

                mstr.テーブル一覧取得(cn, ref cmb対象テーブル);
            }
        }

        private void btnRateダウンロード対象通貨ペア確認_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = DB定数.GetConnectionString(connectDBダウンロード対象通貨ペア.SelectDB());
                    cn.Open();

                    DataTable data = oanda.Rateダウンロード対象通貨ペア確認(cn);

                    string str = "通貨ペアNo\t通貨ペア名";
                    foreach (DataRow row in data.Rows)
                    {
                        str += row[0].ToString() + "\t" + row[1].ToString() + "\r\n";
                    }

                    F結果 F結果 = new F結果(str);
                    F結果.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void Tsvファイルの内容チェック(string[] filesDay1Excel)
        {
            try
            {
                foreach (var file in filesDay1Excel)
                {
                    string 通貨ペア = file.Substring(file.LastIndexOf('\\') + 1).Replace('_', '/').Split('.')[0];

                    // StreamReader の新しいインスタンスを生成する
                    using (StreamReader cReader = new StreamReader(file, Encoding.Default))
                    {
                        if (cReader.ReadLine().IndexOf(通貨ペア) < 0)
                        {
                            MessageBox.Show("ファイル名の通貨ペアとヘッダーの通貨ペアが不一致\r\n" + 通貨ペア + "\r\n" + file);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnTsvファイルの内容チェック_Click(object sender, EventArgs e)
        {
            try
            {
                string[] filesDay1Excel = Directory.GetFiles(txtDay1Excel.Text, "*", SearchOption.AllDirectories);
                string[] filesDay1Tsv = Directory.GetFiles(txtDay1Tsv.Text, "*", SearchOption.AllDirectories);
                string[] filesMin15Excel = Directory.GetFiles(txtMin15Excel.Text, "*", SearchOption.AllDirectories);
                string[] filesMin15Tsv = Directory.GetFiles(txtMin15Tsv.Text, "*", SearchOption.AllDirectories);

                if (filesDay1Excel.Count() != filesDay1Tsv.Count())
                {
                    for (int i = 0; i < filesDay1Excel.Count(); i++)
                    {
                        if (filesDay1Excel[i] == filesDay1Tsv[i]) continue;

                        MessageBox.Show("ファイル数不一致 Day1 \r\n" + filesDay1Excel[i]);
                        return;
                    }
                }

                if (filesMin15Excel.Count() != filesMin15Tsv.Count())
                {
                    for (int i = 0; i < filesMin15Excel.Count(); i++)
                    {
                        if (filesMin15Excel[i] == filesMin15Tsv[i]) continue;

                        MessageBox.Show("ファイル数不一致 Min15 \r\n" + filesMin15Excel[i]);
                        return;
                    }
                }

                Tsvファイルの内容チェック(filesDay1Tsv);
                Tsvファイルの内容チェック(filesMin15Tsv);

                MessageBox.Show("チェック完了");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnFXCMデータベースへインポート_Click(object sender, EventArgs e)
        {
            try
            {
                FXCMデータベースへインポート("Min15", txtインポート先フォルダ_Min15.Text);
                FXCMデータベースへインポート("Day1", txtインポート先フォルダ_Day1.Text);

                MessageBox.Show("インポート完了");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn取り込み済みデータを全て削除_Click(object sender, EventArgs e)
        {
            try
            {
                rate.取り込み済みデータを全て削除();

                MessageBox.Show("削除完了");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn時間調整実行_Click(object sender, EventArgs e)
        {
            try
            {
                rate.時間調整実行();

                MessageBox.Show("時間調整完了");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnエクスポート_Click(object sender, EventArgs e)
        {
            try
            {
                exp.ExeportRateHistory_fromFXCM(connectDBエクスポート先.SelectDB(), cmb対象テーブル.Text);

                MessageBox.Show("エクスポート完了");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnMin1再計算_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = DB定数.GetConnectionString(connectDB再計算先.SelectDB());
                    cn.Open();

                    recu.Min1再計算(cn);
                    recu.Min5再計算(cn);
                    recu.Min15再計算(cn);
                    recu.Hour1再計算(cn);
                    recu.Day1再計算(cn);
                    recu.Week1再計算(cn);
                    recu.Month1再計算(cn);
                }

                MessageBox.Show("再計算完了");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnMin5再計算_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = DB定数.GetConnectionString(connectDB再計算先.SelectDB());
                    cn.Open();

                    recu.Min5再計算(cn);
                    recu.Min15再計算(cn);
                    recu.Hour1再計算(cn);
                    recu.Day1再計算(cn);
                    recu.Week1再計算(cn);
                    recu.Month1再計算(cn);
                }

                MessageBox.Show("再計算完了");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnMin15再計算_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = DB定数.GetConnectionString(connectDB再計算先.SelectDB());
                    cn.Open();

                    recu.Min15再計算(cn);
                    recu.Hour1再計算(cn);
                    recu.Day1再計算(cn);
                    recu.Week1再計算(cn);
                    recu.Month1再計算(cn);
                }

                MessageBox.Show("再計算完了");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnHour1再計算_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = DB定数.GetConnectionString(connectDB再計算先.SelectDB());
                    cn.Open();

                    recu.Hour1再計算(cn);
                    recu.Day1再計算(cn);
                    recu.Week1再計算(cn);
                    recu.Month1再計算(cn);
                }

                MessageBox.Show("再計算完了");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnDay1再計算_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = DB定数.GetConnectionString(connectDB再計算先.SelectDB());
                    cn.Open();

                    recu.Day1再計算(cn);
                    recu.Week1再計算(cn);
                    recu.Month1再計算(cn);
                }

                MessageBox.Show("再計算完了");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnWeek1再計算_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = DB定数.GetConnectionString(connectDB再計算先.SelectDB());
                    cn.Open();

                    recu.Week1再計算(cn);
                    recu.Month1再計算(cn);
                }

                MessageBox.Show("再計算完了");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnMonth1再計算_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = DB定数.GetConnectionString(connectDB再計算先.SelectDB());
                    cn.Open();

                    recu.Month1再計算(cn);
                }

                MessageBox.Show("再計算完了");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        #endregion

    }
}
