using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFX_Form
{
	public class PositionsResponse
	{
		public List<Position> positions;
	}

	public class DeletePositionResponse : Response
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
