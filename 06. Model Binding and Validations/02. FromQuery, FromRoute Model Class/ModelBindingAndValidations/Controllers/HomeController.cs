using Microsoft.AspNetCore.Mvc;
using ModelBindingAndValidations.Models;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {

        /*
         URL like this:
            http://localhost:3435/book?islogged=true?bookid=1
            http://localhost:3435/bookstrore/13/false?islogged=true?bookid=1?author=Scott
         */

        [Route("bookstore/{bookid?}/{islogged?}")]
        public IActionResult Index([FromRoute]int? bookid, [FromQuery]bool? islogged, Book book)
        {
            // Book is should be apply
            if (bookid.HasValue == false)
            {
                return BadRequest("Book id is not supply");
            }

            // Book id can't be empty
            if (bookid <= 0)
            {
                return BadRequest("Book id can't be less than zero");
            }

            // Book id should be between 1 to 100
            if (bookid > 1000)
            {
                return NotFound("Book id can't be greater than or equal to zero");
            }

            if (islogged == false)
            {
                return Unauthorized("User must be authenticated");
            }

            return Content($"Book id: {bookid} - Is Logged: {islogged}", "text/plain");

        }
    }
}
