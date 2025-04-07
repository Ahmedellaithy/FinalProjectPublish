using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using FinalProject.Core.CQRS.Authentication.Commands.Response;
using FinalProject.Data.Identity;
using FinalProject.Data.Models.Authentication;
using FinalProject.Infrastructure.Interfaces;
using FinalProject.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FinalProject.Service.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IRefreshTokenRepository _reftoken;
    private readonly IConfiguration _configuration;
    public AuthenticationService(IConfiguration configuration, IRefreshTokenRepository reftoken)
    {
        _configuration = configuration;
        _reftoken = reftoken;
    }
    

    public async Task<LogInResponse> GenerateJWTToken(ApplicationUser user)
    {
        List<Claim> Claims = new List<Claim>();
        Claims.Add(new Claim(ClaimTypes.Email, user.Email));
        Claims.Add(new Claim(ClaimTypes.MobilePhone, user.PhoneNumber));

        
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        
        var jwtTokenCreate = new JwtSecurityToken(
            claims:Claims,
            issuer:_configuration["Jwt:Issuer"],
            audience:_configuration["Jwt:Audience"],
            expires: DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Jwt:ExpiresDate"]!)),
            signingCredentials:signingCredentials
        );
        string jwtToken = new JwtSecurityTokenHandler().WriteToken(jwtTokenCreate);


        var refreshToken = new RefereshToken
        {
            Token = GenerateRefreshToken(),
            CreatedAt = DateTime.UtcNow,
            ExpiredAt = DateTime.UtcNow.AddMonths(int.Parse(_configuration["Jwt:RefreshTokenExpiresDate"]!)),
            RevokedOn = DateTime.UtcNow.AddMonths(int.Parse(_configuration["Jwt:RefreshTokenExpiresDate"]!)),
            UserId = user.Id
        };
        await _reftoken.AddAsync(refreshToken);
        await _reftoken.SaveChangesAsync();

        var response = new LogInResponse();
        response.AccessToken = jwtToken;
        response.RefreshToken = refreshToken.Token;
        
        return response;
    }


    private string GenerateRefreshToken()
    {
        RandomNumberGenerator rng = RandomNumberGenerator.Create();
        byte[] data = new byte[32];
        rng.GetBytes(data);
        return Convert.ToBase64String(data);
    }
    
}