using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopMKJ.Models
{
    public class CustomersProductsAndDates
    {
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public int? Quantity { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
