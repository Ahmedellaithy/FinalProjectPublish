using System.ComponentModel.DataAnnotations.Schema;
using FinalProject.Data.Models;
using FinalProject.Data.Models.Authentication;
using Microsoft.AspNetCore.Identity;

namespace FinalProject.Data.Identity;

public class ApplicationUser : IdentityUser<int>
{
    public virtual Patient Patient { get; set; }
    public virtual Doctor Doctor { get; set; }
    public virtual ICollection<RefereshToken> RefereshTokens { get; set; }
}