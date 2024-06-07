using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Security.Cryptography;
using Application.Dtos.Authentication;
using Core.Domain.Accounts.Models;
using Microsoft.IdentityModel.Tokens;
using Persistence.Contexts;
using ReptiloidTwitter.Configuration;

namespace ReptiloidTwitter.Services.Authentication;

public class JwtAuthenticationService(
    IConfiguration configuration,
    SocialDbContext socialDbContext) : IJwtAuthenticationService
{
    public AuthenticationResponse GenerateTokens(Account account)
    {
        var authenticationResponse = new AuthenticationResponse
        {
            AccessToken = GenerateAccessToken(account),
            RefreshToken = GenerateRefreshToken(),
            RefreshTokenExpiration = DateTimeOffset.UtcNow.AddMinutes(2).ToUnixTimeSeconds()
        };
        
        return authenticationResponse;
    }

    private string GenerateAccessToken(Account account)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, account.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, account.Username),
            new Claim(JwtRegisteredClaimNames.Email, account.Email)
        };

        foreach (var role in account.Roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role.Title));
        }

        var jwtCredentials = configuration.GetSection("Jwt").Get<JwtCredentials>();

        if (jwtCredentials is not null)
        {
            var credentials = new SigningCredentials(jwtCredentials.SecurityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtCredentials.Issuer,
                audience: jwtCredentials.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        throw new AuthenticationException(
            $"JwtCredentials is null. Place of error: {nameof(JwtAuthenticationService)}.{nameof(GenerateAccessToken)}");
    }

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var generator = RandomNumberGenerator.Create();
        
        generator.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }
}