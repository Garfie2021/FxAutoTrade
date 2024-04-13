using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using 定数;
using 共通Data;
using SystemSetting;
using Common;
using DB;
using OANDAv1;


namespace Maintenance_Form
{
    public partial class Fテスト : Form
    {
        private SqlConnection Cn;
        private int 口座;
        private string コマンドライン;

        private string テスト結果 = "";


        public Fテスト(SqlConnection cn, int 口座, string コマンドライン)
        {
            InitializeComponent();

            Cn = cn;
            this.口座 = 口座;
            this.コマンドライン = コマンドライン;
        }


        #region イベントハンドラ

        private void Fテスト_Load(object sender, EventArgs e)
        {
            txtDB接続先.Text = Cn.ConnectionString;
            txt口座.Text = this.口座.ToString();
            txtコマンドライン.Text = this.コマンドライン;

            //using (SqlConnection cn = new SqlConnection())
            //{
            //    cn.ConnectionString = FormData.DBConnectionString;
            //    cn.Open();

            //    OANDAv1.OANDAv1.ログイン_Order開始(cn);
            //}


            // テスト向け初期化
            //OANDAv1.OANDAv1.ログイン();
            //OANDAv1.OANDAv1.OoandaInstrument取得();
        }

        #region Start

        private void btnログイン_Click(object sender, EventArgs e)
        {
            try
            {
                OANDAv1.OANDAv1.ログイン_Order開始();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnOoandaInstrument取得_Click(object sender, EventArgs e)
        {
            try
            {
                OANDAv1.OANDAv1.OoandaInstrument取得();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        #endregion


        #region Tick_4sec

        private void btnTick_4sec_Click(object sender, EventArgs e)
        {
            try
            {
                FormData.chk15mデータ生成以降の処理をスキップ = false;

                FormData.TradeEvent.Tick_4sec();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnアカウント状態更新_Click(object sender, EventArgs e)
        {
            try
            {
                OANDAv1.OANDAv1.アカウント状態更新();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn保持ポジション更新_Click(object sender, EventArgs e)
        {
            try
            {
                OANDAv1.OANDAv1.保持ポジション更新(FormData.通貨ぺア別取引状況);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn余剰金調整_Click(object sender, EventArgs e)
        {
            try
            {
                注文共通.余剰金調整();

                FormData.余剰金の割合 = OANDAv1.OANDAv1.余剰金の割合計算();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn取引停止中_Click(object sender, EventArgs e)
        {
            try
            {
                注文共通.取引停止中("取引停止中（IsNaN(余剰金の割合)）");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnClosedTrades_余剰金を確保する_Click(object sender, EventArgs e)
        {
            try
            {
                OANDAv1.OANDAv1.ClosedTrades_余剰金を確保する();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnOrder_Ver6_WMA_BS_順張り_Click(object sender, EventArgs e)
        {
            try
            {
                OANDAv1.OANDAv1.Order_Ver6_WMA_BS_順張り();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnC_注文_Order_Ver5_WMA_BS_順張り_Click(object sender, EventArgs e)
        {
            try
            {
                var 通貨ぺア別取引状況_データ生成対象 = FormData.通貨ぺア別取引状況.Where(x => x.Chkデータ生成 == true).ToList();
                OANDAv1.OANDAv1.通貨ペアRate更新(FormData.OrderData, 通貨ぺア別取引状況_データ生成対象);
                注文共通.WMA計算ALL(FormData.OrderData);

                foreach (var 通貨ぺア取引状況 in 通貨ぺア別取引状況_データ生成対象.Where(x => x.Chk注文 == true).ToList())
                {
                    try
                    {
                        //注文共通.C_注文_Order_Ver5_WMA_BS_順張り(cn, FormData.OrderData, 通貨ぺア取引状況);
                    }
                    catch (Exception ex)
                    {
                        List<Cエラー関連変数> Cエラー関連変数List = new List<Cエラー関連変数>();
                        Cエラー関連変数List.Add(new Cエラー関連変数() { 変数名 = "Order_Ver5_通貨ペアNo", 値 = 通貨ぺア取引状況.通貨ペアNo.ToString() });
                        注文共通.Exception共通(ex, Cエラー関連変数List);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn通貨ペアRate更新_Click(object sender, EventArgs e)
        {
            try
            {
                var 通貨ぺア別取引状況_データ生成対象 = FormData.通貨ぺア別取引状況.Where(x => x.Chkデータ生成 == true).ToList();
                OANDAv1.OANDAv1.通貨ペアRate更新(FormData.OrderData, 通貨ぺア別取引状況_データ生成対象);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn特定通貨ペアのリミット幅を拡張する_Click(object sender, EventArgs e)
        {
            try
            {
                var 通貨ぺア別取引状況_データ生成対象 = FormData.通貨ぺア別取引状況.Where(x => x.Chkデータ生成 == true).ToList();

                foreach (var 通貨ぺア取引状況 in 通貨ぺア別取引状況_データ生成対象.Where(x => x.Chk注文 == true).ToList())
                {
                    try
                    {
                        //OANDAv1.OANDAv1.特定通貨ペアのリミット幅を拡張する(通貨ぺア取引状況);  // 現在Rateの50%分、リミットを拡張する。
                    }
                    catch (Exception ex)
                    {
                        string str = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnInsertOrderHistory2_Click(object sender, EventArgs e)
        {
            try
            {
                FormData.OrderData = new OrderData();
                FormData.OrderData.now = DateTime.Now;
                注文共通.StartTime_EndTime取得(FormData.OrderData);
                //FormData.OrderData.FXCM_Hour24前 = FormData.OrderData.now.AddHours(-24 + (FX定数.FXOrder2Go時間補正 * -1));

                foreach (var 通貨ぺア取引状況 in FormData.通貨ぺア別取引状況)
                {
                    oder.InsertOrderHistory2(FormData.OrderData, 通貨ぺア取引状況);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnInsertOrderResponse_Click(object sender, EventArgs e)
        {
            try
            {
                通貨ぺア取引状況 通貨ぺア取引状況 = new 通貨ぺア取引状況()
                {
                    通貨ペアNo = 1,
                    BS開始 = false
                };

                PostOrderResponse response = new PostOrderResponse()
                {
                    instrument = "AUD_CAD",
                    price = 0.99999,
                    time = DateTime.Now.ToString(),
                    orderOpened = new Order() { id = 1000000 }
                };

                oanda.InsertOrderResponse(通貨ぺア取引状況, response);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnポジション追加_成行_Click(object sender, EventArgs e)
        {
            try
            {
                FormData.OrderData = new OrderData();
                FormData.OrderData.now = DateTime.Now;
                注文共通.StartTime_EndTime取得(FormData.OrderData);
                //FormData.OrderData.FXCM_Hour24前 = FormData.OrderData.now.AddHours(-24 + (FX定数.FXOrder2Go時間補正 * -1));

                OANDAv1.OANDAv1.通貨ペアRate更新(FormData.OrderData, FormData.通貨ぺア別取引状況);

                foreach (var 通貨ぺア取引状況 in FormData.通貨ぺア別取引状況)
                {
                    try
                    {
                        if (通貨ぺア取引状況.Instrument != "EUR/AUD") continue;

                        long? TradeData_id = FormData.TradeApi.ポジション追加_成行(通貨ぺア取引状況);
                    }
                    catch (Exception ex)
                    {
                        List<Cエラー関連変数> Cエラー関連変数List = new List<Cエラー関連変数>();
                        Cエラー関連変数List.Add(new Cエラー関連変数() { 変数名 = "Order_Ver5_通貨ペアNo", 値 = 通貨ぺア取引状況.通貨ペアNo.ToString() });
                        注文共通.Exception共通(ex, Cエラー関連変数List);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnC_注文_Order_Ver6_通常_Click(object sender, EventArgs e)
        {
            try
            {
                FormData.OrderData = new OrderData();
                FormData.OrderData.now = DateTime.Parse("2016-12-29 19:52:41");
                注文共通.StartTime_EndTime取得(FormData.OrderData);
                //FormData.OrderData.FXCM_Hour24前 = FormData.OrderData.now.AddHours(-24 + (FX定数.FXOrder2Go時間補正 * -1));

                通貨ぺア取引状況 通貨ぺア取引状況 = new 通貨ぺア取引状況()
                {
                    通貨ペアNo = 37
                };

                注文共通.C_注文_Order_Ver6_Swap(FormData.OrderData, 通貨ぺア取引状況, "Swap ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        #endregion


        #region Tick_3min

        private void btnTick_3min_Click(object sender, EventArgs e)
        {
            try
            {
                システム設定.CommandLineから環境設定();

                OANDAv1.OANDAv1.ログイン();
                OANDAv1.OANDAv1.OoandaInstrument取得();


                テスト結果 = "要ステップ実行 \r\n";

                FormData.TradeEvent.Tick_3min();

                テスト結果 += "完了";

                F結果 F結果 = new F結果(テスト結果);
                F結果.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        // テスト済み
        private void btn注文設定_ポジション数_更新_Click(object sender, EventArgs e)
        {
            try
            {
                テスト結果 = "Instrument ポジション数 \r\n";

                FormData.TradeApi.保持ポジション更新(FormData.通貨ぺア別取引状況);

                foreach (var 通貨ぺア取引状況 in FormData.通貨ぺア別取引状況.Where(x => x.Chkデータ生成 == true))
                {
                    テスト結果 += 通貨ぺア取引状況.Instrument.ToString() + " " + 通貨ぺア取引状況.Unit数.ToString() + "\r\n";
                }

                F結果 F結果 = new F結果(テスト結果);
                F結果.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        // テスト済み
        private void btn注文数約定数約定金額決算待ちポジション数_Click(object sender, EventArgs e)
        {
            try
            {
                FormData.当日約定数 = oanda.Cnt約定数(注文共通.Get当日の開始日時(DateTime.Now));
                FormData.当日約定金額 = oanda.GetSUM差益(注文共通.Get当日の開始日時(DateTime.Now), DateTime.Now);

                テスト結果 = "当日注文数 " + FormData.当日注文数 + "\r\n";
                テスト結果 += "t当日約定数 " + FormData.当日約定数 + "\r\n";
                テスト結果 += "当日約定金額 " + FormData.当日約定金額 + "\r\n";
                テスト結果 += "決算待ちポジション数 " + FormData.決算待ちポジション数 + "\r\n";

                F結果 F結果 = new F結果(テスト結果);
                F結果.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn3分以上経っている注文は削除_Click(object sender, EventArgs e)
        {
            try
            {
                システム設定.CommandLineから環境設定();
                OANDAv1.OANDAv1.ログイン();

                int count;
                OANDAv1.OANDAv1._3分以上経っている注文は削除(out count);

                F結果 F結果 = new F結果(count.ToString());
                F結果.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        #endregion


        #region Tick_10min

        private void btnTick_10min_Click(object sender, EventArgs e)
        {
            try
            {
                テスト結果 = "要ステップ実行 \r\n";

                FormData.TradeEvent.Tick_10min();

                テスト結果 += "完了";

                F結果 F結果 = new F結果(テスト結果);
                F結果.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnChk直近n分以内にボーナスステージ終了有り_Click(object sender, EventArgs e)
        {
            try
            {
                テスト結果 = "Instrument ボーナスステージ終了有り \r\n";
                DateTime n分前 = DateTime.Now.AddMinutes(-25);

                foreach (var 通貨ぺア取引状況 in FormData.通貨ぺア別取引状況)
                {
                    if (oder.Chk直近n分以内にボーナスステージ終了有り(通貨ぺア取引状況, n分前) == false)
                    {
                        テスト結果 += 通貨ぺア取引状況.Instrument.ToString() + " false \r\n";
                    }
                    else
                    {
                        テスト結果 += 通貨ぺア取引状況.Instrument.ToString() + " true \r\n";
                    }
                }

                F結果 F結果 = new F結果(テスト結果);
                F結果.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn利益が出ているOrderは全てクローズする_Click(object sender, EventArgs e)
        {
            try
            {
                テスト結果 = "要ステップ実行 \r\n";

                foreach (var 通貨ぺア取引状況 in FormData.通貨ぺア別取引状況)
                {
                    FormData.TradeApi.利益が出ているポジションは全てクローズする();
                }

                テスト結果 += "完了";

                F結果 F結果 = new F結果(テスト結果);
                F結果.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnGetリミット_BS終了時_Click(object sender, EventArgs e)
        {
            try
            {
                //テスト結果 = "Instrument 買いRate 買いリミット 売りRate 売りリミット \r\n";

                //using (SqlConnection cn = new SqlConnection())
                //{
                //    cn.ConnectionString = FormData.DBConnectionString;
                //    cn.Open();

                //    foreach (var 通貨ぺア取引状況 in FormData.通貨ぺア別取引状況)
                //    {
                //        cmn.Getリミット_BS終了時(cn, 通貨ぺア取引状況);

                //        テスト結果 += 通貨ぺア取引状況.Instrument.ToString() + " " + 通貨ぺア取引状況.買いRate.ToString() + " " + 通貨ぺア取引状況.買いリミット + " " + 通貨ぺア取引状況.売りRate.ToString() +" " + 通貨ぺア取引状況.売りリミット + " \r\n";
                //    }
                //}

                //F結果 F結果 = new F結果(テスト結果);
                //F結果.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn保持ポジションのリミット初期化_BS終了時_Click(object sender, EventArgs e)
        {
            try
            {
                テスト結果 = "要ステップ実行 \r\n";

                foreach (var 通貨ぺア取引状況 in FormData.通貨ぺア別取引状況)
                {
                    FormData.TradeApi.保持ポジションのリミット初期化_BS終了時(通貨ぺア取引状況);
                }

                F結果 F結果 = new F結果(テスト結果);
                F結果.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnGetBSポジションCnt_Click(object sender, EventArgs e)
        {
            try
            {
                通貨ぺア取引状況 通貨ぺア取引状況 = new 通貨ぺア取引状況()
                {
                    通貨ペアNo = 1
                };

                int i = oanda.GetBSポジションCnt(通貨ぺア取引状況, 1000000);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnExecLog_Flush_Click(object sender, EventArgs e)
        {
            try
            {
                BulkCopyExecLog.InsertExecLog(処理区分.Tick.ToString(), "10min", null, null, null);
                BulkCopyExecLog.InsertExecLog(処理区分.Tick.ToString(), null, null, null, null);
                BulkCopyExecLog.InsertExecLog(処理区分.Tick.ToString(), null, null, null, null);
                BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, null, null, null);
                BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, null, null, null);
                BulkCopyExecLog.InsertExecLog(処理区分.Order.ToString(), null, null, "Order対象外（Chk注文がFalse）", null);
                BulkCopyExecLog.ExecLogFlush();
            }
            catch (Exception ex)
            {
                注文共通.Exception共通(ex, new List<Cエラー関連変数>());
            }
        }

        #endregion


        #region Tick_1hour

        private void btnTick_1h_Click(object sender, EventArgs e)
        {
            try
            {
                テスト結果 = "要ステップ実行 \r\n";

                FormData.TradeEvent.Tick_1h();

                F結果 F結果 = new F結果(テスト結果);
                F結果.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        // テスト済み
        private void btn取引可能時間帯_Click(object sender, EventArgs e)
        {
            try
            {
                FormData.システム設定_Trade時間内 = 注文共通.GetTrade時間内();

                if (注文共通.取引可能時間帯() == false)
                {
                    ログ.ログ書き出し("Application.Exit 1");

                    if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday && DateTime.Now.Hour > 9)
                    {
                        ログ.ログ書き出し("Application.Exit 2");
                        Application.Exit();
                    }
                }

                F結果 F結果 = new F結果(テスト結果);
                F結果.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        // テスト済み
        private void btnDB記録_Account_Click(object sender, EventArgs e)
        {
            try
            {
                テスト結果 = "要ステップ実行 \r\n";

                OANDAv1.OANDAv1.DB記録_Account();

                F結果 F結果 = new F結果(テスト結果);
                F結果.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        // テスト済み
        private void btnDB記録_Trade_Click(object sender, EventArgs e)
        {
            try
            {
                テスト結果 = "要ステップ実行 \r\n";

                OANDAv1.OANDAv1.DB記録_Trade_ポジション数更新_注文禁止Rate幅更新();

                F結果 F結果 = new F結果(テスト結果);
                F結果.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        // テスト済み
        private void btnDB記録_Transaction_Click(object sender, EventArgs e)
        {
            try
            {
                テスト結果 = "要ステップ実行 \r\n";

                システム設定.CommandLineから環境設定();
                OANDAv1.OANDAv1.ログイン();

                OANDAv1.OANDAv1.DB記録_Transaction();

                F結果 F結果 = new F結果(テスト結果);
                F結果.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        // テスト済み
        private void btn先月当月利益更新_Click(object sender, EventArgs e)
        {
            try
            {
                テスト結果 = "";

                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = FormData.DBConnectionString;
                    cn.Open();

                    //注文共通.先月当月利益更新(cn);
                }

                テスト結果 += "当月利益プラス" + FormData.当月利益プラス;
                テスト結果 += "先月利益プラス" + FormData.先月利益プラス;

                F結果 F結果 = new F結果(テスト結果);
                F結果.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        // テスト済み
        private void btnInsertポジションHourly_Click(object sender, EventArgs e)
        {
            try
            {
                テスト結果 = "要ステップ実行 \r\n";

                pfmc.InsertポジションHourly();

                F結果 F結果 = new F結果(テスト結果);
                F結果.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn利益が出ているポジションは全てクローズする_Click(object sender, EventArgs e)
        {
            try
            {
                FormData.OrderData = new OrderData();

                FormData.OrderData.now = DateTime.Now;
                注文共通.StartTime_EndTime取得(FormData.OrderData);

                OANDAv1.OANDAv1.通貨ペアRate更新(FormData.OrderData, FormData.通貨ぺア別取引状況);

                foreach (var 通貨ぺア取引状況 in FormData.通貨ぺア別取引状況.Where(x => x.Chk注文 == true).ToList())
                {
                    try
                    {
                        OANDAv1.OANDAv1.利益が出ているポジションは全てクローズする();
                    }
                    catch (Exception ex)
                    {
                        string str = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnOrder間隔最小値_リミット_更新_Click(object sender, EventArgs e)
        {
            try
            {
                //using (SqlConnection cn = new SqlConnection())
                //{
                //    cn.ConnectionString = FormData.DBConnectionString;
                //    cn.Open();

                //    var 通貨ぺア別取引状況_データ生成対象 = FormData.通貨ぺア別取引状況.Where(x => x.Chkデータ生成 == true).ToList();

                //    foreach (var 通貨ぺア取引状況 in 通貨ぺア別取引状況_データ生成対象.Where(x => x.Chk注文 == true).ToList())
                //    {
                //        try
                //        {
                //            注文共通.リミット更新_通常(通貨ぺア取引状況);
                //        }
                //        catch (Exception ex)
                //        {
                //            string str = ex.Message;
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btn保持ポジションのリミット初期化_Click(object sender, EventArgs e)
        {
            try
            {
                FormData.OrderData = new OrderData();

                FormData.OrderData.now = DateTime.Now;
                注文共通.StartTime_EndTime取得(FormData.OrderData);

                OANDAv1.OANDAv1.保持ポジション更新(FormData.通貨ぺア別取引状況);
                OANDAv1.OANDAv1.通貨ペアRate更新(FormData.OrderData, FormData.通貨ぺア別取引状況);

                foreach (var 通貨ぺア取引状況 in FormData.通貨ぺア別取引状況.Where(x => x.Chkデータ生成 == true))
                {
                    try
                    {
                        if (通貨ぺア取引状況.保持ポジション == "")
                            continue;

                        cmn.Get起動初期値_通貨ペア別(通貨ぺア取引状況);

                        OANDAv1.OANDAv1.保持ポジションのリミット初期化(通貨ぺア取引状況);
                    }
                    catch (Exception ex)
                    {
                        List<Cエラー関連変数> Cエラー関連変数List = new List<Cエラー関連変数>();
                        Cエラー関連変数List.Add(new Cエラー関連変数() { 変数名 = "通貨ペアNo", 値 = 通貨ぺア取引状況.通貨ペアNo.ToString() });
                        注文共通.Exception共通(ex, Cエラー関連変数List);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnSelectマイナスInstrument_Click(object sender, EventArgs e)
        {
            try
            {
                FormData.OrderData = new OrderData();

                OANDAv1.OANDAv1.手動登録したSwapに反するポジションは自動クローズする();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }


        #endregion

        private void btnUpdateWMA_Hour1_Click(object sender, EventArgs e)
        {
            try
            {
                FormData.OrderData = new OrderData();
                FormData.OrderData.now = DateTime.Parse("2017/02/13 23:10:40");
                FormData.OrderData.StartHour1 = DateTime.Now;
                //2017 / 02 / 09 17:53:54

                cmn.GetThisMonth1(FormData.OrderData);

                foreach (var 通貨ぺア取引状況 in FormData.通貨ぺア別取引状況.Where(x => x.Chkデータ生成 == true).ToList())
                {
                    rate.UpdateWMA_Hour1(FormData.OrderData, 通貨ぺア取引状況);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        private void btnマイナスInterestが記録された通貨ペアで利益が出ているポジションはクローズ_Click(object sender, EventArgs e)
        {
            try
            {
                OANDAv1.OANDAv1.ログイン();

                OANDAv1.OANDAv1.マイナスInstrument更新(false);

                FormData.通貨ぺア別取引状況.Where(x => x.Instrument == "AUD/JPY").First().マイナスInstrument = true;

                //List<TradeData> openTrades = new List<TradeData>();
                //openTrades.Add(new TradeData() { instrument = "AUD/CAD", side = "buy" });
                //openTrades.Add(new TradeData() { instrument = "AUD/CHF", side = "buy" });

                OANDAv1.OANDAv1.マイナスInterestが記録された通貨ペアで利益が出ているポジションはクローズ();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        #endregion


        #region その他

        private void btnException_Click(object sender, EventArgs e)
        {
            try
            {
                注文共通.Exception共通(new Exception("テスト"), new List<Cエラー関連変数>());
                システム設定.DB接続();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー");
            }
        }

        #endregion


        #region Rest

        private void btnGetTransactionListAsync_Click(object sender, EventArgs e)
        {
            try
            {
                システム設定.CommandLineから環境設定();

                OANDAv1.OANDAv1.ログイン();

                FormData.OandaTransactionLastId = 10915139894;

                List<OandaTransaction> result;
                FormData.OandaTransactionLastId = Rest.GetTransactionListAsync(FormData.OandaAccountId, FormData.OandaTransactionLastId, out result);

                string str = "";
                foreach(var aa in result)
                {
                    str += aa.id + "\t" + aa.time + "\t" + aa.instrument + "\r\n";
                }

                var F結果 = new F結果(str);
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
