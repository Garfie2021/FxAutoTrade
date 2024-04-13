using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using 定数;
using Common;

namespace FXCM
{
    public class TradeOANDA
    {
        private static string s_apiServer = "https://api-fxpractice.oanda.com/";
        private static string accessToken = "111"; // Debug

        /// <summary>
        /// Gets the current rates for the given instruments
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
        /// send a request and retrieve the response
        /// </summary>
        /// <param name="requestString">the request to send</param>
        /// <returns>the response string</returns>
        private static string MakeRequest(string requestString, string method = "GET", string postData = null)
        {
            var request = WebRequest.CreateHttp(requestString);

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
    }
}
