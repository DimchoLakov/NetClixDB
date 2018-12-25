using System;
using System.Collections.Generic;

namespace NetPhlixDB.Data.Models
{
    public class Event : BaseModel<string>
    {
        public Event()
        {
            this.Id = Guid.NewGuid().ToString();
            this.MoviePeople = new List<MoviePerson>();
        }

        public string Title { get; set; }

        public string Info { get; set; }

        public string Picture { get; set; }

        public virtual ICollection<MoviePerson> MoviePeople { get; set; }
    }
}
