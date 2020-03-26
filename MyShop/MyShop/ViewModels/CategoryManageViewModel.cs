using MyShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.ViewModels
{
    public class CategoryManageViewModel
    {
        public string modelName { get; set; }
        public string btnName { get; set; }
        public IEnumerable<Category> categories { get; set; }
    }
}
