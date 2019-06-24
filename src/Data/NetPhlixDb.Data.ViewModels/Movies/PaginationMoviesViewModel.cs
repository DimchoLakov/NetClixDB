using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NetPhlixDb.Data.ViewModels.Movies
{
    public class PaginationMoviesViewModel
    {
        public PaginationMoviesViewModel()
        {
            this.IndexMovieViewModels = new List<IndexMovieViewModel>();
        }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        [Display(Name = "Title")]
        public string Search { get; set; }

        public string Genre { get; set; }

        public List<SelectListItem> Genres { get; set; }
        
        public IList<IndexMovieViewModel> IndexMovieViewModels { get; set; }
    }
}
