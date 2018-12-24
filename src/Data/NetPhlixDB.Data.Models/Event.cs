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
            this.Pictures = new List<string>();
        }

        public string EventTitle { get; set; }

        public string EventInfo { get; set; }

        public List<string> Pictures { get; set; }

        public virtual ICollection<MoviePerson> MoviePeople { get; set; }
    }
}
