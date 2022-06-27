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
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public IActionResult Index()
        {

            return View();
        }

        public async Task<IActionResult> Detail(int id)
        {
            var movie = await _movieService.GetDetails(id);
            movie.Cast = await _movieService.GetMovieCast(id);

            return View(movie);
        }
    }
}
