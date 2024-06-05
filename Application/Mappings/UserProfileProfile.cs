using Application.Dtos.UserProfile;
using AutoMapper;
using Core.Domain.UserProfiles.Models;

namespace Application.Mappings;

public class UserProfileProfile : Profile
{
    public UserProfileProfile()
    {
        CreateProjection<UserProfile, UserProfileInfoDto>()
            .ForMember(d => d.PhotoFile, opt =>
                opt.MapFrom(up => up.Avatar.File));
    }
}