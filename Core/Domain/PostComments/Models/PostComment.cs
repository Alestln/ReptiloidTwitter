using Core.Common;
using Core.Domain.PostComments.Data;

namespace Core.Domain.PostComments.Models;

public class PostComment : Entity
{
    public long Id { get; private set; }
    
    public long PostId { get; private set; }
    
    public Guid UserId { get; private set; }
    
    public string Content { get; private set; }
    
    public DateTime CreatedDate { get; private set; }
    
    private PostComment(long id, long postId, Guid userId, string content, DateTime createdDate)
    {
        Id = id;
        PostId = postId;
        UserId = userId;
        Content = content;
        CreatedDate = createdDate;
    }

    public static PostComment Create(CreatePostCommentData data)
    {
        return new PostComment(
            id: default,
            postId: data.PostId,
            userId: data.UserId,
            content: data.Content,
            createdDate: DateTime.UtcNow);
    }
}