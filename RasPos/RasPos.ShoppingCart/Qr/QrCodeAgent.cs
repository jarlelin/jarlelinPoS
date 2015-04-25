using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Security.Policy;
using RasPos.Common;

namespace RasPos.ShoppingCart.Qr
{
    public class QrCodeAgent 
    {
        const string baseaddress = "http://chart.apis.google.com/chart";

        private readonly string size = "300x300";
        private readonly string parameters = "?cht=qr&chs={size}&chl=bitcoin:{address}?amount={amount}&label={label}&message={message}";
        private string paramSimple = "?cht=qr&chs={0}&chl=bitcoin:{1}?amount={2}";

        public QrCodeAgent(string paramSimple)
        {
            this.paramSimple = paramSimple;
        }


        public string GetPaymentInfoQrCode(Invoice invoice)
        {
            double btcPrice = (double)invoice.PriceInBits / (BitcoinConstants.BitsInABitcoin);
            var btcPriceString = btcPrice.ToString(CultureInfo.CreateSpecificCulture("en-US"));


            var template = new Resta.UriTemplates.UriTemplate(parameters);
            var request = template.Resolve(new Dictionary<string, object>()
            {
                {"size" , size},
                {"address", invoice.PayToAddress},
                {"amount", btcPriceString},
                {"label", "Payment for " + invoice.ProductName},
                {"message", "Paid at " + DateTime.UtcNow}
            });

            //var request = string.Format(parameters, size, invoice.PayToAddress, btcPriceString, "Payment for " + invoice.ProductName, "Paid at " + DateTime.UtcNow.ToString());
            //request = string.Format(paramSimple, size, invoice.PayToAddress, btcPrice.ToString().Replace(",", "."));

            var url = baseaddress + request;

            return url;
        }
    }
}