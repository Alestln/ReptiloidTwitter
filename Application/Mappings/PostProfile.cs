using System.Globalization;
using Application.Dtos.Posts;
using AutoMapper;
using Core.Domain.Posts.Models;

namespace Application.Mappings;

public class PostProfile : Profile
{
    public PostProfile()
    {
        CreateProjection<Post, PostListDto>()
            .ForMember(d => d.Date, opt =>
                opt.MapFrom(p => p.CreatedAt.ToString("dd MMMM yyyy", new CultureInfo("uk-UA"))))
            .ForMember(d => d.Time, opt =>
                opt.MapFrom(p => p.CreatedAt.ToString("HH:mm", new CultureInfo("uk-UA"))))
            .ForMember(d => d.Photos, opt =>
                opt.MapFrom(p => p.Photos.Select(ph => ph.File)));
    }
}