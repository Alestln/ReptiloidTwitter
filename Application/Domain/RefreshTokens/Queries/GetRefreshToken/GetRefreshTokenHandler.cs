using Core.Domain.Accounts.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Application.Domain.RefreshTokens.Queries.GetRefreshToken;

public class GetRefreshTokenHandler(SocialDbContext socialDbContext) : IRequestHandler<GetRefreshTokenQuery, RefreshToken?>
{
    public async Task<RefreshToken?> Handle(GetRefreshTokenQuery request, CancellationToken cancellationToken)
    {
        var refreshToken = await socialDbContext.RefreshTokens
            .Include(r => r.Account)
            .ThenInclude(a => a.Roles)
            .Where(r => r.Token == request.RefreshToken)
            .SingleOrDefaultAsync(cancellationToken);

        return refreshToken;
    }
}