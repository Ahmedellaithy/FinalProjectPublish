using FinalProject.Data.DoctorResponse;
using MediatR;
using SchoolProject.Core.Bases;

namespace FinalProject.Core.CQRS.Admin.Commands.Request;

public class EditDoctorByAdminCommand : IRequest<ExtraResponseOutput<EditDoctorByAdminResponse>>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
}