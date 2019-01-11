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

        public async Task<IEnumerable<IndexMovieViewModel>> GetAll()
        {
            var movies = await this._dbContext.Movies.OrderByDescending(x => x.DateReleased).ToListAsync();
            return _mapper.Map<IEnumerable<Movie>, IEnumerable<IndexMovieViewModel>>(movies);
        }

        public async Task<MovieDetailsViewModel> GetById(string id)
        {
            var movieById = await this._dbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);
            if (movieById == null)
            {
                return null;
            }
            var genresByMovieId = await this._dbContext.MovieGenres.Where(x => x.MovieId == id).Select(x => x.Genre).ToListAsync();
            var peopleByMovieId = await this._dbContext.MoviePeople.Where(x => x.MovieId == id).Select(x => x.Person).ToListAsync();
            var companiesByMovieId = await this._dbContext.MovieCompanies.Where(x => x.MovieId == id).Select(x => x.Company).ToListAsync();
            var reviewsByMovieId = await this._dbContext.Reviews.Where(x => x.MovieId == id).ToListAsync();

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

        public async Task<string> GetMovieTitleById(string id)
        {
            var movie = await this._dbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);
            return movie.Title;
        }

        public async Task<bool> MovieExists(string id)
        {
            return await this._dbContext.Movies.FindAsync(id) != null;
        }
    }
}
