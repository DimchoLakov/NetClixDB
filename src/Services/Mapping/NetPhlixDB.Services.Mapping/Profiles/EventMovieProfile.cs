using AutoMapper;
using NetPhlixDb.Data.ViewModels.Events;
using NetPhlixDB.Data.Models;

namespace NetPhlixDB.Services.Mapping.Profiles
{
    public class EventMovieProfile : Profile
    {
        public EventMovieProfile()
        {
            CreateMap<EventMovie, AddMovieToEventViewModel>()
                .ReverseMap();
        }
    }
}
