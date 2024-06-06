using Application.Dtos.Accounts;
using AutoMapper;
using Core.Domain.Accounts.Data;
using Core.Domain.Accounts.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Application.Domain.Accounts.Commands.CreateAccount;

public class CreateAccountHandler(
    SocialDbContext socialDbContext,
    IMapper mapper) : IRequestHandler<CreateAccountCommand, AuthenticationResponse>
{
    public async Task<AuthenticationResponse> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var data = mapper.Map<CreateAccountData>(request);

        var account = Account.Create(data);

        socialDbContext.Entry(account).State = EntityState.Added;
        await socialDbContext.SaveChangesAsync(cancellationToken);

        return new AuthenticationResponse();
    }
}