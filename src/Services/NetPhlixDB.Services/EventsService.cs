using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly IMoviesService _moviesService;
        private readonly IPeopleService _peopleService;

        public EventsService(NetPhlixDbContext dbContext, IMapper mapper, IMoviesService moviesService, IPeopleService peopleService)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
            this._moviesService = moviesService;
            this._peopleService = peopleService;
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

            var movies = await this._dbContext.EventMovies.Where(x => x.EventId == id).Select(x => x.Movie).Distinct().ToListAsync();
            var eventMovieViewModels = this._mapper.Map<IEnumerable<Movie>, IEnumerable<EventMovieViewModel>>(movies);

            var people = await this._dbContext.EventPeople.Where(x => x.EventId == id).Select(x => x.Person).Distinct().ToListAsync();
            var eventPersonViewModels = this._mapper.Map<IEnumerable<Person>, IEnumerable<EventPersonViewModel>>(people);

            eventViewModel.EventMovieViewModels = eventMovieViewModels;
            eventViewModel.EventPersonViewModels = eventPersonViewModels;

            return eventViewModel;
        }

        public async Task<int> CreateEvent(CreateEventViewModel viewModel)
        {
            var ev = this._mapper.Map<CreateEventViewModel, Event>(viewModel);
            await this._dbContext.Events.AddAsync(ev);
            return await this._dbContext.SaveChangesAsync();
        }

        public async Task<EventWithNotAddedMoviesViewModel> GetEventWithNotAddedMoviesById(string id)
        {
            var ev = await this._dbContext.Events.FindAsync(id);
            var notAddedMovies = await this._moviesService.GetMoviesNotAddedToEventById(id);

            var eventWithNotAddedMoviesViewModel = this._mapper.Map<EventWithNotAddedMoviesViewModel>(ev);
            eventWithNotAddedMoviesViewModel.MovieEventViewModels = notAddedMovies;

            return eventWithNotAddedMoviesViewModel;
        }

        public async Task<EventWithNotAddPeopleViewModel> GetEventWithNotAddedPeopleById(string id)
        {
            var ev = await this._dbContext.Events.FindAsync(id);
            var notAddedPeople = await this._peopleService.GetPeopleNotAddedToEventById(id);

            var eventWithNotAddedPeopleViewModel = this._mapper.Map<Event, EventWithNotAddPeopleViewModel>(ev);
            eventWithNotAddedPeopleViewModel.PersonViewModels = notAddedPeople;

            //var eventWithNotAddedPeopleViewModel = await this._dbContext
            //    .EventPeople
            //    .Where(x => x.EventId == id)
            //    .Select(x => new EventWithNotAddPeopleViewModel()
            //    {
            //        EventId = x.EventId,
            //        EventTitle = x.Event.Title,
            //        PersonViewModels = this._dbContext
            //            .People
            //            .Where(p => p.Id != x.PersonId)
            //            .Select(np => new PersonEventViewModel()
            //            {
            //                PersonId = np.Id,
            //                FullName = np.FirstName + " " + np.LastName,
            //                Role = np.PersonRole.ToString()
            //            })
            //            .ToList()
            //    })
            //    .FirstOrDefaultAsync();

            return eventWithNotAddedPeopleViewModel;
        }

        public async Task<bool> EventExists(string id)
        {
            return await this._dbContext.Events.FindAsync(id) != null;
        }

        public async Task<int> AddMovieToEvent(AddMovieToEventViewModel viewModel)
        {
            var eventMovie = this._mapper.Map<AddMovieToEventViewModel, EventMovie>(viewModel);

            await this._dbContext.EventMovies.AddAsync(eventMovie);
            return await this._dbContext.SaveChangesAsync();
        }

        public async Task<int> AddPersonToEvent(AddPersonToEventViewModel viewModel)
        {
            var eventPerson = this._mapper.Map<AddPersonToEventViewModel, EventPerson>(viewModel);

            await this._dbContext.EventPeople.AddAsync(eventPerson);
            return await this._dbContext.SaveChangesAsync();
        }
    }
}
