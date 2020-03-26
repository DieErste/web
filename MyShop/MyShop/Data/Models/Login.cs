using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Data.Models
{
    public class Login
    {
        public int id { get; set; }
        public DateTime time { get; set; }
        public string sessionID { get; set; }
        public User user { get; set; }
    }
}
