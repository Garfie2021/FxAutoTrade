using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 定数;

namespace Common
{
    public class Instrument
    {
        public byte No;
        public string instrument;
        public bool Chkデータ生成;
        public bool Chk注文;
        public FX定数.Company Company;
        public double 維持証拠金;

        public string pip;
        public int pipLocation;
        public int extraPrecision;
    }

    public class Price
    {
        public string instrument { get; set; }
        public DateTime time;
        public double bid { get; set; }
        public double ask { get; set; }
    }

    public class PricesResponse
    {
        public long time { get; set; }
        public List<Price> prices { get; set; }
    }

    public class DG
	{
		public byte 通貨ペアNo;
		public string 通貨ペア名;
		public string 取引状況;
		public string 保持ポジション;
		public double 売りSwap;
		public double 買いSwap;
		public string Swap判定;
		public double 売りRate;
		public double 買いRate;
		public string WMA前_15m;
		public string WMA今_15m;
		public string WMA上昇角度_今_15m;
		public string WMA判定_15m;
		public string BS判定_前;
		public string BS判定_今;
		public int ポジション数;
		public int ポジション増加数;
		public double リミット;
		public int 維持証拠金;
		public int 維持証拠金小計;
		public bool Chkデータ生成;
		public bool Chk注文;
		public string QuoteID;
	}

    public class Cエラー関連変数
    {
        public string 変数名;
        public string 値;
    }

}
