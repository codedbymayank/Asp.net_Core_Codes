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

        //This is for viewdata attribute , After using viewdata over a property then this property will treated as a viewdata attribute 
        [ViewData]
        public string prop1 { get; set; }
        [ViewData]
        public string Title { get; set; }
        public ViewResult Index()
        {
            prop1 = "Welcome To BookNest";
            Title = "BookNest App";
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
