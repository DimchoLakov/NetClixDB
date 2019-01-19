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

            // Movie With People To Assign View Model
            CreateMap<Movie, MovieWithPeopleToAssignViewModel>()
                .ForMember(dest => dest.MovieId, mapFrom => mapFrom.MapFrom(src => src.Id))
                .ReverseMap();

            // Movie With People To Unassign View Model
            CreateMap<Movie, MovieWithPeopleToUnassignViewModel>()
                .ForMember(dest => dest.MovieId, mapFrom => mapFrom.MapFrom(src => src.Id))
                .ReverseMap();
            
            // Person To Assign View Model
            CreateMap<Person, PersonAssignViewModel>()
                .ForMember(dest => dest.PersonId, mapFrom => mapFrom.MapFrom(src => src.Id))
                .ForMember(dest => dest.FullName, mapFrom => mapFrom.MapFrom(src => src.FirstName + " " + src.LastName))
                .ReverseMap();

            // Assign Person To Movie View Model
            CreateMap<MoviePerson, AssignPersonToMovieViewModel>()
                .ReverseMap();
        }
    }
}
