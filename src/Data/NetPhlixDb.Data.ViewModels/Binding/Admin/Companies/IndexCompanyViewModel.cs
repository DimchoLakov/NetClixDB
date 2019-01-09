using System;
using System.ComponentModel.DataAnnotations;

namespace NetPhlixDb.Data.ViewModels.Binding.Admin.Companies
{
    public class IndexCompanyViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Created On")]
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }

        [Required]
        [Display(Name = "Details")]
        [DataType(DataType.Text)]
        public string Details { get; set; }

        [Required]
        [Display(Name = "Logo")]
        [DataType(DataType.Url)]
        public string Logo { get; set; }
    }
}
