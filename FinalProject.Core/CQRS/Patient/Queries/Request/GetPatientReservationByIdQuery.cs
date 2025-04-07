using FinalProject.Core.CQRS.Patient.Queries.Response;
using MediatR;
using SchoolProject.Core.Bases;

namespace FinalProject.Core.CQRS.Patient.Queries.Request;

public class GetPatientReservationByIdQuery : IRequest<ExtraResponseOutput<List<GetPatientReservationByIdResponse>>>
{
    public int Id { get; set; }
    public GetPatientReservationByIdQuery(int id)
    {
        Id = id;
    }
}