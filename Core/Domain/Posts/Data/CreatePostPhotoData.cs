namespace Core.Domain.Posts.Data;

public record CreatePostPhotoData(
    long PostId,
    Guid PhotoId);