using Core.Domain.Accounts.Data;
using Core.Domain.Accounts.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Application.Domain.RefreshTokens.Commands;

public class CreateRefreshTokenHandler(SocialDbContext socialDbContext) : IRequestHandler<CreateRefreshTokenCommand, Unit>
{
    public async Task<Unit> Handle(CreateRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var refreshTokenData = new CreateRefreshTokenData(request.RefreshToken, request.AccountId, request.Expires);

        var refreshToken = RefreshToken.Create(refreshTokenData);

        socialDbContext.Entry(refreshToken).State = EntityState.Added;
        await socialDbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}