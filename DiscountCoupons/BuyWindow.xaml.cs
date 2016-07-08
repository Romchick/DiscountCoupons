using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
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
    /// Interaction logic for BuyWindow.xaml
    /// </summary>
    public partial class BuyWindow : Window
    {
        double totalPrice;
        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
        public BuyWindow()
        {
            InitializeComponent();
            WorkWithDatabase work = new WorkWithDatabase();
            var dbDataReader = work.selectProducts();
            ArrayList allProducts = new ArrayList();
            while (dbDataReader.Read())
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = dbDataReader["PRODUCT_NAME"].ToString();
                productsCombo.Items.Add(item);
            }
            dbDataReader.Close();
          
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
           
        }
        int amountInTheCart = 0;
        private void Button_AddToCart_Click(object sender, RoutedEventArgs e)
        {
            WorkWithDatabase work = new WorkWithDatabase();
            SQLiteDataReader dbDataReader = work.selectProducts();
            ArrayList allProducts = new ArrayList();
            while (dbDataReader.Read())
            {
                allProducts.Add(new Product(dbDataReader["PRODUCT_NAME"].ToString(), Convert.ToDouble(dbDataReader["PRODUCT_PRICE"])));
            }

            string selectedProduct = productsCombo.Text;
            
            foreach (Product item in allProducts)
            {
                if (selectedProduct.Equals(item.Name))
                {
                    totalPrice += item.Price * Convert.ToInt32(amountToBuy.Text);
                }
            }

            productInfo.Text = "Total price " + totalPrice.ToString();
            amountInTheCart += Convert.ToInt32(amountToBuy.Text);
            productsInTheCart.Text ="Products in the cart: " + amountInTheCart.ToString();
        }

         
    }
}
