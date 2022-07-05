using MyMovieDb.Domain;
using MyMovieDb.Domain.Movies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMovieDb.Data.Services.Contracts
{
    public interface IMovieService
    {
        Task<Movie> GetDetails(int id);
        Task<ResultPage<MovieSearch>> SearchMovie(string name, int page = 1);
        Task<ResultPage<MovieSearch>> GetPopularMovies(int page);
        Task<ResultPage<MovieSearch>> GetTopRatedMovies(int page);
        Task<ResultPage<MovieSearch>> GetUpcomingMovies(int page);
        Task<ResultPage<MovieSearch>> GetMoviesInTheater(int page);
        Task<IList<Cast>> GetMovieCast(int id);
        Task<IList<MovieSearch>> GetMovieRecommendations(int id);
        Task<IList<Review>> GetMovieReviews(int id);
    }
}
