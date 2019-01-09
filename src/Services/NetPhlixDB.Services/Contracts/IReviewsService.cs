﻿using System.Threading.Tasks;
using NetPhlixDb.Data.ViewModels.Binding.Reviews;

namespace NetPhlixDB.Services.Contracts
{
    public interface IReviewsService
    {
        Task<ReviewsMovieAddReviewViewModel> AllReviewsForMovie(string movieId);

        Task AddReview(AddReviewViewModel viewModel);
    }
}
