using System.Globalization;
using FinalProject.Core.CQRS.Reservation.Queries.Response;

namespace FinalProject.Core.MappingProfile.Reservation;

public partial class ReservationMapping
{
    public void GetAllReservationsQueryMapping()
    {
        CreateMap<Data.Models.Reservation, GetDoctorReservationsResponse>()
            .ForMember(dest => dest.PatientName, x => x.MapFrom(src => src.Patient.FullName))
            .ForMember(dest => dest.ReservationDate, x => x.MapFrom(src => src.ReservationDate.ToString("M/d/yyyy h:mm:ss tt")))
            .ReverseMap();
    }
}

