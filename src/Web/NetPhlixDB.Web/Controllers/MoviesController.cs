using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetPhlixDB.Services.Contracts;
using NetPhlixDB.Web.Common;

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
        public async Task<IActionResult> All(int? currentPage = 1, string search = "", string genre = "")
        {
            var paginationMoviesViewModel = await this._moviesService.GetPageMovies(currentPage, search, genre);

            return this.View(paginationMoviesViewModel);
        }

        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            var movieExists = await this._moviesService.MovieExists(id);
            if (!movieExists)
            {
                return this.NotFound();
            }

            var movieViewModel = await this._moviesService.GetById(id);
            movieViewModel.UserFavoriteMovies = await this._usersService.GetFavoriteMoviesList(this.User.Identity.Name);

            return this.View(movieViewModel);
        }
    }
}