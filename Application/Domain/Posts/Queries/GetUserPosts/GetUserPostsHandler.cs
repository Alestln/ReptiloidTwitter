using Application.Dtos.Posts;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Application.Domain.Posts.Queries.GetUserPosts;

public class GetUserPostsHandler(
    SocialDbContext socialDbContext,
    IMapper mapper) : IRequestHandler<GetUserPostsQuery, IEnumerable<PostListDto>>
{
    public async Task<IEnumerable<PostListDto>> Handle(GetUserPostsQuery request, CancellationToken cancellationToken)
    {
        var userPosts = await socialDbContext.Posts
            .Where(up => up.UserId == request.UserProfileId)
            .ProjectTo<PostListDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return userPosts;
    }
}