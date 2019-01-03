using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetPhlixDB.Services.Contracts;

namespace NetPhlixDB.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            this._moviesService = moviesService;
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

            return this.View(movieViewModel);
        }
    }
}