namespace FinalProject.Data.PatientResponse;

public class UpdatePatientResponse
{
    public string FullName { get; set; }
    public byte[]? ProfilePicture { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}