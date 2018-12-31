using System.Collections.Generic;
using AutoMapper;
using NetPhlixDb.Data.ViewModels;
using NetPhlixDB.Data.Models;
using NetPhlixDB.Services.Contracts;
using NetPhlixDB.Services.Repositories.Contracts;

namespace NetPhlixDB.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _dbRepository;
        private readonly IMapper _mapper;

        public MovieService(IRepository<Movie> dbRepository, IMapper mapper)
        {
            this._dbRepository = dbRepository;
            this._mapper = mapper;
        }

        public IEnumerable<IndexMovieViewModel> GetAllIndexMovies()
        {
            var allMovies = this._dbRepository.All();
            return _mapper.Map<IEnumerable<Movie>, IEnumerable<IndexMovieViewModel>>(allMovies);
        }
    }
}
