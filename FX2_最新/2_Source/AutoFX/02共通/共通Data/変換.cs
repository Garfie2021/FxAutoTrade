using System;

namespace 共通Data
{
    public static class 変換
    {
        public static bool? GetBool売買(string 売買モード)
        {
            if (売買モード == "S")
                return false;
            else if (売買モード == "B")
                return true;
            else if (string.IsNullOrEmpty(売買モード))
                return null;
            else
            {
                // ここを通ったらバグ
                ログ.ログ書き出し("売買モード : " + 売買モード);
                throw new Exception("売買モードを変換できない");
            }
        }

        public static string GetStr売買(bool? 売買モード)
        {
            if (売買モード == false)
                return "S";
            else if (売買モード == true)
                return "B";
            else if (売買モード == null)
                return null;
            else
            {
                // ここを通ったらバグ
                ログ.ログ書き出し("売買モード : " + 売買モード);
                throw new Exception("売買モードを変換できない");
            }
        }

        // OANDA専用
        public static string GetStr売買Oanda(string strBuyShellMode)
        {
            if (strBuyShellMode == "sell")
                return "S";
            else if (strBuyShellMode == "buy")
                return "B";
            else if (string.IsNullOrEmpty(strBuyShellMode))
                return null;
            else
            {
                // ここを通ったらバグ
                ログ.ログ書き出し("strBuyShellMode : " + strBuyShellMode);
                throw new Exception("売買モードを変換できない");
            }
        }
    }

}
