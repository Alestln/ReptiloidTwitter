using Core.Common;
using Core.Domain.Posts.Data;
using Core.Domain.UserProfiles.Models;

namespace Core.Domain.Posts.Models;

public class PostLike : Entity
{
    public long PostId { get; private set; }
    
    public Guid UserId { get; private set; }
    
    public Post Post { get; private set; }
    
    public UserProfile User { get; private set; }

    private PostLike(long postId, Guid userId)
    {
        PostId = postId;
        UserId = userId;
    }
}