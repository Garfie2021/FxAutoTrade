using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 定数;
using Common;


namespace FXCM
{
    public static class Trade共通
    {
        public static List<Instrument> 通貨ペア;
        public static FX定数.Company Company;

        public static TradeApi trade;

        public static void 初期化()
        {
            if (システム設定.CommandLine.IndexOf(FX定数.Company.FXCMJP.ToString(), StringComparison.Ordinal) > -1)
            {
                Company = FX定数.Company.FXCMJP;
                通貨ペア = 通貨ペア初期化.FXCMJP();
            }
            else if (システム設定.CommandLine.IndexOf(FX定数.Company.FXCMUK.ToString(), StringComparison.Ordinal) > -1)
            {
                Company = FX定数.Company.FXCMUK;
                通貨ペア = 通貨ペア初期化.FXCMUK();
            }
            else if (システム設定.CommandLine.IndexOf(FX定数.Company.OANDA.ToString(), StringComparison.Ordinal) > -1)
            {
                Company = FX定数.Company.OANDA;
                通貨ペア = 通貨ペア初期化.OANDA();
            }

        }
    }
}
