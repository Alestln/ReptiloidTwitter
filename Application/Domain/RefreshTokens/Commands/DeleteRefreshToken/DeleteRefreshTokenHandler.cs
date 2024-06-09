using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Application.Domain.RefreshTokens.Commands.DeleteRefreshToken;

public class DeleteRefreshTokenHandler(SocialDbContext socialDbContext) : IRequestHandler<DeleteRefreshTokenCommand, Unit>
{
    public async Task<Unit> Handle(DeleteRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        socialDbContext.Entry(request.RefreshToken).State = EntityState.Deleted;
        await socialDbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}