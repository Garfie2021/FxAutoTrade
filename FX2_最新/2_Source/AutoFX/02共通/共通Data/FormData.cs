using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using 定数;

namespace 共通Data
{
    public static class FormData
    {
        #region 共通変数

        // システム

        // 【;区切り】
        // 1つ目：Autoかどうか;
        // 2つ目：アカウント（DemoA_FX or RealA_FX or etc...）;
        // 3つ目：API（FXCMJP or FXCMUK or OANDAJP）
        // 【例】
        // Auto;DemoA_FX;FXCMJP;FXCMv1  
        // Auto;RealA_FX;FXCMJP;FXCMv1
        // Auto;DemoB_FX;FXCMUK;FXCMv1
        // Auto;RealB_FX;FXCMUK;FXCMv1
        // Auto;DemoC_FX;OANDAJP;OANDAv1
        // Auto;RealC_FX;OANDAJP;OANDAv1
        public static string CommandLine = "";

        public static string ExeFilePath;
        public static string DBConnectionString = "";
        public static SqlConnection cn = new SqlConnection();

        public static Encoding Enc = Encoding.GetEncoding("Shift_JIS");

        public static I_TradeEvent TradeEvent;
        public static I_TradeApi TradeApi;

        public static int _1ポジションあたり25000円の変動までは耐える = 25000;                // 1ポジションあたり25000円の変動までは耐える
        public static int 注文単位を1づつ増やす際の注文可能限界数 = 25;                                    // 注文単位を1づつ増やす際の注文可能限界数
        public static int n日以上前のポジションは決済 = 90;
        public static string ログフォルダ = "";       // txtログフォルダ_Text

        public static OrderData OrderData;

        public static List<TradeData> Oanda保持ポジション;

        // 口座
        public static int 口座No;
        public static Company FX会社;
        public static Contry FxServerContry;
        public static 個人法人 個人法人;
        public static DemoReal DemoReal;
        public static 有効無効 有効無効;
        public static MasterSlave MasterSlave;
        public static int? 取引証拠金上限;
        public static 毎朝の自動注文開始を行う 毎朝の自動注文開始を行う;

        public static 自動開始 自動開始;


        //public static string Connection = "";
        public static string Username = "";
        public static string Password = "";

        // Oanda固有
        public static int OandaAccountId;
        public static string OandaAccessToken;
        public static EEnvironment OandaEnvironment;

        public static int ロスカット余剰金調整値;
        

        #endregion



        public static DateTime OandaTransaction最終日時;
        public static long OandaTransactionLastId;

        //public static List<通貨ぺア別取引状況> DG = new List<通貨ぺア別取引状況>();

        #region 注文設定tab

        // 枠無し

        
        public static bool chk初期値の計算処理をスキップ = true;
        public static bool chkフォームデータ自動更新 = true;
        public static string システム設定_Trade時間内 = "";
        public static string Order状況 = "取引中 or 取引停止中(事由)";
        public static string Auto = "Auto";
        public static string ログイン表示 = "ログイン中";
        public static string 取引モード表示 = "自動取引中";

        // 口座ログイン
        public static string Connection = "Demo";
        public static string 口座種別 = "個人";
        //public static string Username = "1111";
        //public static string Password = "1111";
        public static string DB接続先 = "DB接続先";

        // ポジションクローズ
        public static bool chk余剰金確保の自動ポジションCloseはしない = false;
        public static bool chk余剰金確保の自動ポジションCloseはMSG確認する = false;
        public static bool chkn日以上前のポジション決済をスキップ = true;

        // 注文
        public static bool chk15mデータ生成以降の処理をスキップ = true;
        public static bool chk注文状態記録まで注文はスキップ = true;
        //public static bool chk毎朝の自動注文開始を行う = true;
        public static bool chkスワップロジックで注文する = false;
        public static bool chkスワップロジックの注文条件を緩和 = false;
        public static bool chk反転ロジックで注文する = false;
        public static bool chk反転ロジックはマイナススワップのみ対象 = false;
        
        public static bool chkStoploss設定する = false;
        public static bool chk手動登録したSwapに反するポジションは自動クローズする = false;


        // 口座状況
        public static double 先月利益マイナス = 0;
        public static double 先月利益プラス = 0;
        public static double 出金可能額_先月 = 0;
        public static string 出金済_先月 = "済";
        public static double 当月利益マイナス = 0;
        public static double 当月利益プラス = 0;
        public static double 出金可能額_当月 = 0;
        public static int 決算待ちポジション数 = 0;
        public static int 当日注文数 = 0;
        public static int 当日約定数 = 0;
        public static double 当日約定金額 = 0;
        public static double 取引証拠金 = 0;
        public static double 維持証拠金 = 0;
        public static double 余剰証拠金 = 0;
        public static double 出金可能額で調整したロスカット余剰金 = 0;
        public static double 余剰金の割合 = 0;

        // 更新日時
        public static DateTime Rate更新最終日時;


        #region DataGridView

        public static List<通貨ぺア取引状況> 通貨ぺア別取引状況;
        public static int 通貨ぺア別取引数 = 0;

        // BackColor
        public static Color clrSwap判定が逆のポジションがある_BackColor = Color.FromArgb(255, 192, 255);
        public static Color clrSwap判定が逆のポジションがありRateも保持ポジションの逆に動いてる_BackColor = Color.Fuchsia;

        #endregion

        #endregion


        #region システム設定tab

        #region 注文設定tab

        // 注文設定
        public static string grpシステム設定_注文設定_注文設定 = "注文設定";
        public static int ポジション増加数_直近n時間 = -24;         // txtポジション増加数_直近n時間_Text
        public static int 差損益気増加数_直近n日間 = 3;                // txt差損益気増加数_直近n日間_Text

        // Order
        public static string grpシステム設定_注文設定_Order = "Order";
        public static double 余剰金割合_Order対象通貨ペアを減らす開始点 = 0;   // txt余剰金割合_Order対象通貨ペアを減らす開始点_Text
        //public static double 余剰金割合_Order限界点 = 15;                        // txt余剰金割合_Order限界点_Text
        public static int Order対象を減少させないOrder数 = 3;                  // txtOrder対象を減少させないOrder数_Text
        public static byte システム設定_Rate幅を求めるn日間_Order間隔最小値 = 7;               // txtシステム設定_Rate幅を求めるn日間_Order間隔最小値_Text
        public static double 前日の高値底値とOrder間隔最小値の割合 = 0;          // txt前日の高値底値とOrder間隔最小値の割合_Text
        public static byte システム設定_Rate幅を求めるn日間_リミット = 7;                 // txtシステム設定_Rate幅を求めるn日間_リミット_Text
        public static double 前日の高値底値とリミットの割合 = 20;               // txt前日の高値底値とリミットの割合_Text
        public static double システム_Order間隔増加割合 = 20;                          // txtシステム_Order間隔増加割合_Text
        public static double システム_自動更新Rate幅はOrder間隔のn倍 = 2.5;                // txtシステム_自動更新Rate幅はOrder間隔のn倍_Text
        public static int システム設定_AtMarket = 5;                                           // txtシステム設定_AtMarket_Text
        public static double BS発生_リミット拡張幅 = 0.1; // txtBS発生_リミット拡張幅_Text

        // Close Trade
        public static string grpシステム設定_注文設定_CloseTrade = "Close Trade";
        public static double 余剰金割合の限界点 = 2;                 // txt余剰金割合の限界点_Text
        public static double システム設定_CloseTrade_nヵ月前からあるポジション = 1;   // txtシステム設定_CloseTrade_nヵ月前からあるポジション_Text
        public static double システム設定_CloseTrade_n以上であればCloseする = 50; // txtシステム設定_CloseTrade_n以上であればCloseする_Text

        // 出金 Monthly
        public static DateTime 出金可能にする開始日時 = DateTime.Parse("2014/04/21 00:00:00");     // txt出金可能にする開始日時_Text
        public static int 出金可能にする取引証拠金 = 2500000;                                       // txt出金可能にする取引証拠金_Text
        public static byte 出金可能にする利益Percent = 80;                                           // txt出金可能にする利益Percent_Text

        #endregion

        #region 処理状況tab

        // システム日時曜日
        public static int システム設定_年;
        public static int システム設定_月;
        public static int システム設定_日;
        public static int システム設定_時;
        public static int システム設定_分;
        public static int システム設定_秒;
        public static string txtシステム設定_曜日 = "";

        public static bool chkInsturment取得に失敗したためRate取得Onlyに移行 = false;

        #endregion

        #region その他tab

        public static int システム設定_日付はn時くぎり = 6;  // txtシステム設定_日付はn時くぎり_Text


        #endregion

        #endregion


        #region その他

        // ToolStrip
        public static string toolStripStatusLabel1 = "";
        public static string ToolStripStsLbl = "";
        public static Color ToolStripStsLbl_BackColor = Color.LightGray;

        // timer
        public static Timer timer_1sec;
        public static Timer timer_4sec;
        public static Timer timer_3min;
        public static Timer timer_10min;
        public static Timer timer_20min;
        public static Timer timer_1hour;
        public static Timer timer_1day;

        #endregion


    }
}
