using Microsoft.Extensions.Logging;
using MyShop.Data.Interfaces;
using MyShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Data.Repository
{
    public class CategoryRepository : ICategory
    {
        private readonly ILogger _logger;
        private readonly AppDBContent _appDBContent;
        public CategoryRepository(ILogger<CategoryRepository> logger, AppDBContent appDBContent)
        {
            _logger = logger;
            _appDBContent = appDBContent;
        }
        public IEnumerable<Category> categories => _appDBContent.category.OrderBy(x => x.id);

        public bool Insert(Category category)
        {
            // проверка имени чтобы не совпадало
            if(_appDBContent.category.FirstOrDefault(c => string.Equals(c.name, category.name, StringComparison.OrdinalIgnoreCase)) != null)
            {
                return false;
            }
            _appDBContent.category.Add(category);
            _appDBContent.SaveChanges();
            return true;
        }

        public bool Delete(Category category)
        {
            Category category1  = _appDBContent.category.FirstOrDefault(c => c.id == category.id);
            if (category1 == null)
            {
                return false;
            }
            //check before items
            IEnumerable<Item> items = _appDBContent.item.Where(i => i.categoryID == category1.id).ToList();
            if(items.Any())
            {
                return false;
            }
            _appDBContent.category.Remove(category1);
            _appDBContent.SaveChanges();
            return true;
        }

        public bool Edit(Category category)
        {
            Category category1 = _appDBContent.category.FirstOrDefault(c => c.id == category.id);
            if(category1 == null)
            {
                return false;
            }
            category1.name = category.name;
            _appDBContent.category.Update(category1);
            _appDBContent.SaveChanges();
            return true;
        }

        public Category GetCategory(int id) => _appDBContent.category.FirstOrDefault(c => c.id == id);
    }
}
