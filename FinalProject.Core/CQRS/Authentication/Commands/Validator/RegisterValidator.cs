using System.Text.RegularExpressions;
using FinalProject.Core.CQRS.Authentication.Commands.Response;
using FluentValidation;

namespace FinalProject.Core.CQRS.Authentication.Commands.Validators;

public class RegisterValidator : AbstractValidator<RegisterCommand>
{
    public RegisterValidator()
    {
        RegisterValidation();
    }

    public void RegisterValidation()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full name is required")
            .NotNull().WithMessage("Full name is required")
            .Matches(@"^[A-Za-z\s]+$").WithMessage("Full name must contain only characters and spaces")
            .MaximumLength(80).WithMessage("Full name must not exceed 80 characters");
        
        RuleFor(x=>x.Email)
            .NotEmpty().WithMessage("Email is required")
            .NotNull().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email address")
            .MaximumLength(255).WithMessage("Email must not exceed 255 characters");
        
        RuleFor(x=>x.Password)
            .NotEmpty().WithMessage("Password is required")
            .NotNull().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters")
            .MaximumLength(128).WithMessage("Password is too long")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
            .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character")
            .Must(ContainsNumber).WithMessage("Password must contain at least one number");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required")
            .NotNull().WithMessage("Phone number is required")
            .MaximumLength(15).WithMessage("Phone number must not exceed 15 characters")
            .Matches(@"^\+?\d+$").WithMessage("Invalid phone number");
        
        RuleFor(x=>x.DateOfBirth)
            .NotEmpty().WithMessage("Birth Date is required")
            .NotNull().WithMessage("Birth date is required")
            .Must(Valid).WithMessage("Invalid Birth date");


        RuleFor(x => x.Gender)
            .NotEmpty().WithMessage("Gender is required")
            .NotNull().WithMessage("Gender is required")
            .Must(gender => gender == "Male" || gender == "Female")
            .WithMessage("Gender must be either Male or Female");
    }
    
    private bool Valid(DateOnly birthDate)
    {
        return birthDate <= DateOnly.FromDateTime(DateTime.Now);
    }
    
    private bool ContainsNumber(string password)
    {
        return Regex.IsMatch(password, @"\d");
    }

}
