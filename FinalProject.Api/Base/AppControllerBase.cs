using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Bases;

namespace SchoolProject.Api.Base;

[ApiController]
public class AppControllerBase : ControllerBase
{
    private IMediator _mediatorInstance;
    protected IMediator Mediator => _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();
    
    public ObjectResult NewResult<T>(ExtraResponseOutput<T> extraResponseOutput)
    {
        switch (extraResponseOutput.StatusCode) {
            case HttpStatusCode.OK:
                return new OkObjectResult(extraResponseOutput);
            case HttpStatusCode.Created:
                return new CreatedResult(string.Empty, extraResponseOutput);
            case HttpStatusCode.Unauthorized:
                return new UnauthorizedObjectResult(extraResponseOutput);
            case HttpStatusCode.BadRequest:
                return new BadRequestObjectResult(extraResponseOutput);
            case HttpStatusCode.NotFound:
                return new NotFoundObjectResult(extraResponseOutput);
            case HttpStatusCode.Accepted:
                return new AcceptedResult(string.Empty, extraResponseOutput);
            case HttpStatusCode.UnprocessableEntity:
                return new UnprocessableEntityObjectResult(extraResponseOutput);
            default:
                return new BadRequestObjectResult(extraResponseOutput);
        }
    }
}