using PerformingValidationsDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UnderstandingBindingTechniquesDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string name, IEnumerable<string> categories)
        {
            string str = Request.Form.ToString();
            str += "<br />Name: " + name + "<br />categories: ";
            foreach (var s in categories)
            {
                str += s + " ";
            }
            return Content(str);
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

        //public ActionResult GetPersonDetails(Person person, HttpPostedFileBase photo)
        //public ActionResult GetPersonDetails([Bind(Exclude="PersonID")]Person person, HttpPostedFileBase photo)
        public ActionResult GetPersonDetails([Bind(Include = "Address,LastName", Exclude = "Photo")]Person person, HttpPostedFileBase photo)
        {
            string str = person.PersonID + ", " + person.FirstName + ", " + person.LastName + "<br />" + person.Address.Country + ", " + person.Address.Street + ", " + person.Address.City;
            if (photo != null)
            {
                string vpath = "~/Content/Photos/" + photo.FileName;
                string ppath = Server.MapPath(vpath);
                photo.SaveAs(ppath);
            }
            return Content(str);
        }

        //[HttpPost]
        //public ActionResult GetAddressDetails([Bind(Prefix = "Present")]AddressSummary b, AddressSummary permanent)
        //{
        //    string str = "";
        //    str = b.Country + ", " + b.Street + ", " + b.City + "<br />";
        //    str += permanent.Country + ", " + permanent.Street + ", " + permanent.City + "<br />";
        //    return Content(str);
        //}

        [HttpPost]
        public ActionResult GetAddressDetails(FormCollection fc)
        {
            AddressSummary present = new AddressSummary();
            AddressSummary permanent = new AddressSummary();
            string str = "";

            UpdateModel(present, "present"); // Will throw exception if validation fails

            bool result = TryUpdateModel(permanent, "permanent"); // Returns false if validation fails

            str += "present: " + present.Country + ", " + present.Street + ", " + present.City + "<br />";

            return Content(str);
        }

        [HttpPost]
        public ActionResult GetCustomerDetails([ModelBinder(typeof(CustomCustomerBinder))]Customer customer)
        {
            string str = "Customer ID: " + customer.CustomerID + "<br />";
            str += "Present: " + customer.PresentAddress.Country + ", " + customer.PresentAddress.City + ", " + customer.PresentAddress.Street + "<br />";
            str += "Permanent: " + customer.PermanentAddress.Country + ", " + customer.PermanentAddress.City + ", " + customer.PermanentAddress.Street + "<br />";
            return Content(Request.Form + "<hr />" + str);
        }
    }
}