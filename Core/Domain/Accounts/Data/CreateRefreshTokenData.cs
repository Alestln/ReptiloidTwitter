namespace Core.Domain.Accounts.Data;

public record CreateRefreshTokenData(
    string Token,
    Guid AccountId,
    long Expires);