using EFDemo.DAL;
using EFDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFDemo.Controllers
{
    public class EmployeeDALController : Controller
    {
        EmployeeDAL objEmpBO = new EmployeeDAL();
        DepartmentDAL objDeptBO = new DepartmentDAL();

        // GET: EmployeeDAL
        public ActionResult Index()
        {
            return View();
        }

        // GET: EmployeeDAL/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeDAL/Create
        public ActionResult Create()
        {
            ViewBag.DeptID = new SelectList(objDeptBO.GetAllDepartments(), "DeptID", "DeptName");
            return View();
        }

        // POST: EmployeeDAL/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    objEmpBO.Insert(employee);
                    return RedirectToAction("Index");
                }
                ViewBag.DeptID = new SelectList(objDeptBO.GetAllDepartments(), "DeptID", "DeptName");
                return View(employee);
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeDAL/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeDAL/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeDAL/Delete/5
        public ActionResult Delete(int id)
        {
            Employee employee = objEmpBO.GetDetails(id);
            if(employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: EmployeeDAL/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                objEmpBO.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
