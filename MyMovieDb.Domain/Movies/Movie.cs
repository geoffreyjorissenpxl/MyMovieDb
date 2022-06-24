using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieDb.Domain.Movies
{
    public class Movie
    {
        public IList<Genre> Genres { get; set; }

        [JsonProperty(PropertyName = "release_date")]
        public DateTime? ReleaseDate { get; set; }

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
