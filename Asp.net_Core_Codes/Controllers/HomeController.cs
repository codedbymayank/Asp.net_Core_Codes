using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Codes.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Welcome Back";
        }

        public ViewResult Myname()
        {
            return View();
        }
    }
}
