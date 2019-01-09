using System;
using System.ComponentModel.DataAnnotations;
using NetPhlixDB.Data.Models.Enums;

namespace NetPhlixDb.Data.ViewModels.Binding.Admin.Movies
{
    public class EditMovieViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        [StringLength(maximumLength: 200, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 2)]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Storyline")]
        [StringLength(maximumLength: 5000, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 10)]
        [DataType(DataType.Text)]
        public string Storyline { get; set; }

        [Required]
        [Display(Name = "Language")]
        public Language Language { get; set; }

        [Required]
        [Display(Name = "Poster")]
        [DataType(DataType.Url)]
        public string Poster { get; set; }

        [Required]
        [Display(Name = "Trailer")]
        [DataType(DataType.Url)]
        public string Trailer { get; set; }

        [Required]
        [Display(Name = "Date Released")]
        [DataType(DataType.Date)]
        public DateTime DateReleased { get; set; }

        [Required]
        [Display(Name = "Production Cost")]
        [DataType(DataType.Currency)]
        public decimal ProductionCost { get; set; }

        [Required]
        [Display(Name = "Duration")]
        public int Duration { get; set; }

        [Required]
        [Display(Name = "Duration")]
        [Range(minimum: 1, maximum: 10)]
        public double Rating { get; set; }

        [Required]
        [Display(Name = "Movie Type")]
        public MovieType MovieType { get; set; }
    }
}
