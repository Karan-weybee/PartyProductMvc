using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PartyProduct.Models
{

    public class Party
    {
        public int id { get; set; }

        [Required]
        public string PartyName { get; set; }
    }
}