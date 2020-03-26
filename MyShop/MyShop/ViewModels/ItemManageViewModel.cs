using MyShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.ViewModels
{
    public class ItemManageViewModel
    {
        public string modelName { get; set; }
        public IEnumerable<Item> items { get; set; }
    }
}
