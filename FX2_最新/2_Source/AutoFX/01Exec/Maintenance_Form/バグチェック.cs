using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using 定数;
using 共通Data;
using Common;
using SystemSetting;
using DB_Maintenance;
using Maintenance_Form.F手動データ登録;
using Maintenance_Form.Fデータ加工;
using System.Text;


namespace Maintenance_Form
{
    public class DBテーブル
    {
        public string schemaname;
        public string tblname;
        public DataColumnCollection Columns;
        public DataColumn[] PrimaryKey;
    }

    public static class バグチェック
    {
        public static void DBサンプリング比較(SqlConnection cn_Primary, SqlConnection cn_ACV)
        {
            var 接続先 = "【接続先】\r\n" + cn_Primary.ConnectionString + "\r\n" + cn_ACV.ConnectionString + "\r\n";

            const string sqlTmplate本テーブル = "select top 1 * from {0}.{1};";

            var DemoReal = システム設定.DemoReal判定(FormData.DBConnectionString);
            string 件名 = $"週次レポート バグチェック {DemoReal}";

            var dt_Primary = system.Selectテーブル一覧(cn_Primary);
            var dt_ACV = system.Selectテーブル一覧(cn_ACV);
            List<DBテーブル> DBテーブルList = new List<DBテーブル>();
            var resultテーブル不一致 = "【テーブル不一致】\r\n";
            var resultカラム不一致 = "【カラム不一致】\r\n";
            var resultPrimaryKey不一致 = "【PrimaryKey不一致】\r\n";
            var resultデータ不一致 = "【データ不一致】\r\n";

            テーブル不一致(dt_Primary, dt_ACV, ref DBテーブルList, ref resultテーブル不一致);

            foreach (var DBテーブル in DBテーブルList)
            {
                var dt本テーブル_Primary = system.ExecSql(cn_Primary, string.Format(sqlTmplate本テーブル, DBテーブル.schemaname, DBテーブル.tblname));
                var dt本テーブル_ACV = system.ExecSql(cn_ACV, string.Format(sqlTmplate本テーブル, DBテーブル.schemaname, DBテーブル.tblname));

                if (カラム不一致(dt_Primary, dt_ACV, DBテーブル, ref resultカラム不一致))
                    continue;

                if (PrimaryKey不一致(dt本テーブル_Primary, dt本テーブル_ACV, DBテーブル, ref resultPrimaryKey不一致))
                    continue;

                データ不一致(cn_Primary, cn_ACV, DBテーブル, ref resultデータ不一致);
            }

            Mail.SendMail(件名, 接続先 + "\r\n" + resultテーブル不一致 + "\r\n" + resultカラム不一致 + "\r\n" + resultPrimaryKey不一致 + "\r\n" + resultデータ不一致);
        }

        private static void テーブル不一致(DataTable dt_Primary, DataTable dt_ACV,
            ref List<DBテーブル> DBテーブルList, ref string result)
        {
            foreach (DataRow rowPrimary in dt_Primary.Rows)
            {
                var schemaname_Primary = (string)rowPrimary["schemaname"];
                var tblname_Primary = (string)rowPrimary["tblname"];

                foreach (DataRow rowACV in dt_ACV.Rows)
                {
                    var schemaname_ACV = (string)rowACV["schemaname"];
                    var tblname_ACV = (string)rowACV["tblname"];

                    if (schemaname_Primary == schemaname_ACV && tblname_Primary == tblname_ACV)
                    {
                        DBテーブルList.Add(new DBテーブル()
                        {
                            schemaname = schemaname_Primary,
                            tblname = tblname_Primary
                        });

                        break;
                    }
                }

                result += schemaname_Primary + "." + tblname_Primary;
            }

            result += "正常\r\n";
        }

        private static bool カラム不一致(DataTable dt_Primary, DataTable dt_ACV,
            DBテーブル DBテーブル, ref string result)
        {
            if (dt_ACV.Columns.Count != dt_ACV.Columns.Count)
            {
                result += $"[{DBテーブル.schemaname}.{DBテーブル.tblname}] カラム数不一致 \r\n";
                return true;
            }

            var cntカラム名一致 = 0;
            foreach (DataColumn clmPrimary in dt_Primary.Columns)
            {
                foreach (DataColumn clmACV in dt_ACV.Columns)
                {
                    if (clmPrimary.ColumnName == clmACV.ColumnName)
                    {
                        cntカラム名一致++;
                    }
                }
            }
            if (dt_Primary.Columns.Count != cntカラム名一致)
            {
                result += $"[{DBテーブル.schemaname}.{DBテーブル.tblname}] カラム名不一致\r\n";
                return true;
            }

            var cntカラムデータ型一致 = 0;
            foreach (DataColumn clmPrimary in dt_Primary.Columns)
            {
                foreach (DataColumn clmACV in dt_ACV.Columns)
                {
                    if (clmPrimary.DataType == clmACV.DataType)
                    {
                        cntカラムデータ型一致++;
                    }
                }
            }
            if (dt_Primary.Columns.Count != cntカラムデータ型一致)
            {
                result += $"[{DBテーブル.schemaname}.{DBテーブル.tblname}] カラムデータ型不一致\r\n";
                return true;
            }

            result += $"[{DBテーブル.schemaname}.{DBテーブル.tblname}] 正常\r\n";

            DBテーブル.Columns = dt_Primary.Columns;

            return false;
        }

        private static bool PrimaryKey不一致(DataTable dt_Primary, DataTable dt_ACV,
            DBテーブル DBテーブル, ref string result)
        {
            if (dt_Primary.PrimaryKey.Length != dt_ACV.PrimaryKey.Length)
            {
                result += $"[{DBテーブル.schemaname}.{DBテーブル.tblname}] PrimaryKey数不一致\r\n";
                return true;
            }

            var cntカラム名一致 = 0;
            foreach (var clmPrimary in dt_Primary.PrimaryKey)
            {
                foreach (var clmACV in dt_ACV.PrimaryKey)
                {
                    if (clmPrimary.ColumnName == clmACV.ColumnName)
                    {
                        cntカラム名一致++;
                    }
                }
            }
            if (dt_Primary.PrimaryKey.Length != cntカラム名一致)
            {
                result += $"[{DBテーブル.schemaname}.{DBテーブル.tblname}] PrimaryKeyカラム名不一致\r\n";
                return true;
            }

            result += $"[{DBテーブル.schemaname}.{DBテーブル.tblname}] 正常\r\n";

            DBテーブル.PrimaryKey = dt_Primary.PrimaryKey;

            return false;
        }

        private static string Where条件作成(DataColumnCollection columns)
        {
            var where = "";
            foreach (DataColumn clm in columns)
            {
                where += clm.ColumnName + "=";

                switch (clm.DataType.IsValueType.GetTypeCode())
                {
                    case TypeCode.Empty:
                    case TypeCode.DBNull:
                        // null
                        break;

                    case TypeCode.Boolean:
                        // bool
                        where += clm;
                        break;

                    case TypeCode.SByte:
                    case TypeCode.Byte:
                    case TypeCode.Int16:
                    case TypeCode.UInt16:
                    case TypeCode.Int32:
                    case TypeCode.UInt32:
                    case TypeCode.Int64:
                    case TypeCode.UInt64:
                    case TypeCode.Single:
                    case TypeCode.Double:
                    case TypeCode.Decimal:
                        // 数値
                        where += clm;
                        break;

                    case TypeCode.DateTime:
                    case TypeCode.Char:
                    case TypeCode.String:
                    case TypeCode.Object:
                        // 文字列
                        where += "\"" + clm + "\"";
                        break;
                }

                where += " AND ";
            }

            where.TrimEnd(new char[] { ' ', 'A', 'N', 'D', ' ' });  // 余分なANDを削除

            return where;
        }

        // ACVにデータをコピーした後、直ぐにPrimaryデータベースから削除するわけではないので、ACVの一番新しい値と比較
        private static void データ不一致(SqlConnection cn_Primary, SqlConnection cn_ACV,
            DBテーブル DBテーブル, ref string result)
        {
            const string sqlTmplate本テーブルOrderby_ACV = "select top 1 * from {0}.{1} order by {2};";
            const string sqlTmplate本テーブルWhere_Primary = "select top 1 * from {0}.{1} where {2};";

            var dt本テーブルOrderby_ACV = system.ExecSql(cn_ACV, string.Format(sqlTmplate本テーブルOrderby_ACV, DBテーブル.schemaname, DBテーブル.tblname, DBテーブル.PrimaryKey));

            var dt本テーブルWhere_Primary = system.ExecSql(cn_Primary, string.Format(sqlTmplate本テーブルWhere_Primary, DBテーブル.schemaname, DBテーブル.tblname, Where条件作成(dt本テーブルOrderby_ACV.Columns)));

            if (dt本テーブルWhere_Primary.Rows.Count < 1)
            {
                result += $"[{DBテーブル.schemaname}.{DBテーブル.tblname}] データ不一致 \r\n";
            }
        }


    }
}
