using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMovieDb.Data.Repositories.Contracts
{
    public interface IGenericApiRepository
    {
        Task<T> GetAsync<T>(string url);
    }
}
