using MediatR;
using SchoolProject.Core.Bases;

namespace FinalProject.Core.CQRS.Authentication.Commands.Response;

public class SetNewPasswordCommand : IRequest<ExtraResponseOutput<SetNewPasswordResponse>>
{
    public int Id { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}