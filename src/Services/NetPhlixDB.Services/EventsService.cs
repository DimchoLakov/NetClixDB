using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<EventViewModel>> GetAll()
        {
            var events = await this._dbContext.Events.OrderByDescending(x => x.Date).ToListAsync();
            var eventViewModels = this._mapper.Map<IEnumerable<Event>, IEnumerable<EventViewModel>>(events);
            
            return eventViewModels;
        }

        public async Task<EventViewModel> GetById(string id)
        {
            var ev = await this._dbContext.Events.FirstOrDefaultAsync(x => x.Id == id);
            if (ev == null)
            {
                return null;
            }
            var eventViewModel = this._mapper.Map<Event, EventViewModel>(ev);

            var movies = await this._dbContext.MoviePeople.Where(x => x.EventId == id).Select(x => x.Movie).Distinct().ToListAsync();
            var eventMovieViewModels = this._mapper.Map<IEnumerable<Movie>, IEnumerable<EventMovieViewModel>>(movies);

            var people = await this._dbContext.MoviePeople.Where(x => x.EventId == id).Select(x => x.Person).Distinct().ToListAsync();
            var eventPersonViewModels = this._mapper.Map<IEnumerable<Person>, IEnumerable<EventPersonViewModel>>(people);

            eventViewModel.EventMovieViewModels = eventMovieViewModels;
            eventViewModel.EventPersonViewModels = eventPersonViewModels;

            return eventViewModel;
        }
    }
}
