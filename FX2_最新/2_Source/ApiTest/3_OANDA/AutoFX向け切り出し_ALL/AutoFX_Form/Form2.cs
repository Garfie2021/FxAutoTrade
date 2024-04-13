using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Reflection;
using System.Xml;


namespace AutoFX_Form
{
    public partial class Form2 : Form
    {
		#region メンバ変数

		private const string TestInstrument = "EUR_USD";
		private int _accountId { get { return Credentials.GetDefaultCredentials().DefaultAccountId; } }
		private TestResults _results = new TestResults();
		private List<InstrumentOANDA> _instruments;
		private bool _marketHalted;

		#endregion

		#region publicメソッド

		public Form2()
		{
			InitializeComponent();
		}

		#endregion

		#region privateメソッド

		private bool VerifyDefaultData<T>(T entry)
		{
			var fields = entry.GetType().GetTypeInfo().DeclaredFields.Where(x => x.Name.StartsWith("Has") && x.FieldType == typeof(bool));
			foreach (var field in fields)
			{
				bool isOptional = (null != field.GetCustomAttribute(typeof(IsOptionalAttribute)));
				bool valueIsPresent = (bool)field.GetValue(entry);
				// Data should be present iff it is not optional
				if (isOptional == valueIsPresent)
				{
					return false;
				}
			}
			return true;
		}

		private void VerifyPosition(Position position)
		{
			_results.Verify(position.units > 0, "Position has units");
			_results.Verify(position.avgPrice > 0, "Position has avgPrice");
			_results.Verify(!string.IsNullOrEmpty(position.side), "Position has direction");
			_results.Verify(!string.IsNullOrEmpty(position.instrument), "Position has instrument");
		}

		private bool VerifyAllData<T>(T entry)
		{
			var fields = entry.GetType().GetTypeInfo().DeclaredFields.Where(x => x.Name.StartsWith("Has") && x.FieldType == typeof(bool));
			foreach (var field in fields)
			{
				if ((bool)field.GetValue(entry) == false)
				{
					Console.WriteLine("Fail: " + field.Name + " is missing.");
					return false;
				}
			}
			return true;
		}

		private void PlaceMarketOrder()
		{
			if (!_marketHalted)
			{
				// create new market order
				var request = new Dictionary<string, string>
					{
						{"instrument", TestInstrument},
						{"units", "1"},
						{"side", "buy"},
						{"type", "market"},
						{"price", "1.0"}
					};
				var response = Rest.PostOrderAsync(_accountId, request);
				// We're assuming we don't already have a position on the sell side
				_results.Verify(response.tradeOpened != null && response.tradeOpened.id > 0, "Trade successfully placed");
			}
			else
			{
				Console.WriteLine("Skipping: Market open test because market is halted");
			}
		}

		private void RunInstrumentListTest()
        {
            // Get an instrument list (basic)
            var result = Rest.GetInstrumentsAsync(_accountId);
            _results.Verify(result.Count > 0, "Instrument list received");
            foreach (var entry in result)
            {
                _results.Verify(VerifyDefaultData(entry), "Checking instrument data for " + entry.instrument);
            }
            // Store the instruments for other tests
            _instruments = result;
        }

		private void RunPricesTest()
		{
			// Get a price list (basic, all instruments)
			var result = Rest.GetRatesAsync(_instruments);
			_results.Verify(result.Count == _instruments.Count, "Price returned for all " + _instruments.Count + " instruments");
			foreach (var price in result)
			{
				_results.Verify(!string.IsNullOrEmpty(price.instrument), "price has instrument");
				_results.Verify(price.ask > 0 && price.bid > 0, "Seemingly valid rates for instrument " + price.instrument);
			}
		}

		private void RunRatesTest()
		{
			RunPricesTest();
			//new CandlesTest(_results).Run();
		}

		private void RunAccountsTest()
		{
			// Get Account List
			List<Account> result;
			List<Account> result2;
			if (Credentials.GetDefaultCredentials().IsSandbox)
			{
				result = Rest.GetAccountListAsync(Credentials.GetDefaultCredentials().Username);
			}
			else
			{
				result = Rest.GetAccountListAsync();
				result2 = Rest.GetAccountListAsync("mm712140");
			}
			_results.Verify(result.Count > 0, "Accounts are returned");
			foreach (var account in result)
			{
				_results.Verify(VerifyDefaultData(account), "Checking account data for " + account.accountId);
				// Get Account Information
				var accountDetails = Rest.GetAccountDetailsAsync(account.accountId);
				_results.Verify(VerifyAllData(accountDetails), "Checking account details data for " + account.accountId);
			}
		}

		private void RunOrdersTest()
		{

			// 2013-12-06T20:36:06Z
			var expiry = DateTime.Now.AddMonths(1);
			// XmlConvert.ToDateTime and ToString can be used for going to/from RCF3339
			string expiryString = XmlConvert.ToString(expiry, XmlDateTimeSerializationMode.Utc);

			// create new pending order
			var request = new Dictionary<string, string>
				{
					{"instrument", TestInstrument},
					{"units", "1"},
					{"side", "buy"},
					{"type", "marketIfTouched"},
					{"expiry", expiryString},
					{"price", "1.0"}
				};
			var response = Rest.PostOrderAsync(_accountId, request);
			_results.Verify(response.orderOpened != null && response.orderOpened.id > 0, "Order successfully opened");
			// Get open orders
			var orders = Rest.GetOrderListAsync(_accountId);

			// Get order details
			if (orders.Count == 0)
			{
				Console.WriteLine("Error: No orders to request details for...");
			}
			else
			{
				var order = Rest.GetOrderDetailsAsync(_accountId, orders[0].id);
				_results.Verify(order.id > 0, "Order details retrieved");
			}

			// Modify an Existing order
			request["units"] += 10;
			var patchResponse = Rest.PatchOrderAsync(_accountId, orders[0].id, request);
			_results.Verify(patchResponse.id > 0 && patchResponse.id == orders[0].id && patchResponse.units.ToString() == request["units"], "Order patched");

			// close an order
			var deletedOrder = Rest.DeleteOrderAsync(_accountId, orders[0].id);
			_results.Verify(deletedOrder.id > 0 && deletedOrder.units == patchResponse.units, "Order deleted");
		}

		private void RunTradesTest()
		{
			// trade tests
			PlaceMarketOrder();

			// get list of open trades
			var openTrades = Rest.GetTradeListAsync(_accountId);
			_results.Verify(openTrades.Count > 0 && openTrades[0].id > 0, "Trades list retrieved");
			if (openTrades.Count > 0)
			{
				// get details for a trade
				var tradeDetails = Rest.GetTradeDetailsAsync(_accountId, openTrades[0].id);
				_results.Verify(tradeDetails.id > 0 && tradeDetails.price > 0 && tradeDetails.units != 0, "Trade details retrieved");

				// Modify an open trade
				var request = new Dictionary<string, string>
					{
						{"stopLoss", "0.4"}
					};
				var modifiedDetails = Rest.PatchTradeAsync(_accountId, openTrades[0].id, request);
				_results.Verify(modifiedDetails.id > 0 && Math.Abs(modifiedDetails.stopLoss - 0.4) < float.Epsilon, "Trade modified");

				if (!_marketHalted)
				{
					// close an open trade
					var closedDetails = Rest.DeleteTradeAsync(_accountId, openTrades[0].id);
					_results.Verify(closedDetails.id > 0, "Trade closed");
					_results.Verify(!string.IsNullOrEmpty(closedDetails.time), "Trade close details time");
					_results.Verify(!string.IsNullOrEmpty(closedDetails.side), "Trade close details side");
					_results.Verify(!string.IsNullOrEmpty(closedDetails.instrument), "Trade close details instrument");
					_results.Verify(closedDetails.price > 0, "Trade close details price");
					_results.Verify(closedDetails.profit != 0, "Trade close details profit");
				}
				else
				{
					Console.WriteLine("Skipping: Trade delete test because market is halted");
				}
			}
			else
			{
				Console.WriteLine("Skipping: Trade details test because no trades were found");
				Console.WriteLine("Skipping: Trade modify test because no trades were found");
				Console.WriteLine("Skipping: Trade delete test because no trades were found");
			}
		}

		private void RunPositionsTest()
		{
			if (!_marketHalted)
			{
				// Make sure there's a position to test
				PlaceMarketOrder();

				// get list of open positions
				var positions = Rest.GetPositionsAsync(_accountId);
				_results.Verify(positions.Count > 0, "Positions retrieved");
				foreach (var position in positions)
				{
					VerifyPosition(position);
				}

				// get position for a given instrument
				var onePosition = Rest.GetPositionAsync(_accountId, TestInstrument);
				VerifyPosition(onePosition);

				// close a whole position
				var closePositionResponse = Rest.DeletePositionAsync(_accountId, TestInstrument);
				_results.Verify(closePositionResponse.ids.Count > 0 && closePositionResponse.instrument == TestInstrument, "Position closed");
				_results.Verify(closePositionResponse.totalUnits > 0 && closePositionResponse.price > 0, "Position close response seems valid");
			}
			else
			{
				Console.WriteLine("Skipping: Position test because market is halted");
			}
		}

		private void RunTransactionsTest()
		{
			// transaction tests

			// Get transaction history basic
			var result = Rest.GetTransactionListAsync(_accountId);
			_results.Verify(result.Count > 0, "Recent transactions retrieved");
			foreach (var transaction in result)
			{
				_results.Verify(transaction.id > 0, "Transaction has id");
				_results.Verify(!string.IsNullOrEmpty(transaction.type), "Transation has type");
			}
			var parameters = new Dictionary<string, string> { { "count", "500" } };
			result = Rest.GetTransactionListAsync(_accountId, parameters);
			_results.Verify(result.Count == 500, "Recent transactions retrieved");
			foreach (var transaction in result)
			{
				_results.Verify(transaction.id > 0, "Transaction has id");
				_results.Verify(!string.IsNullOrEmpty(transaction.type), "Transation has type");
			}

			// Get details for a transaction
			var trans = Rest.GetTransactionDetailsAsync(_accountId, result[0].id);
			_results.Verify(trans.id == result[0].id, "Transaction details retrieved");

			//if (!Credentials.GetDefaultCredentials().IsSandbox)
			//{	// Not available on sandbox
			//	// Get Full account history
			//	var fullHistory = Rest.GetFullTransactionHistoryAsync(_accountId);
			//	_results.Verify(fullHistory.Count > 0, "Full transaction history retrieved");
			//}
		}

		private bool IsMarketHalted()
		{
			var eurusd = _instruments.Where(x => x.instrument == TestInstrument).ToList();
			var rates = Rest.GetRatesAsync(eurusd);
			return rates[0].status == "halted";
		}

		#endregion

		#region イベント

		private void btn通貨ペア取得_Click(object sender, EventArgs e)
        {
            if (Credentials.GetDefaultCredentials().HasServer(EServer.Rates))
            {
                RunInstrumentListTest();
            }
        }

		private void btnRate取得_Click(object sender, EventArgs e)
		{
			if (Credentials.GetDefaultCredentials().HasServer(EServer.Rates))
			{
				RunInstrumentListTest();

				_marketHalted = IsMarketHalted();

				RunRatesTest();
			}
		}

        private void btnアカウント情報取得_Click(object sender, EventArgs e)
        {
			if (Credentials.GetDefaultCredentials().HasServer(EServer.Account))
			{
				// Accounts
				RunAccountsTest();
			}
        }

		private void btnOrders_Click(object sender, EventArgs e)
		{
			if (Credentials.GetDefaultCredentials().HasServer(EServer.Account))
			{
				// Orders
				RunOrdersTest();
			}
		}

		private void btnTrades_Click(object sender, EventArgs e)
		{
			if (Credentials.GetDefaultCredentials().HasServer(EServer.Account))
			{
				// Trades
				RunTradesTest();
			}
		}

		private void btnPositions_Click(object sender, EventArgs e)
		{
			if (Credentials.GetDefaultCredentials().HasServer(EServer.Account))
			{
				// Positions
				RunPositionsTest();
			}
		}

		private void btnTransactions_Click(object sender, EventArgs e)
		{
			if (Credentials.GetDefaultCredentials().HasServer(EServer.Account))
			{
				// Transaction History
				RunTransactionsTest();
			}
		}

		#endregion
	}
}
