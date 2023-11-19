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
            ViewBag.APIKey = _congiguration.GetValue("APIKey", "Defaultkey");
            ViewBag.Counter = _congiguration.GetValue<int>("Counter", 10);
            return View();
        }
    }
}

