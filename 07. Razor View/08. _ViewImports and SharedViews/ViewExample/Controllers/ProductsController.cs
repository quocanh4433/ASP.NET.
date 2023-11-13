using Microsoft.AspNetCore.Mvc;

namespace ViewExample.Controllers
{
    public class ProductsController : Controller
    {
        [Route("products/all")]
        public IActionResult All()
        {
            return View();
        }
    }
}
