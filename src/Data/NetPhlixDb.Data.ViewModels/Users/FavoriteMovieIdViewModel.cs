using System.ComponentModel.DataAnnotations;

namespace NetPhlixDb.Data.ViewModels.Users
{
    public class FavoriteMovieIdViewModel
    {
        [Required]
        public string Id { get; set; }
    }
}
