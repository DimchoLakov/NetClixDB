using System;

namespace NetPhlixDb.Data.ViewModels.People
{
    public class PersonMovieViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public DateTime DateReleased { get; set; }

        public string Storyline { get; set; }

        public double Rating { get; set; }
    }
}
