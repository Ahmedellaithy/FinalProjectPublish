using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using FinalProject.Data.Enums.Patient;
using FinalProject.Data.Identity;
using Microsoft.AspNetCore.Http;

namespace FinalProject.Data.Models;

public class Patient
{
    public int Id { get; set; }
    public int ApplicationUserId { get; set; }
    public string FullName { get; set; }
    public string? ProfilePicture { get; set; }
    public DateOnly DateOfBirth { get; set; }
    
    public string Gender { get; set; }
    
    public virtual ApplicationUser ApplicationUser { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
}