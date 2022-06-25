using MyMovieDb.Domain.Movies;
using MyMovieDb.Domain.TVSeries;
using System.Collections.Generic;

namespace MyMovieDb.Models
{
    public class HomeViewModel
    {
        public IList<MovieSearch> TheaterMovies { get; set; }
        public IList<MovieSearch> PopularMovies { get; set; }
        public IList<MovieSearch> TopRatedMovies  { get; set; }
        public IList<TVSerieSearch> PopularTVSeries { get; set; }
        public IList<TVSerieSearch> TopRatedTVSeries { get; set; }

    }
}
