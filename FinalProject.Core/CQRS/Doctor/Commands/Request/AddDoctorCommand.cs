using FinalProject.Data.Models;
using MediatR;

namespace FinalProject.Core.CQRS.Doctor.Commands.Request;

public class AddDoctorCommand : IRequest<string>
{
    public string FullName { get; set; }
    public int YearsOfExperience { get; set; }
    public string Degree { get; set; }
    public string specialty { get; set; }
    public string Focus { get; set; }
    public string Profile { get; set; }
    public string CareerPath { get; set; }
    public string Highlights { get; set; }
    public string ProfilePicture { get; set; }
    public DateTime AvailableFrom { get; set; }
    public DateTime AvailableTo { get; set; }
}