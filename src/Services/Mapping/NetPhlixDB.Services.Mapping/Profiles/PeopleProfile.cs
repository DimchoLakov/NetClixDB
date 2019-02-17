using AutoMapper;
using NetPhlixDb.Data.ViewModels.Events;
using NetPhlixDb.Data.ViewModels.People;
using NetPhlixDB.Data.Models;

namespace NetPhlixDB.Services.Mapping.Profiles
{
    public class PeopleProfile : Profile
    {
        public PeopleProfile()
        {
            // Person View Model
            CreateMap<Person, PersonViewModel>()
                .ForMember(dest => dest.Role, map => map.MapFrom(src => src.PersonRole.ToString()))
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.FirstName + " " + src.LastName))
                .ReverseMap();

            CreateMap<Movie, PersonMovieViewModel>()
                .ForMember(
                    dest => dest.Storyline,
                    mapFrom => mapFrom.MapFrom(
                        src => src.Storyline.Length >= 50 ? src.Storyline.Substring(0, 100) + "..." : src.Storyline))
                .ReverseMap();

            CreateMap<Person, PersonEventViewModel>()
                .ForMember(dest => dest.PersonId, mapFrom => mapFrom.MapFrom(src => src.Id))
                .ForMember(dest => dest.FullName, mapFrom => mapFrom.MapFrom(src => src.FirstName + " " + src.LastName))
                .ForMember(dest => dest.Role, mapFrom => mapFrom.MapFrom(src => src.PersonRole.ToString()))
                .ReverseMap();
        }
    }
}
