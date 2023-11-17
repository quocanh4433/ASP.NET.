using Microsoft.AspNetCore.Mvc;
using ViewComponentExample.Models;

namespace ViewComponentsExample.ViewComponents
{
    public class GridViewComponent : ViewComponent
    { 
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ////invoked a partial view Views/Shared/Components/Grid/Sample.cshtml
            //return View("Sample");

            PersonGridModel model = new PersonGridModel()
            {
                GridTitle = "Person List",
                Persons = new List<Person>()
                {
                    new Person() { PersonName = "John Cena", JobTitle = "Artist" },
                    new Person() { PersonName = "Ronaldo", JobTitle = "Football Player" },
                    new Person() { PersonName = "Taylor Swift", JobTitle = "Singer" },
                }
            };

            //invoked a partial view Views/Shared/Components/Grid/Default.cshtml
            ViewData["Grid"] = model;
            return View();
        }
    }
}