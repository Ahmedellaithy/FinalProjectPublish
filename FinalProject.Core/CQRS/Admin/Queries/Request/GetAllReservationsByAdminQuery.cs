using FinalProject.Core.CQRS.Admin.Queries.Response;
using MediatR;
using SchoolProject.Core.Bases;

namespace FinalProject.Core.CQRS.Admin.Queries.Request;

public class GetAllReservationsByAdminQuery : IRequest<ExtraResponseOutput<List<GetAllReservationsByAdminResponse>>>
{
    public GetAllReservationsByAdminQuery()
    { }
}