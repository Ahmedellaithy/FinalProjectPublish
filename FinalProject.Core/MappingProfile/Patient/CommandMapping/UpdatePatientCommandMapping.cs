using FinalProject.Data.PatientResponse;

namespace FinalProject.Core.MappingProfile.Patient;

public partial class PatientMapping
{
    public void UpdatePatientCommandMapping()
    {
        CreateMap<Data.Models.Patient, UpdatePatientResponse>()
            .ForMember(dest =>dest.FullName,x=>x.MapFrom(src=>src.FullName))
            .ForMember(dest =>dest.ProfilePicture,x=>x.MapFrom(src=>src.ProfilePicture))
            .ForMember(dest =>dest.DateOfBirth,x=>x.MapFrom(src=>src.DateOfBirth))
            .ForMember(dest =>dest.PhoneNumber,x=>x.MapFrom(src=>src.ApplicationUser.PhoneNumber))
            .ForMember(dest =>dest.Email,x=>x.MapFrom(src=>src.ApplicationUser.Email))
            .ReverseMap();
    }
}
