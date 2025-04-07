using FinalProject.Data.Enums.Patient;
using FinalProject.Data.Identity;
using FinalProject.Data.Models;

namespace FinalProject.Core.CQRS.Patient.Queries.Response;

public class GetPatientByIdResponse
{
    public string FullName { get; set; }
    public string? ProfilePicture { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string Gender { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}