using MyShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.ViewModels
{
    public class CategoryEditViewModel
    {
        public string modelName { get; set; }
        public string btnName { get; set; }
        public Category category { get; set; }
    }
}
