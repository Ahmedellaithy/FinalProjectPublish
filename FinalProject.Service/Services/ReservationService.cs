using System.Globalization;
using FinalProject.Data.Enums.Reservation;
using FinalProject.Data.Models;
using FinalProject.Infrastructure.Interfaces;
using FinalProject.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Service.Services;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservation;
    private readonly IDoctorRepository _doctor;
    private readonly IPatientRepository _patient;
    public ReservationService(IReservationRepository reservation, IDoctorRepository doctor, IPatientRepository patient)
    {
        _reservation = reservation;
        _doctor = doctor;
        _patient = patient;
    }


    public async Task<ICollection<Reservation>> GetPatientReservationsAsync(int id)
    {
        var reservations = await _reservation.GetTableNoTracking()
            .Include(x => x.Patient).Include(x => x.Doctor)
            .Where(x => x.PatientId == id).ToListAsync();

        return reservations;
    }

    public async Task<List<Reservation>> GetDoctorReservationsAsync(int id)
    {
        var reservations = await _reservation.GetTableNoTracking()
            .Include(x => x.Patient)
            .Include(x => x.Doctor)
            .Where(x => x.DoctorId == id).ToListAsync();
        
        return reservations;
    }
    

    public async Task<Reservation> CancelPatientReservationAsync(int patientId, int doctorId,DateTime reservationDate)
    {
       var reservation = await _reservation.GetTableNoTracking()
           .Include(x => x.Patient).Include(x => x.Doctor)
           .FirstOrDefaultAsync(x => x.PatientId == patientId && x.DoctorId == doctorId && x.ReservationDate == reservationDate);

       if (reservation == null) return null;

       await _reservation.DeleteAsync(reservation);
       await _reservation.SaveChangesAsync();
       return reservation;
    }

    public async Task<string> DeleteReservationAsync(Reservation reservation)
    {
        await _reservation.DeleteByIdAsync(reservation.Id);
        await _reservation.SaveChangesAsync();
        return "Deleted Successfully";
    }

    
    public async Task<string> MakeReservationAsync(int patientId, int doctorId, string reservationDateTime)
    {
        var patient = await _patient.GetPatientByIdAsync(patientId);
        if(patient == null) return "Patient not found";
        
        var doctor = await _doctor.GetDoctorByIdAsync(doctorId);
        if(doctor == null) return "Doctor not found";


        var availableFromDate =
            DateTime.ParseExact(reservationDateTime, "yyyy-MM-dd hh:mm tt", CultureInfo.InvariantCulture).TimeOfDay;

        var availableToDate =
            DateTime.ParseExact(reservationDateTime, "yyyy-MM-dd hh:mm tt", CultureInfo.InvariantCulture).TimeOfDay;

        if (availableFromDate<doctor.AvailableFrom || availableToDate>doctor.AvailableTo)
            return "Sorry, Doctor is not available";
        
        
        // var existingReservation = await _reservation.(x =>
        //     x.DoctorId == doctorId &&
        //     x.ReservationDate.Date == reservationTime.Date &&  // Same day
        //     Math.Abs((x.ReservationDate - reservationTime).TotalMinutes) < 60 && 
        //     x.IsAvailable == false);
        //
        // if (existingReservation != null)
        //     return "not";
        
        
        var reservation = await _reservation.GetReservationsByGivenDoctorAsync(doctorId, reservationDateTime);
        if(reservation != null) return "not";

        var addReservation = new Reservation()
        {
            ReservationDate = DateTime.ParseExact(reservationDateTime, "yyyy-MM-dd hh:mm tt", CultureInfo.InvariantCulture),
            DoctorId = doctor.Id,
            PatientId = patient.Id,
            IsAvailable = false,
            Status = Status.Confirmed
        };
        await _reservation.AddAsync(addReservation);
        await _reservation.SaveChangesAsync();

        return "Done";
    }

    public async Task<Reservation> GetLastReservation()
    {
        var reservation = await _reservation.GetTableNoTracking()
            .Include(x => x.Patient)
            .Include(x => x.Doctor)
            .FirstOrDefaultAsync();

        return reservation;
    }

    public async Task<Reservation> GetReservationByPatientAsync(int patientId)
    {
        var reservation = await _reservation.GetTableNoTracking()
                                            .Where(x=>x.PatientId == patientId).FirstOrDefaultAsync();
        
        return reservation;
    }

    public async Task<List<Reservation>> GetAllReservationAsync()
    {
        var reservations = await _reservation.GetTableNoTracking()
            .Include(x=>x.Patient)
            .Include(x=>x.Doctor).ToListAsync();
        
        return reservations;
    }

    public async Task SaveChangesAsync()
    {
        await _reservation.SaveChangesAsync();
    }
}