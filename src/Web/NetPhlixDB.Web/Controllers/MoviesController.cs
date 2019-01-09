using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetPhlixDB.Services.Contracts;

namespace NetPhlixDB.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _moviesService;
        private readonly IUsersService _usersService;

        public MoviesController(IMoviesService moviesService, IUsersService usersService)
        {
            this._moviesService = moviesService;
            this._usersService = usersService;
        }

        [Authorize]
        public async Task<IActionResult> All(int? currentPage = 1)
        {
            var allMovies = await this._moviesService.GetAll();

            var count = allMovies.Count();
            var size = 10;
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

            return this.View(allMovies.Take(take).ToList());
        }

        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            var movieViewModel = await this._moviesService.GetById(id);
            movieViewModel.UserFavoriteMovies = await this._usersService.GetFavoriteMoviesList(this.User.Identity.Name);

            return this.View(movieViewModel);
        }
    }
}