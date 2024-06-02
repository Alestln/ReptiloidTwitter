namespace Core.Domain.Photos.Data;

public record CreatePostPhotoData(
    long PostId,
    string FilePath);