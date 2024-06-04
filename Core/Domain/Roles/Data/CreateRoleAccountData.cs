namespace Core.Domain.Roles.Data;

public record CreateRoleAccountData(
    Guid AccountId,
    int RoleId);