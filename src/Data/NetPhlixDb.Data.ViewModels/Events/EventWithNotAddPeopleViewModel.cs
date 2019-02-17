using System.Collections.Generic;

namespace NetPhlixDb.Data.ViewModels.Events
{
    public class EventWithNotAddPeopleViewModel
    {
        public EventWithNotAddPeopleViewModel()
        {
            this.PersonViewModels = new List<PersonEventViewModel>();
        }

        public string EventId { get; set; }

        public string EventTitle { get; set; }

        public IEnumerable<PersonEventViewModel> PersonViewModels { get; set; }
    }
}
