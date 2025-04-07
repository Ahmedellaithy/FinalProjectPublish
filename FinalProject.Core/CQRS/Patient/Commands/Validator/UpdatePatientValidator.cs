using FinalProject.Core.CQRS.Patient.Commands.Request;
using FluentValidation;

namespace FinalProject.Core.CQRS.Patient.Commands.Validator;

public class UpdatePatientValidator : AbstractValidator<UpdatePatientCommand>
{

    public UpdatePatientValidator()
    {
        
    }

    public void UpdatePatientValidation()
    {
        RuleFor(x=>x.Id)
            .NotEmpty().WithMessage("Id is required")
            .NotNull().WithMessage("Id is required");
        
        RuleFor(x=>x.FullName)
            .NotEmpty().WithMessage("FullName is required")
            .NotNull().WithMessage("FullName is required")
            .MaximumLength(80).WithMessage("FullName must not exceed 100 characters");
    }
}