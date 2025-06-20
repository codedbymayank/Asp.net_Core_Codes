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

        //This is attribute routing , After running aplication just directly type about-us and about method will return view 
        //With the help of this order value , u can main order of routes
        [Route("about-us", Order =1)]
        //[Route("about-us/{id?}")]  --> same as we do in convetional routing and for this not required to write parameter name in query string , but if required parameters in a method then dont write in this pattern and use parameter name also in query string
        // when parameters are written in a method and are not using in program.cs or like above then in query string write & between partameters
        // Like this only  [Route("about-us")]
        public ViewResult About()
        {
            return View();
        }

        //Like in request there are two things verb and url 
        // So here is a verb
        [HttpPost]
        public ViewResult Contact()
        {
            return View();
        }

        //This is when we are using MapController() only
        [Route("")]

        //Let suppose u have changed name of controller and action method in future then how to resolve this prob
        [Route("[controller]/[action]")]
        //Automatically controller and action name will get replace and If above line we will write on controller level , then it will work automatically for all action method of this controller
        //If we use tilt then we can override this values from which aw are using on controller level
        [Route("~/Somecontroller/methodname",Name ="something")]
        public ViewResult MapControllerMethod()
        {
            return View();
        }
    }
}
