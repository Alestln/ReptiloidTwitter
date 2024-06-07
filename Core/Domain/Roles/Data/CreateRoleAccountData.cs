namespace Core.Domain.Roles.Data;

public record CreateRoleAccountData(
    Guid AccountId,
    Guid RoleId);