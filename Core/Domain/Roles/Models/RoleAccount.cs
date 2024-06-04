using Core.Common;
using Core.Domain.Accounts.Models;
using Core.Domain.Roles.Data;

namespace Core.Domain.Roles.Models;

public class RoleAccount : Entity
{
    public Guid AccountId { get; private set; }
    
    public int RoleId { get; private set; }
    
    public Account Account { get; private set; }
    
    public Role Role { get; private set; }

    private RoleAccount(Guid accountId, int roleId)
    {
        AccountId = accountId;
        RoleId = roleId;
    }

    public static RoleAccount Create(CreateRoleAccountData data)
    {
        return new RoleAccount(
            accountId: data.AccountId,
            roleId: data.RoleId);
    }
}