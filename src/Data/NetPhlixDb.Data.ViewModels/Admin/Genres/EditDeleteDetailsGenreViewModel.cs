using System.ComponentModel.DataAnnotations;
using NetPhlixDB.Data.Models.Enums;

namespace NetPhlixDb.Data.ViewModels.Admin.Genres
{
    public class EditDeleteDetailsGenreViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public GenreType GenreType { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Poster")]
        public string Poster { get; set; }
    }
}
