using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetPhlixDb.Data.ViewModels.Movies;
using NetPhlixDB.Data;
using NetPhlixDB.Data.Models;
using NetPhlixDB.Services.Contracts;

namespace NetPhlixDB.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IMapper _mapper;
        private readonly NetPhlixDbContext _dbContext;

        public MoviesService(IMapper mapper, NetPhlixDbContext dbContext)
        {
            this._mapper = mapper;
            this._dbContext = dbContext;
        }

        public IEnumerable<IndexMovieViewModel> GetAll()
        {
            var movies = this._dbContext.Movies.ToList();
            return _mapper.Map<IEnumerable<Movie>, IEnumerable<IndexMovieViewModel>>(movies);
        }

        public MovieDetailsViewModel GetById(string id)
        {
            var movieById = this._dbContext.Movies.FirstOrDefault(x => x.Id == id);
            var genresByMovieId = this._dbContext.MovieGenres.Where(x => x.MovieId == id).Select(x => x.Genre).ToList();
            var peopleByMovieId = this._dbContext.MoviePeople.Where(x => x.MovieId == id).Select(x => x.Person).ToList();
            var companiesByMovieId = this._dbContext.MovieCompanies.Where(x => x.MovieId == id).Select(x => x.Company).ToList();
            var reviewsByMovieId = this._dbContext.Reviews.Where(x => x.MovieId == id).ToList();

            var genreViewModels = this._mapper.Map<IEnumerable<Genre>, IEnumerable<MovieGenreViewModel>>(genresByMovieId);
            var peopleViewModels = this._mapper.Map<IEnumerable<Person>, IEnumerable<MoviePersonViewModel>>(peopleByMovieId);
            var reviewsViewModel = this._mapper.Map<IEnumerable<Review>, IEnumerable<MovieReviewViewModel>>(reviewsByMovieId);
            var companyViewModel = this._mapper.Map<IEnumerable<Company>, IEnumerable<MovieCompanyViewModel>>(companiesByMovieId);
            var movieViewModel = this._mapper.Map<Movie, MovieDetailsViewModel>(movieById);

            movieViewModel.MovieGenreViewModels = genreViewModels;
            movieViewModel.MoviePersonViewModels = peopleViewModels;
            movieViewModel.MovieReviewViewModels = reviewsViewModel;
            movieViewModel.MovieCompanyViewModels = companyViewModel;

            return movieViewModel;
        }

        public string GetMovieTitleById(string id)
        {
            return this._dbContext.Movies.FirstOrDefault(x => x.Id == id).Title;
        }
    }
}
