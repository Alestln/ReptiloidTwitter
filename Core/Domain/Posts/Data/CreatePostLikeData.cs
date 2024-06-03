namespace Core.Domain.Posts.Data;

public record CreatePostLikeData(
    long PostId,
    Guid UserId);