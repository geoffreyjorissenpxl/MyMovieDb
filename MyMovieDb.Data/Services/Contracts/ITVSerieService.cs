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
        Task<IList<TVSerieSearch>> SearchTVSerie(string name, int page = 1);
        Task<IList<TVSerieSearch>> GetPopularTVSeries();
        Task<IList<TVSerieSearch>> GetTopRatedTVSeries(int page = 1);
        Task<IList<Cast>> GetTVSerieCast(int id);
        Task<IList<TVSerieSearch>> GetTVSerieRecommendations(int id);
    }
}
