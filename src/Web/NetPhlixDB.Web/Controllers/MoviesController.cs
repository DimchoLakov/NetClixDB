using System.Linq;
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
        public IActionResult All()
        {
            var allMovies = this._moviesService.GetAll().ToList();

            return this.View(allMovies);
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var movieViewModel = this._moviesService.GetById(id);
            movieViewModel.UserFavoriteMovies = this._usersService.GetFavoriteMoviesList(this.User.Identity.Name);

            return this.View(movieViewModel);
        }
    }
}