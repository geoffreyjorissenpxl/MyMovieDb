using MyMovieDb.Domain;
using MyMovieDb.Domain.TVSeries;
using System.Collections.Generic;

namespace MyMovieDb.Models
{
    public class TVDetailViewModel
    {
        public TVSerie TVSerie { get; set; }
        public IList<TVSerieSearch> Recommendations { get; set; }
        public IList<Cast> Cast { get; set; }
        public Media Media { get; set; }
    }
}
