using Core.Common;
using Core.Domain.Accounts.Models;

namespace Core.Domain.Roles.Models;

public class RoleAccount : Entity
{
    public Guid AccountId { get; private set; }
    
    public int RoleId { get; private set; }
    
    public Account Account { get; private set; }
    
    public Role Role { get; private set; }
}