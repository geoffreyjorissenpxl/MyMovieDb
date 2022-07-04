using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieDb.Domain
{
    public class Review
    {
        public string Content { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public string Date { get; set; }
        public string Url { get; set; }
    }
}
