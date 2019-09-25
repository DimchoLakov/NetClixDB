using System.Linq;
using AutoMapper;
using NetPhlixDb.Data.ViewModels.Admin.Movies;
using NetPhlixDb.Data.ViewModels.Events;
using NetPhlixDb.Data.ViewModels.Movies;
using NetPhlixDb.Data.ViewModels.People;
using NetPhlixDB.Data.Models;
using NetPhlixDB.Services.Mapping.Constants;

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
                                src => src.Storyline.Length >= 250 ? src.Storyline.Substring(0, 250) + "..." : src.Storyline))
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
                .ReverseMap();

            // Movie Person View Model
            CreateMap<Person, MoviePersonViewModel>()
                .ForMember(dest => dest.FullName, mapFrom => mapFrom.MapFrom(src => src.FirstName + " " + src.LastName))
                .ForMember(dest => dest.PersonRole, mapFrom => mapFrom.MapFrom(src => src.PersonRole.ToString()))
                .ReverseMap();

            // Movie Review View Model
            CreateMap<Review, MovieReviewViewModel>()
                .ForMember(dest => dest.UserName, mapFrom => mapFrom.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.UserAvatar, mapFrom => mapFrom.MapFrom(src => src.User.Avatar))
                .ReverseMap();

            // Create Movie View Model
            CreateMap<CreateMovieViewModel, Movie>()
                //.ForMember(dest => dest.Trailer, mapFrom => mapFrom.MapFrom(src => src.Trailer.UrlToEmbedCode()))
                .ReverseMap();

            // Movie Event View Model
            CreateMap<Movie, MovieEventViewModel>()
                .ForMember(dest => dest.MovieId, mapFrom => mapFrom.MapFrom(src => src.Id))
                .ForMember(dest => dest.MovieTitle, mapFrom => mapFrom.MapFrom(src => src.Title))
                .ForMember(dest => dest.DateReleased, mapFrom => mapFrom.MapFrom(src => src.DateReleased.ToString("yyyy")))
                .ReverseMap();
        }
    }
}
