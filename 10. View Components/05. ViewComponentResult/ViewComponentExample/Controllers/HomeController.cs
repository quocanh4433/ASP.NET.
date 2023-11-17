using Microsoft.AspNetCore.Mvc;
using ViewComponentExample.Models;

namespace ViewComponentExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            
            return View();
        }

        [Route("friend-list")]
        public IActionResult Friends()
        {
            PersonGridModel personGridModel = new PersonGridModel()
            {
                GridTitle = "Friend List",
                Persons = new List<Person>()
                {
                    new Person() { PersonName = "John Cena", JobTitle = "Artist" },
                    new Person() { PersonName = "Ronaldo", JobTitle = "Football Player" },
                    new Person() { PersonName = "Taylor Swift", JobTitle = "Singer" },

                }
            };

            return ViewComponent("Grid", new { peopleModel = personGridModel });
        }
    }
}
