using FinalProject.Data.CommandResponse.ReservationResponse;
using MediatR;
using SchoolProject.Core.Bases;

namespace FinalProject.Core.CQRS.Reservation.Commands.Request;

public class CancelPatientReservationCommand : IRequest<ExtraResponseOutput<CancelPatientReservationResponse>>
{
    public int patientId { get; set; }
    public int DoctorId { get; set; }
    public DateTime ReservationDate { get; set; }
}