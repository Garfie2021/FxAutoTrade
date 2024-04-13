using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using 定数;
using 共通Data;
using DB_Maintenance;
using Common;
using SystemSetting;
using FXAPI共通;


namespace HealthCheck
{
    public static class HealthCheckSt
    {
        // DB毎にデータのロストが発生していないかチェック
        // OANDA_DemoB/OANDA_RealA データベースが対象
        public static void データロスト検出_OANDA(SqlConnection cn, string DB名, string 口座No, List<int> チェック口座NoList, ref string result)
        {
            const int tSec_1時間の最低件数 = 1620;   // 60秒 * 60分 - (60秒 * 60分 * 10%は誤差) / 2秒に1回
            const int tMin1_1時間の最低件数 = 54;    // 60 - (60 * 0.1)
            const int tMin5_1時間の最低件数 = 10;    // 12 - (12 * 0.1)
            const int tMin15_1時間の最低件数 = 3;   // 4 - (4 * 0.1)
            const int tHour1_1時間の最低件数 = 1;   // 1
            const int tDay1_1時間の最低件数 = 1;   // 1
            const int tWeek1_1時間の最低件数 = 1;   // 1
            const int tMonth1_1時間の最低件数 = 1;   // 1

            var 通貨ぺア取引状況List = Instrument初期化.通貨ペア初期化_OANDA_US();

            var StartDate_Houry = DateTime.Parse(DateTime.Now.AddHours(-1).ToString("yyyy/MM/dd HH:mm:00"));
            var EndDate_Houry = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd HH:mm:00"));

            var StartDate_Daily = DateTime.Parse(DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd HH:mm:00"));
            var EndDate_Daily = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd HH:mm:00"));

            var StartDate_Weekly = DateTime.Parse(DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd HH:mm:00"));
            var EndDate_Weekly = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd HH:mm:00"));

            var StartDate_Monthly = DateTime.Parse(DateTime.Now.AddMonths(-1).ToString("yyyy/MM/dd HH:mm:00"));
            var EndDate_Monthly = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd HH:mm:00"));

            var 通貨ペア数 = cnt.通貨ペア数(cn);

            var log = "";

            // anls //

            foreach (var 通貨ぺア取引状況 in 通貨ぺア取引状況List)
            {
                var 行数 = anls.CntデルタRate_通貨ペアNo_登録日時(cn, 通貨ぺア取引状況.通貨ペアNo, StartDate_Weekly, EndDate_Weekly);

                if (行数 < 1)
                {
                    Result(StartDate_Weekly, EndDate_Weekly, "anls.tデルタRate", 1, 通貨ぺア取引状況.通貨ペアNo, null, 行数, ref result);
                }
            }
            HealthCheckログ.ログ書き出し("[anls].[tデルタRate] 終了");

            foreach (var 通貨ぺア取引状況 in 通貨ぺア取引状況List)
            {
                var 行数 = anls.Cnt注文単位を割る値_通貨ペアNo_登録日時(cn, 通貨ぺア取引状況.通貨ペアNo, StartDate_Weekly, EndDate_Weekly);

                if (行数 < 1)
                {
                    Result(StartDate_Weekly, EndDate_Weekly, "anls.t注文単位を割る値", 1, 通貨ぺア取引状況.通貨ペアNo, null, 行数, ref result);
                }
            }
            HealthCheckログ.ログ書き出し("[anls].[t注文単位を割る値] 終了");


            // oanda //

            foreach (var チェック口座No in チェック口座NoList)
            {
                var 行数 = oanda.CntAccount_口座No_日時(cn, チェック口座No, StartDate_Houry, EndDate_Houry);

                if (行数 < 1)
                {
                    Result(StartDate_Houry, EndDate_Houry, "oanda.tAccount", 1, null, チェック口座No, 行数, ref result);
                }
            }
            HealthCheckログ.ログ書き出し("[oanda].[tAccount");


            // hstr // ※1時間おきに実行し、1時間前の総件数が0件かチェック

            foreach (var 通貨ぺア取引状況 in 通貨ぺア取引状況List)
            {
                var 行数 = hstr.CntSec_通貨ペアNo_StartDate(cn, 通貨ぺア取引状況.通貨ペアNo, StartDate_Houry, EndDate_Houry);

                if (行数 < tSec_1時間の最低件数)
                {
                    Result(StartDate_Houry, EndDate_Houry, "hstr.tSec", tSec_1時間の最低件数, 通貨ぺア取引状況.通貨ペアNo, null, 行数, ref result);
                }
            }
            HealthCheckログ.ログ書き出し("[hstr].[tSec] 終了");

            foreach (var 通貨ぺア取引状況 in 通貨ぺア取引状況List)
            {
                var 行数 = hstr.CntMin1_通貨ペアNo_StartDate(cn, 通貨ぺア取引状況.通貨ペアNo, StartDate_Houry, EndDate_Houry);

                if (行数 < tMin1_1時間の最低件数)
                {
                    Result(StartDate_Houry, EndDate_Houry, "hstr.tMin1", tMin1_1時間の最低件数, 通貨ぺア取引状況.通貨ペアNo, null, 行数, ref result);
                }
            }
            HealthCheckログ.ログ書き出し("[hstr].[tMin1] 終了");

            foreach (var 通貨ぺア取引状況 in 通貨ぺア取引状況List)
            {
                var 行数 = hstr.CntMin5_通貨ペアNo_StartDate(cn, 通貨ぺア取引状況.通貨ペアNo, StartDate_Houry, EndDate_Houry);

                if (行数 < tMin5_1時間の最低件数)
                {
                    Result(StartDate_Houry, EndDate_Houry, "hstr.tMin5", tMin5_1時間の最低件数, 通貨ぺア取引状況.通貨ペアNo, null, 行数, ref result);
                }
            }
            HealthCheckログ.ログ書き出し("[hstr].[tMin5] 終了");

            foreach (var 通貨ぺア取引状況 in 通貨ぺア取引状況List)
            {
                var 行数 = hstr.CntMin15_通貨ペアNo_StartDate(cn, 通貨ぺア取引状況.通貨ペアNo, StartDate_Houry, EndDate_Houry);

                if (行数 < tMin15_1時間の最低件数)
                {
                    Result(StartDate_Houry, EndDate_Houry, "hstr.tMin15", tMin15_1時間の最低件数, 通貨ぺア取引状況.通貨ペアNo, null, 行数, ref result);
                }
            }
            HealthCheckログ.ログ書き出し("[hstr].[tMin15] 終了");

            foreach (var 通貨ぺア取引状況 in 通貨ぺア取引状況List)
            {
                var 行数 = hstr.CntHour1_通貨ペアNo_StartDate(cn, 通貨ぺア取引状況.通貨ペアNo, StartDate_Houry, EndDate_Houry, ref log);

                if (行数 < tHour1_1時間の最低件数)
                {
                    Result(StartDate_Houry, EndDate_Houry, "hstr.tHour1", tHour1_1時間の最低件数, 通貨ぺア取引状況.通貨ペアNo, null, 行数, ref result);
                }
            }
            HealthCheckログ.ログ書き出し(log);
            log = "";
            HealthCheckログ.ログ書き出し("[hstr].[tHour1] 終了");

            foreach (var 通貨ぺア取引状況 in 通貨ぺア取引状況List)
            {
                var 行数 = hstr.CntDay1_通貨ペアNo_StartDate(cn, 通貨ぺア取引状況.通貨ペアNo, StartDate_Daily, EndDate_Daily);

                if (行数 < tDay1_1時間の最低件数)
                {
                    Result(StartDate_Daily, EndDate_Daily, "hstr.tDay1", tDay1_1時間の最低件数, 通貨ぺア取引状況.通貨ペアNo, null, 行数, ref result);
                }
            }
            HealthCheckログ.ログ書き出し("[hstr].[tDay1] 終了");

            foreach (var 通貨ぺア取引状況 in 通貨ぺア取引状況List)
            {
                var 行数 = hstr.CntWeek1_通貨ペアNo_StartDate(cn, 通貨ぺア取引状況.通貨ペアNo, StartDate_Weekly, EndDate_Weekly);

                if (行数 < tWeek1_1時間の最低件数)
                {
                    Result(StartDate_Weekly, EndDate_Weekly, "hstr.tWeek1", tWeek1_1時間の最低件数, 通貨ぺア取引状況.通貨ペアNo, null, 行数, ref result);
                }
            }
            HealthCheckログ.ログ書き出し("[hstr].[tWeek1] 終了");

            foreach (var 通貨ぺア取引状況 in 通貨ぺア取引状況List)
            {
                var 行数 = hstr.CntMonth1_通貨ペアNo_StartDate(cn, 通貨ぺア取引状況.通貨ペアNo, StartDate_Monthly, EndDate_Monthly);

                if (行数 < tMonth1_1時間の最低件数)
                {
                    Result(StartDate_Monthly, EndDate_Monthly, "hstr.tMonth1", tMonth1_1時間の最低件数, 通貨ぺア取引状況.通貨ペアNo, null, 行数, ref result);
                }
            }
            HealthCheckログ.ログ書き出し("[hstr].[tMonth1] 終了");


            // swap //

            var 行数2 = swap.CntSwap手動登録_Day1_StartDate(cn, StartDate_Daily.AddDays(-1), EndDate_Daily.AddDays(-1));

            if (行数2 < 通貨ペア数) 
            {
                Result(StartDate_Daily, EndDate_Daily, "swap.tSwap手動登録_Day1", 通貨ペア数, null, null, 行数2, ref result);
            }
            HealthCheckログ.ログ書き出し("[swap].[tSwap手動登録_Day1");

        }

        public static void Result(DateTime startDate, DateTime endDate, string テーブル, int _1時間の最低件数, byte? 通貨ペアNo, int? 口座No, int 行数, ref string result)
        {
            result += $"日時：{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}\r\n";
            result += $"StartDate：{startDate.ToString("yyyy/MM/dd HH:mm:ss")}\r\n";
            result += $"EndDate：{endDate.ToString("yyyy/MM/dd hh:mm:ss")}\r\n";
            result += $"テーブル：{テーブル} \r\n";
            result += $"1時間の最低件数：{_1時間の最低件数}\r\n";
            result += $"通貨ペアNo：{通貨ペアNo} \r\n";
            result += $"口座No：{口座No} \r\n";
            result += $"行数：{行数} \r\n\r\n";
        }

        // DB毎にデータのロストが発生していないかチェック
        // OANDA_DemoB_ACV/OANDA_RealA_ACV データベースが対象
        public static void データロスト検出_ACV(SqlConnection cn, string DB名, string 口座No, ref string result)
        {
            // 

            //


            //

            //

        }


        // SwapCollect データベースが対象
        // DB毎にデータのロストが発生していないかチェック
        // 日次で実行
        public static void データロスト検出_SwapCollect(SqlConnection cnOanda, SqlConnection cnSwapCollect,
            string DB名, DateTime StartDate, DateTime EndDate,
            ref string result)
        {
            // 口座No(1/2/3/4)毎に確認。 （SELECT distinct [口座No] FROM [SwapCollect].[oanda].[tTransaction]）
            // 日次で件数を確認。 月曜日～金曜日、0:00～23:59の間で通貨ペア数と同じレコード数があれば正常

            var 通貨ペア数 = cnt.通貨ペア数(cnOanda);

            var 行数1 = oanda.GetTransactionCnt_time(cnSwapCollect, 1, StartDate, EndDate);
            var 行数2 = oanda.GetTransactionCnt_time(cnSwapCollect, 2, StartDate, EndDate);

            var 行数3 = oanda.GetTransactionCnt_time(cnSwapCollect, 3, StartDate, EndDate);
            var 行数4 = oanda.GetTransactionCnt_time(cnSwapCollect, 4, StartDate, EndDate);

            if (行数1 + 行数2 != 通貨ペア数 || 行数3 + 行数4 != 通貨ペア数)
            {
                result += $"日時：{DateTime.Now.ToLongDateString()}\r\n";
                result += $"StartDate：{StartDate.ToLongDateString()}\r\n";
                result += $"EndDate：{EndDate.ToLongDateString()}\r\n";
                result += $"通貨ペア数：{通貨ペア数}\r\n";
                result += $"テーブル：Transaction \r\n";
                result += $"口座No：1  行数：{行数1} \r\n";
                result += $"口座No：2  行数：{行数2} \r\n";
                result += $"口座No：3  行数：{行数3} \r\n";
                result += $"口座No：4  行数：{行数4} \r\n";
            }
       }

    }
}
