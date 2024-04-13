using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maintenance_Form.シュミレーション
{
    public static class シュミレーションログ
    {
        private static StringBuilder log;

        public static void 初期化()
        {
            log = new StringBuilder(1024 * 1024);
        }

        public static void WriteLog(string ログ)
        {
            log.AppendLine(ログ);
            共通Data.ログ.ログ書き出し(ログ);
        }

        public static string GetLog()
        {
            return log.ToString();
        }
    }
}
