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
                    _logger.Debug("Price has change. New price is: {price}", PriceString);

                }
            }
        }
        public string PriceString
        {
            get
            {
                double amount = _price / 100;
                var pricestring = string.Format("${0}", amount);
                return pricestring;
            }
        }
    }
}
