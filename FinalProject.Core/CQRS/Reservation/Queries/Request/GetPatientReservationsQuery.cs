using FinalProject.Core.CQRS.Reservation.Queries.Response;
using MediatR;
using SchoolProject.Core.Bases;

namespace FinalProject.Core.CQRS.Reservation.Queries.Request;

public class GetPatientReservationsQuery : IRequest<ExtraResponseOutput<ICollection<GetPatientReservationsResponse>>>
{
    public int Id { get; set; }
    public GetPatientReservationsQuery(int id)
    {
        Id = id;
    }
}