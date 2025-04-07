using System.ComponentModel.DataAnnotations.Schema;
using FinalProject.Data.Identity;
using Microsoft.AspNetCore.Http;

namespace FinalProject.Data.Models;

public class Doctor
{
    public int Id { get; set; }
    public int ApplicationUserId { get; set; }
    public string FullName { get; set; }
    public int YearsOfExperience { get; set; }
    public string Degree { get; set; }
    public string Specialty { get; set; }
    public string Focus { get; set; }
    public string Profile { get; set; }
    public string CareerPath { get; set; }
    public string Highlights { get; set; }
    public string ProfilePicture { get; set; }
    public TimeSpan AvailableFrom { get; set; }
    public TimeSpan AvailableTo { get; set; }
    
    
    
    public virtual ApplicationUser ApplicationUser { get; set; }
    public virtual ICollection<Reservation> Reservations { get; set; }
    
}