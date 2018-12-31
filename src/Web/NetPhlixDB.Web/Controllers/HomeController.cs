using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebSockets.Internal;
using NetPhlixDB.Services.Contracts;
using NetPhlixDB.Web.Common;
using NetPhlixDB.Web.Models;

namespace NetPhlixDB.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;

        public HomeController(IMovieService movieService)
        {
            this._movieService = movieService;
        }

        public IActionResult Index()
        {
            var indexMovies = this._movieService.GetAllIndexMovies().Take(NetConstants.IndexMoviesCount).ToList();

            if (this.User.Identity.IsAuthenticated)
            {
                return View("IndexLoggedIn", indexMovies);
            }
            
            return View(indexMovies);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
