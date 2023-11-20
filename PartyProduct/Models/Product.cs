using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartyProduct.Models
{
    public class Product
    {
        public int id { get; set; }

        [Required]
        public string ProductName { get; set; }
    }
}