using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartyProduct.Models
{
    public class Invoice
    {
        public int id { get; set; }
        [Required]
        public Party Party { get; set; }
        [Required]
        public Product Product { get; set; }

        [Display(Name = "Rate")]
        public decimal Rate_Of_Product { get; set; }

        public int Quantity { get; set; }

    }
}