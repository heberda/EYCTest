using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DHebert_EYCTest.Models;

namespace DHebert_EYCTest.Repository
{
    public class FakeData
    {
        public Invoice GetInvoice(int id)
        {
            return Invoices.Where(x => x.SupplierId == id).First();
        }

        public List<SelectListItem> ReturnSupplierSelectList()
        {
            return Invoices.Select(x => new SelectListItem { Value = x.SupplierId.ToString(), Text = x.SupplierName }).ToList();
        }

        public List<Invoice> ReturnAllInvoices()
        {
            return Invoices;
        }

        public List<Invoice> Invoices
        {
            get
            {
                var egg = new Product(
                    "Egg",
                    Category.Fresh,
                    1.25,
                    Country.Ireland);

                var chicken = new Product(
                    "Chicken",
                    Category.Fresh,
                    2.20,
                    Country.Spain);

                var milk = new Product(
                    "Milk",
                    Category.Processed,
                    0.79,
                    Country.UK);

                var softDrink = new Product(
                    "Soft Drink",
                    Category.Processed,
                    1.00,
                    Country.UK);

                var juice = new Product(
                    "Juice",
                    Category.Fresh,
                    2.00,
                    Country.Spain);

                var supplier1Invoice = new Invoice(1, "Supplier 1");
                supplier1Invoice.LineItems.Add(new LineItem(egg, 2000));
                supplier1Invoice.LineItems.Add(new LineItem(chicken, 7000));
                supplier1Invoice.LineItems.Add(new LineItem(milk, 9000));

                var supplier2Invoice = new Invoice(2, "Supplier 2");
                supplier2Invoice.LineItems.Add(new LineItem(softDrink, 3000));
                supplier2Invoice.LineItems.Add(new LineItem(juice, 50000));

                var bigSupplier = new Invoice(3, "The big Supply Company Ltd");
                bigSupplier.LineItems.Add(new LineItem(softDrink, 3000));
                bigSupplier.LineItems.Add(new LineItem(chicken, 500));
                bigSupplier.LineItems.Add(new LineItem(milk, 9000000));
                
                return new List<Invoice>
                {
                    supplier1Invoice,
                    supplier2Invoice,
                    bigSupplier
                };
            }
        }
    }
}