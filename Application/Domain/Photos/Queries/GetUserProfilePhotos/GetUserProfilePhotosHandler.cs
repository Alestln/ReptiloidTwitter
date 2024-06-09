using Application.Dtos.Photos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Application.Domain.Photos.Queries.GetUserProfilePhotos;

public class GetUserProfilePhotosHandler(
    SocialDbContext socialDbContext,
    IMapper mapper) : IRequestHandler<GetUserProfilePhotosQuery, IEnumerable<PhotoListDto>>
{
    public async Task<IEnumerable<PhotoListDto>> Handle(GetUserProfilePhotosQuery request, CancellationToken cancellationToken)
    {
        var photos = await socialDbContext.UserProfiles
            .Where(up => up.AccountId == request.UserProfileId)
            .SelectMany(up => up.Photos)
            .ProjectTo<PhotoListDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return photos;
    }
}