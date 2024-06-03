namespace Core.Domain.UserProfiles.Data;

public record CreateUserProfileData(
    Guid AccountId, 
    string FirstName, 
    string LastName, 
    string MiddleName, 
    DateTime? BirthdayDate, 
    string Bio,
    Guid AvatarId);