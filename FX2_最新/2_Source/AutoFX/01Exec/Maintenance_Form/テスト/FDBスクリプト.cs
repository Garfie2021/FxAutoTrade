using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Maintenance_Form
{
    public partial class FDBスクリプト : Form
    {
        public FDBスクリプト()
        {
            InitializeComponent();
        }

        private string TextData加工(string file)
        {
            var reader = new StreamReader(file);

            string line;
            string 加工済みText = "";
            while ((line = reader.ReadLine()) != null)
            {
                line = line.Trim();

                if (line.Length == 0) continue;
                if (line.StartsWith("/*")) continue;
                if (line.StartsWith("--")) continue;
                if (line.ToUpper() == "GO") continue;
                if (line.StartsWith("USE ")) continue;

                加工済みText += line + "\r\n";
            }

            return 加工済みText;
        }


        #region イベントハンドラ

        private void btn加工開始_DB_Click(object sender, EventArgs e)
        {
            try
            {
                // 「C:\Users\1111\Documents\DBスクリプト比較\DBスクリプト\plane」にDBから出力したスクリプトが保存されてる。

                // スクリプトを1行づつ読み込んで不要な行を除去
                foreach (var file in Directory.GetFiles(txtDB元.Text))
                {
                    string writeFile = txtTextData加工済みファイルの保存先_DB.Text + file.Substring(file.LastIndexOf("\\"));
                    File.WriteAllText(writeFile, TextData加工(file));
                }

                // SVNと同じフォルダ構造を作成
                if (Directory.Exists(txtSVNとの比較用に加工したDBスクリプトの保存先.Text))
                {
                    Directory.Delete(txtSVNとの比較用に加工したDBスクリプトの保存先.Text, true);
                }
                Directory.CreateDirectory(txtSVNとの比較用に加工したDBスクリプトの保存先.Text);

                // SVNのファイル名に合わせて保存し直し。
                foreach (var file in Directory.GetFiles(txtTextData加工済みファイルの保存先_DB.Text))
                {
                    // cmn.spChkTrade時間外.StoredProcedure.sql
                    var FileName = file.Substring(file.LastIndexOf("\\") + "\\".Length);
                    var splitFileName = FileName.Split('.');

                    var SchemaDirectroy = txtSVNとの比較用に加工したDBスクリプトの保存先.Text + "\\" + splitFileName[0];

                    if (Directory.Exists(SchemaDirectroy) == false)
                    {
                        Directory.CreateDirectory(SchemaDirectroy);
                    }

                    var destFilePath = SchemaDirectroy + "\\" + splitFileName[1] + "." + splitFileName[3];
                    File.Copy(file, destFilePath);
                }

                MessageBox.Show("完了");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn加工開始_SVN_Click(object sender, EventArgs e)
        {
            try
            {
                // SVNと同じフォルダ構造を作成
                if (Directory.Exists(txtDBとの比較用に加工したSVNスクリプトの保存先.Text))
                {
                    Directory.Delete(txtDBとの比較用に加工したSVNスクリプトの保存先.Text, true);
                }
                Directory.CreateDirectory(txtDBとの比較用に加工したSVNスクリプトの保存先.Text);

                // 「D:\work\3_FX\2_FX2\trunk2\3_SourceDB\RealA\1_DDL\2_SP」にSVNから出力したスクリプトが保存されてる。
                foreach (var folder in Directory.GetDirectories(txtSVN元.Text))
                {
                    Directory.CreateDirectory(txtDBとの比較用に加工したSVNスクリプトの保存先.Text + folder.Substring(folder.LastIndexOf("\\")));
                }

                foreach (var folderSchema in Directory.GetDirectories(txtSVN元.Text))
                {
                    var schema = folderSchema.Substring(folderSchema.LastIndexOf("\\"));

                    foreach (var file in Directory.GetFiles(folderSchema))
                    {
                        string writeFile = txtDBとの比較用に加工したSVNスクリプトの保存先.Text + schema + file.Substring(file.LastIndexOf("\\"));
                        File.WriteAllText(writeFile, TextData加工(file));
                    }
                }

                MessageBox.Show("完了");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnスキーマ比較開始_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "【スキーマ比較結果】\r\n";

                var folderSVN = Directory.GetDirectories(txtSVNとの比較用に加工したDBスクリプトの保存先.Text);
                var folderDB = Directory.GetDirectories(txtDBとの比較用に加工したSVNスクリプトの保存先.Text);

                if (folderSVN.SequenceEqual(folderDB))
                {
                    result += "一致\r\n";
                }
                else
                {
                    result += "SVN: " + folderSVN.Length + "\r\n";
                    result += "DB: " + folderDB.Length + "\r\n";
                    result += "\r\n";
                    result += "SVN\t/\tDB\r\n";

                    int max;
                    if (folderSVN.Length > folderDB.Length)
                    {
                        max = folderSVN.Length;
                    }
                    else
                    {
                        max = folderDB.Length;
                    }

                    int cnt = 0;
                    while (cnt < max)
                    {
                        if (folderSVN.Length - 1 < cnt) result += "";
                        else result += folderSVN[cnt].Substring(folderSVN[cnt].LastIndexOf("\\") + "\\".Length);

                        result += "\t/\t";

                        if (folderDB.Length - 1 < cnt) result += "";
                        else result += folderDB[cnt].Substring(folderDB[cnt].LastIndexOf("\\") + "\\".Length);

                        result += "\r\n";

                        cnt++;
                    }
                }

                result += "\r\n";

                F結果 F結果 = new F結果(result);
                F結果.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnストアド比較開始_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "【スキーマ比較結果】\r\n";

                var folderSVN = Directory.GetDirectories(txtSVNとの比較用に加工したDBスクリプトの保存先.Text);
                var folderDB = Directory.GetDirectories(txtDBとの比較用に加工したSVNスクリプトの保存先.Text);

                string[] folderBase;
                //int max;
                if (folderSVN.Length > folderDB.Length)
                {
                    folderBase = folderSVN;
                }
                else
                {
                    folderBase = folderDB;
                }

                foreach (var folder in folderBase)
                {
                    var schema = folder.Substring(folder.LastIndexOf("\\") + "\\".Length);

                    result += "【" + schema + "】\r\n";
                    result += "SVN\t/\tDB\r\n";

                    string[] fileSchemaSVN = { };
                    if (Directory.Exists(txtDBとの比較用に加工したSVNスクリプトの保存先.Text + "\\" + schema))
                    {
                        fileSchemaSVN = Directory.GetFiles(txtDBとの比較用に加工したSVNスクリプトの保存先.Text + "\\" + schema);
                    }

                    string[] fileSchemaDB = { };
                    if (Directory.Exists(txtSVNとの比較用に加工したDBスクリプトの保存先.Text + "\\" + schema))
                    {
                        fileSchemaDB = Directory.GetFiles(txtSVNとの比較用に加工したDBスクリプトの保存先.Text + "\\" + schema);
                    }

                    result += fileSchemaSVN.Length + "\t/\t" + fileSchemaDB.Length + "\r\n";

                    //if (folderSVN.SequenceEqual(folderDB))
                    //{
                    //    result += "一致\r\n";
                    //}
                    //else
                    //{
                    //}

                    result += "\r\n";
                }

                result += "\r\n";

                F結果 F結果 = new F結果(result);
                F結果.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        #endregion
    }
}
