using Core.Domain.Photos.Data;
using Core.Domain.Photos.Enums;
using Core.Domain.Photos.Models.Abstractions;

namespace Core.Domain.Photos.Models.ConcreteTypes;

public class PostPhoto : Photo
{
    public long PostId { get; private set; }

    public PostPhoto(Guid id, long postId, string filePath, DateTime uploadDate) 
        : base(id, filePath, uploadDate, PhotoType.Post)
    {
        PostId = postId;
    }
    
    public static PostPhoto Create(CreatePostPhotoData data)
    {
        return new PostPhoto(
            id: Guid.NewGuid(),
            postId: data.PostId,
            filePath: data.FilePath,
            uploadDate: DateTime.UtcNow);
    }
}