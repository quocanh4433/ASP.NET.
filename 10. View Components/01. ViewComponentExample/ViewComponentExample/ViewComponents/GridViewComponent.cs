using Microsoft.AspNetCore.Mvc;

namespace ViewComponentsExample.ViewComponents
{
    public class GridViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ////invoked a partial view Views/Shared/Components/Grid/Sample.cshtml
            //return View("Sample");

            //invoked a partial view Views/Shared/Components/Grid/Default.cshtml
            return View();
        }
    }
}