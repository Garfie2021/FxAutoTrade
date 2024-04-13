using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Windows.Forms;
using 定数;
using 共通Data;

namespace OANDAv1
{
    public class TradeApiOanda : I_TradeApi
    {
        #region publicメソッド

        public void 利益が出ているポジションは全てクローズする()
        {
            OANDAv1.利益が出ているポジションは全てクローズする();
        }

        public void Swapに反しているいるBSポジションは全てクローズする(通貨ぺア取引状況 通貨ぺア取引状況)
        {
            OANDAv1.Swapに反しているいるBSポジションは全てクローズする(通貨ぺア取引状況);
        }

        public void 保持ポジションのリミット初期化_BS終了時(通貨ぺア取引状況 通貨ぺア取引状況)
        {
            OANDAv1.保持ポジションのリミット初期化_BS終了時(通貨ぺア取引状況);
        }

        public void 保持ポジション更新(List<通貨ぺア取引状況> 通貨ぺア別取引状況)
        {
            OANDAv1.保持ポジション更新(通貨ぺア別取引状況);
        }

        public bool Chk逆ポジション(通貨ぺア取引状況 通貨ぺア取引状況)
        {
            return OANDAv1.Chk逆ポジション(通貨ぺア取引状況);
        }

        //public void 特定通貨ペアのリミット幅を拡張する(OrderData orderData, 通貨ぺア取引状況 通貨ぺア取引状況)
        //{
        //    OANDAv1.特定通貨ペアのリミット幅を拡張する(orderData, 通貨ぺア取引状況);
        //}

        public bool Chk近似Rateにポジション有り(通貨ぺア取引状況 通貨ぺア取引状況)
        {
            return OANDAv1.Chk近似Rateにポジション有り(通貨ぺア取引状況);
        }

        public bool 直近のポジションClose最終日時を再確認(string Instrument2, DateTime _3時間前, DateTime 当日StartDate)
        {
            return OANDAv1.直近のポジションClose最終日時を再確認(Instrument2, _3時間前, 当日StartDate);
        }

        public void リミット_ストップ取得(通貨ぺア取引状況 通貨ぺア取引状況)
        {
            OANDAv1.リミット_ストップ取得(通貨ぺア取引状況);
        }

        public long? ポジション追加_成行(通貨ぺア取引状況 通貨ぺア取引状況)
        {
            return OANDAv1.ポジション追加_成行(通貨ぺア取引状況);
        }

        public void 注文を全て削除()
        {
            OANDAv1.注文を全て削除();
        }

        public void 全ポジションをクローズする()
        {
            OANDAv1.全ポジションをクローズする();
        }

        public double 余剰金の割合計算()
        {
            return OANDAv1.余剰金の割合計算();
        }

        public void ポジションをクローズする(string sTradeID, int iAmount, double dRate, string sQuoteID, int iAtMarket, out object sOrderID)
        {
            sOrderID = null;
        }

        public void FormDataUpdate_dgv注文設定_初回のみ(ref DataGridView dgv注文設定)
        {
            dgv注文設定.Rows.Add(FormData.通貨ぺア別取引状況.Count());

            int i = 0;
            foreach (var 通貨ぺア別取引状況 in FormData.通貨ぺア別取引状況)
            {
                dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_通貨ペア].Value = 通貨ぺア別取引状況.Instrument;
                dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_維持証拠金].Value = 通貨ぺア別取引状況.維持証拠金;
                dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_Chkデータ生成].Value = 通貨ぺア別取引状況.Chkデータ生成;
                dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_Chk注文].Value = 通貨ぺア別取引状況.Chk注文;
                dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_買い売りRate差].Value = 通貨ぺア別取引状況.買い売りRate差;
                dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_差分リミット通常].Value = 通貨ぺア別取引状況.差分リミット通常;
                dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_差分リミットBS].Value = 通貨ぺア別取引状況.差分リミットBS;
                dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_注文禁止Rate幅].Value = 通貨ぺア別取引状況.注文禁止Rate幅;

                i++;
            }
        }

        public void FormDataUpdate_dgv注文設定(ref DataGridView dgv注文設定)
        {
            int i = 0;
            foreach (var 通貨ぺア別取引状況 in FormData.通貨ぺア別取引状況)
            {
                dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_取引状況].Value = 通貨ぺア別取引状況.取引状況;
                dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_保持ポジション].Value = 通貨ぺア別取引状況.保持ポジション;
                dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_売りSwap].Value = 通貨ぺア別取引状況.売りSwap;
                dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_買いSwap].Value = 通貨ぺア別取引状況.買いSwap;
                dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_Swap判定].Value = 通貨ぺア別取引状況.Swap判定;
                dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_売りRate].Value = 通貨ぺア別取引状況.売りRate;
                dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_買いRate].Value = 通貨ぺア別取引状況.買いRate;
                dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_BS_WMA判定_15m].Value = 通貨ぺア別取引状況.BS_WMA判定_15m;
                dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_BS判定_前].Value = 通貨ぺア別取引状況.BS判定_前;
                dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_BS判定_今].Value = 通貨ぺア別取引状況.BS判定_今;
                dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_ポジション数].Value = 通貨ぺア別取引状況.Unit数;
                dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_維持証拠金小計].Value = 通貨ぺア別取引状況.維持証拠金小計;
                dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_最終注文日時].Value = 通貨ぺア別取引状況.最終注文日時;
                dgv注文設定.Rows[i].Cells[Form定数.DGVClmNo注文設定_ポジションClose最終日時].Value = 通貨ぺア別取引状況.ポジションClose最終日時;
                dgv注文設定.Rows[i].DefaultCellStyle.BackColor = 通貨ぺア別取引状況.DefaultCellStyle_BackColor;
                i++;
            }
        }

        #endregion
    }
}
