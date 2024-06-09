using Core.Domain.Accounts.Models;
using MediatR;

namespace Application.Domain.RefreshTokens.Queries.GetRefreshToken;

public record GetRefreshTokenQuery(string RefreshToken) : IRequest<RefreshToken?>;