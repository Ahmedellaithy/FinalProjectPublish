using System.Globalization;
using FinalProject.Data.Enums.Reservation;
using FinalProject.Data.Models;
using FinalProject.Infrastructure.Context;
using FinalProject.Infrastructure.GenericRepositories;
using FinalProject.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Infrastructure.Repositories;

public class ReservationRepository : GenericRepository<Reservation>,
                                     IReservationRepository
                                     
{
    private readonly DbSet<Reservation> _reservation;
    public ReservationRepository(ApplicationDbContext context) : base(context)
    {
        _reservation = context.Set<Reservation>();
    }

    public async Task<ICollection<Reservation>> GetAllReservationsAsync()
    {
        var reservations = await _reservation.ToListAsync();
        return reservations;
    }

    public async Task<Reservation> GetReservationByIdAsync(int id)
    {
        var reservation = await _reservation.FindAsync(id);
        return reservation;
    }

    public async Task<Reservation> GetReservationsByGivenDoctorAsync(int doctorId, string reservationDate)
    {
        if (!DateTime.TryParseExact(
                reservationDate, 
                "yyyy-MM-dd hh:mm tt",  
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime reservationDateTime))
        {
            throw new ArgumentException("Invalid date format. Use 'yyyy-MM-dd hh:mm tt'");
        }

        var result = await _reservation.FirstOrDefaultAsync(x =>
            x.DoctorId == doctorId &&
            x.ReservationDate.Year == reservationDateTime.Year &&
            x.ReservationDate.Month == reservationDateTime.Month &&
            x.ReservationDate.Day == reservationDateTime.Day &&
            x.ReservationDate.Hour == reservationDateTime.Hour &&
            x.ReservationDate.Minute == reservationDateTime.Minute
            );

        return result;
    }


}