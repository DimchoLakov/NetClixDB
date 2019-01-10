using System;
using System.ComponentModel.DataAnnotations;
using NetPhlixDB.Data.Models.Enums;

namespace NetPhlixDb.Data.ViewModels.Admin.Movies
{
    public class CreateMovieViewModel
    {
        [Required]
        [Display(Name = "Title")]
        [DataType(DataType.Text)]
        [StringLength(maximumLength: 200, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Storyline")]
        [DataType(DataType.Text)]
        [StringLength(maximumLength: 5000, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 10)]
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
        [DataType(DataType.DateTime)]
        public DateTime DateReleased { get; set; }

        [Required]
        [Display(Name = "Production Cost")]
        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal ProductionCost { get; set; }

        [Required]
        [Display(Name = "Movie Length (min)")]
        public int Duration { get; set; }

        [Required]
        [Display(Name = "Rating")]
        [Range(typeof(double), "1", "10")]
        public double Rating { get; set; }

        [Required]
        [Display(Name = "Movie Type")]
        public MovieType MovieType { get; set; }
    }
}
