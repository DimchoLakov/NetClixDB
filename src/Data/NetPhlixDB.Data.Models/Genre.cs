using System.Collections.Generic;
using NetPhlixDB.Data.Models.Enums;

namespace NetPhlixDB.Data.Models
{
    using System;

    public class Genre : BaseModel<string>
    {
        public Genre()
        {
            this.Id = Guid.NewGuid().ToString();
            this.GenreMovies = new List<MovieGenre>();
        }

        public GenreType GenreType { get; set; }

        public virtual ICollection<MovieGenre> GenreMovies { get; set; }
    }
}
