using System;
using System.Runtime.InteropServices;
using RaspPos.BackgroundAgents;

namespace RasPos.ShoppingCart
{
    public class Invoice
    {
        private readonly PurchasableItem _product;
        private readonly string _receivingAddress;
        private readonly PriceInformation _priceInformation;


        public int ProductId { get { return _product.ProductId; } }
        public string ProductName { get { return _product.Name; } }
        public double Price { get { return _product.Price; } }
        public double PriceInBits { get { return _priceInformation.GetPriceInBits(_product.Price); } }

        public Invoice(PurchasableItem product, string receivingAddress, PriceInformation priceInformation)
        {
            if (product == null) throw new ArgumentNullException("product");
            if (receivingAddress == null) throw new ArgumentNullException("receivingAddress");
            if (priceInformation == null) throw new ArgumentNullException("priceInformation");
            _product = product;
            _receivingAddress = receivingAddress;
            _priceInformation = priceInformation;
        }
    }
}