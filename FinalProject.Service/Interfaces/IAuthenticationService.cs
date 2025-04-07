using FinalProject.Core.CQRS.Authentication.Commands.Response;
using FinalProject.Data.Identity;

namespace FinalProject.Service.Interfaces;

public interface IAuthenticationService
{
    Task<LogInResponse> GenerateJWTToken(ApplicationUser user);
}