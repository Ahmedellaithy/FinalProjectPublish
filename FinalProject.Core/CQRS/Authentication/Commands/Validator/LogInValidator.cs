using FinalProject.Core.CQRS.Authentication.Commands.Response;
using FluentValidation;

namespace FinalProject.Core.CQRS.Authentication.Commands.Validators;

public class LogInValidator : AbstractValidator<LogInCommand>
{
    public LogInValidator()
    {
        LogInValidation();
    }

    public void LogInValidation()
    {
        RuleFor(x => x.EmailOrPhone)
            .NotEmpty().WithMessage("Email or Phone is required")
            .NotNull().WithMessage("Email or Phone is required");
        
        RuleFor(x=>x.Password)
            .NotEmpty().WithMessage("Password is required")
            .NotNull().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters");
    }
}

