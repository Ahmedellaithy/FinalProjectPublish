using MediatR;
using SchoolProject.Core.Bases;

namespace FinalProject.Core.CQRS.Authentication.Commands.Response;

public class LogInCommand : IRequest<ExtraResponseOutput<LogInResponse>>
{
    public string EmailOrPhone { get; set; }
    public string Password { get; set; }
}