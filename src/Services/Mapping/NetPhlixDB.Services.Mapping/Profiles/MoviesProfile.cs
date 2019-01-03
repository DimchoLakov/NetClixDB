using System.Linq;
using AutoMapper;
using NetPhlixDb.Data.ViewModels.Movies;
using NetPhlixDB.Data.Models;

namespace NetPhlixDB.Services.Mapping.Profiles
{
    public class MoviesProfile : Profile
    {
        public MoviesProfile()
        {
            // Index Movie View Model
            CreateMap<Movie, IndexMovieViewModel>()
                .ForMember(dest => dest.DateReleased, mapFrom => mapFrom.MapFrom(src => src.DateReleased.ToString("MMM/dd/yyyy")))
                .ForMember(
                    dest => dest.ShortStoryline,
                       mapFrom => mapFrom.MapFrom(
                                src => src.Storyline.Length >= 50 ? src.Storyline.Substring(0, 50) + "..." : src.Storyline))
                .ForMember(
                    dest => dest.Rating,
                       mapFrom => mapFrom.MapFrom(
                                src => double.IsNaN(src.Reviews.Sum(x => x.Rating) / src.Reviews.Count) ? 0 : src.Reviews.Sum(x => x.Rating) / src.Reviews.Count))
                .ReverseMap();

            // Movie Details View Model
            CreateMap<Movie, MovieDetailsViewModel>()
                .ForMember(dest => dest.YearReleased,
                    mapFrom => mapFrom.MapFrom(src => src.DateReleased.ToString("yyyy")))
                .ForMember(dest => dest.FullDateReleased,
                    mapFrom => mapFrom.MapFrom(src => src.DateReleased.ToString("MMM/dd/yyyy")))
                .ForMember(dest => dest.Language, mapFrom => mapFrom.MapFrom(src => src.Language.ToString()))
                .ForMember(dest => dest.MovieType, mapFrom => mapFrom.MapFrom(src => src.MovieType.ToString()))
                .ForMember(
                    dest => dest.Rating,
                    mapFrom => mapFrom.MapFrom(
                        src => double.IsNaN(src.Reviews.Sum(x => x.Rating) / src.Reviews.Count)
                            ? 0
                            : src.Reviews.Sum(x => x.Rating) / src.Reviews.Count))
                .ForMember(dest => dest.ProductionCost, mapFrom => mapFrom.MapFrom(src => src.ProductionCost.ToString("F2")))
                .ReverseMap();
            
            // Movie Genre View Model
            CreateMap<Genre, MovieGenreViewModel>()
                .ForMember(dest => dest.Name, mapFrom => mapFrom.MapFrom(src => src.GenreType.ToString()));

            // Movie Person View Model
            CreateMap<Person, MoviePersonViewModel>()
                .ForMember(dest => dest.FullName, mapFrom => mapFrom.MapFrom(src => src.FirstName + " " + src.LastName))
                .ForMember(dest => dest.PersonRole, mapFrom => mapFrom.MapFrom(src => src.PersonRole.ToString()));

            // Movie Review View Model
            CreateMap<Review, MovieReviewViewModel>()
                .ForMember(dest => dest.DateAdded,
                    mapFrom => mapFrom.MapFrom(src => src.DateAdded.ToString("MMM/dd/yyyy")))
                .ForMember(dest => dest.UserName, mapFrom => mapFrom.MapFrom(src => src.User.FirstName + "" + src.User.LastName))
                .ForMember(dest => dest.UserAvatar, mapFrom => mapFrom.MapFrom(src => src.User.Avatar));
        }
    }
}
