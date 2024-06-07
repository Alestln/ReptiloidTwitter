using AutoMapper;
using Core.Domain.Accounts.Data;
using Core.Domain.Accounts.Models;
using Core.Domain.Roles.Models;
using Core.Domain.UserProfiles.Data;
using Core.Domain.UserProfiles.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Application.Domain.Accounts.Commands.CreateAccount;

public class CreateAccountHandler(
    SocialDbContext socialDbContext,
    IMapper mapper) : IRequestHandler<CreateAccountCommand, Account>
{
    public async Task<Account> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var data = mapper.Map<CreateAccountData>(request);

        var account = Account.Create(data);

        // TODO: Remove this variable
        const string userRoleTitle = "User";

        var role = await socialDbContext.Roles
            .Where(r => r.Title.Trim().ToLower() == userRoleTitle.Trim().ToLower())
            .FirstOrDefaultAsync(cancellationToken);

        if (role is null) 
            throw new NullReferenceException($"User role is null. UserRoleTitle: {userRoleTitle}");

        var userProfileData = new CreateUserProfileData(account.Id, request.FirstName, request.LastName);

        var userProfile = UserProfile.Create(userProfileData);

        socialDbContext.Entry(account).State = EntityState.Added;
        socialDbContext.Entry(RoleAccount.Create(account.Id, role.Id)).State = EntityState.Added;
        socialDbContext.Entry(userProfile).State = EntityState.Added;
        
        await socialDbContext.SaveChangesAsync(cancellationToken);
        
        return account;
    }
}