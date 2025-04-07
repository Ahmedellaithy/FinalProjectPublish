using FinalProject.Core.CQRS.Admin.Queries.Response;

namespace FinalProject.Core.MappingProfile.Reservation;

public partial class ReservationMapping
{

    public void GetAllReservationsByAdminQueryMapping()
    {
        CreateMap<Data.Models.Reservation, GetAllReservationsByAdminResponse>()
            .ForMember(dest => dest.DoctorName, x => x.MapFrom(src => src.Doctor.FullName))
            .ForMember(dest => dest.PatientName, x => x.MapFrom(src => src.Patient.FullName))
            .ForMember(dest => dest.ReservationDate,
                x => x.MapFrom(src => src.ReservationDate.ToString("hh:mm tt")));
    }
}