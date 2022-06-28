using MyMovieDb.Data.Contstants;
using MyMovieDb.Data.Repositories.Contracts;
using MyMovieDb.Data.Services.Contracts;
using MyMovieDb.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovieDb.Data.Services
{
    public class MediaService : IMediaService
    {
        private IGenericApiRepository _genericApiRepository;

        public MediaService(IGenericApiRepository genericApiRepository)
        {
            _genericApiRepository = genericApiRepository;
        }

        public async Task<IList<MediaImage>> GetPosters(int id, string media)
        {
            var url = $"{media}/{id}/images?api_key={ApiConstants.ApiKey}";
            var result = await _genericApiRepository.GetAsync<Media>(url);

            return result.Posters.OrderByDescending(x => x.Popularity).Take(15).ToList();
        }

        public async Task<IList<MediaVideo>> GetVideos(int id, string media)
        {
            var url = $"{media}/{id}/videos?api_key={ApiConstants.ApiKey}&language=en-US";
            var result = await _genericApiRepository.GetAsync<Media>(url);

            return result.Videos.Where(x => x.Site.ToLower() == "youtube")
                .Where(x => x.Type.ToLower() == "trailer")
                .Take(5).ToList();
        }
    }
}
