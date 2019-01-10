using System;
using System.ComponentModel.DataAnnotations;
using NetPhlixDB.Data.Models.Enums;

namespace NetPhlixDb.Data.ViewModels.Admin.People
{
    public class EditPersonViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [DataType(DataType.Text)]
        [StringLength(maximumLength: 32, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [DataType(DataType.Text)]
        [StringLength(maximumLength: 32, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        [Display(Name = "Birth Place")]
        [DataType(DataType.Text)]
        [StringLength(maximumLength: 50, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 2)]
        public string BirthPlace { get; set; }

        [Required]
        [Display(Name = "Person Role")]
        public PersonRole PersonRole { get; set; }

        [Required]
        [Display(Name = "Picture")]
        [DataType(DataType.Url)]
        public string Picture { get; set; }

        [Required]
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Required]
        [StringLength(maximumLength: 1500, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 10)]
        [Display(Name = "Bio")]
        [DataType(DataType.Text)]
        public string Bio { get; set; }
    }
}
