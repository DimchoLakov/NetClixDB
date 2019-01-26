using Newtonsoft.Json;

namespace NetPhlixDb.Data.ViewModels.DTOs
{
    public class MovieCompanyDto
    {
        [JsonProperty("logo_path")]
        public string Logo { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("origin_country")]
        public string OriginCountry { get; set; }
    }
}
