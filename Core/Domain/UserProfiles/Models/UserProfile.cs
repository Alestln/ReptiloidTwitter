using Core.Common;
using Core.Domain.Accounts.Models;
using Core.Domain.Photos.Models;
using Core.Domain.UserProfiles.Data;

namespace Core.Domain.UserProfiles.Models;

public class UserProfile : Entity
{
    public Guid AccountId { get; private set; }

    public string? FirstName { get; private set; }
    
    public string? LastName { get; private set; }
    
    public string? MiddleName { get; private set; }

    public DateTime? BirthdayDate { get; private set; }

    public string? Bio { get; private set; }

    public Guid? AvatarId { get; private set; }
    
    public Account Account { get; private set; }

    public Photo Avatar { get; private set; }

    public ICollection<UserProfile> Friends { get; private set; }
    
    public ICollection<Photo> Photos { get; private set; }
    
    private UserProfile(
        Guid accountId,
        string firstName,
        string lastName,
        string? middleName = null,
        DateTime? birthdayDate = null,
        string? bio = null,
        Guid? avatarId = null)
    {
        AccountId = accountId;
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        BirthdayDate = birthdayDate;
        Bio = bio;
        AvatarId = avatarId;
    }

    public static UserProfile Create(CreateUserProfileData data)
    {
        return new UserProfile(
            accountId: data.AccountId,
            firstName: data.FirstName,
            lastName: data.LastName,
            middleName: data.MiddleName,
            birthdayDate: data.BirthdayDate,
            bio: data.Bio,
            avatarId: data.AvatarId);
    }
}