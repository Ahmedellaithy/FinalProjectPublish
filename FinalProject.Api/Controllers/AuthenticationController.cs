using FinalProject.Api.Routing;
using FinalProject.Core.CQRS.Authentication.Commands.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;


namespace FinalProject.Api.Controllers;

[ApiController]
public class AuthenticationController : AppControllerBase
{
    
    [HttpPost(Router.Authentication.Register)]
    public async Task<IActionResult> Register([FromBody] RegisterCommand register)
    {
        var result = await Mediator.Send(register);
        return NewResult(result);
    }
    
    
    [HttpPost(Router.Authentication.Login)]
    [Authorize]
    public async Task<IActionResult> LogIn([FromBody] LogInCommand login)
    {
        var result = await Mediator.Send(login);
        return NewResult(result);
    }

    
    [HttpPost(Router.Authentication.SetNewPassword)]
    [Authorize]
    public async Task<IActionResult> SetNewPassword([FromBody] SetNewPasswordCommand password)
    {
        var result = await Mediator.Send(password);
        return NewResult(result);
    }
}