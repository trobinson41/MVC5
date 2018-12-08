using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkingWithHandleErrorAttributeDemo.Controllers
{
    [HandleError(ExceptionType = typeof(System.DivideByZeroException), View = "Contact")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            int a, b, c;
            a = 10;
            b = 0;
            c = a / b;
            return Content(c.ToString());
        }

        [CustomHandleError]
        //[HandleError(ExceptionType=typeof(System.DivideByZeroException), View = "Contact")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            int a, b, c;
            a = 10;
            b = 0;
            c = a / b;
            return Content(c.ToString());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}