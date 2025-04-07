using FinalProject.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using PayPal.Api;

namespace FinalProject.Service.Services;

public class PayPalService : IPayPalService
{
    private readonly APIContext _context;
    public PayPalService(IConfiguration configuration)
    {
        var config = new Dictionary<string, string>
        {
            { "mode", configuration.GetSection("PayPal:Mode").Value! }
        };
        var clientId = configuration.GetSection("PayPal:ClientId").Value;
        var clientSecret = configuration.GetSection("PayPal:ClientSecret").Value;
        
        var accessToken = new OAuthTokenCredential(clientId, clientSecret, config).GetAccessToken();
        _context = new APIContext(accessToken) { Config = config };
    }

    public Payment CreatePayment(decimal amount, string returnUrl, string cancelUrl, string currency = "USD")
    {
        var payment = new Payment
        {
            intent = "sale",
            payer = new Payer { payment_method = "paypal" },
            transactions = new List<Transaction>
            {
                new Transaction
                {
                    amount = new Amount
                    {
                        currency = currency,
                        total = amount.ToString("F2")
                    },
                    description = "Transaction description."
                }
            },
            redirect_urls = new RedirectUrls
            {
                return_url = returnUrl,
                cancel_url = cancelUrl
            }
        };

        var createdPayment = payment.Create(_context);
        return createdPayment;
    }
    
    public Payment ExecutePayment(string paymentId, string payerId)
    {
        var paymentExecution = new PaymentExecution { payer_id = payerId };
        var payment = new Payment { id = paymentId };
        var executedPayment = payment.Execute(_context, paymentExecution);
        return executedPayment;
    }
}