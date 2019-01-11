using System.Linq;
using AutoMapper;
using NetPhlixDb.Data.ViewModels.Admin.Movies;
using NetPhlixDb.Data.ViewModels.Movies;
using NetPhlixDb.Data.ViewModels.People;
using NetPhlixDB.Data.Models;

namespace NetPhlixDB.Services.Mapping.Profiles
{
    public class MoviesProfile : Profile
    {
        public MoviesProfile()
        {
            // Index Movie View Model
            CreateMap<Movie, IndexMovieViewModel>()
                .ForMember(dest => dest.DateReleased, mapFrom => mapFrom.MapFrom(src => src.DateReleased.ToString(ProfileConstants.FullDateFormat)))
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
                    mapFrom => mapFrom.MapFrom(src => src.DateReleased.ToString(ProfileConstants.YearDateFormat)))
                .ForMember(dest => dest.FullDateReleased,
                    mapFrom => mapFrom.MapFrom(src => src.DateReleased.ToString(ProfileConstants.FullDateFormat)))
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
                .ForMember(dest => dest.UserName, mapFrom => mapFrom.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.UserAvatar, mapFrom => mapFrom.MapFrom(src => src.User.Avatar));

            // Create Movie View Model
            CreateMap<CreateMovieViewModel, Movie>()
                //.ForMember(dest => dest.Trailer, mapFrom => mapFrom.MapFrom(src => src.Trailer.UrlToEmbedCode()))
                .ReverseMap();
        }
    }
}
