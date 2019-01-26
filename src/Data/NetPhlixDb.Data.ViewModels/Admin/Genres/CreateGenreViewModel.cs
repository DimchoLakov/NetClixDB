using System.ComponentModel.DataAnnotations;

namespace NetPhlixDb.Data.ViewModels.Admin.Genres
{
    public class CreateGenreViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Url)]
        [Display(Name = "Poster")]
        public string Poster { get; set; }
    }
}
