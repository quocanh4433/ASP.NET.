using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {

        /*
         URL like this:
            http://localhost:3435/book?islogged=true?bookid=1
         */

        [Route("bookstore")]
        public IActionResult Index()
        {
            // Book is should be apply
            if (!Request.Query.ContainsKey("bookid"))
            {
                //return Content("Book id is not supply");
                //return new BadRequestResult();
                return BadRequest("Book id is not supply");
            }

            // Book id can't be empty
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                return BadRequest("Book id can't be null or empty");
            }

            // Book id should be between 1 to 100
            int bookId = Convert.ToInt16(ControllerContext.HttpContext.Request.Query["bookid"]);

            if (bookId <= 0)
            {
                Response.StatusCode = 404;
                return NotFound("Book id can't be less than or equal to zero");
            }

            if (bookId > 1000)
            {
                Response.StatusCode = 404;
                return NotFound("Book id can't be greater than or equal to zero");
            }

            if (!Convert.ToBoolean(Request.Query["islogged"]))
            {
                return Unauthorized("User must be authenticated");
            }

            // 302 - Found - RedirectToActionResult
            //return new RedirectToActionResult("Books", "Store", new { id = bookId}); // 302 Found
            //return RedirectToAction("Books", "Store", new { id = bookId });


            // 301 - Move permanent - RedirectToActionResult
            //return new RedirectToActionResult("Books", "Store", new {}, permanent: true); // 301 Move Permanently
            //return RedirectToActionPermanent("Books", "Store", new { id = bookId });


            // 302 - Found - LocalRedirectResult
            //return new LocalRedirectResult($"store/books/{bookId}");
            //return LocalRedirect($"store/books/{bookId}");


            // 301 - Move permanent - LocalRedirectResult
            //return new LocalRedirectResult($"store/books/{bookId}", true);
            //return LocalRedirectPermanent($"store/books/{bookId}");


            // 302 - Found - Redirect
            //return new RedirectResult($"store/books/{bookId}");
            //return Redirect($"store/books/{bookId


            // 301 - Move permanent - Redirect
            //return new RedirectResult($"store/books/{bookId}", true);
            return RedirectPermanent($"store/books/{bookId}");

        }
    }
}
