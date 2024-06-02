using Core.Domain.Accounts.Models;
using Core.Domain.Photos.Data;
using Core.Domain.Photos.Enums;
using Core.Domain.Photos.Models.Abstractions;

namespace Core.Domain.Photos.Models.ConcreteTypes;

public class ProfilePhoto : Photo
{
    public Guid UserId { get; private set; }

    public Account User { get; private set; }

    public ProfilePhoto(Guid id, Guid userId, string filePath, DateTime uploadDate) 
        : base(id, filePath, uploadDate, PhotoType.Profile)
    {
        UserId = userId;
    }
    
    public static ProfilePhoto Create(CreateProfilePhotoData data)
    {
        return new ProfilePhoto(
            id: Guid.NewGuid(),
            userId: data.UserId,
            filePath: data.FilePath,
            uploadDate: DateTime.UtcNow);
    }
}