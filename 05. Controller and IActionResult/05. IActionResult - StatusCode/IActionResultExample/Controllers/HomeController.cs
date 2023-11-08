using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {

        /*
         URL like this:
            http://localhost:3435/book?islogged=true?bookid=1
         */

        [Route("book")]
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

            return PhysicalFile(@"D:\QA\Image\sample.pdf", "application/pdf");
        }
    }
}
