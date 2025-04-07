using AutoMapper;

namespace FinalProject.Core.MappingProfile.Doctor;

public partial class DoctorMapping : Profile
{
    public DoctorMapping()
    {
        EditDoctorByAdminCommand();
        AddDoctorByAdminCommandMapping();
        GetDoctorsPaginatedQueryMapping();
        GetDoctorByIdQueryMapping();
        AddDoctorCommandMapping();
        RemoveDoctorByAdminCommandMapping();
    }
}