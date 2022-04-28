using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopMKJ.Aggregate
{
    public static class Handler
    {
        /// <summary>
        /// Shows the products with stock value.
        /// </summary>
        public static void ShowProductsWithStockValue()
        {
            Console.Clear();
            Print.Logo();
            var productsAndStocks = Databasedapper.ShowAllProductsWithStockValue();

            if(productsAndStocks.Count() == 0)
            {
                Console.WriteLine("\n\t Nothing to display right now");
                Console.ReadKey();
                return;
            }

            foreach (var item in productsAndStocks)
            {
                Console.WriteLine($"\t{item.Name}\t{item.Quantity}");
            }
            Console.Write("\n\tPress any key to continue.. ");
            Console.ReadKey();
        }

        /// <summary>
        /// Shows all carts with products.
        /// </summary>
        public static void ShowAllCartsWithProducts()
        {
            Console.Clear();
            Print.Logo();
            var cartsAndProducts = Databasedapper.ShowCartWithProducts();

            if (cartsAndProducts.Count() == 0)
            {
                Console.WriteLine("\n\t Nothing to display right now");
                Console.ReadKey();
                return;
            }

            foreach (var item in cartsAndProducts)
            {
                Console.WriteLine($"\t{item.CustomerName}\t{item.ProductName}\t{item.Quantity}");
            }
            Console.Write("\n\tPress any key to continue.. ");
            Console.ReadKey();
        }

        /// <summary>
        /// Shows the product maximum inventory.
        /// </summary>
        public static void ShowProductMaxInventory()
        {
            Console.Clear();
            Print.Logo();
            var maxInventory = Databasedapper.ShowProductWithMostInventory();

            if (maxInventory.Count() == 0)
            {
                Console.WriteLine("\n\t Nothing to display right now");
                Console.ReadKey();
                return;
            }

            foreach (var item in maxInventory)
            {
                Console.WriteLine($"\t{item.Name}\t{item.Quantity}");
            }
            Console.Write("\n\tPress any key to continue.. ");
            Console.ReadKey();
        }

        /// <summary>
        /// Shows the product minimum inventory.
        /// </summary>
        public static void ShowProductMinInventory()
        {
            Console.Clear();
            Print.Logo();
            var minInventory = Databasedapper.ShowProductWithLeastInventory();

            if (minInventory.Count() == 0)
            {
                Console.WriteLine("\n\t Nothing to display right now");
                Console.ReadKey();
                return;
            }

            foreach (var item in minInventory)
            {
                Console.WriteLine($"\n\t{item.Name}\t{item.Quantity}");
            }
            Console.Write("\n\tPress any key to continue.. ");
            Console.ReadKey();
        }

        /// <summary>
        /// Shows the customers and products and dates.
        /// </summary>
        public static void ShowCustomersAndProductsAndDates()
        {
            Console.Clear();
            Print.Logo();
            var customerProductsAndDates = Databasedapper.ShowCustomersProductsAndDate();

            if (customerProductsAndDates.Count() == 0)
            {
                Console.WriteLine("\n\t Nothing to display right now");
                Console.ReadKey();
                return;
            }

            foreach (var item in customerProductsAndDates)
            {
                Console.WriteLine($"\t{item.CustomerName}\t{item.ProductName}\t{item.Quantity}\t{item.OrderDate}");
            }
            Console.Write("\n\tPress any key to continue.. ");
            Console.ReadKey();
        }
        public static void PrintMostStocked()
        {
            Console.Clear();
            Print.Logo();

            var mostStocked = new List<Models.MostStockedCategory>();

            if(Databasedapper.MostStockedCategories(out mostStocked))
            {
                Console.WriteLine($"\tName\tStock");
                foreach (var item in mostStocked)
                {
                    Console.WriteLine($"\t{item.Name}\t{item.Stock}");
                }

                Console.Write("\n\tPress any key to continue.. ");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\tNot enough data in the database to display relevant information");
                Console.Write("\n\tPress any key to continue.. ");
                Console.ReadKey();
            }
        }
        public static void PrintCategoryPopularity()
        {
            Console.Clear();
            Print.Logo();

            var popularCategory = new List<Models.MostPopularCategory>();

            if(Databasedapper.CategoryPopularity(out popularCategory))
            {
                Console.WriteLine($"\tName\tAmount of products in category");
                foreach (var item in popularCategory)
                {
                    Console.WriteLine($"\t{item.Name}\t{item.Popularity}");
                }

                Console.Write("\n\tPress any key to continue.. ");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\tNot enough data in the database to display relevant information");
                Console.Write("\n\tPress any key to continue.. ");
                Console.ReadKey();
            }
        }
        public static void PrintShipperPopularity()
        {
            Console.Clear();
            Print.Logo();

            var shipperPopular = new List<Models.MostPopularShipper>();

            if(Databasedapper.ShipperPopularity(out shipperPopular))
            {
                Console.WriteLine($"\tName\tPopularity");
                foreach (var item in shipperPopular)
                {
                    Console.WriteLine($"\t{item.Name}\t{item.Popularity}");
                }

                Console.Write("\n\tPress any key to continue.. ");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Not enough data in the database to display relevant information");
                Console.Write("\n\tPress any key to continue.. ");
                Console.ReadKey();
            }

        }
        public static void PrintOrdersPerCustomer()
        {
            Console.Clear();
            Print.Logo();

            var orderPerCustomer = new List<Models.OrdersPerCustomer>();

            if(Databasedapper.OrdersPerCustomer(out orderPerCustomer))
            {
                Console.WriteLine($"\tName\tAmount of orders");
                foreach (var item in orderPerCustomer)
                {
                    Console.WriteLine($"\t{item.Name}\t{item.AmountOfOrders}");
                }

                Console.Write("\n\tPress any key to continue.. ");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\tNot enough data in the database to display relevant information");
                Console.Write("\n\tPress any key to continue.. ");
                Console.ReadKey();
            }

        }
        public static void PrintTopThree()
        {
            Console.Clear();
            Print.Logo();

            var topThree = new List<Models.TopProducts>();

            if(Databasedapper.GetTopThree(out topThree))
            {
                Console.WriteLine("\tTop three trending products:");
                Console.WriteLine($"\tName\tQuantity");
                foreach (var item in topThree)
                {
                    Console.WriteLine($"\t{item.Name}\t{item.Quantity}");
                }

                Console.Write("\n\tPress any key to continue.. ");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\tNot enough data in the database to display relevant information");
                Console.Write("\n\tPress any key to continue.. ");
                Console.ReadKey();
            }

        }


        /// <summary>
        /// Aggres the gate main menu.
        /// </summary>
        public static void AggregateMainMenu()
        {
            bool notExit = true;

            while (notExit)
            {
                Print.AggreGateTextMenu();
                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1":
                            ShowProductsWithStockValue();
                            break;
                        case "2":
                            ShowAllCartsWithProducts();
                            break;
                        case "3":
                            ShowProductMaxInventory();
                            break;
                        case "4":
                            ShowProductMinInventory();
                            break;
                        case "5":
                            ShowCustomersAndProductsAndDates();
                            break;
                        case "6":
                            PrintMostStocked();
                            break;
                        case "7":
                            PrintCategoryPopularity();
                            break;
                        case "8":
                            PrintShipperPopularity();
                            break;
                        case "9":
                            PrintOrdersPerCustomer();
                            break;
                        case "10":
                            PrintTopThree();
                            break;
                        case "11":
                            notExit = false;
                            break;


                        default:
                            Console.WriteLine("\n\tInput was not a valid number!");
                            Console.Write("\n\tPress Enter To Continue.. ");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"\n\t{exception.Message}");
                    Console.Write("\tPress Enter To Continue...");
                    Console.ReadKey();
                }
            }
        }

    }

}
