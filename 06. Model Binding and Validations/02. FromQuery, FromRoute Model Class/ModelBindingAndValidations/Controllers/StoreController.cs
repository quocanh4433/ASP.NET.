using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IActionResultExample.Controllers
{
    [Route("store/books/{id}")]
    public class StoreController : Controller
    {
        public IActionResult Books()
        {
            int bookId = Convert.ToInt32(Request.RouteValues["id"]);
            return Content($"<h1>Bookstore {bookId}</h1>", "text/html");
        }
    }
}
