using Application.Dtos.Authentication;
using Core.Domain.Accounts.Models;

namespace ReptiloidTwitter.Services.Authentication;

public interface IJwtAuthenticationService
{
    AuthenticationResponse GenerateTokens(Account account);

    AccessToken UpdateAccessToken(Account account);

    Task InvalidateTokensAsync(Guid accountId, CancellationToken cancellationToken);
}