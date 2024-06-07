using System.Security.Authentication;
using Core.Domain.Accounts.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Application.Domain.Accounts.Queries.GetAccount;

public class GetAccountByLoginHandler(SocialDbContext socialDbContext) 
    : IRequestHandler<GetAccountByLoginQuery, Account>
{
    public async Task<Account> Handle(GetAccountByLoginQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var account = await socialDbContext.Accounts
                .Include(a => a.Roles)
                .Where(a => a.Username == request.Login
                            && a.Password == request.Password)
                .SingleAsync(cancellationToken);

            return account;
        }
        catch (ArgumentNullException)
        {
            throw new AuthenticationException(
                $"Account is null.\nUsername: {request.Login}\nPassword: {request.Password}");
        }
        catch (InvalidOperationException)
        {
            throw new AuthenticationException(
                $"DB contains more than one element or contains no elements.\nUsername: {request.Login}\nPassword: {request.Password}");
        }
    }
}