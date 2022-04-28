using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace WebShopMKJ
{

    public class Databasedapper
    {
        /// <summary>
        /// The connection string
        /// </summary>
        static string connString = "Server=tcp:newtonely1.database.windows.net,1433;Initial Catalog=WebshopDB;Persist Security Info=False;User ID=admin123;Password=Admin_123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        /// <summary>
        /// Shows all categories.
        /// </summary>
        /// <returns> a list of the class Category</returns>
        public static List<Models.Category> ShowAllCategories()
        {
            string sql = "SELECT * FROM categories";
            var categories = new List<Models.Category>();

            using (var connectin = new SqlConnection(connString))
            {
                categories = connectin.Query<Models.Category>(sql).ToList();
            }

            return categories;
        }

        /// <summary>
        /// Shows all carts.
        /// </summary>
        /// <returns>a list of the class Cart</returns>
        public static List<Models.Cart> ShowAllCart()
        {
            string sql = "SELECT * FROM Cart";
            var cart = new List<Models.Cart>();

            using (var connectin = new SqlConnection(connString))
            {
                cart = connectin.Query<Models.Cart>(sql).ToList();
            }

            return cart;
        }

        /// <summary>
        /// Shows the specific cart.
        /// </summary>
        /// <returns></returns>
        public static List<Models.Cart> ShowSpecificCart()
        {
            string sql = $"SELECT * FROM Cart where [CustomerID] = {Menu.MenuModel.CustomerID}";
            var cart = new List<Models.Cart>();

            using (var connectin = new SqlConnection(connString))
            {
                cart = connectin.Query<Models.Cart>(sql).ToList();
            }

            return cart;
        }

        public static void DeleteFromCurrentCart(int productID, int? customerID)
        {
            string sql = $"DELETE from dbo.Cart where [ProductID] = {productID} and [CustomerID] = {customerID}";

            using (var connection = new SqlConnection(connString))
            {
                try
                {
                    connection.Open();
                    var command = new SqlCommand(sql, connection);
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }

        public static void UpdateQuantityFromCurrentCart(int amount, int productID, int? customerID)
        {
            string sql = $"UPDATE dbo.Cart SET [Quantity] = {amount} where [ProductID] = {productID} and [CustomerID] = {customerID}";

            using (var connection = new SqlConnection(connString))
            {
                try
                {
                    connection.Open();
                    var command = new SqlCommand(sql, connection);
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }

        /// <summary>
        /// Shows all customers.
        /// </summary>
        /// <returns>a list of the class Customer</returns>
        public static List<Models.Customer> ShowAllCustomers()
        {
            string sql = "SELECT * FROM Customers";
            var customers = new List<Models.Customer>();

            using (var connectin = new SqlConnection(connString))
            {
                customers = connectin.Query<Models.Customer>(sql).ToList();
            }

            return customers;
        }

        /// <summary>
        /// Shows all shippers.
        /// </summary>
        /// <returns>a list of the class Shipper</returns>
        public static List<Models.Shipper> ShowAllShippers()
        {
            string sql = "SELECT * FROM Shippers";
            var shippers = new List<Models.Shipper>();

            using (var connection = new SqlConnection(connString))
            {
                shippers = connection.Query<Models.Shipper>(sql).ToList();
            }

            return shippers;
        }

        /// <summary>
        /// Shows all products.
        /// </summary>
        /// <returns>a list of the class product</returns>
        public static List<Models.Product> ShowAllProducts()
        {
            string sql = "SELECT * FROM Products";
            var products = new List<Models.Product>();

            using (var connectin = new SqlConnection(connString))
            {
                products = connectin.Query<Models.Product>(sql).ToList();
            }

            return products;
        }

        /// <summary>
        /// Shows specific category products.
        /// </summary>
        /// <returns>a list of the class product</returns>
        public static List<Models.Product> ShowSpecificCategorieProducts(int num)
        {
            string sql = $"SELECT * FROM Products WHERE CategoryID = {num}";
            var products = new List<Models.Product>();

            using (var connectin = new SqlConnection(connString))
            {
                products = connectin.Query<Models.Product>(sql).ToList();
            }

            return products;
        }

        /// <summary>
        /// Shows the specific product.
        /// </summary>
        /// <param name="num">The number.</param>
        /// <returns>a proudct</returns>
        public static List<Models.Product> ShowSpecificProduct(int num)
        {
            string sql = $"SELECT * FROM Products WHERE ID = {num}";
            var product = new List<Models.Product>();

            using (var connectin = new SqlConnection(connString))
            {
                product = connectin.Query<Models.Product>(sql).ToList();
            }

            return product;
        }

        /// <summary>
        /// Shows all inventory from the database
        /// </summary>
        /// <returns>a list of the class Inventory</returns>
        public static List<Models.Inventory> ShowAllInventory()
        {
            string sql = "SELECT * FROM Inventory";
            var inventory = new List<Models.Inventory>();

            using (var connectin = new SqlConnection(connString))
            {
                inventory = connectin.Query<Models.Inventory>(sql).ToList();
            }

            return inventory;
        }

        /// <summary>
        /// Shows all order details from the database
        /// </summary>
        /// <returns>a list of the class OrderDetail</returns>
        public static List<Models.OrderDetail> ShowAllOrderDetail()
        {
            string sql = "SELECT * FROM OrderDetails";
            var orderDetails = new List<Models.OrderDetail>();

            using (var connectin = new SqlConnection(connString))
            {
                orderDetails = connectin.Query<Models.OrderDetail>(sql).ToList();
            }

            return orderDetails;
        }

        /// <summary>
        /// Shows all orders from the database
        /// </summary>
        /// <returns>a list of the class Order</returns>
        public static List<Models.Order> ShowAllOrders()
        {
            string sql = "SELECT * FROM Orders";
            var order = new List<Models.Order>();

            using (var connectin = new SqlConnection(connString))
            {
                order= connectin.Query<Models.Order>(sql).ToList();
            }

            return order;
        }

        /// <summary>
        /// Shows the cart with customers and products.
        /// </summary>
        /// <returns></returns>
        public static List<Models.CustomerCartWithProducts> ShowCartWithProducts()
        {
            var sql = $@"SELECT 
                         Customers.[Name] as 'CustomerName', 
                         Cart.Quantity as 'Quantity', 
                         Products.[Name] as 'ProductName'
                         FROM Cart 
                         JOIN Products ON Products.Id = Cart.ProductID 
                         JOIN Customers ON Customers.ID = Cart.CustomerID";

            var customersWithProducts = new List<Models.CustomerCartWithProducts>();

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    customersWithProducts = connection.Query<Models.CustomerCartWithProducts>(sql).ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return customersWithProducts;
        }

        /// <summary>
        /// Shows the customers products and date.
        /// </summary>
        /// <returns></returns>
        public static List<Models.CustomersProductsAndDates> ShowCustomersProductsAndDate()
        {
            var sql = $@"SELECT Customers.[Name] as 'CustomerName', 
                         Products.[Name] as 'ProductName', 
                         Orderdetails.Quantity as 'Quantity',
                         Orders.[OrderDate] as 'OrderDate'
                         FROM Customers
                         JOIN Orders
                         ON Orders.CustomerID = Customers.ID
                         JOIN Orderdetails
                         ON Orderdetails.OrderID = Orders.Id
                         JOIN Products
                         ON Orderdetails.ProductID = Products.Id";

            var customersWithProducts = new List<Models.CustomersProductsAndDates>();

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    customersWithProducts = connection.Query<Models.CustomersProductsAndDates>(sql).ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return customersWithProducts;
        }

        /// <summary>
        /// Shows the product which have the highest amount of product in inventory.
        /// </summary>
        /// <returns></returns>

        public static List<Models.TopProducts> ShowProductWithMostInventory()
        {
            var sql = $"SELECT [Name], Stock as 'Quantity' FROM Inventory JOIN Products ON Products.ID = Inventory.ProductID WHERE Stock = (select max(stock) from inventory)";

            var mostPopularProduct = new List<Models.TopProducts>();

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    mostPopularProduct = connection.Query<Models.TopProducts>(sql).ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return mostPopularProduct;
        }

        /// <summary>
        /// Shows the product with least inventory.
        /// </summary>
        /// <returns></returns>
        public static List<Models.TopProducts> ShowProductWithLeastInventory()
        {
            var sql = $"SELECT [Name], Stock as 'Quantity' FROM Inventory JOIN Products ON Products.ID = Inventory.ProductID WHERE Stock = (SELECT MIN(stock) from Inventory)";

            var mostPopularProduct = new List<Models.TopProducts>();

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    mostPopularProduct = connection.Query<Models.TopProducts>(sql).ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return mostPopularProduct;
        }

        /// <summary>
        /// Shows all products with stock value.
        /// </summary>
        /// <returns></returns>
        public static List<Models.TopProducts> ShowAllProductsWithStockValue()
        {
            var sql = "SELECT [Name], Stock as 'Quantity' FROM Inventory JOIN Products ON Products.ID = Inventory.ProductID";

            var mostPopularProduct = new List<Models.TopProducts>();

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    mostPopularProduct = connection.Query<Models.TopProducts>(sql).ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return mostPopularProduct;
        }

        /// <summary>
        /// Adds to cart table in database.
        /// </summary>
        /// <param name="newItem">The new item.</param>
        /// <returns>int of amount of rows affected in database</returns>
        public static int AddToCart(Models.Cart newItem)
        {
            using (var database = new Models.WebShopContext())
            {
                var cartList = database.Carts;

                cartList.Add(newItem);

                int savedChanges = database.SaveChanges();

                return savedChanges;
            }
        }

        /// <summary>
        /// Adds to orders.
        /// </summary>
        /// <param name="newOrder">The new order.</param>
        /// <returns></returns>
        public static int AddToOrders(Models.Order newOrder)
        {
            using (var database = new Models.WebShopContext())
            {

                var orderList = database.Orders;

                orderList.Add(newOrder);

                int savedChanges = database.SaveChanges();

                return savedChanges;
            }

        }

        /// <summary>
        /// Adds to order details.
        /// </summary>
        /// <param name="newOrderDetail">The new order detail.</param>
        /// <returns></returns>
        public static int AddToOrderDetails(Models.OrderDetail newOrderDetail)
        {
            using (var database = new Models.WebShopContext())
            {
                var orderDetailList = database.OrderDetails;

                orderDetailList.Add(newOrderDetail);

                int savedChanges = database.SaveChanges();

                return savedChanges;
            }
        }

        /// <summary>
        /// Updates stock in the Inventory database. This method is called in UpdateInventory
        /// </summary>
        /// <param name="newInventory">The new inventory.</param>
        /// <returns></returns>
        public static void UpdateInventory(Models.Inventory newInventory)
        {
            var sql = @$"UPDATE Inventory SET [Stock] = {newInventory.Stock} where ProductID = {newInventory.ProductId}";
             

            using (var connection = new SqlConnection(connString))
            {
                try
                {
                    connection.Open();
                    var command = new SqlCommand(sql, connection);
                    command.ExecuteNonQuery();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        /// Updates the stock quantity, also saves the changes to the database.
        /// </summary>
        /// <param name="currentCart">The current cart.</param>
        public static void UpdateStockQuantity(List<Models.Cart> currentCart)
        {
            var listOfQuantity = Databasedapper.ShowAllInventory();

            foreach (var item in listOfQuantity)
            {
                foreach (var cart in currentCart)
                {
                    if (item.ProductId == cart.ProductId)
                        item.Stock -= cart.Quantity;
                }
            }
            foreach (var inventory in listOfQuantity)
                UpdateInventory(inventory);
        }

        /// <summary>
        /// Clears customer specific cart. This method is called in the Checkout method.
        /// </summary>
        public static void ClearCart()
        {
            var sql = @$"DELETE FROM Cart where [CustomerID] = {Menu.MenuModel.CustomerID}";

            using(var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }

        /// <summary>
        /// adds a new product to your store
        /// </summary>
        /// <param name="newProduct"></param>
        /// <returns></returns>
        public static int ProductAddToDatabase(Models.Product newProduct)
        {
            
            int affectedRows = 0;

            var sql = $"INSERT INTO dbo.Products([Name], [categoryId], [Description], [Price]) VALUES('{newProduct.Name}', {newProduct.CategoryId}, '{newProduct.Description}',{newProduct.Price})";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return affectedRows;
        }

        //INSERT INTO dbo.Inventory (Stock, Discontinued)VALUES({userEntry}, 0)
        /// <summary>
        /// Add a stock value to a product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="userEntry">The user entry.</param>
        /// <returns></returns>
        public static int ProductAddStockValue(int productId, int stockAmount)
        {
            int affectedRows = 0;

            var sql = $"INSERT INTO dbo.Inventory (ProductId, Stock, Discontinued)VALUES({productId}, {stockAmount}, 0)";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return affectedRows;
        }
        /// <summary>
        /// Adds a Customers to the database.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns>int, amount off changed rows</returns>
        public static int CustomerAddToDatabase(Models.Customer customer)
        {
            int affectedRows = 0;

            var sql = $"INSERT INTO dbo.Customers ([Name], [Email]) VALUES('{customer.Name}', '{customer.Email}')";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return affectedRows;
        }

        /// <summary>
        /// Remove a product from the database.
        /// </summary>
        /// <param name="ProductId">The identifier.</param>
        /// <returns></returns>
        public static int ProductRemoveFromInventoryDatabase(int ProductId)
        {

            int affectedRows = 0;

            var sql = $"DELETE FROM dbo.Inventory WHERE productId = {ProductId}";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return affectedRows;
        }

        /// <summary>
        /// Remove product from database.
        /// </summary>
        /// <param name="ProductId">The product identifier.</param>
        /// <returns></returns>
        public static int ProductRemoveFromDatabase(int ProductId)
        {

            int affectedRows = 0;

            var sql = $"DELETE FROM dbo.Products WHERE Products.Id = {ProductId}";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return affectedRows;
        }

        /// <summary>
        /// Products the remove order detail from database.
        /// </summary>
        /// <param name="ProductId">The product identifier.</param>
        /// <returns></returns>
        public static int ProductRemoveOrderDetailFromDatabase(int ProductId)
        {

            int affectedRows = 0;

            var sql = $"DELETE FROM dbo.OrderDetails WHERE OrderDetails.ProductId = {ProductId}";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return affectedRows;
        }

        /// <summary>
        /// Changes the description of the product.
        /// </summary>
        /// <param name="infoText">The information text.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public static int ProductChangeDescription(string infoText, int Id)
        {
            int affectedRows = 0;

            var sql = $"UPDATE dbo.Products SET[Description] = '{infoText}' WHERE id = {Id}"; ;

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return affectedRows;
        }

        /// <summary>
        /// Changes the categoryId of the product.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        public static int ProductChangeCategoryId(int categoryId, int productId)
        {
            int affectedRows = 0;

            var sql = $"UPDATE Products SET CategoryID = {categoryId} WHERE Products.Id = {productId}";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return affectedRows;
        }

        /// <summary>
        /// Changes the name of the product.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public static int ProductChangeName(string name, int Id)
        {
            int affectedRows = 0;

            var sql = $"UPDATE dbo.Products SET [Name] = '{name}' WHERE id = {Id}"; ;

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return affectedRows;
        }

        /// <summary>
        /// Products the change price.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public static int ProductChangePrice(float price, int Id)
        {
            int affectedRows = 0;

            var sql = $"UPDATE dbo.Products SET Price = '{price}' WHERE id = {Id}"; ;

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return affectedRows;
        }

        /// <summary>
        /// Categories the remove from database.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns></returns>
        public static int CategoryRemoveFromDatabase(int categoryId)
        {

            int affectedRows = 0;

            var sql = $"DELETE FROM dbo.Products WHERE CategoryID = {categoryId} DELETE FROM dbo.Categories WHERE ID = {categoryId}";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return affectedRows;
        }

        /// <summary>
        /// Adds a new category to the database.
        /// </summary>
        /// <param name="newProduct">The new product.</param>
        /// <returns></returns>
        public static int CategoryAddToDatabase(Models.Category newCategory)
        {
            int affectedRows = 0;

            var sql = $"INSERT INTO dbo.Categories ([Name]) VALUES('{newCategory.Name}')";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return affectedRows;
        }

        /// <summary>
        /// Changes the name of the category.
        /// </summary>
        /// <param name="selectedName">Name of the selected.</param>
        /// <param name="selectedCategory">The selected category.</param>
        /// <returns></returns>
        public static int CategoryChangeName(string selectedName, int selectedCategory)
        {   

            int affectedRows = 0;

            var sql = $"  UPDATE dbo.Categories SET[Name] = '{selectedName}' WHERE [ID] = {selectedCategory}";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return affectedRows;
        }

        /// <summary>
        /// Change the categoryID of a category.
        /// </summary>
        /// <param name="newCategoryId">The new category identifier.</param>
        /// <param name="selectedCategory">The selected category.</param>
        /// <returns></returns>
        public static int CategoryChangeCategoryId(int newCategoryId, int selectedCategory)
        {
            int affectedRows = 0;

            var sql = $"UPDATE dbo.Categories SET [CategoryID] = '{newCategoryId}' WHERE id = {selectedCategory}"; ;

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return affectedRows;
        }

        /// <summary>
        /// Remove a supplier from the database .
        /// </summary>
        /// <param name="supplierId">The supplier identifier.</param>
        /// <returns></returns>
        public static int ShipperRemoveFromDatabase(int supplierId)
        {

            int affectedRows = 0;

            var sql = $"DELETE FROM dbo.Shippers WHERE [ID] = '{supplierId}'";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return affectedRows;
        }
        
        /// <summary>
        /// Add a shipper to the database
        /// </summary>
        /// <param name="newShipper">The new shipper.</param>
        /// <returns></returns>
        public static int ShipperAddToDatabase(Models.Shipper newShipper)
        {

            int affectedRows = 0;

            var sql = $"INSERT INTO dbo.Shippers ([Name], [Price]) VALUES('{newShipper.Name}', {newShipper.Price})";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return affectedRows;
        }

        /// <summary>
        /// Change price of the shipper.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <param name="shipperId">The shipper identifier.</param>
        /// <returns></returns>
        public static int ShipperChangePrice(int price, int shipperId)
        {
            int affectedRows = 0;

            var sql = $"UPDATE dbo.Shippers SET Price = '{price}' WHERE Id = {shipperId}"; ;

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return affectedRows;
        }

        /// <summary>
        /// Removes a customer from the database.
        /// </summary>
        /// <param name="customerId">The identifier.</param>
        /// <returns></returns>
        public static int CustomerRemoveFromDatabase(int customerId)
        {

            int affectedRows = 0;

            var sql = $"DELETE FROM dbo.Customers WHERE ID = {customerId}";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return affectedRows;
        }

        /// <summary>
        /// Removes orders from customer
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        public static int CustomerRemoveOrder(int customerId)
        {
            int affectedRows = 0;

            var sql = $"DELETE FROM dbo.Orders WHERE CustomerId = {customerId}";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return affectedRows;
        }
        /// <summary>
        /// Saves customer orders to remove it later
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        public static List<int> CustomerSaveFromOrders(int customerId)
        {
            var sql = $"SELECT Id FROM Orders WHERE CustomerID = {customerId}";
            var idList = new List<int>();

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    idList = connection.Query<int>(sql).ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return idList;
        }

        /// <summary>
        /// Removes customer orderId
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        public static void CustomerRemoveOrderId(int customerId)
        {
            var sql = $"DELETE FROM OrderDetails WHERE Orderdetails.OrderId = {customerId}";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    connection.Query<int>(sql).ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        /// Removes Cart from customer so we can delete a customer from the database.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        public static int CustomerRemoveCartFromDatabase(int customerId)
        {
            int affectedRows = 0;

            var sql = $"DELETE FROM dbo.Cart WHERE customerID = {customerId}";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return affectedRows;
        }

        /// <summary>
        /// Continues a product in your inventory.
        /// </summary>
        /// <param name="Id">The product identifier.</param>
        /// <param name="inventoryContinue">if set to <c>true</c> [inventory continue].</param>
        /// <returns></returns>
        public static int InventoryContinueProduct(int Id)
        {
            int affectedRows = 0;

            var sql = $"UPDATE dbo.Inventory SET Discontinued = 0 WHERE Id = {Id}";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return affectedRows;
        }

        /// <summary>
        /// Discontinues a product in inventory.
        /// </summary>
        /// <param name="Id">The product identifier.</param>
        /// <param name="inventoryDiscontinue">if set to <c>true</c> [inventory discontinue].</param>
        /// <returns></returns>
        public static int InventoryDiscontinueProduct(int Id)
        {
            int affectedRows = 0;

            var sql = $"UPDATE dbo.Inventory SET Discontinued = 1 WHERE Id = {Id}";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return affectedRows;
        }

        /// <summary>
        /// Changes inventory stock value.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="StockValue">The stock value.</param>
        /// <returns></returns>
        public static int InventoryStockChange(int Id, int StockValue)
        {
            int affectedRows = 0;

            var sql = $"UPDATE dbo.Inventory SET Stock = {StockValue} WHERE Id = {Id}";

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return affectedRows;
        }
        /// <summary>
        /// Fetch most stocked categories
        /// </summary>
        /// <param name="stockedCategory">The stocked category.</param>
        /// <returns></returns>

        public static List<Models.ProductsCategoriesInventory> InventorySeeInventoryStocksAndProducts()
        {
            string sql = @"SELECT Products.[Name] as 'ProductName', Categories.[Name] as 'CategoryName', Inventory.Stock as 'Stock', Inventory.Discontinued as 'SoldOrNOt' FROM Products
                           JOIN Inventory
                           ON Inventory.ProductID = Products.ID
                           JOIN Categories
                           ON Categories.Id = Products.CategoryID";

            var inventory = new List<Models.ProductsCategoriesInventory>();

            using (var connectin = new SqlConnection(connString))
            {
                inventory = connectin.Query<Models.ProductsCategoriesInventory>(sql).ToList();
            }

            return inventory;
        }

        public static bool MostStockedCategories(out List<Models.MostStockedCategory> stockedCategory)
        {
            var sql = $@"select distinct dbo.Categories.Name, sum(distinct dbo.Inventory.Stock) as 'Stock'
                         from dbo.Categories
                         join dbo.Products
                         on dbo.Categories.ID = dbo.Products.CategoryID
                         join dbo.Inventory
                         on dbo.Inventory.ProductID = dbo.Products.ID
                         group by dbo.Categories.Name
                         order by Stock desc";

            using (var connection = new SqlConnection(connString))
            {
                stockedCategory = connection.Query<Models.MostStockedCategory>(sql).ToList();
            }

            if (stockedCategory.Count >= 1)
                return true;

            return false;
        }
        /// <summary>
        /// Fetches the most popular category
        /// </summary>
        /// <param name="popularCategory">The popular category.</param>
        /// <returns></returns>
        public static bool CategoryPopularity(out List<Models.MostPopularCategory> popularCategory)
        {
            var sql = $@"select Categories.Name, count(Products.CategoryID) as 'Popularity'
                         from Categories
                         join Products
                         on Categories.ID = Products.CategoryID
                         group by Categories.Name
                         order by Popularity desc";

            using (var connection = new SqlConnection(connString))
            {
                popularCategory = connection.Query<Models.MostPopularCategory>(sql).ToList();
            }

            if (popularCategory.Count >= 1)
                return true;

            return false;
        }
        /// <summary>
        /// Fetches the most popular shippers
        /// </summary>
        /// <param name="shipperPopularity">The shipper popularity.</param>
        /// <returns></returns>
        public static bool ShipperPopularity(out List<Models.MostPopularShipper> shipperPopularity)
        {
            var sql = $@"select [Name], Count(ShipperID) as 'Popularity'
                         from dbo.Shippers
                         join dbo.Orders
                         on dbo.Shippers.ID = dbo.Orders.ShipperID
                         group by Name
                         order by Popularity desc";

            using (var connection = new SqlConnection(connString))
            {
                shipperPopularity = connection.Query<Models.MostPopularShipper>(sql).ToList();
            }

            if (shipperPopularity.Count >= 1)
                return true;

            return false;
        }

        /// <summary>
        /// Fetches orders per customer
        /// </summary>
        /// <param name="ordersPerCustomer">The orders per customer.</param>
        /// <returns></returns>
        public static bool OrdersPerCustomer(out List<Models.OrdersPerCustomer> ordersPerCustomer)
        {
            var sql = $@"select Name, count([CustomerId]) 
                      as 'AmountOfOrders'
                      from Customers
                      join Orders
                      on Customers.ID = Orders.CustomerId
                      group by Customers.Name";

            using (var connection = new SqlConnection(connString))
            {
                ordersPerCustomer = connection.Query<Models.OrdersPerCustomer>(sql).ToList();
            }

            if (ordersPerCustomer.Count >= 1)
                return true;

            return false;
        }


        /// <summary>
        /// Gets the top three most attractive products .
        /// </summary>
        /// <param name="listOfTopProducts">The list of top products.</param>
        /// <returns></returns>
        public static bool GetTopThree(out List<Models.TopProducts> listOfTopProducts)
        {
            var sql = $@" select top 3 [Name], sum(Quantity) as 'Quantity'
                          from Products
                          join Orderdetails
                          on Products.Id = OrderDetails.ProductID
                          group by Products.Name
                          order by Quantity desc";


            using (var connection = new SqlConnection(connString))
            {
                listOfTopProducts = connection.Query<Models.TopProducts>(sql).ToList();
            }

            if (listOfTopProducts.Count >= 3)
                return true;

            return false;
        }
    }
}
