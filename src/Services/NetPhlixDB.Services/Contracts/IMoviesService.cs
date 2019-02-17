using System.Collections.Generic;
using System.Threading.Tasks;
using NetPhlixDb.Data.ViewModels.Events;
using NetPhlixDb.Data.ViewModels.Movies;

namespace NetPhlixDB.Services.Contracts
{
    public interface IMoviesService
    {
        Task<IEnumerable<IndexMovieViewModel>> GetAll();

        Task<IEnumerable<IndexMovieViewModel>> Get(int count);

        Task<int> GetMoviesCount();

        Task<IEnumerable<IndexMovieViewModel>> GetPageMovies(int skip, int take);

        Task<MovieDetailsViewModel> GetById(string id);

        Task<string> GetMovieTitleById(string id);

        Task<bool> MovieExists(string id);

        Task<IEnumerable<MovieEventViewModel>> GetMoviesNotAddedToEventById(string eventId);
    }
}
