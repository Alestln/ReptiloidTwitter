namespace Application.Dtos.Authentication;

public class AccessToken
{
    public string Token { get; set; }
    
    public long Expires { get; set; }
}