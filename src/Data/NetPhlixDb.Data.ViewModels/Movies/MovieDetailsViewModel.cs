using System.Collections.Generic;

namespace NetPhlixDb.Data.ViewModels.Movies
{
    public class MovieDetailsViewModel
    {
        public MovieDetailsViewModel()
        {
            this.MovieGenreViewModels = new List<MovieGenreViewModel>();
            this.MoviePersonViewModels = new List<MoviePersonViewModel>();
            this.MovieReviewViewModels = new List<MovieReviewViewModel>();
        }

        public string Id { get; set; }

        public string Poster { get; set; }

        public string Title { get; set; }

        public string Rating { get; set; }

        public string Storyline { get; set; }

        public string YearReleased { get; set; }

        public string FullDateReleased { get; set; }

        public string Language { get; set; }

        public string Trailer { get; set; }

        public string ProductionCost { get; set; }

        public int Duration { get; set; }

        public string MovieType { get; set; }

        public string UserId { get; set; }

        public IEnumerable<MovieGenreViewModel> MovieGenreViewModels { get; set; }

        public IEnumerable<MoviePersonViewModel> MoviePersonViewModels { get; set; }

        public IEnumerable<MovieReviewViewModel> MovieReviewViewModels { get; set; }

        //public List<MovieCompany> MovieCompanies { get; set; }
    }
}
