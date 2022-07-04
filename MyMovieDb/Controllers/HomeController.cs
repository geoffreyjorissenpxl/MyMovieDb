using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyMovieDb.Data.Repositories.Contracts;
using MyMovieDb.Data.Services.Contracts;
using MyMovieDb.Domain.Base;
using MyMovieDb.Domain.TVSeries;
using MyMovieDb.Models;

namespace MyMovieDb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMovieService _movieService;
        private ITVSerieService _tvSerieService;

        public HomeController(ILogger<HomeController> logger, IMovieService movieService, ITVSerieService tvSerieService)
        {
            _logger = logger;
            _movieService = movieService;
            _tvSerieService = tvSerieService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeViewModel();
            viewModel.TheaterMovies = (await _movieService.GetMoviesInTheater(1)).Results;
            viewModel.PopularMovies = (await _movieService.GetPopularMovies(1)).Results;
            viewModel.TopRatedMovies = (await _movieService.GetTopRatedMovies(1)).Results;

            viewModel.PopularTVSeries = (await _tvSerieService.GetPopularTVSeries(1)).Results;
            viewModel.TopRatedTVSeries = (await _tvSerieService.GetTopRatedTVSeries(1)).Results;
            
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
