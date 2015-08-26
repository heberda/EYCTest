using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DHebert_EYCTest.Models;
using DHebert_EYCTest.Repository;

namespace DHebert_EYCTest.Controllers
{
    public class InvoiceController : Controller
    {
        //
        // GET: /Invoice/
        public ActionResult Index()
        {
            var model = new InvoiceSelector();
            model.Suppliers = new FakeData().ReturnSupplierSelectList();
            return View(model);
        }

        public ActionResult List()
        {
            var model = new FakeData().ReturnAllInvoices();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = new FakeData().GetInvoice(id);
            return View(model);
        }

        //
        // GET: /Invoice/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Invoice/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Invoice/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Invoice/Edit/5
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

        //
        // GET: /Invoice/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Invoice/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
