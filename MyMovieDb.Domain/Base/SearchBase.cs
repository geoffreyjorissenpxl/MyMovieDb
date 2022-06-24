using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieDb.Domain.Base
{
    public class SearchBase
    {
        public int Id { get; set; }
        public string Overview { get; set; }

        [JsonProperty(PropertyName = "poster_path")]
        public string PosterLink { get; set; }

        [JsonProperty(PropertyName = "vote_average")]
        public double Rating { get; set; }

        [JsonProperty(PropertyName = "vote_count")]
        public int Votes { get; set; }

        [JsonProperty(PropertyName = "popularity")]
        public double PopularityScore { get; set; }
    }
}
