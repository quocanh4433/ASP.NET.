using Microsoft.AspNetCore.Mvc;
using PartialViewExample.Models;

namespace PartialViewExample.Controllers
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

        //[Route("programming-languages")]
        [HttpPost("programming-languages")]
        public IActionResult ProgrammingLanguages()
        {
            ListModel listModel = new ListModel()
            {
                Title = "Programming Languages",
                ListItem = new List<string>() { "Javascript", "C++", "C#", "Go", "Pascal" }
            };


            //return new PartialViewResult()
            //{
            //    ViewName = "_ListPartialView",
            //    Model = listModel
            //};


            return PartialView("_ListPartialView", listModel);


        }
    }
}
