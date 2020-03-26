using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyShop.Data.Interfaces;
using MyShop.Data.Models;
using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Controllers
{
    //связь модели и отображения
    public class ItemsController : Controller
    {
        private readonly ILogger _logger;
        private readonly ICategory _category;
        private readonly IItem _item;

        public ItemsController(ILogger<ItemsController> logger, ICategory iCategory, IItem iItem)
        {
            _logger = logger;
            _category = iCategory;
            _item = iItem;
        }

        [Route("Items")]
        [Route("Items/List")]
        [Route("Items/List/{categoryName}")]
        public ViewResult List(string categoryName)
        {
            IEnumerable<Item> items = null;
            string currentCategoryName = "";
            IEnumerable<Category> categories = _category.categories;
            // выборка всех позиций
            if (string.IsNullOrEmpty(categoryName))
            {
                items = _item.items.OrderBy(i => i.id);
            }
            // выборка позиций по категории
            else
            {
                foreach (var el in categories)
                {
                    if (string.Equals(el.name, categoryName, StringComparison.OrdinalIgnoreCase))
                    {
                        items = _item.items.Where(i => i.category.name.Equals(el.name)).OrderBy(i => i.id);
                        currentCategoryName = el.name;
                    }
                }
            }
            var obj = new ItemsViewModel
            {
                modelName = "Все позиции",
                items = items,
                currentCategory = currentCategoryName
            };
            return View(obj);
        }

        [Route("Items/Index/id")]
        public ViewResult Index(int id)
        {
            var obj = _item.GetItem(id);
            return View(obj);
        }
    }
}
