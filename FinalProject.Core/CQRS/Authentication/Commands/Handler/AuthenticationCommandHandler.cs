using AutoMapper;
using FinalProject.Core.CQRS.Authentication.Commands.Response;
using FinalProject.Data.Enums.Patient;
using FinalProject.Data.Identity;
using FinalProject.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Core.Bases;

namespace FinalProject.Core.CQRS.Authentication.Commands.Handler;

public class AuthenticationCommandHandler : ExtraResponseHandler,
                                            IRequestHandler<RegisterCommand,ExtraResponseOutput<RegisterResponse>>,
                                            IRequestHandler<LogInCommand,ExtraResponseOutput<LogInResponse>>,
                                            IRequestHandler<SetNewPasswordCommand,ExtraResponseOutput<SetNewPasswordResponse>>

{
    private readonly UserManager<ApplicationUser> _user;
    private readonly Service.Interfaces.IAuthenticationService _service;
    private readonly IPatientService _patient;
    private readonly IMapper _mapper;
    public AuthenticationCommandHandler(UserManager<ApplicationUser> user,
                                        Service.Interfaces.IAuthenticationService service,
                                        IPatientService patient,
                                        IMapper mapper)
    {
        _user = user;
        _service = service;
        _patient = patient;
        _mapper = mapper;
    }
    
    public async Task<ExtraResponseOutput<RegisterResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var userEmail = await _user.FindByEmailAsync(request.Email);
        if (userEmail != null)
        {
            return  UnprocessableEntity<RegisterResponse>("The email address is already in use. Please use a different one");
        }

        var userPhone = await _user.Users.SingleOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber);
        if (userPhone != null)
        {
            return  UnprocessableEntity<RegisterResponse>("This phone number is already registered. please use a different phone number or log in to your existing account");
        }

        var user = new ApplicationUser {
            Email = request.Email, UserName = request.Email, PhoneNumber = request.PhoneNumber, EmailConfirmed = true,
        };
        var result = await _user.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            return BadRequest<RegisterResponse>("Failed to create user");
        }
        
        var patient = new Data.Models.Patient
        {
            Gender = request.Gender, FullName = request.FullName, DateOfBirth = request.DateOfBirth,ApplicationUserId = user.Id,
        };
        await _patient.AddPatientAsync(patient);
        await _patient.SaveChangesAsync();
        
        var mappedResult = _mapper.Map<RegisterResponse>(patient);
        
        var token = await _service.GenerateJWTToken(user);
        mappedResult.AccessToken=token.AccessToken;
        mappedResult.RefreshToken=token.RefreshToken;
        
        return Success(mappedResult);
        
    }
    
    

    public async Task<ExtraResponseOutput<LogInResponse>> Handle(LogInCommand request, CancellationToken cancellationToken)
    {
        var response = new LogInResponse();
        var user = await _user.FindByEmailAsync(request.EmailOrPhone);
        if (user == null)
        {
            var userPhone = await _user.Users.FirstOrDefaultAsync(x => x.PhoneNumber == request.EmailOrPhone);
            if (userPhone == null)
            {
                return BadRequest<LogInResponse>("Invalid email or password");
            }

            if (userPhone.Email != null && await _user.CheckPasswordAsync(userPhone, request.Password))
            {
                response = await _service.GenerateJWTToken(userPhone);
                return Success(response);
            }
            return BadRequest<LogInResponse>("Invalid email or password");
        }
        if (await _user.CheckPasswordAsync(user, request.Password))
        {
            response = await _service.GenerateJWTToken(user);
            return Success(response);
        }
        return NotFound<LogInResponse>("Invalid email or password");
    }
    
    
    
    public async Task<ExtraResponseOutput<SetNewPasswordResponse>> Handle(SetNewPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _user.FindByIdAsync(request.Id.ToString());
        if (user == null) return NotFound<SetNewPasswordResponse>("user not found");
        
        if(request.Password != request.ConfirmPassword) return BadRequest<SetNewPasswordResponse>("password and confirm password do not match");

        var result = await _user.RemovePasswordAsync(user);
        if (!result.Succeeded) return BadRequest<SetNewPasswordResponse>("Failed to update password");
        await _user.AddPasswordAsync(user,request.Password);
        
        await _user.UpdateAsync(user);
        
        SetNewPasswordResponse response = new SetNewPasswordResponse();
        response.Email=user.Email;
        
        return Success(response);
    }
}