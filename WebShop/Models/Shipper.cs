using System;
using System.Collections.Generic;

#nullable disable

namespace WebShopMKJ.Models
{
    public partial class Shipper
    {
        public Shipper()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
