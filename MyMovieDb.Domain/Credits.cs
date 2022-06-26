using MyMovieDb.Domain.TVSeries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieDb.Domain
{
    public class Credits
    { 
        [JsonProperty(PropertyName = "cast")]
        public IList<Cast> Cast { get; set; }
    }
}
