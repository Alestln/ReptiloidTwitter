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
            var refreshToken = await socialDbContext.RefreshTokens
                .Where(r => r.AccountId == request.AccountId
                            && r.Token == request.OldRefreshToken)
                .SingleAsync(cancellationToken);
            
            refreshToken.Update(request.NewRefreshToken, request.NewExpires);

            socialDbContext.Entry(refreshToken).State = EntityState.Modified;
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