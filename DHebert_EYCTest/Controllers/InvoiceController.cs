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
        public ActionResult Index()
        {
            var model = new InvoiceSelector();
            model.Suppliers = new FakeData().ReturnSupplierSelectList();
            return View(model);
        }

        public ActionResult Get(int id)
        {
            var model = new FakeData().GetInvoice(id);
            return View(model);
        }
    }
}