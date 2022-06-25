using MyMovieDb.Domain.Movies;
using System.Collections.Generic;

namespace MyMovieDb.Models
{
    public class HomeViewModel
    {
        public IList<MovieSearch> TheaterMovies { get; set; }
        public IList<MovieSearch> PopularMovies { get; set; }
        public IList<MovieSearch> TopRatedMovies  { get; set; }

    }
}
