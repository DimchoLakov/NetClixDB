using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NetPhlixDb.Data.ViewModels.Movies;

namespace NetPhlixDb.Data.ViewModels.Binding.Reviews
{
    public class ReviewsMovieAddReviewViewModel
    {
        public ReviewsMovieAddReviewViewModel()
        {
            this.MovieReviewViewModels = new List<MovieReviewViewModel>();
        }

        public IEnumerable<MovieReviewViewModel> MovieReviewViewModels { get; set; }

        public string MovieTitle { get; set; }

        [Required]
        [Display(Name = "Title")]
        [StringLength(maximumLength: 256, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Content")]
        [StringLength(maximumLength: 5000, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 10)]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Rating")]
        [Range(minimum: 1, maximum: 10)]
        public double Rating { get; set; }

        [Required]
        public string MovieId { get; set; }

        public string UserId { get; set; }
    }
}
