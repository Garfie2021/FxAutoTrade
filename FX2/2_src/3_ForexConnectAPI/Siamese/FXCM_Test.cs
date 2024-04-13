using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fxcore2;

namespace Siamese
{
    public static class FXCM_Test
    {

        public static void Login()
        {
            O2GSession session = null;

            try
            {
                string Login = "111";
                string Password = "1111";
                string URL = "http://www.fxcorporate.com/Hosts.jsp";
                string Connection = "Demo";

                session = O2GTransport.createSession();
                session.login(Login, Password, URL, Connection);

                session.useTableManager(O2GTableManagerMode.Yes, null);

                O2GTableManager tableMgr = session.getTableManager();

                O2GOffersTable offersTable = (O2GOffersTable)tableMgr.getTable(O2GTableType.Offers);

                for (int i = 0; i < offersTable.Count; i++)
                {
                    O2GOfferRow offer = offersTable.getRow(i);
                    Console.WriteLine("Instrument: " + offer.Instrument + " Bid = " + offer.Bid + " Ask = " + offer.Ask);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.ToString());
            }
            finally
            {
                if (session != null)
                {
                    session.Dispose();
                }
            }
        }
    }
}
