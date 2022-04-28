using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopMKJ.LogIn
{
    static class Handler
    {
        /// <summary>
        /// Creates and adds new customer to database.
        /// </summary>
        public static void CreateNewCustomer()
        {
            var customer = new Models.Customer();

            string fullName;
            do
            {
                Console.Write($"\tEnter your full name: ");
                fullName = Console.ReadLine();
            } while (fullName.Length <= 3);

            string email;
            do
            {
                Console.Write($"\tEnter your email: ");
                email = Console.ReadLine();
            } while (email.Length <= 5);

            customer.Name = fullName;
            customer.Email = email;

            Databasedapper.CustomerAddToDatabase(customer);
        }

        /// <summary>
        /// Picks the customer.
        /// </summary>
        /// <returns>int, the customer id</returns>
        public static int? PickCustomer()
        {
            var customers = Databasedapper.ShowAllCustomers();
            Console.WriteLine("\tID\t Name");
            foreach (var customer in customers)
            {
                Console.WriteLine($"\t{customer.Id}\t {customer.Name}");
            }

            Console.Write("\n\tChoose a customer ID: ");
            if(customers.Count() > 0)
            {
                int input = Program.MenuReader(customers[0].Id, customers[^1].Id);
                return input;
            }
            return null;
        }
    }
}
