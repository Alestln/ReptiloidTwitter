using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Security.Cryptography;
using Application.Dtos.Authentication;
using Core.Domain.Accounts.Models;
using Microsoft.EntityFrameworkCore;
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
            AccessTokenExpiration = DateTimeOffset.UtcNow.AddSeconds(25).ToUnixTimeSeconds(),
            RefreshToken = GenerateRefreshToken(),
            RefreshTokenExpiration = DateTimeOffset.UtcNow.AddMinutes(2).ToUnixTimeSeconds()
        };
        
        return authenticationResponse;
    }

    public AccessToken UpdateAccessToken(Account account)
    {
        return new AccessToken()
        {
            Token = GenerateAccessToken(account),
            Expires = DateTimeOffset.UtcNow.AddSeconds(25).ToUnixTimeSeconds()
        };
    }

    public async Task InvalidateTokensAsync(Guid accountId, CancellationToken cancellationToken)
    {
        var tokens = await socialDbContext.RefreshTokens
            .Where(r => r.AccountId == accountId)
            .ToListAsync(cancellationToken);
        
        socialDbContext.RefreshTokens.RemoveRange(tokens);
        
        await socialDbContext.SaveChangesAsync(cancellationToken);
    }
    
    private string GenerateAccessToken(Account account)
    {
        var jwtCredentials = configuration.GetSection("Jwt").Get<JwtCredentials>();
        
        if (jwtCredentials is not null)
        {
            var credentials = new SigningCredentials(jwtCredentials.SecurityKey, SecurityAlgorithms.HmacSha256);
            
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, account.Id.ToString()),
                new(JwtRegisteredClaimNames.UniqueName, account.Username),
                new(JwtRegisteredClaimNames.Email, account.Email)
            };
        
            claims.AddRange(account.Roles.Select(role => new Claim(ClaimTypes.Role, role.Title)));
            
            var token = new JwtSecurityToken(
                issuer: jwtCredentials.Issuer,
                audience: jwtCredentials.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddSeconds(30),
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
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