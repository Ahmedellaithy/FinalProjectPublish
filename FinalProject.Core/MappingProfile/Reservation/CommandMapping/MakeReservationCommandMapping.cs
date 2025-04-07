using FinalProject.Data.CommandResponse.ReservationResponse;

namespace FinalProject.Core.MappingProfile.Reservation;

public partial class ReservationMapping
{

    public void MakeReservationCommandMapping()
    {
        CreateMap<Data.Models.Reservation, MakeReservationResponse>()
            .ForMember(dest =>dest.PatientName,x=>x.MapFrom(src=>src.Patient.FullName))
            .ForMember(dest =>dest.DoctorName,x=>x.MapFrom(src=>src.Doctor.FullName))
            .ForMember(dest =>dest.ReservationDate,x=>x.MapFrom(src=>src.ReservationDate.ToString("yyyy-MM-dd hh:mm tt")));
    }
}
