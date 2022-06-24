using MyMovieDb.Domain.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieDb.Domain.TVSeries
{
    public class TVSerieSearch : SearchBase
    {
        [JsonProperty(PropertyName = "first_air_date")]
        public DateTime? ReleaseDate { get; set; }
        public string Name { get; set; }

    }
}
