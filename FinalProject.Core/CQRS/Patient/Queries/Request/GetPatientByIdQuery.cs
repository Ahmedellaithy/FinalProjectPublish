using FinalProject.Core.CQRS.Patient.Queries.Response;
using MediatR;
using SchoolProject.Core.Bases;

namespace FinalProject.Core.CQRS.Patient.Queries.Request;

public class GetPatientByIdQuery : IRequest<ExtraResponseOutput<GetPatientByIdResponse>>
{
    public int Id { get; set; }
    public GetPatientByIdQuery(int id)
    {
        Id = id;
    }
}