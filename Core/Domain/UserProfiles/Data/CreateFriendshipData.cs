namespace Core.Domain.UserProfiles.Data;

public record CreateFriendshipData(
    Guid UserId,
    Guid FriendId);