using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountCoupons
{
   public class Coupon
    {
       public enum typesOfCoupons
       {
           forAll,
           highestPriced,
           lowestPriced
       }

       public int NumberOfCoupon { get; set; }
       public double Discount { get; set; }
       public string TypeOfCoupon { get; set; }

       public Coupon(int NumberOfCoupon, double Discount, string TypeOfCoupon)
       {
           this.NumberOfCoupon = NumberOfCoupon;
           this.Discount = Discount;
           this.TypeOfCoupon = TypeOfCoupon;
       }

    }
}
