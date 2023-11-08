using Microsoft.AspNetCore.Mvc;

namespace ControllerExample.Controller
{
    public class HomeController
    {

        // Multiple action method
        [Route("sayhello")]
        [Route("sayhi")]
        public string method1()
        {
            return "Hello from method 1";
        }


        [Route("/")]
        [Route("home")]
        public string Index()
        {
            return "Hello from Index";
        }

        [Route("about")]
        public string About()
        {
            return "Hello from About";
        }

        [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")]
        
        public string Contact()
        {
            return "Hello from Contact";
        }



    }
}
