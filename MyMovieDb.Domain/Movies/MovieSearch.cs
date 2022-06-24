using MyMovieDb.Domain.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieDb.Domain.Movies
{
    public class MovieSearch : SearchBase
    {
        [JsonProperty(PropertyName = "release_date")]
        public DateTime? ReleaseDate { get; set; }
        public string Title { get; set; }
    }
}
