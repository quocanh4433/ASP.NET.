using Microsoft.AspNetCore.Mvc;

namespace ControllerExample.Controller
{
    public class HomeController
    {
        [Route("sayhello")]
        public string method1()
        {
            return "Hello from method 1";
        }
    }
}
