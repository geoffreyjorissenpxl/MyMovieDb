using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyMovieDb.Controllers
{
    public class TVController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
