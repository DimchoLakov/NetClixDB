using System;
using System.ComponentModel.DataAnnotations;

namespace NetPhlixDb.Data.ViewModels.Admin.Companies
{
    public class EditDeleteDetailsCompanyViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(maximumLength: 200, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Created On")]
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }

        [Required]
        [Display(Name = "Details")]
        [StringLength(maximumLength: 1000, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 2)]
        [DataType(DataType.Text)]
        public string Details { get; set; }

        [Required]
        [Display(Name = "Logo")]
        [DataType(DataType.Text)]
        public string Logo { get; set; }
    }
}
