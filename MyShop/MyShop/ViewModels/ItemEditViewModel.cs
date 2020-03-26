using Microsoft.AspNetCore.Mvc.Rendering;
using MyShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.ViewModels
{
    public class ItemEditViewModel
    {
        public string modelName { get; set; }
        public string btnName { get; set; }
        public SelectList categories { get; set; }
        public Item item { get; set; }
        public SelectList imgs { get; set; }
        public string imgBtnName { get; set; }
    }
}
