using Core.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Application.Domain.RefreshTokens.Commands.DeleteRefreshToken;

public class DeleteRefreshTokenHandler(SocialDbContext socialDbContext) : IRequestHandler<DeleteRefreshTokenCommand, Unit>
{
    public async Task<Unit> Handle(DeleteRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var refreshToken = await socialDbContext.RefreshTokens
                .Where(r => r.Token == request.RefreshToken)
                .SingleAsync(cancellationToken);

            socialDbContext.Entry(refreshToken).State = EntityState.Deleted;
            await socialDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
        catch (ArgumentNullException)
        {
            throw new NotFoundException($"Refresh token is null. Token: {request.RefreshToken}");
        }
        catch (InvalidOperationException)
        {
            throw new NotFoundException($"DB contains more than one elements or contains no elements. Token: {request.RefreshToken}");
        }
    }
}