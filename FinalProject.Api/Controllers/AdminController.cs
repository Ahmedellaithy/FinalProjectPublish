using System.ComponentModel.DataAnnotations;
using FinalProject.Api.Routing;
using FinalProject.Core.CQRS.Admin.Commands.Request;
using FinalProject.Core.CQRS.Admin.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;

namespace FinalProject.Api.Controllers;

[ApiController]
public class AdminController : AppControllerBase
{

    [HttpPost(Router.Admin.AddDoctor)]
    public async Task<IActionResult> AddDoctor(AddDoctorByAdminCommand doctor)
    {
        var result = await Mediator.Send(doctor);
        return NewResult(result);
    }

    [HttpPut(Router.Admin.EditDoctor)]
    public async Task<IActionResult> EditDoctor(EditDoctorByAdminCommand doctor)
    {
        var result = await Mediator.Send(doctor);
        return NewResult(result);
    }

    [HttpDelete(Router.Admin.RemoveDoctor)]
    public async Task<IActionResult> RemoveDoctor(RemoveDoctorByAdminCommand doctor)
    {
        var result = await Mediator.Send(doctor);
        return NewResult(result);
    }

    [HttpGet(Router.Admin.GetAllReservations)]
    public async Task<IActionResult> GetAllReservations()
    {
        var result = await Mediator.Send(new GetAllReservationsByAdminQuery());
        return NewResult(result);
    }
}