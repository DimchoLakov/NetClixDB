using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetPhlixDb.Data.ViewModels.People;
using NetPhlixDb.Data.ViewModels.Users;
using NetPhlixDB.Data.Models;
using NetPhlixDB.Services.Contracts;
using NetPhlixDB.Web.Common;

namespace NetPhlixDB.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;
        private readonly IMoviesService _moviesService;
        private readonly IMapper _mapper;

        public UsersController(IUsersService usersService, IMoviesService moviesService, IMapper mapper)
        {
            this._usersService = usersService;
            this._moviesService = moviesService;
            this._mapper = mapper;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RemoveFavMovie(RemoveFavMovieViewModel viewModel)
        {
            if (viewModel.Id == null ||
                !this.ModelState.IsValid)
            {
                return this.RedirectToAction("All", "Movies");
            }

            if (!await this._moviesService.MovieExists(viewModel.Id))
            {
                return this.NotFound();
            }

            var user = await this._usersService.GetUserByUsername(this.User.Identity.Name);
            await this._usersService.RemoveFavoriteMovie(viewModel.Id, user.Id);

            return RedirectToAction("Favorites", "Users");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddFavMovie(FavoriteMovieIdViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("All", "Movies");
            }

            var user = await this._usersService.GetUserByUsername(this.User.Identity.Name);
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
            var user = await this._usersService.GetUserByIdAsync(id);
            if (user == null)
            {
                return this.NotFound();
            }

            var userViewModel = this._mapper.Map<User, UserInfoViewModel>(user);

            return await Task.Run(() => this.View(userViewModel));
        }
    }
}