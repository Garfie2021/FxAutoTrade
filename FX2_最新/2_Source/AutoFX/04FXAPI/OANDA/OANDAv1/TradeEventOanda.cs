using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using 定数;
using 共通Data;
using Common;
using Common461;
using DB;

namespace OANDAv1
{
    public class TradeEventOanda : I_TradeEvent
    {
        public void Start()
        {
            try
            {
                BulkCopyExecLog.InsertExecLog(処理区分.Start.ToString(), "", null, null, null);

                bool TradingServerDisconnect = true;
                while (TradingServerDisconnect)
                {
                    try
                    {
                        OANDAv1.ログイン_Order開始();

                        注文共通.自動取引開始終了();

                        TradingServerDisconnect = false; // Ttrading server に接続できたのでループを抜ける。
                    }
                    catch (Exception ex)
                    {
                        Mail.SendMailAndLogErr("ログイン失敗(OANDAv1)", ex);

                        System.Threading.Thread.Sleep(600000); // 10分待ってTrading serverが復旧している事を期待。

                        if (DateTime.Now.Hour > 9)
                        {
                            // ログインを諦めてアプリケーションを終了しておく
                            BulkCopyExecLog.InsertExecLog(処理区分.Exit.ToString(), "ログインを諦めてアプリケーションを終了", null, null, null);
                            Application.Exit();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                注文共通.Exception共通(ex, new List<Cエラー関連変数>());
            }
            finally
            {
                BulkCopyExecLog.ExecLogFlush();
            }
        }

        public void Tick_1sec()
        {
            try
            {
                BulkCopyExecLog.InsertExecLog(処理区分.Tick.ToString(), "1sec", null, null, null);

                OANDAv1.Rate取得WMA計算();
            }
            catch (Exception ex)
            {
                注文共通.Exception共通(ex, new List<Cエラー関連変数>());
                throw;
            }
            finally
            {
                BulkCopyExecLog.ExecLogFlush();
            }
        }

        public void Tick_4sec()
        {
            try
            {
                BulkCopyExecLog.InsertExecLog(処理区分.Tick.ToString(), "4sec", null, null, null);

                OANDAv1.Order_Ver6();
            }
            catch (Exception ex)
            {
                OANDAv1.FXサーバ障害時のException(ex);
                throw;
            }
            finally
            {
                BulkCopyExecLog.ExecLogFlush();
            }
        }

        private static int Tick_3min_orderCount;
        public void Tick_3min()
        {
            try
            {
                BulkCopyExecLog.InsertExecLog(処理区分.Tick.ToString(), "3min", null, null, null);

                FormData.TradeApi.保持ポジション更新(FormData.通貨ぺア別取引状況);

                if (FormData.chk注文状態記録まで注文はスキップ == false)
                {
                    OANDAv1._3分以上経っている注文は削除(out Tick_3min_orderCount);
                }

                OANDAv1.DB記録_Trade_ポジション数更新_注文禁止Rate幅更新();

                pfmc.InsertポジションMin3(Tick_3min_orderCount, FormData.Oanda保持ポジション.Count());

                //C共通.Z_取引単位を調整する(txt口座種別_Text, txt出金可能額で調整したロスカット余剰金_Text, ref dgv注文設定);


                //FormData.txt決算待ちポジション数_Text = OANDAv1.現在保有しているポジション数();

                OANDAv1.DB記録_Transaction();
            }
            catch (Exception ex)
            {
                注文共通.Exception共通(ex, new List<Cエラー関連変数>());
                throw;
            }
            finally
            {
                BulkCopyExecLog.ExecLogFlush();
            }
        }

        public void Tick_10min()
        {
            try
            {
                BulkCopyExecLog.InsertExecLog(処理区分.Tick.ToString(), "10min", null, null, null);

                if (FormData.システム設定_Trade時間内 == "時間外")
                {
                    if (FormData.ログイン表示 == "ログイン中")
                    {
                        //FXCMv1.ログアウト();
                        return;
                    }
                }
                else if (注文共通.取引可能時間帯())
                {
                    if (FormData.ログイン表示 == "")
                    {
                        OANDAv1.ログイン_Order開始();
                        注文共通.自動取引開始終了();
                    }
                }

                if (FormData.chk注文状態記録まで注文はスキップ == false)
                {
                    注文共通461.BS終了_再処理(DateTime.Now.AddMinutes(-25));
                }
            }
            catch (Exception ex)
            {
                FormData.ToolStripStsLbl = "Exceptionエラーが発生しました。 " + ex.Message;
                FormData.ToolStripStsLbl_BackColor = Color.Red;
                注文共通.Exception共通(ex, new List<Cエラー関連変数>());
                throw;
            }
            finally
            {
                BulkCopyExecLog.ExecLogFlush();
            }
        }

        public void Tick_1h()
        {
            try
            {
                BulkCopyExecLog.InsertExecLog(処理区分.Tick.ToString(), "1h", null, null, null);

                OANDAv1.DB記録_Account();

                注文共通.データ不足判定_更新();

                //注文共通.先月当月利益更新(cn);

                if (FormData.chk注文状態記録まで注文はスキップ == false)
                {
                    OANDAv1.マイナスInterestが記録された通貨ペアで利益が出ているポジションはクローズ();
                }

                pfmc.InsertポジションHourly();

                if (DateTime.Now.Hour == 4)
                {
                    // 毎朝4時

                    if (FormData.chk手動登録したSwapに反するポジションは自動クローズする)
                    {
                        if (FormData.chk注文状態記録まで注文はスキップ == false)
                        {
                            OANDAv1.手動登録したSwapに反するポジションは自動クローズする();
                        }
                    }
                }
                else if (DateTime.Now.Hour == 5)
                {
                    // 毎朝5時

                    BulkCopyExecLog.InsertExecLog(処理区分.Tick.ToString(), "1h", null, "AM 5", null);

                    if (FormData.chk注文状態記録まで注文はスキップ == false)
                    {
                        OANDAv1.利益が出ているポジションは全てクローズする();

                        foreach (var 通貨ぺア取引状況 in FormData.通貨ぺア別取引状況.Where(x => x.Chkデータ生成 == true))
                        {
                            try
                            {
                                if (通貨ぺア取引状況.保持ポジション == "")
                                    continue;

                                OANDAv1.保持ポジションのリミット初期化(通貨ぺア取引状況);
                            }
                            catch (Exception ex)
                            {
                                List<Cエラー関連変数> Cエラー関連変数List = new List<Cエラー関連変数>();
                                Cエラー関連変数List.Add(new Cエラー関連変数() { 変数名 = "通貨ペアNo", 値 = 通貨ぺア取引状況.通貨ペアNo.ToString() });
                                注文共通.Exception共通(ex, Cエラー関連変数List);
                            }
                        }
                    }
                }
                else if (5 < DateTime.Now.Hour && DateTime.Now.Hour < 9)
                {
                    // 毎朝6時～8時

                    BulkCopyExecLog.InsertExecLog(処理区分.Tick.ToString(), "1h", null, "AM 6 ～ AM 8", null);

                    if (DateTime.Now.Hour == 7)
                    {
                        // 毎朝7時

                        BulkCopyExecLog.InsertExecLog(処理区分.Tick.ToString(), "1h", null, "AM 7 plus", null);

                        OANDAv1.マイナスInstrument更新(true);
                    }
                    else if (DateTime.Now.Hour == 8)
                    {
                        // 毎朝8時

                        BulkCopyExecLog.InsertExecLog(処理区分.Tick.ToString(), "1h", null, "AM 8 plus", null);

                        if (FormData.毎朝の自動注文開始を行う == 毎朝の自動注文開始を行う.する)
                        {
                            FormData.chk15mデータ生成以降の処理をスキップ = false;
                            FormData.chk注文状態記録まで注文はスキップ = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OANDAv1.FXサーバ障害時のException(ex);
                throw;
            }
            finally
            {
                BulkCopyExecLog.ExecLogFlush();
            }
        }

        public void Tick_1day()
        {
            try
            {
                BulkCopyExecLog.InsertExecLog(処理区分.Tick.ToString(), "1day", null, null, null);

                OANDAv1.通貨ペアSwap更新();

                if (FormData.MasterSlave == MasterSlave.Slave)
                {
                    FormData.当日注文数 = oder.Cnt当日注文数(注文共通.Get当日の開始日時(DateTime.Now));
                }
            }
            catch (Exception ex)
            {
                OANDAv1.FXサーバ障害時のException(ex);
                throw;
            }
            finally
            {
                BulkCopyExecLog.ExecLogFlush();
            }
        }

        public void Closing()
        {
            try
            {
                注文共通.自動取引開始終了();

                //FXCMv1.Logout();
            }
            catch (Exception ex)
            {
                注文共通.Exception共通(ex, new List<Cエラー関連変数>());
                注文共通.全Timerを停止();
            }
        }
    }
}
