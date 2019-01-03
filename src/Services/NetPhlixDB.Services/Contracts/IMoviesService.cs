using System.Collections.Generic;
using NetPhlixDb.Data.ViewModels.Movies;

namespace NetPhlixDB.Services.Contracts
{
    public interface IMoviesService
    {
        IEnumerable<IndexMovieViewModel> GetAll();

        MovieDetailsViewModel GetById(string id);
    }
}
