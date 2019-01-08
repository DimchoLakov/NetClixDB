using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NetPhlixDB.Data;
using NetPhlixDB.Data.Models;
using NetPhlixDB.Services.Contracts;
using NetPhlixDB.Web.Common;
using NetPhlixDB.Web.Models;

namespace NetPhlixDB.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMoviesService _moviesService;
        private readonly NetPhlixDbContext _dbContext;

        public HomeController(IMoviesService moviesService, NetPhlixDbContext dbContext)
        {
            this._moviesService = moviesService;
            this._dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var movies = this._moviesService.GetAll().Take(NetConstants.IndexMoviesCount).ToList();

            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("All", "Movies");
            }
            
            return View(movies);
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
