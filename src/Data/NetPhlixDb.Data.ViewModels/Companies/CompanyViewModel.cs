using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetPhlixDb.Data.ViewModels.Companies
{
    public class CompanyViewModel
    {
        public CompanyViewModel()
        {
            this.CompanyMoviesViewModels = new List<CompanyMovieViewModel>();
        }

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

        public IEnumerable<CompanyMovieViewModel> CompanyMoviesViewModels { get; set; }
    }
}
