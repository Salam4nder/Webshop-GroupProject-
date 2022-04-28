using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebShopMKJ
{
    public static class EntityFrameworkMethods
    {
        public static void SearchEngine(string item)
        {
            using (var db = new Models.WebShopContext())
            {
                var products = db.Products;
                var productsResult =
                                from prod in products
                                where
                                prod.Name.Contains(item.ToUpper())
                                orderby prod.Name
                                select new
                                { prod.Name,
                                  prod.Price };

                foreach (var x in productsResult)
                {
                    Console.WriteLine($"\t{x.Name}\t {x.Price}");
                }
                Console.WriteLine("--------------------------------");
            }
        }
    }
}
