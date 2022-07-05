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
using MyMovieDb.Domain;
using MyMovieDb.Domain.Base;
using MyMovieDb.Domain.Movies;
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


        public async Task<IActionResult> Search(string query, int page = 1)
        {
            ViewBag.query = query;

            var viewModel = new SearchViewModel();
            viewModel.CurrentPage = page;
            
            try
            {
                viewModel.MovieResults = await _movieService.SearchMovie(query, page);
                viewModel.TVSerieResults = await _tvSerieService.SearchTVSerie(query, page);
            }
            catch (Exception ex)
            {
                if (viewModel.MovieResults.Results.Count == 0 && viewModel.TVSerieResults == null)
                {
                    return View(viewModel);
                }
            }

            viewModel.TotalPages = GetTotalPages(viewModel.MovieResults, viewModel.TVSerieResults);

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


        private int GetTotalPages(ResultPage<MovieSearch> movieResults, ResultPage<TVSerieSearch> tVSerieResults)
        {

            if (movieResults == null)
            {
                return tVSerieResults.TotalPages;
            }

            if (tVSerieResults == null)
            {
                return movieResults.TotalPages;
            }

            if (movieResults.TotalPages > tVSerieResults.TotalPages)
            {
                return movieResults.TotalPages;
            }

            return tVSerieResults.TotalPages;
        }
    }
}
