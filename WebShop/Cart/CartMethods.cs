using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopMKJ.Cart
{
    public static class CartMethods
    {
        /// <summary>
        /// Displays all items in the customers cart and prints the total sum to pay. Asks if the user wants to checkout.
        /// </summary>
        public static void GetCurrentCart(int? customerId)
        {
            double? totalSum = 0;
            bool cartEmpty = false;

            var currentCart = Databasedapper.ShowSpecificCart();
            
                if (currentCart.Count == 0)
                {
                    Console.WriteLine("Your cart is empty");
                    Console.WriteLine("Press any button to return to Main Menu");
                    Console.ReadKey();
                    cartEmpty = true;
                }

                if (cartEmpty)
                    return;

                using (var db = new Models.WebShopContext())
                {
                    var cartWithPrices = (from
                                          cart in db.Carts
                                          join
                                          product in db.Products
                                          on cart.ProductId equals product.Id
                                          select new
                                          {
                                              cart.CustomerId,
                                              cart.ProductId,
                                              product.Name,
                                              cart.Quantity,
                                              product.Price,
                                          }).ToList();

                    var listWithPrices = cartWithPrices.ToList();

                    Console.WriteLine($"\tId\t Name\t Qty\t Price");
                    foreach (var item in listWithPrices)
                    {
                        if (customerId == item.CustomerId)
                        {
                            Console.WriteLine($"\t{item.ProductId}\t {item.Name}\t {item.Quantity}\t {item.Price * item.Quantity}");
                            totalSum += (item.Price * item.Quantity);
                        }
                    }

                    Console.WriteLine($"\tYour total will be {totalSum}");

                    Console.WriteLine("[1]. Checkout");
                    Console.WriteLine("[2]. Edit Cart");
                    Console.WriteLine("[3]. Return");
                    string choice = Console.ReadLine();

                if (choice == "1")
                    Checkout();
                else if (choice == "2")
                    EditCart();
                else if (choice == "3")
                    return;
                else
                {
                    Console.WriteLine("Wrong Input. Returning to main menu.");
                    Console.WriteLine("Press any button...");
                    Console.ReadKey();
                    return;
                }
                }
        }
        /// <summary>
        /// Asks the user to pick a shipper. The customer checks out, the order is added to Orders and OrderDetatails databases. Clears the customer specific cart.
        /// </summary>
        public static void Checkout()
        {
            Console.WriteLine("\tDo you wish to checkout?");
            Console.WriteLine("\t1. Yes | 2. No ");
            int choice = Program.MenuReader(1, 2);

                 if (choice == 2)
                  return;
                 else if(choice == 1)
                 {
                  Models.Order order = new Models.Order();
                  var currentCart = Databasedapper.ShowSpecificCart();

                  //Pick a shipper
                  order.ShipperId = Shop.Handler.ShowAndPickShipper();

                  //Pick an id
                  order.CustomerId = Menu.MenuModel.CustomerID;

                  //Add a date
                  DateTime d1 = new DateTime();
                  d1 = DateTime.Now;
                  order.OrderDate = d1;


                  // Add the order to the orders database.
                  Databasedapper.AddToOrders(order);

                  // Copy details from the current cart to order details. Add the data to the OrderDetails database.
                  foreach (var item in currentCart)
                  {
                    Models.OrderDetail orderDetail = new Models.OrderDetail();
                    orderDetail.OrderId = order.Id;
                    orderDetail.ProductId = item.ProductId;
                    orderDetail.Quantity = item.Quantity;
                    Databasedapper.AddToOrderDetails(orderDetail);
                  }
  
                  // Update the stock in the Inventory database.
                  Databasedapper.UpdateStockQuantity(currentCart);

                  // Clear the cart with the current customerID.
                  Databasedapper.ClearCart();

                  Console.WriteLine("Order successfully placed. Thank you for shopping with us.");
                  Console.ReadKey();
                 }
                 else
                 {
                  Console.WriteLine("Wrong input. Returning to main menu.");
                  Console.WriteLine("press any key...");
                  Console.ReadKey();
                  return;
                 }
        }

        public static void EditCart()
        {
            int amountChoice = 0;
            int productChoice = 0;
            Console.WriteLine("Which product ID would you like to edit?");
            Console.WriteLine("No changes will be saved if you input incorrect product ID.");
            string stringChoice = Console.ReadLine();

            Console.WriteLine("What quantity would you like to change to?");
            string stringChoice2 = Console.ReadLine();

            try
            {
                productChoice = Convert.ToInt32(stringChoice);
                amountChoice = Convert.ToInt32(stringChoice2);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Incorrect inputs detected. Press any key to return..");
                Console.ReadKey();
            }

            if (amountChoice > 0)
                Databasedapper.UpdateQuantityFromCurrentCart(amountChoice, productChoice, Menu.MenuModel.CustomerID);
            else if (amountChoice == 0)
                Databasedapper.DeleteFromCurrentCart(productChoice, Menu.MenuModel.CustomerID);
            else
            {
                Console.WriteLine("Incorrect choice. Press any key");
                Console.ReadKey();
                return;
            }


            
        }
    }
}
