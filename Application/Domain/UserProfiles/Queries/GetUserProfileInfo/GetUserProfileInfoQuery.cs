using Application.Dtos.UserProfile;
using MediatR;

namespace Application.Domain.UserProfiles.Queries.GetUserProfileInfo;

public record GetUserProfileInfoQuery(Guid Id) : IRequest<UserProfileInfoDto>;