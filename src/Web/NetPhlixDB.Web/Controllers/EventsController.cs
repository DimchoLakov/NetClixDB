using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetPhlixDb.Data.ViewModels.Events;
using NetPhlixDB.Services.Contracts;

namespace NetPhlixDB.Web.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventsService _eventsService;
        private readonly IMoviesService _moviesService;
        private readonly IPeopleService _peopleService;

        public EventsController(IEventsService eventsService, IMoviesService moviesService, IPeopleService peopleService)
        {
            this._eventsService = eventsService;
            this._moviesService = moviesService;
            this._peopleService = peopleService;
        }

        [Authorize]
        public async Task<IActionResult> All()
        {
            var events = await this._eventsService.GetAll();
            return this.View(events);
        }

        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            var ev = await this._eventsService.GetById(id);

            if (ev == null)
            {
                return this.NotFound();
            }

            return this.View(ev);
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            return await Task.Run(() => this.View());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateEventViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                await this._eventsService.CreateEvent(viewModel);

                return this.RedirectToAction("All", "Events");
            }

            return await Task.Run(() => this.View(viewModel));
        }

        [Authorize]
        public async Task<IActionResult> AddMovies(string id)
        {
            var eventWithNotAddedMoviesViewModel = await this._eventsService.GetEventWithNotAddedMoviesById(id);

            return await Task.Run(() => this.View(eventWithNotAddedMoviesViewModel));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddMovies(AddMovieToEventViewModel viewModel)
        {
            if (!await this._eventsService.EventExists(viewModel.EventId) ||
                !await this._moviesService.MovieExists(viewModel.MovieId))
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                await this._eventsService.AddMovieToEvent(viewModel);

                return this.RedirectToAction("AddMovies", "Events", new { id = viewModel.EventId });
            }

            return await Task.Run(() => this.View());
        }

        public async Task<IActionResult> AddPeople(string id)
        {
            var eventWithNotAddedPeople = await this._eventsService.GetEventWithNotAddedPeopleById(id);

            return await Task.Run(() => this.View(eventWithNotAddedPeople));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPeople(AddPersonToEventViewModel viewModel)
        {
            if (!await this._eventsService.EventExists(viewModel.EventId) ||
                !await this._peopleService.PersonExists(viewModel.PersonId))
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                await this._eventsService.AddPersonToEvent(viewModel);

                return this.RedirectToAction("AddPeople", "Events", new { id = viewModel.EventId });
            }

            return await Task.Run(() => this.View());
        }
    }
}