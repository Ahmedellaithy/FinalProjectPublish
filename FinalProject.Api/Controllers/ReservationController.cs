using FinalProject.Core.CQRS.Reservation.Commands.Request;
using FinalProject.Core.CQRS.Reservation.Queries.Request;
using FinalProject.Data.CommandResponse.ReservationResponse;
using FinalProject.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using Router = FinalProject.Api.Routing.Router;

namespace FinalProject.Api.Controllers;

[ApiController]
public class ReservationController : AppControllerBase
{

    [HttpGet(Router.Reservation.GetAllReservations)]
    public async Task<IActionResult> GetAllReservations(GetDoctorReservationsQuery reservations)
    {
        var result = await Mediator.Send(reservations);
        return NewResult(result);
    }
    
    [HttpGet(Router.Reservation.GetAllReservationsByPatientById)]
    public async Task<IActionResult> GetAllReservationsByPatientById(int id)
    {
        var result = await Mediator.Send(new GetPatientReservationsQuery(id));
        return NewResult(result);
    }
    
    [HttpPost(Router.Reservation.PatientReservationsById)]
    public async Task<IActionResult> GetReservationsById(MakeReservationCommand reservation)
    {
        var result = await Mediator.Send(reservation);
        return NewResult(result);
    }
    

    [HttpDelete(Router.Reservation.CancelPatientReservationById)]
    public async Task<IActionResult> CancelReservationById(CancelPatientReservationCommand command)
    {
        var result = await Mediator.Send(command);
        return Ok(result);
    }
    
}