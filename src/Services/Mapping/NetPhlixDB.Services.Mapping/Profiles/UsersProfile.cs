using AutoMapper;
using NetPhlixDb.Data.ViewModels.Users;
using NetPhlixDB.Data.Models;
using NetPhlixDB.Services.Mapping.Constants;

namespace NetPhlixDB.Services.Mapping.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            // User Id Email ViewModel
            CreateMap<User, UserIdEmailViewModel>()
                .ForMember(dest => dest.CreatedOn, mapFrom => mapFrom.MapFrom(
                    src => src.CreatedOn.ToString(ProfileConstants.FullDateFormat)))
                .ReverseMap();

            // User Id Email ViewModel
            CreateMap<User, UserInfoViewModel>()
                .ReverseMap();
        }
    }
}
