using System;
using System.Collections.Generic;

namespace NetPhlixDB.Data.Models
{
    public class Event : BaseModel<string>
    {
        public Event()
        {
            this.Id = Guid.NewGuid().ToString();
            this.EventMovies = new List<EventMovie>();
            this.EventPeople = new List<EventPerson>();
        }

        public string Title { get; set; }

        public string Info { get; set; }

        public string Picture { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<EventMovie> EventMovies { get; set; }

        public virtual ICollection<EventPerson> EventPeople { get; set; }
    }
}
