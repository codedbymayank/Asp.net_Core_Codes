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
            return View("Index");
        }

        public ViewResult SomeMethod()
        {
            // for full path and we use .cshtml ex6tension also
            return View("TempView/tempview.cshtml");
            //for relative path
            //return View("../../TempView/tempview");

        }
    }
}
