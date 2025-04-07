using FinalProject.Data.Models;

namespace FinalProject.Service.Interfaces;

public interface IReservationService
{
    Task<ICollection<Reservation>> GetPatientReservationsAsync(int id);
    Task<List<Reservation>> GetDoctorReservationsAsync(int id);
    Task<Reservation> CancelPatientReservationAsync(int patientId, int doctorId, DateTime reservationDate);
    Task<string> DeleteReservationAsync(Reservation reservation);

    Task<string> MakeReservationAsync(int patientId, int doctorId, string reservationDate);

    Task<Reservation> GetLastReservation();
    Task<Reservation> GetReservationByPatientAsync(int patientId);
    
    Task<List<Reservation>> GetAllReservationAsync();
    
    Task SaveChangesAsync();
}