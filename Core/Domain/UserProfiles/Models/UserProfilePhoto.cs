using Core.Common;
using Core.Domain.Photos.Models;
using Core.Domain.UserProfiles.Data;

namespace Core.Domain.UserProfiles.Models;

public class UserProfilePhoto : Entity
{
    public Guid UserProfileId { get; private set; }
    
    public Guid PhotoId { get; private set; }
    
    public UserProfile UserProfile { get; private set; }
    
    public Photo Photo { get; private set; }

    private UserProfilePhoto(Guid userProfileId, Guid photoId)
    {
        UserProfileId = userProfileId;
        PhotoId = photoId;
    }

    public static UserProfilePhoto Create(CreateUserProfilePhotoData data)
    {
        return new UserProfilePhoto(
            userProfileId: data.UserProfileId,
            photoId: data.PhotoId);
    }
}