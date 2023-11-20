using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartyProduct.Models
{
    public class ProductRate
    {
        public int id { get; set; }

        [Required]
        public Product Product { get; set; }

        [Required]
        public Decimal Rate { get; set; }

        [Required]
        public DateTime Date_Of_Rate { get; set; }
    }
}