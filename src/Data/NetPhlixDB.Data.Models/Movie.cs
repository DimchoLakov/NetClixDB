namespace NetPhlixDB.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Movie : BaseModel<string>
    {
        public Movie()
        {
            this.Id = Guid.NewGuid().ToString();
            this.MovieActors = new List<MovieActor>();
            this.MovieGenres = new List<MovieGenre>();
            this.Companies = new List<MovieCompany>();
            this.Reviews = new List<Review>();
        }

        public string Title { get; set; }

        public string Director { get; set; }

        public string Storyline { get; set; }

        public string Language { get; set; }

        public DateTime DateReleased { get; set; }

        public decimal ProductionCost { get; set; }

        public int Duration { get; set; }

        public double Rating { get; set; }

        public virtual ICollection<MovieCompany> Companies { get; set; }

        public virtual ICollection<MovieActor> MovieActors { get; set; }

        public virtual ICollection<MovieGenre> MovieGenres { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
