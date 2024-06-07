namespace Core.Domain.Posts.Data;

public record CreatePostData(Guid UserId, string Header, string Content);