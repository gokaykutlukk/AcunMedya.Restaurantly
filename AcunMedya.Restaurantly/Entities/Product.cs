using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcunMedya.Restaurantly.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal price { get; set; }
        public string imageUrl { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}