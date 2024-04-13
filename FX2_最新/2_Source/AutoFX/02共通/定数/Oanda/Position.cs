using System.Collections.Generic;

namespace 定数
{
    public class PositionsResponse
    {
        public List<Position> positions;
    }

    public class DeletePositionResponse //: Response
    {
        public List<long> ids { get; set; }
        public string instrument { get; set; }
        public int totalUnits { get; set; }
        public double price { get; set; }
    }

    public class Position
    {
        public string side { get; set; }
        public string instrument { get; set; }
        public int units { get; set; }
        public double avgPrice { get; set; }
    }
}
