using PartyProduct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyProduct.ViewModels
{
    public class BindInvoice
    {
        public IEnumerable<Invoice> invoices { get; set; }

        public Invoice singleInvoice { get; set; }
    }
}