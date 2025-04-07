using FinalProject.Core.CQRS.Patient.Queries.Response;

namespace FinalProject.Core.MappingProfile.Patient;

public partial class PatientMapping
{
    public void GetPatientByIdQueryMapping()
    {
        CreateMap<Data.Models.Patient, GetPatientByIdResponse>()
            .ForMember(dest =>dest.FullName,x=>x.MapFrom(src =>src.FullName))
            .ForMember(dest =>dest.DateOfBirth,x=>x.MapFrom(src =>src.DateOfBirth))
            .ForMember(dest=>dest.ProfilePicture,x=>x.MapFrom(src=>src.ProfilePicture))
            .ForMember(dest=>dest.Gender,x=>x.MapFrom(src=>src.Gender))
            .ForMember(dest=>dest.PhoneNumber,x=>x.MapFrom(src=>src.ApplicationUser.PhoneNumber))
            .ForMember(dest=>dest.Email,x=>x.MapFrom(src=>src.ApplicationUser.Email))
            .ReverseMap();
    }
}

