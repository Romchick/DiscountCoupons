using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DiscountCoupons
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
       
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void Button_Product_Add_Click(object sender, RoutedEventArgs e)
        {
            if (nameOfProduct.Text.Equals("") || priceOfProduct.Text.Equals(""))
            {
                MessageBox.Show("Not all fields are filled!");
            }
            else
            {
                Product product = new Product(nameOfProduct.Text, Convert.ToDouble(priceOfProduct.Text));
                WorkWithDatabase work = new WorkWithDatabase();
                work.addProduct(product);
                nameOfProduct.Text = "";
                priceOfProduct.Text = "";
            }
        }

        private void Button_Set_Click(object sender, RoutedEventArgs e)
        {
            if (priceSet.Text.Equals(""))
            {
                MessageBox.Show("The lower price isn`t filled!");
            }
            else
            {
                WorkWithDatabase work = new WorkWithDatabase();
                work.addLowerPriceLimit(Convert.ToDouble(priceSet.Text));
                priceSet.Text = "";
            }
        }

        private void Button_Coupon_Add_Click(object sender, RoutedEventArgs e)
        {
            if (couponNumber.Text.Equals("") || Discount.Text.Equals(""))
            {
                MessageBox.Show("Not all fields are filled!");
            }
            else
            {
                ComboBoxItem typeItem = (ComboBoxItem)comboBox.SelectedItem;

                Coupon coupon = new Coupon(Convert.ToInt32(couponNumber.Text), Convert.ToDouble(Discount.Text), typeItem.Content.ToString());
                WorkWithDatabase work = new WorkWithDatabase();
                work.addCoupon(coupon);
                couponNumber.Text = "";
                Discount.Text = "";

            }
        }

       
        private void priceOfProduct_TextChanged(object sender, TextChangedEventArgs e)
        {
            double res;
            bool isInt = double.TryParse(priceOfProduct.Text, out res);
            if (isInt != true && !priceOfProduct.Text.Equals(""))
            {
                MessageBox.Show("Only positive numbers requried!");
                priceOfProduct.Text = "";
            }
        }

        private void couponNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (couponNumber.Text.Length > 9)
            {
                MessageBox.Show("Too long number!");
            }
                     
            int res;
            bool isInt = int.TryParse(couponNumber.Text, out res);
            if (isInt != true && !couponNumber.Text.Equals(""))
            {
                MessageBox.Show("Only numbers requried!");
                couponNumber.Text = "";
            }
        }
        
        private void Discount_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            double res;
            bool isInt = double.TryParse(Discount.Text, out res);
            if (isInt != true && !Discount.Text.Equals("") || res<0 || res>100)
            {
                MessageBox.Show("Only positive numbers from 0 to 100 requried!");
                Discount.Text = "";
            }
          
        }

        private void priceSet_TextChanged(object sender, TextChangedEventArgs e)
        {
             double res;
             bool isInt = double.TryParse(priceSet.Text, out res);
             if (isInt != true && !priceSet.Text.Equals("") || res < 0 || res > 100)
            {
                MessageBox.Show("Only positive numbers requried!");
                priceSet.Text = "";
            }
        }

    }
}
