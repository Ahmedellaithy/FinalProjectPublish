namespace FinalProject.Core.CQRS.Authentication.Commands.Response;

public class LogInResponse
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
    
}