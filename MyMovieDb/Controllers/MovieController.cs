using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyMovieDb.Data.Services.Contracts;
using MyMovieDb.Domain;
using MyMovieDb.Models;

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
            var cast = await _movieService.GetMovieCast(id);

            var movieMedia = new Media();
            movieMedia.Videos = await _mediaService.GetVideos(id, "movie");
            movieMedia.Posters = await _mediaService.GetPosters(id, "movie");

            var reviews = await _movieService.GetMovieReviews(id);

            var recommendations = await _movieService.GetMovieRecommendations(id);

            var viewModel = new MovieDetailViewModel()
            {
                Movie = movie,
                Cast = cast,
                Recommendations = recommendations,
                Media = movieMedia,
                Reviews = reviews
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Theater(int page = 1)
        {
            if(page < 1)
            {
                page = 1;
            }

            var viewModel = await _movieService.GetMoviesInTheater(page);
            return View(viewModel);
        }
    }
}
