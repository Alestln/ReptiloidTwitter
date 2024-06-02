namespace Core.Domain.Photos.Data;

public record CreateProfilePhotoData(
    Guid UserId,
    string FilePath);