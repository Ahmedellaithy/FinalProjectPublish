using System.Text;
using System.Text.Json.Serialization;
using FinalProject.Core;
using FinalProject.Core.CQRS.Admin.Commands.Validator;
using FinalProject.Core.CQRS.Authentication.Commands.Validators;
using FinalProject.Core.CQRS.Patient.Commands.Validator;
using FinalProject.Core.CQRS.Reservation.Commands.Validator;
using FinalProject.Core.ValidationFilter;
using FinalProject.Data.Identity;
using FinalProject.Infrastructure;
using FinalProject.Infrastructure.Context;
using FinalProject.Service;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    options.JsonSerializerOptions.AllowTrailingCommas = true;
});


builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<RegisterValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<SetNewPasswordValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdatePatientProfilePictureValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<MakeReservationValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<AddDoctorByAdminValidator>();


//builder.Services.AddControllers(options =>
//    {
//        options.Filters.Add<ValidationFilter>();
//    })
//    .AddFluentValidation(fv=>fv.RegisterValidatorsFromAssemblyContaining<RegisterValidator>())
//    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddDoctorByAdminValidator>())
//    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<EditDoctorByAdminValidator>())
//    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RemoveDoctorByAdminValidator>())
//    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<MakeReservationValidator>())
//    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UpdatePatientProfilePictureValidator>())
//    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<SetNewPasswordValidator>());

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


//Add Entity to our Service(Add ConnectionString to Database)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//Add Identity to our Service
builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>(options =>
    {
        options.Password.RequiredLength = 8;
        options.Password.RequireUppercase = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireNonAlphanumeric = true;
        
        options.User.RequireUniqueEmail = true;
        options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

        options.Lockout.MaxFailedAccessAttempts = 5;
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
        
    }).AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();



//Add JWTToken to our Service
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.SaveToken = true;
        x.RequireHttpsMetadata = false;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Issuer"],
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        }; 
    });


//Add Services
builder.Services.AddService();              
builder.Services.AddInfrastrucutre();
builder.Services.AddCore();

builder.Services.AddCors();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "FinalProject"));
}

app.UseHttpsRedirection();


app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();