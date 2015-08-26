using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DHebert_EYCTest.Models
{
    public class Invoice
    {
        public Invoice(int id, string supplierName)
        {
            this.SupplierId = id;
            this.SupplierName = supplierName;
            this.LineItems = new List<LineItem>();
        }

        public int SupplierId { get; set; }

        [Display(Name = "Supplier Name")]
        public string SupplierName { get; set; }

        public List<LineItem> LineItems { get; set; }
    }
}