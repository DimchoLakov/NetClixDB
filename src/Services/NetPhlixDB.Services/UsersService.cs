using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetPhlixDb.Data.ViewModels.Movies;
using NetPhlixDb.Data.ViewModels.Users;
using NetPhlixDB.Data;
using NetPhlixDB.Data.Models;
using NetPhlixDB.Services.Common;
using NetPhlixDB.Services.Contracts;

namespace NetPhlixDB.Services
{
    public class UsersService : IUsersService
    {
        private readonly NetPhlixDbContext _dbContext;
        private readonly IMapper _mapper;

        public UsersService(NetPhlixDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        public async Task<List<string>> GetFavoriteMoviesList(string username)
        {
            var user = await this.GetUserByUsername(username);
            var userId = user.Id;
            var movies = await this._dbContext.MovieUsers.Where(x => x.UserId == userId).Select(x => x.Movie.Id).ToListAsync();
            return movies;
        }

        public async Task<IEnumerable<IndexMovieViewModel>> GetFavoriteMovies(string username)
        {
            var user = await this.GetUserByUsername(username);
            var userId = user.Id;
            var movies = await this._dbContext.MovieUsers.Where(x => x.UserId == userId).Select(x => x.Movie).ToListAsync();
            return _mapper.Map<IEnumerable<Movie>, IEnumerable<IndexMovieViewModel>>(movies);
        }

        public async Task<int> AddFavoriteMovie(string id, string userId)
        {
            var movie = await this._dbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);
            if (movie == null)
            {
                return 0;
            }
            await this._dbContext.MovieUsers.AddAsync(new MovieUser()
            {
                MovieId = id,
                UserId = userId
            });
            return await this._dbContext.SaveChangesAsync();
        }

        public async Task<UserIdEmailViewModel> GetUserByUsername(string username)
        {
            var user = await this._dbContext.Users.FirstOrDefaultAsync(x => x.UserName == username);
            var userViewModel =
                this._mapper.Map<UserIdEmailViewModel>(user);

            return userViewModel;
        }

        public async Task<UserIdEmailViewModel> GetUserById(string id)
        {
            var userViewModel =
                this._mapper.Map<UserIdEmailViewModel>(await this._dbContext.Users.FirstOrDefaultAsync(x => x.Id == id));

            return userViewModel;
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await this._dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PaginationMoviesViewModel> GetPageMovies(int? currentPage, string search, string genre)
        {
            var count = await this._dbContext.Users.Select(x => x.FavoriteMovies).CountAsync();

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
                movies = await this._dbContext.Users
                    .SelectMany(x => x.FavoriteMovies)
                    .Select(x => x.Movie)
                    .Where(x => x.Title.ToLower().Contains(search.ToLower()) &&
                                x.MovieGenres.Any(mg => mg.Genre.Name == genre))
                    .Skip(skip)
                    .Take(take)
                    .OrderByDescending(x => x.DateReleased).ToListAsync();

                var moviesCountAfterSearch = await this._dbContext.Users
                    .SelectMany(x => x.FavoriteMovies)
                    .Select(x => x.Movie)
                    .Where(x => x.Title.ToLower().Contains(search.ToLower()) &&
                                x.MovieGenres.Any(mg => mg.Genre.Name == genre))
                    .CountAsync();

                totalPages = (int)Math.Ceiling(decimal.Divide(moviesCountAfterSearch, size));
            }
            else if (!string.IsNullOrWhiteSpace(search))
            {
                movies = await this._dbContext.Users
                    .SelectMany(x => x.FavoriteMovies)
                    .Select(x => x.Movie)
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
                movies = await this._dbContext.Users
                    .SelectMany(x => x.FavoriteMovies)
                    .Select(x => x.Movie)
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
                movies = await this._dbContext.Users
                    .SelectMany(x => x.FavoriteMovies)
                    .Select(x => x.Movie)
                    .Skip(skip)
                    .Take(take)
                    .OrderByDescending(x => x.DateReleased).ToListAsync();
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

        public async Task<int> RemoveFavoriteMovie(string id, string userId)
        {
            var movieUser = await this._dbContext.MovieUsers.FirstOrDefaultAsync(x => x.MovieId == id && x.UserId == userId);
            this._dbContext.MovieUsers.Remove(movieUser);
            return await this._dbContext.SaveChangesAsync();
        }
    }
}
