using AutoMapper;
using NetPhlixDb.Data.ViewModels.Events;
using NetPhlixDB.Data.Models;

namespace NetPhlixDB.Services.Mapping.Profiles
{
    public class EventsProfile : Profile
    {
        public EventsProfile()
        {
            // Event View Model
            CreateMap<Event, EventViewModel>()
                .ReverseMap();

            // Event Person View Model
            CreateMap<Person, EventPersonViewModel>()
                .ForMember(dest => dest.FullName,
                    mapFrom => mapFrom.MapFrom(src => src.FirstName + " " + src.LastName));

            // Event Movie View Model
            CreateMap<Movie, EventMovieViewModel>()
                .ForMember(dest => dest.Date,
                    mapFrom => mapFrom.MapFrom(src => src.DateReleased.Year));
        }
    }
}
