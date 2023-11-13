using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ViewExample.Models;

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

            ViewData["appTitle"] = "Asp.net Course";
            ViewData["people"] = new List<Person>()
                {
                    new Person() {Name = "John Carter", DateOfBirth = DateTime.Parse("2005-04-15"), PersonGender = Gender.Male},
                    new Person() {Name = "Natasha", DateOfBirth = DateTime.Parse("1996-07-23"), PersonGender = Gender.Female},
                    new Person() {Name = "John Carter", DateOfBirth = DateTime.Parse("1999-02-28"), PersonGender = Gender.Other}
                };
            return View();

        }
    }
}
