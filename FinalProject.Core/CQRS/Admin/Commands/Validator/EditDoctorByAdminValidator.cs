using System.Globalization;
using FinalProject.Core.CQRS.Admin.Commands.Request;
using FinalProject.Data.DoctorResponse;
using FluentValidation;

namespace FinalProject.Core.CQRS.Admin.Commands.Validator;

public class EditDoctorByAdminValidator : AbstractValidator<EditDoctorByAdminResponse>
{
    public EditDoctorByAdminValidator()
    {
        EditDoctorByAdminValidation();
    }

    public void EditDoctorByAdminValidation()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full name cannot be empty")
            .NotNull().WithMessage("Full name cannot be empty")
            .Matches(@"^[A-Za-z\s]+$").WithMessage("Full name must contain only characters and spaces")
            .MaximumLength(80);
        
        RuleFor(x=>x.YearsOfExperience)
            .NotEmpty().WithMessage("Years of experience cannot be empty")
            .NotNull().WithMessage("Years of experience cannot be empty")
            .Must(x => x == (int)x).WithMessage("Years of experience must be a digit")
            .GreaterThan(0).WithMessage("Years of experience must be greater than 0");

        RuleFor(x => x.Degree)
            .NotEmpty().WithMessage("Degree cannot be empty")
            .NotNull().WithMessage("Degree cannot be empty")
            .Matches(@"^[A-Za-z\s]+$").WithMessage("Degree must contain only characters and spaces")
            .MaximumLength(10);

        RuleFor(x => x.Specialty)
            .NotEmpty().WithMessage("Specialty cannot be empty")
            .NotNull().WithMessage("Specialty cannot be empty")
            .MaximumLength(30).WithMessage("Specialty must be less than 30");
        
        RuleFor(x=>x.Focus)
            .NotEmpty().WithMessage("Focus cannot be empty")
            .NotNull().WithMessage("Focus cannot be empty")
            .MaximumLength(100).WithMessage("Focus must be less than 100");
        
        RuleFor(x=>x.Profile)
            .NotEmpty().WithMessage("Profile cannot be empty")
            .NotNull().WithMessage("Profile cannot be empty")
            .MaximumLength(200).WithMessage("Profile must be less than 200");
        
        RuleFor(x=>x.CareerPath)
            .NotEmpty().WithMessage("CareerPath cannot be empty")
            .NotNull().WithMessage("CareerPath cannot be empty")
            .MaximumLength(200).WithMessage("CareerPath must be less than 200");
        
        RuleFor(x=>x.Highlights)
            .NotEmpty().WithMessage("Highlights cannot be empty")
            .NotNull().WithMessage("Highlights cannot be empty")
            .MaximumLength(200).WithMessage("Highlights must be less than 200");

        RuleFor(x => x.ProfilePicture)
            .NotEmpty().WithMessage("ProfilePicture cannot be empty")
            .NotNull().WithMessage("ProfilePicture cannot be empty")
            .Must(validProfilePicture).WithMessage("profile picture is invalid");
            

        RuleFor(x => x.AvailableFrom)
            .NotEmpty().WithMessage("AvailableFrom cannot be empty")
            .NotNull().WithMessage("AvailableFrom cannot be empty")
            .Must(ValidTime).WithMessage("AvailableFrom must be a date");
        
        RuleFor(x => x.AvailableTo)
            .NotEmpty().WithMessage("AvailableFrom cannot be empty")
            .NotNull().WithMessage("AvailableFrom cannot be empty")
            .Must(ValidTime).WithMessage("AvailableFrom must be a date");
        
        RuleFor(d => d)
            .Must(d => CheckTime(d.AvailableFrom, d.AvailableTo))
            .WithMessage("Available From must be before Available To.");
        
        RuleFor(x=>x.Email)
            .NotEmpty().WithMessage("Email is required")
            .NotNull().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email address")
            .MaximumLength(255).WithMessage("Email must not exceed 255 characters");
        

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required")
            .NotNull().WithMessage("Phone number is required")
            .MaximumLength(15).WithMessage("Phone number must not exceed 15 characters")
            .Matches(@"^\+?\d+$").WithMessage("Invalid phone number");
    }
    
    private bool validProfilePicture(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out _);
    }
    
    private bool ValidTime(string time)
    {
        return DateTime.TryParseExact(time, "hh:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
    }
    private bool CheckTime(string from, string to)
    {
        if (DateTime.TryParseExact(from, "hh:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out var fromTime) &&
            DateTime.TryParseExact(to, "hh:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out var toTime))
        {
            return fromTime < toTime;
        }
        return false;
    }
}