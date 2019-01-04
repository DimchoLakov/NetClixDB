using System.Collections.Generic;
using NetPhlixDb.Data.ViewModels.Movies;
using NetPhlixDb.Data.ViewModels.Users;

namespace NetPhlixDB.Services.Contracts
{
    public interface IUsersService
    {
        IEnumerable<IndexMovieViewModel> GetFavoriteMovies(string email);

        List<string> GetFavoriteMoviesList(string email);

        void AddFavoriteMovie(string id, string userId);

        UserIdEmailViewModel GetUserByEmail(string email);

        UserIdEmailViewModel GetUserById(string id);
    }
}
