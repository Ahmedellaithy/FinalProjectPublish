using FinalProject.Data.PatientResponse;
using MediatR;
using SchoolProject.Core.Bases;

namespace FinalProject.Core.CQRS.Patient.Commands.Request;

public class UpdatePatientCommand : IRequest<ExtraResponseOutput<UpdatePatientResponse>>
{
    public int Id { get; set; }
    public string FullName { get; set; }
}