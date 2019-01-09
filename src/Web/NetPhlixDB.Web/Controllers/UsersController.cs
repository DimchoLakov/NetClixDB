using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> AddFavMovie(FavoriteMovieIdViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("All", "Movies");
            }

            var user = await this._usersService.GetUserByEmail(this.User.Identity.Name);
            await this._usersService.AddFavoriteMovie(viewModel.Id, user.Id);

            return RedirectToAction("Favorites", "Users");
        }

        [Authorize]
        public async Task<IActionResult> Favorites()
        {
            var favoriteMovies = await this._usersService.GetFavoriteMovies(this.User.Identity.Name);

            return this.View(favoriteMovies.ToList());
        }

        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            return await Task.Run(() => this.View());
        }
    }
}