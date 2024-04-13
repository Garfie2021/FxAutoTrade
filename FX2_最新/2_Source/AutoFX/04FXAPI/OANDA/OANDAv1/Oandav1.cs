using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using 定数;
using 共通Data;
using Common;
using DB;

namespace OANDAv1
{
    public static class OANDAv1
    {
        public static void ログイン_Order開始()
        {
            if (FormData.chk初期値の計算処理をスキップ == false)
            {
                foreach (var 通貨ぺア取引状況 in FormData.通貨ぺア別取引状況)
                {
                    cmn.Get起動初期値_通貨ペア別(通貨ぺア取引状況);
                }
            }

            ログイン();
            OoandaInstrument取得();

            通貨ペアSwap更新();

            if (FormData.MasterSlave == MasterSlave.Master)
            {
                Rate取得WMA計算();
            }
            else
            {
                oanda.GetTransaction最終日時();
                FormData.当日注文数 = oder.Cnt当日注文数(注文共通.Get当日の開始日時(DateTime.Now));
                マイナスInstrument更新(false);

                保持ポジション更新(FormData.通貨ぺア別取引状況);

                if (FormData.chkInsturment取得に失敗したためRate取得Onlyに移行 == false)
                {
                    //QuoteID表示();
                    アカウント状態更新();
                    DB記録_Account();
                    //注文共通.先月当月利益更新(cn);
                }

                DB記録_Trade_ポジション数更新_注文禁止Rate幅更新();

                注文共通.データ不足判定_更新();

                Order_Ver6();
            }
        }

        // Swap判定可能になったらこっちを使う
        public static void Order_Ver6()
        {
            //DB記録_ClosedTrade(cn);
            //アカウント状態更新();

            注文共通.余剰金調整();
            FormData.余剰金の割合 = 余剰金の割合計算();

            if (double.IsNaN(FormData.余剰金の割合) == true)
            {
                注文共通.取引停止中("取引停止中（IsNaN(余剰金の割合)）");
                return;
            }

            if (FormData.chk余剰金確保の自動ポジションCloseはしない == false)
            {
                ClosedTrades_余剰金を確保する();
            }

            Order_Ver6_WMA_BS_順張り();

            //DB記録_Trade(cn);
        }

        private static List<TradeData> 手動登録したSwapに反するポジションは自動クローズする_openTrades;
        private static bool 手動登録したSwapに反するポジションは自動クローズする_close;
        public static void 手動登録したSwapに反するポジションは自動クローズする()
        {
            手動登録したSwapに反するポジションは自動クローズする_openTrades = Rest.GetTradeListAsync(FormData.OandaAccountId);

            foreach (var tradeData in 手動登録したSwapに反するポジションは自動クローズする_openTrades)
            {
                var 通貨ぺア別取引状況 = FormData.通貨ぺア別取引状況.Where(x => x.Instrument2 == tradeData.instrument).First();

                手動登録したSwapに反するポジションは自動クローズする_close = false;
                if (tradeData.side == "buy" && 通貨ぺア別取引状況.買いSwap <= 0)
                {
                    手動登録したSwapに反するポジションは自動クローズする_close = true;
                }
                else if (tradeData.side == "sell" && 通貨ぺア別取引状況.売りSwap <= 0)
                {
                    手動登録したSwapに反するポジションは自動クローズする_close = true;
                }

                if (手動登録したSwapに反するポジションは自動クローズする_close)
                {
                    oder.InsertCloseHistory(1, null, 通貨ぺア別取引状況, tradeData);

                    var closedDetails = Rest.DeleteTradeAsync(FormData.OandaAccountId, tradeData.id);

                    oanda.InsertDeleteTradeResponse(closedDetails);
                }
            }
        }

        private const string マイナスInstrument更新_マイナスInstrument = "id\ttime\tinstrument\tinterest\t買いSwap\t売りSwap\t保持ポジション\t売買判定Month1\t売買判定Week1\t売買判定Day1\r\n";
        private static List<マイナスInstrument> マイナスInstrument更新_dt;
        private static string マイナスInstrument更新_マイナスInstrument_tmp;
        private static 通貨ぺア取引状況 マイナスInstrument更新_マイナスInstrument_通貨ぺア取引状況;
        public static void マイナスInstrument更新(bool メール送信する)
        {
            マイナスInstrument更新_マイナスInstrument_tmp = "";

            // マイナスInstrumentを初期化
            foreach (var 通貨ぺア取引状況 in FormData.通貨ぺア別取引状況.Where(x => x.マイナスInstrument == true))
            {
                通貨ぺア取引状況.マイナスInstrument = false;
            }

            // 過去4日間にマイナスInstrumentが記録されているか
            マイナスInstrument更新_dt = oanda.SelectマイナスInstrument(DateTime.Now.AddDays(-4), DateTime.Now);

            if (マイナスInstrument更新_dt.Count < 1) return;

            foreach (var row in マイナスInstrument更新_dt)
            {
                マイナスInstrument更新_マイナスInstrument_通貨ぺア取引状況 = FormData.通貨ぺア別取引状況.Where(x => x.Instrument2 == row.instrument).First();
                マイナスInstrument更新_マイナスInstrument_通貨ぺア取引状況.マイナスInstrument = true;

                string 売買判定Month1 = "";
                if (マイナスInstrument更新_マイナスInstrument_通貨ぺア取引状況.WMA判定_Month1_買いWMAs2 > マイナスInstrument更新_マイナスInstrument_通貨ぺア取引状況.WMA判定_Month1_買いWMAs14 && マイナスInstrument更新_マイナスInstrument_通貨ぺア取引状況.WMA判定_Month1_買いWMAs2角度 > 0)
                {
                    売買判定Month1 = "B";
                }
                else if (マイナスInstrument更新_マイナスInstrument_通貨ぺア取引状況.WMA判定_Month1_売りWMAs2 < マイナスInstrument更新_マイナスInstrument_通貨ぺア取引状況.WMA判定_Month1_売りWMAs14 && マイナスInstrument更新_マイナスInstrument_通貨ぺア取引状況.WMA判定_Month1_売りWMAs2角度 < 0)
                {
                    売買判定Month1 = "S";
                }

                string 売買判定Week1 = "";
                if (マイナスInstrument更新_マイナスInstrument_通貨ぺア取引状況.WMA判定_Week1_買いWMAs2 > マイナスInstrument更新_マイナスInstrument_通貨ぺア取引状況.WMA判定_Week1_買いWMAs14 && マイナスInstrument更新_マイナスInstrument_通貨ぺア取引状況.WMA判定_Week1_買いWMAs2角度 > 0)
                {
                    売買判定Week1 = "B";
                }
                else if (マイナスInstrument更新_マイナスInstrument_通貨ぺア取引状況.WMA判定_Week1_売りWMAs2 < マイナスInstrument更新_マイナスInstrument_通貨ぺア取引状況.WMA判定_Week1_売りWMAs14 && マイナスInstrument更新_マイナスInstrument_通貨ぺア取引状況.WMA判定_Week1_売りWMAs2角度 < 0)
                {
                    売買判定Week1 = "S";
                }

                string 売買判定Day1 = "";
                if (マイナスInstrument更新_マイナスInstrument_通貨ぺア取引状況.WMA判定_Day1_買いWMAs2 > マイナスInstrument更新_マイナスInstrument_通貨ぺア取引状況.WMA判定_Day1_買いWMAs14 && マイナスInstrument更新_マイナスInstrument_通貨ぺア取引状況.WMA判定_Day1_買いWMAs2角度 > 0)
                {
                    売買判定Day1 = "B";
                }
                else if (マイナスInstrument更新_マイナスInstrument_通貨ぺア取引状況.WMA判定_Day1_売りWMAs2 < マイナスInstrument更新_マイナスInstrument_通貨ぺア取引状況.WMA判定_Day1_売りWMAs14 && マイナスInstrument更新_マイナスInstrument_通貨ぺア取引状況.WMA判定_Day1_売りWMAs2角度 < 0)
                {
                    売買判定Day1 = "S";
                }

                マイナスInstrument更新_マイナスInstrument_tmp +=
                    マイナスInstrument更新_マイナスInstrument + 
                    row.id.ToString() + "\t" +
                    row.time.ToString() + "\t" +
                    row.instrument + "\t" +
                    row.interest.ToString() + "\t" +
                    マイナスInstrument更新_マイナスInstrument_通貨ぺア取引状況.買いSwap + "\t" +
                    マイナスInstrument更新_マイナスInstrument_通貨ぺア取引状況.売りSwap + "\t" +
                    マイナスInstrument更新_マイナスInstrument_通貨ぺア取引状況.保持ポジション + "\t" +
                    売買判定Month1 + "\t" +
                    売買判定Week1 + "\t" +
                    売買判定Day1 + "\r\n";
            }

            if (メール送信する)
            {
                Mail.SendMail("マイナスInstrument " + FormData.DemoReal.ToString() + " 口座No" +  FormData.口座No, マイナスInstrument更新_マイナスInstrument_tmp);    // メール通知しとく
            }
        }

        private static List<TradeData> 全ポジションをクローズする_openTrades;
        private static DeleteTradeResponse 全ポジションをクローズする_closedDetails;
        public static void 全ポジションをクローズする()
        {
            全ポジションをクローズする_openTrades = Rest.GetTradeListAsync(FormData.OandaAccountId);

            foreach (var tradeData in 全ポジションをクローズする_openTrades)
            {
                oder.InsertCloseHistory(3, null, null, tradeData);

                全ポジションをクローズする_closedDetails = Rest.DeleteTradeAsync(FormData.OandaAccountId, tradeData.id);

                oanda.InsertDeleteTradeResponse(全ポジションをクローズする_closedDetails);
            }
        }

        private static List<TradeData> Swapに反しているいるBSポジションは全てクローズする_openTrades;
        private static DeleteTradeResponse Swapに反しているいるBSポジションは全てクローズする_closedDetails;
        public static void Swapに反しているいるBSポジションは全てクローズする(通貨ぺア取引状況 通貨ぺア取引状況)
        {
            Swapに反しているいるBSポジションは全てクローズする_openTrades = Rest.GetTradeListAsync(FormData.OandaAccountId);

            foreach (var tradeData in Swapに反しているいるBSポジションは全てクローズする_openTrades)
            {
                if (oanda.GetBSポジションCnt(通貨ぺア取引状況, tradeData.id) < 1) continue;

                oder.InsertCloseHistory(4, null, 通貨ぺア取引状況, tradeData);

                Swapに反しているいるBSポジションは全てクローズする_closedDetails = Rest.DeleteTradeAsync(FormData.OandaAccountId, tradeData.id);

                oanda.InsertDeleteTradeResponse(Swapに反しているいるBSポジションは全てクローズする_closedDetails);
            }
        }

        private static IEnumerable<通貨ぺア取引状況> マイナスInterestが記録された通貨ペアで利益が出ているポジションはクローズ_通貨ぺア別取引状況;
        private static List<TradeData> マイナスInterestが記録された通貨ペアで利益が出ているポジションはクローズ_openTrades;
        private static DeleteTradeResponse マイナスInterestが記録された通貨ペアで利益が出ているポジションはクローズ_deleteTradeResponse;
        public static void マイナスInterestが記録された通貨ペアで利益が出ているポジションはクローズ()
        {
            マイナスInterestが記録された通貨ペアで利益が出ているポジションはクローズ_通貨ぺア別取引状況 = FormData.通貨ぺア別取引状況.Where(x => x.マイナスInstrument == true);

            if (マイナスInterestが記録された通貨ペアで利益が出ているポジションはクローズ_通貨ぺア別取引状況.Count() < 1) return;

            マイナスInterestが記録された通貨ペアで利益が出ているポジションはクローズ_openTrades = Rest.GetTradeListAsync(FormData.OandaAccountId);

            foreach (var 通貨ぺア取引状況 in マイナスInterestが記録された通貨ペアで利益が出ているポジションはクローズ_通貨ぺア別取引状況)
            {
                foreach (var tradeData in マイナスInterestが記録された通貨ペアで利益が出ているポジションはクローズ_openTrades)
                {
                    if (tradeData.instrument != 通貨ぺア取引状況.Instrument2) continue;

                    if (tradeData.side == "buy")
                    {
                        if (通貨ぺア取引状況.買いRate - tradeData.price < 通貨ぺア取引状況.差分リミット通常)
                            continue;
                    }
                    else
                    {
                        if (tradeData.price - 通貨ぺア取引状況.売りRate < 通貨ぺア取引状況.差分リミット通常)
                            continue;
                    }

                    oder.InsertCloseHistory(5, null, 通貨ぺア取引状況, tradeData);

                    マイナスInterestが記録された通貨ペアで利益が出ているポジションはクローズ_deleteTradeResponse = Rest.DeleteTradeAsync(FormData.OandaAccountId, tradeData.id);

                    oanda.InsertDeleteTradeResponse(マイナスInterestが記録された通貨ペアで利益が出ているポジションはクローズ_deleteTradeResponse);
                }
            }
        }

        private static List<TradeData> 利益が出ているポジションは全てクローズする_openTrades;
        private static 通貨ぺア取引状況 利益が出ているポジションは全てクローズする_通貨ぺア取引状況;
        private static DeleteTradeResponse 利益が出ているポジションは全てクローズする_closedDetails;
        public static void 利益が出ているポジションは全てクローズする()
        {
            利益が出ているポジションは全てクローズする_openTrades = Rest.GetTradeListAsync(FormData.OandaAccountId);

            foreach (var tradeData in 利益が出ているポジションは全てクローズする_openTrades)
            {
                利益が出ているポジションは全てクローズする_通貨ぺア取引状況 = FormData.通貨ぺア別取引状況.Where(x => x.Instrument2 == tradeData.instrument).First();

                if (tradeData.side == "buy")
                {
                    if (利益が出ているポジションは全てクローズする_通貨ぺア取引状況.買いRate - tradeData.price <
                        利益が出ているポジションは全てクローズする_通貨ぺア取引状況.差分リミット通常)
                        continue;
                }
                else
                {
                    if (tradeData.price - 利益が出ているポジションは全てクローズする_通貨ぺア取引状況.売りRate <
                        利益が出ているポジションは全てクローズする_通貨ぺア取引状況.差分リミット通常)
                        continue;
                }

                oder.InsertCloseHistory(6, null, null, tradeData);

                利益が出ているポジションは全てクローズする_closedDetails = Rest.DeleteTradeAsync(FormData.OandaAccountId, tradeData.id);

                oanda.InsertDeleteTradeResponse(利益が出ているポジションは全てクローズする_closedDetails);
            }
        }

        private static List<TradeData> 保持ポジションのリミット初期化_BS終了時_openTrades;
        public static void 保持ポジションのリミット初期化_BS終了時(通貨ぺア取引状況 通貨ぺア取引状況)
        {
            //注文共通.リミット更新_通常(通貨ぺア取引状況);

            保持ポジションのリミット初期化_BS終了時_openTrades = Rest.GetTradeListAsync(FormData.OandaAccountId);

            foreach (var tradeData in 保持ポジションのリミット初期化_BS終了時_openTrades)
            {
                if (通貨ぺア取引状況.OandaInstrument.instrument != tradeData.instrument) continue;

                リミット変更(tradeData, 通貨ぺア取引状況);
            }
        }

        private static List<TradeData> 保持ポジションのリミット初期化_openTrades;
        public static void 保持ポジションのリミット初期化(通貨ぺア取引状況 通貨ぺア取引状況)
        {
            保持ポジションのリミット初期化_openTrades = Rest.GetTradeListAsync(FormData.OandaAccountId);

            foreach (var tradeData in 保持ポジションのリミット初期化_openTrades)
            {
                if (通貨ぺア取引状況.OandaInstrument.instrument != tradeData.instrument) continue;

                リミット変更(tradeData, 通貨ぺア取引状況);
            }
        }

        public static void FXサーバ障害時のException(Exception ex)
        {
            FormData.ToolStripStsLbl = "Exceptionエラーが発生しました。 " + ex.Message;
            注文共通.Exception共通(ex, new List<Cエラー関連変数>());
        }

        public static double 余剰金の割合計算()
        {
            return (FormData.余剰証拠金 / FormData.取引証拠金) * 100;
        }

        private static List<Position> 保持ポジション更新_positions;
        private static 通貨ぺア取引状況 保持ポジション更新_通貨ぺア取引状況;
        public static void 保持ポジション更新(List<通貨ぺア取引状況> 通貨ぺア別取引状況)
        {
            foreach (var 通貨ぺア取引状況 in 通貨ぺア別取引状況.Where(x => x.保持ポジション != ""))
            {
                通貨ぺア取引状況.Unit数 = 0;
                通貨ぺア取引状況.OandaPositionSide = "";
                通貨ぺア取引状況.保持ポジション = "";
            }

            保持ポジション更新_positions = Rest.GetPositionsAsync(FormData.OandaAccountId);

            //_results.Verify(positions.Count > 0, "Positions retrieved");

            FormData.決算待ちポジション数 = 0;
            foreach (var position in 保持ポジション更新_positions)
            {
                保持ポジション更新_通貨ぺア取引状況 = 通貨ぺア別取引状況.Find(x => x.OandaInstrument.instrument == position.instrument);
                保持ポジション更新_通貨ぺア取引状況.Unit数 = position.units;
                保持ポジション更新_通貨ぺア取引状況.OandaPositionSide = position.side;
                保持ポジション更新_通貨ぺア取引状況.保持ポジション = 変換.GetStr売買Oanda(position.side);

                FormData.決算待ちポジション数 += position.units;
            }
        }

        private static List<TradeData> 特定通貨ペアのリミット幅を拡張する_openTrades;
        public static void 特定通貨ペアのリミット幅を拡張する(OrderData orderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            if (通貨ぺア取引状況.BS開始_リミット拡張はこの日時以降まで禁止 > orderData.now) return;

            //注文共通.リミット更新_BS(通貨ぺア取引状況);

            特定通貨ペアのリミット幅を拡張する_openTrades = Rest.GetTradeListAsync(FormData.OandaAccountId);

            foreach (var tradeData in 特定通貨ペアのリミット幅を拡張する_openTrades)
            {
                if (通貨ぺア取引状況.OandaInstrument.instrument != tradeData.instrument) continue;

                リミット変更(tradeData, 通貨ぺア取引状況);
            }

            // ポジション単位にリミットを拡張する禁止時間が違い、通貨ペア単位に期間を固定してしまうのは良くないが、
            // それでも1時間以内に何度も拡張するのは無い。
            通貨ぺア取引状況.BS開始_リミット拡張はこの日時以降まで禁止 = orderData.now.AddHours(1);
        }

        public static bool Chk近似Rateにポジション有り(通貨ぺア取引状況 通貨ぺア取引状況)
        {
            foreach (var trade in FormData.Oanda保持ポジション.Where(x => x.instrument == 通貨ぺア取引状況.OandaInstrument.instrument))
            {
                if (trade.side == "buy")
                {
                    if ((通貨ぺア取引状況.買いRate - 通貨ぺア取引状況.注文禁止Rate幅) < trade.price &&
                        trade.price < (通貨ぺア取引状況.買いRate + 通貨ぺア取引状況.注文禁止Rate幅))
                    {
                        return true; // ポジション有り
                    }
                }
                else
                {
                    if ((通貨ぺア取引状況.売りRate - 通貨ぺア取引状況.注文禁止Rate幅) < trade.price &&
                        trade.price < (通貨ぺア取引状況.売りRate + 通貨ぺア取引状況.注文禁止Rate幅))
                    {
                        return true; // ポジション有り
                    }
                }
            }

            return false; // ポジション無し
        }

        /// <returns>
        /// true：逆ポジション有り
        /// </returns>
		public static bool Chk逆ポジション(通貨ぺア取引状況 通貨ぺア取引状況)
        {
            if (string.IsNullOrWhiteSpace(通貨ぺア取引状況.OandaPositionSide))
            {
                return false;
            }

            if (変換.GetStr売買Oanda(通貨ぺア取引状況.OandaPositionSide) != 通貨ぺア取引状況.売買判定)
            {
                return true;
            }

            return false;
        }

        public static void リミット_ストップ取得(通貨ぺア取引状況 通貨ぺア取引状況)
        {
            // create new pending order
            if (通貨ぺア取引状況.売買 == true)
            {
                if (通貨ぺア取引状況.BS判定_今 == "B")
                {
                    通貨ぺア取引状況.ポジション追加_成行_リミット = 通貨ぺア取引状況.買いRate + (double)通貨ぺア取引状況.差分リミットBS;
                }
                else
                {
                    通貨ぺア取引状況.ポジション追加_成行_リミット = 通貨ぺア取引状況.買いRate + (double)通貨ぺア取引状況.差分リミット通常;
                }

                if (FormData.chkStoploss設定する)
                {
                    通貨ぺア取引状況.ポジション追加_成行_ストップ = 通貨ぺア取引状況.買いRate - (double)通貨ぺア取引状況.差分ストップ;
                }
            }
            else
            {
                if (通貨ぺア取引状況.BS判定_今 == "B")
                {
                    通貨ぺア取引状況.ポジション追加_成行_リミット = 通貨ぺア取引状況.売りRate - (double)通貨ぺア取引状況.差分リミットBS;
                }
                else
                {
                    通貨ぺア取引状況.ポジション追加_成行_リミット = 通貨ぺア取引状況.売りRate - (double)通貨ぺア取引状況.差分リミット通常;
                }

                if (FormData.chkStoploss設定する)
                {
                    通貨ぺア取引状況.ポジション追加_成行_ストップ = 通貨ぺア取引状況.売りRate + (double)通貨ぺア取引状況.差分ストップ;
                }
            }
        }


        private static Dictionary<string, string> ポジション追加_成行_request;
        private static PostOrderResponse ポジション追加_成行_response;
        public static long ポジション追加_成行(通貨ぺア取引状況 通貨ぺア取引状況)
        {
            // 2013-12-06T20:36:06Z
            //var expiry = DateTime.Now.AddMonths(1);
            // XmlConvert.ToDateTime and ToString can be used for going to/from RCF3339
            //string expiryString = XmlConvert.ToString(expiry, XmlDateTimeSerializationMode.Utc);

            try
            {
                // create new pending order
                if (通貨ぺア取引状況.売買 == true)
                {
                    if (FormData.chkStoploss設定する)
                    {
                        ポジション追加_成行_request = new Dictionary<string, string>
                        {
                            {"instrument", 通貨ぺア取引状況.OandaInstrument.instrument},
                            {"units", 通貨ぺア取引状況.注文単位.ToString()},
                            {"side", "buy"},
					        //{"type", "marketIfTouched"},
					        //{"price", 通貨ぺア取引状況.買いRate.ToString()},
                            {"type", "market"},
                            {"stopLoss", ((double)通貨ぺア取引状況.ポジション追加_成行_ストップ).ToString("F" + 通貨ぺア取引状況.Rateの少数点桁数.ToString())},
                            {"takeProfit", ((double)通貨ぺア取引状況.ポジション追加_成行_リミット).ToString("F" + 通貨ぺア取引状況.Rateの少数点桁数.ToString())},
                            {"expiry", XmlConvert.ToString(DateTime.Now.AddMinutes(3), XmlDateTimeSerializationMode.Utc)}
                        };
                    }
                    else
                    {
                        ポジション追加_成行_request = new Dictionary<string, string>
                        {
                            {"instrument", 通貨ぺア取引状況.OandaInstrument.instrument},
                            {"units", 通貨ぺア取引状況.注文単位.ToString()},
                            {"side", "buy"},
					        //{"type", "marketIfTouched"},
					        //{"price", 通貨ぺア取引状況.買いRate.ToString()},
                            {"type", "market"},
                            {"takeProfit", ((double)通貨ぺア取引状況.ポジション追加_成行_リミット).ToString("F" + 通貨ぺア取引状況.Rateの少数点桁数.ToString())},
                            {"expiry", XmlConvert.ToString(DateTime.Now.AddMinutes(3), XmlDateTimeSerializationMode.Utc)}
                        };
                    }
                }
                else
                {
                    if (FormData.chkStoploss設定する)
                    {
                        ポジション追加_成行_request = new Dictionary<string, string>
                        {
                            {"instrument", 通貨ぺア取引状況.OandaInstrument.instrument},
                            {"units", 通貨ぺア取引状況.注文単位.ToString()},
                            {"side", "sell"},
					        //{"type", "marketIfTouched"},
					        //{"price", 通貨ぺア取引状況.売りRate.ToString()},
                            {"type", "market"},
                            {"stopLoss", ((double)通貨ぺア取引状況.ポジション追加_成行_ストップ).ToString("F" + 通貨ぺア取引状況.Rateの少数点桁数.ToString())},
                            {"takeProfit", ((double)通貨ぺア取引状況.ポジション追加_成行_リミット).ToString("F" + 通貨ぺア取引状況.Rateの少数点桁数.ToString())},
                            {"expiry", XmlConvert.ToString(DateTime.Now.AddMinutes(3), XmlDateTimeSerializationMode.Utc)}
                        };
                    }
                    else
                    {
                        ポジション追加_成行_request = new Dictionary<string, string>
                        {
                            {"instrument", 通貨ぺア取引状況.OandaInstrument.instrument},
                            {"units", 通貨ぺア取引状況.注文単位.ToString()},
                            {"side", "sell"},
					        //{"type", "marketIfTouched"},
					        //{"price", 通貨ぺア取引状況.売りRate.ToString()},
                            {"type", "market"},
                            {"takeProfit", ((double)通貨ぺア取引状況.ポジション追加_成行_リミット).ToString("F" + 通貨ぺア取引状況.Rateの少数点桁数.ToString())},
                            {"expiry", XmlConvert.ToString(DateTime.Now.AddMinutes(3), XmlDateTimeSerializationMode.Utc)}
                        };
                    }
                }

                ポジション追加_成行_response = Rest.PostOrderAsync(FormData.OandaAccountId, ポジション追加_成行_request);

                oanda.InsertOrderResponse(通貨ぺア取引状況, ポジション追加_成行_response);

                return ポジション追加_成行_response.tradeOpened.id;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                //ログ.ログ書き出し("expiry : " + expiry);
                //ログ.ログ書き出し("expiryString : " + expiryString);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("通貨ぺア取引状況.売買 : " + 通貨ぺア取引状況.売買);
                ログ.ログ書き出し("通貨ぺア取引状況.OandaInstrument.instrument : " + 通貨ぺア取引状況.OandaInstrument.instrument);
                ログ.ログ書き出し("通貨ぺア取引状況.注文単位 : " + 通貨ぺア取引状況.注文単位.ToString());
                ログ.ログ書き出し("通貨ぺア取引状況.ポジション追加_成行_リミット : " + ((double)通貨ぺア取引状況.ポジション追加_成行_リミット).ToString("F" + 通貨ぺア取引状況.Rateの少数点桁数.ToString()));
                ログ.ログ書き出し("通貨ぺア取引状況.ポジション追加_成行_ストップ : " + ((double)通貨ぺア取引状況.ポジション追加_成行_ストップ).ToString("F" + 通貨ぺア取引状況.Rateの少数点桁数.ToString()));
                ログ.ログ書き出し("FormData.OandaAccountId : " + FormData.OandaAccountId);
                throw;
            }
        }

        private static List<Order> _3分以上経っている注文は削除_orders;
        public static void _3分以上経っている注文は削除(out int count)
        {
            _3分以上経っている注文は削除_orders = Rest.GetOrderListAsync(FormData.OandaAccountId);

            count = _3分以上経っている注文は削除_orders.Count();

            foreach (var order in _3分以上経っている注文は削除_orders)
            {
                if (DateTime.Parse(order.time) < DateTime.Now.AddMinutes(-3))
                {
                    Rest.DeleteOrderAsync(FormData.OandaAccountId, order.id);
                }
            }
        }

        private static double リミット変更_リミット;
        private static Dictionary<string, string> リミット変更_request;
        private static TradeData リミット変更_modifiedDetails;
        private static void リミット変更(TradeData TradeData, 通貨ぺア取引状況 通貨ぺア取引状況)
        {
            // get details for a trade
            //var tradeDetails = Rest.GetTradeDetailsAsync(FormData.OandaAccountId, TradeID);
            //_results.Verify(tradeDetails.id > 0 && tradeDetails.price > 0 && tradeDetails.units != 0, "Trade details retrieved");

            if (TradeData.side == "buy")
            {
                if (通貨ぺア取引状況.BS判定_前 == "" && 通貨ぺア取引状況.BS判定_今 == "B")
                {
                    // BS開始。リミットを拡張。
                    リミット変更_リミット = (double)(TradeData.price + 通貨ぺア取引状況.差分リミットBS);

                    if (TradeData.takeProfit > リミット変更_リミット)
                    {
                        // リミット変更をしてもそのリミットに達する可能性は無い。
                        return;
                    }
                }
                else
                {
                    // 通常。リミットを初期化。
                    リミット変更_リミット = (double)(TradeData.price + 通貨ぺア取引状況.差分リミット通常);

                    if (通貨ぺア取引状況.買いRate < リミット変更_リミット - 通貨ぺア取引状況.注文禁止Rate幅_基準値)
                    {
                        // リミット変更をしてもそのリミットに達する可能性は無い。
                        return;
                    }
                }
            }
            else if (TradeData.side == "sell")
            {
                if (通貨ぺア取引状況.BS判定_前 == "" && 通貨ぺア取引状況.BS判定_今 == "B")
                {
                    // BS開始。リミットを拡張。
                    リミット変更_リミット = (double)(TradeData.price - 通貨ぺア取引状況.差分リミットBS);

                    if (TradeData.takeProfit < リミット変更_リミット)
                    {
                        // リミット変更をしてもそのリミットに達する可能性は無い。
                        return;
                    }
                }
                else
                {
                    // 通常。リミットを初期化。
                    リミット変更_リミット = (double)(TradeData.price - 通貨ぺア取引状況.差分リミット通常);

                    if (通貨ぺア取引状況.売りRate > リミット変更_リミット + 通貨ぺア取引状況.注文禁止Rate幅_基準値)
                    {
                        // リミット変更をしてもそのリミットに達する可能性は無い。
                        return;
                    }
                }
            }
            else
            {
                // ここを通ったらバグ
                throw new Exception("リミット変更「side」がnull");
            }

            oder.Insertリミット変更History(TradeData, リミット変更_リミット.ToString("F" + 通貨ぺア取引状況.Rateの少数点桁数.ToString()), 通貨ぺア取引状況);

            // Modify an open trade
            リミット変更_request = new Dictionary<string, string>
            {
				//{"stopLoss", "0.4"}
				//{"highLimit", リミット}
				{"takeProfit", リミット変更_リミット.ToString("F" + 通貨ぺア取引状況.Rateの少数点桁数.ToString())},
                {"expiry", XmlConvert.ToString(DateTime.Now.AddMinutes(3), XmlDateTimeSerializationMode.Utc)}
            };

            リミット変更_modifiedDetails = Rest.PatchTradeAsync(FormData.OandaAccountId, TradeData.id, リミット変更_request);

            oanda.InsertTrade_リミット変更(リミット変更_modifiedDetails, TradeData.id);
        }


        private static List<Order> 注文を全て削除_orders;
        public static void 注文を全て削除()
        {
            注文を全て削除_orders = Rest.GetOrderListAsync(FormData.OandaAccountId);

            foreach (var order in 注文を全て削除_orders)
            {
                Rest.DeleteOrderAsync(FormData.OandaAccountId, order.id);
            }
        }


        public static void DB記録_Account()
        {
            oanda.InsertAccount(アカウント状態更新());
        }

        private static 通貨ぺア取引状況 DB記録_Trade_ポジション数更新_注文禁止Rate幅更新_通貨ぺア取引状況;
        public static void DB記録_Trade_ポジション数更新_注文禁止Rate幅更新()
        {
            FormData.Oanda保持ポジション = Rest.GetTradeListAsync(FormData.OandaAccountId);

            // 初期化
            foreach (var 通貨ぺア取引状況 in FormData.通貨ぺア別取引状況)
            {
                通貨ぺア取引状況.ポジション数 = 0;
                通貨ぺア取引状況.注文禁止Rate幅 = 通貨ぺア取引状況.注文禁止Rate幅_基準値;
            }

            foreach (var openTrade in FormData.Oanda保持ポジション)
            {
                // ポジション数更新
                DB記録_Trade_ポジション数更新_注文禁止Rate幅更新_通貨ぺア取引状況 = FormData.通貨ぺア別取引状況.Where(x => x.Instrument2 == openTrade.instrument).First();
                DB記録_Trade_ポジション数更新_注文禁止Rate幅更新_通貨ぺア取引状況.ポジション数++;
                DB記録_Trade_ポジション数更新_注文禁止Rate幅更新_通貨ぺア取引状況.注文禁止Rate幅 = 
                    DB記録_Trade_ポジション数更新_注文禁止Rate幅更新_通貨ぺア取引状況.注文禁止Rate幅_基準値 * DB記録_Trade_ポジション数更新_注文禁止Rate幅更新_通貨ぺア取引状況.ポジション数;

                if ((int)oanda.Cnt_Trades_TradeID(openTrade.id) > 0) continue;

                //var openTradesDetail = Rest.GetTradeDetailsAsync(FormData.OandaAccountId, openTrade.id);

                oanda.InsertTrade(openTrade);
            }
        }

        //public static void DB記録_ClosedTrade()
        //{
        //    //var closePositionResponse = Rest.DeletePositionAsync(_accountId, TestInstrument);

        //    //foreach (var openTrade in closePositionResponse)
        //    //{
        //    //	if ((int)oanda.Cnt_Trades_TradeID(cn, openTrade.id) > 0)
        //    //		continue;

        //    //	oanda.InsertTrade(cn, openTrade);
        //    //}
        //}

        private static List<OandaTransaction> DB記録_Transaction_result;
        private static DateTime DB記録_Transaction_OandaTransaction日時;
        private static DateTime DB記録_Transaction_今回最も新しかったもの = DateTime.MinValue;
        public static void DB記録_Transaction()
        {
            DB記録_Transaction_今回最も新しかったもの = DateTime.MinValue;
            FormData.OandaTransactionLastId = Rest.GetTransactionListAsync(FormData.OandaAccountId, FormData.OandaTransactionLastId, out DB記録_Transaction_result);

            foreach (var transaction in DB記録_Transaction_result)
            {
                DB記録_Transaction_OandaTransaction日時 = DateTime.Parse(transaction.time);

                if (DB記録_Transaction_OandaTransaction日時 < FormData.OandaTransaction最終日時) continue;

                if (DB.oanda.GetTransactionCnt(FormData.口座No, transaction) > 0) continue;

                oanda.InsertTransaction(FormData.口座No, transaction);

                if (transaction.type == "TRADE_CLOSE" || transaction.type == "TAKE_PROFIT_FILLED")
                {
                    FormData.通貨ぺア別取引状況.Where(x => x.Instrument2 == transaction.instrument).First().ポジションClose最終日時 = DB記録_Transaction_OandaTransaction日時;
                }

                if (DB記録_Transaction_今回最も新しかったもの < DB記録_Transaction_OandaTransaction日時)
                {
                    DB記録_Transaction_今回最も新しかったもの = DB記録_Transaction_OandaTransaction日時;
                }
            }

            FormData.OandaTransaction最終日時 = DB記録_Transaction_今回最も新しかったもの;
        }


        private static List<OandaTransaction> 直近のポジションClose最終日時を再確認_result;
        private static DateTime 直近のポジションClose最終日時を再確認_time;
        public static bool 直近のポジションClose最終日時を再確認(string Instrument2, DateTime _3時間前, DateTime 当日StartDate)
        {
            FormData.OandaTransactionLastId = Rest.GetTransactionListAsync(FormData.OandaAccountId, FormData.OandaTransactionLastId, out 直近のポジションClose最終日時を再確認_result);

            foreach (var transaction in 直近のポジションClose最終日時を再確認_result)
            {
                if (transaction.instrument != Instrument2) continue;

                if (transaction.type != "TRADE_CLOSE" && transaction.type != "TAKE_PROFIT_FILLED") continue;

                直近のポジションClose最終日時を再確認_time = DateTime.Parse(transaction.time);
                if (直近のポジションClose最終日時を再確認_time > _3時間前 || 直近のポジションClose最終日時を再確認_time > 当日StartDate)
                {
                    // 3時間以内、もしくは当日ににClose有り
                    return true;
                }
            }

            return false;
        }

        #region privateメソッド

        public static void ログイン()
        {
            // OANDAはアカウントのセットのみ。
            CredentialsSt.SetCredentials(FormData.OandaEnvironment, FormData.OandaAccessToken, FormData.OandaAccountId);

            FormData.ログイン表示 = "ログイン中";
        }

        private static void Logout()
        {
            // OANDAでは必要無い
        }

        public static void OrderData更新()
        {
            FormData.OrderData = new OrderData();
            FormData.OrderData.now = DateTime.Now;
            //FormData.OrderData.FXCM_Hour24前 = FormData.OrderData.now.AddHours(-24);
            注文共通.StartTime_EndTime取得(FormData.OrderData);
            FormData.Rate更新最終日時 = FormData.OrderData.now;

            /*
            System.IO.File.AppendAllText(@"C:\AutoFX\FX.txt",
                "FormData.OrderData.now : " + FormData.OrderData.now + "\r\n" +
                "OrderData.StartMonth1 : " + FormData.OrderData.StartMonth1 + "\r\n" +
                "OrderData.EndMonth1 : " + FormData.OrderData.EndMonth1 + "\r\n" +
                "OrderData.StartWeek1 : " + FormData.OrderData.StartWeek1 + "\r\n" +
                "OrderData.EndWeek1 : " + FormData.OrderData.EndWeek1 + "\r\n" +
                "OrderData.StartDay1 : " + FormData.OrderData.StartDay1 + "\r\n" +
                "OrderData.EndDay1 : " + FormData.OrderData.EndDay1 + "\r\n" +
                "OrderData.StartHour1 : " + FormData.OrderData.StartHour1 + "\r\n" +
                "OrderData.EndHour1 : " + FormData.OrderData.EndHour1 + "\r\n" +
                "OrderData.StartMin15 : " + FormData.OrderData.StartMin15 + "\r\n" +
                "OrderData.EndMin15 : " + FormData.OrderData.EndMin15 + "\r\n" +
                "OrderData.StartMin5 : " + FormData.OrderData.StartMin5 + "\r\n" +
                "OrderData.EndMin5 : " + FormData.OrderData.EndMin5 + "\r\n" +
                "OrderData.StartMin1 : " + FormData.OrderData.StartMin1 + "\r\n" +
                "OrderData.EndMin1 : " + FormData.OrderData.EndMin1 + "\r\n\r\n");
            */
        }

        public static void Rate取得WMA計算()
        {
            OrderData更新();

            通貨ペアRate更新(FormData.OrderData, FormData.通貨ぺア別取引状況);

            注文共通.WMA計算ALL(FormData.OrderData);
        }

        public static void Order_Ver6_WMA_BS_順張り()
        {
            OrderData更新();

            if (FormData.chk15mデータ生成以降の処理をスキップ == true)
            {
                BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, null, "15mデータ生成以降の処理をしない", FormData.OrderData.now);
                return;
            }

            //通貨ペアRate更新_Rate取得Only(FormData.OrderData, FormData.通貨ぺア別取引状況);

            foreach (var 通貨ぺア取引状況 in FormData.通貨ぺア別取引状況)
            {
                try
                {
                    hstr.Get最新Rate(通貨ぺア取引状況);

                    if (注文共通.Chk注文設定_Chk注文(FormData.OrderData, 通貨ぺア取引状況) == false)
                    {
                        BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, "Order判定しない", FormData.OrderData.now);
                        continue;
                    }

                    oder.GetWMA_Month1(FormData.OrderData, 通貨ぺア取引状況);
                    oder.GetWMA_Week1(FormData.OrderData, 通貨ぺア取引状況);
                    oder.GetWMA_Day1(FormData.OrderData, 通貨ぺア取引状況);
                    oder.GetWMA_Hour1(FormData.OrderData, 通貨ぺア取引状況);
                    oder.GetWMA_Min15(FormData.OrderData, 通貨ぺア取引状況);
                    oder.GetWMA_Min5(FormData.OrderData, 通貨ぺア取引状況);
                    oder.GetWMA_Min1(FormData.OrderData, 通貨ぺア取引状況);

                    BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, 通貨ぺア取引状況.通貨ペアNo, "Order判定開始", FormData.OrderData.now);

                    if (FormData.chkスワップロジックで注文する)
                    {
                        if (注文共通.C_注文_Order_Ver6_BS(FormData.OrderData, 通貨ぺア取引状況, "BS "))
                        {
                            if (通貨ぺア取引状況.BS判定_前 == "" && 通貨ぺア取引状況.BS判定_今 == "B")
                            {
                                特定通貨ペアのリミット幅を拡張する(FormData.OrderData, 通貨ぺア取引状況);
                            }
                        }
                        else
                        {
                            注文共通.C_注文_Order_Ver6_Swap(FormData.OrderData, 通貨ぺア取引状況, "Swap ");
                        }
                    }

                    if (FormData.chk反転ロジックで注文する)
                    {
                        通貨ぺア取引状況.BS開始 = false;
                        注文共通.C_注文_Order_Ver7_反転(FormData.OrderData, 通貨ぺア取引状況, "反転 ");
                    }
                }
                catch (Exception ex)
                {
                    List<Cエラー関連変数> Cエラー関連変数List = new List<Cエラー関連変数>();
                    Cエラー関連変数List.Add(new Cエラー関連変数() { 変数名 = "Order_Ver5_通貨ペアNo", 値 = 通貨ぺア取引状況.通貨ペアNo.ToString() });
                    注文共通.Exception共通(ex, Cエラー関連変数List);
                }
            }
        }


        private static List<OandaInstrument> OoandaInstrument取得_OandaInstruments;
        private static OandaInstrument OoandaInstrument取得_oandaInstrument;
        public static void OoandaInstrument取得()
        {
            try
            {
                OoandaInstrument取得_OandaInstruments = Rest.GetInstrumentsAsync(FormData.OandaAccountId);
            }
            catch (Exception ex)
            {
                Mail.SendMailAndLogErr("OoandaInstrument取得 失敗", ex);

                // Rate取得を継続するために List<OandaInstrument> を自力で作る
                FormData.chk15mデータ生成以降の処理をスキップ = true;
                OoandaInstrument取得_OandaInstruments = new List<OandaInstrument>();
                foreach (var 通貨ぺア取引状況 in FormData.通貨ぺア別取引状況)
                {
                    OoandaInstrument取得_OandaInstruments.Add(new OandaInstrument()
                    {
                        displayName = 通貨ぺア取引状況.Instrument,
                        instrument = 通貨ぺア取引状況.Instrument.Replace('/', '_'),
                    });
                }

                FormData.chkInsturment取得に失敗したためRate取得Onlyに移行 = true;
            }

            foreach (var 通貨ぺア取引状況 in FormData.通貨ぺア別取引状況)
            {
                //System.Diagnostics.Debug.WriteLine(通貨ぺア取引状況.Instrument);
                OoandaInstrument取得_oandaInstrument = OoandaInstrument取得_OandaInstruments.Find(x => x.displayName == 通貨ぺア取引状況.Instrument);

                if (OoandaInstrument取得_oandaInstrument == null)
                {
                    // ここを通ったらバグ
                    throw new Exception("通貨ぺア別取引状況の配列と、OoandaInstrumentsが一致していない");
                }
                else
                {
                    通貨ぺア取引状況.OandaInstrument = OoandaInstrument取得_oandaInstrument;
                }
            }
        }

        private static List<Price> 通貨ペアRate更新_result;
        private static 通貨ぺア取引状況 通貨ペアRate更新_通貨ぺア取引状況;
        public static void 通貨ペアRate更新(OrderData OrderData, List<通貨ぺア取引状況> 通貨ぺア別取引状況_データ生成対象)
        {
            BulkCopyRateSec.RateSecInitialize();

            通貨ペアRate更新_result = Rest.GetRatesAsync(通貨ぺア別取引状況_データ生成対象, null);

            foreach (var price in 通貨ペアRate更新_result)
            {
                if (string.IsNullOrEmpty(price.instrument) || price.bid < 0.00001 || price.ask < 0.00001)
                {
                    // FXCMのバグでRateが0以下になり、シグマ計算結果が狂う事件があったので、それはここで回避。
                    BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), "Order対象外(Rate取得異常) " + price.instrument, null, null, OrderData.now);
                    continue;
                }

                通貨ペアRate更新_通貨ぺア取引状況 = 通貨ぺア別取引状況_データ生成対象.Find(x => x.OandaInstrument.instrument == price.instrument);

                通貨ペアRate更新_通貨ぺア取引状況.買いRate = price.bid;
                通貨ペアRate更新_通貨ぺア取引状況.売りRate = price.ask;

                BulkCopyRateSec.InsertRateSec(OrderData, 通貨ペアRate更新_通貨ぺア取引状況);
                //rate.InsertRateHistoryIncludeSwap(cn, 通貨ぺア取引状況);
            }

            BulkCopyRateSec.RateSecFlush();
        }

        private static List<Price> 通貨ペアRate更新_Rate取得Only_result;
        private static 通貨ぺア取引状況 通貨ペアRate更新_Rate取得Only_通貨ぺア取引状況;
        public static void 通貨ペアRate更新_Rate取得Only(OrderData OrderData, List<通貨ぺア取引状況> 通貨ぺア別取引状況_データ生成対象)
        {
            通貨ペアRate更新_Rate取得Only_result = Rest.GetRatesAsync(通貨ぺア別取引状況_データ生成対象, null);

            foreach (var price in 通貨ペアRate更新_Rate取得Only_result)
            {
                if (string.IsNullOrEmpty(price.instrument) || price.bid < 0.00001 || price.ask < 0.00001)
                {
                    // FXCMのバグでRateが0以下になり、シグマ計算結果が狂う事件があったので、それはここで回避。
                    BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), "Order対象外(Rate取得異常) " + price.instrument, null, null, OrderData.now);
                    continue;
                }

                通貨ペアRate更新_Rate取得Only_通貨ぺア取引状況 = 通貨ぺア別取引状況_データ生成対象.Find(x => x.OandaInstrument.instrument == price.instrument);

                通貨ペアRate更新_Rate取得Only_通貨ぺア取引状況.買いRate = price.bid;
                通貨ペアRate更新_Rate取得Only_通貨ぺア取引状況.売りRate = price.ask;
            }
        }

        public static void 通貨ペアSwap更新()
        {
            foreach (var 通貨ぺア取引状況 in FormData.通貨ぺア別取引状況)
            {
                swap.GetSwap_手動登録Swap(通貨ぺア取引状況);
            }
        }


        private static DeleteTradeResponse ポジションをクローズする_closedDetails;
        private static void ポジションをクローズする(long TradeID, out long OrderID)
        {
            ポジションをクローズする_closedDetails = Rest.DeleteTradeAsync(FormData.OandaAccountId, TradeID);

            oanda.InsertDeleteTradeResponse(ポジションをクローズする_closedDetails);

            OrderID = ポジションをクローズする_closedDetails.id;
        }

        public static void ClosedTrades_余剰金を確保する()
        {
            double 余剰金の割合 = 0;

            DateTime Time;
            double 差益 = 0;
            string sTradeID = "";
            int iAmount = 0;
            double dRate = 0;
            string sQuoteID = "";
            long CloseOrderID;

            temp.DeleteAll_SortCloseTradeTmp();

            var openTrades2 = Rest.GetTradeListAsync(FormData.OandaAccountId);
            //_results.Verify(openTrades2.Count > 0 && openTrades2[0].id > 0, "Trades list retrieved");

            foreach (var tradeData2 in openTrades2)
            {
                余剰金の割合 = 余剰金の割合計算();

                if (余剰金の割合 > FormData.余剰金割合の限界点)
                    return;

                if (FormData.chk余剰金確保の自動ポジションCloseはMSG確認する == true)
                {
                    if (MessageBox.Show("[ClosedTrades_余剰金を確保する]を本当に実行しますか？ \r\n実行すると、極端な損失が発生します。", "確認（超重要）",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
                        return;
                }

                temp.DeleteAll_SortCloseTradeTmp();

                var openTrades = Rest.GetTradeListAsync(FormData.OandaAccountId);
                //_results.Verify(openTrades.Count > 0 && openTrades[0].id > 0, "Trades list retrieved");

                foreach (var tradeData in openTrades)
                {
                    Time = DateTime.Parse(tradeData.time);
                    差益 = tradeData.takeProfit;
                    iAmount = tradeData.units;
                    dRate = tradeData.price;
                    sTradeID = tradeData.id.ToString();
                    sQuoteID = "";

                    temp.InsertSortCloseTradeTmp(Time, sTradeID, 差益, iAmount, dRate, sQuoteID);
                }

                temp.FillBy差益_SortCloseTradeTmp(sTradeID, iAmount, dRate, sQuoteID);

                oder.InsertCloseHistory(7, null, null, tradeData2);

                // 差益がマイナスなTrade、Top1のみクローズ
                ポジションをクローズする(long.Parse(sTradeID), out CloseOrderID);

                System.Threading.Thread.Sleep(1000);
            }
        }

        private static OandaAccount アカウント状態更新_oandaAccount;
        public static OandaAccount アカウント状態更新()
        {
            アカウント状態更新_oandaAccount = Rest.GetAccountDetailsAsync(FormData.OandaAccountId);

            //FormData.txt決算待ちポジション数_Text = 現在保有しているポジション数();
            //FormData.txt決算待ちポジション数 = int.Parse(oandaAccount.openTrades);
            FormData.取引証拠金 = double.Parse(アカウント状態更新_oandaAccount.balance);
            FormData.維持証拠金 = double.Parse(アカウント状態更新_oandaAccount.marginUsed);
            FormData.余剰証拠金 = double.Parse(アカウント状態更新_oandaAccount.marginAvail);

            FormData.当日約定数 = oanda.Cnt約定数(注文共通.Get当日の開始日時(DateTime.Now));
            FormData.当日約定金額 = oanda.GetSUM差益(注文共通.Get当日の開始日時(DateTime.Now), DateTime.Now);

            return アカウント状態更新_oandaAccount;
        }

        #endregion

    }
}
