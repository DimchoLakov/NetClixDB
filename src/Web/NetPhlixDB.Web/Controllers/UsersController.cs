using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetPhlixDb.Data.ViewModels.Binding.Users;
using NetPhlixDB.Services.Contracts;

namespace NetPhlixDB.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            this._usersService = usersService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddFavMovie(FavoriteMovieIdViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("All", "Movies");
            }

            var user = this._usersService.GetUserByEmail(this.User.Identity.Name);
            this._usersService.AddFavoriteMovie(viewModel.Id, user.Id);

            return RedirectToAction("FavoriteMovies", "Users");
        }

        [Authorize]
        public IActionResult FavoriteMovies()
        {
            var user = this._usersService.GetUserByEmail(this.User.Identity.Name);

            var favoriteMovies = this._usersService.GetFavoriteMovies(user.Email).ToList();

            return this.View(favoriteMovies);
        }
    }
}