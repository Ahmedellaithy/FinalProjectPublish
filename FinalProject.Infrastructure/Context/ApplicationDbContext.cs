
using FinalProject.Data.Identity;
using FinalProject.Data.Models;
using FinalProject.Data.Models.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Infrastructure.Context;

public class ApplicationDbContext: IdentityDbContext<IdentityUser<int>,IdentityRole<int>,int,IdentityUserClaim<int>,IdentityUserRole<int>,IdentityUserLogin<int>,IdentityRoleClaim<int>,IdentityUserToken<int>>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {       
        builder.HasDefaultSchema("FinalProject");
        
        //Patient Table
        builder.Entity<Patient>().HasKey(x => x.Id);
        builder.Entity<Patient>().HasOne(x => x.ApplicationUser)
            .WithOne(x => x.Patient).HasForeignKey<Patient>(x => x.ApplicationUserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<Patient>().Property(x => x.FullName).IsRequired().HasMaxLength(80);
        builder.Entity<Patient>().Property(x => x.DateOfBirth).IsRequired();
        builder.Entity<Patient>().Property(x => x.Gender).IsRequired();
        builder.Entity<Patient>().HasIndex(x => x.ProfilePicture).IsUnique();
        builder.Entity<Patient>().ToTable("Patient");
        
        
        //Doctor Table
        builder.Entity<Doctor>().HasKey(x => x.Id);
        builder.Entity<Doctor>().HasOne(x => x.ApplicationUser)
            .WithOne(x => x.Doctor).HasForeignKey<Doctor>(x => x.ApplicationUserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<Doctor>().Property(x =>x.FullName).IsRequired().HasMaxLength(80);
        builder.Entity<Doctor>().Property(x => x.YearsOfExperience).IsRequired();
        builder.Entity<Doctor>().Property(x => x.Degree).HasMaxLength(10).IsRequired();
        builder.Entity<Doctor>().Property(x => x.Specialty).IsRequired().HasMaxLength(30);
        builder.Entity<Doctor>().Property(x => x.Focus).IsRequired().HasMaxLength(100);
        builder.Entity<Doctor>().Property(x => x.Profile).IsRequired().HasMaxLength(200);
        builder.Entity<Doctor>().Property(x => x.CareerPath).IsRequired().HasMaxLength(200);
        builder.Entity<Doctor>().Property(x => x.Highlights).IsRequired().HasMaxLength(200);
        builder.Entity<Doctor>().HasIndex(c => c.ProfilePicture).IsUnique();
        builder.Entity<Doctor>().Property(x => x.AvailableFrom).IsRequired();
        builder.Entity<Doctor>().Property(x => x.AvailableTo).IsRequired();
        builder.Entity<Doctor>().ToTable("Doctor");
        
        
        //Admin Table
        builder.Entity<Admin>().HasKey(x => x.Id);
        builder.Entity<Admin>().Property(x => x.FullName).IsRequired().HasMaxLength(80);
        builder.Entity<Admin>().ToTable("Admin");
        
        
        //Reservation Table
        builder.Entity<Reservation>().HasKey(x => x.Id);

        builder.Entity<Reservation>().HasOne(x => x.Doctor)
            .WithMany(x => x.Reservations).HasForeignKey(x => x.DoctorId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.Entity<Reservation>().HasOne(x=>x.Patient)
            .WithMany(x=>x.Reservations).HasForeignKey(x=>x.PatientId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Reservation>().Property(x => x.ReservationDate).IsRequired();
        builder.Entity<Reservation>().Property(x => x.Status).HasConversion<string>().IsRequired();
        builder.Entity<Reservation>().Property(x => x.IsAvailable).IsRequired();
        builder.Entity<Reservation>().ToTable("Reservation");
       
        
        //Identity Tables
        builder.Entity<ApplicationUser>().Property(x => x.PhoneNumber).IsRequired().HasMaxLength(15);
        
        
        base.OnModelCreating(builder);
    }
    
    //public DbSet<ApplicationUser> ApplicationUser { get; set; }
    public DbSet<Patient> Patient { get; set; }
    public DbSet<Doctor> Doctor { get; set; }
    public DbSet<Admin> Admin { get; set; }
    public DbSet<Reservation> Reservation { get; set; }
    public DbSet<RefereshToken> RefreshToken { get; set; }
}