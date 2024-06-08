using MediatR;

namespace Application.Domain.RefreshTokens.Commands.UpdateRefreshToken;

public record UpdateRefreshTokenCommand(
    Guid AccountId,
    string OldRefreshToken,
    string NewRefreshToken,
    long NewExpires) : IRequest<Unit>;