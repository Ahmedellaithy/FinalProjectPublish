using AutoMapper;
using FinalProject.Core.CQRS.Admin.Queries.Request;
using FinalProject.Core.CQRS.Admin.Queries.Response;
using FinalProject.Service.Interfaces;
using MediatR;
using SchoolProject.Core.Bases;

namespace FinalProject.Core.CQRS.Admin.Queries.Handler;

public class AdminQueryHandler : ExtraResponseHandler,
                                IRequestHandler<GetAllReservationsByAdminQuery,ExtraResponseOutput<List<GetAllReservationsByAdminResponse>>>
{

    private readonly IMapper _mapper;
    private readonly IReservationService _service;
    public AdminQueryHandler(IMapper mapper, IReservationService service)
    {
        _mapper = mapper;
        _service = service;
    }
    
    public async Task<ExtraResponseOutput<List<GetAllReservationsByAdminResponse>>> Handle(GetAllReservationsByAdminQuery request, CancellationToken cancellationToken)
    {
        var reservation = await _service.GetAllReservationAsync();
        if(reservation == null) return BadRequest<List<GetAllReservationsByAdminResponse>>("Reservation not found");

        var mappedReservation = _mapper.Map<List<GetAllReservationsByAdminResponse>>(reservation);
        return Success(mappedReservation);
    }
}