﻿using System.Collections.Generic;

namespace 定数
{
    public class TradesResponse
    {
        public List<TradeData> trades;
        public string nextPage;
    }

    public class DeleteTradeResponse //: Response
    {
        public long id { get; set; }
        public double price { get; set; }
        public string instrument { get; set; }
        public double profit { get; set; }
        public string side { get; set; }
        public string time { get; set; }
    }

    public class TradeData //: Response
    {
        public long id { get; set; }
        public string side { get; set; }
        public string instrument { get; set; }
        public string time { get; set; }
        public double price { get; set; }
        public int units { get; set; }
        public double takeProfit { get; set; }
        public double stopLoss { get; set; }
        public int trailingStop { get; set; }
        public double trailingAmount { get; set; }
    }
}
