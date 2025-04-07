using AutoMapper;
using FinalProject.Core.CQRS.Reservation.Commands.Request;
using FinalProject.Data.CommandResponse.ReservationResponse;
using FinalProject.Data.Enums.Reservation;
using FinalProject.Infrastructure.Interfaces;
using FinalProject.Service.Interfaces;
using MediatR;
using SchoolProject.Core.Bases;

namespace FinalProject.Core.CQRS.Reservation.Commands.Handler;

public class ReservationCommandHandler : ExtraResponseHandler,
                                         IRequestHandler<CancelPatientReservationCommand,ExtraResponseOutput<CancelPatientReservationResponse>>,
                                         IRequestHandler<MakeReservationCommand,ExtraResponseOutput<MakeReservationResponse>>
{

    private readonly IMapper _mapper;
    private readonly IReservationService _service;
    
    public ReservationCommandHandler(IMapper mapper, 
                                     IReservationService service)
    {
        _mapper = mapper;
        _service = service;
    }


    public async Task<ExtraResponseOutput<CancelPatientReservationResponse>> Handle(CancelPatientReservationCommand request, CancellationToken cancellationToken)
    {

        var reservationDate = await _service.CancelPatientReservationAsync(request.patientId, request.DoctorId, request.ReservationDate);
        if (reservationDate == null) return NotFound<CancelPatientReservationResponse>("There is no reservation by this date");
        
        var mappedCancelReservation = _mapper.Map<CancelPatientReservationResponse>(reservationDate);
        return Success(mappedCancelReservation);
    }
    

    public async Task<ExtraResponseOutput<MakeReservationResponse>> Handle(MakeReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = await _service.MakeReservationAsync(request.patientId,request.doctorId,request.reservationDate);

        if (reservation == "Patient not found") return NotFound<MakeReservationResponse>("Patient not found");
        if(reservation == "Doctor not found") return NotFound<MakeReservationResponse>("Doctor not found");
        if(reservation=="Sorry, Doctor is not available") return NotFound<MakeReservationResponse>("Sorry, Doctor is not available");
        if(reservation == "not") return NotFound<MakeReservationResponse>("This Slot is already booked");


        var result = await _service.GetLastReservation();
        var mappedReservation = _mapper.Map<MakeReservationResponse>(result);
        return Success(mappedReservation);
    }
}