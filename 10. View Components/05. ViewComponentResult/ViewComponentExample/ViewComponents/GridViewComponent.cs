using Microsoft.AspNetCore.Mvc;
using ViewComponentExample.Models;

namespace ViewComponentsExample.ViewComponents
{
    public class GridViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(PersonGridModel peopleModel)
        {
            ////invoked a partial view Views/Shared/Components/Grid/Sample.cshtml
            //return View("Sample");


            //invoked a partial view Views/Shared/Components/Grid/Default.cshtml
            return View(peopleModel);
        }
    }
}