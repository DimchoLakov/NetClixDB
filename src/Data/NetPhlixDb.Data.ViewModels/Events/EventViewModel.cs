using System;
using System.Collections.Generic;

namespace NetPhlixDb.Data.ViewModels.Events
{
    public class EventViewModel
    {
        public EventViewModel()
        {
            this.EventPersonViewModels = new List<EventPersonViewModel>();
            this.EventMovieViewModels = new List<EventMovieViewModel>();
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Info { get; set; }

        public string Picture { get; set; }

        public DateTime Date { get; set; }

        public IEnumerable<EventPersonViewModel> EventPersonViewModels { get; set; }

        public IEnumerable<EventMovieViewModel> EventMovieViewModels { get; set; }
    }
}
