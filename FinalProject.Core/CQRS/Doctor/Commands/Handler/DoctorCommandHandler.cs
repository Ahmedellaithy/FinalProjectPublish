using AutoMapper;
using FinalProject.Core.CQRS.Doctor.Commands.Request;
using FinalProject.Service.Interfaces;
using MediatR;

namespace FinalProject.Core.CQRS.Doctor.Commands.Handler;

public class DoctorCommandHandler : IRequestHandler<AddDoctorCommand,string>
                                    //IRequestHandler<DeleteDoctorCommand,string>
{
    private readonly IMapper _mapper;
    private readonly IDoctorService _doctorservice;
    public DoctorCommandHandler(IMapper mapper, IDoctorService doctorservice)
    {
        _mapper = mapper;
        _doctorservice = doctorservice;
    }
    
    
    public async Task<string> Handle(AddDoctorCommand request, CancellationToken cancellationToken)
    {
        var mappedDoctor = _mapper.Map<Data.Models.Doctor>(request);
        string doctor = await _doctorservice.AddDoctorAsync(mappedDoctor);
        if(doctor=="Added Successfully") return "Doctor Added Successfully";
        return "Error Occurs";
    }

    // public async Task<string> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
    // {
    //     var deletedDoctor = await _doctorservice.RemoveDoctorAsync(request.Id);
    //     if(deletedDoctor == "Deleted Successfully") return "Doctor deleted successfully";
    //     return "Error Occurs";
    // }
}