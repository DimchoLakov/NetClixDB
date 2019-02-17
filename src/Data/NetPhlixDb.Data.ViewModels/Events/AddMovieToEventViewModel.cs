using System.ComponentModel.DataAnnotations;

namespace NetPhlixDb.Data.ViewModels.Events
{
    public class AddMovieToEventViewModel
    {
        [Required]
        public string EventId { get; set; }

        [Required]
        public string MovieId { get; set; }
    }
}
