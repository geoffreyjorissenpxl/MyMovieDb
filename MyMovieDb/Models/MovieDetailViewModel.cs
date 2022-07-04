using MyMovieDb.Domain;
using MyMovieDb.Domain.Movies;
using System.Collections.Generic;

namespace MyMovieDb.Models
{
    public class MovieDetailViewModel
    {
        public Movie Movie { get; set; }
        public IList<MovieSearch> Recommendations { get; set; }
        public IList<Cast> Cast { get; set; }
        public Media Media { get; set; }
        public IList<Review> Reviews { get; set; }
    }
}
