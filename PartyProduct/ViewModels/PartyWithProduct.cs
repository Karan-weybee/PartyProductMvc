using PartyProduct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyProduct.ViewModels
{
    public class PartyWithProduct
    {
        public IEnumerable<Party> Parties { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}