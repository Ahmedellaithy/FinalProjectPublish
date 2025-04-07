using FinalProject.Core.CQRS.Patient.Commands.Request;
using FluentValidation;

namespace FinalProject.Core.CQRS.Patient.Commands.Validator;

public class UpdatePatientProfilePictureValidator : AbstractValidator<UpdatePatientProfilePictureCommand>
{
    public UpdatePatientProfilePictureValidator()
    {
        UpdatePatientProfilePictureValidation();
    }

    public void UpdatePatientProfilePictureValidation()
    {
        RuleFor(x=>x.ProfilePicture)
            .NotNull().WithMessage("profile picture is required")
            .NotEmpty().WithMessage("profile picture is required")
            .Must(valid).WithMessage("profile picture is invalid");
    }
    
    private bool valid(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out _);
    }
}