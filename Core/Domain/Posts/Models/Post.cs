using Core.Common;
using Core.Domain.Accounts.Models;
using Core.Domain.Posts.Data;

namespace Core.Domain.Posts.Models;

public class Post : Entity
{
    public long Id { get; private set; }
    
    public Guid UserId { get; private set; }
    
    public string Content { get; private set; }
    
    public DateTime CreatedAt { get; private set; }

    public Account User { get; private set; }
    
    private Post(long id, Guid userId, string content, DateTime createdAt)
    {
        Id = id;
        UserId = userId;
        Content = content;
        CreatedAt = createdAt;
    }

    public static Post Create(CreatePostData data)
    {
        return new Post(
            id: default,
            userId: data.UserId,
            content: data.Content,
            createdAt: DateTime.UtcNow);
    }
}