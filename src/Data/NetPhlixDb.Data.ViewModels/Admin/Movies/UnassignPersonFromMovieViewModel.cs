using System.ComponentModel.DataAnnotations;

namespace NetPhlixDb.Data.ViewModels.Admin.Movies
{
    public class UnassignPersonFromMovieViewModel
    {
        [Required]
        public string PersonId { get; set; }

        [Required]
        public string MovieId { get; set; }
    }
}
