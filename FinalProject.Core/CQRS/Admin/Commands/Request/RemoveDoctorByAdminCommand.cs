using FinalProject.Data.DoctorResponse;
using MediatR;
using SchoolProject.Core.Bases;

namespace FinalProject.Core.CQRS.Admin.Commands.Request;

public class RemoveDoctorByAdminCommand : IRequest<ExtraResponseOutput<RemoveDoctorByAdminResponse>>
{
    public int Id { get; set; }
    public RemoveDoctorByAdminCommand(int id)
    {
        Id = id;
    }
}