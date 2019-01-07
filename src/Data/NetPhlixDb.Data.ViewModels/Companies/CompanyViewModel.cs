using System;
using System.Collections.Generic;

namespace NetPhlixDb.Data.ViewModels.Companies
{
    public class CompanyViewModel
    {
        public CompanyViewModel()
        {
            this.CompanyMoviesViewModels = new List<CompanyMovieViewModel>();
        }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Details { get; set; }

        public string Logo { get; set; }

        public IEnumerable<CompanyMovieViewModel> CompanyMoviesViewModels { get; set; }
    }
}
