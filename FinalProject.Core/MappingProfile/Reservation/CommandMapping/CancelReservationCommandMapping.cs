using FinalProject.Data.CommandResponse.ReservationResponse;

namespace FinalProject.Core.MappingProfile.Reservation;

public partial class ReservationMapping
{
    public void CancelReservationCommandMapping()
    {
        CreateMap<Data.Models.Reservation, CancelPatientReservationResponse>()
            .ForMember(dest=>dest.DoctorName,x=>x.MapFrom(src=>src.Doctor.FullName))
            .ForMember(dest=>dest.PatientName,x=>x.MapFrom(src=>src.Patient.FullName))
            .ForMember(dest=>dest.ReservationDate,x=>x.MapFrom(src=>src.ReservationDate))
            .ReverseMap();
    }
}
