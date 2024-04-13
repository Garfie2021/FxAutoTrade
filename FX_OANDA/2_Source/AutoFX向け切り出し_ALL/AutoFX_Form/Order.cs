using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFX_Form
{
	public class OrdersResponse
	{
		public List<Order> orders;
		public string nextPage;
	}

	public class PostOrderResponse : Response
	{
		public string instrument { get; set; }
		public string time { get; set; }
		public double? price { get; set; }

		public Order orderOpened { get; set; }
		public TradeData tradeOpened { get; set; }
		public List<Transaction> tradesClosed { get; set; } // TODO: verify this
		public Transaction tradeReduced { get; set; } // TODO: verify this
	}

	public class Order : Response
	{
		public long id { get; set; }
		public string instrument { get; set; }
		public int units { get; set; }
		public string side { get; set; }
		public string type { get; set; }
		public string time { get; set; }
		public double price { get; set; }
		public double takeProfit { get; set; }
		public double stopLoss { get; set; }
		public string expiry { get; set; }
		public double upperBound { get; set; }
		public double lowerBound { get; set; }
		public int trailingStop { get; set; }
	}
}
