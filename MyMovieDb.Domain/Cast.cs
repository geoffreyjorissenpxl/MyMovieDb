using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieDb.Domain
{
    public class Cast
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Character")]
        public string Character { get; set; }

        [JsonProperty(PropertyName = "popularity")]
        public double Number { get; set; }

        [JsonProperty(PropertyName = "profile_path")]
        public string PosterLink { get; set; }
    }
}
