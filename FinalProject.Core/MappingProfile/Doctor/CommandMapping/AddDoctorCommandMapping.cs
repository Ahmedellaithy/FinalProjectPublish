using System.Globalization;
using FinalProject.Core.CQRS.Admin.Commands.Request;
using FinalProject.Core.CQRS.Doctor.Commands.Request;
using FinalProject.Data.DoctorResponse;

namespace FinalProject.Core.MappingProfile.Doctor;

public partial class DoctorMapping
{
    public void AddDoctorCommandMapping()
    {
        CreateMap<AddDoctorByAdminCommand, Data.Models.Doctor>()
            .ForMember(dest => dest.FullName, x => x.MapFrom(src => src.FullName))
            .ForMember(dest => dest.YearsOfExperience, x => x.MapFrom(src => src.YearsOfExperience))
            .ForMember(dest => dest.Degree, x => x.MapFrom(src => src.Degree))
            .ForMember(dest => dest.Specialty, x => x.MapFrom(src => src.Specialty))
            .ForMember(dest => dest.Focus, x => x.MapFrom(src => src.Focus))
            .ForMember(dest => dest.Profile, x => x.MapFrom(src => src.Profile))
            .ForMember(dest => dest.CareerPath, x => x.MapFrom(src => src.CareerPath))
            .ForMember(dest => dest.Highlights, x => x.MapFrom(src => src.Highlights))
            .ForMember(dest => dest.ProfilePicture, x => x.MapFrom(src => src.ProfilePicture))
            .ForMember(dest => dest.AvailableFrom, x => x.MapFrom(src => DateTime.ParseExact(src.AvailableFrom, "hh:mm tt", null).TimeOfDay))
            .ForMember(dest => dest.AvailableTo, x => x.MapFrom(src => DateTime.ParseExact(src.AvailableTo, "hh:mm tt", null).TimeOfDay));
    }
    
    private static TimeSpan ConvertToTimeSpan(string time)
    {
        if (DateTime.TryParseExact(time, "hh:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedTime))
        {
            return parsedTime.TimeOfDay;
        }
        throw new FormatException($"Invalid time format: {time}. Expected format: 'hh:mm AM/PM'.");
    }
}
