using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Codes.Controllers
{
    public class HomeController : Controller
    {
      
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


        public ViewResult Index()
        {
            return View();
        }
        public ViewResult About()
        {
            return View();
        }

        public ViewResult Contact()
        {
            return View();
        }

    }
}
