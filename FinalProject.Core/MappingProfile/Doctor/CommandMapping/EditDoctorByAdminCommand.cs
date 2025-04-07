using FinalProject.Data.DoctorResponse;

namespace FinalProject.Core.MappingProfile.Doctor;

public partial class DoctorMapping
{

    public void EditDoctorByAdminCommand()
    {
        CreateMap<Data.Models.Doctor, EditDoctorByAdminResponse>()
            .ForMember(dest => dest.FullName, x => x.MapFrom(src => src.FullName))
            .ForMember(dest => dest.YearsOfExperience, x => x.MapFrom(src => src.YearsOfExperience))
            .ForMember(dest => dest.Degree, x => x.MapFrom(src => src.Degree))
            .ForMember(dest => dest.Specialty, x => x.MapFrom(src => src.Specialty))
            .ForMember(dest => dest.Focus, x => x.MapFrom(src => src.Focus))
            .ForMember(dest => dest.Profile, x => x.MapFrom(src => src.Profile))
            .ForMember(dest => dest.CareerPath, x => x.MapFrom(src => src.CareerPath))
            .ForMember(dest => dest.Highlights, x => x.MapFrom(src => src.Highlights))
            .ForMember(dest => dest.ProfilePicture, x => x.MapFrom(src => src.ProfilePicture))
            .ForMember(dest => dest.AvailableFrom, x => x.MapFrom(src => DateTime.Today.Add(src.AvailableFrom).ToString("hh:mm tt")))
            .ForMember(dest => dest.AvailableTo, x => x.MapFrom(src => DateTime.Today.Add(src.AvailableTo).ToString("hh:mm tt")))
            .ForMember(dest => dest.Email, x => x.MapFrom(src => src.ApplicationUser.Email))
            .ForMember(dest => dest.UserName, x => x.MapFrom(src => src.ApplicationUser.UserName));
    }
}

