using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IDExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly CitiesService _citiesService;

        // Constuctor
        public HomeController()
        {
            _citiesService = new CitiesService();
        }
        [Route("/")]
        [Route("home")]
        public IActionResult Index()
        {
            List<string> cities = _citiesService.GetCities();
            return View(cities);
        }
    }
}

