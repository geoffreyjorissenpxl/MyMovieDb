using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyMovieDb.Data.Services.Contracts;

namespace MyMovieDb.Controllers
{
    public class MovieController : Controller
    {
        private IMovieService _movieService;
        private IMediaService _mediaService;
        public MovieController(IMovieService movieService, IMediaService mediaService)
        {
            _movieService = movieService;
            _mediaService = mediaService;
        }
        public IActionResult Index()
        {

            return View();
        }

        public async Task<IActionResult> Detail(int id)
        {
            var movie = await _movieService.GetDetails(id);
            movie.Cast = await _movieService.GetMovieCast(id);

            movie.MovieMedia.Posters = await _mediaService.GetPosters(id, "movie");
            movie.MovieMedia.Videos = await _mediaService.GetVideos(id, "movie");

            return View(movie);
        }
    }
}
