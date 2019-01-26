using System.ComponentModel.DataAnnotations;

namespace NetPhlixDb.Data.ViewModels.Admin.Movies
{
    public class MovieAddGenreViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        [StringLength(maximumLength: 32, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 2)]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(maximumLength: 32, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 2)]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}
