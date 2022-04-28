using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopMKJ.Menu
{
    public static class MenuModel
    {
        public static int? CustomerID = null;
        /// <summary>
        /// The main menu for the application. Executes mini menus together with other methods.
        /// </summary>
        /// <param name="choice">The choice.</param>
        public static void MenuHandler()
        {

            while (true)
            {
                Print.MenuCustomerOrAdmin();
                switch (Program.MenuReader(1, 5))
                {
                    case 1:
                        Admin.Handler.AdminOptionsMainMenu();
                        break;
                        
                    case 2:
                        CustomerID = LogInMenu();
                        if(CustomerID != null)
                        {
                            CustomerMenu(CustomerID);
                        }
                        break;
                    case 3:
                        {
                            Aggregate.Handler.AggregateMainMenu();
                        }
                        break;
                    case 4:
                        {
                            searchForItem();
                        }
                        break;
                    case 5:
                        return;
                }
            }
        }

        /// <summary>
        /// The menu for loging in, returns the id of the customer
        /// </summary>
        /// <returns>int, id of the customer</returns>
        public static int? LogInMenu()
        {
            int? currentCustomer = null;

            while (currentCustomer == null)
            {
                Print.MenuLogin();
                switch (Program.MenuReader(1, 3))
                {
                    case 1:
                        currentCustomer = LogIn.Handler.PickCustomer();
                        if (currentCustomer == null)
                        {
                            Console.WriteLine("\nNo customer exists in the database, press enter to continue");
                            Console.ReadLine();
                        }
                        break;
                    case 2:
                        LogIn.Handler.CreateNewCustomer();
                        var customers = Databasedapper.ShowAllCustomers();
                        break;
                    case 3:
                        return currentCustomer;

                }
            }
            return currentCustomer;
        }

        public static void searchForItem()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Print.Logo();
                Console.Write("\n\n\tSearch item:");
                EntityFrameworkMethods.SearchEngine(Console.ReadLine());
                
                Console.WriteLine("Press Backspace to return or enter to search again");
                var key = Console.ReadKey();
                if (key.Key.Equals(ConsoleKey.Backspace))
                {
                    running = false;
                }
            }
        }

        /// <summary>
        /// The menu for picking shop in main menu
        /// </summary>
        public static void CustomerMenu(int? customerID)
        {
            bool run = true;
            while (run)
            {
                Console.Clear();
                Print.MenuCustomer();
                switch (Program.MenuReader(1, 3))
                {
                    case 1:
                        int categoryChoice = Shop.Handler.DisplayAndPickCategories();
                        int productChoice = Shop.Handler.ShowAndPickProduct(categoryChoice);
                        Shop.Handler.PutChosenProductInCart(productChoice, customerID);
                        break;
                    case 2:
                        CartMenu();
                        break;
                    case 3:
                        run = false;
                        break;
                }
            }
        }

        /// <summary>
        /// The menu for picking cart in main menu
        /// </summary>
        public static void CartMenu()
        {
            Print.CartMenu();
            Cart.CartMethods.GetCurrentCart(CustomerID);
        }
    }
}
