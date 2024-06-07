namespace Application.Dtos.Authentication;

public class AuthenticationResponse
{
    public string AccessToken { get; set; }

    public string RefreshToken { get; set; }

    public long RefreshTokenExpiration { get; set; }
}