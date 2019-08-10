using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using NetPhlixDb.Data.ViewModels.Events;
using NetPhlixDb.Data.ViewModels.Movies;
using NetPhlixDB.Data;
using NetPhlixDB.Data.Models;
using NetPhlixDB.Services.Common;
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

        public async Task<IEnumerable<IndexMovieViewModel>> Get(int count)
        {
            var movies = await this._dbContext.Movies.Take(count).OrderByDescending(x => x.DateReleased).ToListAsync();
            return _mapper.Map<IEnumerable<Movie>, IEnumerable<IndexMovieViewModel>>(movies);
        }

        public async Task<int> GetMoviesCount()
        {
            return await this._dbContext.Movies.CountAsync();
        }

        public async Task<PaginationMoviesViewModel> GetPageMovies(int? currentPage, string search, string genre, string sortOrder)
        {
            var count = await this._dbContext.Movies.CountAsync();

            var size = NetConstants.DefaultPageSize;
            var totalPages = (int)Math.Ceiling(decimal.Divide(count, size));

            if (currentPage <= 1)
            {
                currentPage = 1;
            }
            if (currentPage >= totalPages)
            {
                currentPage = totalPages;
            }

            var skip = (int)(currentPage - 1) * size;
            if (skip < 0)
            {
                skip = 0;
            }
            var take = size;

            var movies = new List<Movie>();

            if (!string.IsNullOrWhiteSpace(search) && 
                !string.IsNullOrWhiteSpace(genre))
            {
                movies = await this._dbContext.Movies
                    .Where(x => x.Title.ToLower().Contains(search.ToLower()) &&
                                x.MovieGenres.Any(mg => mg.Genre.Name == genre))
                    .Skip(skip)
                    .Take(take)
                    .OrderByDescending(x => x.DateReleased).ToListAsync();

                var moviesCountAfterSearch = await this._dbContext.Movies
                    .Where(x => x.Title.ToLower().Contains(search.ToLower()) &&
                                x.MovieGenres.Any(mg => mg.Genre.Name == genre))
                    .CountAsync();

                totalPages = (int) Math.Ceiling(decimal.Divide(moviesCountAfterSearch, size));
            }
            else if (!string.IsNullOrWhiteSpace(search))
            {
                movies = await this._dbContext.Movies
                    .Where(x => x.Title.ToLower().Contains(search.ToLower()))
                    .Skip(skip)
                    .Take(take)
                    .OrderByDescending(x => x.DateReleased).ToListAsync();

                var moviesCountAfterSearch = await this._dbContext.Movies
                    .Where(x => x.Title.ToLower().Contains(search.ToLower()))
                    .CountAsync();

                totalPages = (int)Math.Ceiling(decimal.Divide(moviesCountAfterSearch, size));
            }
            else if (!string.IsNullOrWhiteSpace(genre))
            {
                movies = await this._dbContext.Movies
                    .Where(x => x.MovieGenres.Any(mg => mg.Genre.Name.ToLower() == genre.ToLower()))
                    .Skip(skip)
                    .Take(take)
                    .OrderByDescending(x => x.DateReleased).ToListAsync();

                var moviesCountAfterSearch = await this._dbContext.Movies
                    .Where(x => x.MovieGenres.Any(mg => mg.Genre.Name.ToLower() == genre.ToLower()))
                    .CountAsync();

                totalPages = (int)Math.Ceiling(decimal.Divide(moviesCountAfterSearch, size));
            }
            else
            {
                movies = await this._dbContext.Movies
                    .Skip(skip)
                    .Take(take)
                    .OrderByDescending(x => x.DateReleased).ToListAsync();
            }

            switch (sortOrder)
            {
                case "name":
                    movies = movies.OrderBy(x => x.Title).ToList();
                    break;
                case "name_desc":
                    movies = movies.OrderByDescending(x => x.Title).ToList();
                    break;
                case "date":
                    movies = movies.OrderBy(x => x.DateReleased).ToList();
                    break;
                case "date_desc":
                    movies = movies.OrderByDescending(x => x.DateReleased).ToList();
                    break;
                default:
                    movies = movies.OrderBy(x => x.Title).ToList();
                    break;
            }

            var movieViewModels = _mapper.Map<IEnumerable<Movie>, IEnumerable<IndexMovieViewModel>>(movies);
            var paginationMovieViewModel = new PaginationMoviesViewModel()
            {
                IndexMovieViewModels = movieViewModels.ToList()
            };
            paginationMovieViewModel.CurrentPage = currentPage.Value;
            paginationMovieViewModel.TotalPages = totalPages;
            paginationMovieViewModel.Search = search;
            paginationMovieViewModel.Genre = genre;
            
            // Get all genres
            var allGenres = await this._dbContext
                .Genres
                .OrderBy(x => x.Name)
                .Select(x => new SelectListItem(x.Name, x.Name)).ToListAsync();

            paginationMovieViewModel.Genres = allGenres;

            // Map genres for each movie
            foreach (var mov in paginationMovieViewModel.IndexMovieViewModels)
            {
                var genres = await this._dbContext
                    .MovieGenres
                    .Where(x => x.MovieId == mov.Id)
                    .Select(x => x.Genre)
                    .ToListAsync();

                mov.Genres = this._mapper.Map<IEnumerable<Genre>, IEnumerable<MovieGenreViewModel>>(genres).ToList();
            }

            return paginationMovieViewModel;
        }

        public async Task<MovieDetailsViewModel> GetById(string id)
        {
            var movieById = await this._dbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);
            if (movieById == null)
            {
                return null;
            }
            var genresByMovieId = await this._dbContext
                .MovieGenres
                .Where(x => x.MovieId == id)
                .Select(x => x.Genre)
                .ToListAsync();

            var peopleByMovieId = await this._dbContext
                .MoviePeople
                .Where(x => x.MovieId == id)
                .Select(x => x.Person)
                .ToListAsync();

            var companiesByMovieId = await this._dbContext
                .MovieCompanies
                .Where(x => x.MovieId == id)
                .Select(x => x.Company)
                .ToListAsync();

            var reviewsByMovieId = await this._dbContext
                .Reviews
                .Where(x => x.MovieId == id)
                .ToListAsync();

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

        public async Task<IEnumerable<MovieEventViewModel>> GetMoviesNotAddedToEventById(string eventId)
        {
            var eventMovieIds = await this._dbContext
                .EventMovies
                .Where(em => em.EventId == eventId)
                .Select(mp => mp.MovieId)
                .Distinct()
                .ToListAsync();

            var allMoviesIds = await this._dbContext
                .Movies
                .Select(m => m.Id)
                .ToListAsync();

            foreach (var eventMovieId in eventMovieIds)
            {
                allMoviesIds.Remove(eventMovieId);
            }

            var moviesNotAddedToEvent = await this._dbContext
                .Movies
                .Where(x => allMoviesIds.Contains(x.Id))
                .ToListAsync();

            var moviesNotAddedToEventViewModels =
                this._mapper.Map<IEnumerable<Movie>, IEnumerable<MovieEventViewModel>>(moviesNotAddedToEvent);

            return moviesNotAddedToEventViewModels;
        }
    }
}
