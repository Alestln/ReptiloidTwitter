using System.Buffers.Text;

namespace Application.Dtos.UserProfile;

public class UserProfileInfoDto
{
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }
    
    public string? MiddleName { get; set; }

    public string? BirthdayDate { get; set; }

    public string? Bio { get; set; }

    public string PhotoFile { get; set; }
}