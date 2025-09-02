using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using VehicleQuotes.Api.ResourceModels;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace VehicleQuotes.Api.Services;

public class JwtService(IConfiguration configuration)
{
    private const int EXPIRATION_MINUTES = 1;

    public AuthenticationResponse CreateToken(IdentityUser user)
    {
        var expiration = DateTime.UtcNow.AddMinutes(EXPIRATION_MINUTES);
        
        var token = CreateJwtToken(CreateClaims(user), CreateSigningCredentials, expiration);
        var tokenHandler = new JwtSecurityTokenHandler();
        return new AuthenticationResponse
        {
            Token = tokenHandler.WriteToken(token),
            ExpiresAt = expiration
        };
    }

    private JwtSecurityToken CreateJwtToken(Claim[] claims, SigningCredentials credentials, DateTime expiration)
    {
        return new JwtSecurityToken(
            configuration["Jwt:Issuer"],
            configuration["Jwt:Audience"],
            claims,
            expires: expiration,
            signingCredentials: credentials
        );
    }

    private Claim[] CreateClaims(IdentityUser user)
    {
        return new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, configuration["Jwt:Subject"]),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName)
        };
    }

    private SigningCredentials CreateSigningCredentials() => new SigningCredentials(
        new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
        SecurityAlgorithms.HmacSha256
        );

}