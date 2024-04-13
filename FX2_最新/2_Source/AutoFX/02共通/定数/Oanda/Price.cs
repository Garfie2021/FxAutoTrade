using System.Collections.Generic;

namespace 定数
{
    public class PricesResponse
    {
        public long time;
        public List<Price> prices;
    }

    public class Price
    {
        public enum State
        {
            Default,
            Increasing,
            Decreasing
        };

        public string instrument { get; set; }
        public string time;
        public double bid { get; set; } // 買いRate
        public double ask { get; set; } // 売りRate
        public string status;
        public State state = State.Default;

        public void update(Price update)
        {
            if (this.bid > update.bid)
            {
                state = State.Decreasing;
            }
            else if (this.bid < update.bid)
            {
                state = State.Increasing;
            }
            else
            {
                state = State.Default;
            }

            this.bid = update.bid;
            this.ask = update.ask;
            this.time = update.time;
        }
    }
}
