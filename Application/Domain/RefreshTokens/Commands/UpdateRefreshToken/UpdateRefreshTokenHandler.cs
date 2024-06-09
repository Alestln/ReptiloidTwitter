using Core.Domain.Accounts.Data;
using Core.Domain.Accounts.Models;
using Core.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Application.Domain.RefreshTokens.Commands.UpdateRefreshToken;

public class UpdateRefreshTokenHandler(SocialDbContext socialDbContext) : IRequestHandler<UpdateRefreshTokenCommand, Unit>
{
    public async Task<Unit> Handle(UpdateRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var oldRefreshToken = await socialDbContext.RefreshTokens
                .Where(r => r.AccountId == request.AccountId
                            && r.Token == request.OldRefreshToken)
                .SingleAsync(cancellationToken);

            socialDbContext.Entry(oldRefreshToken).State = EntityState.Deleted;

            var newRefreshTokenData = new CreateRefreshTokenData(
                request.NewRefreshToken,
                request.AccountId,
                request.NewExpires);

            var newRefreshToken = RefreshToken.Create(newRefreshTokenData);

            socialDbContext.Entry(newRefreshToken).State = EntityState.Added;
            
            await socialDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
        catch (ArgumentNullException)
        {
            throw new NotFoundException($"Refresh token not found.\nAccountId: {request.AccountId}\nOldRefreshToken: {request.OldRefreshToken}");
        }
        catch (InvalidOperationException)
        {
            throw new NotFoundException($"Multiple refresh tokens found for the same account.\nAccountId: {request.AccountId}\nOldRefreshToken: {request.OldRefreshToken}");
        }
    }
}