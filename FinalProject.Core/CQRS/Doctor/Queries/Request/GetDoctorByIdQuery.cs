using FinalProject.Core.CQRS.Doctor.Queries.Response;
using MediatR;
using SchoolProject.Core.Bases;

namespace FinalProject.Core.CQRS.Doctor.Queries.Response;

public class GetDoctorByIdQuery : IRequest<ExtraResponseOutput<GetDoctorByIdResponse>>
{
    public int Id { get; set; }
    public GetDoctorByIdQuery(int id)
    {   
        Id = id;
    }
}