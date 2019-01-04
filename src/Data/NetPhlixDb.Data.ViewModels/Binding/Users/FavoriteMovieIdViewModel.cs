using System.ComponentModel.DataAnnotations;

namespace NetPhlixDb.Data.ViewModels.Binding.Users
{
    public class FavoriteMovieIdViewModel
    {
        [Required]
        public string Id { get; set; }
    }
}
