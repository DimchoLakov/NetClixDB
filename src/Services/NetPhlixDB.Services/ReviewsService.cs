using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetPhlixDb.Data.ViewModels.Binding.Reviews;
using NetPhlixDb.Data.ViewModels.Movies;
using NetPhlixDB.Data;
using NetPhlixDB.Data.Models;
using NetPhlixDB.Services.Contracts;

namespace NetPhlixDB.Services
{
    public class ReviewsService : IReviewsService
    {
        private readonly NetPhlixDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IMoviesService _moviesService;

        public ReviewsService(NetPhlixDbContext dbContext, IMapper mapper, IMoviesService moviesService)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
            this._moviesService = moviesService;
        }

        public async Task<ReviewsMovieAddReviewViewModel> AllReviewsForMovie(string movieId)
        {
            var reviews = await this._dbContext.Movies
                                                .Where(x => x.Id == movieId)
                                                .SelectMany(x => x.Reviews)
                                                .OrderByDescending(x => x.DateAdded)
                                                .ToListAsync();

            var reviewsViewModels = this._mapper.Map<IEnumerable<Review>, IEnumerable<MovieReviewViewModel>>(reviews);
            var movieTitle = await this._moviesService.GetMovieTitleById(movieId);

            var reviewsMovieAddReviewViewModel = new ReviewsMovieAddReviewViewModel()
            {
                MovieReviewViewModels = reviewsViewModels,
                MovieTitle = movieTitle
            };

            return reviewsMovieAddReviewViewModel;
        }

        public async Task AddReview(AddReviewViewModel viewModel)
        {
            var user = await this._dbContext.Users.FirstOrDefaultAsync(x => x.Id == viewModel.UserId);
            var name = user.FirstName + user.LastName;
            var email = user.Email.Substring(0, user.Email.IndexOf("@"));
            name = string.IsNullOrWhiteSpace(name) ? email : name;

            var review = this._mapper.Map<AddReviewViewModel, Review>(viewModel);
            review.AddedBy = name;
            review.DateAdded = DateTime.UtcNow;
            await this._dbContext.Reviews.AddAsync(review);
            await this._dbContext.SaveChangesAsync();
        }
    }
}
