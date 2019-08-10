using System.Collections.Generic;
using System.Threading.Tasks;
using NetPhlixDb.Data.ViewModels.Movies;
using NetPhlixDb.Data.ViewModels.Users;
using NetPhlixDB.Data.Models;

namespace NetPhlixDB.Services.Contracts
{
    public interface IUsersService
    {
        Task<IEnumerable<IndexMovieViewModel>> GetFavoriteMovies(string username);

        Task<List<string>> GetFavoriteMoviesList(string username);

        Task<int> AddFavoriteMovie(string id, string userId);

        Task<UserIdEmailViewModel> GetUserByUsername(string username);

        Task<UserIdEmailViewModel> GetUserById(string id);

        Task<int> RemoveFavoriteMovie(string id, string userId);

        Task<User> GetUserByIdAsync(string id);

        Task<PaginationMoviesViewModel> GetPageMovies(int? currentPage, string search, string genre);
    }
}
