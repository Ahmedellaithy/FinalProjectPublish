using AutoMapper;
using FinalProject.Core.CQRS.Patient.Commands.Request;
using FinalProject.Core.Downloads;
using FinalProject.Data.PatientResponse;
using FinalProject.Service.Interfaces;
using MediatR;
using SchoolProject.Core.Bases;

namespace FinalProject.Core.CQRS.Patient.Commands.Handler;

public class PatientCommandHandler : ExtraResponseHandler,
                                     IRequestHandler<UpdatePatientCommand,ExtraResponseOutput<UpdatePatientResponse>>,
                                     IRequestHandler<UpdatePatientProfilePictureCommand,ExtraResponseOutput<AddProfilePictureResponse>>
{
    private readonly IMapper _mapper;
    private readonly IPatientService _service;
    public PatientCommandHandler(IMapper mapper, IPatientService service)
    {
        _mapper = mapper;
        _service = service;
    }
    
    
    public async Task<ExtraResponseOutput<UpdatePatientResponse>> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = await _service.GetPatientByIdWithIncludeAsync(request.Id);
        
        patient.FullName=request.FullName;      
        await _service.UpdatePatientAsync(patient);
        await _service.SaveChangesAsync();

        var mappeedPatient = _mapper.Map<UpdatePatientResponse>(patient);
        return Success(mappeedPatient);
    }

    public async Task<ExtraResponseOutput<AddProfilePictureResponse>> Handle(UpdatePatientProfilePictureCommand request, CancellationToken cancellationToken)
    {
        var patient = await _service.GetPatientByIdWithoutIncludeAsync(request.Id);
        if(patient == null) return NotFound<AddProfilePictureResponse>("Patient not found");
        
        try
        {
            patient.ProfilePicture=request.ProfilePicture;
            await _service.UpdatePatientAsync(patient);
            await _service.SaveChangesAsync();

            var result = new AddProfilePictureResponse();
            result.ProfilePicture=request.ProfilePicture;
            result.Name = patient.FullName;
            
            return Success(result);

        }
        catch (Exception ex)
        {
            return BadRequest<AddProfilePictureResponse>(ex.Message);
        }
    }
}