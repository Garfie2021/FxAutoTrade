using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using 定数;
using 共通Data;
using DB;
using OANDAv1;
using FXAPI共通;

namespace SystemSetting
{
    public static class システム設定
    {
        #region publicメソッド

        public static string DemoReal判定(string connectionString)
        {
            if (connectionString.IndexOf("Demo") > -1)
            {
                return "Demo";
            }
            else
            {
                return "Real";
            }
        }


        public static void CommandLine取得(bool maintenance)
        {
            if (Environment.GetCommandLineArgs().Length > 1)
            {
                FormData.CommandLine = Environment.GetCommandLineArgs()[1];

                var command = FormData.CommandLine.Split(';');

                FormData.自動開始 = (自動開始)Enum.Parse(typeof(自動開始), command[(int)CommandColumn.自動開始]);
                FormData.DB接続先 = command[(int)CommandColumn.接続先DB];

                if (!maintenance)
                {
                    FormData.口座No = int.Parse(command[(int)CommandColumn.口座No]);
                    FormData.MasterSlave = (MasterSlave)Enum.Parse(typeof(MasterSlave), command[(int)CommandColumn.Rate取得]);
                }
            }
        }

        public static void 実行モード確認()
        {
            if (FormData.DemoReal == DemoReal.Real)
            {
                if (FormData.DBConnectionString.IndexOf("Demo", StringComparison.Ordinal) > -1)
                {
                    if (DialogResult.Yes != MessageBox.Show("アプリケーションのコマンドラインと、DB接続先が一致していませんが、続行しますか？"
                        , "バグチェック", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        throw new Exception("アプリケーションのコマンドラインとDB接続先が不一致");
                }
            }
            else if (FormData.DemoReal == DemoReal.Demo)
            {
                if (FormData.DBConnectionString.IndexOf("Real", StringComparison.Ordinal) > -1)
                {
                    if (DialogResult.Yes != MessageBox.Show("アプリケーションのコマンドラインと、DB接続先が一致していませんが、続行しますか？"
                        , "バグチェック", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        throw new Exception("アプリケーションのコマンドラインとDB接続先が不一致");
                }
            }
        }

        public static void DB接続()
        {
            FormData.cn.Close();
            FormData.cn.ConnectionString = FormData.DBConnectionString;
            FormData.cn.Open();

            DB接続(FormData.cn);
        }

        public static void DB接続(SqlConnection cn)
        {
            anls.SqlCommandInitialize(FormData.cn);
            cmn.SqlCommandInitialize(FormData.cn);
            fxcm.SqlCommandInitialize(FormData.cn);
            hltc.SqlCommandInitialize(FormData.cn);
            hstr.SqlCommandInitialize(FormData.cn);
            mstr.SqlCommandInitialize(FormData.cn);
            oanda.SqlCommandInitialize(FormData.cn);
            oder.SqlCommandInitialize(FormData.cn);
            pfmc.SqlCommandInitialize(FormData.cn);
            rate.SqlCommandInitialize(FormData.cn);
            swap.SqlCommandInitialize(FormData.cn);
            temp.SqlCommandInitialize(FormData.cn);
        }

        public static void CommandLineから環境設定()
        {
            //FormData.DBConnectionString = DB定数.GetDBConnectionString(FormData.CommandLine);
            FormData.DBConnectionString = DB定数.GetConnectionString(FormData.DB接続先);

            DB接続();

            cmn.Select口座();

            if (FormData.FX会社 == Company.OANDA)
            {
                FormData.TradeEvent = new TradeEventOanda();
                FormData.TradeApi = new TradeApiOanda();
            }

            if (FormData.DemoReal == DemoReal.Real)
            {
                FormData.OandaEnvironment = EEnvironment.Trade;
            }
            else
            {
                FormData.OandaEnvironment = EEnvironment.Practice;
            }

            FormData.通貨ぺア別取引状況 = Instrument初期化.通貨ペア初期化();


            if (FormData.CommandLine.IndexOf("OANDA_DemoB_ACV", StringComparison.Ordinal) > -1)
            {
                OANDA_DemoB();
            }
            else if (FormData.CommandLine.IndexOf("OANDA_DemoB", StringComparison.Ordinal) > -1)
            {
                OANDA_DemoB();
            }
            else if (FormData.CommandLine.IndexOf("OANDA_RealA_ACV", StringComparison.Ordinal) > -1)
            {
                OANDA_RealA();
            }
            else if (FormData.CommandLine.IndexOf("OANDA_RealA", StringComparison.Ordinal) > -1)
            {
                OANDA_RealA();
            }
            else if (FormData.CommandLine.IndexOf("FXCM_DemoA", StringComparison.Ordinal) > -1)
            {
                FXCM_DemoA();
            }
            else if (FormData.CommandLine.IndexOf("RealA_FX", StringComparison.Ordinal) > -1)
            {
                FXCM_RealA();
            }

            //oder.LogPath = FormData.ログフォルダ;
        }


        #endregion

        #region publicメソッド

        #region Demo

        // FXCM UK のデモ口座
        private static void FXCM_DemoA()
        {
            //FormData.Company = Company.FXCM;
            //FormData.Contry = Contry.UK;
            //FormData.TradeEvent = new TradeEventFXCMv1();
            //FormData.TradeApi = new TradeApiFXCMv1();
            //FormData.通貨ぺア別取引状況 = Instrument初期化.通貨ペア初期化(FormData.CommandLine);

            FormData.ExeFilePath = @"C:\AutoFX\FXCM_DemoA\AutoFx_Form.exe";
            FormData.ログフォルダ = @"C:\AutoFX\FXCM_DemoA\log";

            //FormData.口座種別 = "個人";
            //FormData.Connection = "Demo";
            FormData.Username = "1111";
            FormData.Password = "1111";

            FormData.余剰金割合_Order対象通貨ペアを減らす開始点 = 25;
            FormData.前日の高値底値とOrder間隔最小値の割合 = 50;

            FormData.n日以上前のポジションは決済 = 7;
            FormData.chkn日以上前のポジション決済をスキップ = true;

            //FormData.chk毎朝の自動注文開始を行う = false;
            FormData.chk余剰金確保の自動ポジションCloseはしない = true;
        }

        // FXCM JP  Real口座 個人
        private static void FXCM_RealA()
        {
            //FormData.Company = Company.FXCM;
            //FormData.Contry = Contry.JP;
            //FormData.TradeEvent = new TradeEventFXCMv1();
            //FormData.TradeApi = new TradeApiFXCMv1();
            //FormData.通貨ぺア別取引状況 = Instrument初期化.通貨ペア初期化(FormData.CommandLine);

            FormData.ExeFilePath = @"C:\AutoFX\RealA_FX\AutoFx_Form.exe";
            FormData.ログフォルダ = @"C:\AutoFX\RealA_FX\log";

            //FormData.口座種別 = "個人";
            //FormData.Connection = "Real";
            FormData.Username = "111";
            FormData.Password = "1111";

            FormData.余剰金割合_Order対象通貨ペアを減らす開始点 = 15;
            FormData.前日の高値底値とOrder間隔最小値の割合 = 99;

            //FormData.chk毎朝の自動注文開始を行う = false;
            FormData.chk余剰金確保の自動ポジションCloseはしない = true;
        }

        // OANDA JP のデモ口座
        private static void OANDA_DemoB()
        {
            //FormData.Company = Company.OANDA;
            //FormData.Contry = Contry.US;
            //FormData.TradeEvent = new TradeEventOanda();
            //FormData.TradeApi = new TradeApiOanda();
            //FormData.通貨ぺア別取引状況 = Instrument初期化.通貨ペア初期化(FormData.CommandLine);

            FormData.ExeFilePath = @"C:\AutoFX\OANDA_DemoB\AutoFx_Form.exe";
            FormData.ログフォルダ = @"C:\AutoFX\OANDA_DemoB\log";

            // 口座ログイン
            //FormData.口座No = 0;
            //FormData.口座種別 = "個人";
            //FormData.Connection = "Demo";
            //FormData.OandaAccountId = 111;
            //FormData.Password = "";
            //FormData.OandaAccessToken = "111";
            //FormData.OandaAccountId = 111;
            //FormData.Password = "";
            //FormData.OandaAccessToken = "111";
            //FormData.OandaEnvironment = EEnvironment.Practice;

            FormData.chkフォームデータ自動更新 = false;

            // 注文
            FormData.chk15mデータ生成以降の処理をスキップ = true;
            FormData.chk注文状態記録まで注文はスキップ = true;
            //FormData.chk毎朝の自動注文開始を行う = true;

            if (FormData.口座No == 1)
            {
                // 口座1(111)： 本番稼働中と同じロジック。スワップがプラスでRate判定の全単位が正の時に注文。これより良い結果かどうかで新しいロジックを採用するかどうか決める。

                FormData.chkスワップロジックで注文する = true;
                FormData.chkスワップロジックの注文条件を緩和 = false;
                FormData.chk反転ロジックで注文する = false;
                FormData.chk反転ロジックはマイナススワップのみ対象 = false;
            }
            else if (FormData.口座No == 2)
            {
                // 口座2(111)： 反転ロジックのみで、週次に対して日次が反転した際に注文。スワップがマイナスのポジションが残っていたら毎朝クローズ。スワップがプラスのポジションは長期保有。

                FormData.chkスワップロジックで注文する = false;
                FormData.chkスワップロジックの注文条件を緩和 = false;
                FormData.chk反転ロジックで注文する = true;
                FormData.chk反転ロジックはマイナススワップのみ対象 = false;
            }
            else if (FormData.口座No == 3)
            {
                // 口座3(111)： スワップロジックのみで、注文タイミングは緩和し、週次に対して日次が反転した際にも注文。

                FormData.chkスワップロジックで注文する = true;
                FormData.chkスワップロジックの注文条件を緩和 = true;
                FormData.chk反転ロジックで注文する = false;
                FormData.chk反転ロジックはマイナススワップのみ対象 = false;
            }
            else if (FormData.口座No == 4)
            {
                // 口座4(111)： 反転ロジックとスワップロジックを混在させ、反転ロジックは週次に対して日次が反転した際に注文、スワップロジックは更に週次と日次が正の時も注文。スワップがマイナスのポジションが残っていたら毎朝クローズ。スワップがプラスのポジションは長期保有。

                FormData.chkスワップロジックで注文する = true;
                FormData.chkスワップロジックの注文条件を緩和 = true;
                FormData.chk反転ロジックで注文する = true;
                FormData.chk反転ロジックはマイナススワップのみ対象 = false;
            }
            else if (FormData.口座No == 5)
            {
                // 口座5 (111)： 反転ロジックのみで、週次に対して日次が反転した際、スワップがマイナスなら注文。ポジションが残っていたら毎朝クローズ。

                FormData.chkスワップロジックで注文する = false;
                FormData.chkスワップロジックの注文条件を緩和 = false;
                FormData.chk反転ロジックで注文する = true;
                FormData.chk反転ロジックはマイナススワップのみ対象 = true;
            }
            else
            {
                // 口座0 ： Master口座。Rate収集WMA計算のみ。

                FormData.chkスワップロジックで注文する = false;
                FormData.chkスワップロジックの注文条件を緩和 = false;
                FormData.chk反転ロジックで注文する = false;
                FormData.chk反転ロジックはマイナススワップのみ対象 = false;
            }

            FormData.chkStoploss設定する = false;
            FormData.chk手動登録したSwapに反するポジションは自動クローズする = true;

            // ポジションクローズ
            FormData.chk余剰金確保の自動ポジションCloseはしない = true;
            FormData.chk余剰金確保の自動ポジションCloseはMSG確認する = false;
            FormData.chkn日以上前のポジション決済をスキップ = true;
            FormData.n日以上前のポジションは決済 = 90;
            FormData.余剰金割合_Order対象通貨ペアを減らす開始点 = 25;
        }

        // OANDA JP の本番口座 個人
        private static void OANDA_RealA()
        {
            //FormData.Company = Company.OANDA;
            //FormData.Contry = Contry.US;
            //FormData.TradeEvent = new TradeEventOanda();
            //FormData.TradeApi = new TradeApiOanda();
            //FormData.通貨ぺア別取引状況 = Instrument初期化.通貨ペア初期化(FormData.CommandLine);

            FormData.ExeFilePath = @"C:\AutoFX\OANDA_RealA\AutoFx_Form.exe";
            FormData.ログフォルダ = @"C:\AutoFX\OANDA_RealA\log";

            // 口座ログイン
            //FormData.口座No = 0;
            //FormData.口座種別 = "個人";
            //FormData.Connection = "Real";
            //FormData.OandaAccountId = 111;
            //FormData.Password = "";
            //FormData.OandaAccessToken = "111";
            //FormData.OandaEnvironment = EEnvironment.Trade;

            FormData.chkフォームデータ自動更新 = false;

            // 注文
            FormData.chk15mデータ生成以降の処理をスキップ = true;
            FormData.chk注文状態記録まで注文はスキップ = true;
            //FormData.chk毎朝の自動注文開始を行う = true;
            FormData.chkスワップロジックで注文する = true;
            FormData.chkスワップロジックの注文条件を緩和 = false;
            FormData.chk反転ロジックで注文する = false;
            FormData.chk手動登録したSwapに反するポジションは自動クローズする = false;
            FormData.chkStoploss設定する = false;

            // ポジションクローズ
            FormData.chk余剰金確保の自動ポジションCloseはしない = true;
            FormData.chk余剰金確保の自動ポジションCloseはMSG確認する = false;
            FormData.chkn日以上前のポジション決済をスキップ = true;
            FormData.n日以上前のポジションは決済 = 90;
            FormData.余剰金割合_Order対象通貨ペアを減らす開始点 = 25;
        }

        #endregion


        #endregion


    }
}
