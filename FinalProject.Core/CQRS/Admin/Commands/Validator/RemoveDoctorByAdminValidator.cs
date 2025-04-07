using FinalProject.Core.CQRS.Admin.Commands.Request;
using FinalProject.Data.DoctorResponse;
using FluentValidation;

namespace FinalProject.Core.CQRS.Admin.Commands.Validator;

public class RemoveDoctorByAdminValidator : AbstractValidator<RemoveDoctorByAdminCommand>
{
    public RemoveDoctorByAdminValidator()
    {
        RemoveDoctorByAdminResponseValidation();
    }

    public void RemoveDoctorByAdminResponseValidation()
    {
        RuleFor(x=>x.Id)
            .NotEmpty().WithMessage("Id cannot be empty")
            .NotNull().WithMessage("Id cannot be null")
            .GreaterThan(0).WithMessage("Id must be greater than 0");
        
    }
}