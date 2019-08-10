using System;
using System.Collections.Generic;

namespace NetPhlixDb.WebApi.DTOs
{
    public class MovieDto
    {

        public MovieDto()
        {
            this.Persons = new HashSet<MoviePersonDto>();
            this.Companies= new HashSet<MovieCompanyDto>();
        }

        public string Title { get; set; }

        public string Storyline { get; set; }

        public string Language { get; set; }

        public string Poster { get; set; }

        public string Trailer { get; set; }

        public string DateReleased { get; set; }

        public IEnumerable<MoviePersonDto> Persons { get; set; }

        public IEnumerable<MovieCompanyDto> Companies { get; set; }
    }
}
