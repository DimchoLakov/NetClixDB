using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using NetPhlixDb.Data.ViewModels.Events;
using NetPhlixDB.Data;
using NetPhlixDB.Data.Models;
using NetPhlixDB.Services.Contracts;

namespace NetPhlixDB.Services
{
    public class EventsService : IEventsService
    {
        private readonly NetPhlixDbContext _dbContext;
        private readonly IMapper _mapper;

        public EventsService(NetPhlixDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        public IEnumerable<EventViewModel> GetAll()
        {
            var events = this._dbContext.Events.ToList();
            var eventViewModels = this._mapper.Map<IEnumerable<Event>, IEnumerable<EventViewModel>>(events);
            
            return eventViewModels;
        }

        public EventViewModel GetById(string id)
        {
            var ev = this._dbContext.Events.FirstOrDefault(x => x.Id == id);
            var eventViewModel = this._mapper.Map<Event, EventViewModel>(ev);
            var movies = this._dbContext.MoviePeople.Where(x => x.EventId == id).Select(x => x.Movie).Distinct();
            var eventMovieViewModels = this._mapper.Map<IEnumerable<Movie>, IEnumerable<EventMovieViewModel>>(movies);
            var people = this._dbContext.MoviePeople.Where(x => x.EventId == id).Select(x => x.Person).Distinct();
            var eventPersonViewModels = this._mapper.Map<IEnumerable<Person>, IEnumerable<EventPersonViewModel>>(people);

            eventViewModel.EventMovieViewModels = eventMovieViewModels;
            eventViewModel.EventPersonViewModels = eventPersonViewModels;

            return eventViewModel;
        }
    }
}
