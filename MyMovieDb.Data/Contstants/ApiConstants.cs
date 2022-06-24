using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieDb.Data.Contstants
{
    public class ApiConstants
    {
        public const string BaseUrl = "https://api.themoviedb.org/3/";
        public const string ApiKey = "8d2ad5c9c92e29f8ec1c5c4d5c61f1bd";
        public const string Language = "en-US";
        public const string NoAdultSearch = "false";


        public const string PopularMoviesEndpoint = "movie/popular/";
        public const string TopRatedMoviesEndPoint = "movie/top_rated?";
        public const string UpcomingMoviesEndpoint = "movie/upcoming?";
        public const string SearchMovieEndPoint = "search/movie?";
        public const string MoviesInTheaterEndPoint = "movie/now_playing?";

        public const string TvEndPoint = "tv/";
        public const string PersonEndPoint = "person/";

        public const string SearchEnpoint = "search/";

      
        public const string PopularTVEndPoint = "tv/popular";


    }
}
