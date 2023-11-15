using Microsoft.AspNetCore.Mvc;

namespace PartialViewExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.Title = "Cities from Controller";
            ViewBag.ListItem = new List<string>() { "Quang Binh", "Ha Noi", "Tp.HCM" };
            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            return View();
        }
    }
}
