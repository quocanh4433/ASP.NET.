using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConfigurationExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _congiguration;

        public HomeController(IConfiguration configuration)
        {
            _congiguration = configuration;

        }
        [Route("/")]
        public IActionResult Index()
        {
            // Cách 1:
            //ViewBag.ClientID = _congiguration.GetValue("WeatherApp:ClientID", "......");
            //ViewBag.ClientSecret = _congiguration.GetValue("WeatherApp:ClientSecret", "......");

            //Cách 2:
            ViewBag.ClientID = _congiguration.GetSection("WeatherApp")["ClientID"];
            ViewBag.ClientSecret = _congiguration.GetValue("WeatherApp:ClientSecret", "......");




            return View();
        }
    }
}

