using Core.Common;
using Core.Domain.Photos.Models;
using Core.Domain.PostComments.Models;
using Core.Domain.Posts.Data;
using Core.Domain.UserProfiles.Models;

namespace Core.Domain.Posts.Models;

public class Post : Entity
{
    public long Id { get; private set; }
    
    public Guid UserId { get; private set; }

    public string Header { get; private set; }
    
    public string Content { get; private set; }
    
    public DateTime CreatedAt { get; private set; }

    public UserProfile User { get; private set; }

    public IReadOnlyCollection<UserProfile> Likes { get; private set; }

    public IReadOnlyCollection<PostComment> Comments { get; private set; }
    
    public IReadOnlyCollection<Photo> Photos { get; private set; }
    
    private Post(long id, Guid userId, string header, string content, DateTime createdAt)
    {
        Id = id;
        UserId = userId;
        Header = header;
        Content = content;
        CreatedAt = createdAt;
    }

    public static Post Create(CreatePostData data)
    {
        return new Post(
            id: default,
            userId: data.UserId,
            header: data.Header,
            content: data.Content,
            createdAt: DateTime.UtcNow);
    }
}