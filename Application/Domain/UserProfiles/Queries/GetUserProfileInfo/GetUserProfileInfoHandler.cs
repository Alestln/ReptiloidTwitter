using Application.Dtos.UserProfile;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Application.Domain.UserProfiles.Queries.GetUserProfileInfo;

public class GetUserProfileInfoHandler(
    SocialDbContext socialDbContext,
    IMapper mapper) : IRequestHandler<GetUserProfileInfoQuery, UserProfileInfoDto>
{
    public async Task<UserProfileInfoDto> Handle(GetUserProfileInfoQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var userProfile = await socialDbContext.UserProfiles
                .Where(up => up.AccountId == request.Id)
                .ProjectTo<UserProfileInfoDto>(mapper.ConfigurationProvider)
                .SingleAsync(cancellationToken);
            
            return userProfile;
        }
        catch (ArgumentNullException)
        {
            throw new NotFoundException($"UserProfile is null. Id: {request.Id}");
        }
        catch (InvalidOperationException)
        {
            throw new NotFoundException(
                $"DB contains more than one elements or contains no elements. Id: {request.Id}");
        }
    }
}