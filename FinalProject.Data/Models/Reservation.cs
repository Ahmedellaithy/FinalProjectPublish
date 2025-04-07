using System.ComponentModel.DataAnnotations.Schema;
using FinalProject.Data.Enums.Reservation;

namespace FinalProject.Data.Models;

public class Reservation
{
    public int Id { get; set; }
    public int DoctorId { get; set; }
    public int PatientId { get; set; }
    public DateTime ReservationDate { get; set; }
    public Status Status { get; set; }
    public bool IsAvailable { get; set; } = true;
    
    
    public virtual Doctor Doctor { get; set; }
    public virtual Patient Patient { get; set; }
}