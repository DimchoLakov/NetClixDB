using System;
using System.ComponentModel.DataAnnotations;

namespace NetPhlixDb.Data.ViewModels.Events
{
    public class CreateEventViewModel
    {
        [Required]
        [StringLength(maximumLength: 64, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Title")]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required]
        [StringLength(maximumLength: 3000, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Info")]
        [DataType(DataType.Text)]
        public string Info { get; set; }

        [Required]
        [Display(Name = "Picture")]
        [DataType(DataType.Url)]
        public string Picture { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
