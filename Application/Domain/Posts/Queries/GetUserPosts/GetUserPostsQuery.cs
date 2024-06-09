using Application.Dtos.Posts;
using MediatR;

namespace Application.Domain.Posts.Queries.GetUserPosts;

public record GetUserPostsQuery(
    Guid UserProfileId) : IRequest<IEnumerable<PostListDto>>;