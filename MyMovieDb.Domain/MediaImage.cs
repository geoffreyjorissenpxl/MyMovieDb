using Newtonsoft.Json;

namespace MyMovieDb.Domain
{
    public class MediaImage
    {
        [JsonProperty(PropertyName = "file_path")]
        public string ImageLink { get; set; }


        [JsonProperty(PropertyName = "vote_average")]
        public double Popularity { get; set; }
    }
}