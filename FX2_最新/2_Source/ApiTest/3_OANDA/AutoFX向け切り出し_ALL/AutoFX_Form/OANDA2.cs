using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFX_Form
{
    public static class OANDA2
    {
        private static Credentials GetPracticeCredentials()
        {
            return new Credentials()
            {
                DefaultAccountId = 111,
                Environment = EEnvironment.Practice,
                AccessToken = "111",
            };

        }

    }
}
