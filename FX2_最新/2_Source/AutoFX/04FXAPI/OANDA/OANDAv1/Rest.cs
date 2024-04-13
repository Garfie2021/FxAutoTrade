using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Linq;
using 定数;
using 共通Data;

namespace OANDAv1
{
    public class Rest
    {
        private static Dictionary<string, string> TransactionListParam = new Dictionary<string, string>();

        public Rest()
        {
            TransactionListParam.Add("minId", "");

        }


        // Convenience helpers
        private static string Server(EServer server)
        {
            return CredentialsSt.GetDefaultCredentials().GetServer(server);
        }
        private static string AccessToken
        {
            get { return CredentialsSt.GetDefaultCredentials().AccessToken; }
        }

        /// <summary>
        /// Primary (internal) request handler
        /// </summary>
        /// <typeparam name="T">The response type</typeparam>
        /// <param name="requestString">the request to make</param> 
        /// <param name="method">method for the request (defaults to GET)</param>
        /// <param name="requestParams">optional parameters (note that if provided, it's assumed the requestString doesn't contain any)</param>
        /// <returns>response via type T</returns>
        private static HttpWebRequest MakeRequestAsync_request;
        private static string MakeRequestAsync_parameters;
        private static T MakeRequestAsync<T>(string requestString, string method = "GET", Dictionary<string, string> requestParams = null)
        {
            if (requestParams != null && requestParams.Count > 0)
            {
                MakeRequestAsync_parameters = CreateParamString(requestParams);
                requestString = requestString + "?" + MakeRequestAsync_parameters;
            }

            MakeRequestAsync_request = WebRequest.CreateHttp(requestString);
            MakeRequestAsync_request.Headers[HttpRequestHeader.Authorization] = "Bearer " + AccessToken;
            MakeRequestAsync_request.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate";
            MakeRequestAsync_request.Method = method;

            try
            {
                using (WebResponse response = MakeRequestAsync_request.GetResponse())
                {
                    var serializer = new DataContractJsonSerializer(typeof(T));
                    var stream = GetResponseStream(response);
                    return (T)serializer.ReadObject(stream);
                }
            }
            catch (WebException ex)
            {
                ログ.ログ書き出し(ex.Message + "\r\n" + ex.StackTrace);

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
        private static string MakeRequestWithBody_requestBody;
        private static HttpWebRequest MakeRequestWithBody_request;
        private static T MakeRequestWithBody<T>(string method, Dictionary<string, string> requestParams, string requestString)
        {
            // Create the body
            MakeRequestWithBody_requestBody = CreateParamString(requestParams);
            MakeRequestWithBody_request = WebRequest.CreateHttp(requestString);
            MakeRequestWithBody_request.Headers[HttpRequestHeader.Authorization] = "Bearer " + AccessToken;
            MakeRequestWithBody_request.Method = method;
            MakeRequestWithBody_request.ContentType = "application/x-www-form-urlencoded";

            using (var writer = new StreamWriter(MakeRequestWithBody_request.GetRequestStream()))
            {
                // Write the body
                writer.WriteAsync(MakeRequestWithBody_requestBody);
            }

            // Handle the response
            try
            {
                using (WebResponse response = MakeRequestWithBody_request.GetResponse())
                {
                    var serializer = new DataContractJsonSerializer(typeof(T));
                    return (T)serializer.ReadObject(response.GetResponseStream());
                }
            }
            catch (WebException ex)
            {
                ログ.ログ書き出し(ex.Message + "\r\n" + ex.StackTrace);

                var response = (HttpWebResponse)ex.Response;
                var stream = new StreamReader(response.GetResponseStream());
                var result = stream.ReadToEnd();
                throw new Exception(result);
            }
        }

        private static StringBuilder GetCommaSeparatedList_result;
        private static string GetCommaSeparatedList(List<string> items)
        {
            GetCommaSeparatedList_result = new StringBuilder();

            foreach (var item in items)
            {
                GetCommaSeparatedList_result.Append(item + ",");
            }

            return GetCommaSeparatedList_result.ToString().Trim(',');
        }

        /// <summary>
        /// Helper function to create the parameter string out of a dictionary of parameters
        /// </summary>
        /// <param name="requestParams">the parameters to convert</param>
        /// <returns>string containing all the parameters for use in requests</returns>
        private static string CreateParamString_requestBody;
        private static string CreateParamString(Dictionary<string, string> requestParams)
        {
            CreateParamString_requestBody = "";

            foreach (var pair in requestParams)
            {
                CreateParamString_requestBody += WebUtility.UrlEncode(pair.Key) + "=" + WebUtility.UrlEncode(pair.Value) + "&";
            }

            CreateParamString_requestBody = CreateParamString_requestBody.Trim('&');

            return CreateParamString_requestBody;
        }

        private static Stream GetResponseStream_stream;
        private static Stream GetResponseStream(WebResponse response)
        {
            GetResponseStream_stream = response.GetResponseStream();

            if (response.Headers["Content-Encoding"] == "gzip")
            {   // if we received a gzipped response, handle that
                GetResponseStream_stream = new GZipStream(GetResponseStream_stream, CompressionMode.Decompress);
            }

            return GetResponseStream_stream;
        }


        /// <summary>
        /// Retrieves the list of instruments available for the given account
        /// </summary>
        /// <param name="account">the account to check</param>
        /// <param name="fields">optional - the fields to request in the response</param>
        /// <param name="instrumentNames">optional - the instruments to request details for</param>
        /// <returns>List of Instrument objects with details about each instrument</returns>
        private static string GetInstrumentsAsync_requestString;
        private static string GetInstrumentsAsync_fieldsParam;
        private static string GetInstrumentsAsync_instrumentsParam;
        private static InstrumentsResponse GetInstrumentsAsync_instrumentResponse;
        private static List<OandaInstrument> GetInstrumentsAsync_instruments;
        public static List<OandaInstrument> GetInstrumentsAsync(int account, List<string> fields = null, List<string> instrumentNames = null)
        {
            GetInstrumentsAsync_requestString = Server(EServer.Rates) + "instruments?accountId=" + account;

            // TODO: make sure this works
            if (fields != null)
            {
                GetInstrumentsAsync_fieldsParam = GetCommaSeparatedList(fields);
                GetInstrumentsAsync_requestString += "&fields=" + Uri.EscapeDataString(GetInstrumentsAsync_fieldsParam);
            }

            if (instrumentNames != null)
            {
                GetInstrumentsAsync_instrumentsParam = GetCommaSeparatedList(instrumentNames);
                GetInstrumentsAsync_requestString += "&instruments=" + Uri.EscapeDataString(GetInstrumentsAsync_instrumentsParam);
            }

            GetInstrumentsAsync_instrumentResponse = MakeRequestAsync<InstrumentsResponse>(GetInstrumentsAsync_requestString);

            GetInstrumentsAsync_instruments = new List<OandaInstrument>();
            GetInstrumentsAsync_instruments.AddRange(GetInstrumentsAsync_instrumentResponse.instruments);

            return GetInstrumentsAsync_instruments;
        }

        /// <summary>
        /// Retrieves the current rate for each of a list of instruments
        /// </summary>
        /// <param name="instruments">the list of instruments to check</param>
        /// <returns>List of Price objects with the current price for each instrument</returns>
        private static StringBuilder GetRatesAsync_requestBuilder;
        private static string GetRatesAsync_requestString;
        private static PricesResponse GetRatesAsync_pricesResponse;
        private static List<Price> GetRatesAsync_prices;
        public static List<Price> GetRatesAsync(List<通貨ぺア取引状況> instruments, string since = null)
        {
            GetRatesAsync_requestBuilder = new StringBuilder(Server(EServer.Rates) + "prices?instruments=");

            foreach (var instrument in instruments)
            {
                GetRatesAsync_requestBuilder.Append(instrument.OandaInstrument.instrument + ",");
            }
            GetRatesAsync_requestString = GetRatesAsync_requestBuilder.ToString().Trim(',');
            GetRatesAsync_requestString = GetRatesAsync_requestString.Replace(",", "%2C");

            // TODO: make sure this works
            if (!string.IsNullOrEmpty(since))
            {
                GetRatesAsync_requestString += "&since=" + since;
            }

            GetRatesAsync_pricesResponse = MakeRequestAsync<PricesResponse>(GetRatesAsync_requestString);
            GetRatesAsync_prices = new List<Price>();
            GetRatesAsync_prices.AddRange(GetRatesAsync_pricesResponse.prices);

            return GetRatesAsync_prices;
        }

        /// <summary>
        /// Retrieves all the accounts belonging to the user
        /// </summary>
        /// <param name="user">the username to use -- only needed on sandbox-- otherwise identified by the token used</param>
        /// <returns>list of accounts, including basic information about the accounts</returns>
        private static string GetAccountListAsync_requestString;
        private static AccountsResponse GetAccountListAsync_result;
        public static List<OandaAccount> GetAccountListAsync(string user = "")
        {
            GetAccountListAsync_requestString = Server(EServer.Account) + "accounts";
            if (!string.IsNullOrEmpty(user))
            {
                GetAccountListAsync_requestString += "?username=" + user;
            }

            GetAccountListAsync_result = MakeRequestAsync<AccountsResponse>(GetAccountListAsync_requestString);
            return GetAccountListAsync_result.accounts;
        }

        /// <summary>
        /// Retrieves the details for a given account
        /// </summary>
        /// <param name="accountId">details will be retrieved for this account id</param>
        /// <returns>Account object containing the account details</returns>
        private static string GetAccountDetailsAsync_requestString;
        private static OandaAccount GetAccountDetailsAsync_accountDetails;
        public static OandaAccount GetAccountDetailsAsync(int accountId)
        {
            GetAccountDetailsAsync_requestString = Server(EServer.Account) + "accounts/" + accountId;

            GetAccountDetailsAsync_accountDetails = MakeRequestAsync<OandaAccount>(GetAccountDetailsAsync_requestString);
            return GetAccountDetailsAsync_accountDetails;
        }

        /// <summary>
        /// Posts an order on the given account with the given parameters
        /// </summary>
        /// <param name="account">the account to post on</param>
        /// <param name="requestParams">the parameters to use in the request</param>
        /// <returns>PostOrderResponse with details of the results (throws if if fails)</returns>
        private static string PostOrderAsync_requestString;
        public static PostOrderResponse PostOrderAsync(int account, Dictionary<string, string> requestParams)
        {
            PostOrderAsync_requestString = Server(EServer.Account) + "accounts/" + account + "/orders";
            return MakeRequestWithBody<PostOrderResponse>("POST", requestParams, PostOrderAsync_requestString);
        }

        /// <summary>
        /// Retrieves the list of open orders belonging to the account
        /// </summary>
        /// <param name="account">the account to retrieve the list for</param>
        /// <param name="requestParams">optional additional parameters for the request (name, value pairs)</param>
        /// <returns>List of Order objects (or empty list, if no orders)</returns>
        private static string GetOrderListAsync_requestString;
        private static OrdersResponse GetOrderListAsync_ordersResponse;
        private static List<Order> GetOrderListAsync_orders;
        public static List<Order> GetOrderListAsync(int account, Dictionary<string, string> requestParams = null)
        {
            GetOrderListAsync_requestString = Server(EServer.Account) + "accounts/" + account + "/orders";

            GetOrderListAsync_ordersResponse = MakeRequestAsync<OrdersResponse>(GetOrderListAsync_requestString, "GET", requestParams);

            GetOrderListAsync_orders = new List<Order>();
            GetOrderListAsync_orders.AddRange(GetOrderListAsync_ordersResponse.orders);

            return GetOrderListAsync_orders;
        }

        /// <summary>
        /// Retrieves the details for a given order ID
        /// </summary>
        /// <param name="account">the account that the order belongs to</param>
        /// <param name="orderId">the id of the order to retrieve</param>
        /// <returns>Order object containing the order details</returns>
        private static string GetOrderDetailsAsync_requestString;
        public static Order GetOrderDetailsAsync(int accountId, long orderId)
        {
            GetOrderDetailsAsync_requestString = Server(EServer.Account) + "accounts/" + accountId + "/orders/" + orderId;

            return MakeRequestAsync<Order>(GetOrderDetailsAsync_requestString);
        }

        /// <summary>
        /// Modify the specified order, updating it with the parameters provided
        /// </summary>
        /// <param name="accountId">the account the owns the order</param>
        /// <param name="orderId">the order to update</param>
        /// <param name="requestParams">the parameters to update (name, value pairs)</param>
        /// <returns>Order object containing the new details of the order (post update)</returns>
        private static string PatchOrderAsync_requestString;
        public static Order PatchOrderAsync(int accountId, long orderId, Dictionary<string, string> requestParams)
        {
            PatchOrderAsync_requestString = Server(EServer.Account) + "accounts/" + accountId + "/orders/" + orderId;
            return MakeRequestWithBody<Order>("PATCH", requestParams, PatchOrderAsync_requestString);
        }

        /// <summary>
        /// Delete the order specified
        /// </summary>
        /// <param name="accountId">the account that owns the order</param>
        /// <param name="orderId">the ID of the order to delete</param>
        /// <returns>Order object containing the details of the deleted order</returns>
        private static string DeleteOrderAsync_requestString;
        public static Order DeleteOrderAsync(int accountId, long orderId)
        {
            DeleteOrderAsync_requestString = Server(EServer.Account) + "accounts/" + accountId + "/orders/" + orderId;
            return MakeRequestAsync<Order>(DeleteOrderAsync_requestString, "DELETE");
        }

        /// <summary>
        /// Retrieves the list of open trades belonging to the account
        /// </summary>
        /// <param name="account">the account to retrieve the list for</param>
        /// <param name="requestParams">optional additional parameters for the request (name, value pairs)</param>
        /// <returns>List of TradeData objects (or empty list, if no trades)</returns>
        private static string GetTradeListAsync_requestString;
        private static TradesResponse GetTradeListAsync_tradeResponse;
        private static List<TradeData> GetTradeListAsync_trades;
        public static List<TradeData> GetTradeListAsync(int account, Dictionary<string, string> requestParams = null)
        {
            GetTradeListAsync_requestString = Server(EServer.Account) + "accounts/" + account + "/trades";
            GetTradeListAsync_tradeResponse = MakeRequestAsync<TradesResponse>(GetTradeListAsync_requestString, "GET", requestParams);

            GetTradeListAsync_trades = new List<TradeData>();
            GetTradeListAsync_trades.AddRange(GetTradeListAsync_tradeResponse.trades);

            return GetTradeListAsync_trades;
        }

        /// <summary>
        /// Retrieves the details for a given trade
        /// </summary>
        /// <param name="accountId">the account to which the trade belongs</param>
        /// <param name="tradeId">the ID of the trade to get the details</param>
        /// <returns>TradeData object containing the details of the trade</returns>
        private static string GetTradeDetailsAsync_requestString;
        private static TradeData GetTradeDetailsAsync_trade;
        public static TradeData GetTradeDetailsAsync(int accountId, long tradeId)
        {
            GetTradeDetailsAsync_requestString = Server(EServer.Account) + "accounts/" + accountId + "/trades/" + tradeId;

            GetTradeDetailsAsync_trade = MakeRequestAsync<TradeData>(GetTradeDetailsAsync_requestString);

            return GetTradeDetailsAsync_trade;
        }

        /// <summary>
        /// Modify the specified trade, updating it with the parameters provided
        /// </summary>
        /// <param name="accountId">the account that owns the trade</param>
        /// <param name="tradeId">the id of the trade to update</param>
        /// <param name="requestParams">the parameters to update (name, value pairs)</param>
        /// <returns>TradeData for the trade post update</returns>
        private static string PatchTradeAsync_requestString;
        public static TradeData PatchTradeAsync(int accountId, long tradeId, Dictionary<string, string> requestParams)
        {
            PatchTradeAsync_requestString = Server(EServer.Account) + "accounts/" + accountId + "/trades/" + tradeId;
            return MakeRequestWithBody<TradeData>("PATCH", requestParams, PatchTradeAsync_requestString);
        }

        /// <summary>
        /// Close the trade specified
        /// </summary>
        /// <param name="accountId">the account that owns the trade</param>
        /// <param name="tradeId">the ID of the trade to close</param>
        /// <returns>DeleteTradeResponse containing the details of the close</returns>
        private static string DeleteTradeAsync_requestString;
        public static DeleteTradeResponse DeleteTradeAsync(int accountId, long tradeId)
        {
            DeleteTradeAsync_requestString = Server(EServer.Account) + "accounts/" + accountId + "/trades/" + tradeId;
            return MakeRequestAsync<DeleteTradeResponse>(DeleteTradeAsync_requestString, "DELETE");
        }

        /// <summary>
        /// Retrieves the current non-zero positions for a given account
        /// </summary>
        /// <param name="accountId">positions will be retrieved for this account id</param>
        /// <returns>List of Position objects with the details for each position (or empty list iff no positions)</returns>
        private static string GetPositionsAsync_requestString;
        private static PositionsResponse GetPositionsAsync_positionResponse;
        private static List<Position> GetPositionsAsync_positions;
        public static List<Position> GetPositionsAsync(int accountId)
        {
            GetPositionsAsync_requestString = Server(EServer.Account) + "accounts/" + accountId + "/positions";

            GetPositionsAsync_positionResponse = MakeRequestAsync<PositionsResponse>(GetPositionsAsync_requestString);

            GetPositionsAsync_positions = new List<Position>();
            GetPositionsAsync_positions.AddRange(GetPositionsAsync_positionResponse.positions);

            return GetPositionsAsync_positions;
        }

        /// <summary>
        /// Retrieves the current position for the given instrument and account
        ///   This will cause an error if there is no position for that instrument
        /// </summary>
        /// <param name="accountId">the account for which to get the position</param>
        /// <param name="instrument">the instrument for which to get the position</param>
        /// <returns>Position object with the details of the position</returns>
        private static string GetPositionAsync_requestString;
        public static Position GetPositionAsync(int accountId, string instrument)
        {
            GetPositionAsync_requestString = Server(EServer.Account) + "accounts/" + accountId + "/positions/" + instrument;

            return MakeRequestAsync<Position>(GetPositionAsync_requestString);
        }

        /// <summary>
        /// Close the given position
        /// This will close all trades on the provided account/instrument
        /// </summary>
        /// <param name="accountId">the account to close trades on</param>
        /// <param name="instrument">the instrument for which to close all trades</param>
        /// <returns>DeletePositionResponse object containing details about the actions taken</returns>
        private static string DeletePositionAsync_requestString;
        public static DeletePositionResponse DeletePositionAsync(int accountId, string instrument)
        {
            DeletePositionAsync_requestString = Server(EServer.Account) + "accounts/" + accountId + "/positions/" + instrument;

            return MakeRequestAsync<DeletePositionResponse>(DeletePositionAsync_requestString, "DELETE");
        }

        /// <summary>
        /// retrieves a list of transactions in descending order
        /// </summary>
        /// <param name="account"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private static string GetTransactionListAsync_requestString;
        private static TransactionsResponse GetTransactionListAsync_dataResponse;
        private static long GetTransactionListAsync_Result;
        public static long GetTransactionListAsync(int accountId, long lastId, out List<OandaTransaction> resultList)
        {
            TransactionListParam["minId"] = lastId.ToString();

            GetTransactionListAsync_requestString = Server(EServer.Account) + "accounts/" + accountId + "/transactions";

            GetTransactionListAsync_dataResponse = MakeRequestAsync<TransactionsResponse>(GetTransactionListAsync_requestString, "GET", TransactionListParam);

            resultList = new List<OandaTransaction>();
            resultList.AddRange(GetTransactionListAsync_dataResponse.transactions);

            GetTransactionListAsync_Result = resultList.Max(x => x.id);

            if (resultList.Any(x => x.id == lastId))
            {
                // minIdのItemが含まれるので削除
                resultList.Remove(resultList.Where(x => x.id == lastId).First());
            }

            return GetTransactionListAsync_Result;
        }

        /// <summary>
        /// Retrieves the details for a given transaction
        /// </summary>
        /// <param name="accountId">the id of the account to which the transaction belongs</param>
        /// <param name="transId">the id of the transaction to retrieve</param>
        /// <returns>Transaction object with the details of the transaction</returns>
        private static string GetTransactionDetailsAsync_requestString;
        private static OandaTransaction GetTransactionDetailsAsync_transaction;
        public static OandaTransaction GetTransactionDetailsAsync(int accountId, long transId)
        {
            GetTransactionDetailsAsync_requestString = Server(EServer.Account) + "accounts/" + accountId + "/transactions/" + transId;

            GetTransactionDetailsAsync_transaction = MakeRequestAsync<OandaTransaction>(GetTransactionDetailsAsync_requestString);

            return GetTransactionDetailsAsync_transaction;
        }

        /// <summary>
        /// Expensive request to retrieve the entire transaction history for a given account
        /// This request may take some time
        /// This request is heavily rate limited
        /// This request does not work on sandbox
        /// </summary>
        /// <param name="accountId">the id of the account for which to retrieve the history</param>
        /// <returns>List of Transaction objects with the details of all transactions</returns>
        public static async Task<List<OandaTransaction>> GetFullTransactionHistoryAsync(int accountId)
        {
            // NOTE: this does not work on sandbox
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
                ログ.ログ書き出し(ex.Message + "\r\n" + ex.StackTrace);

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
                        var serializer = new DataContractJsonSerializer(typeof(List<OandaTransaction>));
                        var archive = new ZipArchive(await response.Content.ReadAsStreamAsync());
                        return (List<OandaTransaction>)serializer.ReadObject(archive.Entries[0].Open());
                    }
                    else if (response.StatusCode == HttpStatusCode.NotFound)
                    {   // Not found is expected until the resource is ready
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
                    ログ.ログ書き出し(ex.Message + "\r\n" + ex.StackTrace);

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
