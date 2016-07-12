using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountCoupons
{
    class WorkWithDatabase
    {
        private const string connString = "Data Source=CouponDatabase.sqlite;Version=3;";

        public void createNewDatabase()
        {
            if (!(File.Exists("CouponDatabase.sqlite")))
            {
                SQLiteConnection.CreateFile("CouponDatabase.sqlite");

                using (var connection = new SQLiteConnection(connString))
                {
                    connection.Open();
                    string createProductTableQuery = @"CREATE TABLE PRODUCTS (
                                                       PRODUCT_NAME VARCHAR(20), PRODUCT_PRICE REAL)";
                    SQLiteCommand createProductTable = new SQLiteCommand(createProductTableQuery, connection);
                    createProductTable.ExecuteNonQuery();

                    string createCouponTableQuery = @"CREATE TABLE COUPONS ( 
                                                       COUPON_NUMBER INT, COUPON_TYPE VARCHAR(30), COUPON_DISCOUNT REAL)";
                    SQLiteCommand createCouponTable = new SQLiteCommand(createCouponTableQuery, connection);
                    createCouponTable.ExecuteNonQuery();

                    string createLowerPriceLimitTableQuery = @"CREATE TABLE LOWER_PRICE ( 
                                                       PRICE_LIMIT REAL)";
                    SQLiteCommand createLowerPriceLimitTable = new SQLiteCommand(createLowerPriceLimitTableQuery, connection);
                    createLowerPriceLimitTable.ExecuteNonQuery();
                    
                }
            }
        }

        public void addProduct(Product product)
        {
            using (var connection = new SQLiteConnection(connString)){
                connection.Open();
                string addProductQuerry = String.Format(@"INSERT INTO PRODUCTS
                                                        (PRODUCT_NAME, PRODUCT_PRICE) VALUES
                                                        ('{0}', '{1}')", product.Name, product.Price);

                SQLiteCommand addProductCommand = new SQLiteCommand(addProductQuerry, connection);
                addProductCommand.ExecuteNonQuery();
            }
        }

        public void addCoupon(Coupon coupon)
        {
            using (var connection = new SQLiteConnection(connString))
            {
                connection.Open();
                string addCouponQuerry = String.Format(@"INSERT INTO COUPONS
                                                        (COUPON_NUMBER, COUPON_TYPE, COUPON_DISCOUNT) VALUES
                                                        ('{0}', '{1}', '{2}')", coupon.NumberOfCoupon,
                                                         coupon.TypeOfCoupon, coupon.Discount);

                SQLiteCommand addCouponCommand = new SQLiteCommand(addCouponQuerry, connection);
                addCouponCommand.ExecuteNonQuery();
            }
        }

        public void addLowerPriceLimit(double price)
        {
            using (var connection = new SQLiteConnection(connString))
            {
                connection.Open();

                string eraseLowerPriceQuerry = "DELETE FROM LOWER_PRICE";
                SQLiteCommand eraseLowerPriceCommand = new SQLiteCommand(eraseLowerPriceQuerry, connection);
                eraseLowerPriceCommand.ExecuteNonQuery();

                string addLowerPriceQuerry = String.Format(@"INSERT INTO LOWER_PRICE
                                                        (PRICE_LIMIT) VALUES ('{0}')", price);

                SQLiteCommand addLowerPriceCommand = new SQLiteCommand(addLowerPriceQuerry, connection);
                addLowerPriceCommand.ExecuteNonQuery();
            }
        }

        public SQLiteDataReader selectProducts()
        {
            var connection = new SQLiteConnection(connString);
            string selectProductsQuery = "SELECT * FROM PRODUCTS";
            connection.Open();
            SQLiteCommand selectAllProducts = new SQLiteCommand(selectProductsQuery, connection);
            SQLiteDataReader allProductsReader = selectAllProducts.ExecuteReader();
            return allProductsReader;
        }

        public SQLiteDataReader selectCoupon(int couponNumber)
        {
            var connection = new SQLiteConnection(connString);
            string selectCouponQuery = String.Format(@"SELECT * FROM COUPONS 
                                                        WHERE COUPON_NUMBER = '{0}' ", couponNumber);
            connection.Open();
            SQLiteCommand selectOneCoupon = new SQLiteCommand(selectCouponQuery, connection);
            SQLiteDataReader selectedCouponReader = selectOneCoupon.ExecuteReader();

            return selectedCouponReader;
          
        }

        public void deleteCoupon(int couponNumber)
        {
            var connection = new SQLiteConnection(connString);
            string deleteCouponQuery = String.Format(@"DELETE FROM COUPONS 
                                                        WHERE COUPON_NUMBER = {0};", couponNumber);
            connection.Open();
            SQLiteCommand deleteOneCoupon = new SQLiteCommand(deleteCouponQuery, connection);
            deleteOneCoupon.ExecuteNonQuery();

        }

        public SQLiteDataReader selectLowerPrice()
        {
            var connection = new SQLiteConnection(connString);
            string selectLowerPriceQuery = "SELECT * FROM LOWER_PRICE";
            connection.Open();
            SQLiteCommand selectPrice = new SQLiteCommand(selectLowerPriceQuery, connection);
            SQLiteDataReader selectedLowerPrice = selectPrice.ExecuteReader();
            return selectedLowerPrice;
        }

        public SQLiteDataReader selectOneProduct(string selectedProduct)
        {
            var connection = new SQLiteConnection(connString);
            string selectOneProductQuery = String.Format(@"SELECT * FROM PRODUCTS 
                                                        WHERE PRODUCT_NAME = '{0}'", selectedProduct);
            connection.Open();
            SQLiteCommand selectOneProductCommand = new SQLiteCommand(selectOneProductQuery, connection);
            SQLiteDataReader selectOneProductReader = selectOneProductCommand.ExecuteReader();
            return selectOneProductReader;
        }
    }
}
