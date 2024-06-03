namespace Core.Domain.UserProfiles.Data;

public record CreateUserProfileData(
    Guid AccountId,
    string FirstName,
    string LastName,
    string? MiddleName = null,
    DateTime? BirthdayDate = null, 
    string? Bio = null,
    Guid? AvatarId = null);