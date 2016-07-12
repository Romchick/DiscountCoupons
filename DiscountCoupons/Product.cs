using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountCoupons
{
    public class Product
    {
        public string Name { get; set; }

        public double Price { get; set; }
        public bool HasDiscount { get; set; }

        public Product(string Name, double Price, bool HasDiscount)
        {
            this.Name = Name;
            this.Price = Price;
            this.HasDiscount = HasDiscount;
        }
    }
}
