using System.ComponentModel.DataAnnotations;

namespace NetPhlixDb.Data.ViewModels.Reviews
{
    public class AddReviewViewModel
    {
        [Required]
        [Display(Name = "Title")]
        [StringLength(maximumLength: 256, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Content")]
        [StringLength(maximumLength: 5000, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 10)]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Rating - number between 0 and 10")]
        [Range(minimum: 1, maximum: 10)]
        public double Rating { get; set; }
        
        [Required]
        public string MovieId { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
