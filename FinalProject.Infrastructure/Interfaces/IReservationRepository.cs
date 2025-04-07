using FinalProject.Data.Models;
using FinalProject.Infrastructure.GenericRepositories;

namespace FinalProject.Infrastructure.Interfaces;

public interface IReservationRepository : IGenericRepository<Reservation>
{
    Task<ICollection<Reservation>> GetAllReservationsAsync();
    Task<Reservation> GetReservationByIdAsync(int id);
    
    Task<Reservation> GetReservationsByGivenDoctorAsync(int doctorId, string reservationDate);
}