using System.Security.Policy;

namespace RasPos.ShoppingCart.Qr
{
    public class QrCodeAgent : IQrCodeAgent
    {
        public Url GetPaymentInfoQrCode(string priceInBits, string receivingAddress, string label)
        {
            return new Url("www.google.com");
        }
    }
}