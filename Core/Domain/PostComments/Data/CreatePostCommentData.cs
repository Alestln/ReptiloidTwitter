namespace Core.Domain.PostComments.Data;

public record CreatePostCommentData(
    long PostId, 
    Guid UserId, 
    string Content);