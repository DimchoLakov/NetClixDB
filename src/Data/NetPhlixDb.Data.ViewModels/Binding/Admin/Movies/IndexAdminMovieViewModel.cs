using System;
using System.ComponentModel.DataAnnotations;
using NetPhlixDB.Data.Models.Enums;

namespace NetPhlixDb.Data.ViewModels.Binding.Admin.Movies
{
    public class IndexAdminMovieViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Movie Type")]
        public MovieType MovieType { get; set; }

        [Display(Name = "Date Released")]
        public DateTime DateReleased { get; set; }
    }
}
