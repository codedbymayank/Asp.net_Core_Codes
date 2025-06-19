using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Codes.Components
{
    public class TopBooksViewComponent : ViewComponent
    {
        //If u need sync , then this async is not required 
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
