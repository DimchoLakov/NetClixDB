using System.Collections.Generic;
using System.Threading.Tasks;
using NetPhlixDb.Data.ViewModels.Movies;
using NetPhlixDb.Data.ViewModels.Users;

namespace NetPhlixDB.Services.Contracts
{
    public interface IUsersService
    {
        Task<IEnumerable<IndexMovieViewModel>> GetFavoriteMovies(string email);

        Task<List<string>> GetFavoriteMoviesList(string email);

        Task AddFavoriteMovie(string id, string userId);

        Task<UserIdEmailViewModel> GetUserByEmail(string email);

        Task<UserIdEmailViewModel> GetUserById(string id);
    }
}
