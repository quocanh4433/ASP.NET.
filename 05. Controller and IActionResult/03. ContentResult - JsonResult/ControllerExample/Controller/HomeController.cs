using ControllerExample.Model;
using Microsoft.AspNetCore.Mvc;

namespace ControllerExample.Controller
{

    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        [Route("/")]
        [Route("home")]
        public ContentResult Index()
        {
            /* return new ContentResult()
             {
                 Content = "Hello from Index",
                 ContentType = "text/pain"
             };*/

            return Content("Hello from Index", "text/pain");
        }

        [Route("/person")]
        public JsonResult Person()
        {
            Person person = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = "Nam",
                LastName = "Nguyen",
                Age = 20
            };
            /*return new JsonResult(person);*/
            return Json(person);
        }
    }
}
