using System.Linq.Expressions;
using AutoMapper;
using FinalProject.Core.CQRS.Doctor.Queries.Handler;
using FinalProject.Core.CQRS.Doctor.Queries.Response;
using FinalProject.Core.Pagination;
using FinalProject.Data.Models;
using FinalProject.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using SchoolProject.Core.Bases;

namespace FinalProject.Core.CQRS.Doctor.Queries.Handler;

public class DoctorQueryHandler : ExtraResponseHandler,
                                  IRequestHandler<GetDoctorByIdQuery,ExtraResponseOutput<GetDoctorByIdResponse>>,
                                  IRequestHandler<GetDoctorPaginatedQuery,PaginationResponseOutput<GetDoctorPaginatedResponse>>
                                    // IRequestHandler<GetReservationByIdQuery,GetReservationByIdResponse>,
                                 
{
    private readonly IMapper _mapper;
    private readonly IDoctorService _service;
    public DoctorQueryHandler(IMapper mapper, IDoctorService service)
    {
        _mapper = mapper;
        _service = service;
    }
    
    public async Task<ExtraResponseOutput<GetDoctorByIdResponse>> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
    {
        var doctor = await _service.GetDoctorByIdAsync(request.Id);
        if (doctor == null) return NotFound<GetDoctorByIdResponse>("Doctor not found");
        
        var mappedDoctor = _mapper.Map<GetDoctorByIdResponse>(doctor);
        return Success(mappedDoctor);
    }
    

    // public async Task<GetReservationByIdResponse> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
    // {
    //     var reservations = await _reservation.GetDoctorReservationsAsync(request.Id);
    //     var mappedReservations = _mapper.Map<GetReservationByIdResponse>(reservations);
    //     return mappedReservations;
    // }
    
    public async Task<PaginationResponseOutput<GetDoctorPaginatedResponse>> Handle(GetDoctorPaginatedQuery request, CancellationToken cancellationToken)
    {

        Expression<Func<Data.Models.Doctor, GetDoctorPaginatedResponse>> expression = x =>
            new GetDoctorPaginatedResponse(x.FullName,x.YearsOfExperience,
                                            x.Degree,x.Specialty,x.Focus,x.Profile,x.CareerPath,
                                            x.Highlights,x.ProfilePicture,x.ApplicationUser.Email,x.ApplicationUser.PhoneNumber
                                            ,x.AvailableFrom,x.AvailableTo);
        
        

        var querable = _service.GetDoctorsQuerable();
        var paginatedList = await querable.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);

        return paginatedList;
    }
}