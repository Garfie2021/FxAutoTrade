using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace 定数
{
    public interface I_TradeEvent
    {
        void Start();
        void Tick_1sec();   // 日時更新
        void Tick_4sec();   // Order
        void Tick_3min();   // DB記録
        void Tick_10min();  // BS終了
        void Tick_1h();     // リミット更新など
        void Tick_1day();   // Swap更新など
        void Closing();
    }

    public interface I_TradeApi
    {
        //void 保持ポジション更新();
        //string Get保持ポジション(通貨ぺア取引状況 通貨ぺア取引状況);
        //int 現在保有しているポジション数();
        void 利益が出ているポジションは全てクローズする();
        void Swapに反しているいるBSポジションは全てクローズする(通貨ぺア取引状況 通貨ぺア取引状況);
        void 保持ポジションのリミット初期化_BS終了時(通貨ぺア取引状況 通貨ぺア取引状況);
        void 保持ポジション更新(List<通貨ぺア取引状況> 通貨ぺア別取引状況);
        bool Chk逆ポジション(通貨ぺア取引状況 通貨ぺア取引状況);
        //void 特定通貨ペアのリミット幅を拡張する(通貨ぺア取引状況 通貨ぺア取引状況);
        bool Chk近似Rateにポジション有り(通貨ぺア取引状況 通貨ぺア取引状況);	// 厳密な比較を必要としないので「買いRate」のみ比較に使う。
        bool 直近のポジションClose最終日時を再確認(string Instrument2, DateTime _3時間前, DateTime 当日StartDate);
        void リミット_ストップ取得(通貨ぺア取引状況 通貨ぺア取引状況);
        long? ポジション追加_成行(通貨ぺア取引状況 通貨ぺア取引状況);
        void 注文を全て削除();
        void 全ポジションをクローズする();
        double 余剰金の割合計算();
        void ポジションをクローズする(string sTradeID, int iAmount, double dRate, string sQuoteID, int iAtMarket, out object sOrderID);
        void FormDataUpdate_dgv注文設定_初回のみ(ref DataGridView dgv注文設定);
        void FormDataUpdate_dgv注文設定(ref DataGridView dgv注文設定);
    }
}
