using AutoMapper;
using FinalProject.Core.CQRS.Patient.Queries.Request;
using FinalProject.Core.CQRS.Patient.Queries.Response;
using FinalProject.Service.Interfaces;
using MediatR;
using SchoolProject.Core.Bases;

namespace FinalProject.Core.CQRS.Patient.Queries.Handler;

public class PatientQueryHandler : ExtraResponseHandler,
                                   IRequestHandler<GetPatientByIdQuery,ExtraResponseOutput<GetPatientByIdResponse>>
{
    private readonly IPatientService _service;
    private readonly IMapper _mapper;
    public PatientQueryHandler(IPatientService service, IMapper mapper)
    {
        _mapper = mapper;
        _service = service;
    }


    public async Task<ExtraResponseOutput<GetPatientByIdResponse>> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
    {
        var patient = await _service.GetPatientByIdWithIncludeAsync(request.Id);
        if(patient == null) return NotFound<GetPatientByIdResponse>("Patient not found");
        
        var mappedPatient = _mapper.Map<GetPatientByIdResponse>(patient);
        return Success(mappedPatient);
    }
    
}