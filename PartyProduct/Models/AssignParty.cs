using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartyProduct.Models
{
    public class AssignParty
    {
        public int id { get; set; }

        [Required]
        public Party Party { get; set; }

        [Required]
        public Product Product { get; set; }
    }
}