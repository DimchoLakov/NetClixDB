using System.Collections.Generic;
using NetPhlixDB.Data.Models.Enums;

namespace NetPhlixDB.Data.Models
{
    using System;

    public class Person : BaseModel<string>
    {
        public Person()
        {
            this.Id = Guid.NewGuid().ToString();
            this.PersonMovies = new List<MoviePerson>();
            this.PersonEvents = new List<EventPerson>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string BirthPlace { get; set; }

        public PersonRole PersonRole { get; set; }

        public string Picture { get; set; }

        public int Age { get; set; }

        public string Bio { get; set; }

        public virtual ICollection<MoviePerson> PersonMovies { get; set; }

        public virtual ICollection<EventPerson> PersonEvents { get; set; }
    }
}
