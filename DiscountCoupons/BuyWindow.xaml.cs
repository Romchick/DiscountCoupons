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
        int amountInTheCart = 0;
        List<Product> purchasedProducts = new List<Product>();

        //class for workm with ComboBoxes
        public class ComboboxItem
        {
            public string Text { get; set; }

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

        private void Button_AddToCart_Click(object sender, RoutedEventArgs e)
        {
            if (!amountToBuy.Text.Equals(""))
            {
                WorkWithDatabase work = new WorkWithDatabase();
                SQLiteDataReader dbDataReader = work.selectProducts();
                ArrayList allProducts = new ArrayList();
                while (dbDataReader.Read())
                {
                    allProducts.Add(new Product(dbDataReader["PRODUCT_NAME"].ToString(), Convert.ToDouble(dbDataReader["PRODUCT_PRICE"]), false));
                }

                string selectedProduct = productsCombo.Text;


                foreach (Product item in allProducts)
                {
                    int amount = 0;
                    if (selectedProduct.Equals(item.Name))
                    {
                        amount = Convert.ToInt32(amountToBuy.Text);
                        for (int i = 0; i < amount; i++)
                        {

                            purchasedProducts.Add(new Product(item.Name, item.Price, false));

                        }
                        totalPrice += item.Price * amount;


                        purchazedProductsCobmoBox.Items.Clear();
                        foreach (Product prod in purchasedProducts)
                        {
                            ComboboxItem comboItem = new ComboboxItem();
                            comboItem.Text = prod.Name;
                            if (prod.HasDiscount == false)
                            {
                                purchazedProductsCobmoBox.Items.Add(comboItem);
                            }
                        }
                    }


                }
                productInfo.Text = "Total price " + totalPrice.ToString();
                amountInTheCart += Convert.ToInt32(amountToBuy.Text);
                productsInTheCart.Text = "Products in the cart: " + amountInTheCart.ToString();
            }
            else
            {
                MessageBox.Show("Enter Amount");
            }
        }

        private void getDiscount_Click(object sender, RoutedEventArgs e)
        {
            if (!numberOfCoupon.Text.Equals(""))
            {

                if (!purchazedProductsCobmoBox.Text.Equals(""))
                {
                    WorkWithDatabase work = new WorkWithDatabase();
                    double discount = 0;
                    string couponType = "";
                    SQLiteDataReader couponnReader = work.selectCoupon(Convert.ToInt32(numberOfCoupon.Text));
                    if (couponnReader.HasRows)
                    {
                        couponnReader.Read();
                        discount = Convert.ToDouble(couponnReader["COUPON_DISCOUNT"]);
                        couponType = couponnReader["COUPON_TYPE"].ToString();
                        couponnReader.Close();
                    }
                    else
                    {
                        MessageBox.Show("Coupon not found");

                    }
                    SQLiteDataReader lowerPriceLimitReader = work.selectLowerPrice();
                    lowerPriceLimitReader.Read();
                    double lowerPriceLimit = Convert.ToInt32(lowerPriceLimitReader["PRICE_LIMIT"]);
                    lowerPriceLimitReader.Close();

                    SQLiteDataReader productForDiscount = work.selectOneProduct(purchazedProductsCobmoBox.Text);
                    productForDiscount.Read();
                    double discountProductPrice = Convert.ToDouble(productForDiscount["PRODUCT_PRICE"]);
                    int enteredCouponNumber = Convert.ToInt32(numberOfCoupon.Text);
                    productForDiscount.Close();

                    WorkWithCoupons couponsWork = new WorkWithCoupons();
                    string productForDiscountCombo = purchazedProductsCobmoBox.Text;
                    
                    switch (couponType)
                    {
                        case "All Products":
                            {
                                int myInd;
                                double totalPrice1 = couponsWork.getDiscount(purchasedProducts, totalPrice, discountProductPrice, discount, productForDiscountCombo, out myInd);
                                //totalPrice = totalPrice - discountProductPrice * (discount / 100);
                                totalPrice = totalPrice1;
                                productInfo.Text = "Total price " + totalPrice.ToString();
                                /* Product[] prArray = purchasedProducts.ToArray<Product>();
                                 int myIndex = 0;
                                 for (int i = 0; i < prArray.Length; i++)
                                 {
                                     if (prArray[i].Name == purchazedProductsCobmoBox.Text)
                                     {
                                         myIndex = i - 1;
                                     }
                                 }*/
                                int myIndex = myInd;
                                purchasedProducts.RemoveAt(myIndex);
                                purchazedProductsCobmoBox.Items.Clear();
                                foreach (Product prod in purchasedProducts)
                                {
                                    ComboboxItem comboItem = new ComboboxItem();
                                    comboItem.Text = prod.Name;
                                    if (prod.HasDiscount == false)
                                    {
                                        purchazedProductsCobmoBox.Items.Add(comboItem);
                                    }
                                }
                                work.deleteCoupon(Convert.ToInt32(numberOfCoupon.Text));
                                numberOfCoupon.Text = "";
                            }
                            break;
                        case "Lower Price":
                            {
                                if (discountProductPrice <= lowerPriceLimit)
                                {
                                    int myInd;
                                    double totalPrice1 = couponsWork.getDiscount(purchasedProducts, totalPrice, discountProductPrice, discount, productForDiscountCombo, out myInd);
                                    totalPrice = totalPrice1;
                                    productInfo.Text = "Total price " + totalPrice.ToString();

                                    int myIndex = myInd;
                                    purchasedProducts.RemoveAt(myIndex);
                                    purchazedProductsCobmoBox.Items.Clear();
                                    foreach (Product prod in purchasedProducts)
                                    {
                                        ComboboxItem comboItem = new ComboboxItem();
                                        comboItem.Text = prod.Name;
                                        if (prod.HasDiscount == false)
                                        {
                                            purchazedProductsCobmoBox.Items.Add(comboItem);
                                        }
                                    }
                                    work.deleteCoupon(Convert.ToInt32(numberOfCoupon.Text));
                                    numberOfCoupon.Text = "";
                                }
                                else
                                {
                                    MessageBox.Show("Coupon doesn`t fay!");
                                }
                            }


                            break;
                        case "Higher Price":
                            {
                                if (discountProductPrice > lowerPriceLimit)
                                {
                                    int myInd;
                                    double totalPrice1 = couponsWork.getDiscount(purchasedProducts, totalPrice, discountProductPrice, discount, productForDiscountCombo, out myInd);
                                    totalPrice = totalPrice1;
                                    productInfo.Text = "Total price " + totalPrice.ToString();
                                    int myIndex = myInd;
                                    purchasedProducts.RemoveAt(myIndex);
                                    purchazedProductsCobmoBox.Items.Clear();
                                    foreach (Product prod in purchasedProducts)
                                    {
                                        ComboboxItem comboItem = new ComboboxItem();
                                        comboItem.Text = prod.Name;
                                        if (prod.HasDiscount == false)
                                        {
                                            purchazedProductsCobmoBox.Items.Add(comboItem);
                                        }
                                    }
                                    work.deleteCoupon(Convert.ToInt32(numberOfCoupon.Text));
                                    numberOfCoupon.Text = "";
                                }
                                else
                                {
                                    MessageBox.Show("Coupon doesn`t fay!");
                                }
                            }
                            break;
                        default:

                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Select product for discount");
                }
            }
            else
            {
                MessageBox.Show("Coupon not entered!");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (amountInTheCart != 0 || amountInTheCart != 0)
            {
                MessageBox.Show(@"Thank you for purchazing " + "\n" + amountInTheCart
                                    + " products " + "for " + totalPrice);
            }
            else
            {
                MessageBox.Show("You have no products to purchase");
            }
        }
        
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            int res;
            bool isInt = int.TryParse(amountToBuy.Text, out res);
            if (isInt != true && !amountToBuy.Text.Equals(""))
            {
                MessageBox.Show("Only numbers required!");
                amountToBuy.Text = "";
            }
        }

        private void numberOfCoupon_TextChanged(object sender, TextChangedEventArgs e)
        {
            int res;
            bool isInt = int.TryParse(numberOfCoupon.Text, out res);
            if (isInt != true && !numberOfCoupon.Text.Equals(""))
            {
                MessageBox.Show("Only numbers required!");
                numberOfCoupon.Text = "";
            }

        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Close();
        }

    }
}
