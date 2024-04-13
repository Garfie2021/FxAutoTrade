using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using 定数;
using 共通Data;
using Common;
using DB;
using SystemSetting;


namespace AutoFx_Form
{
    public partial class FMain : Form
    {
        //public static I_TradeApi tradeApi;

        #region publicメソッド

        public FMain()
        {
            InitializeComponent();

            if (FormData.MasterSlave == MasterSlave.Master)
            {
                FormData.timer_1sec = new Timer();
                FormData.timer_1sec.Enabled = false;
                FormData.timer_1sec.Interval = 2000;
                FormData.timer_1sec.Tick += new EventHandler(this.timer_Tick_1sec);
            }

            if (FormData.MasterSlave == MasterSlave.Slave)
            {
                FormData.timer_4sec = new Timer();
                FormData.timer_4sec.Enabled = false;
                FormData.timer_4sec.Interval = 4000;
                FormData.timer_4sec.Tick += new EventHandler(this.timer_Tick_4sec);

                FormData.timer_3min = new Timer();
                FormData.timer_3min.Enabled = false;
                FormData.timer_3min.Interval = 180000;
                FormData.timer_3min.Tick += new EventHandler(this.timer_Tick_3min);
            }

            FormData.timer_10min = new Timer();
            FormData.timer_10min.Enabled = false;
            FormData.timer_10min.Interval = 600000;
            FormData.timer_10min.Tick += new EventHandler(this.timer_Tick_10min);

            FormData.timer_1hour = new Timer();
            FormData.timer_1hour.Enabled = false;
            FormData.timer_1hour.Interval = 3600000;
            FormData.timer_1hour.Tick += new EventHandler(this.timer_Tick_1hour);

            FormData.timer_1day = new Timer();
            FormData.timer_1day.Enabled = false;
            FormData.timer_1day.Interval = 86400000;
            FormData.timer_1day.Tick += new EventHandler(this.timer_Tick_1Day);

        }

        #endregion

        #region 非公開 共通メソッド

        private void Start()
        {
            システム設定.CommandLineから環境設定();

            システム設定.実行モード確認();
            ログ.初期化();

            //FormData.chk常時取引可能_Checked = FormData.常時取引可能;

            注文共通.DB接続先表示();
            注文共通.システム設定_表示();

            注文共通.システム日時更新();

            ////Form設定.注文設定DGV初期化();

            // 自動ログイン取引開始
            if (FormData.自動開始 == 自動開始.Auto)
            {
                FormData.Auto = "Auto";

                if (注文共通.取引可能時間帯() == false) return;

                FormData.TradeEvent.Start();
            }
        }

        public void バグチェック()
        {
            if (dgv注文設定.ColumnCount != Form定数.DGVClmNo注文設定_DGV列数)
            {
                throw new Exception("dgv注文設定 の列数と、DGVClmNo注文設定_DGV列数 が不一致");
            }
        }

        private void ToolStripStsLbl更新_chk注文状態記録まで注文はスキップ()
        {
            if (FormData.chk注文状態記録まで注文はスキップ == true)
            {
                FormData.ToolStripStsLbl = "「注文状態記録まで注文はスキップ」：チェック有り";
                FormData.ToolStripStsLbl_BackColor = Color.Yellow;
            }
            else if (FormData.chk注文状態記録まで注文はスキップ == false)
            {
                FormData.ToolStripStsLbl = "";
                FormData.ToolStripStsLbl_BackColor = Color.Gray;
            }
        }

        private void chk注文状態記録まで注文はスキップ_CheckedChanged(object sender, EventArgs e)
        {
            FormData.chk注文状態記録まで注文はスキップ = chk注文状態記録まで注文はスキップ.Checked;

            ToolStripStsLbl更新_chk注文状態記録まで注文はスキップ();
        }

        private void FormDataUpdate_初回のみ()
        {
            #region 注文設定tab

            // 枠無し
            chkフォームデータ自動更新.Checked = FormData.chkフォームデータ自動更新;
            txtAuto.Text = FormData.Auto;
            txtログイン表示.Text = FormData.ログイン表示;
            txt取引モード表示.Text = FormData.取引モード表示;

            // 口座ログイン
            txtConnection.Text = FormData.Connection;
            txt口座種別.Text = FormData.口座種別;
            txtUsername.Text = FormData.Username;
            txtPassword.Text = FormData.Password;
            txtDB接続先.Text = FormData.DB接続先;

            // ポジションクローズ
            chk余剰金確保の自動ポジションCloseはしない.Checked = FormData.chk余剰金確保の自動ポジションCloseはしない;
            chk余剰金確保の自動ポジションCloseはMSG確認する.Checked = FormData.chk余剰金確保の自動ポジションCloseはMSG確認する;
            chkn日以上前のポジション決済をスキップ.Checked = FormData.chkn日以上前のポジション決済をスキップ;
            txtn日以上前のポジションは決済.Text = FormData.n日以上前のポジションは決済.ToString();

            #region DataGridView

            // 注文
            chk15mデータ生成以降の処理をスキップ.Checked = FormData.chk15mデータ生成以降の処理をスキップ;

            if (FormData.毎朝の自動注文開始を行う == 毎朝の自動注文開始を行う.する) chk毎朝の自動注文開始を行う.Checked = true;
            else chk毎朝の自動注文開始を行う.Checked = false;

            chk注文状態記録まで注文はスキップ.Checked = FormData.chk注文状態記録まで注文はスキップ;
            chkスワップロジックで注文する.Checked = FormData.chkスワップロジックで注文する;
            chkスワップロジックの注文条件を緩和.Checked = FormData.chkスワップロジックの注文条件を緩和;
            chk反転ロジックで注文する.Checked = FormData.chk反転ロジックで注文する;
            chk反転ロジックはマイナススワップのみ対象.Checked = FormData.chk反転ロジックはマイナススワップのみ対象;            

            chk手動登録したSwapに反するポジションは自動クローズする.Checked = FormData.chk手動登録したSwapに反するポジションは自動クローズする;
            chkStoploss設定する.Checked = FormData.chkStoploss設定する;

            // BackColor
            clrSwap判定が逆のポジションがある.BackColor = FormData.clrSwap判定が逆のポジションがある_BackColor;
            clrSwap判定が逆のポジションがありRateも保持ポジションの逆に動いてる.BackColor = FormData.clrSwap判定が逆のポジションがありRateも保持ポジションの逆に動いてる_BackColor;

            #endregion

            #endregion

            #region システム設定tab

            #region 注文設定tab

            // 注文設定 //
            grpシステム設定_注文設定_注文設定.Text = FormData.grpシステム設定_注文設定_注文設定;
            txtポジション増加数_直近n時間.Text = FormData.ポジション増加数_直近n時間.ToString();
            txt差損益気増加数_直近n日間.Text = FormData.差損益気増加数_直近n日間.ToString();

            // Order
            grpシステム設定_注文設定_Order.Text = FormData.grpシステム設定_注文設定_Order;
            txt余剰金割合_Order対象通貨ペアを減らす開始点.Text = FormData.余剰金割合_Order対象通貨ペアを減らす開始点.ToString();
            //txt余剰金割合_Order限界点.Text = FormData.余剰金割合_Order限界点.ToString();
            txtOrder対象を減少させないOrder数.Text = FormData.Order対象を減少させないOrder数.ToString();
            txtシステム設定_Rate幅を求めるn日間_Order間隔最小値.Text = FormData.システム設定_Rate幅を求めるn日間_Order間隔最小値.ToString();
            txt前日の高値底値とOrder間隔最小値の割合.Text = FormData.前日の高値底値とOrder間隔最小値の割合.ToString();
            txtシステム設定_Rate幅を求めるn日間_リミット.Text = FormData.システム設定_Rate幅を求めるn日間_リミット.ToString();
            txt前日の高値底値とリミットの割合.Text = FormData.前日の高値底値とリミットの割合.ToString();
            txtシステム_Order間隔増加割合.Text = FormData.システム_Order間隔増加割合.ToString();
            txtシステム_自動更新Rate幅はOrder間隔のn倍.Text = FormData.システム_自動更新Rate幅はOrder間隔のn倍.ToString();
            txtシステム設定_AtMarket.Text = FormData.システム設定_AtMarket.ToString();
            txtBS発生_リミット拡張幅.Text = FormData.BS発生_リミット拡張幅.ToString();

            // Close Trade
            grpシステム設定_注文設定_CloseTrade.Text = FormData.grpシステム設定_注文設定_CloseTrade;
            txt余剰金割合の限界点.Text = FormData.余剰金割合の限界点.ToString();
            txtシステム設定_CloseTrade_nヵ月前からあるポジション.Text = FormData.システム設定_CloseTrade_nヵ月前からあるポジション.ToString();
            txtシステム設定_CloseTrade_n以上であればCloseする.Text = FormData.システム設定_CloseTrade_n以上であればCloseする.ToString();

            // 出金 Monthly
            txt出金可能にする開始日時.Text = FormData.出金可能にする開始日時.ToString();
            txt出金可能にする取引証拠金.Text = FormData.出金可能にする取引証拠金.ToString();
            txt出金可能にする利益Percent.Text = FormData.出金可能にする利益Percent.ToString();

            #endregion

            #region その他tab

            txtシステム設定_日付はn時くぎり.Text = FormData.システム設定_日付はn時くぎり.ToString();

            #endregion

            #endregion

            FormData.TradeApi.FormDataUpdate_dgv注文設定_初回のみ(ref dgv注文設定);

            ToolStripStsLbl更新_chk注文状態記録まで注文はスキップ();
            toolStripStatusLabel1.Text = FormData.toolStripStatusLabel1;

        }

        private void FormDataUpdate()
        {
            // 枠無し
            txtシステム設定_Trade時間内.Text = FormData.システム設定_Trade時間内;
            txtOrder状況.Text = FormData.Order状況;

            // 注文設定 //
            chk15mデータ生成以降の処理をスキップ.Checked = FormData.chk15mデータ生成以降の処理をスキップ;
            chk注文状態記録まで注文はスキップ.Checked = FormData.chk注文状態記録まで注文はスキップ;

            // 口座状況
            txt先月利益マイナス.Text = FormData.先月利益マイナス.ToString();
            txt先月利益プラス.Text = FormData.先月利益プラス.ToString();
            txt出金可能額_先月.Text = FormData.出金可能額_先月.ToString();
            txt出金済_先月.Text = FormData.出金済_先月;
            txt当月利益マイナス.Text = FormData.当月利益マイナス.ToString();
            txt当月利益プラス.Text = FormData.当月利益プラス.ToString();
            txt出金可能額_当月.Text = FormData.出金可能額_当月.ToString();
            txt決算待ちポジション数.Text = FormData.決算待ちポジション数.ToString();
            txt当日注文数.Text = FormData.当日注文数.ToString();
            txt当日約定数.Text = FormData.当日約定数.ToString();
            txt当日約定金額.Text = FormData.当日約定金額.ToString();
            txt取引証拠金.Text = FormData.取引証拠金.ToString();
            txt維持証拠金.Text = FormData.維持証拠金.ToString();
            txtロスカット余剰金.Text = FormData.余剰証拠金.ToString();
            txt出金可能額で調整したロスカット余剰金.Text = FormData.出金可能額で調整したロスカット余剰金.ToString();
            txt余剰金の割合.Text = FormData.余剰金の割合.ToString();

            //txtシステム設定_年.Text = FormData.システム設定_年.ToString();
            //txtシステム設定_月.Text = FormData.システム設定_月.ToString();
            //txtシステム設定_日.Text = FormData.システム設定_日.ToString();
            //txtシステム設定_時.Text = FormData.システム設定_時.ToString();
            //txtシステム設定_分.Text = FormData.システム設定_分.ToString();
            //txtシステム設定_秒.Text = FormData.システム設定_秒.ToString();
            //txtシステム設定_曜日.Text = FormData.txtシステム設定_曜日_Text;

            // 更新日時
            txtRate更新最終日時.Text = FormData.Rate更新最終日時.ToString();
            txtOandaTransaction最終日時.Text = FormData.OandaTransaction最終日時.ToString();


            FormData.TradeApi.FormDataUpdate_dgv注文設定(ref dgv注文設定);

            ToolStripStsLbl.Text = FormData.ToolStripStsLbl;
            ToolStripStsLbl.BackColor = FormData.ToolStripStsLbl_BackColor;
        }

        #endregion


        #region イベントハンドラ

        private void Form1_Load(object sender, EventArgs e)
        {
            FormData.toolStripStatusLabel1 = FormData.CommandLine;

            try
            {
                バグチェック();

                Start();

                FormDataUpdate_初回のみ();
            }
            catch (Exception ex)
            {
                注文共通.Exception共通(ex, new List<Cエラー関連変数>());
                注文共通.全Timerを停止();
            }

            //奇数行を黄色にする
            dgv注文設定.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormData.TradeEvent.Closing();
            FormData.cn.Close();
        }

        #region イベントハンドラ 注文設定Tab

        private void btnシステム設定DB登録_Click(object sender, EventArgs e)
        {
            // No値を変更する場合、ストアド内で使用されているソースも合わせて変更しないといけない
            cmn.UpdateSettings(FormData.OrderData, 0, FormData.grpシステム設定_注文設定_注文設定, txtポジション増加数_直近n時間.Name, FormData.ポジション増加数_直近n時間 * -1);
            cmn.UpdateSettings(FormData.OrderData, 1, FormData.grpシステム設定_注文設定_注文設定, txt差損益気増加数_直近n日間.Name, FormData.差損益気増加数_直近n日間);
            cmn.UpdateSettings(FormData.OrderData, 2, FormData.grpシステム設定_注文設定_注文設定, txtBS発生_リミット拡張幅.Name, FormData.BS発生_リミット拡張幅);

            cmn.UpdateSettings(FormData.OrderData, 3, FormData.grpシステム設定_注文設定_Order, txt余剰金割合_Order対象通貨ペアを減らす開始点.Name, FormData.余剰金割合_Order対象通貨ペアを減らす開始点);
            //cmn.UpdateSettings(FormData.OrderData, 4, FormData.grpシステム設定_注文設定_Order, txt余剰金割合_Order限界点.Name, FormData.余剰金割合_Order限界点);
            cmn.UpdateSettings(FormData.OrderData, 5, FormData.grpシステム設定_注文設定_Order, txtOrder対象を減少させないOrder数.Name, FormData.Order対象を減少させないOrder数);
            cmn.UpdateSettings(FormData.OrderData, 6, FormData.grpシステム設定_注文設定_Order, txtシステム設定_Rate幅を求めるn日間_Order間隔最小値.Name, FormData.システム設定_Rate幅を求めるn日間_Order間隔最小値);
            cmn.UpdateSettings(FormData.OrderData, 7, FormData.grpシステム設定_注文設定_Order, txt前日の高値底値とOrder間隔最小値の割合.Name, FormData.前日の高値底値とOrder間隔最小値の割合 / 100);

            cmn.UpdateSettings(FormData.OrderData, 8, FormData.grpシステム設定_注文設定_Order, txtシステム設定_Rate幅を求めるn日間_リミット.Name, FormData.システム設定_Rate幅を求めるn日間_リミット);
            cmn.UpdateSettings(FormData.OrderData, 9, FormData.grpシステム設定_注文設定_Order, txt前日の高値底値とリミットの割合.Name, FormData.前日の高値底値とリミットの割合 / 100);
            cmn.UpdateSettings(FormData.OrderData, 10, FormData.grpシステム設定_注文設定_Order, txtシステム_Order間隔増加割合.Name, FormData.システム_Order間隔増加割合);
            cmn.UpdateSettings(FormData.OrderData, 11, FormData.grpシステム設定_注文設定_Order, txtシステム_自動更新Rate幅はOrder間隔のn倍.Name, FormData.システム_自動更新Rate幅はOrder間隔のn倍);
            cmn.UpdateSettings(FormData.OrderData, 12, FormData.grpシステム設定_注文設定_Order, txtシステム設定_AtMarket.Name, FormData.システム設定_AtMarket);

            cmn.UpdateSettings(FormData.OrderData, 13, FormData.grpシステム設定_注文設定_CloseTrade, txt余剰金割合の限界点.Name, FormData.余剰金割合の限界点);
            cmn.UpdateSettings(FormData.OrderData, 14, FormData.grpシステム設定_注文設定_CloseTrade, txtシステム設定_CloseTrade_nヵ月前からあるポジション.Name, (double)(FormData.システム設定_CloseTrade_nヵ月前からあるポジション * -1));
            cmn.UpdateSettings(FormData.OrderData, 15, FormData.grpシステム設定_注文設定_CloseTrade, txtシステム設定_CloseTrade_n以上であればCloseする.Name, FormData.システム設定_CloseTrade_n以上であればCloseする);
        }

        private void btn開始_Click(object sender, EventArgs e)
        {
            //FormData.CommandLine = FormData.txtモード_Text;
            FormData.toolStripStatusLabel1 = FormData.CommandLine;

            try
            {
                Start();
            }
            catch (Exception ex)
            {
                注文共通.Exception共通(ex, new List<Cエラー関連変数>());
            }
        }

        private void chk余剰金確保の自動ポジションCloseはしない_CheckedChanged(object sender, EventArgs e)
        {
            FormData.chk余剰金確保の自動ポジションCloseはしない = chk余剰金確保の自動ポジションCloseはしない.Checked;
        }

        private void chk余剰金確保の自動ポジションCloseはMSG確認する_CheckedChanged(object sender, EventArgs e)
        {
            FormData.chk余剰金確保の自動ポジションCloseはMSG確認する = chk余剰金確保の自動ポジションCloseはMSG確認する.Checked;
        }

        private void chkn日以上前のポジション決済をスキップ_CheckedChanged(object sender, EventArgs e)
        {
            FormData.chkn日以上前のポジション決済をスキップ = chkn日以上前のポジション決済をスキップ.Checked;
        }

        private void txtn日以上前のポジションは決済_TextChanged(object sender, EventArgs e)
        {
            FormData.n日以上前のポジションは決済 = int.Parse(txtn日以上前のポジションは決済.Text);
        }

        private void chkInsturment取得に失敗したためRate取得Onlyに移行_CheckedChanged(object sender, EventArgs e)
        {
            FormData.chkInsturment取得に失敗したためRate取得Onlyに移行 = chkInsturment取得に失敗したためRate取得Onlyに移行.Checked;
        }

        private void chkフォームデータ自動更新_CheckedChanged(object sender, EventArgs e)
        {
            FormData.chkフォームデータ自動更新 = chkフォームデータ自動更新.Checked;
        }

        private void chk初期値の計算処理をスキップ_CheckedChanged(object sender, EventArgs e)
        {
            FormData.chk初期値の計算処理をスキップ = chk初期値の計算処理をスキップ.Checked;
        }

        private void chk15mデータ生成以降の処理をスキップ_CheckedChanged(object sender, EventArgs e)
        {
            FormData.chk15mデータ生成以降の処理をスキップ = chk15mデータ生成以降の処理をスキップ.Checked;
        }

        private void chk毎朝の自動注文開始を行う_CheckedChanged(object sender, EventArgs e)
        {
            if (chk毎朝の自動注文開始を行う.Checked == true) FormData.毎朝の自動注文開始を行う = 毎朝の自動注文開始を行う.する;
            else FormData.毎朝の自動注文開始を行う = 毎朝の自動注文開始を行う.しない;
        }

        private void chkスワップロジックで注文する_CheckedChanged(object sender, EventArgs e)
        {
            FormData.chkスワップロジックで注文する = chkスワップロジックで注文する.Checked;
        }

        private void chkスワップロジックの注文条件を緩和_CheckedChanged(object sender, EventArgs e)
        {
            FormData.chkスワップロジックの注文条件を緩和 = chkスワップロジックの注文条件を緩和.Checked;
        }

        private void chk反転ロジックで注文する_CheckedChanged(object sender, EventArgs e)
        {
            FormData.chk反転ロジックで注文する = chk反転ロジックで注文する.Checked;
        }

        private void chk反転ロジックはマイナススワップのみ対象_CheckedChanged(object sender, EventArgs e)
        {
            FormData.chk反転ロジックはマイナススワップのみ対象 = chk反転ロジックはマイナススワップのみ対象.Checked;
        }

        private void chkStoploss設定する_CheckedChanged(object sender, EventArgs e)
        {
            FormData.chkStoploss設定する = chkStoploss設定する.Checked;
        }

        private void chk手動登録したSwapに反するポジションは自動クローズする_CheckedChanged(object sender, EventArgs e)
        {
            FormData.chk手動登録したSwapに反するポジションは自動クローズする = chk手動登録したSwapに反するポジションは自動クローズする.Checked;
        }

        private void btn表示更新_Click(object sender, EventArgs e)
        {
            FormDataUpdate();
        }

        #endregion


        #region イベントハンドラ timer

        // ※注意（DB処理をこのメソッドに書かない）
        private void timer_Tick_1sec(object sender, EventArgs e)
        {
            try
            {
                注文共通.システム日時更新();

                if (FormData.Auto != "Auto")
                    return;

                FormData.TradeEvent.Tick_1sec();
            }
            catch (Exception ex)
            {
                注文共通.Exception共通(ex, new List<Cエラー関連変数>());

                システム設定.DB接続();
            }
        }

        // ※注意（DB処理をこのメソッドに書かない）
        private void timer_Tick_4sec(object sender, EventArgs e)
        {
            try
            {
                if (FormData.Auto != "Auto")
                return;

                if (注文共通.取引可能時間帯() == false)
                    return;

                FormData.TradeEvent.Tick_4sec();

                if (FormData.chkフォームデータ自動更新 == true)
                {
                    FormDataUpdate();
                }
            }
            catch (Exception ex)
            {
                注文共通.Exception共通(ex, new List<Cエラー関連変数>());

                システム設定.DB接続();
            }
        }

        // ※注意（DB処理をこのメソッドに書かない）
        private void timer_Tick_3min(object sender, EventArgs e)
        {
            try
            {
                if (FormData.Auto != "Auto")
                return;

                if (注文共通.取引可能時間帯() == false)
                    return;

                FormData.TradeEvent.Tick_3min();
            }
            catch (Exception ex)
            {
                注文共通.Exception共通(ex, new List<Cエラー関連変数>());

                システム設定.DB接続();
            }
        }

        // ※注意（DB処理をこのメソッドに書かない）
        private void timer_Tick_10min(object sender, EventArgs e)
        {
            try
            {
                if (FormData.Auto != "Auto")
                    return;

                if (注文共通.取引可能時間帯() == false)
                    return;

                if (FormData.chk15mデータ生成以降の処理をスキップ == true)
                    return;

                FormData.TradeEvent.Tick_10min();
            }
            catch (Exception ex)
            {
                注文共通.Exception共通(ex, new List<Cエラー関連変数>());

                システム設定.DB接続();
            }
        }

        // ※注意（DB処理をこのメソッドに書かない）
        private void timer_Tick_1hour(object sender, EventArgs e)
        {
            try
            {
                if (FormData.Auto != "Auto")
                    return;

                if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday && DateTime.Now.Hour > 8)
                {
                    ログ.ログ書き出し("Application.Exit 2");
                    Application.Exit();
                }

                if (注文共通.取引可能時間帯() == false)
                {
                    ログ.ログ書き出し("Application.Exit 1");
                }

                if (FormData.MasterSlave == MasterSlave.Slave)
                {
                    FormData.TradeEvent.Tick_1h();
                }
            }
            catch (Exception ex)
            {
                注文共通.Exception共通(ex, new List<Cエラー関連変数>());

                システム設定.DB接続();
            }
        }

        // ※注意（DB処理をこのメソッドに書かない）
        private void timer_Tick_1Day(object sender, EventArgs e)
        {
            try
            {
                if (FormData.Auto != "Auto") return;

                FormData.TradeEvent.Tick_1day();
            }
            catch (Exception ex)
            {
                注文共通.Exception共通(ex, new List<Cエラー関連変数>());

                システム設定.DB接続();
            }
        }

        #endregion

        #endregion

    }
}


