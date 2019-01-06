using AutoMapper;
using NetPhlixDb.Data.ViewModels.Movies;
using NetPhlixDB.Data.Models;

namespace NetPhlixDB.Services.Mapping.Profiles
{
    public class CompaniesProfile : Profile
    {
        public CompaniesProfile()
        {
            // Movie Company View Model
            CreateMap<Company, MovieCompanyViewModel>()
                .ForMember(dest => dest.CreatedOn, mapFrom => mapFrom.MapFrom(src => src.CreatedOn.ToString(ProfileConstants.FullDateFormat)))
                .ReverseMap();
        }
    }
}
