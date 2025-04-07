using AutoMapper;

namespace FinalProject.Core.MappingProfile.Patient;

public partial class PatientMapping : Profile
{
    public PatientMapping()
    {
        GetPatientByIdQueryMapping();
        UpdatePatientCommandMapping();
    }
}
