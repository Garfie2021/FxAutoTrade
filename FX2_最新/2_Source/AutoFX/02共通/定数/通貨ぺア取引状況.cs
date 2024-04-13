using System;
using System.Drawing;

namespace 定数
{
    public class FXCM固有
    {
        public uint OffersID = 0;
        public string QuoteID = null;
    }

    public class 通貨ぺア取引状況
    {
        public bool Chkデータ生成 = false;
        public bool Chk注文 = false;

        // 旧Instrumentクラス
        //public byte No = 0;
        public string Instrument = "";      // 111/YYY形式
        public string Instrument2 = "";     // 111_YYY形式
                                            //public Company Company;
        public double 維持証拠金 = 0.0;
        public double 証拠金倍率 = 0.0;  // 通貨ペア毎の維持証拠金から求めた注文単位の倍率

        public int 注文単位を割る値 = 0;
        public int 注文単位 = 0;

        public string pip = "";
        public int pipLocation = 0;
        public int extraPrecision = 0;

        //public byte No;
        public byte 通貨ペアNo;
        //public string 通貨ペア名;
        public string 取引状況 = "";
        public string 保持ポジション = "";    // B/S/スペース
        public double 売りSwap = 0.0;
        public double 買いSwap = 0.0;
        public string Swap判定 = "";          // B/S/スペース
        public double 売りRate = 0.0;
        public double 買いRate = 0.0;
        public byte Rateの少数点桁数 = 0;

        public string BS_WMA判定_15m = "";         // B/S/スペース
        public string BS判定_前 = "";              // B/スペース
        public string BS判定_今 = "";              // B/スペース
        public DateTime BS開始_禁止時間 = DateTime.MinValue;
        public DateTime BS開始_リミット拡張はこの日時以降まで禁止 = DateTime.MinValue;

        public double? 買いWMAs14;
        public double? 買いWMAs14上昇角度;
        public double? 買いWMAs14上昇角度シグマ;
        public double? 売りWMAs14;
        public double? 売りWMAs14上昇角度;
        public double? 売りWMAs14上昇角度シグマ;
        public string 売買判定 = "";      // B/S/スペース
        public string BS判定_15m = "";    // B/スペース
        public bool? 売買;
        public bool? BS開始;
        public object OpenOrderID;

        public DateTime 最終注文日時;
        public DateTime ポジションClose最終日時;

        public double? WMA判定_Month1_買いWMAs2;
        public double? WMA判定_Month1_買いWMAs14;
        public double? WMA判定_Month1_売りWMAs2;
        public double? WMA判定_Month1_売りWMAs14;
        public double? WMA判定_Month1_買いWMAs2角度;
        public double? WMA判定_Month1_売りWMAs2角度;
        public double? WMA判定_Week1_買いWMAs2;
        public double? WMA判定_Week1_買いWMAs14;
        public double? WMA判定_Week1_売りWMAs2;
        public double? WMA判定_Week1_売りWMAs14;
        public double? WMA判定_Week1_買いWMAs2角度;
        public double? WMA判定_Week1_売りWMAs2角度;
        public double? WMA判定_Day1_買いWMAs2;
        public double? WMA判定_Day1_買いWMAs14;
        public double? WMA判定_Day1_売りWMAs2;
        public double? WMA判定_Day1_売りWMAs14;
        public double? WMA判定_Day1_買いWMAs2角度;
        public double? WMA判定_Day1_売りWMAs2角度;
        public double? WMA判定_Hour1_買いWMAs2;
        public double? WMA判定_Hour1_買いWMAs14;
        public double? WMA判定_Hour1_売りWMAs2;
        public double? WMA判定_Hour1_売りWMAs14;
        public double? WMA判定_Hour1_買いWMAs2角度;
        public double? WMA判定_Hour1_売りWMAs2角度;
        public double? WMA判定_Min15_買いWMAs2;
        public double? WMA判定_Min15_買いWMAs14;
        public double? WMA判定_Min15_売りWMAs2;
        public double? WMA判定_Min15_売りWMAs14;
        public double? WMA判定_Min15_買いWMAs2角度;
        public double? WMA判定_Min15_売りWMAs2角度;
        public double? WMA判定_Min5_買いWMAs2;
        public double? WMA判定_Min5_買いWMAs14;
        public double? WMA判定_Min5_売りWMAs2;
        public double? WMA判定_Min5_売りWMAs14;
        public double? WMA判定_Min5_買いWMAs2角度;
        public double? WMA判定_Min5_売りWMAs2角度;
        public double? WMA判定_Min1_買いWMAs2;
        public double? WMA判定_Min1_買いWMAs14;
        public double? WMA判定_Min1_売りWMAs2;
        public double? WMA判定_Min1_売りWMAs14;
        public double? WMA判定_Min1_買いWMAs2角度;
        public double? WMA判定_Min1_売りWMAs2角度;

        /// <returns>true：15mの一致　false：</returns>
        public double? ChkGC逆判定_Month1_買いWMAs2;
        public double? ChkGC逆判定_Month1_買いWMAs14;
        public double? ChkGC逆判定_Month1_売りWMAs2;
        public double? ChkGC逆判定_Month1_売りWMAs14;
        public string ChkGC逆判定_Month1_売買判定;     // B/S/スペース
        public double? ChkGC逆判定_Week1_買いWMAs2;
        public double? ChkGC逆判定_Week1_買いWMAs14;
        public double? ChkGC逆判定_Week1_売りWMAs2;
        public double? ChkGC逆判定_Week1_売りWMAs14;
        public string ChkGC逆判定_Week1_売買判定;      // B/S/スペース
        public double? ChkGC逆判定_Day1_買いWMAs2;
        public double? ChkGC逆判定_Day1_買いWMAs14;
        public double? ChkGC逆判定_Day1_売りWMAs2;
        public double? ChkGC逆判定_Day1_売りWMAs14;
        public string ChkGC逆判定_Day1_売買判定;       // B/S/スペース
        public double? ChkGC逆判定_Hour1_買いWMAs2;
        public double? ChkGC逆判定_Hour1_買いWMAs14;
        public double? ChkGC逆判定_Hour1_売りWMAs2;
        public double? ChkGC逆判定_Hour1_売りWMAs14;
        public string ChkGC逆判定_Hour1_売買判定;      // B/S/スペース
        public double? ChkGC逆判定_Min15_買いWMAs2;
        public double? ChkGC逆判定_Min15_買いWMAs14;
        public double? ChkGC逆判定_Min15_売りWMAs2;
        public double? ChkGC逆判定_Min15_売りWMAs14;
        public string ChkGC逆判定_Min15_売買判定;      // B/S/スペース
        public double? ChkGC逆判定_Min5_買いWMAs2;
        public double? ChkGC逆判定_Min5_買いWMAs14;
        public double? ChkGC逆判定_Min5_売りWMAs2;
        public double? ChkGC逆判定_Min5_売りWMAs14;
        public string ChkGC逆判定_Min5_売買判定;       // B/S/スペース
        public double? ChkGC逆判定_Min1_買いWMAs2;
        public double? ChkGC逆判定_Min1_買いWMAs14;
        public double? ChkGC逆判定_Min1_売りWMAs2;
        public double? ChkGC逆判定_Min1_売りWMAs14;
        public string ChkGC逆判定_Min1_売買判定;       // B/S/スペース

        public bool データ不足_Min15 = true;
        public bool データ不足_Week1 = true;
        public bool データ不足_Month1 = true;

        public int? Unit数 = 0;
        public int ポジション数 = 0;

        public double? 注文禁止Rate幅_基準値;
        public double? 注文禁止Rate幅;
        public double? 買い売りRate差 = null;
        public double? 差分ストップ = null;
        public double? 差分リミット通常 = null;
        public double? 差分リミットBS = null;
        public double? ポジション追加_成行_リミット = null;
        public double? ポジション追加_成行_ストップ = null;
        public string ポジション追加時のリミット = null;

        public bool マイナスInstrument = false;

        //public double 維持証拠金;
        public double 維持証拠金小計 = 0.0;
        //public bool Chkデータ生成;
        //public bool Chk注文;
        public Color DefaultCellStyle_BackColor;

        public FXCM固有 FXCM固有;

        // Oanda固有
        //public string InstrumentOanda = "";
        public OandaInstrument OandaInstrument = null;
        public string OandaPositionSide = null;
    }
}
