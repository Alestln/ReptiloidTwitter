namespace Application.Dtos.Accounts;

public class AuthenticationResponse
{
    public string AccessToken { get; set; }

    public string RefreshToken { get; set; }

    public int RefreshTokenExpiration { get; set; }
}