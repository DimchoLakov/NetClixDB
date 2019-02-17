using AutoMapper;
using NetPhlixDb.Data.ViewModels.Events;
using NetPhlixDB.Data.Models;

namespace NetPhlixDB.Services.Mapping.Profiles
{
    public class EventPersonProfile : Profile
    {
        public EventPersonProfile()
        {
            CreateMap<EventPerson, AddPersonToEventViewModel>()
                .ReverseMap();
        }   
    }
}
