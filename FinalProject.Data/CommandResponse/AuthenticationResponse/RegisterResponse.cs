using System.Text.Json.Serialization;
using FinalProject.Data.Enums.Patient;

namespace FinalProject.Core.CQRS.Authentication.Commands.Response;

public class RegisterResponse
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string Gender { get; set; }
}