using System.Security.Policy;

namespace RasPos.ShoppingCart.Qr
{
    public interface IQrCodeAgent
    {
        Url GetPaymentInfoQrCode(string priceInBits, string receivingAddress, string label);
    }
}