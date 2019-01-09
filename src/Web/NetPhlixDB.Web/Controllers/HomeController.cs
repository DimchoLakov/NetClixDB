using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetPhlixDB.Services.Contracts;
using NetPhlixDB.Web.Common;
using NetPhlixDB.Web.Models;

namespace NetPhlixDB.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMoviesService _moviesService;

        public HomeController(IMoviesService moviesService)
        {
            this._moviesService = moviesService;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await this._moviesService.GetAll();
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("All", "Movies");
            }

            return View(movies.Take(NetConstants.IndexMoviesCount).ToList());
        }

        public async Task<IActionResult> About()
        {
            return await Task.Run(() => this.View());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            return await Task.Run(() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }));
        }
    }
}
