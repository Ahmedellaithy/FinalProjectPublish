using AutoMapper;
using Com.CloudRail.SI.ServiceCode.Commands;
using FinalProject.Core.CQRS.Admin.Commands.Request;
using FinalProject.Core.Exceptions;
using FinalProject.Data.DoctorResponse;
using FinalProject.Data.Identity;
using FinalProject.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Bases;

namespace FinalProject.Core.CQRS.Admin.Commands.Handler;

public class AdminCommandHandler : ExtraResponseHandler,
                                   IRequestHandler<AddDoctorByAdminCommand,ExtraResponseOutput<AddDoctorByAdminResponse>>,
                                   IRequestHandler<EditDoctorByAdminCommand,ExtraResponseOutput<EditDoctorByAdminResponse>>,
                                   IRequestHandler<RemoveDoctorByAdminCommand,ExtraResponseOutput<RemoveDoctorByAdminResponse>>
{

    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _user;
    private readonly IDoctorService _service;
    public AdminCommandHandler(IMapper mapper, 
                               UserManager<ApplicationUser> user,
                               IDoctorService service)
    {
        _mapper = mapper;
        _user = user;
        _service = service;
    }
    

    public async Task<ExtraResponseOutput<AddDoctorByAdminResponse>> Handle(AddDoctorByAdminCommand request, CancellationToken cancellationToken)
    {
        var email = await _user.FindByEmailAsync(request.Email);
        if (email != null) return Conflict<AddDoctorByAdminResponse>("Email address already exists"); 
        
        var user = new ApplicationUser()
        {
            Email = request.Email,
            UserName = request.Email,
            PhoneNumber = request.PhoneNumber,
            TwoFactorEnabled = true
        };
        var result = await _user.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new BusinessException($"Creating Doctor failed: {errors}");
        }
        
        var createDoctor = _mapper.Map<Data.Models.Doctor>(request);

        createDoctor.ApplicationUserId = user.Id;
        await _service.AddDoctorAsync(createDoctor);
        await _service.SaveChangesAsync();
        var lastDoctor = await _service.GetLastDoctorAsync();
        
        var mappedDoctor = _mapper.Map<AddDoctorByAdminResponse>(lastDoctor);
        return Success(mappedDoctor);
    }

    public async Task<ExtraResponseOutput<EditDoctorByAdminResponse>> Handle(EditDoctorByAdminCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _service.GetDoctorByIdAsync(request.Id);
        if(doctor == null) return NotFound<EditDoctorByAdminResponse>("Doctor not found");

        doctor.FullName = request.FirstName;
        await _service.UpdateDoctorAsync(doctor);

        var mappedDoctor = _mapper.Map<EditDoctorByAdminResponse>(doctor);
        return Success(mappedDoctor);
    }

    public async Task<ExtraResponseOutput<RemoveDoctorByAdminResponse>> Handle(RemoveDoctorByAdminCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _service.GetDoctorByIdWithIncludesAsync(request.Id);
        if(doctor == null) return NotFound<RemoveDoctorByAdminResponse>("Doctor not found");
        
        var mappedDoctor = _mapper.Map<RemoveDoctorByAdminResponse>(doctor);
        await _service.RemoveDoctorAsync(doctor);
        return Success(mappedDoctor);
    }
}