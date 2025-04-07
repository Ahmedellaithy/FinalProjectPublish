using MediatR;

namespace FinalProject.Core.CQRS.Doctor.Commands.Request;

public class DeleteDoctorCommand : IRequest<string>
{
    public int Id { get; set; }
}