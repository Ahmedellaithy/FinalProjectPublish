using Com.CloudRail.SI.ServiceCode.Commands;
using FinalProject.Core.CQRS.Authentication.Commands.Response;
using FinalProject.Data.Identity;

namespace FinalProject.Core.MappingProfile.Authenticationmapping;

public partial class AuthenticationMapping
{
    public void RegisterCommandMapping()
    {
        CreateMap<Data.Models.Patient, RegisterResponse>()
            .ForMember(dest => dest.FullName , x=>x.MapFrom(src => src.FullName))
            .ForMember(dest=>dest.Email,x=>x.MapFrom(src=>src.ApplicationUser.Email))
            .ForMember(dest=>dest.PhoneNumber,x=>x.MapFrom(src=>src.ApplicationUser.PhoneNumber))
            .ForMember(dest=>dest.Gender,x=>x.MapFrom(src=>src.Gender))
            .ForMember(dest=>dest.DateOfBirth,x=>x.MapFrom(src=>src.DateOfBirth))
            .ReverseMap();
    }
}