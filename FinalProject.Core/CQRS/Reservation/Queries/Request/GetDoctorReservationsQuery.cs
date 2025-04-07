using FinalProject.Core.CQRS.Reservation.Queries.Response;
using MediatR;
using SchoolProject.Core.Bases;

namespace FinalProject.Core.CQRS.Reservation.Queries.Request;

public class GetDoctorReservationsQuery : IRequest<ExtraResponseOutput<List<GetDoctorReservationsResponse>>>
{
    public int Id { get; set; }
    public GetDoctorReservationsQuery(int id)
    {
        Id = id;
    }
}