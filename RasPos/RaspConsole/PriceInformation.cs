using Serilog;

namespace RaspPos.BackgroundAgents
{
    public class PriceInformation
    {
        public const double BITSINABITCOIN = 1000000;
        public ILogger _logger { get; set; }

        public PriceInformation(ILogger logger)
        {
            _logger = logger;
        }

        private double _price;

        public double Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    _logger.Debug("Price has changed. New price is: {price}", PriceString);
                }
            }
        }

        public string PriceString
        {
            get
            {
                decimal d = (decimal) _price/100;
                string pricestring = d.ToString(System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
                return "$" + pricestring;
            }
        }

        public double GetPriceInBits(double priceInDollars)
        {
            var bits = priceInDollars / _price * BITSINABITCOIN;

            //_logger.Debug("The price of {dollarPrice} dollars in bitcoin is {bitPrice} bits. The price per bitcoin was {pricePerBitcoin}", priceInDollars, bits, _price);
            _logger.Debug("The price of {0} dollars in bitcoin is {1} bits. The price per bitcoin was {2}", priceInDollars, bits, _price);
            return bits;
        }
    }
}
