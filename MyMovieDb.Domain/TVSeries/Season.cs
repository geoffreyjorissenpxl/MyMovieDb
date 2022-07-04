using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieDb.Domain.TVSeries
{
    public class Season
    {

        [JsonProperty(PropertyName = "air_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty(PropertyName = "episode_count")]
        public int EpisodeCount { get; set; }

        [JsonProperty(PropertyName = "season_number")]
        public int SeasonNumber { get; set; }
        public string Overview { get; set; }
        [JsonProperty(PropertyName = "poster_path")]
        public string PosterLink { get; set; }
    }
}
