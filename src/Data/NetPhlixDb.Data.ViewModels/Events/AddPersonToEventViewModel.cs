using System.ComponentModel.DataAnnotations;

namespace NetPhlixDb.Data.ViewModels.Events
{
    public class AddPersonToEventViewModel
    {
        [Required]
        public string EventId { get; set; }

        [Required]
        public string PersonId { get; set; }
    }
}
