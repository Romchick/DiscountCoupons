using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DiscountCoupons
{
   public class WorkWithCoupons
    {
       public double getDiscount(List<Product> purchasedProducts, double totalPrice, double discountProductPrice, double discount, string purchazedProd, out int myIndex)
       {
           totalPrice = totalPrice - discountProductPrice * (discount / 100);
         
           Product[] prArray = purchasedProducts.ToArray<Product>();
            myIndex = 0;
           for (int i = 0; i < prArray.Length; i++)
           {
               if (prArray[i].Name.Equals(purchazedProd))
               {
                   myIndex = i - 1;
               }
           }
           return totalPrice;
       }
    }
}
