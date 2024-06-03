using Core.Common;
using Core.Domain.UserProfiles.Data;

namespace Core.Domain.UserProfiles.Models;

public class Friendship : Entity
{
    public Guid UserId { get; private set; }
    
    public Guid FriendId { get; private set; }
    
    public UserProfile User { get; private set; }
    
    public UserProfile Friend { get; private set; }

    private Friendship(Guid userId, Guid friendId)
    {
        UserId = userId;
        FriendId = friendId;
    }

    public static Friendship Create(CreateFriendshipData data)
    {
        return new Friendship(
            userId: data.UserId,
            friendId: data.FriendId);
    }
}