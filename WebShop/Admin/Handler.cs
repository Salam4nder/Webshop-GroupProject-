using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopMKJ.Admin
{
    public static class Handler
    {
        //Contains methods for Menus
        
        #region All Menus
        public static void AdminOptionsMainMenu()
        {
            bool notExit = true;

            while (notExit)
            {
                Print.AdminMainMenu();
                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Change();
                            break;
                        case "2":
                            Add();
                            break;
                        case "3":
                            Remove();
                            break;
                        case "4":
                            Inventory();
                            break;
                        case "5":
                            Show();
                            break;
                        case "6":
                            notExit = false;
                            break;

                        default:
                            Console.WriteLine("\n\tInput was not a valid number!");
                            Console.Write("\n\tPress Enter To Continue.. ");
                            Console.ReadKey();
                            break;
                    }
                }
                catch(Exception exception)
                {
                    Console.WriteLine($"\n\t{exception.Message}");
                    Console.Write("\tPress Enter To Continue...");
                    Console.ReadKey();
                }
            }
        }

        public static void AdminStandardMenu2(int productId)
        {
            bool notExit = true;
            while (notExit)
            {
                Print.AdminSelectMenu2();

                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1":
                            ProductName(productId);
                            break;
                        case "2":
                            ProductCategoryID(productId);
                            break;
                        case "3":
                            ProductDescription(productId);
                            break;
                        case "4":
                            ProductPrice(productId);
                            break;
                        case "5":
                            notExit = false;
                            break;

                        default:
                            Console.WriteLine("\tIncorrect Input!");
                            Console.WriteLine("\n\tPress Enter To Continue...");
                            Console.ReadKey();
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("\n\tIncorrect Input!");
                    Console.Write("\n\tPress Enter To Continue.. ");
                    Console.ReadKey();
                }
            }
        }

        #endregion

        //Contains all the methods to show products, customer, shippers or categories

        #region Show Methods

        /// <summary>
        /// Show select menu, show products, categories etc
        /// </summary>
        public static void Show()
        {
            Print.AdminSelectMenu8();
            int userChoice = Program.MenuReader(1,5);

            if (userChoice == 1) ShowProducts();
            else if (userChoice == 2) ShowCategories();
            else if (userChoice == 3) ShowShippers();
            else if (userChoice == 4) ShowCustomers();
            else if (userChoice == 5) return;
        }

        /// <summary>
        /// Shows all products
        /// </summary>
        public static void ShowProducts()
        {
            Console.Clear();
            var productList = Databasedapper.ShowAllProducts();

            Console.WriteLine("\n\tID\tName\t\tCategoryId\tDescription\t\tPrice\n");
            foreach (var product in productList)
            {
                Console.WriteLine($"\t{product.Id}\t{product.Name}\t{product.CategoryId}\t{product.Description}\t{product.Price}\t");
            }
            Console.Write("\n\tPress any key to continue.. ");
            Console.ReadKey();
        }

        /// <summary>
        /// Shows all categories
        /// </summary>
        public static void ShowCategories()
        {
            Console.Clear();
            Print.Logo();
            var categoryList = Databasedapper.ShowAllCategories();

            Console.WriteLine("\n\tID\tName");
            foreach (var category in categoryList)
            {
                Console.WriteLine($"\t{category.Id}\t{category.Name}");
            }
            Console.Write("\n\tPress any key to continue.. ");
            Console.ReadKey();
        }

        /// <summary>
        /// Shows all shippers
        /// </summary>
        public static void ShowShippers()
        {
            Console.Clear();
            Print.Logo();
            var shipperList = Databasedapper.ShowAllShippers();

            Console.WriteLine("\n\tID\tName\tPrice");
            foreach (var shipper in shipperList)
            {
                Console.WriteLine($"\t{shipper.Id}\t{shipper.Name}\t{shipper.Price}");
            }
            Console.Write("\n\tPress any key to continue.. ");
            Console.ReadKey();
        }

        /// <summary>
        ///Shows all customers 
        /// </summary>
        public static void ShowCustomers()
        {
            Console.Clear();
            Print.Logo();
            var customerList = Databasedapper.ShowAllCustomers();

            Console.WriteLine("\n\tID\tName\t\tEmail");
            foreach (var customer in customerList)
            {
                Console.WriteLine($"\t{customer.Id}\t{customer.Name}\t{customer.Email}");
            }
            Console.Write("\n\tPress any key to continue.. ");
            Console.ReadKey();
        }


        #endregion

        //Contains all the method that change price, name etc

        #region Change Methods

        /// <summary>
        /// This is the change menu
        /// </summary>
        public static void Change()
        {
            bool notExit = true;

            while(notExit)
            {
                Console.Clear();
                Print.Logo();
                Console.WriteLine("\t~~~~~~Change~~~~~~");
                Print.AdminSelectMenu();
                int userChoice = Program.MenuReader(1, 4);
                if (userChoice == 1)
                    ChangeProduct();
                else if (userChoice == 2)
                    ChangeCategory();
                else if (userChoice == 3)
                    ChangeSupplier();
                else if (userChoice == 4)
                    notExit = false;
            }
        }

        /// <summary>
        /// Select a product and change it
        /// </summary>
        public static void ChangeProduct()
        {
            Console.Clear();
            Print.Logo();
            Console.WriteLine("\t~~~~~~Change Product~~~~~~\n");
            int selectedCategory = Shop.Handler.DisplayAndPickCategories();
            Console.Clear();
            Print.Logo();
            int productId = Shop.Handler.ShowAndPickProduct(selectedCategory);

            AdminStandardMenu2(productId);

            Console.ReadKey();
        }
        /// <summary>
        /// Select a category and change it
        /// </summary>
        public static void ChangeCategory()
        {
            Console.Clear();
            Print.Logo();
            int selectedCategory = Shop.Handler.DisplayAndPickCategories();
            Console.Clear();
            Print.Logo();
            Console.WriteLine("\t~~~~~~Change Category~~~~~~\n");

            bool notExit = true;
            while (notExit)
            {
                Console.Clear();
                Print.Logo();
                Print.AdminSelectMenu7();
                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1":
                            CategoryName(selectedCategory);
                            break;
                        case "2":
                            CategoryCategoryID(selectedCategory);
                            break;
                        case "3":
                            notExit = false;
                            break;
                        default:
                            Console.WriteLine("\tIncorrect Input!");
                            Console.WriteLine("\n\tPress Enter To Continue...");
                            Console.ReadKey();
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("\tYour Input was incorrect!");
                    Console.WriteLine("\tPress Enter To Continue...");
                    Console.ReadKey();
                }
            }
        }
        /// <summary>
        /// Select a Supplier and change it
        /// </summary>
        public static void ChangeSupplier()
        {
            Console.Clear();
            Print.Logo();
            Console.WriteLine("\t~~~~~~Change Supplier~~~~~~\n");
            int selectedShipper = Shop.Handler.ShowAndPickShipper();

            Console.Write("\n\tType the new price of the selected Shipper: ");
            float price = Program.MenuReader(1, 2000);

            Databasedapper.ProductChangePrice(price, selectedShipper);
        }

        #endregion
        
        //Contains all the methods that adds products, shippers and categories

        #region Add Methods

        /// <summary>
        /// Adds a product, shipper or category to your store
        /// </summary>
        public static void Add()
        {
            bool notExit = true;

            while (notExit)
            {
                Console.Clear();
                Print.Logo();
                Console.WriteLine("\t~~~~~~Add~~~~~~");
                Print.AdminSelectMenu();
                int userChoice = Program.MenuReader(1, 4);
                if (userChoice == 1)
                    Add_Product();
                else if (userChoice == 2)
                    Add_Category();
                else if (userChoice == 3)
                    Add_Supplier();
                else if (userChoice == 4)
                    notExit = false;
            }
        }

        /// <summary>
        /// Adds a product to the database
        /// </summary>
        public static void Add_Product()
        {
            Console.Clear();
            Print.Logo();
            Console.WriteLine("\n\t~~~~~~Add a product~~~~~~");

            var newProduct = new Models.Product();
            newProduct.CategoryId = Shop.Handler.DisplayAndPickCategories();

            bool incorrectInput = true;
            while (incorrectInput)
            {
                Console.Write("\n\tType a name for your new product: ");
               
                string userInput = Console.ReadLine();

                if (!IsLetters(userInput))
                {
                    Console.WriteLine("\tIncorrect input!");
                }
                else
                {
                    newProduct.Name = userInput;
                    incorrectInput = false;
                }
            }

            Console.Write("\n\tType the price of the selected product: ");
            newProduct.Price = Program.PriceReader(1,2000);

            incorrectInput = true;
            while (incorrectInput)
            {
                Console.Write("\n\tType a description for your new product: ");
               
                string userInput = Console.ReadLine();

                if (!IsLetters(userInput))
                {
                    Console.WriteLine("\tIncorrect input!");
                }
                else
                {
                    newProduct.Description = userInput;
                    incorrectInput = false;
                }
            }

            Databasedapper.ProductAddToDatabase(newProduct);
            Console.Write("\n\ta new product has been generated: ");
            Console.WriteLine($"\n\t{newProduct.Name}\t{newProduct.CategoryId}\t{newProduct.Description}\t{newProduct.Price}");

            var allProducts = Databasedapper.ShowAllProducts();

            Console.Write("\n\tType the quantity of the product (Max 100): ");

            int quantity = Program.MenuReader(1, 100);
            Databasedapper.ProductAddStockValue(allProducts[^1].Id, quantity);

            Console.Write("\n\tPress any key to continue..");
            Console.ReadKey();
        }

        /// <summary>
        /// Adds the category.
        /// </summary>
        public static void Add_Category()
        {
            Console.Clear();
            Print.Logo();
            Console.WriteLine("\n\t~~~~~~Add a category~~~~~~");

            var newCategory = new Models.Category();
            bool incorrectInput = true;

            while (incorrectInput)
            {
                Console.Write("\n\tType a name for your new category: ");
                
                string userInput = Console.ReadLine();

                if (!IsLetters(userInput))
                {
                    Console.WriteLine("\tIncorrect input!");
                }
                else
                {
                    newCategory.Name = userInput;
                    incorrectInput = false;
                }
            }
            Databasedapper.CategoryAddToDatabase(newCategory);
            Console.WriteLine($"\n\ta new category has been generated: {newCategory.Name}");
            Console.Write("\n\tPress any key to continue..");
            Console.ReadKey();
        }

        /// <summary>
        /// Adds the supplier.
        /// </summary>
        public static void Add_Supplier()
        {
            Console.Clear();
            Print.Logo();
            Console.WriteLine("\n\t~~~~~~Add a Shipper~~~~~~");

            var newShipper = new Models.Shipper();
            bool incorrectInput = true;

            while (incorrectInput)
            {
                Console.Write("\n\tType a name for your new Shipper: ");
                string userInput = Console.ReadLine();

                if (!IsLetters(userInput))
                {
                    Console.WriteLine("\tIncorrect input!");
                }
                else
                {
                    newShipper.Name = userInput;
                    incorrectInput = false;
                }
            }
            Console.Write("\n\tType the price of the selected Shipper: ");

            newShipper.Price = Program.PriceReader(1, 2000);

            Databasedapper.ShipperAddToDatabase(newShipper);
            Console.WriteLine($"\n\ta new Shipper has been generated: {newShipper.Name}");
            Console.Write("\n\tPress any key to continue..");
            Console.ReadKey();
        }

        #endregion

        //Contains all the methods that has to do with the inventory

        #region Inventory Methods
        /// <summary>
        /// Inventory Menu.
        /// </summary>
        public static void Inventory()
        {
            bool notExit = true;
            while (notExit)
            {
                Console.Clear();
                Print.Logo();
                Console.WriteLine("\t~~~~~~Inventory~~~~~~");
                Print.AdminSelectMenu4();
                int userChoice = Program.MenuReader(1,4);

                if (userChoice == 1)
                    InventoryContinueOrDiscontinue();
                else if (userChoice == 2)
                    InventoyChangeStockValue();
                else if (userChoice == 3)
                    CheckInventory();
                else if (userChoice == 4)
                    notExit = false;
            }
        }

        /// <summary>
        /// Change stock value of a product.
        /// </summary>
        public static void InventoyChangeStockValue()
        {
            Console.Clear();
            Print.Logo();
            Console.WriteLine("\t~~~~~~Change Inventory~~~~~~");
            int selectedCategory = Shop.Handler.DisplayAndPickCategories();
            int productId = Shop.Handler.ShowAndPickProduct(selectedCategory);
            var changedProduct = new Models.Product();

            Console.Write("\n\tType the new stock value of your product: ");

            int stockValue = Program.MenuReader(1,100);

            Databasedapper.InventoryStockChange(productId, stockValue);

        }

        /// <summary>
        /// Inventory Menu.
        /// </summary>
        public static void CheckInventory()
        {
            Console.Clear();
            Print.Logo();
            var inventoryList = Databasedapper.InventorySeeInventoryStocksAndProducts();

            Console.WriteLine("\tProduct\t\tCategory\tStock\t\tContinued/Discontinued");
            bool productName = false;

            foreach (var product in inventoryList)
            {
                productName = false;
                string InventoryString = $"\t{product.ProductName}\t{product.CategoryName}\t\t{product.Stock}\t\t{product.SoldOrNot}";

                if(product.ProductName.Length <= 6)
                {
                    InventoryString = $"\t{product.ProductName}\t\t{product.CategoryName}\t{product.Stock}\t{product.SoldOrNot}";
                    productName = true;
                }
                if (product.CategoryName.Length <= 5 && !productName)
                {
                    InventoryString = $"\t{product.ProductName}\t{product.CategoryName}\t\t{product.Stock}\t\t{product.SoldOrNot}";
                }
                if (product.CategoryName.Length <= 5 && productName)
                {
                    InventoryString = $"\t{product.ProductName}\t\t{product.CategoryName}\t\t{product.Stock}\t\t{product.SoldOrNot}";
                }
                Console.WriteLine(InventoryString);
            }
            Console.Write("\n\tPress any key to continue.. ");
            Console.ReadKey();
        }

        /// <summary>
        /// Continue or discontinue a selected product.
        /// </summary>
        public static void InventoryContinueOrDiscontinue()
        {
            Console.Clear();
            Print.Logo();
            Console.WriteLine("\t~~~~~~Change Inventory~~~~~~");
            int selectedCategory = Shop.Handler.DisplayAndPickCategories();
            int productId = Shop.Handler.ShowAndPickProduct(selectedCategory);
            var changedProduct = new Models.Product();
            Print.AdminSelectMenu6();
            bool notExit = true;
            int affectedRows = 0;

            while (notExit)
            {
                int userChoice = Program.MenuReader(1, 3);

                if (userChoice == 1) 
                {
                    affectedRows = Databasedapper.InventoryContinueProduct(productId);
                    notExit = false;
                }
                else if (userChoice == 2)
                {
                    affectedRows = Databasedapper.InventoryDiscontinueProduct(productId);
                    notExit = false;
                }
                else if (userChoice == 3)
                {
                    notExit = false;
                }
            }
            Console.Write("\n\tProduct has been updated. Press any key to continue..");
            Console.ReadKey();
        }
        /// <summary>
        /// Inventories the stock value.
        /// </summary>

        #endregion

        //Contains all the methods to remove categories, shippers or products

        #region Remove Methods

        /// <summary>
        /// Remove options
        /// </summary>
        public static void Remove()
        {
            bool notExit = true;
            while (notExit)
            {
                Console.Clear();
                Print.Logo();
                Console.WriteLine("\t~~~~~~Remove~~~~~~\n");
                Print.AdminSelectMenu3();


                int userChoice = Program.MenuReader(1, 5);
                if (userChoice == 1)
                    RemoveProduct();
                else if (userChoice == 2)
                    RemoveCategory();
                else if (userChoice == 3)
                    RemoveSupplier();
                else if (userChoice == 4)
                    RemoveCustomer();
                else if (userChoice == 5)
                    notExit = false;
            }
               
        }
        /// <summary>
        /// Remove product
        /// </summary>
        public static void RemoveProduct()
        {
            Console.Clear();
            Print.Logo();
            int selectedCategory = Shop.Handler.DisplayAndPickCategories();
            Console.Clear();
            Print.Logo();
            int productId = Shop.Handler.ShowAndPickProduct(selectedCategory);

            Databasedapper.ProductRemoveOrderDetailFromDatabase(productId);
            Databasedapper.ProductRemoveFromInventoryDatabase(productId);
            int affectedRows = Databasedapper.ProductRemoveFromDatabase(productId);
            
            if(affectedRows == 1)
                Console.WriteLine("\n\tProduct has successfully been removed from the database");
            else
                Console.WriteLine("\n\tProduct was not removed");
            
            Console.Write("\n\tPress any key to continue: ");
            Console.ReadKey();
        }
        /// <summary>
        /// Remove a category
        /// </summary>
        public static void RemoveCategory()
        {
            Console.Clear();
            Print.Logo();

            bool inCorrectInput = true;
            while (inCorrectInput)
            {
                int selectedCategory = Shop.Handler.DisplayAndPickCategories();
                int affectedRows = Databasedapper.CategoryRemoveFromDatabase(selectedCategory);

                if (affectedRows == 0)
                {
                    Console.WriteLine("\n\tCategory can't be removed when there are still products in it\n");
                }
                else
                {
                    inCorrectInput = false;
                    Console.WriteLine("\n\tA category has successfully been removed");
                    Console.Write("\n\tPress any key to continue..");
                    Console.ReadKey();
                }
            }

        }

        /// <summary>
        /// Remove a supplier
        /// </summary>
        public static void RemoveSupplier()
        {
            Console.Clear();
            Print.Logo();
            int selectedShipper = Shop.Handler.ShowAndPickShipper();
            Databasedapper.ShipperRemoveFromDatabase(selectedShipper);

        }

        /// <summary>
        /// Removes a customer
        /// </summary>
        public static void RemoveCustomer()
        {
            Console.Clear();
            Print.Logo();
            int selectedCustomer = Shop.Handler.ShowAndPickCustomer();
            var idList = Databasedapper.CustomerSaveFromOrders(selectedCustomer);

            foreach (var id in idList)
            {
                Databasedapper.CustomerRemoveOrderId(id);
            }
            
            Databasedapper.CustomerRemoveOrder(selectedCustomer);
            Databasedapper.CustomerRemoveCartFromDatabase(selectedCustomer);
            var affectedRows = Databasedapper.CustomerRemoveFromDatabase(selectedCustomer);
            
            if(affectedRows == 1)
                Console.WriteLine("\n\tA customer has been deleted from the database");
            else
                Console.WriteLine("\n\tCustomer not found");

            Console.Write("\tPress any key to continue..");
            Console.ReadKey();
        }

        #endregion

        //Contains all methods that has to do with categories 

        #region Category Methods


        /// <summary>
        /// change the name of a category
        /// </summary>
        /// <param name="selectedCategory"></param>
        public static void CategoryName(int selectedCategory)
        {
            bool incorrectInput = true;
            string chosenName = "";

            while (incorrectInput)
            {
                Console.Write("\n\tType the name of the selected category: ");

                    chosenName = Console.ReadLine();

                if (!IsLetters(chosenName))
                {
                    Console.WriteLine("\n\tIncorrect input!");
                }
                else
                {
                    incorrectInput = false;
                }
            }
            Databasedapper.CategoryChangeName(chosenName, selectedCategory);
        }

        /// <summary>
        /// Change the category ID of a category
        /// </summary>
        /// <param name="selectedCategory"></param>
        public static void CategoryCategoryID(int selectedCategory)
        {
            Console.Write("\t\nType the new CategoryId of the selected category: ");
            int newCategoryId = Program.MenuReader(1,2000);
            Databasedapper.CategoryChangeCategoryId(newCategoryId, selectedCategory);
        }
        #endregion

        //Contains all methods that has to do with products

        #region Product Methods

        /// <summary>
        /// Changes a products category ID
        /// </summary>
        /// <param name="productId"></param>
        public static void ProductCategoryID(int productId)
        {
            var categoryList = Databasedapper.ShowAllCategories();
            Console.Write("\n\tType the new Id of the selected product: ");
            int categoryId = Program.MenuReader(1,categoryList.Count());
            Databasedapper.ProductChangeCategoryId(categoryId, productId);

        }

        /// <summary>
        /// Changes the name of a selected product 
        /// </summary>
        /// <param name="ProductId"></param>
        public static void ProductName(int ProductId)
        {

            bool incorrectInput = true;
            string chosenName = "";

            while (incorrectInput)
            {
                Console.Write("\n\tType the name of the selected product: ");

                chosenName = Console.ReadLine();

                if (!IsLetters(chosenName))
                {
                    Console.WriteLine("\n\tIncorrect input!");
                    continue;
                }
                else
                {
                    incorrectInput = false;
                }

            }
            Databasedapper.ProductChangeName(chosenName, ProductId);
        }

        /// <summary>
        /// Adds or updates a price on a product in your store
        /// </summary>
        /// <param name="productId"></param>
        public static void ProductPrice(int productId)
        {
            Console.Write("\n\tType the price for the selected product: ");
            float price = Program.PriceReader(1,2000);
            Databasedapper.ProductChangePrice(price, productId); 
        }

        /// <summary>
        /// Changes the description of the product
        /// </summary>
        /// <param name="productId"></param>
        public static void ProductDescription(int productId)
        {
            bool incorrectInput = true;
            string chosenInfoText = "";

            while (incorrectInput)
            {
                Console.Write("\n\tType the infotext of the selected product: ");

                chosenInfoText = Console.ReadLine();

                if (!IsLetters(chosenInfoText))
                {
                    Console.WriteLine("\n\tIncorrect input!");
                }
                else
                {
                    incorrectInput = false;
                }
            }
            Databasedapper.ProductChangeDescription(chosenInfoText, productId);
            Console.ReadKey();
        }

        /// <summary>
        /// Adds a product to your store
        /// </summary>

        #endregion

        //Contains some methods that has to do with checking if inputs are as we want them

        #region Illegal Inputs

        public static bool IsLetters(string userInput)
        {
            if (userInput.Length < 3) return false;
            if (userInput.Length > 15) return false;
            if (HasDigits(userInput)) return false;
            if (Contains(userInput, '/')) return false;
            if (Contains(userInput, '&')) return false;
            if (Contains(userInput, '.')) return false;
            if (Contains(userInput, ',')) return false;
            if (Contains(userInput, '<')) return false;
            if (Contains(userInput, '>')) return false;
            if (Contains(userInput, '|')) return false;
            if (Contains(userInput, '´')) return false;
            if (Contains(userInput, '*')) return false;
            if (Contains(userInput, '#')) return false;
            return true;
        }
        public static bool HasDigits(string userInput)
        {
            foreach (char letter in userInput)
                if (char.IsDigit(letter)) return true;

            return false;
        }
        private static bool Contains(string input, char letter)
        {
            foreach (char character in input)
                if (character == letter) return true;

            return false;
        }
        #endregion
    }
}
