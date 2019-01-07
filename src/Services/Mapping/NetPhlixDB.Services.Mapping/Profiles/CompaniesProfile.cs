using AutoMapper;
using NetPhlixDb.Data.ViewModels.Companies;
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
                .ReverseMap();

            // Company View Model
            CreateMap<Company, CompanyViewModel>()
                .ReverseMap();

            // Company Movie View Model
            CreateMap<Movie, CompanyMovieViewModel>()
                .ReverseMap();

            // Company Short View Model
            CreateMap<Company, CompanyShortViewModel>()
                .ReverseMap();
        }
    }
}
