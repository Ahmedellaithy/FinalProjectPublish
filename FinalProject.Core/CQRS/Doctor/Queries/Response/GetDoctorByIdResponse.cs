using FinalProject.Data.Models;

namespace FinalProject.Core.CQRS.Doctor.Queries.Response;

public class GetDoctorByIdResponse
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
    public string AvailableFrom { get; set; }
    public string AvailableTo { get; set; }
}