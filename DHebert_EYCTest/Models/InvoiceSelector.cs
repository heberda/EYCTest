using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DHebert_EYCTest.Models
{
    public class InvoiceSelector
    {
        public string SelectedInvoiceId { get; set; }

        public List<SelectListItem> Suppliers { get; set; }
    }
}