using System;
using System.Collections.Generic;

namespace NetPhlixDb.Data.ViewModels.People
{
    public class PersonViewModel
    {
        public PersonViewModel()
        {
            this.PersonMovieViewModels = new List<PersonMovieViewModel>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string BirthPlace { get; set; }

        public string Role { get; set; }

        public string Picture { get; set; }

        public int Age { get; set; }

        public string Bio { get; set; }

        public IList<PersonMovieViewModel> PersonMovieViewModels { get; set; }
    }
}
