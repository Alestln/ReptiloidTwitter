using Core.Domain.Accounts.Models;
using MediatR;

namespace Application.Domain.RefreshTokens.Commands.DeleteRefreshToken;

public record DeleteRefreshTokenCommand(string RefreshToken) : IRequest<Unit>;