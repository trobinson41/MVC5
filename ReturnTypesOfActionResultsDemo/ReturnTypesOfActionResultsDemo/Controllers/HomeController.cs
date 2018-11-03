﻿using ReturnTypesOfActionResultsDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReturnTypesOfActionResultsDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(string Message="Your Contact Page")
        {
            ViewBag.Message = Message;

            return View();
        }

        public ContentResult GreetUser()
        {
            return Content("Hello World From MVC 5.0");
        }

        public ViewResult WishUser()
        {
            return View();
        }

        public RedirectResult GotoURL()
        {
            return Redirect("http://www.google.com");
        }

        public RedirectResult GotoURLPermanently()
        {
            return RedirectPermanent("http://www.google.com");
        }

        public RedirectToRouteResult GotoContactsAction()
        {
            return RedirectToAction("Contact", new { Message = "Hey! I am coming from a different action..." });
        }

        public RedirectToRouteResult GotoAbout()
        {
            return RedirectToRoute("AboutUs");
        }

        public FileResult ShowMeSiteCSSFileContent()
        {
            return File(Server.MapPath("~/Content/Site.css"), "text/css");
        }

        public JsonResult ShowNewProduct()
        {
            Products prod = new Products()
            {
                ProductCode = 101,
                ProductName = "Printer",
                Cost = 1500
            };

            return Json(prod, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult ShowChildViewContent()
        {
            return PartialView();
        }
    }
}