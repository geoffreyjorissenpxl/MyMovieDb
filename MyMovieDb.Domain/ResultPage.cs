using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieDb.Domain
{
    public class ResultPage<T>
    {
        [JsonProperty(PropertyName = "page")]
        public int CurrentPage { get; set; }

        [JsonProperty(PropertyName = "total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty(PropertyName = "total_results")]
        public int TotalResults { get; set; }

        [JsonProperty(PropertyName = "results")]
        public List<T> Results { get; set; }

    }
}
