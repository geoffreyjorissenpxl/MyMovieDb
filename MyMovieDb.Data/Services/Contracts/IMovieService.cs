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
        Task<IList<MovieSearch>> SearchMovie(string name, int page = 1);
        Task<IList<MovieSearch>> GetPopularMovies(int page = 1);
        Task<IList<MovieSearch>> GetTopRatedMovies(int page = 1);
        Task<IList<MovieSearch>> GetUpcomingMovies(int page = 1);
        Task<IList<MovieSearch>> GetMoviesInTheater(int page = 1);
        Task<IList<Cast>> GetMovieCast(int id);
        Task<IList<MovieSearch>> GetMovieRecommendations(int id);
    }
}
