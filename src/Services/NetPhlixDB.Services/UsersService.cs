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

        public List<string> GetFavoriteMoviesList(string email)
        {
            var userId = this.GetUserByEmail(email).Id;
            var movies = this._dbContext.MovieUsers.Where(x => x.UserId == userId).Select(x => x.Movie.Id).ToList();
            return movies;
        }

        public IEnumerable<IndexMovieViewModel> GetFavoriteMovies(string email)
        {
            var userId = this.GetUserByEmail(email).Id;
            var movies = this._dbContext.MovieUsers.Where(x => x.UserId == userId).Select(x => x.Movie).ToList();
            return _mapper.Map<IEnumerable<Movie>, IEnumerable<IndexMovieViewModel>>(movies);
        }

        public async void AddFavoriteMovie(string id, string userId)
        {
            await this._dbContext.MovieUsers.AddAsync(new MovieUser()
            {
                MovieId = id,
                UserId = userId
            });
            await this._dbContext.SaveChangesAsync();
        }

        public UserIdEmailViewModel GetUserByEmail(string email)
        {
            var userViewModel =
               this._mapper.Map<UserIdEmailViewModel>(this._dbContext.Users.FirstOrDefault(x => x.Email == email));

            return userViewModel;
        }

        public UserIdEmailViewModel GetUserById(string id)
        {
            var userViewModel =
                this._mapper.Map<UserIdEmailViewModel>(this._dbContext.Users.FirstOrDefault(x => x.Id == id));

            return userViewModel;
        }
    }
}
