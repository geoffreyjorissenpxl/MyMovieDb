using Newtonsoft.Json;

namespace MyMovieDb.Domain
{
    public class MediaVideo
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "site")]
        public string Site { get; set; }

        [JsonProperty(PropertyName = "key")]
        public string VideoLink { get; set; }
    }
}