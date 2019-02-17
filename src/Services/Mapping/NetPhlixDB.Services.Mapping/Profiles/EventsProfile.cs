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

            // Create Event View Model
            CreateMap<Event, CreateEventViewModel>()
                .ReverseMap();

            // Add Movie To Event View Model
            CreateMap<Event, EventWithNotAddedMoviesViewModel>()
                .ForMember(dest => dest.EventId, mapFrom => mapFrom.MapFrom(src => src.Id))
                .ForMember(dest => dest.EventTitle, mapFrom => mapFrom.MapFrom(src => src.Title))
                .ReverseMap();

            // Add Person To Event View Model
            CreateMap<Event, EventWithNotAddPeopleViewModel>()
                .ForMember(dest => dest.EventId, mapFrom => mapFrom.MapFrom(src => src.Id))
                .ForMember(dest => dest.EventTitle, mapFrom => mapFrom.MapFrom(src => src.Title))
                .ReverseMap();
        }
    }
}
