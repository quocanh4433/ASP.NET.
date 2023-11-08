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

        [Route("file")]
        public VirtualFileResult FileDownload()
        {
            /*return new VirtualFileResult("/sample.pdf", "application/pdf");*/
            return File("/sample.pdf", "application/pdf");
        }


        [Route("file02")]
        public PhysicalFileResult FileDownload2()
        {
           /* return new PhysicalFileResult(@"D:\QA\Image\sample.pdf", "application/pdf");*/
            return PhysicalFile(@"D:\QA\Image\sample.pdf", "application/pdf");
        }



        [Route("file03")]
        public FileContentResult FileDownload3()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"D:\QA\Image\sample.pdf");
            /*return new FileContentResult(bytes, "image/pdf");*/
            return File(bytes, "application/pdf");
        }
    }
}
