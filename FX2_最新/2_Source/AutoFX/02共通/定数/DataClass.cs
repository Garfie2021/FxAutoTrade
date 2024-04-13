using System;


namespace 定数
{
    //public class Instrument
    //{
    //	public byte No;
    //	public string instrument;
    //	public string instrumentOanda;
    //	public bool Chkデータ生成;
    //	public bool Chk注文;
    //	public Company Company;
    //	public double 維持証拠金;

    //	public string pip;
    //	public int pipLocation;
    //	public int extraPrecision;
    //}


    public class マイナスInstrument
    {
        public long id;
        public DateTime time;
        public string instrument;
        public double interest;
    }


    public class OrderData
    {
        public DateTime now;

        public DateTime StartMonth1;
        public DateTime EndMonth1;

        public DateTime StartWeek1;
        public DateTime EndWeek1;

        public DateTime StartDay1;
        public DateTime EndDay1;

        public DateTime StartHour1;
        public DateTime EndHour1;

        public DateTime StartMin15;
        public DateTime EndMin15;

        public DateTime StartMin5;
        public DateTime EndMin5;

        public DateTime StartMin1;
        public DateTime EndMin1;

        public DateTime FXCM_Hour24前;

        //public string 通貨ペア別Rate更新用_QuoteID = "";
        //public uint 通貨ペア別Rate更新用_Cnt = 0;
    }

    public class Cエラー関連変数
    {
        public string 変数名;
        public string 値;
    }

}
