using System.ComponentModel.DataAnnotations;
using NetPhlixDB.Data.Models.Enums;

namespace NetPhlixDb.Data.ViewModels.Binding.Admin.Genres
{
    public class IndexGenreViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Genre")]
        public GenreType GenreType { get; set; }

        [Display(Name = "Poster")]
        public string Poster { get; set; }
    }
}
