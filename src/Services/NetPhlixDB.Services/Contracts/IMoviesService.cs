using System.Collections.Generic;
using System.Threading.Tasks;
using NetPhlixDb.Data.ViewModels.Movies;

namespace NetPhlixDB.Services.Contracts
{
    public interface IMoviesService
    {
        Task<IEnumerable<IndexMovieViewModel>> GetAll();

        Task<MovieDetailsViewModel> GetById(string id);

        Task<string> GetMovieTitleById(string id);
    }
}
