using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieDb.Domain.Movies
{
    public class Movie
    {

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "runtime")]
        public int Duration { get; set; }
        [JsonProperty(PropertyName = "tagline")]
        public string Tagline { get; set; }

        [JsonProperty(PropertyName = "overview")]
        public string Description { get; set; }
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
        
        [JsonIgnore]
        public IList<Cast> Cast { get; set; }
    }
}
