using System.ComponentModel.DataAnnotations;
using FinalProject.Data.Enums.Patient;
using MediatR;
using SchoolProject.Core.Bases;

namespace FinalProject.Core.CQRS.Authentication.Commands.Response;

public class RegisterCommand : IRequest<ExtraResponseOutput<RegisterResponse>>
{
    public string FullName { get; set; }
    public string Email { get; set; }   
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string Gender { get; set; }
    
}