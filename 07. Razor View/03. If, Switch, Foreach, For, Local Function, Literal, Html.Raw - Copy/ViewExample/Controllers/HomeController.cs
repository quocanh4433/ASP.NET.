using Microsoft.AspNetCore.Mvc;

namespace ViewExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            /*
             return View(); 
             - Default involke to Views/Home/Index.cshtml. "Home" is name of controller
             */

            /*
             return View("abc")
             - involke to abc.cshtml
             */

            /*
             return new ViewResult() {ViewName = "abc"}
            - involke to abc.cshtml
            */

            return View();

        }
    }
}
