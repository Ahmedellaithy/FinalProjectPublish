using FinalProject.Data.PatientResponse;
using MediatR;
using SchoolProject.Core.Bases;

namespace FinalProject.Core.CQRS.Patient.Commands.Request;

public class UpdatePatientProfilePictureCommand : IRequest<ExtraResponseOutput<AddProfilePictureResponse>>
{
    public int Id { get; set; }
    public string ProfilePicture { get; set; }
    public UpdatePatientProfilePictureCommand(int id, string profilePicture)
    {
        Id = id;
        ProfilePicture = profilePicture;
    }
}