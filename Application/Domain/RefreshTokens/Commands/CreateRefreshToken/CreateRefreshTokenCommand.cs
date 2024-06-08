using MediatR;

namespace Application.Domain.RefreshTokens.Commands.CreateRefreshToken;

public record CreateRefreshTokenCommand(
    string RefreshToken,
    Guid AccountId,
    long Expires) : IRequest<Unit>;