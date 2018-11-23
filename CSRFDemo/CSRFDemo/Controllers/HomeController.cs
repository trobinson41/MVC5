﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSRFDemo.Controllers
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

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CheckLoginCredentials()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckLoginCredentials(FormCollection coll)
        {
            if ((coll["UserName"].ToString().ToLower().Equals("tim")) && (coll["Password"].ToString().Equals("password")))
            {
                return View("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult ScriptInjectionDemo()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public string ScriptInjectionDemo(string txtDescription)
        {
            return Server.HtmlEncode(txtDescription);
        }
    }
}