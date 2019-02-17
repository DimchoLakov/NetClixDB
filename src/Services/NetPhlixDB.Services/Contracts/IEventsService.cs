using System.Collections.Generic;
using System.Threading.Tasks;
using NetPhlixDb.Data.ViewModels.Events;

namespace NetPhlixDB.Services.Contracts
{
    public interface IEventsService
    {
        Task<IEnumerable<EventViewModel>> GetAll();

        Task<EventViewModel> GetById(string id);

        Task<int> CreateEvent(CreateEventViewModel viewModel);

        Task<EventWithNotAddedMoviesViewModel> GetEventWithNotAddedMoviesById(string id);

        Task<EventWithNotAddPeopleViewModel> GetEventWithNotAddedPeopleById(string id);

        Task<bool> EventExists(string id);

        Task<int> AddMovieToEvent(AddMovieToEventViewModel viewModel);

        Task<int> AddPersonToEvent(AddPersonToEventViewModel viewModel);
    }
}
