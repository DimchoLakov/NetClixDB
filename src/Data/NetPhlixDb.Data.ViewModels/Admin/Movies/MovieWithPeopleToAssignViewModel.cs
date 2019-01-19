using System.Collections.Generic;
using NetPhlixDb.Data.ViewModels.Admin.People;

namespace NetPhlixDb.Data.ViewModels.Admin.Movies
{
    public class MovieWithPeopleToAssignViewModel
    {
        public MovieWithPeopleToAssignViewModel()
        {
            this.PersonToAssignViewModels = new List<PersonAssignViewModel>();
        }

        public string MovieId { get; set; }

        public string Title { get; set; }

        public IEnumerable<PersonAssignViewModel> PersonToAssignViewModels { get; set; }
    }
}
