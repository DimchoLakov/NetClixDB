using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetPhlixDb.Data.ViewModels.Reviews;
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
        public async Task<IActionResult> Add(AddReviewViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                await this._reviewsService.AddReview(viewModel);

                return this.RedirectToAction("Movie", "Reviews", new { id = viewModel.MovieId });
            }

            return await this.Movie(viewModel.MovieId);
        }

        [Authorize]
        public async Task<IActionResult> Movie(string id)
        {
            var reviewsForMovie = await this._reviewsService.AllReviewsForMovie(id);
            if (reviewsForMovie == null)
            {
                return this.NotFound();
            }
            reviewsForMovie.MovieId = id;

            var user = await this._usersService.GetUserByUsername(this.User.Identity.Name);
            reviewsForMovie.UserId = user.Id;

            return this.View(reviewsForMovie);
        }
    }
}