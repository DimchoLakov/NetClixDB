using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetPhlixDb.Data.ViewModels.Users;
using NetPhlixDB.Services.Contracts;
using NetPhlixDB.Web.Common;

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
            var result = await this._usersService.AddFavoriteMovie(viewModel.Id, user.Id);
            if (result == NetConstants.ZeroResult)
            {
                return this.NotFound();
            }

            return RedirectToAction("Favorites", "Users");
        }

        [Authorize]
        public async Task<IActionResult> Favorites(int? currentPage = 1)
        {
            var favoriteMovies = await this._usersService.GetFavoriteMovies(this.User.Identity.Name);

            var count = favoriteMovies.Count();
            var size = NetConstants.PageSize;
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
            var take = size;

            this.ViewBag.CurrentPage = currentPage;
            this.ViewBag.FirstPage = 1;
            this.ViewBag.LastPage = totalPages;

            return this.View(favoriteMovies.Skip(skip).Take(take).ToList());
        }

        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            return await Task.Run(() => this.View());
        }
    }
}