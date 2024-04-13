using System.Data.SqlClient;
using System.Windows.Forms;
using 定数;

namespace Common
{
    public class コンボボックス
    {
        public static void SQL実行結果をコンボボックスに展開(SqlDataReader reader, ref ComboBox cmb)
        {
            cmb.Items.Clear();

            // SQLの実行結果をコンボボックスに表示
            while (reader.Read())
            {
                cmb.Items.Add(reader[0].ToString());
            }

            reader.Close();
        }
    }
}
