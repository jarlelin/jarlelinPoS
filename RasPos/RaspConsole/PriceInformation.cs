using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Serilog;


namespace RaspConsole
{
    public class PriceInformation
    {
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
                decimal d = (decimal)_price / 100;
                var dd = new decimal(98138.45);
                string pricestring = d.ToString(System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
                return "$"+pricestring;
            }
        }
    }
}
