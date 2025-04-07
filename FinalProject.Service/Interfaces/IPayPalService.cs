using PayPal.Api;

namespace FinalProject.Service.Interfaces;

public interface IPayPalService
{
    public Payment CreatePayment(decimal amount, string returnUrl, string cancelUrl, string currency = "USD");
    public Payment ExecutePayment(string paymentId, string payerId);
}