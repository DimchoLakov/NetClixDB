using NetPhlixDB.Data.Models.Enums;

namespace NetPhlixDB.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Movie : BaseModel<string>
    {
        public Movie()
        {
            this.Id = Guid.NewGuid().ToString();
            this.MoviePeople = new List<MoviePerson>();
            this.MovieGenres = new List<MovieGenre>();
            this.MovieCompanies = new List<MovieCompany>();
            this.Reviews = new List<Review>();
            this.MovieUsers = new List<MovieUser>();
        }

        public string Title { get; set; }

        public string Storyline { get; set; }

        public Language Language { get; set; }

        public string Poster { get; set; }

        public string Trailer { get; set; }

        public DateTime DateReleased { get; set; }

        public decimal ProductionCost { get; set; }

        public int Duration { get; set; }

        public double Rating { get; set; }

        public MovieType MovieType { get; set; }

        public virtual ICollection<MovieUser> MovieUsers { get; set; }

        public virtual ICollection<MovieCompany> MovieCompanies { get; set; }

        public virtual ICollection<MoviePerson> MoviePeople { get; set; }

        public virtual ICollection<MovieGenre> MovieGenres { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
