using FinalProject.Data.DoctorResponse;
using MediatR;
using SchoolProject.Core.Bases;

namespace FinalProject.Core.CQRS.Admin.Commands.Request;

public class AddDoctorByAdminCommand : IRequest<ExtraResponseOutput<AddDoctorByAdminResponse>>
{
    public string FullName { get; set; }
    public int YearsOfExperience { get; set; }
    public string Degree { get; set; }
    public string Specialty { get; set; }
    public string Focus { get; set; }
    public string Profile { get; set; }
    public string CareerPath { get; set; }
    public string Highlights { get; set; }
    public string ProfilePicture { get; set; }
    public string AvailableFrom { get; set; }
    public string AvailableTo { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    
}