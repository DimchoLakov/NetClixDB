using System.Collections.Generic;
using NetPhlixDb.Data.ViewModels;

namespace NetPhlixDB.Services.Contracts
{
    public interface IMovieService
    {
        IEnumerable<IndexMovieViewModel> GetAllIndexMovies();
    }
}
