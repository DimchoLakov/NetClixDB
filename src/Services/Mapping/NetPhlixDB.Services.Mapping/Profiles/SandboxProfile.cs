using AutoMapper;
using NetPhlixDb.Data.ViewModels.DTOs;
using NetPhlixDB.Data.Models;

namespace NetPhlixDB.Services.Mapping.Profiles
{
    public class SandboxProfile : Profile
    {
        public SandboxProfile()
        {
            CreateMap<MovieDto, Movie>()
                .ForMember(dest => dest.Poster, opts => opts.MapFrom(src => "https://image.tmdb.org/t/p/w600_and_h900_bestv2" + src.Poster))
                .ForMember(dest => dest.DateReleased, opts => opts.MapFrom(src => src.ReleaseDate))
                .ReverseMap();

            CreateMap<MovieGenreDto, Genre>()
                .ReverseMap();

            CreateMap<MovieCompanyDto, Company>()
                .ReverseMap();
        }
    }
}
