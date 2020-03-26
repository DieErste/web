using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Data.Models
{
    public class OrderDetail
    {
        public int id { get; set; }
        public uint quantity { get; set; }
        public double price { get; set; }
        public int orderID { get; set; }
        public int itemID { get; set; }
        public virtual Item item { get; set; }
        public virtual Order order { get; set; }
    }
}
