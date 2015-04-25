using System;
using System.Runtime.InteropServices;
using RaspPos.BackgroundAgents;

namespace RasPos.ShoppingCart
{
    public class Invoice
    {
        private readonly PurchasableItem _product;


        public int ProductId { get; private set; }
        public string ProductName { get; private set; }
        public string DenominatedPrice { get; private set; }
        public int PriceInBits { get; private set; }
        public double PriceOfOneBitcoin { get; private set; }
        public string PayToAddress { get; set; }
        public string PaymentQrCode { get; set; }


        public Invoice(PurchasableItem product, string receivingAddress, PriceInformation priceInformation)
        {
            if (product == null) throw new ArgumentNullException("product");
            if (receivingAddress == null) throw new ArgumentNullException("receivingAddress");
            if (priceInformation == null) throw new ArgumentNullException("priceInformation");
            _product = product;


            ProductId = product.ProductId;
            ProductName = product.Name;
            PriceInBits = priceInformation.GetPriceInBits(_product.Price);
            DenominatedPrice = "$"+ product.Price;
            PriceOfOneBitcoin = priceInformation.DollarPriceOf1BTC;
        }
    }
}