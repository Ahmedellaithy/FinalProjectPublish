using FinalProject.Core.CQRS.Doctor.Queries.Response;

namespace FinalProject.Core.MappingProfile.Doctor;

public partial class DoctorMapping
{
    public void GetDoctorByIdQueryMapping()
    {
        CreateMap<Data.Models.Doctor, GetDoctorByIdResponse>()
            .ForMember(dest=>dest.FullName,x=>x.MapFrom(src=>src.FullName))
            .ForMember(dest=>dest.YearsOfExperience,x=>x.MapFrom(src=>src.YearsOfExperience))
            .ForMember(dest=>dest.Degree,x=>x.MapFrom(src=>src.Degree))
            .ForMember(dest=>dest.specialty,x=>x.MapFrom(src=>src.Specialty))
            .ForMember(dest=>dest.Focus,x=>x.MapFrom(src=>src.Focus))
            .ForMember(dest=>dest.Profile,x=>x.MapFrom(src=>src.Profile))
            .ForMember(dest=>dest.CareerPath,x=>x.MapFrom(src=>src.CareerPath))
            .ForMember(dest=>dest.Highlights,x=>x.MapFrom(src=>src.Highlights))
            .ForMember(dest=>dest.ProfilePicture,x=>x.MapFrom(src=>src.ProfilePicture))
            .ForMember(dest=>dest.AvailableFrom,x=>x.MapFrom(src=>TimeOnly.FromTimeSpan(src.AvailableFrom).ToString("hh:mm tt")))
            .ForMember(dest=>dest.AvailableTo,x=>x.MapFrom(src=>TimeOnly.FromTimeSpan(src.AvailableTo).ToString("hh:mm tt")))
            .ReverseMap();
    }
}
