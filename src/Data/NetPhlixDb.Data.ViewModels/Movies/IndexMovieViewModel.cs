using System.Collections.Generic;

namespace NetPhlixDb.Data.ViewModels.Movies
{
    public class IndexMovieViewModel
    {
        public IndexMovieViewModel()
        {
            this.Genres = new List<MovieGenreViewModel>();
        }

        public string Id { get; set; }

        public string Poster { get; set; }

        public string Title { get; set; }

        public double Rating { get; set; }

        public string ShortStoryline { get; set; }

        public string DateReleased { get; set; }

        public IList<MovieGenreViewModel> Genres { get; set; }
    }
}
