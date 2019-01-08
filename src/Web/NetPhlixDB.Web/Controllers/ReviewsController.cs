using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetPhlixDb.Data.ViewModels.Binding.Reviews;
using NetPhlixDB.Services;
using NetPhlixDB.Services.Contracts;

namespace NetPhlixDB.Web.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IReviewsService _reviewsService;
        private readonly IUsersService _usersService;

        public ReviewsController(IReviewsService reviewsService, IUsersService usersService)
        {
            this._reviewsService = reviewsService;
            this._usersService = usersService;
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(AddReviewViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                this._reviewsService.AddReview(viewModel);

                return this.RedirectToAction("Movie", "Reviews", new { id = viewModel.MovieId });
            }

            return this.Movie(viewModel.MovieId);
        }

        [Authorize]
        public IActionResult Movie(string id)
        {
            var reviewsForMovie = this._reviewsService.AllReviewsForMovie(id);
            reviewsForMovie.MovieId = id;

            var user = this._usersService.GetUserByEmail(this.User.Identity.Name);
            reviewsForMovie.UserId = user.Id;

            return this.View(reviewsForMovie);
        }
    }
}