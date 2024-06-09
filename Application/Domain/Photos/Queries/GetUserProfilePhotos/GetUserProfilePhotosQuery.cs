using Application.Dtos.Photos;
using MediatR;

namespace Application.Domain.Photos.Queries.GetUserProfilePhotos;

public record GetUserProfilePhotosQuery(
    Guid UserProfileId) : IRequest<IEnumerable<PhotoListDto>>;