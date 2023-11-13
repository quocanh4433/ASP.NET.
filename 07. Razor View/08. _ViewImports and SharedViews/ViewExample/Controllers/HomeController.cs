using Microsoft.AspNetCore.Mvc;
using ViewExample.Models;

namespace ViewExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.appTitle = "Asp.net Course";


            List<Person> people = new List<Person>()
                {
                    new Person() {Name = "John Carter", DateOfBirth = DateTime.Parse("2005-04-15"), PersonGender = Gender.Male},
                    new Person() {Name = "Natasha", DateOfBirth = DateTime.Parse("1996-07-23"), PersonGender = Gender.Female},
                    new Person() {Name = "John Carter", DateOfBirth = DateTime.Parse("1999-02-28"), PersonGender = Gender.Other}
                };
            return View("Index", people);

        }

        [Route("/person-details/{name}")]
        public IActionResult Details(string? name)
        {
            if (name == null)
                return Content("Person name can't be null");

            List<Person> people = new List<Person>()
                {
                    new Person() {Name = "John Carter", DateOfBirth = DateTime.Parse("2005-04-15"), PersonGender = Gender.Male},
                    new Person() {Name = "Natasha", DateOfBirth = DateTime.Parse("1996-07-23"), PersonGender = Gender.Female},
                    new Person() {Name = "John Carter", DateOfBirth = DateTime.Parse("1999-02-28"), PersonGender = Gender.Other}
                };

            Person? matchingPerson = people.Where(temp => temp.Name == name).FirstOrDefault();

            //return View(object Model)
            return View(matchingPerson); //Views/Home/Details.cshtml

            // return (string ViewName, object Model)
            //return View("Details", matchingPerson);
        }

        [Route("/person-and-product")]
        public IActionResult PersonAndProduct()
        {
            Person person = new Person()
            {
                Name = "Johny Evan",
                DateOfBirth = DateTime.Parse("2005-04-15"),
                PersonGender = Gender.Male
            };
            Product product = new Product()
            {
                ProductId = 453,
                ProductName = "Air Conditioner"
            };
            PersonAndProdcutWrapperModel personAndProdcutWrapper = new PersonAndProdcutWrapperModel()
            {
                PersonData = person,
                ProductData = product
            };
            return View(personAndProdcutWrapper);
        }

        [Route("home/all-product")]
        public IActionResult All()
        {
            return View();
        }
    }
}
