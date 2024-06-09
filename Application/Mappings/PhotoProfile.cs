using Application.Dtos.Photos;
using AutoMapper;
using Core.Domain.Photos.Models;

namespace Application.Mappings;

public class PhotoProfile : Profile
{
    public PhotoProfile()
    {
        CreateProjection<Photo, PhotoListDto>();
    }
}