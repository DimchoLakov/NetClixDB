using NetPhlixDb.Data.ViewModels;
using NetPhlixDB.Data.Models;
using NetPhlixDB.Services.Contracts;
using NetPhlixDB.Services.Repositories;

namespace NetPhlixDB.Services
{
    public class MovieService : IMovieService
    {
        private readonly DbRepository<Movie> _dbRepository;

        public MovieService(DbRepository<Movie> dbRepository)
        {
            this._dbRepository = dbRepository;
        }

        public void Add(MovieViewModel viewModel)
        {
        }
    }
}
