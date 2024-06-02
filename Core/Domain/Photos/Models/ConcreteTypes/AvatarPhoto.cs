using Core.Domain.Accounts.Models;
using Core.Domain.Photos.Data;
using Core.Domain.Photos.Enums;
using Core.Domain.Photos.Models.Abstractions;

namespace Core.Domain.Photos.Models.ConcreteTypes;

public class AvatarPhoto : Photo
{
    public Guid UserId { get; private set; }

    public Account User { get; private set; }
    
    public AvatarPhoto(Guid id, Guid userId, string filePath, DateTime uploadDate) 
        : base(id, filePath, uploadDate, PhotoType.Avatar)
    {
        UserId = userId;
    }
    
    public static AvatarPhoto Create(CreateAvatarPhotoData data)
    {
        return new AvatarPhoto(
            id: Guid.NewGuid(),
            userId: data.UserId,
            filePath: data.FilePath,
            uploadDate: DateTime.UtcNow);
    }
}