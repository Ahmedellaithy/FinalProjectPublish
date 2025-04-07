using FinalProject.Core.CQRS.Doctor.Commands.Request;
using FinalProject.Core.CQRS.Doctor.Queries.Response;
using FinalProject.Core.CQRS.Reservation.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using Router = FinalProject.Api.Routing.Router;

namespace FinalProject.Api.Controllers;

[ApiController]
public class DoctorController : AppControllerBase
{

    [HttpGet(Router.Doctor.GetDoctorById)]
    public async Task<IActionResult> GetDoctorById(int id)
    {
        var result = await Mediator.Send(new GetDoctorByIdQuery(id));
        return NewResult(result);
    }

    [HttpGet(Router.Doctor.GetDoctorsPaginated)]
    public async Task<IActionResult> GetDoctorsPaginated(int pageNumber=1, int pageSize=10)
    {
        var result = await Mediator.Send(new GetDoctorPaginatedQuery(pageNumber, pageSize));
        return Ok(result);
    }
    

    [HttpGet(Router.Doctor.GetDoctorReservationsById)]
    public async Task<IActionResult> GetDoctorReservations(int id)
    {
        var result = await Mediator.Send(new GetDoctorReservationsQuery(id));
        return NewResult(result);
    }

}