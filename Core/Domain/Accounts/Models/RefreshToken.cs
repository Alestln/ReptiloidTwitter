using Core.Domain.Accounts.Data;

namespace Core.Domain.Accounts.Models;

public class RefreshToken
{
    public string Token { get; private set; }

    public Guid AccountId { get; private set; }

    public long Expires { get; private set; }

    private RefreshToken(string token, Guid accountId, long expires)
    {
        Token = token;
        AccountId = accountId;
        Expires = expires;
    }

    public static RefreshToken Create(CreateRefreshTokenData data)
    {
        return new RefreshToken(
            token: data.Token,
            accountId: data.AccountId,
            expires: data.Expires);
    }

    public void Update(string token, long expires)
    {
        Token = token;
        Expires = expires;
    }
}