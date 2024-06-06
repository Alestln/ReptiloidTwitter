using Application.Dtos.UserProfiles;
using MediatR;

namespace Application.Domain.UserProfiles.Queries.GetUserProfileInfo;

public record GetUserProfileInfoQuery(Guid Id) : IRequest<UserProfileInfoDto>;