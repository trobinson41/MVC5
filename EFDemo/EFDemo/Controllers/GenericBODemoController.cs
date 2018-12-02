using EFDemo.DAL;
using EFDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFDemo.Controllers
{
    public class GenericBODemoController : Controller
    {
        GenericBO<Employee> obj = new GenericBO<Employee>();
        GenericBO<Department> objDept = new GenericBO<Department>();

        public ActionResult Index()
        {
            var employees = obj.GetAll();
            return View(employees.ToList());
        }

        public ActionResult Details(int id)
        {
            var employee = obj.GetDetails(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        public ActionResult Create()
        {
            ViewBag.DeptID = new SelectList(objDept.GetAll(), "DeptID", "DeptName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    obj.Insert(employee);
                    return RedirectToAction("Index");
                }

                ViewBag.DeptID = new SelectList(objDept.GetAll(), "DeptID", "DeptName");
                return View(employee);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            Employee employee = obj.GetDetails(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            ViewBag.DeptID = new SelectList(objDept.GetAll(), "DeptID", "DeptName");
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    obj.Update(employee);
                    return RedirectToAction("Index");
                }

                ViewBag.DeptID = new SelectList(objDept.GetAll(), "DeptID", "DeptName");
                return View(employee);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            Employee employee = obj.GetDetails(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                obj.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}