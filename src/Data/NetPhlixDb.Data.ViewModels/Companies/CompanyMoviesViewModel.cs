using System;
using System.ComponentModel.DataAnnotations;

namespace NetPhlixDb.Data.ViewModels.Companies
{
    public class CompanyMovieViewModel
    {
        [Required]
        [Display(Name = "Title")]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Poster")]
        [DataType(DataType.ImageUrl)]
        public string Poster { get; set; }

        [Required]
        [Display(Name = "Date Released")]
        [DataType(DataType.DateTime)]
        public DateTime DateReleased { get; set; }
    }
}
