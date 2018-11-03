﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkingWithFormsDemo.Controllers
{
    public class FormsDemoController : Controller
    {
        // GET: FormsDemo
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string txtProductName, string txtCost, string txtQty)
        {
            string ProductName = txtProductName;
            int Cost = Convert.ToInt32(txtCost);
            int Quantity = Convert.ToInt32(txtQty);

            double BillAmount = Cost * Quantity;
            double Discount = BillAmount * 10 / 100;
            double NetBillAmount = BillAmount - Discount;

            ViewBag.BillAmount = BillAmount;
            ViewBag.Discount = Discount;
            ViewBag.NetBillAmount = NetBillAmount;

            return View();
        }

        //[HttpPost]
        //public ActionResult Index(FormCollection collection)
        //{
        //    string ProductName = collection["txtProductName"];
        //    int Cost = Convert.ToInt32(collection["txtCost"]);
        //    int Quantity = Convert.ToInt32(collection["txtQty"]);

        //    double BillAmount = Cost * Quantity;
        //    double Discount = BillAmount * 10 / 100;
        //    double NetBillAmount = BillAmount - Discount;

        //    ViewBag.BillAmount = BillAmount;
        //    ViewBag.Discount = Discount;
        //    ViewBag.NetBillAmount = NetBillAmount;

        //    return View();
        //}

        [HttpPost]
        public ActionResult Calculate()
        {
            string ProductName = Request.Form["txtProductName"];
            int Cost = Convert.ToInt32(Request.Form["txtCost"].ToString());
            int Quantity = Convert.ToInt32(Request.Form["txtQty"].ToString());

            double BillAmount = Cost * Quantity;
            double Discount = BillAmount * 10 / 100;
            double NetBillAmount = BillAmount - Discount;

            ViewBag.BillAmount = BillAmount;
            ViewBag.Discount = Discount;
            ViewBag.NetBillAmount = NetBillAmount;

            return View("Index");
        }
    }
}