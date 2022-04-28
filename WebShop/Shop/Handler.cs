using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopMKJ.Shop
{
    public static class Handler
    {
        /// <summary>
        /// Shows all the categorys and lets the user pick one
        /// </summary>
        /// <returns>int of the chosen category</returns>
        public static int DisplayAndPickCategories()
        {
            var categories = Databasedapper.ShowAllCategories();

            Console.WriteLine("\tNumber\t Name");
            foreach (var category in categories)
            {
                Console.WriteLine($"\t{category.Id}\t{category.Name}");
            }
            Console.Write("\n\tChoose a category number: ");
            return Program.MenuReader(categories[0].Id, categories[^1].Id);
        }

        /// <summary>
        /// Shows the products in the chosen category
        /// and lets the user pick a product.
        /// </summary>
        /// <param name="num">the Id for the chosen category</param>
        /// <returns>int, the product ID</returns>
        public static int ShowAndPickProduct(int num)
        {
            var products = Databasedapper.ShowSpecificCategorieProducts(num);

            Console.WriteLine("\tNumber\t Name\t Price");
            foreach (var product in products)
            {
                Console.WriteLine($"\t{product.Id}\t{product.Name}\t{product.Price}");
            }
            Console.Write("\n\tChoose a Product Number: ");
            return Program.MenuReader(products[0].Id, products[^1].Id);
        }

        /// <summary>
        /// Puts the chosen product in cart.
        /// </summary>
        /// <param name="num">The number.</param>
        /// <param name="IdOfCustomer">The identifier of customer.</param>
        public static void PutChosenProductInCart(int num, int? IdOfCustomer)
        {
            var product = Databasedapper.ShowSpecificProduct(num);

            foreach (var info in product)
            {
                Console.WriteLine($"\t{info.Name}\t{info.Price}\n\n{info.Description}");
            }

            Console.Write("\tHow many?(Max 10): ");

            var productToCart = new Models.Cart();
            productToCart.Quantity = Program.MenuReader(1, 10);
            productToCart.ProductId = num;
            productToCart.CustomerId = IdOfCustomer;

            int savedChanges = Databasedapper.AddToCart(productToCart);
            
            Console.WriteLine($"\t{savedChanges} Affected rows");
            
        }

        /// <summary>
        /// Shows and picks shipper from database.
        /// </summary>
        /// <returns></returns>
        public static int ShowAndPickShipper()
        {
            var shippers = Databasedapper.ShowAllShippers();

            Console.WriteLine("\tNumber\t Name");
            foreach (var shipper in shippers)
            {
                Console.WriteLine($"\t{shipper.Id}\t{shipper.Name}");
            }
            Console.Write("\n\tChoose a Shipper Number: ");
            return Program.MenuReader(shippers[0].Id, shippers[^1].Id);
        }

        /// <summary>
        /// Show and pick a customer.
        /// </summary>
        /// <returns></returns>
        public static int ShowAndPickCustomer()
        {
            var customers = Databasedapper.ShowAllCustomers();

            Console.WriteLine("\tNumber\t Name");
            foreach (var customer in customers)
            {
                Console.WriteLine($"\t{customer.Id}\t{customer.Name}");
            }
            Console.Write("\n\tChoose a Customer Id: ");
            return Program.MenuReader(customers[0].Id, customers[^1].Id);
        }

    }
}
