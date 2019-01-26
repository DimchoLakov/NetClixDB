using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NetPhlixDb.Data.ViewModels.DTOs
{
    public class MovieDto
    {
        public MovieDto()
        {
            this.MovieGenreDtos = new List<MovieGenreDto>();
            this.MovieCompanyDtos = new List<MovieCompanyDto>();
        }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("budget")]
        public decimal ProductionCost { get; set; }

        [JsonProperty("original_language")]
        public string Language { get; set; }

        [JsonProperty("release_date")]
        public DateTime ReleaseDate { get; set; }

        [JsonProperty("runtime")]
        public int Duration { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

        [JsonProperty("overview")]
        public string Storyline { get; set; }

        [JsonProperty("poster_path")]
        public string Poster { get; set; }

        [JsonProperty("genres")]
        public List<MovieGenreDto> MovieGenreDtos { get; set; }

        [JsonProperty("production_companies")]
        public List<MovieCompanyDto> MovieCompanyDtos { get; set; }
    }
}
