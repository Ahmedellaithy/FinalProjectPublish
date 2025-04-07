using FinalProject.Data.CommandResponse.ReservationResponse;
using MediatR;
using SchoolProject.Core.Bases;

namespace FinalProject.Core.CQRS.Reservation.Commands.Request;

public class MakeReservationCommand : IRequest<ExtraResponseOutput<MakeReservationResponse>>
{
    public int patientId { get; set; }
    public int doctorId { get; set; }
    public string reservationDate { get; set; }
}