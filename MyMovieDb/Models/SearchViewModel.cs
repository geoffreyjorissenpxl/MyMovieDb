using MyMovieDb.Domain;
using MyMovieDb.Domain.Movies;
using MyMovieDb.Domain.TVSeries;

namespace MyMovieDb.Models
{
    public class SearchViewModel
    {
        public ResultPage<MovieSearch> MovieResults { get; set; }
        public ResultPage<TVSerieSearch> TVSerieResults { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
    }
}
