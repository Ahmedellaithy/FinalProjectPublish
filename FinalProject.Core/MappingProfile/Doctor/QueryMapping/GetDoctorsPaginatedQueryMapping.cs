using System.Security.Cryptography;
using FinalProject.Core.CQRS.Doctor.Queries.Response;

namespace FinalProject.Core.MappingProfile.Doctor;

public partial class DoctorMapping
{
    public void GetDoctorsPaginatedQueryMapping()
    {
        CreateMap<Data.Models.Doctor, GetDoctorPaginatedResponse>()
            .ForMember(dest => dest.FullName,x=>x.MapFrom(src=>src.FullName))
            .ForMember(dest=>dest.YearsOfExperience,x=>x.MapFrom(src=>src.YearsOfExperience))
            .ForMember(dest=>dest.Degree,x=>x.MapFrom(src=>src.Degree))
            .ForMember(dest=>dest.Specialty,x=>x.MapFrom(src=>src.Specialty))
            .ForMember(dest=>dest.Focus,x=>x.MapFrom(src=>src.Focus))
            .ForMember(dest=>dest.Profile,x=>x.MapFrom(src=>src.Profile))
            .ForMember(dest=>dest.Highlights,x=>x.MapFrom(src=>src.Highlights))
            .ForMember(dest=>dest.ProfilePicture,x=>x.MapFrom(src=>src.ProfilePicture))
            .ForMember(dest=>dest.AvailableFrom,x=>x.MapFrom(src=>TimeOnly.FromTimeSpan(src.AvailableFrom).ToString("h:mm tt")))
            .ForMember(dest=>dest.AvailableTo,x=>x.MapFrom(src=>TimeOnly.FromTimeSpan(src.AvailableTo).ToString("h:mm tt")))
            .ReverseMap();
    }
}



