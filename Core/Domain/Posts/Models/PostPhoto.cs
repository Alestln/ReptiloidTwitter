using Core.Common;
using Core.Domain.Photos.Models;
using Core.Domain.Posts.Data;

namespace Core.Domain.Posts.Models;

public class PostPhoto : Entity
{
    public long PostId { get; private set; }
    
    public Guid PhotoId { get; private set; }
    
    public Post Post { get; private set; }
    
    public Photo Photo { get; private set; }

    private PostPhoto(long postId, Guid photoId)
    {
        PostId = postId;
        PhotoId = photoId;
    }
}