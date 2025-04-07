
using FinalProject.Core.Pagination;
using MediatR;
using SchoolProject.Core.Bases;

namespace FinalProject.Core.CQRS.Doctor.Queries.Response;

public class GetDoctorPaginatedQuery : IRequest<PaginationResponseOutput<GetDoctorPaginatedResponse>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public GetDoctorPaginatedQuery(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}