using System.ComponentModel.DataAnnotations;

namespace NetPhlixDb.Data.ViewModels.Admin.Genres
{
    public class IndexGenreViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Poster")]
        public string Poster { get; set; }
    }
}
