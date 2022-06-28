using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieDb.Domain
{
    public class Media
    {
        [JsonProperty(PropertyName = "backdrops")]
        public IList<MediaImage>  Posters { get; set; }
        
        [JsonProperty(PropertyName = "Results")]
        public IList<MediaVideo> Videos { get; set; }
    }

}
