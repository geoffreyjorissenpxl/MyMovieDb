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
    public class TVController : Controller
    {
        private ITVSerieService _tvSerieService;
        private IMediaService _mediaService;
        public TVController(ITVSerieService tvSerieService, IMediaService mediaService)
        {
            _tvSerieService = tvSerieService;
            _mediaService = mediaService;
        }
        public IActionResult Index()
        {

            return View();
        }

        public async Task<IActionResult> Detail(int id)
        {

            var tvSerie = await _tvSerieService.GetDetails(id);
            var cast = await _tvSerieService.GetTVSerieCast(id);

            var tvSerieMedia = new Media();
            tvSerieMedia.Videos = await _mediaService.GetVideos(id, "tv");
            tvSerieMedia.Posters = await _mediaService.GetPosters(id, "tv");

            var reviews = await _tvSerieService.GetTVSerieReviews(id);

            var recommendations = await _tvSerieService.GetTVSerieRecommendations(id);

            var viewModel = new TVDetailViewModel()
            {
                TVSerie = tvSerie,
                Cast = cast,
                Recommendations = recommendations,
                Media = tvSerieMedia,
                Reviews = reviews
            };

            return View(viewModel);
        }
    }
}
