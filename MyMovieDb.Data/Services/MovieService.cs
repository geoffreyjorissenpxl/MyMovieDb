using Microsoft.AspNetCore.WebUtilities;
using MyMovieDb.Data.Contstants;
using MyMovieDb.Data.Repositories.Contracts;
using MyMovieDb.Data.Services.Contracts;
using MyMovieDb.Domain;
using MyMovieDb.Domain.Movies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMovieDb.Data.Services
{
    public class MovieService : IMovieService
    {
        private IGenericApiRepository _genericApiRepository;

        public MovieService(IGenericApiRepository genericApiRepository)
        {
            _genericApiRepository = genericApiRepository;
        }
        public async Task<Movie> GetDetails(int id)
        {
            var url = $"movie/{id}?api_key={ApiConstants.ApiKey}&language=en-US";
            var result = await _genericApiRepository.GetAsync<Movie>(url);

            return result;
        }

        public async Task<ResultPage<MovieSearch>> GetPopularMovies(int page = 1)
        {
            var url = $"{ApiConstants.PopularMoviesEndpoint}api_key={ApiConstants.ApiKey}&language=en-US&page={page}";
            var resultPage = await _genericApiRepository.GetAsync<ResultPage<MovieSearch>>(url);

            return resultPage;
        }

        public async Task<ResultPage<MovieSearch>> GetTopRatedMovies(int page)
        {
            var url = $"{ApiConstants.TopRatedMoviesEndPoint}api_key={ApiConstants.ApiKey}&language=en-US&page={page}";
            var resultPage = await _genericApiRepository.GetAsync<ResultPage<MovieSearch>>(url);

            return resultPage;
        }

        public async Task<ResultPage<MovieSearch>> GetMoviesInTheater(int page = 1)
        {
            var url = $"{ApiConstants.MoviesInTheaterEndPoint}api_key={ApiConstants.ApiKey}&language=en-US&page={page}";
            var resultPage = await _genericApiRepository.GetAsync<ResultPage<MovieSearch>>(url);

            return resultPage;
        }

        public async Task<ResultPage<MovieSearch>> GetUpcomingMovies(int page)
        {
            var url = $"{ApiConstants.UpcomingMoviesEndpoint}api_key={ApiConstants.ApiKey}&language=en-US&page={page}";
            var resultPage = await _genericApiRepository.GetAsync<ResultPage<MovieSearch>>(url);

            return resultPage;
        }

        public async Task<IList<MovieSearch>> SearchMovie(string name, int page)
        {
            var url = $"{ApiConstants.SearchMovieEndPoint}api_key={ApiConstants.ApiKey}&language=en-US&query={name}&page={page}&include_adult=false";

            var resultPage = await _genericApiRepository.GetAsync<ResultPage<MovieSearch>>(url);
            return resultPage.Results;
        }

        public async Task<IList<Cast>> GetMovieCast(int id)
        {
            var url = $"movie/{id}/credits?api_key={ApiConstants.ApiKey}&language=en-US";

            var result = await _genericApiRepository.GetAsync<Credits>(url);
            return result.Cast;

        }

        public async Task<IList<MovieSearch>> GetMovieRecommendations(int id)
        {
            var url = $"movie/{id}/recommendations?api_key={ApiConstants.ApiKey}&language=en-US&page=1";

            var result = await _genericApiRepository.GetAsync<ResultPage<MovieSearch>>(url);
            return result.Results;
        }

        public async Task<IList<Review>> GetMovieReviews(int id)
        {
            var url = $"movie/{id}/reviews?api_key={ApiConstants.ApiKey}&language=en-US&page=1";

            var result = await _genericApiRepository.GetAsync<ResultPage<Review>>(url);
            return result.Results;
        }
    }
}
