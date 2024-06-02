using Core.Common;
using Core.Domain.UserProfiles.Data;

namespace Core.Domain.UserProfiles.Models;

public class UserProfile : Entity
{
    public Guid AccountId { get; private set; }

    public string FirstName { get; private set; }
    
    public string LastName { get; private set; }
    
    public string? MiddleName { get; private set; }

    public DateTime? BirthdayDate { get; private set; }

    public string? Bio { get; private set; }
    
    private UserProfile(Guid accountId, string firstName, string lastName, string middleName, DateTime? birthdayDate, string bio)
    {
        AccountId = accountId;
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        BirthdayDate = birthdayDate;
        Bio = bio;
    }

    public static UserProfile Create(CreateUserProfileData data)
    {
        return new UserProfile(
            accountId: data.AccountId,
            firstName: data.FirstName,
            lastName: data.LastName,
            middleName: data.MiddleName,
            birthdayDate: data.BirthdayDate,
            bio: data.Bio);
    }
}