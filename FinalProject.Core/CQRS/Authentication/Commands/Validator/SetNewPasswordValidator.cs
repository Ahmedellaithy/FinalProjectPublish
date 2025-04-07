using System.Text.RegularExpressions;
using FinalProject.Core.CQRS.Authentication.Commands.Response;
using FluentValidation;

namespace FinalProject.Core.CQRS.Authentication.Commands.Validators;

public class SetNewPasswordValidator : AbstractValidator<SetNewPasswordCommand>
{
    public SetNewPasswordValidator()
    {
        SetNewPasswordValidate();
    }

    public void SetNewPasswordValidate()
    {
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("This field cannot be empty")
            .NotNull().WithMessage("This field cannot be null")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters")
            .MaximumLength(128).WithMessage("Password is too long")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
            .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character")
            .Must(ContainsNumber).WithMessage("Password must contain at least one number");

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty().WithMessage("This field cannot be empty")
            .NotNull().WithMessage("This field cannot be null")
            .Matches(x => x.Password);
    }
    
    private bool ContainsNumber(string password)
    {
        return Regex.IsMatch(password, @"\d");
    }
}