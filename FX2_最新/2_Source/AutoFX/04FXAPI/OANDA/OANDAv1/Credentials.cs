using System.Collections.Generic;
using 定数;


namespace OANDAv1
{
    public class Credentials
    {
        public bool HasServer(EServer server)
        {
            return CredentialsSt.Servers[Environment].ContainsKey(server);
        }

        public string GetServer(EServer server)
        {
            if (HasServer(server))
            {
                return CredentialsSt.Servers[Environment][server];
            }
            return null;
        }

        public string AccessToken;

        public int DefaultAccountId;
        public EEnvironment Environment;

        public string Username;
    }

    public static class CredentialsSt
    {

        private static Credentials _instance;


        public static readonly Dictionary<EEnvironment, Dictionary<EServer, string>> Servers = new Dictionary<EEnvironment, Dictionary<EServer, string>>
        {
            {EEnvironment.Practice, new Dictionary<EServer, string>
                {
                    {EServer.StreamingRates, "https://stream-fxpractice.oanda.com/v1/"},
                    {EServer.StreamingEvents, "https://stream-fxpractice.oanda.com/v1/"},
                    {EServer.Account, "https://api-fxpractice.oanda.com/v1/"},
                    {EServer.Rates, "https://api-fxpractice.oanda.com/v1/"},
                    {EServer.Labs, "https://api-fxpractice.oanda.com/labs/v1/"},
                }
            },
            {EEnvironment.Trade, new Dictionary<EServer, string>
                {
                    {EServer.StreamingRates, "https://stream-fxtrade.oanda.com/v1/"},
                    {EServer.StreamingEvents, "https://stream-fxtrade.oanda.com/v1/"},
                    {EServer.Account, "https://api-fxtrade.oanda.com/v1/"},
                    {EServer.Rates, "https://api-fxtrade.oanda.com/v1/"},
                    {EServer.Labs, "https://api-fxtrade.oanda.com/labs/v1/"},
                }
            }
        };

        public static Credentials GetDefaultCredentials()
        {
            if (_instance == null)
            {
                //_instance = GetPracticeCredentials();
            }
            return _instance;
        }

        private static Credentials GetPracticeCredentials()
        {
            return new Credentials()
            {
                DefaultAccountId = 111,
                Environment = EEnvironment.Practice,
                AccessToken = "111",
            };

        }

        private static Credentials GetLiveCredentials()
        {
            // You'll need to add your own accessToken and account if desired
            return new Credentials()
            {
                //defaultAccountId = 00000,
                //accessToken = "111",
                Environment = EEnvironment.Trade
            };
        }

        public static void SetCredentials(EEnvironment environment, string accessToken, int defaultAccount = 0)
        {
            _instance = new Credentials
            {
                Environment = environment,
                AccessToken = accessToken,
                DefaultAccountId = defaultAccount
            };
        }
    }

}
