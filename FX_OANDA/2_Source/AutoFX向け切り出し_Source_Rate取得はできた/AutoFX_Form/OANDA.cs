using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.IO;
using System.Web.Script.Serialization;
using System.Net;

namespace AutoFX_Form
{
    #region データクラス

    public class AccountDetails
    {
        public int accountId;
        public string name;
        public double balance { get; set; }
        public double unrealizedPl { get; set; }
        public double nav;
        public double realizedPl { get; set; }
        public double marginUsed { get; set; }
        public double marginAvail { get; set; }
        public int openTrades;
        public int openOrders;
        public double marginRate;
        public string homecurr;
    }
    public class Price
    {
        public string instrument { get; set; }
        public DateTime time;
        public double bid { get; set; }
        public double ask { get; set; }
    }
    public class Instrument
    {
        public string instrument;
        public string displayName { get; set; }
        public string pip;
        public int pipLocation;
        public int extraPrecision;
    }
    public class PricesResponse
    {
        public long time { get; set; }
        public List<Price> prices { get; set; }
    }
    public class Position
    {
        [DisplayName("Direction")]
        public string direction { get; set; }
        [DisplayName("Instrument")]
        public string instrument { get; set; }
        [DisplayName("Units")]
        public int units { get; set; }
        [DisplayName("Average Price")]
        public double avgPrice { get; set; }
    }
    public class TradeData
    {
        [DisplayName("ID")]
        public long id { get; set; }
        [DisplayName("Units")]
        public int units { get; set; }
        [DisplayName("Side")]
        public string side { get; set; }
        [DisplayName("Instrument")]
        public string instrument { get; set; }
        [DisplayName("Time")]
        public DateTime time { get; set; }
        [DisplayName("Price")]
        public double price { get; set; }
        [DisplayName("Take Profit")]
        public double takeProfit { get; set; }
        [DisplayName("Stop Loss")]
        public double stopLoss { get; set; }
        [DisplayName("Trailing Stop")]
        public int trailingStop { get; set; }
    }
    public class Order
    {
        [DisplayName("ID")]
        public long id { get; set; }
        [DisplayName("Type")]
        public string type { get; set; }
        [DisplayName("Side")]
        public string side { get; set; }
        [DisplayName("Instrument")]
        public string instrument { get; set; }
        [DisplayName("Units")]
        public int units { get; set; }
        [DisplayName("Time")]
        public DateTime time { get; set; }
        [DisplayName("Price")]
        public double price { get; set; }
        [DisplayName("Take Profit")]
        public double takeProfit { get; set; }
        [DisplayName("Expiry")]
        public DateTime expiry { get; set; }
        [DisplayName("Upper Bound")]
        public double upperBound { get; set; }
        [DisplayName("Lower Bound")]
        public double lowerBound { get; set; }
        [DisplayName("Trailing Stop")]
        public int trailingStop { get; set; }
    }

    public class TradesResponse
    {
        public List<TradeData> trades { get; set; }
        public string nextPage { get; set; }
    }
    public class OrdersResponse
    {
        public List<Order> orders { get; set; }
        public string nextPage { get; set; }
    }
    class InstrumentsResponse
    {
        public List<Instrument> instruments { get; set; }
    }
    class PositionsResponse
    {
        public List<Position> positions { get; set; }
    }

    #endregion

    public static class OANDA
    {
        private static string s_apiServer = "https://api-fxpractice.oanda.com/";

        #region public

        /// <summary>
        /// アカウント情報取得
        /// </summary>
        /// <param name="account">the ID of the account to retrieve</param>
        /// <returns>the AccountDetails for the account</returns>
        public static AccountDetails GetAccountDetails(int account)
        {   // eg. https://oanda-cs-dev:1342/accounts/123456
            string requestString = s_apiServer + "v1/accounts/" + account;

            string responseString = MakeRequest(requestString);

            var serializer = new JavaScriptSerializer();

            var accountDetails = serializer.Deserialize<AccountDetails>(responseString);
            return accountDetails;
        }

        /// <summary>
        /// 通貨ペア取得
        /// </summary>
        /// <returns>a list of the available instruments</returns>
        public static List<Instrument> GetInstruments(int account)
        {
            string requestString = s_apiServer + "v1/instruments?accountId=" + account;

            string responseString = MakeRequest(requestString);

            var serializer = new JavaScriptSerializer();
            var instrumentResponse = serializer.Deserialize<InstrumentsResponse>(responseString);

            List<Instrument> instruments = new List<Instrument>();
            instruments.AddRange(instrumentResponse.instruments);

            return instruments;
        }


        /// <summary>
        /// 通貨ペアのRate取得
        /// </summary>
        /// <param name="instruments">The list of instruments to request</param>
        /// <returns>The list of prices</returns>
        public static List<Price> GetRates(List<Instrument> instruments)
        {
            var requestBuilder = new StringBuilder(s_apiServer + "v1/prices?instruments=");

            foreach (var instrument in instruments)
            {
                requestBuilder.Append(instrument.instrument + ",");
            }
            // Grab the string and remove the trailing comma
            string requestString = requestBuilder.ToString().Trim(',');

            string responseString = MakeRequest(requestString);

            var serializer = new JavaScriptSerializer();
            var pricesResponse = serializer.Deserialize<PricesResponse>(responseString);
            List<Price> prices = new List<Price>();
            prices.AddRange(pricesResponse.prices);

            return prices;
        }

        /// <summary>
        /// ポジション取得
        /// </summary>
        /// <param name="account">the ID of the account</param>
        /// <returns>list of positions (or empty list if there are none)</returns>
        public static List<Position> GetPositions(int account)
        {
            string requestString = s_apiServer + "v1/accounts/" + account + "/positions";

            string responseString = MakeRequest(requestString);

            var serializer = new JavaScriptSerializer();
            var positionResponse = serializer.Deserialize<PositionsResponse>(responseString);
            var positions = new List<Position>();
            positions.AddRange(positionResponse.positions);

            return positions;
        }

        /// <summary>
        /// Execute a marketOrder on the given account using the given parameters
        /// </summary>
        /// <param name="account">the ID of the account to use</param>
        /// <param name="requestParams">dictionary of parameters for the request key=Name, value=Value</param>
        public static void PostMarketOrder(int account, Dictionary<string, string> requestParams)
        {
            string requestString = s_apiServer + "v1/accounts/" + account + "/orders";

            var postData = "";
            foreach (var pair in requestParams)
            {
                postData += pair.Key + "=" + pair.Value + "&";
            }
            postData += "type=market";

            string responseString = MakeRequest(requestString, "POST", postData);
            // TODO: make use of the response
        }

        /// <summary>
        /// Gets the list of open trades for a given account
        /// </summary>
        /// <param name="account">the account ID of the account</param>
        /// <returns>list of open trades (empty list if there are none)</returns>
        public static List<TradeData> GetTradeList(int account)
        {
            string requestString = s_apiServer + "v1/accounts/" + account + "/trades";
            string responseString = MakeRequest(requestString);

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            TradesResponse tradeResponse = serializer.Deserialize<TradesResponse>(responseString);
            List<TradeData> trades = new List<TradeData>();

            trades.AddRange(tradeResponse.trades);
            // TODO: should loop through the "next pages"

            return trades;
        }

        /// <summary>
        /// Get the list of open orders for a given account
        /// </summary>
        /// <param name="account">the account ID of the account</param>
        /// <returns>list of open orders (empty list if there are none)</returns>
        public static List<Order> GetOrderList(int account)
        {
            string requestString = s_apiServer + "v1/accounts/" + account + "/orders";
            string responseString = MakeRequest(requestString);

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            OrdersResponse tradeResponse = serializer.Deserialize<OrdersResponse>(responseString);

            List<Order> orders = new List<Order>();
            orders.AddRange(tradeResponse.orders);
            // TODO: should loop through the "next pages"

            return orders;
        }

        #endregion


        #region private

        /// <summary>
        /// send a request and retrieve the response
        /// </summary>
        /// <param name="requestString">the request to send</param>
        /// <returns>the response string</returns>
        private static string MakeRequest(string requestString, string method = "GET", string postData = null)
        {
            var request = WebRequest.CreateHttp(requestString);

            var accessToken = "111";
            request.Headers.Add("Authorization", "Bearer " + accessToken);

            request.Method = method;
            if (method == "POST")
            {
                var data = Encoding.UTF8.GetBytes(postData);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }

            using (var response = request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string responseString = reader.ReadToEnd().Trim();

                    return responseString;
                }
            }
        }

        #endregion
    }
}
