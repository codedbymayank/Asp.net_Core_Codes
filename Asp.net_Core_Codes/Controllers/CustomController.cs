using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Codes.Controllers
{
    public class CustomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public string M1()
        {
            return "Method M1";
        }

        //Passing parameters in action method
        public string getname(string name)
        {
            return ("My name is " + name);
        }
    }
}
