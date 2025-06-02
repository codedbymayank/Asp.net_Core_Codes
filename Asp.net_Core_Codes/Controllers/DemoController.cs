using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Codes.Controllers
{
    /*
     Controller :- this is present inside asp.netcore.mvc
     */
    public class DemoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
