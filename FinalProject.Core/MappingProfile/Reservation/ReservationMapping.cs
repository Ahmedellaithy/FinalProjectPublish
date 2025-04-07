using AutoMapper;

namespace FinalProject.Core.MappingProfile.Reservation;

public partial class ReservationMapping : Profile
{
    public ReservationMapping()
    {
        GetPatientReservationsQueryMapping();
        MakeReservationCommandMapping();
        GetAllReservationsQueryMapping();
        CancelReservationCommandMapping();
        GetAllReservationsByAdminQueryMapping();
    }
}