using System.ComponentModel.DataAnnotations;

namespace NetPhlixDb.Data.ViewModels.People
{
    public class RemoveFavMovieViewModel
    {
        [Required]
        public string Id { get; set; }
    }
}
