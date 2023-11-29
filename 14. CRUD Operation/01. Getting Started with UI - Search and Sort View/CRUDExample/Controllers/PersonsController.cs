using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUDExample.Controllers
{
    public class PersonsController : Controller
    {
        // Private - readonly
        private readonly IPersonService _personService;

        // Constructor
        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        [Route("persons/index")]
        [Route("/")]
        public IActionResult Index(string searchBy, string? searchString, string sortBy = nameof(PersonResponse.PersonName), SortOrderOptions sortOrder = SortOrderOptions.ASC)
        {
            ViewBag.SearchFields = new Dictionary<string, string>()
            {
               { nameof(PersonResponse.PersonName), "Person Name" },
               { nameof(PersonResponse.Email), "Email" },
               { nameof(PersonResponse.DateOfBirth), "Date of Birth" },
               { nameof(PersonResponse.Gender), "Gender" },
               { nameof(PersonResponse.CountryID), "Country" },
               { nameof(PersonResponse.Address), "Address" }
            };
            List<PersonResponse> persons = _personService.GetFilterPerson(searchBy, searchString);
            ViewBag.CurrentSearchBy = searchBy;
            ViewBag.CurrentSearchString = searchString;

            // Sort
            List<PersonResponse> sortPersons = _personService.GetSortPersons(persons, sortBy, sortOrder);
            ViewBag.CurrentSortBy = sortBy;
            ViewBag.CurrentSortOrder = sortOrder.ToString();
            return View(sortPersons);
        }
    }
}

