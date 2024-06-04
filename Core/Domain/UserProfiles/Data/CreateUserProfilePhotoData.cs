namespace Core.Domain.UserProfiles.Data;

public record CreateUserProfilePhotoData(
    Guid UserProfileId,
    Guid PhotoId);