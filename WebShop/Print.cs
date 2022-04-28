using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopMKJ
{
   public static class Print
    {
        public static void Logo()
        {
            Console.WriteLine();
            Console.WriteLine(
                    "\t░██╗░░░░░░░██╗███████╗██████╗░░██████╗██╗░░██╗░█████╗░██████╗░\n" +
                    "\t░██║░░██╗░░██║██╔════╝██╔══██╗██╔════╝██║░░██║██╔══██╗██╔══██╗\n" +
                    "\t░╚██╗████╗██╔╝█████╗░░██████╦╝╚█████╗░███████║██║░░██║██████╔╝\n" +
                    "\t░░████╔═████║░██╔══╝░░██╔══██╗░╚═══██╗██╔══██║██║░░██║██╔═══╝░\n" +
                    "\t░░╚██╔╝░╚██╔╝░███████╗██████╦╝██████╔╝██║░░██║╚█████╔╝██║░░░░░\n" +
                    "\t░░░╚═╝░░░╚═╝░░╚══════╝╚═════╝░╚═════╝░╚═╝░░╚═╝░╚════╝░╚═╝░░░░░\n");
        }

        public static void MenuLogin()
        {
            Console.Clear();
            Logo();
            Console.WriteLine("\t~~~~~ Login ~~~~~");
            Console.WriteLine("\t[1] Pick existing");
            Console.WriteLine("\t[2] Create new");
            Console.WriteLine("\t[3] Return");
            Console.WriteLine("\t---------------");
            Console.Write("\tInput: ");
        }
        public static void MenuCustomerOrAdmin()
        {
            Console.Clear();
            Logo();
            Console.WriteLine("\t~~~~~ Admin or Customer ~~~~~");
            Console.WriteLine("\t[1] Admin");
            Console.WriteLine("\t[2] Customer");
            Console.WriteLine("\t[3] Aggregate methods");
            Console.WriteLine("\t[4] Search");
            Console.WriteLine("\t[5] Exit");
            Console.WriteLine("\t------------------------------");
                Console.Write("\tInput: ");
        }


        public static void MenuCustomer()
        {
            Logo();
            Console.WriteLine("\t~~~~~ Customer ~~~~~");
            Console.WriteLine("\t[1] Shop");
            Console.WriteLine("\t[2] Cart");
            Console.WriteLine("\t[3] Exit");
            Console.WriteLine("\t--------------------");
            Console.Write("\tInput: ");
        }

        public static void ShopMenu()
        {
            Console.WriteLine("\tPlease pick a category.");
            Console.WriteLine("\t[1]. Fruit");
            Console.WriteLine("\t[2]. Drinks");
            Console.WriteLine("\t[3]. Meat");
            Console.WriteLine("\t[4]. Bread");
            Console.WriteLine("\t[5]. Snacks");
            Console.WriteLine("\t[6]. Back");
        }

        public static void CartMenu()
        {
            Console.WriteLine("\nItems in your cart: ");
        }

        public static void AdminMainMenu()
        {
            Console.Clear();
            Print.Logo();
            Console.WriteLine("\t[1] Change   \t\t- Change a products name, price, description or category ID");
            Console.WriteLine("\t[2] Add      \t\t- Add a new product, category or shipper to your store");
            Console.WriteLine("\t[3] Remove   \t\t- Removes an existing product, category, shipper or customer account");
            Console.WriteLine("\t[4] Inventory\t\t- Check or Change the inventory balance of a product");
            Console.WriteLine("\t[5] Show     \t\t- Show all products, categories, customers or shippers");
            Console.WriteLine("\t[6] Back     \t\t- Exit to main menu");
            Console.Write("\n\tSelect an option: ");
        }

        public static void AdminSelectMenu()
        {
            Console.WriteLine("\t[1]  Product ");
            Console.WriteLine("\t[2]  Category");
            Console.WriteLine("\t[3]  Supplier");
            Console.WriteLine("\t[4]  Back  ");
            Console.Write("\n\tSelect an option: ");
        }

        public static void AdminSelectMenu2()
        {
            Console.Clear();
            Print.Logo();
            Console.WriteLine("\t[1]  Name");
            Console.WriteLine("\t[2]  Category ID");
            Console.WriteLine("\t[3]  Description");
            Console.WriteLine("\t[4]  Price");
            Console.WriteLine("\t[5]  Back");
            Console.Write("\n\tSelect option: ");
        }

        public static void AdminSelectMenu3()
        {
            Console.WriteLine("\t[1]  Product ");
            Console.WriteLine("\t[2]  Category");
            Console.WriteLine("\t[3]  Supplier");
            Console.WriteLine("\t[4]  Customer");
            Console.WriteLine("\t[5]  Back  ");
            Console.Write("\n\tSelect an option: ");
        }

        public static void AdminSelectMenu4()
        {
            Console.WriteLine("\t[1]  Continue or Discontinue product");
            Console.WriteLine("\t[2]  Change Stock Value");
            Console.WriteLine("\t[3]  Check Inventory");
            Console.WriteLine("\t[4]  Back");
            Console.Write("\n\tSelect an option: ");
        }

        public static void AdminSelectMenu5()
        {
            Console.Clear();
            Print.Logo();
            Console.WriteLine("\t[1]  Name");
            Console.WriteLine("\t[2]  Price ");
            Console.WriteLine("\t[3]  Back");
            Console.Write("\n\tSelect option: ");

        }
        public static void AdminSelectMenu6()
        {
            Console.WriteLine("\t[1]  Continue product ");
            Console.WriteLine("\t[2]  Discontinue product");
            Console.WriteLine("\t[3]  Back");
            Console.Write("\n\tSelect an option: ");
        }

        public static void AdminSelectMenu7()
        {
            Console.WriteLine("\t~~~~~~Change Category~~~~~~\n");
            Console.WriteLine("\t[1]  Name");
            Console.WriteLine("\t[2]  Category ID");
            Console.WriteLine("\t[3]  Back");
            Console.Write("\n\tSelect option: ");
        }

        public static void AdminSelectMenu8()
        {
            Console.Clear();
            Logo();
            Console.WriteLine("\t~~~~~~Show~~~~~~\n");
            Console.WriteLine("\t[1]  Product");
            Console.WriteLine("\t[2]  Categories");
            Console.WriteLine("\t[3]  Shippers");
            Console.WriteLine("\t[4]  Customers");
            Console.WriteLine("\t[5]  Back");
            Console.Write("\n\tSelect option: ");
        }
        public static void AggreGateTextMenu()
        {
            Console.Clear();
            Logo();
            Console.WriteLine("\t~~~~~ Aggregate ~~~~~");
            Console.WriteLine("\t[1] Show Products with stock value");
            Console.WriteLine("\t[2] Show all carts with products");
            Console.WriteLine("\t[3] Show Product with max Inventory");
            Console.WriteLine("\t[4] Show product with min Inventory");
            Console.WriteLine("\t[5] Show Customers and products with order dates etc");
            Console.WriteLine("\t[6] Show most stocked categories");
            Console.WriteLine("\t[7] Show category popularity");
            Console.WriteLine("\t[8] Show shipper popularity");
            Console.WriteLine("\t[9] Orders per customer");
            Console.WriteLine("\t[10] Show top 3 trending products");
            Console.WriteLine("\t[11] Exit");
            Console.WriteLine("\t------------------------------");
            Console.Write("\tInput: ");
        }
    }
}
