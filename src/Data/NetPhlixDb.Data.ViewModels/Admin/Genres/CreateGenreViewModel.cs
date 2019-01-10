using System.ComponentModel.DataAnnotations;
using NetPhlixDB.Data.Models.Enums;

namespace NetPhlixDb.Data.ViewModels.Admin.Genres
{
    public class CreateGenreViewModel
    {
        [Required]
        [Display(Name = "Genre")]
        public GenreType GenreType { get; set; }

        [Required]
        [DataType(DataType.Url)]
        [Display(Name = "Poster")]
        public string Poster { get; set; }
    }
}
