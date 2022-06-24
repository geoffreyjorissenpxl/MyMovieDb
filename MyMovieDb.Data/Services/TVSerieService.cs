using MyMovieDb.Data.Contstants;
using MyMovieDb.Data.Repositories.Contracts;
using MyMovieDb.Data.Services.Contracts;
using MyMovieDb.Domain;
using MyMovieDb.Domain.TVSeries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMovieDb.Data.Services
{
    public class TVSerieService : ITVSerieService
    {

        private IGenericApiRepository _genericApiRepository;

        public TVSerieService(IGenericApiRepository genericApiRepository)
        {
            _genericApiRepository = genericApiRepository;
        }


        public async Task<TVSerie> GetDetails(int id)
        {
            var url = $"/tv/{id}?api_key={ApiConstants.ApiKey}&language=en-US";
            var result = await _genericApiRepository.GetAsync<TVSerie>(url);

            return result;
        }

        public async Task<IList<TVSerieSearch>> GetPopularTVSeries()
        {
            var url = $"/movie/popular?api_key={ApiConstants.ApiKey}&language=en-US&page=1";
            var resultPage = await _genericApiRepository.GetAsync<ResultPage<TVSerieSearch>>(url);

            return resultPage.Results;
        }

        public async Task<IList<TVSerieSearch>> GetTopRatedTVSeries(int page = 1)
        {
            var url = $"/tv/top_rated?api_key={ApiConstants.ApiKey}&language=en-US&page={page}";
            var resultPage = await _genericApiRepository.GetAsync<ResultPage<TVSerieSearch>>(url);

            return resultPage.Results;
        }
        public async Task<IList<TVSerieSearch>> SearchTVSerie(string name, int page = 1)
        {
            var query = Uri.EscapeUriString(name);
            var url = $"/search/tv?api_key={ApiConstants.ApiKey}&language=en-US&page={page}&query={query}&include_adult=false";

            var resultPage = await _genericApiRepository.GetAsync<ResultPage<TVSerieSearch>>(url);
            return resultPage.Results;
        }
    }
}
