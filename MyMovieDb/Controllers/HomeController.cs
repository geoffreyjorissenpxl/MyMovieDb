﻿using System;
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
            viewModel.TheaterMovies = await _movieService.GetMoviesInTheater(1);
            viewModel.PopularMovies = await _movieService.GetPopularMovies();
            viewModel.TopRatedMovies = await _movieService.GetTopRatedMovies();

            viewModel.PopularTVSeries = await _tvSerieService.GetPopularTVSeries();
            viewModel.TopRatedTVSeries = await _tvSerieService.GetTopRatedTVSeries();
            
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
