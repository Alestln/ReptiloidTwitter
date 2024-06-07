using Application.Dtos.Authentication;
using Core.Domain.Accounts.Models;

namespace ReptiloidTwitter.Services.Authentication;

public interface IJwtAuthenticationService
{
    AuthenticationResponse GenerateTokens(Account account);
}