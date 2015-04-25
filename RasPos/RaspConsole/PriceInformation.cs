using RasPos.Common;
using Serilog;

namespace RaspPos.BackgroundAgents
{
    public class PriceInformation
    {
        public ILogger _logger { get; set; }

        public PriceInformation(ILogger logger)
        {
            _logger = logger;
            _logger.Debug("Created new PriceInformation object.");
        }

        private int _dollarPriceFor100Btc;
        public double DollarPriceOf1BTC { get { return (double) _dollarPriceFor100Btc/100; }  }

        public int DollarPriceFor100BTC
        {
            get { return _dollarPriceFor100Btc; }
            set
            {
                if (_dollarPriceFor100Btc != value)
                {
                    _dollarPriceFor100Btc = value;
                    _logger.Debug("Price has changed. New price is: {price}", PriceString);
                }
            }
        }

        public string PriceString
        {
            get
            {
                decimal d = (decimal) _dollarPriceFor100Btc/100;
                string pricestring = d.ToString(System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
                return "$" + pricestring;
            }
        }

        public int GetPriceInBits(double priceInDollars)
        {
            var bits = priceInDollars / DollarPriceOf1BTC  * BitcoinConstants.BitsInABitcoin ;
            _logger.Debug("The price of {0} dollars in bitcoin is {1} bits. The price per bitcoin was {2}", priceInDollars, bits, DollarPriceOf1BTC);

            var intBits = (int) bits;
            return intBits;
        }

        public double GetPriceInBTC(double priceInDollars)
        {
            var btc = priceInDollars / (DollarPriceOf1BTC);

            _logger.Debug("The price of {0} dollars in bitcoin is {1} btc. The price per bitcoin was {2}", priceInDollars, btc, DollarPriceOf1BTC);
            return btc;
        }

    }
}
