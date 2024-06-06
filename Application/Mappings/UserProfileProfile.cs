using System.Globalization;
using Application.Dtos.UserProfiles;
using AutoMapper;
using Core.Domain.UserProfiles.Models;

namespace Application.Mappings;

public class UserProfileProfile : Profile
{
    public UserProfileProfile()
    {
        CreateProjection<UserProfile, UserProfileInfoDto>()
            .ForMember(d => d.PhotoFile, opt =>
                opt.MapFrom(up => up.Avatar.File))
            .ForMember(d => d.BirthdayDate, opt =>
                opt.MapFrom(up => up.BirthdayDate.HasValue ? up.BirthdayDate.Value.ToString("dd MMMM yyyy", new CultureInfo("uk-UA")) : null));
    }
}