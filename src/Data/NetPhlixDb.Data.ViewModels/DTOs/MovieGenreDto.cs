using Newtonsoft.Json;

namespace NetPhlixDb.Data.ViewModels.DTOs
{
    public class MovieGenreDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
