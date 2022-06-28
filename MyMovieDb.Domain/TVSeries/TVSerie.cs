using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieDb.Domain.TVSeries
{
    public class TVSerie
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Title { get; set; }

        public string Tagline { get; set; }
        public string Overview { get; set; }

        [JsonProperty(PropertyName = "first_air_date")]
        public DateTime? ReleaseDate { get; set; }

        [JsonProperty(PropertyName = "poster_path")]
        public string PosterLink { get; set; }

        public IList<Genre> Genres { get; set; }
        public IList<Season> Seasons { get; set; }

        [JsonProperty(PropertyName = "vote_average")]
        public double Rating { get; set; }
        [JsonProperty(PropertyName = "vote_count")]
        public int Votes { get; set; }
        [JsonProperty(PropertyName = "popularity")]
        public double PopularityScore { get; set; }
    }
}
