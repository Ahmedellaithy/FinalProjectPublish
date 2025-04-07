using FinalProject.Api.Routing;
using FinalProject.Service.Interfaces;
using FinalProject.Service.Services;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;

namespace FinalProject.Api.Controllers;

[ApiController]
public class PayPalController : AppControllerBase
{
    private readonly IPayPalService _service;
    public PayPalController(IPayPalService service)
    {
        _service = service;
    }
    
    [HttpGet(Router.PayPal.Success)]
    public IActionResult PaymentSuccess(string paymentId, string token, string PayerID)
    {
        var executedPayment = _service.ExecutePayment(paymentId, PayerID);
        return Ok(executedPayment);
    }
    
    
    [HttpPost(Router.PayPal.Create)]
    public IActionResult CreatePayment([FromBody] decimal amount)
    {
        var baseUrl = $"{Request.Scheme}://{Request.Host}";
        var returnUrl = $"{baseUrl}/api/paypal/success";
        var cancelUrl = $"{baseUrl}/api/paypal/cancel";

        var payment = _service.CreatePayment(amount, returnUrl, cancelUrl);
        return Ok(payment.GetApprovalUrl());
    }
    
    
    [HttpGet(Router.PayPal.Cancel)]
    public IActionResult Cancel()
    {
        return Ok("Payment is Cancelledl");
    }
}