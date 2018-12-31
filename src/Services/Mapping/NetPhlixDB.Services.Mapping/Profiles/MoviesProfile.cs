using System.Linq;
using AutoMapper;
using NetPhlixDb.Data.ViewModels;
using NetPhlixDB.Data.Models;

namespace NetPhlixDB.Services.Mapping
{
    public class MoviesProfile : Profile
    {
        public MoviesProfile()
        {
            CreateMap<Movie, IndexMovieViewModel>()
                .ForMember(dest => dest.Title, mapFrom => mapFrom.MapFrom(src => src.Title))
                .ForMember(dest => dest.DateReleased, mapFrom => mapFrom.MapFrom(src => src.DateReleased.ToString("MMM/dd/yyyy")))
                .ForMember(dest => dest.Poster, mapFrom => mapFrom.MapFrom(src => src.Poster))
                .ForMember(
                    dest => dest.ShortStoryline,
                       mapFrom => mapFrom.MapFrom(
                                src => src.Storyline.Length >= 50 ? src.Storyline.Substring(0, 50) + "..." : src.Storyline))
                .ForMember(
                    dest => dest.Rating, 
                       mapFrom => mapFrom.MapFrom(
                                src => double.IsNaN(src.Reviews.Sum(x => x.Rating) / src.Reviews.Count) ? 0 : src.Reviews.Sum(x => x.Rating) / src.Reviews.Count))
                .ReverseMap();
        }
    }
}
