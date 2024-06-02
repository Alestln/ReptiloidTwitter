namespace Core.Domain.Photos.Data;

public record CreateAvatarPhotoData(
    Guid UserId, 
    string FilePath);