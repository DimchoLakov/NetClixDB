using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetPhlixDb.Data.ViewModels.Movies;
using NetPhlixDb.Data.ViewModels.Users;
using NetPhlixDB.Data;
using NetPhlixDB.Data.Models;
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

        public async Task<List<string>> GetFavoriteMoviesList(string email)
        {
            var user = await this.GetUserByEmail(email);
            var userId = user.Id;
            var movies = await this._dbContext.MovieUsers.Where(x => x.UserId == userId).Select(x => x.Movie.Id).ToListAsync();
            return movies;
        }

        public async Task<IEnumerable<IndexMovieViewModel>> GetFavoriteMovies(string email)
        {
            var user = await this.GetUserByEmail(email);
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

        public async Task<UserIdEmailViewModel> GetUserByEmail(string email)
        {
            var userViewModel =
               this._mapper.Map<UserIdEmailViewModel>(await this._dbContext.Users.FirstOrDefaultAsync(x => x.Email == email));

            return userViewModel;
        }

        public async Task<UserIdEmailViewModel> GetUserById(string id)
        {
            var userViewModel =
                this._mapper.Map<UserIdEmailViewModel>(await this._dbContext.Users.FirstOrDefaultAsync(x => x.Id == id));

            return userViewModel;
        }
    }
}
