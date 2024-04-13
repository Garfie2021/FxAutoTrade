using System;
using System.Data;
using System.Data.SqlClient;
using 定数;
using 共通Data;
using Common;
using DB_Maintenance;


namespace Maintenance_Form.シュミレーション
{
    public class Order_v7_Param
    {
        public SqlConnection cn;

        public byte 通貨ペアNo;
        public bool chkWMA月判定有り;
        public bool chkWMA週判定有り;
        public bool chkWMA日判定有り;

        public double 閾値_買いWMAs2角度 = 0.0;
        public long 閾値_経過時間カウント = 0;

        public long 注文回数 = 0;

        public long ポジティブだった注文回数 = 0;
        public long ポジティブな可能性のあった注文回数 = 0;
        public long ネガティブな注文回数 = 0;

        public double ポジティブだった注文のRate差 = 0;
        public double ポジティブな可能性のあった注文のRate差 = 0;
        public double ネガティブな注文のRate差 = 0;

        public double 合計_ポジティブだった注文のRate差 = 0;
        public double 合計_ポジティブな可能性のあった注文のRate差 = 0;
        public double 合計_ネガティブな注文のRate差 = 0;

        public DataTable dtWeek;
        public double 買いWMAs2_Week;
        public double 買いWMAs14_Week;

        public DataTable dtDay;
        public double 買いWMAs2_Day;
        public double 買いWMAs14_Day;

        public DateTime 買いWMAs2角度マイナス10発生_StartDate = DateTime.MinValue;
        public bool 買いWMAs2角度マイナス10発生 = false;
        public double 達した高値Rate_12時間以内 = 0.0;
        public double 達した安値Rate_12時間以内 = 0.0;
        public long 経過時間カウント = 0;
        public double 買いRate = 0.0;
        public double 合計Rate差_買い_高値 = 0.0;
        public double 合計Rate差_買い_安値 = 0.0;

        public long 合計数 = 0;
        public long 高値が安値の幅を超えた回数 = 0;
        public long 高値が付かなかった回数 = 0;
        public double 高値が付かなかった累計Rate幅 = 0.0;

        public DataTable dtHour1;
    }

    public static class Order_v7
    {
        // ループはHour1で回す。
        public static string 週次に対して日次が反転した際に注文(Order_v7_Param param)
        {
            foreach (DataRow row in param.dtHour1.Rows)
            {
                FormData.OrderData = new OrderData();
                FormData.OrderData.now = (DateTime)row["StartDate"];
                注文共通.StartTime_EndTime取得(FormData.OrderData);

                param.dtWeek = hstr.SelectWeek1(param.cn, param.通貨ペアNo, FormData.OrderData.StartWeek1);
                param.買いWMAs2_Week = (double)param.dtWeek.Rows[0]["買いWMAs2"];
                param.買いWMAs14_Week = (double)param.dtWeek.Rows[0]["買いWMAs14"];

                param.dtDay = hstr.SelectDay1(param.cn, param.通貨ペアNo, FormData.OrderData.StartDay1);
                param.買いWMAs2_Day = (double)param.dtDay.Rows[0]["買いWMAs2"];
                param.買いWMAs14_Day = (double)param.dtDay.Rows[0]["買いWMAs14"];

                if (param.買いWMAs14_Week > param.買いWMAs2_Week && param.買いWMAs14_Day < param.買いWMAs2_Day)
                {
                    // 週次で下がっていたのに、日次が上昇に転じたので注文
                    param.注文回数++;

                    var 買いRate = (double)row["買いRate_終値"];
                    var その日の終値 = (double)param.dtDay.Rows[0]["買いRate_終値"];
                    var その日の最高値 = (double)param.dtDay.Rows[0]["買いRate_高値"];
                    var その日の最安値 = (double)param.dtDay.Rows[0]["買いRate_安値"];

                    if (買いRate < その日の終値)
                    {
                        param.ポジティブだった注文回数++;
                        param.ポジティブだった注文のRate差 = その日の終値 - 買いRate;
                        param.合計_ポジティブだった注文のRate差 += param.ポジティブだった注文のRate差;
                    }
                    else if (買いRate < その日の最高値)
                    {
                        param.ポジティブな可能性のあった注文回数++;
                        param.ポジティブな可能性のあった注文のRate差 = (その日の最高値 - 買いRate) / 3;    // 3分の1を得られれば御の字。
                        param.合計_ポジティブな可能性のあった注文のRate差 += param.ポジティブな可能性のあった注文のRate差;
                    }
                    else
                    {
                        param.ネガティブな注文回数++;
                        param.ネガティブな注文のRate差 = その日の終値 - 買いRate;
                        param.合計_ネガティブな注文のRate差 += param.ネガティブな注文のRate差;
                    }

                    シュミレーションログ.WriteLog(string.Format("注文発生　StartDate:{0}　買いRate:{1}　その日の終値:{2}　その日の最高値：{3}  その日の最安値：{4} ポジティブだった注文のRate差:{5}  ポジティブな可能性のあった注文のRate差:{6}  ネガティブな注文のRate差:{7}",
                        FormData.OrderData.now, 買いRate, その日の終値, その日の最高値, その日の最安値,
                        param.ポジティブだった注文のRate差, param.ポジティブな可能性のあった注文のRate差, param.ネガティブな注文のRate差));
                }
            }

            シュミレーションログ.WriteLog(string.Format("ポジティブだった注文回数:{0}　ポジティブな可能性のあった注文回数:{1}　ネガティブな注文回数:{2}",
                param.ポジティブだった注文回数, param.ポジティブな可能性のあった注文回数, param.ネガティブな注文回数));

            シュミレーションログ.WriteLog(string.Format("合計　ポジティブだった注文のRate差:{0}　ポジティブな可能性のあった注文のRate差:{1}　ネガティブな注文のRate差:{2}",
                param.合計_ポジティブだった注文のRate差, param.合計_ポジティブな可能性のあった注文のRate差, param.合計_ネガティブな注文のRate差));

            return シュミレーションログ.GetLog();
        }

        public static string Hour1のみでWMAが反転した際に注文(Order_v7_Param param)
        {
            foreach (DataRow row in param.dtHour1.Rows)
            {
                FormData.OrderData = new OrderData();
                FormData.OrderData.now = (DateTime)row["StartDate"];
                注文共通.StartTime_EndTime取得(FormData.OrderData);

                if (param.chkWMA月判定有り)
                {
                    var dtMonth = hstr.SelectMonth1(param.cn, param.通貨ペアNo, FormData.OrderData.StartMonth1);

                    var 買いWMAs2 = (double)dtMonth.Rows[0]["買いWMAs2"];
                    var 買いWMAs14 = (double)dtMonth.Rows[0]["買いWMAs14"];

                    if (買いWMAs14 > 買いWMAs2) continue;
                }

                if (param.chkWMA週判定有り)
                {
                    var dtWeek = hstr.SelectWeek1(param.cn, param.通貨ペアNo, FormData.OrderData.StartWeek1);

                    var 買いWMAs2 = (double)dtWeek.Rows[0]["買いWMAs2"];
                    var 買いWMAs14 = (double)dtWeek.Rows[0]["買いWMAs14"];

                    if (買いWMAs14 > 買いWMAs2) continue;
                }

                if (param.chkWMA日判定有り)
                {
                    var dtDay = hstr.SelectDay1(param.cn, param.通貨ペアNo, FormData.OrderData.StartDay1);

                    var 買いWMAs2 = (double)dtDay.Rows[0]["買いWMAs2"];
                    var 買いWMAs14 = (double)dtDay.Rows[0]["買いWMAs14"];

                    if (買いWMAs14 > 買いWMAs2) continue;
                }

                var 買いRate_終値 = (double)row["買いRate_終値"];
                var 買いWMAs2角度 = (double)row["買いWMAs2角度"];
                var 買いRate_高値 = (double)row["買いRate_高値"];
                var 買いRate_安値 = (double)row["買いRate_安値"];

                if (買いWMAs2角度 < param.閾値_買いWMAs2角度)
                {
                    if (param.買いWMAs2角度マイナス10発生 == false)
                    {
                        // 買いに反転すると判断
                        シュミレーションログ.WriteLog($"買いWMAs2角度マイナス10発生　StartDate:{FormData.OrderData.now}　買いWMAs2角度:{買いWMAs2角度}　買いRate_終値:{買いRate_終値}");

                        param.買いWMAs2角度マイナス10発生 = true;

                        // 12時間以内に達した高値Rateを測定  
                        // ※AutoFXでは一つ前のHour1で判断することになる
                        param.買いWMAs2角度マイナス10発生_StartDate = FormData.OrderData.now;
                        param.経過時間カウント++;

                        continue;
                    }
                }

                if (param.買いWMAs2角度マイナス10発生)
                {
                    if (param.経過時間カウント == 1)
                    {
                        param.買いRate = 買いRate_終値;
                        param.達した高値Rate_12時間以内 = 買いRate_終値;
                        param.達した安値Rate_12時間以内 = 買いRate_終値;
                        シュミレーションログ.WriteLog($"買いポジション追加。 買いRate:{param.買いRate}");
                    }

                    // 12時間以内に達した高値Rateを測定
                    if (param.達した高値Rate_12時間以内 < 買いRate_高値)
                        param.達した高値Rate_12時間以内 = 買いRate_高値;

                    if (param.達した安値Rate_12時間以内 > 買いRate_安値)
                        param.達した安値Rate_12時間以内 = 買いRate_安値;

                    param.経過時間カウント++;
                }

                if (param.経過時間カウント > param.閾値_経過時間カウント)
                {
                    // 12時間に達したので初期化
                    シュミレーションログ.WriteLog($"12時間経過した。");

                    var Rate差_買い_高値 = param.達した高値Rate_12時間以内 - param.買いRate;
                    param.合計Rate差_買い_高値 += Rate差_買い_高値;
                    シュミレーションログ.WriteLog($"Rate差異:{Rate差_買い_高値} 達した高値Rate:{param.達した高値Rate_12時間以内} 終了_StartDate:{(DateTime)row["StartDate"]}");

                    var Rate差_買い_安値 = param.達した安値Rate_12時間以内 - param.買いRate;
                    param.合計Rate差_買い_安値 += Rate差_買い_安値;
                    シュミレーションログ.WriteLog($"Rate差異:{Rate差_買い_安値} 達した安値Rate:{param.達した安値Rate_12時間以内} 終了_StartDate:{(DateTime)row["StartDate"]}");

                    //var Rate差_買い_高値 = 達した高値Rate_12時間以内 - 売りRate;
                    //合計Rate差_買い_高値 += Rate差_買い_高値;
                    //log.AppendLine($"Rate差異:{Rate差_買い_高値} 達した高値Rate:{達した高値Rate_12時間以内} 終了_StartDate:{(DateTime)row["StartDate"]}");

                    //var Rate差_買い_安値 = 達した安値Rate_12時間以内 - 売りRate;
                    //合計Rate差_買い_安値 += Rate差_買い_安値;
                    //log.AppendLine($"Rate差異:{Rate差_買い_安値} 達した安値Rate:{達した安値Rate_12時間以内} 終了_StartDate:{(DateTime)row["StartDate"]}");

                    param.合計数++;
                    if (Rate差_買い_高値 > Math.Abs(Rate差_買い_安値)) param.高値が安値の幅を超えた回数++;
                    //if (Rate差_買い_高値 < 0.07) 高値が付かなかった回数++;
                    if (Rate差_買い_高値 < 0.1)
                    {
                        param.高値が付かなかった回数++;
                        param.高値が付かなかった累計Rate幅 += Rate差_買い_安値;
                    }

                    シュミレーションログ.WriteLog("\r\n");

                    param.買いWMAs2角度マイナス10発生_StartDate = DateTime.MinValue;
                    param.買いWMAs2角度マイナス10発生 = false;
                    param.達した高値Rate_12時間以内 = 0.0;
                    param.達した安値Rate_12時間以内 = 0.0;
                    param.経過時間カウント = 0;
                    param.買いRate = 0.0;
                }
            }

            シュミレーションログ.WriteLog($"合計Rate差_買い_高値:{param.合計Rate差_買い_高値}　合計Rate差_買い_安値:{param.合計Rate差_買い_安値}　");
            シュミレーションログ.WriteLog($"合計数:{param.合計数} 高値が安値の幅を超えた回数:{param.高値が安値の幅を超えた回数} 高値が付かなかった回数:{param.高値が付かなかった回数}");
            シュミレーションログ.WriteLog($"高値が付かなかった累計Rate幅:{param.高値が付かなかった累計Rate幅} ");

            return シュミレーションログ.GetLog();
        }

    }
}
