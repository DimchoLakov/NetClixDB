using System.Collections.Generic;

namespace NetPhlixDb.Data.ViewModels.Events
{
    public class EventWithNotAddedMoviesViewModel
    {
        public EventWithNotAddedMoviesViewModel()
        {
            this.MovieEventViewModels = new List<MovieEventViewModel>();
        }

        public string EventId { get; set; }

        public string EventTitle { get; set; }

        public IEnumerable<MovieEventViewModel> MovieEventViewModels { get; set; }
    }
}
