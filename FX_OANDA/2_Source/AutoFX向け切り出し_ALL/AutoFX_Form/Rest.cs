using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Json;


namespace AutoFX_Form
{
    public class Rest
    {
        // Convenience helpers
        private static string Server(EServer server) { return Credentials.GetDefaultCredentials().GetServer(server); }
        private static string AccessToken { get { return Credentials.GetDefaultCredentials().AccessToken; } }

		/// <summary>
		/// Primary (internal) request handler
		/// </summary>
		/// <typeparam name="T">The response type</typeparam>
		/// <param name="requestString">the request to make</param>
		/// <param name="method">method for the request (defaults to GET)</param>
		/// <param name="requestParams">optional parameters (note that if provided, it's assumed the requestString doesn't contain any)</param>
		/// <returns>response via type T</returns>
		private static T MakeRequestAsync<T>(string requestString, string method = "GET", Dictionary<string, string> requestParams = null)
		{
			if (requestParams != null && requestParams.Count > 0)
			{
				var parameters = CreateParamString(requestParams);
				requestString = requestString + "?" + parameters;
			}
			HttpWebRequest request = WebRequest.CreateHttp(requestString);
			request.Headers[HttpRequestHeader.Authorization] = "Bearer " + AccessToken;
			request.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate";
			request.Method = method;

			try
			{
				using (WebResponse response = request.GetResponse())
				{
					var serializer = new DataContractJsonSerializer(typeof(T));
					var stream = GetResponseStream(response);
					return (T)serializer.ReadObject(stream);
				}
			}
			catch (WebException ex)
			{
				var stream = GetResponseStream(ex.Response);
				var reader = new StreamReader(stream);
				var result = reader.ReadToEnd();
				throw new Exception(result);
			}
		}

		/// <summary>
		/// Secondary (internal) request handler. differs from primary in that parameters are placed in the body instead of the request string
		/// </summary>
		/// <typeparam name="T">response type</typeparam>
		/// <param name="method">method to use (usually POST or PATCH)</param>
		/// <param name="requestParams">the parameters to pass in the request body</param>
		/// <param name="requestString">the request to make</param>
		/// <returns>response, via type T</returns>
		private static T MakeRequestWithBody<T>(string method, Dictionary<string, string> requestParams, string requestString)
		{
			// Create the body
			var requestBody = CreateParamString(requestParams);
			HttpWebRequest request = WebRequest.CreateHttp(requestString);
			request.Headers[HttpRequestHeader.Authorization] = "Bearer " + AccessToken;
			request.Method = method;
			request.ContentType = "application/x-www-form-urlencoded";

			using (var writer = new StreamWriter(request.GetRequestStream()))
			{
				// Write the body
				writer.WriteAsync(requestBody);
			}

			// Handle the response
			try
			{
				using (WebResponse response = request.GetResponse())
				{
					var serializer = new DataContractJsonSerializer(typeof(T));
					return (T)serializer.ReadObject(response.GetResponseStream());
				}
			}
			catch (WebException ex)
			{
				var response = (HttpWebResponse)ex.Response;
				var stream = new StreamReader(response.GetResponseStream());
				var result = stream.ReadToEnd();
				throw new Exception(result);
			}
		}

		private static string GetCommaSeparatedList(List<string> items)
		{
			StringBuilder result = new StringBuilder();
			foreach (var item in items)
			{
				result.Append(item + ",");
			}
			return result.ToString().Trim(',');
		}

		/// <summary>
		/// Helper function to create the parameter string out of a dictionary of parameters
		/// </summary>
		/// <param name="requestParams">the parameters to convert</param>
		/// <returns>string containing all the parameters for use in requests</returns>
		private static string CreateParamString(Dictionary<string, string> requestParams)
		{
			string requestBody = "";
			foreach (var pair in requestParams)
			{
				requestBody += WebUtility.UrlEncode(pair.Key) + "=" + WebUtility.UrlEncode(pair.Value) + "&";
			}
			requestBody = requestBody.Trim('&');
			return requestBody;
		}

		private static Stream GetResponseStream(WebResponse response)
		{
			var stream = response.GetResponseStream();
			if (response.Headers["Content-Encoding"] == "gzip")
			{   // if we received a gzipped response, handle that
				stream = new GZipStream(stream, CompressionMode.Decompress);
			}
			return stream;
		}


        /// <summary>
        /// Retrieves the list of instruments available for the given account
        /// </summary>
        /// <param name="account">the account to check</param>
        /// <param name="fields">optional - the fields to request in the response</param>
        /// <param name="instrumentNames">optional - the instruments to request details for</param>
        /// <returns>List of Instrument objects with details about each instrument</returns>
        public static List<Instrument> GetInstrumentsAsync(int account, List<string> fields = null, List<string> instrumentNames = null)
        {
            string requestString = Server(EServer.Rates) + "instruments?accountId=" + account;

            // TODO: make sure this works
            if (fields != null)
            {
                string fieldsParam = GetCommaSeparatedList(fields);
                requestString += "&fields=" + Uri.EscapeDataString(fieldsParam);
            }
            if (instrumentNames != null)
            {
                string instrumentsParam = GetCommaSeparatedList(instrumentNames);
                requestString += "&instruments=" + Uri.EscapeDataString(instrumentsParam);
            }

            InstrumentsResponse instrumentResponse = MakeRequestAsync<InstrumentsResponse>(requestString);

            List<Instrument> instruments = new List<Instrument>();
            instruments.AddRange(instrumentResponse.instruments);

            return instruments;
        }

		/// <summary>
		/// Retrieves the current rate for each of a list of instruments
		/// </summary>
		/// <param name="instruments">the list of instruments to check</param>
		/// <returns>List of Price objects with the current price for each instrument</returns>
		public static List<Price> GetRatesAsync(List<Instrument> instruments, string since = null)
		{
			StringBuilder requestBuilder = new StringBuilder(Server(EServer.Rates) + "prices?instruments=");

			foreach (var instrument in instruments)
			{
				requestBuilder.Append(instrument.instrument + ",");
			}
			string requestString = requestBuilder.ToString().Trim(',');
			requestString = requestString.Replace(",", "%2C");

			// TODO: make sure this works
			if (!string.IsNullOrEmpty(since))
			{
				requestString += "&since=" + since;
			}

			PricesResponse pricesResponse = MakeRequestAsync<PricesResponse>(requestString);
			List<Price> prices = new List<Price>();
			prices.AddRange(pricesResponse.prices);

			return prices;
		}

		/// <summary>
		/// Retrieves all the accounts belonging to the user
		/// </summary>
		/// <param name="user">the username to use -- only needed on sandbox-- otherwise identified by the token used</param>
		/// <returns>list of accounts, including basic information about the accounts</returns>
		public static List<Account> GetAccountListAsync(string user = "")
		{
			string requestString = Server(EServer.Account) + "accounts";
			if (!string.IsNullOrEmpty(user))
			{
				requestString += "?username=" + user;
			}

			var result = MakeRequestAsync<AccountsResponse>(requestString);
			return result.accounts;
		}

		/// <summary>
		/// Retrieves the details for a given account
		/// </summary>
		/// <param name="accountId">details will be retrieved for this account id</param>
		/// <returns>Account object containing the account details</returns>
		public static Account GetAccountDetailsAsync(int accountId)
		{
			string requestString = Server(EServer.Account) + "accounts/" + accountId;

			var accountDetails = MakeRequestAsync<Account>(requestString);
			return accountDetails;
		}

		/// <summary>
		/// Posts an order on the given account with the given parameters
		/// </summary>
		/// <param name="account">the account to post on</param>
		/// <param name="requestParams">the parameters to use in the request</param>
		/// <returns>PostOrderResponse with details of the results (throws if if fails)</returns>
		public static PostOrderResponse PostOrderAsync(int account, Dictionary<string, string> requestParams)
		{
			string requestString = Server(EServer.Account) + "accounts/" + account + "/orders";
			return MakeRequestWithBody<PostOrderResponse>("POST", requestParams, requestString);
		}

		/// <summary>
		/// Retrieves the list of open orders belonging to the account
		/// </summary>
		/// <param name="account">the account to retrieve the list for</param>
		/// <param name="requestParams">optional additional parameters for the request (name, value pairs)</param>
		/// <returns>List of Order objects (or empty list, if no orders)</returns>
		public static List<Order> GetOrderListAsync(int account, Dictionary<string, string> requestParams = null)
		{
			string requestString = Server(EServer.Account) + "accounts/" + account + "/orders";

			OrdersResponse ordersResponse = MakeRequestAsync<OrdersResponse>(requestString, "GET", requestParams);

			var orders = new List<Order>();
			orders.AddRange(ordersResponse.orders);

			return orders;
		}

		/// <summary>
		/// Retrieves the details for a given order ID
		/// </summary>
		/// <param name="account">the account that the order belongs to</param>
		/// <param name="orderId">the id of the order to retrieve</param>
		/// <returns>Order object containing the order details</returns>
		public static Order GetOrderDetailsAsync(int accountId, long orderId)
		{
			string requestString = Server(EServer.Account) + "accounts/" + accountId + "/orders/" + orderId;

			var order = MakeRequestAsync<Order>(requestString);

			return order;
		}

		/// <summary>
		/// Modify the specified order, updating it with the parameters provided
		/// </summary>
		/// <param name="accountId">the account the owns the order</param>
		/// <param name="orderId">the order to update</param>
		/// <param name="requestParams">the parameters to update (name, value pairs)</param>
		/// <returns>Order object containing the new details of the order (post update)</returns>
		public static Order PatchOrderAsync(int accountId, long orderId, Dictionary<string, string> requestParams)
		{
			string requestString = Server(EServer.Account) + "accounts/" + accountId + "/orders/" + orderId;
			return MakeRequestWithBody<Order>("PATCH", requestParams, requestString);
		}

		/// <summary>
		/// Delete the order specified
		/// </summary>
		/// <param name="accountId">the account that owns the order</param>
		/// <param name="orderId">the ID of the order to delete</param>
		/// <returns>Order object containing the details of the deleted order</returns>
		public static Order DeleteOrderAsync(int accountId, long orderId)
		{
			string requestString = Server(EServer.Account) + "accounts/" + accountId + "/orders/" + orderId;
			return MakeRequestAsync<Order>(requestString, "DELETE");
		}

		/// <summary>
		/// Retrieves the list of open trades belonging to the account
		/// </summary>
		/// <param name="account">the account to retrieve the list for</param>
		/// <param name="requestParams">optional additional parameters for the request (name, value pairs)</param>
		/// <returns>List of TradeData objects (or empty list, if no trades)</returns>
		public static List<TradeData> GetTradeListAsync(int account, Dictionary<string, string> requestParams = null)
		{
			string requestString = Server(EServer.Account) + "accounts/" + account + "/trades";
			TradesResponse tradeResponse = MakeRequestAsync<TradesResponse>(requestString, "GET", requestParams);

			var trades = new List<TradeData>();
			trades.AddRange(tradeResponse.trades);

			return trades;
		}

		/// <summary>
		/// Retrieves the details for a given trade
		/// </summary>
		/// <param name="accountId">the account to which the trade belongs</param>
		/// <param name="tradeId">the ID of the trade to get the details</param>
		/// <returns>TradeData object containing the details of the trade</returns>
		public static TradeData GetTradeDetailsAsync(int accountId, long tradeId)
		{
			string requestString = Server(EServer.Account) + "accounts/" + accountId + "/trades/" + tradeId;

			var trade = MakeRequestAsync<TradeData>(requestString);

			return trade;
		}

		/// <summary>
		/// Modify the specified trade, updating it with the parameters provided
		/// </summary>
		/// <param name="accountId">the account that owns the trade</param>
		/// <param name="tradeId">the id of the trade to update</param>
		/// <param name="requestParams">the parameters to update (name, value pairs)</param>
		/// <returns>TradeData for the trade post update</returns>
		public static TradeData PatchTradeAsync(int accountId, long tradeId, Dictionary<string, string> requestParams)
		{
			string requestString = Server(EServer.Account) + "accounts/" + accountId + "/trades/" + tradeId;
			return MakeRequestWithBody<TradeData>("PATCH", requestParams, requestString);
		}

		/// <summary>
		/// Close the trade specified
		/// </summary>
		/// <param name="accountId">the account that owns the trade</param>
		/// <param name="tradeId">the ID of the trade to close</param>
		/// <returns>DeleteTradeResponse containing the details of the close</returns>
		public static DeleteTradeResponse DeleteTradeAsync(int accountId, long tradeId)
		{
			string requestString = Server(EServer.Account) + "accounts/" + accountId + "/trades/" + tradeId;
			return MakeRequestAsync<DeleteTradeResponse>(requestString, "DELETE");
		}

		/// <summary>
		/// Retrieves the current non-zero positions for a given account
		/// </summary>
		/// <param name="accountId">positions will be retrieved for this account id</param>
		/// <returns>List of Position objects with the details for each position (or empty list iff no positions)</returns>
		public static List<Position> GetPositionsAsync(int accountId)
		{
			string requestString = Server(EServer.Account) + "accounts/" + accountId + "/positions";

			var positionResponse = MakeRequestAsync<PositionsResponse>(requestString);
			var positions = new List<Position>();
			positions.AddRange(positionResponse.positions);

			return positions;
		}

		/// <summary>
		/// Retrieves the current position for the given instrument and account
		///   This will cause an error if there is no position for that instrument
		/// </summary>
		/// <param name="accountId">the account for which to get the position</param>
		/// <param name="instrument">the instrument for which to get the position</param>
		/// <returns>Position object with the details of the position</returns>
		public static Position GetPositionAsync(int accountId, string instrument)
		{
			string requestString = Server(EServer.Account) + "accounts/" + accountId + "/positions/" + instrument;

			return MakeRequestAsync<Position>(requestString);
		}

		/// <summary>
		/// Close the given position
		/// This will close all trades on the provided account/instrument
		/// </summary>
		/// <param name="accountId">the account to close trades on</param>
		/// <param name="instrument">the instrument for which to close all trades</param>
		/// <returns>DeletePositionResponse object containing details about the actions taken</returns>
		public static DeletePositionResponse DeletePositionAsync(int accountId, string instrument)
		{
			string requestString = Server(EServer.Account) + "accounts/" + accountId + "/positions/" + instrument;

			return MakeRequestAsync<DeletePositionResponse>(requestString, "DELETE");
		}


		/// <summary>
		/// retrieves a list of transactions in descending order
		/// </summary>
		/// <param name="account"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		public static List<Transaction> GetTransactionListAsync(int accountId, Dictionary<string, string> parameters = null)
		{
			string requestString = Server(EServer.Account) + "accounts/" + accountId + "/transactions";

			var transactions = new List<Transaction>();
			var dataResponse = MakeRequestAsync<TransactionsResponse>(requestString, "GET", parameters);
			transactions.AddRange(dataResponse.transactions);

			return transactions;
		}

		/// <summary>
		/// Retrieves the details for a given transaction
		/// </summary>
		/// <param name="accountId">the id of the account to which the transaction belongs</param>
		/// <param name="transId">the id of the transaction to retrieve</param>
		/// <returns>Transaction object with the details of the transaction</returns>
		public static Transaction GetTransactionDetailsAsync(int accountId, long transId)
		{
			string requestString = Server(EServer.Account) + "accounts/" + accountId + "/transactions/" + transId;

			var transaction = MakeRequestAsync<Transaction>(requestString);

			return transaction;
		}

		/// <summary>
		/// Expensive request to retrieve the entire transaction history for a given account
		/// This request may take some time
		/// This request is heavily rate limited
		/// This request does not work on sandbox
		/// </summary>
		/// <param name="accountId">the id of the account for which to retrieve the history</param>
		/// <returns>List of Transaction objects with the details of all transactions</returns>
		public static async Task<List<Transaction>> GetFullTransactionHistoryAsync(int accountId)
		{	// NOTE: this does not work on sandbox
			string requestString = Server(EServer.Account) + "accounts/" + accountId + "/alltransactions";

			HttpWebRequest request = WebRequest.CreateHttp(requestString);
			request.Headers[HttpRequestHeader.Authorization] = "Bearer " + AccessToken;
			request.Method = "GET";
			string location;
			// Phase 1: request and get the location
			try
			{
				using (WebResponse response = await request.GetResponseAsync())
				{
					location = response.Headers["Location"];
				}
			}
			catch (WebException ex)
			{
				var response = (HttpWebResponse)ex.Response;
				var stream = new StreamReader(response.GetResponseStream());
				var result = stream.ReadToEnd();
				throw new Exception(result);
			}

			// Phase 2: wait for and retrieve the actual data
			HttpClient client = new HttpClient();

			//request = WebRequest.CreateHttp(location);
			for (int retries = 0; retries < 20; retries++)
			{
				try
				{
					var response = await client.GetAsync(location);
					if (response.IsSuccessStatusCode)
					{
						var serializer = new DataContractJsonSerializer(typeof(List<Transaction>));
						var archive = new ZipArchive(await response.Content.ReadAsStreamAsync());
						return (List<Transaction>)serializer.ReadObject(archive.Entries[0].Open());
					}
					else if (response.StatusCode == HttpStatusCode.NotFound)
					{	// Not found is expected until the resource is ready
						// Delay a bit to wait for the response
						await Task.Delay(500);
					}
					else
					{
						var stream = new StreamReader(await response.Content.ReadAsStreamAsync());
						var result = stream.ReadToEnd();
						throw new Exception(result);
					}
				}
				catch (WebException ex)
				{
					var response = (HttpWebResponse)ex.Response;
					var stream = new StreamReader(response.GetResponseStream());
					var result = stream.ReadToEnd();
					throw new Exception(result);
				}
			}
			return null;
		}

	}
}
