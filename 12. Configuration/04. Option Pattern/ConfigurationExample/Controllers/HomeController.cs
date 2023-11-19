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
            // Get configuration value int new Option object
            //WeatherOption option = _congiguration.GetSection("WeatherApi").Get<WeatherOption>();

            // Get configuration value into existing option object
            WeatherOption option = new WeatherOption();
            _congiguration.GetSection("WeatherApi").Bind(option);

            // Cách 3: Get từ option pattern
            ViewBag.ClientID = option.ClientID;
            ViewBag.ClientSecret = option.ClientSecret;





            return View();
        }
    }
}

