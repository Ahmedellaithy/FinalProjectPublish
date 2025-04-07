using System.ComponentModel.DataAnnotations.Schema;
using FinalProject.Data.Identity;

namespace FinalProject.Data.Models.Authentication;

public class RefereshToken
{
    public int Id { get; set; }
    public string Token { get; set; } 
    public DateTime CreatedAt { get; set; }
    public DateTime ExpiredAt { get; set; }
    public DateTime? RevokedOn { get; set; }
    public bool IsActive => RevokedOn == null && !IsExpired;
    public bool IsExpired  => DateTime.UtcNow >= ExpiredAt;
    
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual ApplicationUser ApplicationUser { get; set; }
    
}