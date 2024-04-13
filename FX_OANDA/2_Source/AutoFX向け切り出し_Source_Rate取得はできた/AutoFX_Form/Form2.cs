using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoFX_Form
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btn通貨ペア取得_Click(object sender, EventArgs e)
        {
            //var prices = OANDA.GetInstruments.GetRates(instruments);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Instrument> instruments = new List<Instrument>();
            //instruments.Add(new Instrument() { instrument = "AUD/CAD" });
            //instruments.Add(new Instrument() { instrument = "AUD/CHF" });
            //instruments.Add(new Instrument() { instrument = "AUD/HKD" });
            //instruments.Add(new Instrument() { instrument = "AUD/JPY" });
            //instruments.Add(new Instrument() { instrument = "AUD/NZD" });
            //instruments.Add(new Instrument() { instrument = "AUD/SGD" });
            //instruments.Add(new Instrument() { instrument = "AUD/USD" });
            //instruments.Add(new Instrument() { instrument = "CAD/CHF" });
            //instruments.Add(new Instrument() { instrument = "CAD/HKD" });
            //instruments.Add(new Instrument() { instrument = "CAD/JPY" });
            //instruments.Add(new Instrument() { instrument = "CAD/SGD" });
            //instruments.Add(new Instrument() { instrument = "CHF/HKD" });
            //instruments.Add(new Instrument() { instrument = "CHF/JPY" });
            //instruments.Add(new Instrument() { instrument = "CHF/ZAR" });
            //instruments.Add(new Instrument() { instrument = "EUR/AUD" });
            //instruments.Add(new Instrument() { instrument = "EUR/CAD" });
            //instruments.Add(new Instrument() { instrument = "EUR/CHF" });
            //instruments.Add(new Instrument() { instrument = "EUR/CZK" });
            //instruments.Add(new Instrument() { instrument = "EUR/DKK" });
            //instruments.Add(new Instrument() { instrument = "EUR/GBP" });
            //instruments.Add(new Instrument() { instrument = "EUR/HKD" });
            //instruments.Add(new Instrument() { instrument = "EUR/HUF" });
            //instruments.Add(new Instrument() { instrument = "EUR/JPY" });
            //instruments.Add(new Instrument() { instrument = "EUR/NOK" });
            //instruments.Add(new Instrument() { instrument = "EUR/NZD" });
            //instruments.Add(new Instrument() { instrument = "EUR/PLN" });
            //instruments.Add(new Instrument() { instrument = "EUR/SEK" });
            //instruments.Add(new Instrument() { instrument = "EUR/SGD" });
            //instruments.Add(new Instrument() { instrument = "EUR/TRY" });
            //instruments.Add(new Instrument() { instrument = "EUR/USD" });
            //instruments.Add(new Instrument() { instrument = "EUR/ZAR" });
            //instruments.Add(new Instrument() { instrument = "GBP/AUD" });
            //instruments.Add(new Instrument() { instrument = "GBP/CAD" });
            //instruments.Add(new Instrument() { instrument = "GBP/CHF" });
            //instruments.Add(new Instrument() { instrument = "GBP/HKD" });
            //instruments.Add(new Instrument() { instrument = "GBP/JPY" });
            //instruments.Add(new Instrument() { instrument = "GBP/NZD" });
            //instruments.Add(new Instrument() { instrument = "GBP/PLN" });
            //instruments.Add(new Instrument() { instrument = "GBP/SGD" });
            //instruments.Add(new Instrument() { instrument = "GBP/USD" });
            //instruments.Add(new Instrument() { instrument = "GBP/ZAR" });
            //instruments.Add(new Instrument() { instrument = "HKD/JPY" });
            //instruments.Add(new Instrument() { instrument = "NZD/CAD" });
            //instruments.Add(new Instrument() { instrument = "NZD/CHF" });
            //instruments.Add(new Instrument() { instrument = "NZD/HKD" });
            //instruments.Add(new Instrument() { instrument = "NZD/JPY" });
            //instruments.Add(new Instrument() { instrument = "NZD/SGD" });
            //instruments.Add(new Instrument() { instrument = "NZD/USD" });
            //instruments.Add(new Instrument() { instrument = "SGD/CHF" });
            //instruments.Add(new Instrument() { instrument = "SGD/HKD" });
            //instruments.Add(new Instrument() { instrument = "SGD/JPY" });
            //instruments.Add(new Instrument() { instrument = "TRY/JPY" });
            //instruments.Add(new Instrument() { instrument = "USD/CAD" });
            //instruments.Add(new Instrument() { instrument = "USD/CHF" });
            //instruments.Add(new Instrument() { instrument = "USD/CNH" });
            //instruments.Add(new Instrument() { instrument = "USD/CZK" });
            //instruments.Add(new Instrument() { instrument = "USD/DKK" });
            //instruments.Add(new Instrument() { instrument = "USD/HKD" });
            //instruments.Add(new Instrument() { instrument = "USD/HUF" });
            //instruments.Add(new Instrument() { instrument = "USD/INR" });
            instruments.Add(new Instrument() { instrument = "USD_JPY" });
            //instruments.Add(new Instrument() { instrument = "USD/MXN" });
            //instruments.Add(new Instrument() { instrument = "USD/NOK" });
            //instruments.Add(new Instrument() { instrument = "USD/PLN" });
            //instruments.Add(new Instrument() { instrument = "USD/SAR" });
            //instruments.Add(new Instrument() { instrument = "USD/SEK" });
            //instruments.Add(new Instrument() { instrument = "USD/SGD" });
            //instruments.Add(new Instrument() { instrument = "USD/THB" });
            //instruments.Add(new Instrument() { instrument = "USD/TRY" });
            //instruments.Add(new Instrument() { instrument = "USD/ZAR" });
            //instruments.Add(new Instrument() { instrument = "ZAR/JPY" });

            var prices = OANDA.GetRates(instruments);


        }

    }
}
