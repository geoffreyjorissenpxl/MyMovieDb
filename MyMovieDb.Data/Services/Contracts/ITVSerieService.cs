using MyMovieDb.Domain;
using MyMovieDb.Domain.TVSeries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMovieDb.Data.Services.Contracts
{
    public interface ITVSerieService
    {
        Task<TVSerie> GetDetails(int id);
        Task<ResultPage<TVSerieSearch>> SearchTVSerie(string name, int page);
        Task<ResultPage<TVSerieSearch>> GetPopularTVSeries(int page);
        Task<ResultPage<TVSerieSearch>> GetTopRatedTVSeries(int page);
        Task<IList<Cast>> GetTVSerieCast(int id);
        Task<IList<TVSerieSearch>>GetTVSerieRecommendations(int id);
        Task<IList<Review>> GetTVSerieReviews(int id);
    }
}
