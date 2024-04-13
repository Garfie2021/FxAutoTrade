using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Data.SqlClient;
using 定数;
using 共通Data;
using DB;

namespace Common
{
    public static class 注文共通
    {
        public static int minAmount = 0;


        public static void データ不足判定_更新()
        {
            foreach (var 通貨ぺア取引状況 in FormData.通貨ぺア別取引状況)
            {
                oder.Chkデータ不足判定(通貨ぺア取引状況);
            }
        }

        public static int 少数点の桁数取得(double decValue)
        {
            return decValue.ToString().Split('.')[1].Length;
        }

        private static DateTime 先月当月利益更新_年月;
        public static void 先月当月利益更新()
        {
            // 当月の利益 //

            先月当月利益更新_年月 = DateTime.Now;
            pfmc.Insert利益_Monthly(先月当月利益更新_年月, FormData.出金可能にする開始日時, FormData.出金可能にする利益Percent);

            int 利益確定開始以降の利益;
            int 出金可能額;

            pfmc.Get利益Monthly(DateTime.Parse(先月当月利益更新_年月.Year.ToString() + "/" + 先月当月利益更新_年月.Month.ToString() + "/1 00:00:00"),
                out 利益確定開始以降の利益, out 出金可能額);

            FormData.当月利益プラス = 利益確定開始以降の利益;

            if (出金可能額 < 1)
            {
                FormData.出金可能額_当月 = 0;
            }
            else
            {
                FormData.出金可能額_当月 = 出金可能額;
            }


            // 先月の利益 //

            先月当月利益更新_年月 = 先月当月利益更新_年月.AddMonths(-1);

            pfmc.Insert利益_Monthly(先月当月利益更新_年月, FormData.出金可能にする開始日時, FormData.出金可能にする利益Percent);

            pfmc.Get利益Monthly(DateTime.Parse(先月当月利益更新_年月.Year.ToString() + "/" + 先月当月利益更新_年月.Month.ToString() + "/1 00:00:00"),
                out 利益確定開始以降の利益, out 出金可能額);

            FormData.先月利益プラス = 利益確定開始以降の利益;

            if (出金可能額 < 1)
            {
                FormData.出金可能額_先月 = 0;
            }
            else
            {
                FormData.出金可能額_先月 = 出金可能額;
            }

            // 先月の利益は出金済み？ //
            if (pfmc.Chk出金済み(DateTime.Now, FormData.取引証拠金, FormData.先月利益プラス) == 1)
            {
                // 出金済み
                FormData.出金済_先月 = "済";
            }
            else
            {
                // 未出金
                FormData.出金済_先月 = "";
            }

        }


        public static void 自動取引開始終了()
        {
            //if (btn自動取引開始_Text == "自動取引開始")
            //if (txt取引モード表示_Text == "自動取引中")
            if (FormData.取引モード表示 == "")
            {
                自動取引を再開();
            }
            else
            {
                自動取引を解除();
            }
        }

        public static void 自動取引を解除()
        {
            if (FormData.MasterSlave == MasterSlave.Master)
            {
                FormData.timer_1sec.Enabled = false;
            }

            if (FormData.MasterSlave == MasterSlave.Slave)
            {

                FormData.timer_4sec.Enabled = false;
                FormData.timer_3min.Enabled = false;
            }

            FormData.timer_10min.Enabled = false;
            FormData.timer_1hour.Enabled = false;
            FormData.timer_1day.Enabled = false;

            FormData.取引モード表示 = "";
        }

        public static void 自動取引を再開()
        {
            if (FormData.MasterSlave == MasterSlave.Master)
            {
                FormData.timer_1sec.Enabled = true;
            }

            if (FormData.MasterSlave == MasterSlave.Slave)
            {
                FormData.timer_4sec.Enabled = true;
                FormData.timer_3min.Enabled = true;
            }

            FormData.timer_10min.Enabled = true;
            FormData.timer_1hour.Enabled = true;
            FormData.timer_1day.Enabled = true;

            FormData.取引モード表示 = "自動取引中";
        }

        public static void 全Timerを停止()
        {
            //全てのTimerを停止
            FormData.timer_1sec.Enabled = false;
            FormData.timer_4sec.Enabled = false;
            FormData.timer_3min.Enabled = false;
            FormData.timer_10min.Enabled = false;
            FormData.timer_1hour.Enabled = false;
            FormData.timer_1day.Enabled = false;

            FormData.取引モード表示 = "";
        }

        public static void StartTime_EndTime取得(OrderData OrderData)
        {
            cmn.GetThisMonth1(OrderData);
            cmn.GetThisWeek1(OrderData);
            cmn.GetThisDay1(OrderData);
            cmn.GetThisHour1(OrderData);
            cmn.GetThisMin15(OrderData);
            cmn.GetThisMin5(OrderData);
            cmn.GetThisMin1(OrderData);
        }

        public static void DB接続先表示()
        {
            FormData.DB接続先 = FormData.DBConnectionString;
        }

        public static void システム設定_表示()
        {
            // 注文設定 //
            //FormData.txtBS発生_リミット拡張幅_Text = FormData.BS発生_リミット拡張幅;

            // Order //
            //FormData.txtシステム設定_AtMarket_Text = FormData.txtシステム設定_AtMarket_Text;

            // Close Trade //
            //FormData.システム設定_CloseTrade_nヵ月前からあるポジション = FormData.CloseTrade_nヵ月前からあるポジション;
            //FormData.システム設定_CloseTrade_n以上であればCloseする = FormData.CloseTrade_n以上であればCloseする;

            // その他 //
            //FormData.システム設定_日付はn時くぎり = FormData.日付はn時くぎり;

            FormData.口座種別 = FormData.個人法人.ToString();
            FormData.Connection = FormData.DemoReal.ToString();
            //FormData.Username = FormData.Username;
            //FormData.Password = FormData.Password;

            //FormData.chkn日以上前のポジション決済をスキップ_Checked = FormData.n日以上前のポジション決済をスキップ;

            FormData.ログイン表示 = "";
            FormData.取引モード表示 = "";
            FormData.ToolStripStsLbl = "";

        }

        public static void システム日時更新()
        {
            FormData.システム設定_年 = DateTime.Now.Year;
            FormData.システム設定_月 = DateTime.Now.Month;
            FormData.システム設定_日 = DateTime.Now.Day;
            FormData.システム設定_時 = DateTime.Now.Hour;
            FormData.システム設定_分 = DateTime.Now.Minute;
            FormData.システム設定_秒 = DateTime.Now.Second;
            FormData.txtシステム設定_曜日 = DateTime.Now.DayOfWeek.ToString();

            FormData.システム設定_Trade時間内 = GetTrade時間内();
        }

        public static void Exception共通(Exception ex, List<Cエラー関連変数> エラー関連変数List)
        {
            try
            {
                FormData.ToolStripStsLbl = "Exceptionエラーが発生しました。 " + ex.Message;
                FormData.ToolStripStsLbl_BackColor = Color.Red;

                ログ.ログ書き出し(ex);

                if (エラー関連変数List != null)
                {
                    foreach (Cエラー関連変数 エラー関連変数 in エラー関連変数List)
                    {
                        ログ.ログ書き出し(エラー関連変数.変数名 + " : " + エラー関連変数.値);
                    }
                }
            }
            catch (Exception ex2)
            {
                File.AppendAllText(@"C:\error.log", DateTime.Now.ToString() + " " + ex.Message + "\r\n" + ex.StackTrace + "\r\n", FormData.Enc);
                File.AppendAllText(@"C:\error.log", DateTime.Now.ToString() + " " + ex2.Message + "\r\n" + ex2.StackTrace + "\r\n", FormData.Enc);
            }
        }

        public static void WMA計算ALL(OrderData OrderData)
        {
            foreach (var 通貨ぺア取引状況 in FormData.通貨ぺア別取引状況.Where(x => x.Chkデータ生成 == true).ToList())
            {
                rate.InsertRateHistory_Min1(OrderData, 通貨ぺア取引状況);
                rate.InsertRateHistory_Min5(OrderData, 通貨ぺア取引状況);
                rate.InsertRateHistory_Min15(OrderData, 通貨ぺア取引状況);
                rate.InsertRateHistory_Hour1(OrderData, 通貨ぺア取引状況);
                rate.InsertRateHistory_Day1(OrderData, 通貨ぺア取引状況);
                rate.InsertRateHistory_Week1(OrderData, 通貨ぺア取引状況);
                rate.InsertRateHistory_Month1(OrderData, 通貨ぺア取引状況);
                rate.UpdateWMA_Min1(OrderData, 通貨ぺア取引状況);
                rate.UpdateWMA_Min5(OrderData, 通貨ぺア取引状況);
                rate.UpdateWMA_Min15(OrderData, 通貨ぺア取引状況);
                rate.UpdateWMA_Hour1(OrderData, 通貨ぺア取引状況);
                rate.UpdateWMA_Day1(OrderData, 通貨ぺア取引状況);
                rate.UpdateWMA_Week1(OrderData, 通貨ぺア取引状況);
                rate.UpdateWMA_Month1(OrderData, 通貨ぺア取引状況);
            }
        }

        public static void WMA計算(通貨ぺア取引状況 通貨ぺア取引状況)
        {
            rate.InsertRateHistory_Min1(FormData.OrderData, 通貨ぺア取引状況);
            rate.InsertRateHistory_Min5(FormData.OrderData, 通貨ぺア取引状況);
            rate.InsertRateHistory_Min15(FormData.OrderData, 通貨ぺア取引状況);
            rate.InsertRateHistory_Hour1(FormData.OrderData, 通貨ぺア取引状況);
            rate.UpdateWMA_Min1(FormData.OrderData, 通貨ぺア取引状況);
            rate.UpdateWMA_Min5(FormData.OrderData, 通貨ぺア取引状況);
            rate.UpdateWMA_Min15(FormData.OrderData, 通貨ぺア取引状況);
            rate.UpdateWMA_Hour1(FormData.OrderData, 通貨ぺア取引状況);

            if ((FormData.OrderData.now.Hour == 5 && FormData.OrderData.now.Minute > 58) || (FormData.OrderData.now.Hour == 6 && FormData.OrderData.now.Minute < 1))
            {
                rate.InsertRateHistory_Day1(FormData.OrderData, 通貨ぺア取引状況);
                rate.InsertRateHistory_Week1(FormData.OrderData, 通貨ぺア取引状況);
                rate.InsertRateHistory_Month1(FormData.OrderData, 通貨ぺア取引状況);
                rate.UpdateWMA_Day1(FormData.OrderData, 通貨ぺア取引状況);
                rate.UpdateWMA_Week1(FormData.OrderData, 通貨ぺア取引状況);
                rate.UpdateWMA_Month1(FormData.OrderData, 通貨ぺア取引状況);
            }
        }

        public static bool Chk注文設定_Chk注文(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            if (通貨ぺア取引状況.Chk注文 == false)
            {
                BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, "Order対象外（Chk注文がFalse）", OrderData.now);
                return false;
            }

            return true;
        }


        public static bool 注文設定_Swap判定(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            if (通貨ぺア取引状況.買いSwap == 0 && 通貨ぺア取引状況.売りSwap == 0)
            {
                通貨ぺア取引状況.Swap判定 = "";
                BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, "Order対象外（Swap判定できず）", OrderData.now);
                return false;
            }

            if (通貨ぺア取引状況.買いSwap > 通貨ぺア取引状況.売りSwap)
            {
                if (通貨ぺア取引状況.買いSwap < 0)
                {
                    通貨ぺア取引状況.Swap判定 = "";
                    BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, "Order対象外（Swap値が低過ぎる）買", OrderData.now);
                    return false;
                }

                通貨ぺア取引状況.Swap判定 = "B";
            }
            else
            {
                if (通貨ぺア取引状況.売りSwap < 0)
                {
                    通貨ぺア取引状況.Swap判定 = "";
                    BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, "Order対象外（Swap値が低過ぎる）売", OrderData.now);
                    return false;
                }

                通貨ぺア取引状況.Swap判定 = "S";
            }

            return true;
        }

        public static bool B_逆ポジションの有る通貨ペアを算出(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            if (FormData.TradeApi.Chk逆ポジション(通貨ぺア取引状況) == false)
            {
                // Swap判定に反するポジションは保持してなかった
                return true;
            }

            if (通貨ぺア取引状況.売買判定 == "B")
            {
                BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, "Order対象外(Swapに対して逆ポジション有り)買", OrderData.now);

                if (通貨ぺア取引状況.WMA判定_Month1_売りWMAs2 < 通貨ぺア取引状況.WMA判定_Month1_売りWMAs14 && 通貨ぺア取引状況.WMA判定_Month1_売りWMAs2角度 < 0 &&
                    通貨ぺア取引状況.WMA判定_Week1_売りWMAs2 < 通貨ぺア取引状況.WMA判定_Week1_売りWMAs14 && 通貨ぺア取引状況.WMA判定_Week1_売りWMAs2角度 < 0 &&
                    通貨ぺア取引状況.WMA判定_Day1_売りWMAs2 < 通貨ぺア取引状況.WMA判定_Day1_売りWMAs14 && 通貨ぺア取引状況.WMA判定_Day1_売りWMAs2角度 < 0)
                {
                    // 保持ポジションが買で、Swap判定が売、RateのGC判定が売
                    通貨ぺア取引状況.DefaultCellStyle_BackColor = FormData.clrSwap判定が逆のポジションがありRateも保持ポジションの逆に動いてる_BackColor;
                }
                else
                {
                    // 保持ポジションが買で、Swap判定が売、RateのGC判定が買
                    通貨ぺア取引状況.DefaultCellStyle_BackColor = FormData.clrSwap判定が逆のポジションがある_BackColor;
                }
            }
            else if (通貨ぺア取引状況.売買判定 == "S")
            {
                BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, "Order対象外(Swapに対して逆ポジション有り)売", OrderData.now);

                if (通貨ぺア取引状況.WMA判定_Month1_買いWMAs2 > 通貨ぺア取引状況.WMA判定_Month1_買いWMAs14 && 通貨ぺア取引状況.WMA判定_Month1_買いWMAs2角度 > 0 &&
                    通貨ぺア取引状況.WMA判定_Week1_買いWMAs2 > 通貨ぺア取引状況.WMA判定_Week1_買いWMAs14 && 通貨ぺア取引状況.WMA判定_Week1_買いWMAs2角度 > 0 &&
                    通貨ぺア取引状況.WMA判定_Day1_買いWMAs2 > 通貨ぺア取引状況.WMA判定_Day1_買いWMAs14 && 通貨ぺア取引状況.WMA判定_Day1_買いWMAs2角度 > 0)
                {
                    // 保持ポジションが売で、Swap判定が買、RateのGC判定が買
                    通貨ぺア取引状況.DefaultCellStyle_BackColor = FormData.clrSwap判定が逆のポジションがありRateも保持ポジションの逆に動いてる_BackColor;
                }
                else
                {
                    // 保持ポジションが売で、Swap判定が買、RateのGC判定が売
                    通貨ぺア取引状況.DefaultCellStyle_BackColor = FormData.clrSwap判定が逆のポジションがある_BackColor;
                }
            }
            else
            {
                // ここを通ったらバグ
                BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, "Order対象外(「通貨ぺア取引状況.売買判定」がnull)", OrderData.now);
                return false;
            }

            return false;
        }

        private static double 注文単位を算出_証拠金の3分の2;
        private static double 注文単位を算出_注文単位A;
        private static double 注文単位を算出_注文単位B;
        private static int 注文単位を算出_注文単位_最終;
        public static int 注文単位を算出(通貨ぺア取引状況 通貨ぺア取引状況)
        {
            anls.Get注文単位を割る値(通貨ぺア取引状況);

            if (FormData.取引証拠金上限 == null || FormData.取引証拠金上限 > FormData.取引証拠金)
            {
                if (FormData.取引証拠金上限 == null || FormData.取引証拠金 - FormData.取引証拠金上限 < 1)
                {
                    FormData.ロスカット余剰金調整値 = 0;
                }
                else
                {
                    FormData.ロスカット余剰金調整値 = (int)FormData.取引証拠金 - (int)FormData.取引証拠金上限;
                }

                注文単位を算出_証拠金の3分の2 = (FormData.取引証拠金 - FX定数.OANDA注文禁止証拠金 - FormData.ロスカット余剰金調整値) * 0.66;
            }
            else
            {
                注文単位を算出_証拠金の3分の2 = (double)(FormData.取引証拠金上限 - FX定数.OANDA注文禁止証拠金) * 0.66;
            }

            if (FormData.余剰証拠金 > 注文単位を算出_証拠金の3分の2)
            {
                注文単位を算出_注文単位A = 注文単位を算出_証拠金の3分の2 / (通貨ぺア取引状況.注文単位を割る値 * (通貨ぺア取引状況.ポジション数 + 1));
            }
            else
            {
                注文単位を算出_注文単位A = FormData.余剰証拠金 / (通貨ぺア取引状況.注文単位を割る値 * (通貨ぺア取引状況.ポジション数 + 1));
            }

            注文単位を算出_注文単位B = 注文単位を算出_注文単位A * 通貨ぺア取引状況.証拠金倍率;

            // SWAP補正
            // swapを10分の１にしその値を注文単位にかける。Swapが0の場合もあるのでswapを + 1した後。
            if ((bool)通貨ぺア取引状況.売買)
            {
                注文単位を算出_注文単位_最終 = (int)(注文単位を算出_注文単位B * ((通貨ぺア取引状況.買いSwap + 1) / 20));
            }
            else
            {
                注文単位を算出_注文単位_最終 = (int)(注文単位を算出_注文単位B * ((通貨ぺア取引状況.売りSwap + 1) / 20));
            }

            if (FormData.chkスワップロジックの注文条件を緩和)
            {
                注文単位を算出_注文単位_最終 = 注文単位を算出_注文単位_最終 / 3;
            }

            if (注文単位を算出_注文単位_最終 < 1)
            {
                ログ.ログ書き出し("\r\n 【注文単位が0】start");
                ログ.ログ書き出し("FormData.取引証拠金上限 : " + FormData.取引証拠金上限);
                ログ.ログ書き出し("FormData.取引証拠金 : " + FormData.取引証拠金);
                ログ.ログ書き出し("FormData.ロスカット余剰金調整値 : " + FormData.ロスカット余剰金調整値);
                ログ.ログ書き出し("FX定数.OANDA注文禁止証拠金 : " + FX定数.OANDA注文禁止証拠金);
                ログ.ログ書き出し("FormData.ロスカット余剰金調整値 : " + FormData.ロスカット余剰金調整値);
                ログ.ログ書き出し("注文単位を算出_証拠金の3分の2 : " + 注文単位を算出_証拠金の3分の2);
                ログ.ログ書き出し("FormData.ロスカット余剰金 : " + FormData.余剰証拠金);
                ログ.ログ書き出し("通貨ぺア取引状況.注文単位を割る値 : " + 通貨ぺア取引状況.注文単位を割る値);
                ログ.ログ書き出し("通貨ぺア取引状況.ポジション数 : " + 通貨ぺア取引状況.ポジション数);
                ログ.ログ書き出し("通貨ぺア取引状況.証拠金倍率 : " + 通貨ぺア取引状況.証拠金倍率);
                ログ.ログ書き出し("注文単位を算出_注文単位 : " + 注文単位を算出_注文単位A);
                ログ.ログ書き出し("注文単位を算出_注文単位 : " + 注文単位を算出_注文単位B);
                ログ.ログ書き出し("注文単位を算出_注文単位_最終 : " + 注文単位を算出_注文単位_最終);
                ログ.ログ書き出し("【注文単位が0】end \r\n ");
            }

            return 注文単位を算出_注文単位_最終;
        }

        private static long? ポジション追加_TradeData_id;
        public static void ポジション追加(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況, string ロジック)
        {
            if (通貨ぺア取引状況.最終注文日時 > OrderData.StartDay1)
            {
                BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, ロジック + "当日にOrder有り", OrderData.now);
                return;
            }

            if (通貨ぺア取引状況.最終注文日時 > OrderData.now.AddHours(-8))
            {
                BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, ロジック + "8時間以内にOrder有り", OrderData.now);
                return;
            }

            if (通貨ぺア取引状況.ポジションClose最終日時 > OrderData.now.AddHours(-3))
            {
                BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, ロジック + "3時間以内にポジションClose有り(1)", OrderData.now);
                return;
            }
            else
            {
                // 直近のポジションClose最終日時を再確認。
                // 「通貨ぺア取引状況.ポジションClose最終日時」が更新される前に注文が実行されることがある。
                if (FormData.TradeApi.直近のポジションClose最終日時を再確認(通貨ぺア取引状況.Instrument2, OrderData.now.AddHours(-3), OrderData.StartDay1))
                {
                    BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, ロジック + "3時間以内にポジションClose有り(2)", OrderData.now);
                    return; // 近くのRateでポジションが既にある。
                }
            }

            //if (FormData.余剰金の割合 < FormData.余剰金割合_Order限界点)
            //{
            //    取引停止中("取引停止中（余剰金割合_Order限界点）");
            //    BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, "取引停止中（余剰金割合_Order限界点）", OrderData.now);
            //    return;
            //}

            if (Chk限界余剰証拠金(OrderData, 通貨ぺア取引状況))
            {
                取引停止中("取引停止中（総ポジション限界数）");
                return;
            }

            if (FormData.TradeApi.Chk近似Rateにポジション有り(通貨ぺア取引状況))
            {
                BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, ロジック + "近似Rateにポジション有り", OrderData.now);
                return; // 近くのRateでポジションが既にある。
            }

            if ((bool)通貨ぺア取引状況.BS開始)
            {
                通貨ぺア取引状況.売買 = 変換.GetBool売買(通貨ぺア取引状況.BS_WMA判定_15m);
            }
            else
            {
                通貨ぺア取引状況.売買 = 変換.GetBool売買(通貨ぺア取引状況.売買判定);
            }

            if (通貨ぺア取引状況.売買 == null)
            {
                // ここを通ったらバグ
                throw new Exception("「通貨ぺア取引状況.売買」がnull");
            }

            FormData.TradeApi.リミット_ストップ取得(通貨ぺア取引状況);

            BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, ロジック + "注文実行", OrderData.now);

            通貨ぺア取引状況.最終注文日時 = FormData.OrderData.now;

            通貨ぺア取引状況.注文単位 = 注文単位を算出(通貨ぺア取引状況);

            oder.InsertOrderHistory2(FormData.OrderData, 通貨ぺア取引状況);

            FormData.当日注文数++;

            if (FormData.chk注文状態記録まで注文はスキップ)
            {
                BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, ロジック + "注文状態記録まで注文はスキップ", OrderData.now);
                return;
            }

            ポジション追加_TradeData_id = FormData.TradeApi.ポジション追加_成行(通貨ぺア取引状況);

            oder.UpdateOrderHistory_OANDA_Trade_ID(通貨ぺア取引状況.通貨ペアNo, FormData.OrderData, ポジション追加_TradeData_id);
        }

        // true：「BS開始/BS継続中/BS終了」いずれかの処理が実行されたので、通常注文処理は不要。
        // false：「BS開始/BS継続中/BS終了」いずれでもないので、通常注文処理が必要。
        public static bool C_注文_Order_Ver6_BS(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況, string ロジック)
        {
            if (通貨ぺア取引状況.データ不足_Min15)
            {
                BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, ロジック + "データ不足(Min15)", OrderData.now);
                return false;
            }

            //前回の判定結果をクリア(FormData.OrderData, 通貨ぺア取引状況);

            通貨ぺア取引状況.BS判定_前 = 通貨ぺア取引状況.BS判定_今;

            oder.Chkボーナスステージ_15m(FormData.OrderData, 通貨ぺア取引状況);

            通貨ぺア取引状況.BS判定_今 = 通貨ぺア取引状況.BS判定_15m;

            通貨ぺア取引状況.BS開始 = false;
            if (通貨ぺア取引状況.BS判定_前 == "" && 通貨ぺア取引状況.BS判定_今 == "B")
            {
                // Bonus Stage 開始処理 //

                BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, ロジック + "Order中 (BS開始)", OrderData.now);

                if (通貨ぺア取引状況.BS開始_禁止時間 > OrderData.now)
                {
                    BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, ロジック + "Order対象外（BS開始 禁止時間）", OrderData.now);
                    通貨ぺア取引状況.BS判定_今 = "";
                    return false;    // 前回のBS開始から2分以内は、証券会社に大量のポジション変更依頼を出さない為にスキップする。
                }

                通貨ぺア取引状況.BS開始_禁止時間 = OrderData.now.AddMinutes(2);

                if (売買判定(通貨ぺア取引状況) == false)
                {
                    BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, ロジック + "Order対象外（BSの持続力が弱い）", OrderData.now);
                    通貨ぺア取引状況.BS判定_今 = "";
                    return false;    // BBが持続する確率は低い
                }

                if (通貨ぺア取引状況.BS_WMA判定_15m != 通貨ぺア取引状況.売買判定)
                {
                    BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, ロジック + "Order対象外（BSとWMAの売買判定が一定しない）", OrderData.now);
                    通貨ぺア取引状況.BS判定_今 = "";
                    return false;
                }

                if (通貨ぺア取引状況.保持ポジション != "")
                {
                    if (通貨ぺア取引状況.保持ポジション != 通貨ぺア取引状況.BS_WMA判定_15m)
                    {
                        BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, ロジック + "Order対象外（BS判定とは逆のポジションが既に有る）", OrderData.now);
                        通貨ぺア取引状況.BS判定_今 = "";
                        return false;
                    }
                }

                注文設定_Swap判定(FormData.OrderData, 通貨ぺア取引状況);

                if (通貨ぺア取引状況.マイナスInstrument)
                {
                    // マイナスInstrumentが記録されていたので次の通貨ペアへ
                    BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, ロジック + "Order対象外（マイナスInstrument）", OrderData.now);
                    return true;
                }

                if (通貨ぺア取引状況.Swap判定 == "")
                {
                    // Swap判定できなかったので次の通貨ペアへ
                    通貨ぺア取引状況.BS判定_今 = "";
                    return true;
                }

                if (通貨ぺア取引状況.BS_WMA判定_15m != 通貨ぺア取引状況.Swap判定)
                {
                    BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, ロジック + "Order対象外（BSとWMAの売買判定が一定しない）", OrderData.now);
                    通貨ぺア取引状況.BS判定_今 = "";
                    return false;
                }

                通貨ぺア取引状況.BS開始 = true;

                if (FormData.MasterSlave == MasterSlave.Master)
                {
                    hstr.InsertBonusStage(FormData.OrderData, 通貨ぺア取引状況);
                }

                ポジション追加(OrderData, 通貨ぺア取引状況, ロジック);

                return true;
            }
            else if (通貨ぺア取引状況.BS判定_前 == "B" && 通貨ぺア取引状況.BS判定_今 == "")
            {
                // Bonus Stage 終了処理 //

                BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, ロジック + "Order対象外（BS終了）", OrderData.now);

                if (通貨ぺア取引状況.保持ポジション != "")
                {
                    FormData.TradeApi.利益が出ているポジションは全てクローズする();

                    // 大して利益を産まないので、初期化は朝まで待つ。
                    // FormData.TradeApi.保持ポジションのリミット初期化_BS終了時(通貨ぺア取引状況);
                }

                if (FormData.MasterSlave == MasterSlave.Master)
                {
                    hstr.InsertBonusStage(FormData.OrderData, 通貨ぺア取引状況);
                }

                return true;
            }
            else if (通貨ぺア取引状況.BS判定_前 == "B" && 通貨ぺア取引状況.BS判定_今 == "B")
            {
                // Bonus Stage 継続中は何もしない //

                BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, ロジック + "Order対象外（BS継続中）", OrderData.now);

                return true;
            }

            return false;
        }

        public static void C_注文_Order_Ver6_Swap(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況, string ロジック)
        {
            if (通貨ぺア取引状況.データ不足_Week1)
            {
                BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, ロジック + "データ不足(Week1)", OrderData.now);
                return;
            }

            if (通貨ぺア取引状況.データ不足_Month1)
            {
                BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, ロジック + "データ不足(Month1)", OrderData.now);
                return;
            }

            if (売買判定(通貨ぺア取引状況) == false)
            {
                BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, ロジック + "Order対象外(通常 WMA判定)", OrderData.now);
                return;
            }

            注文設定_Swap判定(FormData.OrderData, 通貨ぺア取引状況);

            if (通貨ぺア取引状況.マイナスInstrument)
            {
                // マイナスInstrumentが記録されていたので次の通貨ペアへ
                BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, ロジック + "Order対象外（マイナスInstrument）", OrderData.now);
                return;
            }

            if (通貨ぺア取引状況.Swap判定 == "")
            {
                BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, ロジック + "Order対象外(通常 Swap判定)", OrderData.now);
                return;
            }

            if (通貨ぺア取引状況.Swap判定 != 通貨ぺア取引状況.売買判定)
            {
                BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, ロジック + "Order対象(通常 Swap判定と売買判定が不一致)", OrderData.now);
                return;
            }

            if (B_逆ポジションの有る通貨ペアを算出(FormData.OrderData, 通貨ぺア取引状況) == false)
            {
                BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, ロジック + "Order対象(通常 逆ポジションの有り)", OrderData.now);
                return;
            }

            ポジション追加( OrderData, 通貨ぺア取引状況, ロジック);
        }

        public static void C_注文_Order_Ver7_反転(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況, string ロジック)
        {
            if (通貨ぺア取引状況.データ不足_Week1)
            {
                BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, ロジック + "データ不足(Week1)", OrderData.now);
                return;
            }

            if (売買判定(通貨ぺア取引状況) == false)
            {
                BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, ロジック + "Order対象外(反転 WMA判定)", OrderData.now);
                return;
            }

            if (FormData.chk反転ロジックはマイナススワップのみ対象)
            {
                // デモ口座検証用ロジック

                if (通貨ぺア取引状況.売買判定 == "B" && 通貨ぺア取引状況.買いSwap >= 0)
                {
                    BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, ロジック + "Order対象外(反転 プラススワップ)", OrderData.now);
                    return;
                }
                else if (通貨ぺア取引状況.売買判定 == "S" && 通貨ぺア取引状況.売りSwap >= 0)
                {
                    BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, ロジック + "Order対象外(反転 プラススワップ)", OrderData.now);
                    return;
                }
            }

            if (FormData.TradeApi.Chk逆ポジション(通貨ぺア取引状況))
            {
                BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, ロジック + "Order対象外(反転 逆ポジション有り)", OrderData.now);
                return;
            }

            ポジション追加(OrderData, 通貨ぺア取引状況, ロジック);
        }

        public static bool Chk限界余剰証拠金(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            // 維持証拠金が10万円では、3ポジションが限界。
            // 維持証拠金が100万円なら、30ポジションが限界。
            // 維持証拠金が1000万円なら、300ポジションが限界。
            // 維持証拠金が1億円なら、3000ポジションが限界。

            if (FormData.取引証拠金 * 0.4 > FormData.余剰証拠金) // FX定数.OANDA注文禁止証拠金 は判断材料に加えない
            {
                BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, "Order対象外（余剰証拠金が取引証拠金の40%以下）", OrderData.now);
                return true;
            }

            return false;
        }

        public static void BS終了_再処理(DateTime n分前)
        {
            foreach (var 通貨ぺア取引状況 in FormData.通貨ぺア別取引状況)
            {
                BS終了_再処理_通貨ぺア取引状況(n分前, 通貨ぺア取引状況);
            }
        }

        public static void BS終了_再処理_通貨ぺア取引状況(DateTime n分前, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            if (通貨ぺア取引状況.保持ポジション == "")
                return;

            if (通貨ぺア取引状況.BS判定_前 == "B" || 通貨ぺア取引状況.BS判定_今 == "B")
                return;

            if (oder.Chk直近n分以内にボーナスステージ終了有り(通貨ぺア取引状況, n分前) == false)
                return;

            FormData.TradeApi.利益が出ているポジションは全てクローズする();

            FormData.TradeApi.Swapに反しているいるBSポジションは全てクローズする(通貨ぺア取引状況);

            FormData.TradeApi.保持ポジションのリミット初期化_BS終了時(通貨ぺア取引状況);
        }

        public static void 取引停止中(string Order状況)
        {
            FormData.Order状況 = Order状況;
            維持証拠金小計_更新();

            //FormData.txt決算待ちポジション数 = FormData.TradeApi.現在保有しているポジション数();

            return;
        }

        private static int 維持証拠金小計_更新_通貨ペアNo;
        public static void 維持証拠金小計_更新()
        {
            for (維持証拠金小計_更新_通貨ペアNo = 0; 維持証拠金小計_更新_通貨ペアNo < FormData.通貨ぺア別取引状況.Count; 維持証拠金小計_更新_通貨ペアNo++)
            {
                FormData.通貨ぺア別取引状況[維持証拠金小計_更新_通貨ペアNo].維持証拠金小計 =
                    (int)FormData.通貨ぺア別取引状況[維持証拠金小計_更新_通貨ペアNo].Unit数 *
                    (int)FormData.通貨ぺア別取引状況[維持証拠金小計_更新_通貨ペアNo].維持証拠金;
            }
        }


        private static double 余剰金調整用_出金可能調整額;
        private static double 余剰金調整用_ロスカット余剰金;
        public static void 余剰金調整()
        {
            余剰金調整用_出金可能調整額 = 0;
            if (FormData.出金済_先月 == "")
            {
                // 未出金
                余剰金調整用_出金可能調整額 = FormData.出金可能額_先月;
            }

            // 当月の利益を足す
            余剰金調整用_出金可能調整額 += FormData.出金可能額_当月;

            余剰金調整用_ロスカット余剰金 = FormData.余剰証拠金;
            if (余剰金調整用_出金可能調整額 < 0)
            {
                // 損切りによって、出金可能額がマイナスになった場合
                FormData.出金可能額で調整したロスカット余剰金 = FormData.余剰証拠金;
            }
            else
            {
                FormData.出金可能額で調整したロスカット余剰金 = (余剰金調整用_ロスカット余剰金 - 余剰金調整用_出金可能調整額);
            }

        }

        public static void 前回の判定結果をクリア(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            通貨ぺア取引状況.BS_WMA判定_15m = "";
            //FromData.DG[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_BS判定_前 = "";
            //FromData.DG[通貨ペアNo].Cells[C共通.DGVClmNo注文設定_BS判定_今 = "";
        }


        public static bool 取引可能時間帯()
        {
            if (FormData.システム設定_Trade時間内 == "時間内")
            {
                return true;
            }

            return false;
        }

        public static bool ChkGC逆判定(OrderData OrderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            oder.Get売買判定_Month1(OrderData, 通貨ぺア取引状況);
            if (通貨ぺア取引状況.BS_WMA判定_15m != 通貨ぺア取引状況.ChkGC逆判定_Month1_売買判定) return true;    // 逆の動きをしているので危険。

            oder.Get売買判定_Week1(OrderData, 通貨ぺア取引状況);
            if (通貨ぺア取引状況.BS_WMA判定_15m != 通貨ぺア取引状況.ChkGC逆判定_Week1_売買判定) return true; // 逆の動きをしているので危険。

            oder.Get売買判定_Day1(OrderData, 通貨ぺア取引状況);
            if (通貨ぺア取引状況.BS_WMA判定_15m != 通貨ぺア取引状況.ChkGC逆判定_Day1_売買判定) return true;  // 逆の動きをしているので危険。

            oder.Get売買判定_Hour1(OrderData, 通貨ぺア取引状況);
            if (通貨ぺア取引状況.BS_WMA判定_15m != 通貨ぺア取引状況.ChkGC逆判定_Hour1_売買判定) return true; // 逆の動きをしているので危険。

            oder.Get売買判定_Min15(OrderData, 通貨ぺア取引状況);
            if (通貨ぺア取引状況.BS_WMA判定_15m != 通貨ぺア取引状況.ChkGC逆判定_Min15_売買判定) return true; // 逆の動きをしているので危険。

            oder.Get売買判定_Min5(OrderData, 通貨ぺア取引状況);
            if (通貨ぺア取引状況.BS_WMA判定_15m != 通貨ぺア取引状況.ChkGC逆判定_Min5_売買判定) return true;  // 逆の動きをしているので危険。

            oder.Get売買判定_Min1(OrderData, 通貨ぺア取引状況);
            if (通貨ぺア取引状況.BS_WMA判定_15m != 通貨ぺア取引状況.ChkGC逆判定_Min1_売買判定) return true;	// 逆の動きをしているので危険。

            return false;   // Min15と他の単位で逆の動きはなかったので危険は無い。
        }

        public static bool 売買判定(通貨ぺア取引状況 通貨ぺア取引状況)
        {
            if (FormData.chkスワップロジックの注文条件を緩和)
            {
                if ((通貨ぺア取引状況.WMA判定_Week1_買いWMAs2 > 通貨ぺア取引状況.WMA判定_Week1_買いWMAs14 && 通貨ぺア取引状況.WMA判定_Week1_買いWMAs2角度 > 0 &&
                     通貨ぺア取引状況.WMA判定_Day1_買いWMAs2 > 通貨ぺア取引状況.WMA判定_Day1_買いWMAs14 && 通貨ぺア取引状況.WMA判定_Day1_買いWMAs2角度 > 0) ||
                    (通貨ぺア取引状況.WMA判定_Week1_買いWMAs2 < 通貨ぺア取引状況.WMA判定_Week1_買いWMAs14 && 通貨ぺア取引状況.WMA判定_Week1_買いWMAs2角度 > 0 &&
                     通貨ぺア取引状況.WMA判定_Day1_買いWMAs2 > 通貨ぺア取引状況.WMA判定_Day1_買いWMAs14 && 通貨ぺア取引状況.WMA判定_Day1_買いWMAs2角度 > 0))
                {
                    // 週次と日次のどちらも上昇しているか、週次が下がっていたのに対して日次が反転上昇した場合は注文対象。

                    通貨ぺア取引状況.売買判定 = "B";
                    return true;
                }
                else if (
                    (通貨ぺア取引状況.WMA判定_Week1_売りWMAs2 < 通貨ぺア取引状況.WMA判定_Week1_売りWMAs14 && 通貨ぺア取引状況.WMA判定_Week1_売りWMAs2角度 < 0 &&
                     通貨ぺア取引状況.WMA判定_Day1_売りWMAs2 < 通貨ぺア取引状況.WMA判定_Day1_売りWMAs14 && 通貨ぺア取引状況.WMA判定_Day1_売りWMAs2角度 < 0) ||
                    (通貨ぺア取引状況.WMA判定_Week1_売りWMAs2 >  通貨ぺア取引状況.WMA判定_Week1_売りWMAs14 && 通貨ぺア取引状況.WMA判定_Week1_売りWMAs2角度 < 0 &&
                     通貨ぺア取引状況.WMA判定_Day1_売りWMAs2 < 通貨ぺア取引状況.WMA判定_Day1_売りWMAs14 && 通貨ぺア取引状況.WMA判定_Day1_売りWMAs2角度 < 0))
                {
                    // 週次と日次のどちらも下降しているか、週次が上昇していたのに対して日次が反転下降した場合は注文対象。

                    通貨ぺア取引状況.売買判定 = "S";
                    return true;
                }

                通貨ぺア取引状況.売買判定 = "";
                return false;
            }
            else
            {
                if (通貨ぺア取引状況.WMA判定_Month1_買いWMAs2 > 通貨ぺア取引状況.WMA判定_Month1_買いWMAs14 && 通貨ぺア取引状況.WMA判定_Month1_買いWMAs2角度 > 0 &&
                    通貨ぺア取引状況.WMA判定_Week1_買いWMAs2 > 通貨ぺア取引状況.WMA判定_Week1_買いWMAs14 && 通貨ぺア取引状況.WMA判定_Week1_買いWMAs2角度 > 0 &&
                    通貨ぺア取引状況.WMA判定_Day1_買いWMAs2 > 通貨ぺア取引状況.WMA判定_Day1_買いWMAs14 && 通貨ぺア取引状況.WMA判定_Day1_買いWMAs2角度 > 0 &&
                    通貨ぺア取引状況.WMA判定_Hour1_買いWMAs2 > 通貨ぺア取引状況.WMA判定_Hour1_買いWMAs14 && 通貨ぺア取引状況.WMA判定_Hour1_買いWMAs2角度 > 0 &&
                    通貨ぺア取引状況.WMA判定_Min15_買いWMAs2 > 通貨ぺア取引状況.WMA判定_Min15_買いWMAs14 && 通貨ぺア取引状況.WMA判定_Min15_買いWMAs2角度 > 0 &&
                    通貨ぺア取引状況.WMA判定_Min5_買いWMAs2 > 通貨ぺア取引状況.WMA判定_Min5_買いWMAs14 && 通貨ぺア取引状況.WMA判定_Min5_買いWMAs2角度 > 0 &&
                    通貨ぺア取引状況.WMA判定_Min1_買いWMAs2 > 通貨ぺア取引状況.WMA判定_Min1_買いWMAs14 && 通貨ぺア取引状況.WMA判定_Min1_買いWMAs2角度 > 0)
                {
                    通貨ぺア取引状況.売買判定 = "B";
                    return true;
                }
                else if (
                    通貨ぺア取引状況.WMA判定_Month1_売りWMAs2 < 通貨ぺア取引状況.WMA判定_Month1_売りWMAs14 && 通貨ぺア取引状況.WMA判定_Month1_売りWMAs2角度 < 0 &&
                    通貨ぺア取引状況.WMA判定_Week1_売りWMAs2 < 通貨ぺア取引状況.WMA判定_Week1_売りWMAs14 && 通貨ぺア取引状況.WMA判定_Week1_売りWMAs2角度 < 0 &&
                    通貨ぺア取引状況.WMA判定_Day1_売りWMAs2 < 通貨ぺア取引状況.WMA判定_Day1_売りWMAs14 && 通貨ぺア取引状況.WMA判定_Day1_売りWMAs2角度 < 0 &&
                    通貨ぺア取引状況.WMA判定_Hour1_売りWMAs2 < 通貨ぺア取引状況.WMA判定_Hour1_売りWMAs14 && 通貨ぺア取引状況.WMA判定_Hour1_売りWMAs2角度 < 0 &&
                    通貨ぺア取引状況.WMA判定_Min15_売りWMAs2 < 通貨ぺア取引状況.WMA判定_Min15_売りWMAs14 && 通貨ぺア取引状況.WMA判定_Min15_売りWMAs2角度 < 0 &&
                    通貨ぺア取引状況.WMA判定_Min5_売りWMAs2 < 通貨ぺア取引状況.WMA判定_Min5_売りWMAs14 && 通貨ぺア取引状況.WMA判定_Min5_売りWMAs2角度 < 0 &&
                    通貨ぺア取引状況.WMA判定_Min1_売りWMAs2 < 通貨ぺア取引状況.WMA判定_Min1_売りWMAs14 && 通貨ぺア取引状況.WMA判定_Min1_売りWMAs2角度 < 0)
                {
                    通貨ぺア取引状況.売買判定 = "S";
                    return true;
                }

                通貨ぺア取引状況.売買判定 = "";
                return false;
            }
        }

        public static bool 売買判定_反転(通貨ぺア取引状況 通貨ぺア取引状況)
        {
            if (通貨ぺア取引状況.WMA判定_Week1_買いWMAs2 < 通貨ぺア取引状況.WMA判定_Week1_買いWMAs14 &&
                通貨ぺア取引状況.WMA判定_Day1_買いWMAs2 > 通貨ぺア取引状況.WMA判定_Day1_買いWMAs14)
            {
                通貨ぺア取引状況.売買判定 = "B";
                return true;
            }
            else if (
                通貨ぺア取引状況.WMA判定_Week1_売りWMAs2 > 通貨ぺア取引状況.WMA判定_Week1_売りWMAs14 &&
                通貨ぺア取引状況.WMA判定_Day1_売りWMAs2 < 通貨ぺア取引状況.WMA判定_Day1_売りWMAs14)
            {
                通貨ぺア取引状況.売買判定 = "S";
                return true;
            }

            通貨ぺア取引状況.売買判定 = "";
            return false;
        }
        
        public static string GetTrade時間内()
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday && DateTime.Now.Hour > 6)
                return "時間外";
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
                return "時間外";
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Monday && DateTime.Now.Hour < 5)
                return "時間外";
            else
                return "時間内";
        }

        private static DateTime Get当日の開始日時_Now;
        public static DateTime Get当日の開始日時(DateTime dt)
        {
            Get当日の開始日時_Now = dt;

            if (Get当日の開始日時_Now.Hour < FormData.システム設定_日付はn時くぎり)
                Get当日の開始日時_Now = Get当日の開始日時_Now.AddDays(-1);

            return DateTime.Parse(Get当日の開始日時_Now.Year.ToString() + "/" + Get当日の開始日時_Now.Month.ToString() + "/" + Get当日の開始日時_Now.Day.ToString() + " " + FormData.システム設定_日付はn時くぎり.ToString() + ":00:00");
        }


        private static DateTime 土日を含む場合の調整_時間単位_from;
        private static DateTime 土日を含む場合の調整_時間単位_to;
        public static void 土日を含む場合の調整_時間単位(DateTime now, int iFrom, int iTo, out int iOutFrom, out int iOutTo)
        {
            土日を含む場合の調整_時間単位_from = now.AddHours(iFrom);
            土日を含む場合の調整_時間単位_to = now.AddHours(iTo);

            iOutFrom = iFrom;
            iOutTo = iTo;

            if (土日を含む場合の調整_時間単位_to.DayOfWeek == DayOfWeek.Saturday && 6 <= 土日を含む場合の調整_時間単位_to.Hour)
            {
                iOutFrom = iFrom - 48;
                iOutTo = iTo - 48;
                return;
            }
            else if (土日を含む場合の調整_時間単位_to.DayOfWeek == DayOfWeek.Sunday)
            {
                iOutFrom = iFrom - 48;
                iOutTo = iTo - 48;
                return;
            }
            else if (土日を含む場合の調整_時間単位_to.DayOfWeek == DayOfWeek.Monday && 土日を含む場合の調整_時間単位_to.Hour < 6)
            {
                iOutFrom = iFrom - 48;
                iOutTo = iTo - 48;
                return;
            }

            if (土日を含む場合の調整_時間単位_from.DayOfWeek == DayOfWeek.Saturday && 6 <= 土日を含む場合の調整_時間単位_from.Hour)
                iOutFrom = iFrom - 48;
            else if (土日を含む場合の調整_時間単位_from.DayOfWeek == DayOfWeek.Sunday)
                iOutFrom = iFrom - 48;
            else if (土日を含む場合の調整_時間単位_from.DayOfWeek == DayOfWeek.Monday && 土日を含む場合の調整_時間単位_from.Hour < 6)
                iOutFrom = iFrom - 48;

        }
    }
}
