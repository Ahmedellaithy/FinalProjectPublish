using FinalProject.Api.Routing;
using FinalProject.Core.CQRS.Patient.Commands.Request;
using FinalProject.Core.CQRS.Patient.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;

namespace FinalProject.Api.Controllers;

[ApiController]
public class PatientController : AppControllerBase
{
    
    [HttpGet(Router.Patient.GetPatientById)]
    public async Task<IActionResult> GetPatientById(int id)
    {
        var result = await Mediator.Send(new GetPatientByIdQuery(id));
        return NewResult(result);
    }


    [HttpPut(Router.Patient.UpdatePatient)]
    public async Task<IActionResult> UpdatePatient(UpdatePatientCommand patient)
    {
        var result = await Mediator.Send(patient);
        return NewResult(result);
    }

    [HttpPut(Router.Patient.UpdatePatientProfilePicture)]
    public async Task<IActionResult> UpdatePatientProfilePicture(UpdatePatientProfilePictureCommand profilePicture)
    {
        var result = await Mediator.Send(profilePicture);
        return NewResult(result);
    }
}