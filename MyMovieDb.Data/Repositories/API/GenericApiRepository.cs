using MyMovieDb.Data.Contstants;
using MyMovieDb.Data.Repositories.Contracts;
using Newtonsoft.Json;
using Polly;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MyMovieDb.Data.Repositories.API
{
    public class GenericApiRepository : IGenericApiRepository
    {
        public async Task<T> GetAsync<T>(string url)
        {
            try
            {

                string jsonResult = string.Empty;
                var httpClient = CreateHttpClient();
                var responseMessage = await Policy
                       .Handle<WebException>(exception =>
                       {
                           Debug.WriteLine($"{exception.GetType().Name + " : " + exception.Message}");
                           return true;
                       })
                       .WaitAndRetryAsync
                       (
                           5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                       )
                       .ExecuteAsync(async () => await httpClient.GetAsync(url));

                if (responseMessage.IsSuccessStatusCode)
                {
                    jsonResult = await responseMessage.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<T>(jsonResult);
                    return result;
                }

                throw new HttpRequestException(responseMessage.StatusCode.ToString());
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{e.GetType().Name + " : " + e.Message}");
                throw;
            }
        }

        private HttpClient CreateHttpClient()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri(ApiConstants.BaseUrl)
            };
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("key", $"={ApiConstants.ApiKey}");

            return client;
        }
    }
}
