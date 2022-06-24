using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace MyMovieDb.Data.Util
{
    public class TMDBClient
    {
        private HttpClient _httpClient;
        private readonly string apiKey = "8d2ad5c9c92e29f8ec1c5c4d5c61f1bd";

        public TMDBClient()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://api.themoviedb.org/3/")
            };
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("key", $"={apiKey}");
        }
    }
}
