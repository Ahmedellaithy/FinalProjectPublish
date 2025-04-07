using AutoMapper;

namespace FinalProject.Core.MappingProfile.Authenticationmapping;

public partial class AuthenticationMapping : Profile
{
    public AuthenticationMapping()
    {
        RegisterCommandMapping();
    }
}