using AutoMapper;
using NetPhlixDb.Data.ViewModels.Admin.Companies;
using NetPhlixDb.Data.ViewModels.Admin.Genres;
using NetPhlixDb.Data.ViewModels.Admin.Movies;
using NetPhlixDb.Data.ViewModels.Admin.People;
using NetPhlixDb.Data.ViewModels.Admin.Users;
using NetPhlixDB.Data.Models;

namespace NetPhlixDB.Services.Mapping.Profiles.Admin
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            // Index Movie View Model
            CreateMap<Movie, IndexAdminMovieViewModel>()
                .ReverseMap();
            
            // Edit Delete Movie View Model
            CreateMap<Movie, EditMovieViewModel>()
                .ReverseMap();

            // Index Genre View Model
            CreateMap<Genre, IndexGenreViewModel>()
                .ReverseMap();

            // Edit Delete Details Genre View Model
            CreateMap<Genre, EditDeleteDetailsGenreViewModel>()
                .ReverseMap();

            // Create Genre View Model
            CreateMap<Genre, CreateGenreViewModel>()
                .ReverseMap();

            // Index Company View Model
            CreateMap<Company, IndexCompanyViewModel>()
                .ReverseMap();

            // Create Company View Model
            CreateMap<Company, CreateCompanyViewModel>()
                .ReverseMap();

            // Edit Delete Details Genre View Model
            CreateMap<Company, EditDeleteDetailsGenreViewModel>()
                .ReverseMap();

            // User Id View Model
            CreateMap<User, UserIdViewModel>()
                .ReverseMap();

            // User View Model
            CreateMap<User, UserViewModel>()
                .ReverseMap();

            // Index Person View Model
            CreateMap<Person, IndexPersonViewModel>()
                .ForMember(dest => dest.FullName,
                    mapFrom => mapFrom.MapFrom(src => src.FirstName + " " + src.LastName));

            // Create Person View Model
            CreateMap<Person, CreatePersonViewModel>()
                .ReverseMap();

            // Edit Person View Model
            CreateMap<Person, EditPersonViewModel>()
                .ReverseMap();

            // Movie Add Genre View Model
            CreateMap<Movie, MovieAddGenreViewModel>()
                .ReverseMap();
        }
    }
}
