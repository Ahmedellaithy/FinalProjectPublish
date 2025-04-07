using FinalProject.Core.Pagination;
using MediatR;

namespace FinalProject.Core.CQRS.Doctor.Queries.Response;

public class GetDoctorListQuery : IRequest<ICollection<GetDoctorListResponse>>
{
    
}