using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConfigurationExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly WeatherOption options;

        public HomeController(IOptions<WeatherOption> weatherOption)
        {
            options = weatherOption.Value;

        }
        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.ClientID = options.ClientID;
            ViewBag.ClientSecret = options.ClientSecret;
            return View();
        }
    }
}

