using MyMovieDb.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMovieDb.Data.Services.Contracts
{
    public interface IMediaService
    {
        Task<IList<MediaImage>> GetPosters(int id, string media);
        Task<IList<MediaVideo>> GetVideos(int id, string media);
    }
}
