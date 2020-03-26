using MyShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.ViewModels
{
    public class ItemsViewModel
    {
        public string modelName { get; set; }
        public IEnumerable<Item> items { get; set; }

        public string currentCategory { get; set; }
    }
}
