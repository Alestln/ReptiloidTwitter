using MediatR;

namespace Application.Domain.RefreshTokens.Commands;

public record CreateRefreshTokenCommand(
    string RefreshToken,
    Guid AccountId,
    long Expires) : IRequest<Unit>;